namespace service_auto_v2;

public class Cerere
{
    public string cod_identificare { get; set; }
        public string client_nume { get; set; }
        public string client_nr_masina { get; set; }
        public string descriere { get; set; }
        public tip status { get; set; }

        public int contor_cerere = 0;
     

        public enum tip
        {
      
            in_preluare,
            investigare,
            astepare_piese,
            finalizat
        };
        
            
        
    
        public Cerere(string Cod_identificare, string Client_nume, string Client_nr_masin, string Descriere, tip Status)
        
        {
            cod_identificare = Cod_identificare;
                     client_nume = Client_nume;
                     client_nr_masina = Client_nr_masin;
                     descriere = Descriere;
                     status = Status;
                     
        }


        public void creare_cerere(List<Cerere> cerere)
        {
            contor_cerere = contor_cerere + 1;
            Console.Write("cod identificare=");
            cod_identificare = Console.ReadLine();
            
            Console.Write("client nume=");
            client_nume = Console.ReadLine();
            
            Console.Write("client nr_masina=");
            client_nr_masina = Console.ReadLine();
            
            Console.Write("descriere=");
            descriere = Console.ReadLine();
            
            
            status = tip.in_preluare;
            Console.WriteLine("cerere creata cu success");
            Console.WriteLine("");
            
            Cerere cerere1=new Cerere(cod_identificare, client_nume, client_nr_masina, descriere, status);
            cerere.Add(cerere1);


        }


        public void afisare_cerere(List<Cerere> cerere)
        {
            if (contor_cerere == 0)
            {
                Console.WriteLine("lista este goala");
                return ;
            }
            foreach (var VARIABLE in cerere)
            {
                Console.WriteLine($"{VARIABLE.cod_identificare} {VARIABLE.client_nume} {VARIABLE.client_nr_masina} {VARIABLE.descriere} {VARIABLE.status} ");
            }

                Console.WriteLine("");
            
        }

        public void preluare_cerere(List<Cerere> cerere)
        {
            if (contor_cerere == 0)
            {
                Console.WriteLine("lista este goala");
                return;
            }
            foreach (var VARIABLE in cerere)
            {
                if (VARIABLE.status == tip.in_preluare)
                {
                    VARIABLE.status=tip.investigare;
                      Console.WriteLine($"{VARIABLE.cod_identificare} {VARIABLE.client_nume} {VARIABLE.client_nr_masina} {VARIABLE.descriere} {VARIABLE.status} ");
                    Console.WriteLine("");
                      break;
                }
                  
            }
        }

        public void investigare_cerere(List<Cerere> cerere)
        {
            if (contor_cerere == 0)
            {
                Console.WriteLine("lista este goala");
                return;
            }
            foreach (var VARIABLE in cerere)
            {
                if (VARIABLE.status == tip.investigare)
                {
                    Console.Write("trebuie piese pentru a finaliza?   (scrieti da sau nu)=");
                    Console.WriteLine("");
                    string temp = Console.ReadLine();
                    if (temp == "nu")
                    {
                        Console.WriteLine("rezolva problema");
                        Console.WriteLine("");
                        Logare.temp_cerere = VARIABLE;
                    }
                    else if (temp == "da")
                    {
                        Console.WriteLine("fa comanda");
                        Console.WriteLine("");
                        VARIABLE.status = tip.astepare_piese;
                         Logare.temp_cerere = VARIABLE;

                    }
                    
                }
            }
        }

        public void rezolva_cerere(List<Cerere>cer1)
        {
        
            foreach (var VARIABLE in cer1)
            {
                    
                if (VARIABLE.status == tip.investigare)
                {
                    VARIABLE.status = tip.finalizat;
                    Console.WriteLine($"{VARIABLE.cod_identificare} {VARIABLE.client_nume} {VARIABLE.client_nr_masina} {VARIABLE.descriere} {VARIABLE.status} ");
                    Console.WriteLine("comanda finalizata");
                    Console.WriteLine("");
                }

            }
        }


}