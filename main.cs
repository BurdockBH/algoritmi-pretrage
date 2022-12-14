using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Zadaca1.Algoritmi;
using System.Diagnostics;
using System.IO;
using Zadaca1.Klase;

namespace Zadaca1
{
    internal class main
    {

        /* Ukoliko je ova konstanta stavljena na true, sve informacija koje se zapisuju na konzolu ce takoder biti
        Zapisane i u .txt file koji ce se nalaziti pored .exe file-a samog projekta. Ukoliko je stavljen na false
        Ispis ce se samo vrsiti na konzolu. */
        const bool ZAPISI_U_DATOTEKU = true;

        static void Main(string[] args)
        {

            /* Postavlja sirinu dovoljnu za ispis informacija, jer ne mora znaciti da su svima iste dimenzije */
            Console.SetWindowSize(180, 40);

            Console.Write("Odaberite opciju (1 za korisnicku pretragu, 2 za takmicenje algoritama): ");
            string odgovor = Console.ReadLine();
            switch (odgovor)
            {
                case "1":
                    Console.WriteLine("Odabir pretrage");
                    KorisnickaPretraga();
                    Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("Odabir takmicenja");
                    TakmicenjeAlgoritama();
                    Console.ReadLine();
                    break;
                default:
                    return;
            }
        }

        static void TakmicenjeAlgoritama()
        {
            List<List<Tuple<string, TimeSpan, int, string, string, string>>> rezultati1 = ListingKomparacijeOsoba(100);
            List<List<Tuple<string, TimeSpan, int, string, string, string>>> rezultati2 = ListingKomparacijeOsoba(1000);
            List<List<Tuple<string, TimeSpan, int, string, string, string>>> rezultati3 = ListingKomparacijeOsoba(10000);

            var ukupni_rezultati = new List<List<List<Tuple<string, TimeSpan, int, string, string, string>>>>();
            ukupni_rezultati.Add(rezultati1);
            ukupni_rezultati.Add(rezultati2);
            ukupni_rezultati.Add(rezultati3);

            /* Beskonacna petlja za pomjeranje listinga algoritama, pritiskom na ESC program zavrsava sa radom. */
            int i = 0;
            while (true)
            {
                Console.Clear();
                IspisiListingOsoba(ukupni_rezultati[i % ukupni_rezultati.Count()]);
                Console.WriteLine("Bilo koja tipka za iduci listing, ESC za kraj...");

                var unos = Console.ReadKey().Key;
                if (unos != ConsoleKey.Escape)
                    i++;
                else return;
            }
        }

