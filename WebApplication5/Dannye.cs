
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApplication5
{
    public class Dannye
    {
        public List<string> DannyeExtrasensa1(List<string> Extranses1,string chislo)
        {
            if (Extranses1 == null)
                Extranses1 = new List<string>();
            Extranses1.Add(chislo);
            return Extranses1;

        }
        public List<string> DannyeExtrasensa2(List<string> Extranses2, string chislo)
        {
            if (Extranses2 == null)
                Extranses2 = new List<string>();
            Extranses2.Add(chislo);
            return Extranses2;
        }

        public List<string> DannyePeople(List<string> People, string chislo)
        {
            if (People == null)
            {
                People = new List<string>();
            }
            People.Add(chislo);
            return People;

        }

    }
}