using Project_Basic_Lite_1._2;

namespace Project_Basic_Lite
{
    internal class EvidencePojistencu
    {
        // komunikace s uzivatelem pres SpracovaniUzivatelskychVstupu a predavani dat do db 
        private DatabazeOsob databazeOsob;
        private SpracovaniUzivatelskychVstupu spracovaniUzivatelskychVstupu;
        private int poradoveCislo = 1;  //pridava se automaticky pro pripad, kdyz jsou zadane osoby se stejnym jmenem+prijmenim, napr pri mazani

        /// <summary>
        /// inicializace
        /// </summary>
        public EvidencePojistencu()
        {
            databazeOsob = new DatabazeOsob();
            spracovaniUzivatelskychVstupu = new SpracovaniUzivatelskychVstupu();
        }

        /// <summary>
        /// pridani osoby do DB
        /// </summary>
        public void PridejOsobu()
        {
            Console.WriteLine("\nZadávaná osoba");
            string jmeno = spracovaniUzivatelskychVstupu.ZiskejJmeno();           //vyzada a ulozi Jmeno
            string prijmeni = spracovaniUzivatelskychVstupu.ZiskejPrijmeni();     //vyzada a ulozi Prijmeni
            string telefonniCislo = spracovaniUzivatelskychVstupu.ZiskejTelefonniCislo(); //vyzada a ulozi tel.c.
            int vek = spracovaniUzivatelskychVstupu.ZiskejVek();                  //vyzada a ulozi Vek

            databazeOsob.PridejOsobu(poradoveCislo, jmeno, prijmeni, vek, telefonniCislo);
            poradoveCislo++;

            Console.WriteLine("\nZadané informace byly uloženy");
            spracovaniUzivatelskychVstupu.Pokracuj();
        }
        /// <summary>
        /// vypis vsech osob v DB
        /// </summary>
        public void VypisSeznamOsob()
        {
            List<PojistenaOsoba> pojisteneOsoby = databazeOsob.VypisSeznamOsob(); //pracuje se seznamem, kam se ukladaji vsechny Osoby
            if (!pojisteneOsoby.Any())                                         
                Console.WriteLine("Žádná pojištěná osoba není uložena.");            // pokud neni ulozena zadna osoba
            else
            {
                Console.WriteLine("Uložené pojištěné osoby:");                      //vypise celou ulozenou PojistenouOsobu dle String.Format
                foreach (PojistenaOsoba osoba in pojisteneOsoby)                    
                    Console.WriteLine(osoba); 
            }
            spracovaniUzivatelskychVstupu.Pokracuj();
        }

