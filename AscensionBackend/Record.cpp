#include "stdafx.h"
#include "Record.h"

Record::Record(CSystem*	PCIBird, DOUBLE_POSITION_ANGLES_TIME_Q_RECORD* record) {
for(int sensorID=0;sensorID<PCIBird->m_config.numberSensors;sensorID++)
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


Record::~Record(void)
{
}