        static void KorisnickaPretraga()
        {
            
            Console.Clear();
            Console.WriteLine("{0,-30} {1,5}\n", "Naziv algoritma", "Unesite:");
            Console.WriteLine("{0,-30} {1,5}", "Iscrpna pretraga", "1");
            Console.WriteLine("{0,-30} {1,5}", "Fibonaci pretraga", "2");
            Console.WriteLine("{0,-30} {1,5}", "Binarna pretraga ", "3");
            Console.WriteLine("{0,-30} {1,5}", "Skok pretraga ", "4");
            Console.WriteLine("{0,-30} {1,5}", "Eksponencijalna pretraga ", "5");
            Console.WriteLine("{0,-30} {1,5}", "Rekurzivna binarna pretraga ", "6");
            Console.WriteLine("{0,-30} {1,5}", "Ternarna pretraga", "7");
            Console.WriteLine("{0,-30} {1,5}", "Bogo pretraga", "8");
            Console.WriteLine("{0,-30} {1,5}", "Bibliotecna pretraga", "9");
            Console.Write("\nOdaberite algoritam: ");
            int odgovor = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("{0,-30} {1,5}\n", "Naziv kontejnera", "Unesite:");
            Console.WriteLine("{0,-30} {1,5}", "Niz", "1");
            Console.WriteLine("{0,-30} {1,5}\n", "Lista", "2");
            Console.Write("\nOdaberite algoritam: ");
            int kontejner = Convert.ToInt32(Console.ReadLine());

           

            switch (odgovor)
            {
                case 1:
                    switch (kontejner)
                    {
                        case 1:
                            OdradiZaNiz(Pretrage.iscrpnaPretraga);
                            break;
                        case 2:
                            OdradiZaListu(Pretrage.iscrpnaPretraga);
                            break;
                    }
                    break;
                case 2:
                    switch (kontejner)
                    {
                        case 1:
                            OdradiZaNiz(Pretrage.fibonaciPretraga);
                            break;
                        case 2:
                            OdradiZaListu(Pretrage.fibonaciPretraga);
                            break;
                    }
                    break;
                case 3:
                    switch (kontejner)
                    {
                        case 1:
                            OdradiZaNiz(Pretrage.binarnaPretraga);
                            break;
                        case 2:
                            OdradiZaListu(Pretrage.binarnaPretraga);
                            break;
                    }
                    break;
                case 4:
                    switch (kontejner)
                    {
                        case 1:
                            OdradiZaNiz(Pretrage.skokPretraga);
                            break;
                        case 2:
                            OdradiZaListu(Pretrage.skokPretraga);
                            break;
                    }
                    break;
                case 5:
                    switch (kontejner)
                    {
                        case 1:
                            OdradiZaNiz(Pretrage.eksponencijalnaPretraga);
                            break;
                        case 2:
                            OdradiZaListu(Pretrage.eksponencijalnaPretraga);
                            break;
                    }
                    break;
                case 6:
                    switch (kontejner)
                    {
                        case 1:
                            OdradiZaNiz(Pretrage.rekurzivnaBinarnaPretraga);
                            break;
                        case 2:
                            OdradiZaListu(Pretrage.rekurzivnaBinarnaPretraga);
                            break;
                    }
                    break;
                case 7:
                    switch (kontejner)
                    {
                        case 1:
                            OdradiZaNiz(Pretrage.ternarnaPretraga);
                            break;
                        case 2:
                            OdradiZaListu(Pretrage.ternarnaPretraga);
                            break;
                    }
                    break;
                case 8:
                    switch (kontejner)
                    {
                        case 1:
                            OdradiZaNiz(Pretrage.bogoPretraga);
                            break;
                        case 2:
                            OdradiZaListu(Pretrage.bogoPretraga);
                            break;
                    }
                    break;
                case 9:
                    switch (kontejner)
                    {
                        case 1:
                            OdradiZaNiz(Pretrage.bibliotecnaPretraga);
                            break;
                        case 2:
                            OdradiZaListu(Pretrage.bibliotecnaPretraga);
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        static void IspisiOsobu(Osoba osoba, int index)
        {
            Console.WriteLine("{0, -15} {1, -20} {2, -20} {3, -20} {4, -20} {5, -20}\n", "Ime osobe", "Prezime osobe", "Visina osobe", "Tezina osobe", "Datum rodjenja", "Na indexu");
            Console.WriteLine("{0, -15} {1, -20} {2, -20} {3, -20} {4, -20} {5, -20}", osoba.ime, osoba.prezime, osoba.visina, osoba.tezina, osoba.datum_rodenja.ToShortDateString(), index);
        }

        static void OdradiZaNiz(Func<IList<Osoba>, Osoba, int> fja)
        {
            Console.Clear();
            Console.Write("Broj osoba :");
            int n = Convert.ToInt32(Console.ReadLine());
            Osoba[] niz = new Osoba[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Ime "+ (i+1) + ". " + "osobe: ");
                string ime = Console.ReadLine();
                Console.Clear();

                Console.Write("Prezime "+ (i+1) + ". " + "osobe: ");
                string prezime = Console.ReadLine();
                Console.Clear();

                Console.Write("Visina "+ (i+1) + ". " + "osobe: ");
                int visina = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                Console.Write("Tezina "+ (i+1) + ". " + "osobe: ");
                int tezina = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                Console.Write("JMBG "+ (i+1) + ". " + "osobe: ");
                uint jmbg = Convert.ToUInt32(Console.ReadLine());
                Console.Clear();

                Console.Write("Datum rodjenja "+ (i+1) + ". " + "osobe: ");
                DateTime datum = Convert.ToDateTime(Console.ReadLine());
                Osoba x = new Osoba(ime, prezime, visina, tezina, jmbg, datum);
                niz[i] = x;

            }
            Console.Clear();

            Console.Write("JMBG trazene osobe: ");
            uint jmbgTrazeni = Convert.ToUInt32(Console.ReadLine());
            var o = new Osoba("test", "test", 1, 1, jmbgTrazeni, new DateTime(2015, 2, 4));
            Osoba trazenaOsoba = o;
            int index = fja(niz, trazenaOsoba);
            if (index != -1)
            {
                Console.Clear();
                IspisiOsobu(niz[index], index);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Nema trazene osobe!");
            }
            
        }

        static void OdradiZaListu(Func<IList<Osoba>, Osoba, int> fja)
        {
            Console.Clear();
            Console.Write("Broj osoba: ");
            int n = Convert.ToInt32(Console.ReadLine());

            List<Osoba> lista = new List<Osoba>();
          
            for (int i = 0; i < n; i++)
            {
                Console.Clear();

                Console.Write("Ime "+ (i+1) + ". " + "osobe: ");
                string ime = Console.ReadLine();
                Console.Clear();

                Console.Write("Prezime "+ (i+1) + ". " + "osobe: ");
                string prezime = Console.ReadLine();
                Console.Clear();

                Console.Write("Visina "+ (i+1) + ". " + "osobe: ");
                int visina = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                Console.Write("Tezina "+ (i+1) + ". " + "osobe: ");
                int tezina = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                Console.Write("JMBG "+ (i+1) + ". " + "osobe: ");
                uint jmbg = Convert.ToUInt32(Console.ReadLine());
                Console.Clear();

                Console.Write("Datum rodjenja "+ (i+1) + ". " + "osobe: ");
                DateTime datum = Convert.ToDateTime(Console.ReadLine());
                Osoba x = new Osoba(ime, prezime, visina, tezina, jmbg, datum);
                lista.Add(x);

            }
            Console.Clear();

            Console.Write("JMBG trazene osobe: ");
            uint jmbgTrazeni = Convert.ToUInt32(Console.ReadLine());
            var o = new Osoba("test", "test", 1, 1, jmbgTrazeni, new DateTime(2015, 2, 4));
            Osoba trazenaOsoba = o;
            int index = fja(lista, trazenaOsoba);
            if (index != -1)
            {
                Console.Clear();
                IspisiOsobu(lista[index], index);
            }
            else
            {
                Console.Clear();

                Console.WriteLine("Nema trazene osobe!");
            }
        }

        /* Metoda zapisuje sve iteracije algoritama u file */
        static void ZapisiSveUFile(List<List<List<Tuple<string, TimeSpan, int, int, string, string>>>> ukupni_rezultati)
        {
            if (File.Exists("algoritmi_informacije.txt"))
            {
                File.Delete("algoritmi_informacije.txt");
            }

            if (ZAPISI_U_DATOTEKU)
                for (int j = 0; j < ukupni_rezultati.Count(); j++)
                    ZapisiUFile(ukupni_rezultati[j]);
        }

        /* Metoda ispisuje sve iteracije na konzolu */
        static void IspisiListing(List<List<Tuple<string, TimeSpan, int, int, string, string>>> rezultati)
        {

            /* Prolazi kroz sve rezultate i sortira ih po vremenu izvrsenja - rastući poredak */
            for (int i = 0; i < rezultati.Count(); i++)
            {
                rezultati[i].Sort((x, y) => x.Item2.CompareTo(y.Item2));
            }

            Console.WriteLine("{0,-30} {1,20} {2, 20} {3,20} {4,20} {5,20}\n", "Naziv algoritma", "Vrijeme izvrsavanja", "Na indeksu", "Trazeni element", "Kontejner", "Na opsegu");
            foreach (var rezultat in rezultati)
            {
                foreach (var vrijednost in rezultat)
                {
                    Console.WriteLine("{0,-30} {1,20} {2, 20} {3,20} {4,20} {5,20}", vrijednost.Item1, vrijednost.Item2, vrijednost.Item3, vrijednost.Item4, vrijednost.Item5, vrijednost.Item6);
                }
                Console.WriteLine(new String('-', 135));
            }
            Console.WriteLine(new String('\n', 3));
        }

        /* Glavna metoda, u kojoj se najveci dio posla obavlja */
        static List<List<Tuple<string, TimeSpan, int, int, string, string>>> ListingKomparacije(int pocetak, int kraj, bool testListeIliNiza)
        {
            Random random = new Random();
            List<List<Tuple<string, TimeSpan, int, int, string, string>>> iteracija = new List<List<Tuple<string, TimeSpan, int, int, string, string>>>();

            if (testListeIliNiza)
            {
                List<Tuple<string, TimeSpan, int, int, string, string>> rezultatiLista1 = ZapocniKomparaciju(pocetak, kraj, pocetak, testListeIliNiza); //pretraga pocetka
                List<Tuple<string, TimeSpan, int, int, string, string>> rezultatiLista2 = ZapocniKomparaciju(pocetak, kraj, (pocetak + kraj) / 2, testListeIliNiza); //pretraga sredine
                List<Tuple<string, TimeSpan, int, int, string, string>> rezultatiLista3 = ZapocniKomparaciju(pocetak, kraj, kraj, testListeIliNiza); //pretraga kraja
                List<Tuple<string, TimeSpan, int, int, string, string>> rezultatiLista4 = ZapocniKomparaciju(pocetak, kraj, Math.Abs(pocetak) + Math.Abs(kraj), testListeIliNiza); //pretraga nepostojeceg elementa
                iteracija.Add(rezultatiLista1);
                iteracija.Add(rezultatiLista2);
                iteracija.Add(rezultatiLista3);
                iteracija.Add(rezultatiLista4);
            }

            else
            {
                List<Tuple<string, TimeSpan, int, int, string, string>> rezultatiLista1 = ZapocniKomparaciju(pocetak, kraj, pocetak, testListeIliNiza);
                List<Tuple<string, TimeSpan, int, int, string, string>> rezultatiLista2 = ZapocniKomparaciju(pocetak, kraj, (pocetak + kraj) / 2, testListeIliNiza);
                List<Tuple<string, TimeSpan, int, int, string, string>> rezultatiLista3 = ZapocniKomparaciju(pocetak, kraj, kraj, testListeIliNiza);
                List<Tuple<string, TimeSpan, int, int, string, string>> rezultatiLista4 = ZapocniKomparaciju(pocetak, kraj, Math.Abs(pocetak) + Math.Abs(kraj), testListeIliNiza);
                iteracija.Add(rezultatiLista1);
                iteracija.Add(rezultatiLista2);
                iteracija.Add(rezultatiLista3);
                iteracija.Add(rezultatiLista4);
            }
            return iteracija;
        }

        /* Pomocna metoda za popunjavanje niza elementima */
        static int[] DajNiz(int pocetak, int kraj)
        {
            int[] niz = new int[Math.Abs(kraj - pocetak + 1)];
            for (int i = 0; i < niz.Count(); i++)
            {
                niz[i] = pocetak;
                pocetak++;
            }
            return niz;
        }

        /* Pomocna metoda za popunjavanje liste elementima */
        static List<int> DajListu(int pocetak, int kraj)
        {
            List<int> lista = new List<int>(Math.Abs(kraj - pocetak));
            for (int i = pocetak; i <= kraj; i++)
                lista.Add(i);
            return lista;
        }

        /* Metoda vrsi komparaciju algoritama pozivajuci IzvrsiPretragu koja pored ostalog prima funkciju kao parametar */
        static List<Tuple<string, TimeSpan, int, int, string, string>> ZapocniKomparaciju(int pocetak, int kraj, int element, bool testListeIliNiza)
        {
            List<Tuple<string, TimeSpan, int, int, string, string>> lista = new List<Tuple<string, TimeSpan, int, int, string, string>>(0);

            lista.Add(IzvrsiPretragu(Pretrage.iscrpnaPretraga<int>, pocetak, kraj, element, "Iscrpna pretraga", testListeIliNiza));
            lista.Add(IzvrsiPretragu(Pretrage.fibonaciPretraga<int>, pocetak, kraj, element, "Fibonacci pretraga", testListeIliNiza));
            lista.Add(IzvrsiPretragu(Pretrage.binarnaPretraga<int>, pocetak, kraj, element, "Binarna pretraga", testListeIliNiza));
            //lista.Add(IzvrsiPretragu(Pretrage.interpolacijskaPretraga, pocetak, kraj, element, "Interpolacijska pretraga", testListeIliNiza));
            lista.Add(IzvrsiPretragu(Pretrage.skokPretraga<int>, pocetak, kraj, element, "Skok pretraga", testListeIliNiza));
            lista.Add(IzvrsiPretragu(Pretrage.eksponencijalnaPretraga<int>, pocetak, kraj, element, "Eksponencijalna pretraga", testListeIliNiza));
            lista.Add(IzvrsiPretragu(Pretrage.rekurzivnaBinarnaPretraga<int>, pocetak, kraj, element, "Rekurzivna binarna pretraga", testListeIliNiza));

            return lista;
        }

        /* Jedino za naglasiti je to da funkcija prima kao parametar funkciju koja ima dva parametra, listu intova, int i vraca int. */
        static Tuple<string, TimeSpan, int, int, string, string> IzvrsiPretragu(Func<IList<int>, int, int> fja, int pocetak, int kraj, int element, string ime, bool testListeIliNiza)
        {
            List<int> lista = DajListu(pocetak, kraj);
            int[] niz = DajNiz(pocetak, kraj);
            int vrijednost;
            string koristeni_kontejner = testListeIliNiza ? "Lista" : "Niz";


            /* Koristena klasa Stopwatch iz standardne System.Diagnostics biblioteke. Potrebna je za metriku izvrsavanja algoritama.
            metode Start() i Stop() pokrecu i zaustavljaju stopericu, dok za Elapsed mozemo vidjeti proteklo vrijeme od starta do kraja*/
            Stopwatch sw = new Stopwatch();
            sw.Start();
            if (testListeIliNiza)
                vrijednost = fja(lista, element);
            else
                vrijednost = fja(niz, element);
            sw.Stop();

            

            return new Tuple<string, TimeSpan, int, int, string, string>(ime, sw.Elapsed, vrijednost, element, koristeni_kontejner, "[" + pocetak + ", " + kraj + "]");
        }

        /* Metoda koja zapisuje jednu iteraciju (jedan opseg vrijednosti) algoritama u file. Zbog cisceg koda, koristi se u metodi koja zapisuje sve iteracije u file. 
        Koristi se StreamWriter kao klasa pomocu koje smo ostvarili pisanje u file. Pored nje se mogla koristiti i File klasa. */
        static void ZapisiUFile(List<List<Tuple<string, TimeSpan, int, int, string, string>>> rezultati)
        {
            using (StreamWriter sw = File.AppendText("algoritmi_informacije.txt"))
            {

                for (int i = 0; i < rezultati.Count(); i++)
                {
                    rezultati[i].Sort((x, y) => x.Item2.CompareTo(y.Item2));
                }

                sw.WriteLine("{0,-30} {1,20} {2, 20} {3,20} {4,20} {5,20}\n", "Naziv algoritma", "Vrijeme izvrsavanja", "Na indeksu", "Trazeni element", "Kontejner", "Na opsegu");
                foreach (var rezultat in rezultati)
                {
                    foreach (var vrijednost in rezultat)
                    {
                        sw.WriteLine("{0,-30} {1,20} {2, 20} {3,20} {4,20} {5,20}", vrijednost.Item1, vrijednost.Item2, vrijednost.Item3, vrijednost.Item4, vrijednost.Item5, vrijednost.Item6);
                    }
                    sw.WriteLine(new String('-', 135));
                }
                sw.WriteLine(new String('\n', 3));
                sw.Flush();
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///
        /* Glavna metoda, u kojoj se najveci dio posla obavlja */
        static List<List<Tuple<string, TimeSpan, int, string, string, string>>> ListingKomparacijeOsoba(int velicina) //u svim funkcijama u je trazeni element bio int, promijenio sam u string da vrati ime
        {
            Random random = new Random();
            List<List<Tuple<string, TimeSpan, int, string, string, string>>> iteracija = new List<List<Tuple<string, TimeSpan, int, string, string, string>>>(); 

            List<Osoba> listaOsoba = DajListuOsoba(velicina); //kreira listu random osoba
            //U zapocniKomparaciju sam dodao da se salje i kreirana lista

            List<Tuple<string, TimeSpan, int, string, string, string>> rezultatiLista1 = ZapocniKomparacijuOsoba(listaOsoba, velicina, listaOsoba[0]) ; //pretraga pocetka
            List<Tuple<string, TimeSpan, int, string, string, string>> rezultatiLista2 = ZapocniKomparacijuOsoba(listaOsoba, velicina, listaOsoba[velicina / 2]); //pretraga sredine
            List<Tuple<string, TimeSpan, int, string, string, string>> rezultatiLista3 = ZapocniKomparacijuOsoba(listaOsoba, velicina, listaOsoba[velicina]); //pretraga kraja
          /* Osoba nepostojeca = new Osoba("ermin", "floki", 1, 1, 1525781, new DateTime(1999, 12, 15)); //nepostojeci jer je JMBG sedam cifri
            List<Tuple<string, TimeSpan, int, string, string, string>> rezultatiLista4 = ZapocniKomparacijuOsoba(listaOsoba, velicina, nepostojeca);*/ //pretraga nepostojeceg elementa //ovo je pojebano baca exception
            iteracija.Add(rezultatiLista1);
            iteracija.Add(rezultatiLista2);
            iteracija.Add(rezultatiLista3);
            /*iteracija.Add(rezultatiLista4);*/

            return iteracija;
        }

        /* Metoda vrsi komparaciju algoritama pozivajuci IzvrsiPretragu koja pored ostalog prima funkciju kao parametar */
        static List<Tuple<string, TimeSpan, int, string, string, string>> ZapocniKomparacijuOsoba(List<Osoba> listaOsoba, int velicina, Osoba element)
        {
            List<Tuple<string, TimeSpan, int, string, string, string>> lista = new List<Tuple<string, TimeSpan, int, string, string, string>>(0);

            lista.Add(IzvrsiPretraguOsoba(Pretrage.iscrpnaPretraga<Osoba>, listaOsoba,  velicina, element, "Iscrpna pretraga"));
            lista.Add(IzvrsiPretraguOsoba(Pretrage.fibonaciPretraga, listaOsoba, velicina, element, "Fibonacci pretraga"));
            lista.Add(IzvrsiPretraguOsoba(Pretrage.binarnaPretraga, listaOsoba, velicina, element, "Binarna pretraga")); 
            lista.Add(IzvrsiPretraguOsoba(Pretrage.skokPretraga, listaOsoba, velicina, element, "Skok pretraga"));
            lista.Add(IzvrsiPretraguOsoba(Pretrage.eksponencijalnaPretraga, listaOsoba, velicina, element, "Eksponencijalna pretraga"));
            lista.Add(IzvrsiPretraguOsoba(Pretrage.rekurzivnaBinarnaPretraga, listaOsoba, velicina, element, "Rekurzivna binarna pretraga"));
            lista.Add(IzvrsiPretraguOsoba(Pretrage.bibliotecnaPretraga, listaOsoba, velicina, element, "Bibliotecna pretraga"));
            lista.Add(IzvrsiPretraguOsoba(Pretrage.bogoPretraga, listaOsoba, velicina, element, "Bogo pretraga"));
            lista.Add(IzvrsiPretraguOsoba(Pretrage.ternarnaPretraga, listaOsoba, velicina, element, "Ternarna pretraga"));

            return lista;
        }

        static Tuple<string, TimeSpan, int, string, string, string> IzvrsiPretraguOsoba(Func<IList<Osoba>, Osoba, int> fja, List<Osoba> listaOsoba, int velicina, Osoba element, string ime)
        {
            int vrijednost;
            string koristeni_kontejner = "Lista";

            Stopwatch sw = new Stopwatch();
            sw.Start();
            vrijednost = fja(listaOsoba, element);
            sw.Stop();

            return new Tuple<string, TimeSpan, int, string, string, string>(ime, sw.Elapsed, vrijednost, listaOsoba[listaOsoba.IndexOf(element)].ime, koristeni_kontejner, "[" + 0 + ", " + velicina + "]");
        }

        static List<Osoba> DajListuOsoba(int velicina)
        {
            Random rand = new Random();
            List<Osoba> lista = new List<Osoba>();
            for (int i = 0; i <= velicina; i++)
            {
                Osoba o = new Osoba(Osoba.DajRandomString(4), Osoba.DajRandomString(6), rand.Next(1, 100), rand.Next(1, 100), (uint)rand.Next(100000000, 999999999), new DateTime(rand.Next(2000, 2050), rand.Next(1, 12), rand.Next(1, 27)));
                lista.Add(o);
            }
            return lista;
        }
        static void IspisiListingOsoba(List<List<Tuple<string, TimeSpan, int, string, string, string>>> rezultati)
        {
            for (int i = 0; i < rezultati.Count(); i++)
            {
                rezultati[i].Sort((x, y) => x.Item2.CompareTo(y.Item2));
            }

            Console.WriteLine("{0,-30} {1,20} {2, 20} {3,20} {4,20} {5,20}\n", "Naziv algoritma", "Vrijeme izvrsavanja", "Na indeksu", "Trazeni element", "Kontejner", "Na opsegu");
            foreach (var rezultat in rezultati)
            {
                foreach (var vrijednost in rezultat)
                {
                    Console.WriteLine("{0,-30} {1,20} {2, 20} {3,20} {4,20} {5,20}", vrijednost.Item1, vrijednost.Item2, vrijednost.Item3, vrijednost.Item4, vrijednost.Item5, vrijednost.Item6);
                }
                Console.WriteLine(new String('-', 135));
            }
            Console.WriteLine(new String('\n', 3));
        }
    }
}
