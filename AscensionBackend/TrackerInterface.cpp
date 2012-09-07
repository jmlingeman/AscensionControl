#include "StdAfx.h"

double rate = 80.0f;

// Initialize the output array
int buffersize = 10000;

struct RECORD;
void FillRecord(DOUBLE_POSITION_ANGLES_TIME_Q_BUTTON_RECORD*);

//
//
struct RECORD {
	int num;
	int active[32];
	double x[32], y[32], z[32], pitch[32], roll[32], yaw[32], time[32];
	unsigned short quality[32], button[32];
};

RECORD* rec;

extern "C" {
    __declspec(dllexport) void __cdecl InitializeTracker(double* rate, double* range);
}

extern "C" {
    __declspec(dllexport) void __cdecl SetRecordRate(double rate);
}

extern "C" {
    __declspec(dllexport) RECORD* __cdecl GetSyncRecord();
}

extern void __cdecl GetSystemConfiguration(void);
extern void __cdecl GetSensorConfig(void);
extern void __cdecl GetTransmitterConfig(void);
extern void __cdecl SetRecordRate(double rate);
extern void __cdecl SetMaximumRange(double range);
extern void __cdecl EnableTransmitter(void);

	
CSystem			PCIBird;
CSensor			*pSensor;
CXmtr			*pXmtr;
int				errorCode;
int				i;
int				sensorID;
short			id;
//int				records;
//double			rate;
DOUBLE_POSITION_ANGLES_TIME_Q_BUTTON_RECORD record[8*4], *pRecord;

void errorHandler(int error) {
	char			buffer[1024];
	char			*pBuffer = &buffer[0];
	int				numberBytes;

	while(error!=BIRD_ERROR_SUCCESS)
	{
		error = GetErrorText(error, pBuffer, sizeof(buffer), SIMPLE_MESSAGE);
		numberBytes = strlen(buffer);
		buffer[numberBytes] = '\n';		// append a newline to buffer
		printf("%s", buffer);
	}
}

extern void __cdecl InitializeTracker(double* rate, double* range) {
	printf("Initializing ATC3DG system...\n");
	
	printf("Record size: %d", sizeof(RECORD));
	errorCode = InitializeBIRDSystem();
	if(errorCode!=BIRD_ERROR_SUCCESS) 
	{
		errorHandler(errorCode);
		exit(1);
	}

	//errorCode = GetBIRDSystemConfiguration(&PCIBird.m_config);
	//if(errorCode!=BIRD_ERROR_SUCCESS) errorHandler(errorCode);

	//pXmtr = new CXmtr[PCIBird.m_config.numberTransmitters];
	//for(i=0;i<PCIBird.m_config.numberTransmitters;i++)
	//{
	//	errorCode = GetTransmitterConfiguration(i, &(pXmtr+i)->m_config);
	//	if(errorCode!=BIRD_ERROR_SUCCESS) errorHandler(errorCode);
	//}

	//for(id=0;id<PCIBird.m_config.numberTransmitters;id++)
	//{
	//	if((pXmtr+id)->m_config.attached)
	//	{
	//		// Transmitter selection is a system function.
	//		// Using the SELECT_TRANSMITTER parameter we send the id of the
	//		// transmitter that we want to run with the SetSystemParameter() call
	//		errorCode = SetSystemParameter(SELECT_TRANSMITTER, &id, sizeof(id));
	//		if(errorCode!=BIRD_ERROR_SUCCESS) errorHandler(errorCode);
	//		break;
	//	}
	//}
	
	
	
	rec = (RECORD *)malloc(sizeof(RECORD));
	rec->num = 0;

	GetSystemConfiguration();
	GetSensorConfig();
	GetTransmitterConfig();

	SetRecordRate(*rate);
	SetMaximumRange(*range);

	bool metric = true;
	SetSystemParameter(METRIC, &metric, sizeof(metric));

	EnableTransmitter();

	// Set the data format type for each attached sensor.
	for(i=0;i<PCIBird.m_config.numberSensors;i++)
	{
		DATA_FORMAT_TYPE type = DOUBLE_POSITION_ANGLES_TIME_Q_BUTTON;
		errorCode = SetSensorParameter(i,DATA_FORMAT,&type,sizeof(type));
		if(errorCode!=BIRD_ERROR_SUCCESS) errorHandler(errorCode);
	}

	printf("\nData rate: %f\n", PCIBird.m_config.measurementRate);
	
}

// TODO: This needs to have some struct being returned to C# containing this information
extern void __cdecl GetSystemConfiguration(void) {
	errorCode = GetBIRDSystemConfiguration(&PCIBird.m_config);
	if(errorCode!=BIRD_ERROR_SUCCESS) errorHandler(errorCode);
}

