namespace service_auto_v2;

public class Logare
{
    public int opt { get; set; }
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
    
    public int optiune_admin = 0;
    public int optiune_mecanic = 0;
    
    public static Cerere cerere =new Cerere("1","1","1","1",Cerere.tip.in_preluare);
    public Piese piesa =new Piese("1",temp_utilizator,Piese.tip.in_asteptare,"1",1,cerere);
    

    public void interfata()
    {
        do
        {
            Console.WriteLine("0.Iesire");
            Console.WriteLine("1.Logare");
            Console.WriteLine("2.Adaugare utilizator");
            Console.WriteLine($"numar admin={counter_admin} mecanic={counter_mecanic}");
            if(counter_admin<1 || counter_mecanic<2)
                Console.WriteLine("minim 1 admin si 2 mecanici");
            Console.WriteLine("");
            Console.Write("optiune=");
            opt= Convert.ToInt32(Console.ReadLine());

          

            switch (opt)
            {
                case 0:
                    Console.WriteLine("Se iese din program");
                    Environment.Exit(0);
                    break;

                case 1:
                    if (counter_admin == 0 || counter_mecanic <= 1)
                    {
                        Console.WriteLine("prea putini utilizatori");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.Write("Nume utilizator=");
                        data_nume = Console.ReadLine();
                        Console.Write("parola=");
                        data_parola = Console.ReadLine();

                        if (validare_logare(lista_de_utilizatori, data_nume, data_parola) == 1)
                        {
                          
                        }
                        else if (validare_logare(lista_de_utilizatori, data_nume, data_parola) == 2)
                        {
                            Console.WriteLine("Mecanic acces primit");
                            
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
           
                                
                                

                                switch (optiune_mecanic)
                                {
                                    case 0:
                                        Console.WriteLine("Se iese din mecanic");
                                        Program.loga.interfata();
                                        break;
                                    case 1: cerere.preluare_cerere(lista_cerere);
                                        break;
                                    case 2:cerere.investigare_cerere(lista_cerere);
                                        break;
                                    case 3:piesa.creare_cerere_piese(lista_piesa,temp_cerere);
                                        break;
                                    case 4:cerere.rezolva_cerere(lista_cerere);
                 
                    
                                        break;
                
                                }
            
                            } while (optiune_mecanic!=0);
                         
                        }
                        else
                        {
                            Console.WriteLine(" utilizator invalid");
                            Console.WriteLine("");
                            Console.WriteLine("");
                        }
                    }
                    break;

                case 2:
                    Console.Write("tip utilizator? admin sau mecanic=");
                    temp_nume = Console.ReadLine();

                    if (temp_nume == "admin")
                    {
                        data_utilizator = Utilizatori.tip_de_utilizator.admin;
                        counter_admin = counter_admin + 1;
                    }
                    else if (temp_nume == "mecanic")
                    {
                        data_utilizator = Utilizatori.tip_de_utilizator.mecanic;
                        counter_mecanic = counter_mecanic + 1;
                    }
                    else
                    {
                        Console.WriteLine("tip de utilizator invalid");
                        break;
                    }

                    Console.Write("cod unic=");
                    data_cod = Console.ReadLine();
                    Console.Write("Nume utilizator=");
                    data_nume = Console.ReadLine();
                    Console.Write("email=");
                    data_email = Console.ReadLine();
                    Console.Write("parola=");
                    data_parola = Console.ReadLine();

                    Utilizatori utli1 = new Utilizatori(data_utilizator, data_cod, data_nume, data_email, data_parola);
                    adaugare_utilizator(lista_de_utilizatori, utli1);

                    Console.WriteLine("utilizator adaugat");
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
        return 0;
    }

    public void adaugare_utilizator(List<Utilizatori> utilizatori_list, Utilizatori util)
    {
        utilizatori_list.Add(util);
    }
}