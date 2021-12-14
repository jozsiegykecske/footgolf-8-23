using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace footgolf_8_23
{
  internal class Jatekos
  {
    public string nev { get; set; }
    public string kategoria { get; set; }
    public string egyesulet { get; set; }
    public List<int> szerzettPontok = new List<int>();
    public int osszpontszam;

    public Jatekos(string be)
    {
      string[] a = be.Split(';');
      nev = a[0];
      kategoria = a[1];
      egyesulet = a[2];
      for (int i = 3; i < a.Length; i++)
      {
        szerzettPontok.Add(Convert.ToInt32(a[i]));
      }
      OsszPontSzamSzamitas(szerzettPontok);
    }

    private void OsszPontSzamSzamitas(List<int> a)
    {
      int osszpont = 0;
      a.Sort();
        if (a[0] != 0)
        {
          osszpont += 10;
        }
        if (a[1] != 0)
        {
          osszpont += 10;
        }
        for (int i = 2; i < a.Count; i++)
        {
          osszpont += a[i];
        }
      osszpontszam = osszpont;
    }
  }
}