extern void __cdecl GetSensorConfig(void) {
	pSensor = new CSensor[PCIBird.m_config.numberSensors];
	for(i=0;i<PCIBird.m_config.numberSensors;i++)
	{
		errorCode = GetSensorConfiguration(i, &(pSensor+i)->m_config);
		if(errorCode!=BIRD_ERROR_SUCCESS) errorHandler(errorCode);
	}
}

extern void __cdecl GetTransmitterConfig(void) {
	pXmtr = new CXmtr[PCIBird.m_config.numberTransmitters];
	for(i=0;i<PCIBird.m_config.numberTransmitters;i++)
	{
		errorCode = GetTransmitterConfiguration(i, &(pXmtr+i)->m_config);
		if(errorCode!=BIRD_ERROR_SUCCESS) errorHandler(errorCode);
	}
}

extern void __cdecl SetMaximumRange(double range) {
	errorCode = SetSystemParameter(MAXIMUM_RANGE, &range, sizeof(range));
	if(errorCode!=BIRD_ERROR_SUCCESS) errorHandler(errorCode);
}

extern void __cdecl SetRecordRate(double rate) {
	errorCode = SetSystemParameter(MEASUREMENT_RATE, &rate, sizeof(rate));
	if(errorCode!=BIRD_ERROR_SUCCESS) errorHandler(errorCode);
}

extern void __cdecl SetAGC(double agc_val) {
	AGC_MODE_TYPE agc;
	if(agc_val == 0)
		agc = SENSOR_AGC_ONLY;
	else
		agc = TRANSMITTER_AND_SENSOR_AGC;

	errorCode = SetSystemParameter(AGC_MODE, &agc, sizeof(agc));
	if(errorCode!=BIRD_ERROR_SUCCESS) errorHandler(errorCode);
}

extern void __cdecl EnableTransmitter(void) {
	for(id=0;id<PCIBird.m_config.numberTransmitters;id++)
	{
		if((pXmtr+id)->m_config.attached)
		{
			// Transmitter selection is a system function.
			// Using the SELECT_TRANSMITTER parameter we send the id of the
			// transmitter that we want to run with the SetSystemParameter() call
			errorCode = SetSystemParameter(SELECT_TRANSMITTER, &id, sizeof(id));
			if(errorCode!=BIRD_ERROR_SUCCESS) errorHandler(errorCode);
			break;
		}
	}
}

//extern RECORD* __cdecl GetSyncRecord() {
//	pRecord = record;
//	
//	errorCode = GetSynchronousRecord(ALL_SENSORS, pRecord, sizeof(record[0]) * PCIBird.m_config.numberSensors);
//	if(errorCode!=BIRD_ERROR_SUCCESS) 
//	{
//			errorHandler(errorCode);
//	}
//
//	rec = FillRecord(pRecord);
//
//	return &rec;
//}


extern RECORD* __cdecl GetSyncRecord() {
	//	printf("Initializing ATC3DG system...\n");
	//
	//printf("Record size: %d", sizeof(RECORD));
	//errorCode = InitializeBIRDSystem();
	//if(errorCode!=BIRD_ERROR_SUCCESS) 
	//{
	//	errorHandler(errorCode);
	//	exit(1);
	//}

	//errorCode = GetBIRDSystemConfiguration(&PCIBird.m_config);
	//if(errorCode!=BIRD_ERROR_SUCCESS) errorHandler(errorCode);

	//pXmtr = new CXmtr[PCIBird.m_config.numberTransmitters];
	//for(i=0;i<PCIBird.m_config.numberTransmitters;i++)
	//{
	//	errorCode = GetTransmitterConfiguration(i, &(pXmtr+i)->m_config);
	//	if(errorCode!=BIRD_ERROR_SUCCESS) errorHandler(errorCode);
	//}

	//for(id=0;id<PCIBird.m_config.numberTransmitters;id++)
	//{
	//	if((pXmtr+id)->m_config.attached)
	//	{
	//		// Transmitter selection is a system function.
	//		// Using the SELECT_TRANSMITTER parameter we send the id of the
	//		// transmitter that we want to run with the SetSystemParameter() call
	//		errorCode = SetSystemParameter(SELECT_TRANSMITTER, &id, sizeof(id));
	//		if(errorCode!=BIRD_ERROR_SUCCESS) errorHandler(errorCode);
	//		break;
	//	}
	//}
	
	
	
	//rec = (RECORD *)malloc(sizeof(RECORD));
	//rec->num =  sizeof(record[0]);
	//printf("Record[0] size: %d\n", rec->num);

	//GetSystemConfiguration();
	//GetTransmitterConfig();
	//GetSensorConfig();
	//
	//SetRecordRate(255.0f);
	//EnableTransmitter();

	pRecord = record;
	
	rec->num++;
	errorCode = GetSynchronousRecord(ALL_SENSORS, pRecord, sizeof(record[0]) * PCIBird.m_config.numberSensors);
	if(errorCode!=BIRD_ERROR_SUCCESS) 
	{
			errorHandler(errorCode);
			exit(1);
	}

	FillRecord(pRecord);

	//rec->num = GetSensorStatus( 0);

	return rec;
}

