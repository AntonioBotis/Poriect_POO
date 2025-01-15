using service_auto_v2;

public class Meniu_Mecanic
{
    public int optiune_mecanic = 0;

    public static Utilizatori temp_util = new Utilizatori(Utilizatori.tip_de_utilizator.mecanic, "mata", "mata", "mata", "mata");
    public List<Cerere> lista_cerere;
    public List<Piese> lista_piesa;

    public static Cerere cerere = new Cerere("mata", "mata", "mata", "mata", Cerere.tip.in_preluare);
    public Piese piesa = new Piese("a", temp_util, Piese.tip.in_asteptare, "mata", 12, cerere);

    // Constructor care primește cererile și piesele
    public Meniu_Mecanic(List<Cerere> cereri, List<Piese> piese)
    {
        this.lista_cerere = cereri;
        this.lista_piesa = piese;
    }

    GestionarePiese gestionarepiese = new GestionarePiese();
    GestionareCereri gestionarecereri = new GestionareCereri();

    // Citirea cererilor din fișier, dar lista se poate actualiza în continuare pe măsură ce apar noi cereri
    static List<Cerere> cereri1 = Cerere.citire_cereri_din_fisier();

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

            switch (optiune_mecanic)
            {
                case 0:
                    Console.WriteLine("Se iese din mecanic");
                    Logare.opt = 4;
                    break;
                case 1:
                    // Verifică dacă lista nu este goală înainte de a prelua cererea
                    if (lista_cerere.Count > 0)
                    {
                        cerere.preluare_cerere(lista_cerere);
                    }
                    else
                    {
                        Console.WriteLine("Nu sunt cereri disponibile.");
                    }
                    break;
                case 2:
                    // Verifică dacă lista nu este goală înainte de a investiga cererea
                    if (lista_cerere.Count > 0)
                    {
                        cerere.investigare_cerere(lista_cerere);
                    }
                    else
                    {
                        Console.WriteLine("Nu sunt cereri disponibile.");
                    }
                    break;
                case 3:
                    piesa.creare_cerere_piese(cerere);
                    break;
                case 4:
                    cerere.rezolva_cerere(lista_cerere);
                    break;
            }

        } while (optiune_mecanic != 0);
    }
}
