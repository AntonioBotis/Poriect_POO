namespace service_auto_v2;
using System;
using System.Collections.Generic;
using System.IO;

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
    public Cerere cere;
  
  

    public Piese(string Awb, Utilizatori Utli, tip Status,string nume, int pret, Cerere cer1)
    {
        
        awb = Awb;
        utli = Utli;
        status = Status;
        pret_piesa = pret;
        nume_piesa = nume;
        cere = cer1;

    }

    
        

    public void creare_cerere_piese(List<Piese> piese,Cerere cer1)
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
       
        
        salvare_piesa_in_fisier(piesa1);
        piese.Add(piesa1);
        Console.WriteLine("");
        Console.WriteLine($"{piesa1.nume_piese} {piesa1.status} {piesa1.pret_piesa}");
    }
    
    private void salvare_piesa_in_fisier(Piese piesa)
    {
        string path = "lista_piese.txt";
        string linie = $"{piesa.awb},{piesa.nume_piesa},{piesa.pret_piesa},{piesa.status}";
        File.AppendAllText(path, linie + Environment.NewLine);
    }
    public static List<Piese> citire_piese_din_fisier()
    {
        string path = "lista_piese.txt";
        List<Piese> piese = new List<Piese>();

        if (File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length == 4)
                {
                    try
                    {
                        Piese p = new Piese(
                            parts[0], // awb
                            null,     // utilizatori (nu e salvat în fișier)
                            Enum.Parse<tip>(parts[3]), // status
                            parts[1], // nume_piesa
                            int.Parse(parts[2]) ,// pret_piesa
                            null
                        );

                        piese.Add(p);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Eroare la citirea piesei: {ex.Message}");
                    }
                }
            }
        }

        return piese;
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

    public void preluare_cerere_piese (List<Piese> lista_piese)
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
                                                         {VARIABLE.status = Piese.tip.finalizat;
                                                             Logare.temp_awb= VARIABLE.awb;
                                                             Console.WriteLine(Logare.temp_awb);
                                                             Logare.temp_cerere.status = Cerere.tip.finalizat;
                                                                 error = true;}
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
    
    public static void scriere_piese_in_fisier(List<Piese> piese)
    {
        string path = "lista_piese.txt";

        try
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                foreach (var piesa in piese)
                {
                    writer.WriteLine($"{piesa.awb},{piesa.nume_piesa},{piesa.pret_piesa},{piesa.status}");
                }
            }

            Console.WriteLine("Piesele au fost salvate cu succes în fișier.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Eroare la scrierea pieselor: {ex.Message}");
        }
    }
}