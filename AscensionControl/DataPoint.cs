using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AscensionControl
{
    public class DataPoint
    {
        public int x, y, z, pitch, yaw, roll, qual, time;

        public DataPoint(int x, int y, int z, int pitch, int yaw, int roll, int qual, int time)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.pitch = pitch;
            this.yaw = yaw;
            this.roll = roll;
            this.qual = qual;
            this.time = time;
        }
    }
}
