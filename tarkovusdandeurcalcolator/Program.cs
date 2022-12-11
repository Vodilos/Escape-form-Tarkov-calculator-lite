using System;

namespace tarkovusdandeurcalcolator
{
    class Program
    {
        private int kurzrubusd = 113;
        // Made by Vodilos_ (https://vodilos.9e.cz ; https://github.com/Vodilos)
        static void Main(string[] args)
        {
            // Vykoná hlavní program
            Menu();
        }
        static void Menu()
        {
            // Proměné
            int ChoseCurr;
            string number1or2 = "Use numbers 1 or 2, 3";
            //  Main menu
            Console.Clear();
            Console.WriteLine("Chose currency:");
            Console.WriteLine("1. RUB to USD");
            Console.WriteLine("2. USD TO RUB");
            Console.WriteLine("3. Quit application");
            Console.WriteLine(number1or2);
            // Input
            try
            {
                ChoseCurr = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Menu();
                throw;
            }
            // Co vybrat
            switch (ChoseCurr)
            {
                case 1:
                    Rubtousd();
                    break;
                case 2:
                    Usdtorub();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Menu();
                    Console.WriteLine(number1or2);
                    break;
            }
        }
        // Rubtousd kalkulace
        static void Rubtousd()
        {
            Program kurz = new Program();
            // Proměná
            double rubtousd;
            // Zeptání se kolik usd to rub
            Console.Clear();
            Console.WriteLine("Write how many RUB you want to convert to USD");
            // Input
            try
            {
                rubtousd = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Rubtousd();
                throw;
            }
            // Kalkulace as good
            int rubtousd2 = Convert.ToInt32(rubtousd) / kurz.kurzrubusd;
            double rubtousd3 = rubtousd / kurz.kurzrubusd - rubtousd2 - 1;
            double rubtousd4 = rubtousd3 * kurz.kurzrubusd;
            int rubtousd5 = Convert.ToInt32(rubtousd4) * 2;
            int rubtousd6 = Math.Abs(rubtousd5) / 2;
            // Vypsání vyseldků
            Console.WriteLine("How close you was to antoher USD: " + rubtousd6 + $" ({rubtousd + rubtousd6})" + " RUB");
            Console.WriteLine("How many you can ACTUALLY afford: " + rubtousd2 + " USD");

            // Vrácení
            Console.WriteLine("\nType anything to retrun to the menu.");
            Console.ReadLine();
            Menu();

        }
        // usdtorub kalkulce
        static void Usdtorub()
        {
            // Poroměná
            int usdtorub;
            Program kurz = new Program();
            // Ptaní se kolik chce usd to rub
            Console.Clear();
            Console.WriteLine("Write how many USD you want to convert to RUB");
            // Input
            try
            {
                usdtorub = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
            Usdtorub();
            throw;
            }
            // Výsledek + kaluklace
            Console.WriteLine(usdtorub * kurz.kurzrubusd + " RUB");

            // Navrácení do menu
            Console.WriteLine("\nType anything to retrun to the menu.");
            Console.ReadLine();
            Menu();
        }
    }
}
