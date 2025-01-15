namespace service_auto_v2;

public class Meniu_Mecanic
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