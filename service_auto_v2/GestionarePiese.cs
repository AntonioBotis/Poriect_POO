namespace service_auto_v2;

public class GestionarePiese
{
    public void AfisarePieseDinFisier()
    {
        List<Piese> piese = Piese.citire_piese_din_fisier();

        if (piese.Count == 0)
        {
            Console.WriteLine("Nu există cereri de piese salvate.");
        }
        else
        {
            Console.WriteLine("Cereri de piese salvate:");
            foreach (var piesa in piese)
            {
                Console.WriteLine($"{piesa.awb} {piesa.nume_piesa} {piesa.pret_piesa} {piesa.status}");
            }
        }
    }

    public void CurataFisierPiese()
    {
        string path = "lista_piese.txt";
        if (File.Exists(path))
        {
            File.WriteAllText(path, "");
            Console.WriteLine("Fisierul lista_piese.txt a fost golit.");
        }
        else
        {
            Console.WriteLine("Fisierul lista_piese.txt nu există.");
        }
    }
    
    public static void StergerePiesaDinFisier(string awbPiesa)
    {
        string path = "lista_piese.txt";
        List<string> piese = new List<string>();

        // Citește toate liniile din fișier
        if (File.Exists(path))
        {
            piese.AddRange(File.ReadAllLines(path));
        }

        // Verifică dacă piesa există înainte de ștergere
        bool piesaExista = piese.Any(linie => linie.StartsWith(awbPiesa + ","));

        if (!piesaExista)
        {
            Console.WriteLine($"Piesa cu AWB-ul {awbPiesa} nu a fost găsită în fisier.");
            return;
        }

        // Elimină piesa cu AWB-ul specificat
        piese = piese.Where(linie => !linie.StartsWith(awbPiesa + ",")).ToList();

        // Rescrie fișierul cu piesele rămase
        try
        {
            File.WriteAllLines(path, piese);
            Console.WriteLine($"Piesa cu AWB-ul {awbPiesa} a fost stearsă.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Eroare la ștergerea piesei: {ex.Message}");
        }
    }

}