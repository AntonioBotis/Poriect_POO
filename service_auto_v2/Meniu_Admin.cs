namespace service_auto_v2;
using System;
using System.Collections.Generic;
using System.IO;
public class Meniu_Admin
{
    public int optiune_admin = 0;

    public  Piese piesa = null;
    public Cerere cerere = null;
    public List<Cerere> lista_cerere ;
    public GestionareCereri gestionarecereri = null;
    public GestionarePiese gestionarepiese = null;
    
    

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

            List<Piese> piese = Piese.citire_piese_din_fisier();

            switch (optiune_admin)
            {
                case 0:
                    Console.WriteLine("Se iese din admin");
                    Logare.opt = 0;
                    break;
                case 1: gestionarecereri.AfisareCereriDinFisier(); break;
                case 2: gestionarepiese.AfisarePieseDinFisier(); break;
                case 3: piesa.preluare_cerere_piese(piese);break;
                case 4: cerere.creare_cerere(); break;
            }

        } while (optiune_admin != 0);


    }
}