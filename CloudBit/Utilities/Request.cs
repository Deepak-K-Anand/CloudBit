using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CloudBit.Utilities
{
    public class Request
    {
        public string DeviceId { get; set; }

        public string Key { get; set; }

        public string Duration { get; set; }

        public string Strength { get; set; }

        public bool AreParamsMissing()
        {
            return  String.IsNullOrEmpty(this.DeviceId) ||
                    String.IsNullOrEmpty(this.Key) ||
                    String.IsNullOrEmpty(this.Duration) ||
                    String.IsNullOrEmpty(this.Strength);
        }
    }
}