//SENSOR* FillRecord(DOUBLE_POSITION_ANGLES_TIME_Q_RECORD* pRecord) {
void FillRecord(DOUBLE_POSITION_ANGLES_TIME_Q_BUTTON_RECORD* pRecord) {
	// scan the sensors and request a record if the sensor is physically attached
	//RECORD* ptr;
	//ptr = rec;
	for(sensorID=0;sensorID<PCIBird.m_config.numberSensors;sensorID++)
	{
		// get the status of the last data record
		// only report the data if everything is okay
		unsigned int status = GetSensorStatus( sensorID);

		if( status == VALID_STATUS)
		{
			rec->active[sensorID] = 1;
			rec->x[sensorID] = record[sensorID].x;
			rec->y[sensorID] = record[sensorID].y;
			rec->z[sensorID] = record[sensorID].z;
			rec->pitch[sensorID] = record[sensorID].e;
			rec->roll[sensorID] = record[sensorID].r;
			rec->yaw[sensorID] = record[sensorID].a;
			rec->time[sensorID] = record[sensorID].time;
			rec->quality[sensorID] = record[sensorID].quality;
			rec->button[sensorID] = record[sensorID].button;
		}
		else
		{
			rec->active[sensorID] = 0;
			rec->x[sensorID] = 0;
			rec->y[sensorID] = 0;
			rec->z[sensorID] = 0;
			rec->pitch[sensorID] = 0;
			rec->roll[sensorID] = 0;
			rec->yaw[sensorID] = 0;
			rec->time[sensorID] = 0;
			rec->quality[sensorID] = 0;
			rec->button[sensorID] = 0;
		}
			
	}
	//return rec;
}

extern void __cdecl GetAsyncRecord(void) {
}

extern void __cdecl RunDemo(void) {
	int records = 1000;
	printf("Beginning test data collection...\n");

	DOUBLE_POSITION_ANGLES_TIME_Q_RECORD record[8*4], *pRecord = record;

	// Set the data format type for each attached sensor.
	for(i=0;i<PCIBird.m_config.numberSensors;i++)
	{
		DATA_FORMAT_TYPE type = DOUBLE_POSITION_ANGLES_TIME_Q;
		errorCode = SetSensorParameter(i,DATA_FORMAT,&type,sizeof(type));
		if(errorCode!=BIRD_ERROR_SUCCESS) errorHandler(errorCode);
	}

	// collect as many records as specified in the records var
	printf("Collecting %d data records at %3.2fhz...\n", records, rate*3.0);
	for(i=0;i<records;i++)
	{
		errorCode = GetSynchronousRecord(ALL_SENSORS, pRecord, sizeof(record[0]) * PCIBird.m_config.numberSensors);

		if(errorCode!=BIRD_ERROR_SUCCESS) 
		{
			errorHandler(errorCode);
		}

		// Get a snap shot of the PC's time
		time_t currentTime;
		time(&currentTime);

		// Some user IO, every 500 records print a progress indication
		if( !(i % 500)) 
			printf( ".");

		// scan the sensors and request a record if the sensor is physically attached
		for(sensorID=0;sensorID<PCIBird.m_config.numberSensors;sensorID++)
		{
			// get the status of the last data record
			// only report the data if everything is okay
			unsigned int status = GetSensorStatus( sensorID);

			if( status == VALID_STATUS)
			{
				// save output to buffer
				//sprintf(output[i][sensorID], "[%d] 0x%04x %8.3f %8.3f %8.3f: %8.2f %8.2f %8.2f %8.4f\n",
				//	sensorID,
				//	status,
				//	record[sensorID].x,
				//	record[sensorID].y,
				//	record[sensorID].z,
				//	record[sensorID].a,
				//	record[sensorID].e,
				//	record[sensorID].r,
				//	record[sensorID].time
				//	);
				printf("[%d] 0x%04x %8.3f %8.3f %8.3f: %8.2f %8.2f %8.2f %8.4f\n",
					sensorID,
					status,
					record[sensorID].x,
					record[sensorID].y,
					record[sensorID].z,
					record[sensorID].a,
					record[sensorID].e,
					record[sensorID].r,
					record[sensorID].time
					);
			}  
			
		}
	}
}
