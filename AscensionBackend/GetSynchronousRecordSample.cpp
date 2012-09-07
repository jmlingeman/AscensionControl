//
// GetSynchronousRecordSample.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
//#include "Tracker.h"

extern "C" void exit( int);

//
// Forward declaration of error handler
// ====================================
//
// A very simple error handler is provided at the end of this file
// It simply takes error codes and converts them to message strings
// then outputs them to the console.
//
void errorHandler(int error);

// An output buffer
// 10000 records * 8 possible units * 4 sensors per unit *128 bytes of string storage
char output[10000][8*4][128] = { { { 0,}, }, };


//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//
//	Main program:
//
//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////

int main2()
{
	//Tracker			tracker(10000);
	CSystem			PCIBird;
	CSensor			*pSensor;
	CXmtr			*pXmtr;
	int				errorCode;
	int				i;
	int				sensorID;
	short			id;
	int				records = 10000;
	double			rate = 255.0f;

	printf("\n\n");
	printf("ATC3DG Timing Test Application\n");

	//////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////////////////
	//
	// Initialize the PCIBIRD driver and DLL
	//
	// It is always necessary to first initialize the PCIBird "system". By
	// "system" we mean the set of PCIBird cards installed in the PC. All cards
	// will be initialized by a single call to InitializeBIRDSystem(). This
	// call will first invoke a hardware reset of each board. If at any time 
	// during operation of the system an unrecoverable error occurs then the 
	// first course of action should be to attempt to Recall InitializeBIRDSystem()
	// if this doesn't restore normal operating conditions there is probably a
	// permanent failure - contact tech support.
	// A call to InitializeBIRDSystem() does not return any information.
	//
	printf("Initializing ATC3DG system...\n");
	errorCode = InitializeBIRDSystem();
	if(errorCode!=BIRD_ERROR_SUCCESS) 
	{
		errorHandler(errorCode);
		exit(1);
	}

	//////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////////////////
	//
	// GET SYSTEM CONFIGURATION
	//
	// In order to get information about the system we have to make a call to
	// GetBIRDSystemConfiguration(). This call will fill a fixed size structure
	// containing amongst other things the number of boards detected and the
	// number of sensors and transmitters the system can support (Note: This
	// does not mean that all sensors and transmitters that can be supported
	// are physically attached)
	//
	errorCode = GetBIRDSystemConfiguration(&PCIBird.m_config);
	if(errorCode!=BIRD_ERROR_SUCCESS) errorHandler(errorCode);

	//////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////////////////
	//
	// GET SENSOR CONFIGURATION
	//
	// Having determined how many sensors can be supported we can dynamically
	// allocate storage for the information about each sensor.
	// This information is acquired through a call to GetSensorConfiguration()
	// This call will fill a fixed size structure containing amongst other things
	// a status which indicates whether a physical sensor is attached to this
	// sensor port or not.
	//
	pSensor = new CSensor[PCIBird.m_config.numberSensors];
	for(i=0;i<PCIBird.m_config.numberSensors;i++)
	{
		errorCode = GetSensorConfiguration(i, &(pSensor+i)->m_config);
		if(errorCode!=BIRD_ERROR_SUCCESS) errorHandler(errorCode);
	}

	//////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////////////////
	//
	// GET TRANSMITTER CONFIGURATION
	//
	// The call to GetTransmitterConfiguration() performs a similar task to the 
	// GetSensorConfiguration() call. It also returns a status in the filled
	// structure which indicates whether a transmitter is attached to this
	// port or not. In a single transmitter system it is only necessary to 
	// find where that transmitter is in order to turn it on and use it.
	//
	pXmtr = new CXmtr[PCIBird.m_config.numberTransmitters];
	for(i=0;i<PCIBird.m_config.numberTransmitters;i++)
	{
		errorCode = GetTransmitterConfiguration(i, &(pXmtr+i)->m_config);
		if(errorCode!=BIRD_ERROR_SUCCESS) errorHandler(errorCode);
	}

	//
	// Set the measurement rate
	//
	errorCode = SetSystemParameter(MEASUREMENT_RATE, &rate, sizeof(rate));
	if(errorCode!=BIRD_ERROR_SUCCESS) errorHandler(errorCode);

	//
	//////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////////////////
	//
	// Search for the first attached transmitter and turn it on
	//
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

	//////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////////////////
	//
	// Collect data from all birds
	// Loop through all sensors and get a data record if the sensor is attached.
	// Print result to screen
	// Note: The default data format is DOUBLE_POSITION_ANGLES. We can use this
	// format without first setting it.
	// 
	//
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
				sprintf(output[i][sensorID], "[%d] 0x%04x %8.3f %8.3f %8.3f: %8.2f %8.2f %8.2f %8.4f\n",
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

	printf("\nSaving results to 'GetSynchronousRecord.dat'..\n");

	FILE *fp = fopen( "GetSynchronousRecord.dat", "w");
	for(i=0;i<records;i++)
		for(sensorID=0;sensorID<PCIBird.m_config.numberSensors;sensorID++)
			fprintf( fp, output[i][sensorID]);
	fclose( fp);
	printf("Complete...\n");

	//////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////////////////
	//
	// Turn off the transmitter before exiting
	// We turn off the transmitter by "selecting" a transmitter with an id of "-1"
	//
	id = -1;
	errorCode = SetSystemParameter(SELECT_TRANSMITTER, &id, sizeof(id));
	if(errorCode!=BIRD_ERROR_SUCCESS) errorHandler(errorCode);

	//////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////////////////
	//////////////////////////////////////////////////////////////////////////////
	//
	//  Free memory allocations before exiting
	//
	delete[] pSensor;
	delete[] pXmtr;

	return 0;
}


//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//
//	ERROR HANDLER
//	=============
//
// This is a simplified error handler.
// This error handler takes the error code and passes it to the GetErrorText()
// procedure along with a buffer to place an error message string.
// This error message string can then be output to a user display device
// like the console
// Specific error codes should be parsed depending on the application.
//
//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
void errorHandler(int error)
{
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


