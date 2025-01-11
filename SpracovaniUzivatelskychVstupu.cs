using System.Text.RegularExpressions;

namespace Project_Basic_Lite_1._2
{
    internal class SpracovaniUzivatelskychVstupu   
    {
        //ziskava vstupy od uzivatele, validuje a osetruje je
        public SpracovaniUzivatelskychVstupu()
        { }

        /// <summary>
        /// pomocna metoda pro pokracovani na dalsi akci
        /// </summary>
        public void Pokracuj()
        {
            Console.WriteLine("\nPro pokračování stiskněte ENTER");
            Console.ReadLine();
        }

        /// <summary>
        /// pomocna metoda pri ziskani a validaci jmena
        /// </summary>
        /// <returns> Jmeno </returns>
        public string ZiskejJmeno()
        {
            //zadani hledaneho jmena
            Console.Write("Jméno: \t\t\t");
            string jmeno;
            while (string.IsNullOrWhiteSpace(jmeno = Console.ReadLine().ToUpper())) //pokud neni zadane jmeno + prevod na velke pismena
            {
                Console.Write("Zadej jméno znovu: \t");
            }
            return jmeno;
        }
        /// <summary>
        /// pomocna metoda pro ziskani a validaci prijmeni
        /// </summary>
        /// <returns> Prijmeni </returns>
        public string ZiskejPrijmeni()
        {
            //zadani hledaneho prijmeni
            Console.Write("Příjmení: \t\t");
            string prijmeni;
            while (string.IsNullOrWhiteSpace(prijmeni = Console.ReadLine().ToUpper())) //pokud neni zadane prijemni + prevod na velke pismena
            {
                Console.Write("Zadej příjmení znovu: \t");
            }
            return prijmeni;
        }

        /// <summary>
        /// pomocna metoda pro ziskani a validaci tel.c.
        /// </summary>
        public string ZiskejTelefonniCislo()
        {
            Console.Write("Telefonní číslo: \t");   
            string telefonniCislo = Console.ReadLine();

            string vzorCisla = @"^\+?[0-9\s]{9,15}$"; //regex muze byt/nemusi '+', povoluje mezeru, delka 9-15
            Regex regex = new Regex(vzorCisla);

            while (!regex.IsMatch(telefonniCislo))
            {
                Console.Write("Zadej telefonní číslo znovu (9-15 číslic, '+' a jedna mezera povolena) : \t");  //zadani a nacteni opraveneho tel.cisla
                telefonniCislo = Console.ReadLine();
            }
            return telefonniCislo;
        }

        /// <summary>
        /// pomocna metoda pro ziskani a validaci veku  
        /// </summary>
        /// <returns>Vek</returns>
        public int ZiskejVek()
        {
            Console.Write("Věk: \t\t\t"); //vyzada a ulozi vek 
            int vek = 0;
            string zadanyVek;
            while (true)    // nekonecny cyklus, ktery se ukonci pouze pri validnim vstupu
            {
                zadanyVek = Console.ReadLine();
				if (int.TryParse(zadanyVek, out vek) && vek > 0 && vek <= 150)
				    break; // Pokud je vše v pořádku, ukončíme smyčku
				
				Console.Write("Nezadal jsi cislo! Zadej věk znovu (kladné číslo do 150):: \t");
            }
            return vek;
        }
    }
}
