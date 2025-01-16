namespace service_auto_v2;
using System;
using System.Collections.Generic;
using System.IO;
public class Meniu_Admin
{
    public int optiune_admin = 0;
    public static Utilizatori temp_util = new Utilizatori(Utilizatori.tip_de_utilizator.mecanic, "mata", "mata", "mata", "mata");
    
    public static Cerere cerere =new Cerere("mata","mata","mata","mata",Cerere.tip.in_preluare);
    public Piese piesa=new Piese("a",temp_util,Piese.tip.in_asteptare,"mata",12,cerere) ;
    
    
    public List<Cerere> lista_cerere=new List<Cerere>() ;
    public GestionarePiese gestionarepiese = new GestionarePiese();
    public GestionareCereri gestionarecereri = new GestionareCereri();

    
    

    public List<Piese> lista_piesa=new List<Piese>() ;

    public Meniu_Admin(List<Cerere> cereri, List<Piese> piese)
    {
        this.lista_cerere = cereri;
        this.lista_piesa = Piese.citire_piese_din_fisier();
    }
  

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
                    Logare.opt = 4;
                    break;
                case 1:
                    cerere.afisare_cerere(lista_cerere);
                    break;
                case 2:
                    gestionarepiese.AfisarePieseDinFisier();
                    break;
                case 3:
                    lista_piesa = Piese.citire_piese_din_fisier();
                    piesa.preluare_cerere_piese(lista_piesa);
            break;
                
                case 4: 
                    cerere.creare_cerere(lista_cerere); break;
            }

        } while (optiune_admin != 0);


    }
}