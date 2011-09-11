using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace AscensionControl
{

    public class TrackerInterface
    {
        public static long recordnum = 0;
        public int init_error = 0;

        public TrackerInterface(float datarate)
        {
            int ret = InitializeTrackerWrapper(datarate);
            if (ret != 0)
            {
                init_error = -1;
            }
        }

        [DllImport("TrackerWrapper.dll")]
        public static extern IntPtr GetSyncRecord();

        [DllImport("TrackerWrapper.dll")]
        public static extern void InitializeTracker();

        [DllImport("TrackerWrapper.dll")]
        public static extern void GetSystemConfiguration();

        [DllImport("TrackerWrapper.dll")]
        public static extern void GetTransmitterConfig();

        [DllImport("TrackerWrapper.dll")]
        public static extern void SetRecordRate(System.Single rate);

        [DllImport("TrackerWrapper.dll")]
        public static extern void RunDemo();

        [StructLayout(LayoutKind.Sequential), Serializable]
        public struct Sensor
        {
            //[MarshalAsAttribute(UnmanagedType.I4)]
            public int x;

            //[MarshalAsAttribute(UnmanagedType.SysInt)]
            public int y;

            //[MarshalAsAttribute(UnmanagedType.SysInt)]
            public int z;

            //[MarshalAsAttribute(UnmanagedType.SysInt)]
            public int pitch;

            //[MarshalAsAttribute(UnmanagedType.SysInt)]
            public int yaw;

            //[MarshalAsAttribute(UnmanagedType.SysInt)]
            public int roll;

            //[MarshalAsAttribute(UnmanagedType.SysInt)]
            public int time;

            //[MarshalAsAttribute(UnmanagedType.SysInt)]
            public int quality;
        };

        [StructLayout(LayoutKind.Sequential), Serializable]
        public struct Record
        {
            public int idnum;

            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32)]
            public int[] active;

            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32)]
            public double[] x;

            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32)]
            public double[] y;

            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32)]
            public double[] z;

            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32)]
            public double[] pitch;

            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32)]
            public double[] roll;

            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32)]
            public double[] yaw;

            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32)]
            public double[] time;

            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32)]
            public ushort[] quality;

            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32)]
            public ushort[] button;
            //public IntPtr sensors;
        };


        public static int InitializeTrackerWrapper(float datarate)
        {
            //IntPtr r = GetSyncRecord();

            try
            {
                InitializeTracker();
                return 0;
            }
            catch (Exception e)
            {
                
                return -1;
            }
            //System.Single clr_datarate = datarate;
            //SetRecordRate(clr_datarate);
            //Stopwatch sw = Stopwatch.StartNew();
            //int i = 0;
            //while (i < 1000)
            //{
            //    IntPtr r = GetSyncRecord();
            //    Record record = (Record)Marshal.PtrToStructure(r, typeof(Record));
            //    Console.WriteLine("{3} X: {0} Y: {1} Z: {2}, Q: {4}, P: {5}, YAW: {6}, R: {7}, T: {8}", record.x[0], record.y[0], record.z[0], record.idnum, record.quality[0], record.pitch[0], record.yaw[0], record.roll[0], record.time[0]);
            //    Console.WriteLine("STATUS FOR SENSOR 2: {0}", record.active[1]);
            //    i++;
            //}
            //sw.Stop();

            //Console.WriteLine("Records per sec: {0}\nTotal Time: {1}",  1000.0 / (sw.ElapsedMilliseconds / 1000.0), sw.ElapsedMilliseconds / 1000.0);
        }


        public SensorReading GetRecord() {
            // Get the record and put it into a C# object for storage.
            IntPtr r = GetSyncRecord();
            Record record = (Record)Marshal.PtrToStructure(r, typeof(Record));

            SensorReading sr = new SensorReading(recordnum, record);
            recordnum++;

            return sr;
        }
    }
}
