using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace conti.maurizio._4H.MediaMobile
{
    class Campioni
    {
        public int Finestra { get; set; }

        public Campione[] Dati { get; private set; }
        public double[] MedieTemperature { get; private set; }

        public Campioni()
        {
            Dati = new Campione[] {
                new Campione{Data=DateTime.Now.AddDays(-10), Pressione=1010, Temperatura=18.1, Umidita=60 },
                new Campione{Data=DateTime.Now.AddDays(-9), Pressione=1009, Temperatura=18.2, Umidita=61 },
                new Campione{Data=DateTime.Now.AddDays(-8), Pressione=1008, Temperatura=18.3, Umidita=62 },
                new Campione{Data=DateTime.Now.AddDays(-7), Pressione=1007, Temperatura=18.4, Umidita=63 },
                new Campione{Data=DateTime.Now.AddDays(-6), Pressione=1006, Temperatura=18.5, Umidita=64 },
                new Campione{Data=DateTime.Now.AddDays(-5), Pressione=1005, Temperatura=25.0, Umidita=65 },
                new Campione{Data=DateTime.Now.AddDays(-4), Pressione=1004, Temperatura=18.7, Umidita=66 },
                new Campione{Data=DateTime.Now.AddDays(-3), Pressione=1003, Temperatura=18.8, Umidita=67 },
                new Campione{Data=DateTime.Now.AddDays(-2), Pressione=1002, Temperatura=18.9, Umidita=68 },
                new Campione{Data=DateTime.Now.AddDays(-1), Pressione=1001, Temperatura=19.0, Umidita=69 }
            };

            Finestra = 3;
        }

        public double MaxTemperatura { get { return Dati.Max(v => v.Temperatura); } }
        public double MinTemperatura { get { return Dati.Min(v => v.Temperatura); } }
        public double OffsetTemperatura { get { return MaxTemperatura - MinTemperatura; } }
        public double MediaTemperatura
        {
            get
            {
                double retVal = 0.0;
                int numeroGiri = Dati.Length - Finestra + 1;  // Se finestra vale 3 e ho 10 elementi, faccio 8 giri.
                MedieTemperature = new double[numeroGiri];

                for (int idx = 0; idx < numeroGiri; idx++)
                {
                    double tmp = 0.0;

                    // Ipotizzando Finestra == 3...
                    // ...facciamo 3 giri.
                    for (int idy = idx; idy < idx + Finestra; idy++)
                        tmp += Dati[idy].Temperatura;

                    tmp = tmp / Finestra;           // Calcola la media dei 3...
                    retVal += tmp;                  // la accumula 
                    MedieTemperature[idx] = tmp;    // e la memorizza...

                }
                return retVal / numeroGiri; // ... fa la media degli 8 giri
            }
        }

        public override string ToString()
        {
            return $"Su una finestra di {Finestra} valori:\nMedia Temperatura={MediaTemperatura}";
        }

        public string Valori
        {
            get
            {
                StringBuilder retVal = new StringBuilder();
                retVal.AppendLine(Dati[0].Titoli);
                foreach (Campione c in Dati)
                    retVal.AppendLine(c.ToString());
                retVal.AppendLine();
                retVal.AppendLine($"Media su finestra di {Finestra}\t{MediaTemperatura}");

                return retVal.ToString();
            }
        }
        public string GraficoTemperatura
        {
            get
            {
                int zoom = 10;

                StringBuilder retVal = new StringBuilder();
                foreach (Campione c in Dati)
                    retVal.AppendLine(c.RigaTemperatura(MinTemperatura, zoom));

                retVal.AppendLine();

                foreach (double v in MedieTemperature)
                {
                    double val = (v - MinTemperatura) * zoom;

                    StringBuilder sb = new StringBuilder();
                    sb.Append('*', (int)val + 1);
                    retVal.AppendLine(sb.ToString());
                }

                return retVal.ToString();
            }
        }
    }
}
