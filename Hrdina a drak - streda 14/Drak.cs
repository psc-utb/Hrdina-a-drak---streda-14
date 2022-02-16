using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrdina_a_drak___streda_14
{
    public class Drak
    {
        public string Jmeno { get; set; }
        public double Zdravi { get; set; }
        public double ZdraviMax { get; set; }
        public double PoskozeniMax { get; set; }
        public double ZbrojMax { get; set; }
        public bool Utekl { get; set; }

        public Drak(string jmeno, double zdravi, double zdraviMax, double poskozeniMax, double zbrojMax)
        {
            Jmeno = jmeno;
            Zdravi = zdravi;
            ZdraviMax = zdraviMax;
            PoskozeniMax = poskozeniMax;
            ZbrojMax = zbrojMax;
            Utekl = false;
        }


        /// <summary>
        /// útok draka na hrdinu
        /// </summary>
        /// <param name="oponent">oponent draka - hrdina</param>
        /// <returns>hodnota utoku</returns>
        /// <exception cref="Exception">postava již nemůže bojovat</exception>
        public double Utok(Hrdina oponent)
        {
            if (MuzeBojovat())
            {
                double hodnotaUtoku = 0;

                Random rnd = new Random();
                hodnotaUtoku = rnd.NextDouble() * PoskozeniMax;
                hodnotaUtoku -= oponent.Obrana();
                this.NastavNuluKdyzJeZaporne(ref hodnotaUtoku);
                oponent.Zdravi -= hodnotaUtoku;

                return hodnotaUtoku;
            }
            else
                throw new Exception("Drak útočí a přitom už nemůže bojovat!");
        }

        public double Obrana()
        {
            double hodnotaObrany = 0;

            //dodelat

            return hodnotaObrany;
        }

        private void NastavNuluKdyzJeZaporne(ref double hodnota)
        {
            if (hodnota < 0)
                hodnota = 0;
        }

        public bool MuzeBojovat()
        {
            return JeZivy() && Utekl == false;
        }

        public bool JeZivy()
        {
            if (Zdravi > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
