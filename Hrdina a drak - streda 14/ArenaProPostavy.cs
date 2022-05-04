using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrdina_a_drak___streda_14
{
    public class ArenaProPostavy
    {
        public List<Postava> Postavy { get; set; }
        public ArenaProPostavy(List<Postava> postavy)
        {
            Postavy = postavy;
            foreach(var postava in Postavy)
            {
                postava.VybranNovyOponent += VypisInfoPoVyberuNovehoOponenta;
            }
        }

        public void Boj()
        {
            Bedna bedna = new Bedna(50, 2);
            while (LzeBojovat())
            {
                for (int i = 0; i < Postavy.Count; ++i)
                {
                    Postava utocnik = Postavy[i];
                    if (utocnik.MuzeBojovat())
                    {
                        Postava oponent = utocnik.VyberOponenta(Postavy);
                        if (oponent != null)
                        {
                            double utok = utocnik.Utok(oponent);
                            Console.WriteLine($"{utocnik.Jmeno} zaútočil hodnotou {utok}. {oponent.Jmeno} má {oponent.Zdravi} zdraví.");
                            
                            if (oponent.MuzeBojovat())
                            {
                                utok = oponent.Utok(utocnik);
                                Console.WriteLine($"{oponent.Jmeno} provedl protiútok hodnotou {utok}. {utocnik.Jmeno} má {utocnik.Zdravi} zdraví.");
                            }

                            if (utocnik.MuzeBojovat() && bedna.NeniRozbita())
                            {
                                utok = utocnik.Utok(bedna);
                                Console.WriteLine($"{utocnik.Jmeno} rozbíjí bednu hodnotou {utok}. Bedna má {bedna.Zdravi} zdraví.");
                            }
                        }
                    }
                }

                Console.WriteLine(String.Empty);
            }
        }

        public Task BojAsync()
        {
            return Task.Run(Boj);
        }

        public bool LzeBojovat()
        {
            if (PocetBojujicichPostav() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int PocetBojujicichPostav()
        {
            int pocet = 0;
            foreach (var postava in Postavy)
            {
                if (postava.MuzeBojovat() && postava.MuzeVybratOponenta(Postavy))
                    ++pocet;
            }
            return pocet;
        }

        void VypisInfoPoVyberuNovehoOponenta(Postava utocnik, Postava oponent)
        {
            Console.WriteLine($"Postava: {utocnik.Jmeno} si vybrala nového oponenta: {oponent.Jmeno}");
        }

        public void StatistikyPostav()
        {
            double prumernaSilaPostav = Postavy.Average(postava => postava.SilaPostavy());
            Console.WriteLine($"Průměrná síla všech postav je: {prumernaSilaPostav}");

            List<Postava> draci = Postavy.FindAll(postava => postava is Drak);
            //následující řádek dělá totéž jako ten další s lambda výrazem - v prvním případě se předá jen reference na již existující metodu a ve druhém metodu vytváříme pomocí lambda výrazu
            //draci.ForEach(Console.WriteLine);
            draci.ForEach(postava => Console.WriteLine(postava.ToString()));

            Console.WriteLine(String.Empty);
        }
    }
}
