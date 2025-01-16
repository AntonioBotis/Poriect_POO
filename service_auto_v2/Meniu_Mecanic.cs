using System.Runtime.ConstrainedExecution;
using service_auto_v2;

public class Meniu_Mecanic
{
    public int optiune_mecanic = 0;

    public static Utilizatori temp_util = new Utilizatori(Utilizatori.tip_de_utilizator.mecanic, "mata", "mata", "mata", "mata");
    public List<Cerere> lista_cerere=new List<Cerere>();
    public  List<Piese> lista_piesa=new List<Piese>();

    public static Cerere cerere = new Cerere("mata", "mata", "mata", "mata", Cerere.tip.in_preluare);
    public Piese piesa = new Piese("a", temp_util, Piese.tip.in_asteptare, "mata", 12, cerere);

    // Constructor care primește cererile și piesele
    public Meniu_Mecanic(List<Cerere> lista_cerere, List<Piese> lista_piesa)
    {
        // Inițializează lista de cereri din fișier
        this.lista_cerere = Cerere.citire_cereri_din_fisier();
        this.lista_piesa = new List<Piese>(); // Inițializare pentru lista pieselor
    }
    
    GestionarePiese gestionarepiese = new GestionarePiese();
    GestionareCereri gestionarecereri = new GestionareCereri();

  
    public void meniu_mecanic()
    {
        do
        {
            Console.WriteLine("0.Iesire");
            Console.WriteLine("1.Preluare cerere de rezolvare client");
            Console.WriteLine("2.Investigare problema cerere");
            Console.WriteLine("3.Creare cerere de piese auto");
            Console.WriteLine("4.Rezolvare problema");
          
            Console.Write("Optiune mecanic: ");
            Console.WriteLine("");
            optiune_mecanic = Convert.ToInt32(Console.ReadLine());
            Console.Write("");
            
            lista_cerere = Cerere.citire_cereri_din_fisier();
            switch (optiune_mecanic)
            {
                case 0:
                    Piese.scriere_piese_in_fisier(lista_piesa);
                    Console.WriteLine("Se iese din mecanic.");
                    break;
                case 1:
                    if (lista_cerere.Count > 0)
                    {
                        cerere = cerere.preluare_cerere(lista_cerere);
                    }
                    else
                    {
                        Console.WriteLine("Nu sunt cereri disponibile.");
                    }
                    break;
                case 2:
                    cerere.investigare_cerere(cerere);
                    break;
                case 3:
                    piesa.creare_cerere_piese(lista_piesa, cerere);
                    break;
                case 4:
                    cerere.rezolva_cerere(cerere);
                    break;
                
                default:
                    Console.WriteLine("Optiune invalida.");
                    break;
            }

        } while (optiune_mecanic != 0);
    }


    
}
