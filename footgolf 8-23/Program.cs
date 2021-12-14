using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace footgolf_8_23
{
  internal class Program
  {
    static List<Jatekos> jatekosok = new List<Jatekos>();
    static void Main(string[] args)
    {
      Beolvasas();
      HarmadikFeladat();
      NegyedikFeladat();
      HatodikFeladat();
      HetedikFeladat();
      NyolcadikFeladat();
      Console.ReadKey();
      //40 perc alatt lett kész!
    }

    private static void NyolcadikFeladat()
    {
      Dictionary<string, int> stat = jatekosok.GroupBy(x => x.egyesulet).Select(y => new { y.Key, Value = y.Count() }).ToDictionary(z => z.Key, z => z.Value);
      Console.WriteLine("8.feladat: Egyesület statisztika");
      foreach (var s in stat)
      {
        if (s.Value!=1 && s.Value!=2 && s.Key !="n.a.")
        {
          Console.WriteLine($"\t{s.Key} - {s.Value} fő");
        }
      }
    }

    private static void HetedikFeladat()
    {
      using (StreamWriter ki = new StreamWriter("osszpontFF.txt"))
      {
        foreach (var j in jatekosok)
        {
          if (j.kategoria=="Felnott ferfi")
          {
            ki.WriteLine($"{j.nev};{j.osszpontszam}");
          }
        }
      }
    }

    private static void HatodikFeladat()
    {
      Jatekos atmeneti = jatekosok.First(x => x.osszpontszam == jatekosok.Max(y => y.osszpontszam));
      Console.WriteLine($"6.feladat: A bajnok női versenyző:\n\tNév: {atmeneti.nev}\n\tEgyesület: {atmeneti.egyesulet}\n\tÖsszpontszám:{atmeneti.osszpontszam}");
    }

    private static void NegyedikFeladat()
    {
      int noi = jatekosok.Count(x => x.kategoria.Equals("Noi"));
      Console.WriteLine($"4.feladat: A női versenyzők aránya: {(double)noi/jatekosok.Count*100:N2}%");
    }

    private static void HarmadikFeladat()
    {
      Console.WriteLine($"3.feladat: Összesen {jatekosok.Count} db versenyző indult!");
    }

    private static void Beolvasas()
    {
      using (StreamReader be = new StreamReader("fob2016.txt"))
      {
        while (!be.EndOfStream)
        {
          jatekosok.Add(new Jatekos(be.ReadLine()));
        }
      }
    }
  }
}