        /// <summary>
        /// vyhledani osoby v DB dle jmena a prijmeni
        /// </summary>
        public void VyhledejOsobu()
        {
            //vyzada jmeno a prijmeni hledane osoby
            Console.WriteLine("Hledaná osoba");
            string jmeno = spracovaniUzivatelskychVstupu.ZiskejJmeno();
            string prijmeni = spracovaniUzivatelskychVstupu.ZiskejPrijmeni();

            //ze seznamu db vysledkyHledani vypis vysledky
            List<PojistenaOsoba> pojisteneOsoby = databazeOsob.VyhledejOsobu(jmeno, prijmeni); //pracuje se seznamem, kde jsou osoby s danym jmenem a prijmenim
            if (!pojisteneOsoby.Any())
                 Console.WriteLine("\nŽádná osoba nebyla nalezena.");         //pokud se nanasla zadna shoda jmena a prijmeni
            else
            {
                Console.WriteLine("\nNalezeno:\n");                         //vypise vsechny Osoby ze seznamu, kam se ulozili shody dle jmena a prijmeni
                foreach (PojistenaOsoba osoba in pojisteneOsoby)            
                     Console.WriteLine(osoba); 
            }
            spracovaniUzivatelskychVstupu.Pokracuj();
        }
        /// <summary>
        /// vymazani osoby z db -> najde dle jmena prijmeni + upresneni dle poradoveho cisla
        /// </summary>
        public void VymazOsobu()
        {
            //vyzada jmeno a prijmeni hledane osoby         
            Console.WriteLine("Hledaná osoba k vymazáni");
            string jmeno = spracovaniUzivatelskychVstupu.ZiskejJmeno();
            string prijmeni = spracovaniUzivatelskychVstupu.ZiskejPrijmeni();

            List<PojistenaOsoba> pojisteneOsoby = databazeOsob.VyhledejOsobu(jmeno, prijmeni); //pracuje se seznamem, kde jsou osoby s danym jmenem a prijmenim
            if (!pojisteneOsoby.Any())
                 Console.WriteLine("\nOsoba nebyla nalezena.");                  //pokud se nanasla zadna shoda jmena a prijmeni
            else
            {
                Console.WriteLine("\nNalezeno:\n");                         //vypise vsechny Osoby ze seznamu, kam se ulozili shody dle jmena a prijmeni
                foreach (PojistenaOsoba osoba in pojisteneOsoby)
                    Console.WriteLine(osoba);

                Console.Write("Vyber poradove cislo osoby, kterou chcete vymazat: \t");  //upresneni, ktera osoba ma byt vymazana, pokud je vice nalezeno se stejnym jmenem a prijmenim
                
                if (int.TryParse(Console.ReadLine(), out int index))
                {                                                           // nalezeni osoby se zadanym poradovym cislem 
                    PojistenaOsoba osobaKVymazani = pojisteneOsoby.FirstOrDefault(osoba => osoba.PoradoveCislo == index);
                    if (osobaKVymazani != null)
                    {
                        Console.WriteLine("Vymazat?: [a/n]\n");
                        char zmazat = char.ToLower(Console.ReadKey().KeyChar);

                        if (zmazat == 'n')              //vymazani neni potvrzene, nic se nestane, vyskoci
                        { //break;
                        }
                        else if (zmazat == 'a')
                        {
                            databazeOsob.VymazOsobu(osobaKVymazani);               //vymaze nalezenou osobu z db
                            Console.WriteLine("\nVymazáno");
                        }
                        else
                            Console.WriteLine("\nNeplatná volba, prosím vyberte [a] pro vymazání nebo [n] pro zrušení.");
                    }
                    else
                        Console.WriteLine("Nesprávné pořadové číslo.");
                }
            }
            spracovaniUzivatelskychVstupu.Pokracuj();
        }
        /// <summary>
        /// uvodni nabidka akci
        /// </summary>
        public void ZobrazNabidku()
        {
            Console.Clear();
            Console.WriteLine("________________________________\n");
            Console.WriteLine("Evidence pojištěných osob");
            Console.WriteLine("________________________________\n");
            Console.WriteLine("Možnosti práce s Evidenci pojištěných");
            Console.WriteLine("1 - Přidat novou pojištěnou osobu do databáze");
            Console.WriteLine("2 - Vypsat všechny pojištěné osoby v databázi");
            Console.WriteLine("3 - Vyhledat pojištenou osobu v databázi");
            Console.WriteLine("4 - Vymazat pojištěnou osobu z databáze");
            Console.WriteLine("5 - Konec\n");
        }

        /// <summary>
        /// spusteni programu, kde je uvodni nabidka vypsana vzdy a uzivatel si vybira akci 
        /// </summary>
        public void SpustEvidenci()
        {
            char vyberAkce = '0';
            do
            {
                ZobrazNabidku();

                Console.WriteLine("\nZadejte akci:\n");
                vyberAkce = Console.ReadKey().KeyChar;      //nacte vybranou akci v char
                Console.WriteLine();

                switch (vyberAkce)
                {
                    case '1':
                        PridejOsobu();
                        break;
                    case '2':
                        VypisSeznamOsob();
                        break;
                    case '3':
                        VyhledejOsobu();
                        break;
                    case '4':
                        VymazOsobu();
                        break;
                    case '5':
                        Console.WriteLine("Děkujeme za použití aplikace. Naschledanou. \n(Stiskněte libovolnou klávesu)"); //exit
                        break;
                    default:
                        Console.WriteLine("Neplatna volba,  stiskněte libovolnou klávesu a opakujte volbu."); //pri nezadani char
                        break;
                }
            } while (vyberAkce != '5');
        }
    }
}
