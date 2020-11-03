using System;
using System.Collections.Generic;
using System.Text;

namespace conti.maurizio._4H.MediaMobile
{
    class Campione
    {
        public DateTime Data { get; set; }
        public double Temperatura { get; set; }
        public int Umidita { get; set; }
        public int Pressione { get; set; }

        public override string ToString()
        {
            return $"{Data}\t{Temperatura}\t{Umidita}\t{Pressione}";
        }
        
        public string Titoli
        {
            get
            {
                return "Datetime\t\t\tTemp\tUmid\tPres";
            }
        }

        public string RigaTemperatura(double offset, int zoom=1)
        {
            double val = (Temperatura - offset)*zoom;
            StringBuilder retVal = new StringBuilder();
            retVal.Append( '*', (int)val+1 );
            return retVal.ToString();
        }

    }
}
