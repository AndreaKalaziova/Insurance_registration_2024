using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Basic_Lite
{
    // db pro osoby a metody co s ni lze delat
    internal class DatabazeOsob
    {
        private List<PojistenaOsoba> pojisteneOsoby;

        public DatabazeOsob()
        {
            pojisteneOsoby = new List<PojistenaOsoba>();
        }

        /// <summary>
        /// pridej osobu do seznamu pojisteneOsoby
        /// </summary>
        /// <param name="poradoveCislo"></param>
        /// <param name="jmeno"></param>
        /// <param name="prijmeni"></param>
        /// <param name="vek"></param>
        /// <param name="telefonniCislo"></param>
        public void PridejOsobu(int poradoveCislo, string jmeno, string prijmeni, int vek, string telefonniCislo)
        {
            pojisteneOsoby.Add(new PojistenaOsoba(poradoveCislo, jmeno, prijmeni, vek, telefonniCislo));
        }
        /// <summary>
        /// seznam vsech osob v db
        /// </summary>
        /// <returns></returns>
        public List<PojistenaOsoba> VypisSeznamOsob()
        {
            List<PojistenaOsoba> seznamOsob = new List<PojistenaOsoba>();

            var dotaz = from s in pojisteneOsoby select s;
            foreach (PojistenaOsoba osoba in dotaz)
            { seznamOsob.Add(osoba); }                             // nalezene se prida do seznamOsob, ktere vyuzijeme v EvidencePojistencu

            return seznamOsob;
        }
        /// <summary>
        /// vyhledej osobu v db podle jmena a prijmeni
        /// </summary>
        /// <param name="jmeno"></param>
        /// <param name="prijmeni"></param>
        /// <returns></returns>
        public List<PojistenaOsoba> VyhledejOsobu(string jmeno, string prijmeni)
        {
            List<PojistenaOsoba> vysledkyHledani = new List<PojistenaOsoba>();

            var dotaz = from o in pojisteneOsoby                                // vyhledavani dle jmeno a prijmeni v db
                        where (o.Jmeno == jmeno) && (o.Prijmeni == prijmeni)
                        select o;
            foreach (PojistenaOsoba osoba in dotaz)
            { vysledkyHledani.Add(osoba); }                             // nalezene se prida do vysledkyHledani, ktere vyuzijem v EvidenciPojistencu

            return vysledkyHledani;
        }

        /// <summary>
        /// vymazat osobu z db dle poradoveho cisla
        /// </summary>
        /// <param name="osoba"></param>
        public void VymazOsobu(PojistenaOsoba osoba)
        {
            pojisteneOsoby.Remove(osoba);
        }

    }
}
