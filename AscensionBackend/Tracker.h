#pragma once
#include "StdAfx.h"
#include "Record.h"

class Tracker
{
public:
	//char output[10000][8*4][128]
	struct SENSOR {
		double x, y, z, pitch, yaw, roll, quality, time;
	};

	struct RECORD {
		SENSOR sensors[32];
	};

	std::vector<Record> output;
	
	CSystem			PCIBird;
	CSensor			*pSensor;
	CXmtr			*pXmtr;
	int				errorCode;
	int				i;
	int				sensorID;
	short			id;
	int				records;
	double			rate;
	DOUBLE_POSITION_ANGLES_TIME_Q_RECORD record[8*4], *pRecord;

	Tracker(int buffersize);
	~Tracker();
	void errorHandler(int error);
	void InitializeTracker(void);
	void GetSystemConfiguration(void);
	void GetSensorConfig(void);
	void GetTransmitterConfig(void);
	void SetRecordRate(int rate);
	RECORD FillRecord(DOUBLE_POSITION_ANGLES_TIME_Q_RECORD* pRecord);
	void EnableTransmitter(void);
	RECORD GetSyncRecord(void);
	void GetAsyncRecord(void);
	void RunDemo(void);

};

