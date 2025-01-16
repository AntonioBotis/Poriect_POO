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
}