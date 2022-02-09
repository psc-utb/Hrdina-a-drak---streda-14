﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrdina_a_drak___streda_14
{
    public class Hrdina
    {
        public string Jmeno { get; set; }
        public double Zdravi { get; set; }
        public double ZdraviMax { get; set; }
        public double PoskozeniMax { get; set; }
        public double ZbrojMax { get; set; }

        public Hrdina(string jmeno, double zdravi, double zdraviMax, double poskozeniMax, double zbrojMax)
        {
            Jmeno = jmeno;
            Zdravi = zdravi;
            ZdraviMax = zdraviMax;
            PoskozeniMax = poskozeniMax;
            ZbrojMax = zbrojMax;
        }

        public double Utok(Drak oponent)
        {
            double hodnotaUtoku = 0;

            Random rnd = new Random();
            hodnotaUtoku = rnd.NextDouble() * PoskozeniMax;
            hodnotaUtoku -= oponent.Obrana();
            this.NastavNuluKdyzJeZaporne(ref hodnotaUtoku);
            oponent.Zdravi -= hodnotaUtoku;

            return hodnotaUtoku;
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
