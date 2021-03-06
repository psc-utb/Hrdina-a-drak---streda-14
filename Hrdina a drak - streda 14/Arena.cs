using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrdina_a_drak___streda_14
{
    public class Arena
    {
        public Hrdina Hrdina { get; set; }
        public Drak Drak { get; set; }

        public Arena(Hrdina hrdina, Drak drak)
        {
            Hrdina = hrdina;
            Drak = drak;
        }

        public void Boj()
        {
            while (Hrdina.MuzeBojovat() && Drak.MuzeBojovat())
            {
                double utok = Hrdina.Utok(Drak);
                Console.WriteLine($"Hrdina zaútočil hodnotou {utok}. Drakovi zbývá {Drak.Zdravi} zdraví.");
                if (Drak.MuzeBojovat())
                {
                    utok = Drak.Utok(Hrdina);
                    Console.WriteLine($"Drak zaútočil hodnotou {utok}. Hrdinovi zbývá {Hrdina.Zdravi} zdraví.");
                }

                //try
                //{
                //    utok = Drak.Utok(Hrdina);
                //    Console.WriteLine($"Drak zaútočil hodnotou {utok}. Hrdinovi zbývá {Hrdina.Zdravi} zdraví.");
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}

                Console.WriteLine(String.Empty);
            }
        }
    }
}
