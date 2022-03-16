﻿using System;

namespace Hrdina_a_drak___streda_14
{
    class Program
    {
        static void Main(string[] args)
        {
            Mec mec = new Mec(20);
            Hrdina hrdina = new Hrdina("Geralt", 100, 100, 14, 10, mec);
            Hrdina hrdina2 = new Hrdina("Dovahkiin", 100, 10, 10);
            Drak drak = new Drak("Alduin", 100, 100, 11, 10);
            Vlk vlk = new Vlk("Wolf", 50, 50, 5, 5);

            /*Arena arena = new Arena(hrdina, drak);
            arena.Boj();*/

            Postava[] postavy = new Postava[] { hrdina, drak, hrdina2, vlk };
            ArenaProPostavy arena = new ArenaProPostavy(postavy);
            arena.Boj();
        }
    }
}
