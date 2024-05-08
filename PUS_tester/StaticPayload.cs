using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUS_tester
{
    public static class StaticPayload
    {
        public static readonly List<byte> _Payload = new List<byte>();

        public static List<byte> PayloadList
        {
            get
            {
                if (_Payload.Count < 1)
                {
                    //Load Customer data
                }
                return _Payload;
            }
        }
    }
}
