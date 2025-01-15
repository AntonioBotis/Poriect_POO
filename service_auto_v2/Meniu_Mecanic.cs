namespace service_auto_v2;
using System;
using System.Collections.Generic;
using System.IO;
public class Meniu_Mecanic
{
    public int optiune_mecanic = 0;
    Cerere cerere;
    Piese piesa;
    public void meniu_mecanic()
    {
        do
      {
         Console.WriteLine("0.Iesire");
         Console.WriteLine("1.Preluare cerere de rezolvare client");
         Console.WriteLine("2.Investigare problema cerere");
         Console.WriteLine("3.Creare cerere de piese auto");
         Console.WriteLine("4.Rezolvare problema ");
         Console.WriteLine("");
         Console.Write("optiune mecanic=");
         optiune_mecanic = Convert.ToInt32(Console.ReadLine());
         
         List<Cerere> cereri = Cerere.citire_cereri_din_fisier();
            Cerere cerere_preluata_curent=cerere.preluare_cerere(cereri);
        
         switch (optiune_mecanic)
         {
             case 0:
                 Console.WriteLine("Se iese din mecanic");
                 Logare.opt = 0;
                 break;
             case 1: cerere.preluare_cerere(cereri);
                 break;
             case 2:cerere.investigare_cerere(cereri);
                 break;
             case 3:piesa.creare_cerere_piese(cerere_preluata_curent);
                 break;
             case 4:cerere.rezolva_cerere(cereri);
     
     
                 break;
     
         }
     
      } while (optiune_mecanic!=0);}

}