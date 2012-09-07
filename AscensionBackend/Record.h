#pragma once
class Record
{
public:
	double x, y, z, pitch, yaw, roll, quality, time;
	struct tagSensor {
		int x, y, z, pitch, yaw, roll;
	} Sensor;
	Record(CSystem*, DOUBLE_POSITION_ANGLES_TIME_Q_RECORD*);
	~Record(void);
};

