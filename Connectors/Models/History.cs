using System;
using System.Collections.Generic;

namespace Connectors.Models
{
    public class History
    {
        public List<int> Time;
        public List<float> Open;
        public List<float> High;
        public List<float> Low;
        public List<float> Close;

        public History()
        {
            this.Time = new List<int>();
            this.Open = new List<float>();
            this.High = new List<float>();
            this.Low = new List<float>();
            this.Close = new List<float>();
        }
    }
}
