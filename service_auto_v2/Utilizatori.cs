namespace service_auto_v2;
using System;
using System.Collections.Generic;
using System.IO;

public class Utilizatori
{
    public string cod_unic { get; set; }
    public string nume { get; set; }
    public string email { get; set; }
    public string parola { get; set; }
    public tip_de_utilizator utilizator { get; set; }
    public enum tip_de_utilizator
    {
        admin,
        mecanic
    };

    public Utilizatori( tip_de_utilizator Utilizator,string CodUnic, string Nume, string Email, string Parola)
    {
        cod_unic = CodUnic;
        nume = Nume;
        email = Email;
        parola = Parola;
        utilizator = Utilizator;
    }

    
}