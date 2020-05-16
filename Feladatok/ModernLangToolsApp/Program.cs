using System;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace ModernLangToolsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Feladat2();
            Feladat3();
            Feladat4();
        
        Console.ReadKey();
            
        } ///MAIN VÉGE


        [Description("Feladat2")]
        public static void Feladat2()
        {
            //egy Jedi objektum létrehozása, értékadás
            Jedi j = new Jedi();
            j.Nev = "Anakin";
            j.KoloniaSzam = 15;

            //kiírás txt-be
            XmlSerializer serializer = new XmlSerializer(typeof(Jedi));
            FileStream stream = new FileStream("jedi.txt", FileMode.Create);
            serializer.Serialize(stream, j);
            stream.Close();

            //visszaolvasás az előbb létrehozott txt-ből. Klónozza az eddig meglévő j nevű Jedi objektumot.
            XmlSerializer ser = new XmlSerializer(typeof(Jedi));
            FileStream fs = new FileStream("jedi.txt", FileMode.Open);
            Jedi clone = (Jedi)ser.Deserialize(fs);
            fs.Close();
        }

        [Description("Feladat3")]
        public static void Feladat3()
        {
            // Tanács létrehozása
            JediCouncil council = new JediCouncil();
            council.Valtozas += MessageReceived;

            //Jedi tanács feltöltése 2 jedivel
            Jedi jedi1 = new Jedi();
            jedi1.Nev = "Jedi 1";
            jedi1.KoloniaSzam = 5000;
            council.Add(jedi1);
            Jedi jedi2 = new Jedi();
            jedi2.Nev = "Jedi 2";
            jedi2.KoloniaSzam = 10000;
            council.Add(jedi2);

            //Tagok törlése
            council.Remove();
            council.Remove();
        }

        [Description("Feladat4")]
        public static void Feladat4()
        {
            // Tanács létrehozása
            JediCouncil council = new JediCouncil();
            council.Valtozas += MessageReceived;

            //Kezdő jedik létrehozása és a tanácshoz adása
            Jedi elso = new Jedi();
            elso.Nev = "Kezdő Jedi 1";
            elso.KoloniaSzam = 100;
            council.Add(elso);
            Jedi ketto = new Jedi();
            ketto.Nev = "Kezdő Jedi 2";
            ketto.KoloniaSzam = 200;
            council.Add(ketto);

            //Kezdő jedik kikeresése és tulajdonságaik kiírása
            foreach (Jedi i in council.Kezdok())
            {
                Console.WriteLine("{0}", i.Nev);
            }
        }

        static void MessageReceived(string message)
        {
            Console.WriteLine(message);
        }
    }

}
