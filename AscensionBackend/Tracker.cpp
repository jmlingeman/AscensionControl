#include "Tracker.h"

Tracker::Tracker(int bs) {
	printf("Initializing class...\n");

	// Initialize some of the params
	rate = 255.0f;
	records = 10000;

	// Initialize the output array
	int buffersize = 10000;
	//for(int i = 0; i < buffersize; i++) {
	//	
	//}
}

void Tracker::errorHandler(int error) {
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

void Tracker::InitializeTracker(void) {
	printf("Initializing ATC3DG system...\n");
	errorCode = InitializeBIRDSystem();
	if(errorCode!=BIRD_ERROR_SUCCESS) 
	{
		errorHandler(errorCode);
		exit(1);
	}
}

// TODO: This needs to have some struct being returned to C# containing this information
void Tracker::GetSystemConfiguration(void) {
	errorCode = GetBIRDSystemConfiguration(&PCIBird.m_config);
	if(errorCode!=BIRD_ERROR_SUCCESS) errorHandler(errorCode);
}

void Tracker::GetSensorConfig(void) {
	pSensor = new CSensor[PCIBird.m_config.numberSensors];
	for(i=0;i<PCIBird.m_config.numberSensors;i++)
	{
		errorCode = GetSensorConfiguration(i, &(pSensor+i)->m_config);
		if(errorCode!=BIRD_ERROR_SUCCESS) errorHandler(errorCode);
	}
}

void Tracker::GetTransmitterConfig(void) {
	pXmtr = new CXmtr[PCIBird.m_config.numberTransmitters];
	for(i=0;i<PCIBird.m_config.numberTransmitters;i++)
	{
		errorCode = GetTransmitterConfiguration(i, &(pXmtr+i)->m_config);
		if(errorCode!=BIRD_ERROR_SUCCESS) errorHandler(errorCode);
	}
}

void Tracker::SetRecordRate(int rate) {
	errorCode = SetSystemParameter(MEASUREMENT_RATE, &rate, sizeof(rate));
	if(errorCode!=BIRD_ERROR_SUCCESS) errorHandler(errorCode);
}

void Tracker::EnableTransmitter(void) {
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

Tracker::RECORD Tracker::GetSyncRecord(void) {
	pRecord = record;
	
	errorCode = GetSynchronousRecord(ALL_SENSORS, pRecord, sizeof(record[0]) * PCIBird.m_config.numberSensors);
	if(errorCode!=BIRD_ERROR_SUCCESS) 
	{
			errorHandler(errorCode);
	}

	RECORD rec = FillRecord(pRecord);

	return rec;
}

Tracker::RECORD Tracker::FillRecord(DOUBLE_POSITION_ANGLES_TIME_Q_RECORD* pRecord) {
	// scan the sensors and request a record if the sensor is physically attached
	RECORD rec;
	for(sensorID=0;sensorID<PCIBird.m_config.numberSensors;sensorID++)
	{
		// get the status of the last data record
		// only report the data if everything is okay
		unsigned int status = GetSensorStatus( sensorID);

		if( status == VALID_STATUS)
		{
			rec.sensors[sensorID].x = record[sensorID].x;
			rec.sensors[sensorID].y = record[sensorID].y;
			rec.sensors[sensorID].z = record[sensorID].y;
			rec.sensors[sensorID].pitch = record[sensorID].e;
			rec.sensors[sensorID].yaw = record[sensorID].a;
			rec.sensors[sensorID].roll = record[sensorID].r;
			rec.sensors[sensorID].time = record[sensorID].time;
			rec.sensors[sensorID].quality = record[sensorID].quality;
		}  
			
	}
	return rec;
}

void Tracker::GetAsyncRecord(void) {
}

void Tracker::RunDemo(void) {
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

Tracker::~Tracker() {
}
