using System.Runtime.ConstrainedExecution;

namespace service_auto_v2;
using System;
using System.Collections.Generic;
using System.IO;

public class Logare
{
    public static int opt { get; set; }
    public string data_nume { get; set; }
    public string data_parola { get; set; }
    public string data_cod { get; set; }
    public string data_email { get; set; }
    public Utilizatori.tip_de_utilizator data_utilizator { get; set; }
    public int counter_admin { get; set; }
    public int counter_mecanic { get; set; }
    public string temp_nume { get; set; }
    public List<Utilizatori> lista_de_utilizatori { get; set; } = new List<Utilizatori>();
    public static Utilizatori temp_utilizator { get; set; }
    public static List<Cerere> lista_cerere = new List<Cerere>();
    public static List<Piese> lista_piesa = new List<Piese>();
    public static Cerere temp_cerere = null;

    public Cerere cerere;
    public Piese piesa;
    public Meniu_Admin ma;
    public Meniu_Mecanic mm;

    // Constructor care inițializează instanțele de Meniu_Admin și Meniu_Mecanic
    public Logare()
    {
        ma = new Meniu_Admin(lista_cerere, lista_piesa);
        mm = new Meniu_Mecanic(lista_cerere, lista_piesa);
    }
    
    GestionarePiese gestionarepiese = new GestionarePiese();
    GestionareCereri gestionarecereri = new GestionareCereri();

    public void interfata()
    {
        do
        {
            Console.WriteLine("0. Iesire");
            Console.WriteLine("1. Logare");
            Console.WriteLine("2. Adaugare utilizator");
            Console.WriteLine($"Număr admin = {counter_admin}, mecanic = {counter_mecanic}");
            if (counter_admin < 1 || counter_mecanic < 2)
                Console.WriteLine("Minim 1 admin si 2 mecanici sunt necesari.");
            Console.WriteLine("");
            Console.Write("Optiune: ");
            opt = Convert.ToInt32(Console.ReadLine());
            

            switch (opt)
            {
                case 0:
                    Console.WriteLine("Se iese din program");
                    gestionarecereri.CurataFisierCereri();
                    gestionarepiese.CurataFisierPiese();
                    Environment.Exit(0);
                    break;

                case 1:
                    
                    if (counter_admin == 0 || counter_mecanic < 2)
                    {
                        Console.WriteLine("Prea putini utilizatori.");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.Write("Nume utilizator: ");
                        data_nume = Console.ReadLine();
                        Console.Write("Parola: ");
                        data_parola = Console.ReadLine();

                        if (validare_logare(lista_de_utilizatori, data_nume, data_parola) == 1)
                        {
                            ma.meniu_admin();
                        }
                        else if (validare_logare(lista_de_utilizatori, data_nume, data_parola) == 2)
                        {
                            Console.WriteLine("Mecanic acces primit");
                            mm.meniu_mecanic();
                        }
                        else
                        {
                            Console.WriteLine("Utilizator invalid.");
                            Console.WriteLine("");
                            Console.WriteLine("");
                        }
                    }
                    break;

                case 2:
                    Console.Write("Tip utilizator (admin sau mecanic): ");
                    temp_nume = Console.ReadLine();

                    if (temp_nume == "admin")
                    {
                        data_utilizator = Utilizatori.tip_de_utilizator.admin;
                        counter_admin++;
                    }
                    else if (temp_nume == "mecanic")
                    {
                        data_utilizator = Utilizatori.tip_de_utilizator.mecanic;
                        counter_mecanic++;
                    }
                    else
                    {
                        Console.WriteLine("Tip de utilizator invalid.");
                        break;
                    }

                    Console.Write("Cod unic: ");
                    data_cod = Console.ReadLine();
                    Console.Write("Nume utilizator: ");
                    data_nume = Console.ReadLine();
                    Console.Write("Email: ");
                    data_email = Console.ReadLine();
                    Console.Write("Parolă: ");
                    data_parola = Console.ReadLine();

                    Utilizatori utli1 = new Utilizatori(data_utilizator, data_cod, data_nume, data_email, data_parola);
                    adaugare_utilizator(lista_de_utilizatori, utli1);

                    Console.WriteLine("Utilizator adăugat.");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    break;
            }

        } while (opt != 0);
    }

    public int validare_logare(List<Utilizatori> utilizatori_list, string name, string pass)
    {
        foreach (var VARIABLE in utilizatori_list)
        {
            if (VARIABLE.nume == name && VARIABLE.parola == pass)
            {
                if (VARIABLE.utilizator == Utilizatori.tip_de_utilizator.admin)
                {
                    temp_utilizator = VARIABLE;
                    return 1;
                }
                else if (VARIABLE.utilizator == Utilizatori.tip_de_utilizator.mecanic)
                {
                    temp_utilizator = VARIABLE;
                    return 2;
                }
            }
        }
        return 0;
    }

    public void adaugare_utilizator(List<Utilizatori> utilizatori_list, Utilizatori util)
    {
        utilizatori_list.Add(util);
    }
}
