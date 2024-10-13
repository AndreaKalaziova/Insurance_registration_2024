using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Basic_Lite
{
    internal class PojistenaOsoba
    {
        /// <summary>
        /// osoba ma jmeno, prijmeni, vek, telefonni cislo
        /// </summary>
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public int Vek { get; set; }
        public string TelefonniCislo { get; set; }
        /// <summary>
        /// poradove cislo, index pro lehci vybirani ze seznamu
        /// </summary>
        public int PoradoveCislo { get; set; }


        /// <summary>
        /// inic.
        /// </summary>
        /// <param name="jmeno"></param>
        /// <param name="prijmeni"></param>
        /// <param name="vek"></param>
        /// <param name="telefonniCislo"></param>
        public PojistenaOsoba(int poradoveCislo, string jmeno, string prijmeni, int vek, string telefonniCislo)
        {
            PoradoveCislo = poradoveCislo;
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Vek = vek;
            TelefonniCislo = telefonniCislo;
        }
        /// <summary>
        /// prepis cele osoby na string
        /// </summary>
        /// <returns>Cela osoba v Stringu</returns>
        public override string ToString()
        {
            return $"{PoradoveCislo}.\t{Jmeno}\t{Prijmeni}\t{TelefonniCislo}\t{Vek}";
            //String.Format
        }

    }
}
