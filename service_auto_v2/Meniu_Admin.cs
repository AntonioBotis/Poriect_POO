namespace service_auto_v2;
using System;
using System.Collections.Generic;
using System.IO;
public class Meniu_Admin
{
    public int optiune_admin = 0;

    public  Piese piesa = null;
    public Cerere cerere = null;

    


    //asta a dat intelysensu
    public bool inputValid = false;
    public void meniu_admin()
    {

        Console.WriteLine("Admin acces primit");
        do
        {
            Console.WriteLine("0.Iesire");
            Console.WriteLine("1.Vizualizarea cereri de rezolvarea a problemelor ");
            Console.WriteLine("2.Vizualizarea comenzi piese");
            Console.WriteLine("3.Preluare si finalizare comanda piese auto");
            Console.WriteLine("4.Creare cerere rezolvare");
            Console.WriteLine("");
            Console.Write("optiune admin=");
            optiune_admin = Convert.ToInt32(Console.ReadLine());



            switch (optiune_admin)
            {
                case 0:
                    Console.WriteLine("Se iese din admin");

                    break;
                case 1: cerere.afisare_cerere(Logare.lista_cerere); break;
                case 2: piesa.vizualizare_cerere_piese(Logare.lista_piesa); break;
                case 3:  piesa.preluare_cerere_piese(Logare.lista_piesa);break;
                case 4: cerere.creare_cerere(Logare.lista_cerere); break;
            }

        } while (optiune_admin != 0);


    }
}