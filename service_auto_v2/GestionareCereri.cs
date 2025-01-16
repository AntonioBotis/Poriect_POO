namespace service_auto_v2;

public class GestionareCereri
{
    public void AfisareCereriDinFisier()
    {
        List<Cerere> cereri = Cerere.citire_cereri_din_fisier();

        if (cereri.Count == 0)
        {
            Console.WriteLine("Nu există cereri salvate.");
        }
        else
        {
            Console.WriteLine("Cereri salvate:");
            foreach (var cerere in cereri)
            {
                Console.WriteLine($"{cerere.cod_identificare} {cerere.client_nume} {cerere.client_nr_masina} {cerere.descriere} {cerere.status}");
            }
        }
        
        
    }
    
    public void CurataFisierCereri()
    {
        string path = "lista_cereri.txt";
        if (File.Exists(path))
        {
            File.WriteAllText(path, "");
            Console.WriteLine("Fisierul lista_cereri.txt a fost golit.");
        }
        else
        {
            Console.WriteLine("Fișierul piese.txt nu există.");
        }
    }
}