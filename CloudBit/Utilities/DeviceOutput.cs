using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudBit.Utilities
{
    public class DeviceOutput
    {
        public string percent { get; set; }

        public string duration_ms { get; set; }

        public DeviceOutput( String percent, String duration_ms )
        {
            this.percent = percent;
            this.duration_ms = duration_ms;
        }
    }
}