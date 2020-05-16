using System;
using System.Collections.Generic;
using System.Text;

namespace ModernLangToolsApp
{
    public class JediCouncil
    {
        public event ValtozasDelegate Valtozas;

        private List<Jedi> tagok = new List<Jedi>();

        public void Add(Jedi newJedi)
        {
            //A generikus lista Add függvényét használja
            tagok.Add(newJedi);
            if (Valtozas != null)
            {
                Valtozas("Új taggal bővültünk");
            }
        }

        //A delegate-hez tartozó részekehez a laboranyagot és a mintát használtam fel.
        public delegate void ValtozasDelegate(string message);


        //A GetBeginner FindAll-hoz tarozó segédfüggvénye. Kiválasztja azokat a Jediket amiknek 300-nál alacsonyabb a midichlorian szintje.
        static bool Beginner(Jedi j)
            => j.KoloniaSzam < 300;

        public void Remove()
        {
            // Eltávolítja a lista utolsó elemét
            tagok.RemoveAt(tagok.Count - 1);
            if (Valtozas == null)
                return;
            if (tagok.Count < 0)
                Valtozas("A tanács elesett!");
            else
                Valtozas("Zavart érzek az erőben");
        }

        //Egy olyan listával tér vissza, aminek Jedik az elemei és a midichlorian szintjük alacsonyabb mint 300.
        public List<Jedi> Kezdok()
        {
            List<Jedi> list = new List<Jedi>();
            list = tagok.FindAll(Beginner);
            return list;
        }
    }
}
