using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ModernLangToolsApp
{   //Xml serializálás, mint a laboron 
    [XmlRoot("Jedi")]
    public class Jedi
    {
        //A MidiChlorianCount tagváltozóhoz tartozó setter és getter. Ha a szint 10 vagy alacsonyabb akkor hibát dob.
        [XmlAttribute("KoloniaSzam")]
        public int KoloniaSzam
        {
            set
            {
                if (value > 10)
                {
                    koloniaSzam = value;
                }
                else
                {
                    throw new ArgumentException("You are not a true jedi!");
                }
            }
            get { return koloniaSzam; }
        }

        [XmlAttribute("Nev")]
        public String Nev { get; set; }

        private int koloniaSzam;

    }
}
