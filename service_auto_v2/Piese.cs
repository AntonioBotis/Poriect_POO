namespace service_auto_v2;

public class Piese
{
    public string awb { get; set; }
    public Utilizatori utli { get; set; }
    public tip status { get; set; }

    public enum tip
    {
        in_asteptare,
        finalizat
    };

    public List<string> nume_piese { get; set; }
    public List<int> pret {get; set;}
    
    public string nume_piesa { get; set; }
    public int pret_piesa   { get; set; }
    
    public List<Piese> lista_piese { get; set; }

    public int contor_piese = 0;
  
  

    public Piese(string Awb, Utilizatori Utli, tip Status,string nume, int pret, Cerere cer1)
    {
        
        awb = Awb;
        utli = Utli;
        status = Status;
        Logare.temp_cerere = cer1;

    }

    
        

    public void creare_cerere_piese(List<Piese> p1,Cerere cer1)
    {
        contor_piese = contor_piese + 1;
        Console.WriteLine($"{cer1.cod_identificare} {cer1.client_nume} {cer1.client_nr_masina} {cer1.descriere} {cer1.status} ");
        Console.WriteLine("nume piesa=");
        string pes1= Console.ReadLine();
       
       
        Console.WriteLine("pret=");
        int pre1= Convert.ToInt32(Console.ReadLine());
  
       
       Console.WriteLine("AWB=");
       awb = Console.ReadLine();
       
        status = tip.in_asteptare;
        Piese piesa1 = new Piese(awb,Logare.temp_utilizator,status,pes1 ,pre1, cer1);
        p1.Add(piesa1);
        
        Console.WriteLine();
    }

    public void vizualizare_cerere_piese(List<Piese> lista_piese)
    {

        if (contor_piese == 0)
        {
            Console.WriteLine("Lista de piese este goală.");
            return;
        }

        foreach (var VARIABLE in lista_piese)
        {
            Console.WriteLine($"{VARIABLE.nume_piesa} {VARIABLE.pret_piesa} {VARIABLE.status} ");
        }
    }

    public void preluare_cerere_piese(List<Piese> lista_piese)
    {
        
    
        {
             foreach (var VARIABLE in lista_piese)
                    {
                        
                        Console.WriteLine($"{VARIABLE.nume_piesa} {VARIABLE.pret_piesa} {VARIABLE.status}  ");
                        if (VARIABLE.status == Piese.tip.in_asteptare)
                        {
                            bool error=false;
                            do
                            { Console.WriteLine("cumparam piesa (da sau nu)?");
                                                         string cumparam = Console.ReadLine();
                                                         if(cumparam == "da")
                                                         {VARIABLE.status = Piese.tip.finalizat;error = true;}
                                                         else if(cumparam == "nu")
                                                         {
                                                             VARIABLE.status = Piese.tip.in_asteptare;
                                                             error = true;
                                                         }
                                                         else
                                                         {
                                                             Console.WriteLine("ai introdus gresit");
                                                             
                                                         }
                                
                            }while(error==false);
                           
                            
                        }
                    }
        }
       
        Console.WriteLine("");
    }
}