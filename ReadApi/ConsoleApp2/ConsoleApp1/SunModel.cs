using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WindowsFormsApp2
{
    public class Record
    {
        public Results Results { get; set; }

       public string  Status { get; set; }

        public override string ToString()
        {
            return "Results=["+Results.ToString()+"], Status="+ Status;
        }
    }

    public class Results
    {
        public string Sunrise { get; set; }
        public string Sunset { get; set; }

        public override string ToString()
        {
            return "Sunrise=" + Sunrise+ ", Sunset="+ Sunset;
        }
    }


    

}


//{
//	"results": {
//		"sunrise": "7:00:05 AM",
//		"sunset": "6:02:43 PM",
//		"solar_noon": "12:31:24 PM",
//		"day_length": "11:02:38",
//		"civil_twilight_begin": "6:33:55 AM",
//		"civil_twilight_end": "6:28:53 PM",
//		"nautical_twilight_begin": "6:03:45 AM",
//		"nautical_twilight_end": "6:59:03 PM",
//		"astronomical_twilight_begin": "5:33:46 AM",
//		"astronomical_twilight_end": "7:29:02 PM"
//	},
//	"status": "OK"
//}