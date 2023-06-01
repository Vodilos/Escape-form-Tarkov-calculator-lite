using System;
using System.Threading;
using System.IO;

namespace tarkovusdandeurcalcolator
{
    class Program
    {
        private static int kurzrubusd;
        private static string pathProgram;
        private static string kurzInt;
        private static string path;
        // Made by Vodilos_ (https://vodilos.9e.cz ; https://github.com/Vodilos)
        static void Main(string[] args)
        {
            pathProgram = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            kurzInt = @"\TarkovCalculator\kurz.int";
            path = pathProgram + kurzInt;
            // Vykoná hlavní program
            Kurz();
        }
        static void Kurz()
        {
            try
            {
                string kurzread = File.ReadAllText(path);
                kurzrubusd = Convert.ToInt32(kurzread);
            }
            catch (UnauthorizedAccessException)
            {
                kurzrubusd = 403;

            }
            catch (Exception)
            {
                kurzrubusd = 404;
                Console.WriteLine("Someting went worng");
                Thread.Sleep(2000);
            }
            Menu();
        }
        static void Menu()
        {
            // Proměné
            int ChoseCurr;
            string number1or2 = "Use numbers only";
            //  Main menu
            Console.Clear();
            Console.WriteLine("Chose currency:");
            Console.WriteLine("1. RUB to USD");
            Console.WriteLine("2. USD TO RUB");
            Console.WriteLine("3. Settings");
            Console.WriteLine("4. Quit application");
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
                    Setting();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Menu();
                    Console.WriteLine(number1or2);
                    break;
            }
        }

        static void Setting()
        {
            Console.Clear();
            Console.WriteLine("Enter new exchange rate:");
            Console.WriteLine("Use only numbers");
            try
            {
                int novyExchange = Convert.ToInt32(Console.ReadLine());
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(novyExchange);
                    sw.Close();
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Application doesn't have right permission try to run the application as admin.");
                Thread.Sleep(2000);
                Console.WriteLine("Going back to menu...");
                Thread.Sleep(1500);
                Menu();
            }
            catch (Exception)
            {
                Setting();
            }
            Console.WriteLine("Your exchange rate has been saved :D");
            Console.WriteLine("Going back to menu");
            Thread.Sleep(1500);
            Kurz();
        }
        // Rubtousd kalkulace
        static void Rubtousd()
        {
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
            int rubtousd2 = Convert.ToInt32(rubtousd) / kurzrubusd;
            double rubtousd3 = rubtousd / kurzrubusd - rubtousd2 - 1;
            double rubtousd4 = rubtousd3 * kurzrubusd;
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
            Console.WriteLine(usdtorub * kurzrubusd + " RUB");

            // Navrácení do menu
            Console.WriteLine("\nType anything to retrun to the menu.");
            Console.ReadLine();
            Menu();
        }
    }
}
