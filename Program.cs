using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FinalProject1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Get the current date and time
            DateTime currentTime = DateTime.Now;

            // Print the date and time to the console
            Console.WriteLine(currentTime);
            Console.ResetColor();
            //intro:
            //Papainput tayo sa user ng info para malaman if pwede ba siya mag order         
            Console.Write("Please Enter Your Name: ");
            string name = Convert.ToString(Console.ReadLine());
            Console.Write("         Enter Address: ");
            string add = Console.ReadLine();
            Console.Write("             Enter Age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            if (age < 15)
            {
                //lagay tayo ng kulay para madali makita ni user
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Warning: Unable to Order due to your Age,Age must be 15+!");
                Console.ResetColor();
                return;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Loading");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(300);
            }
            Console.WriteLine();
            Console.WriteLine("Done!");
            Console.ResetColor();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Print the date and time to the console
            Console.WriteLine(currentTime);
            Console.ResetColor();
            Console.WriteLine("   Name: " + name);
            Console.WriteLine("Address: " + add);
            Console.WriteLine();
            Console.WriteLine("       =========================================");
            Console.WriteLine("            Welcome to TweTeaOne MilkTea Shop");
        list1://label para tatawagin if gusto bumalik dito sa part na to
            Console.WriteLine("       =========================================");
            Console.WriteLine("                          MENU");
            Console.WriteLine("       =========================================");
            Console.WriteLine("               [1] MilkTea");
            Console.WriteLine("               [2] Smoothie");
            Console.WriteLine("               [3] FruiTea");
            Console.WriteLine("               [4] Iced Coffee");
            Console.WriteLine("               [0] Exit");
            Console.WriteLine();
            awit:
            Console.Write("Choose category according to Menu: ");
            int menu = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            //start ng conditional statement para sa Category
            if (menu == 1)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Loading");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(".");
                    System.Threading.Thread.Sleep(300);
                }
                Console.WriteLine();
                Console.WriteLine("Done!");
                Console.ResetColor();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                // Print the date and time to the console
                Console.WriteLine(currentTime);
                Console.ResetColor();
                Console.WriteLine("       =========================================");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("                       MILKTEA");
                Console.ResetColor();
                Console.WriteLine("       =========================================");

                IEnumerable<Tuple<int, string, string, string, string>> Mtea = new[]
                {
                        Tuple.Create(1, "Classic", "P65", "P75", "P125"),
                        Tuple.Create(2, "Cookies & Cream", "P65", "P75", "P125"),
                        Tuple.Create(3, "Dark Chocolate", "P65", "P75", "P125"),
                        Tuple.Create(4, "Hokkaido", "P65", "P75", "P125"),
                        Tuple.Create(5, "Matcha", "P65", "P75", "P125"),
                        Tuple.Create(6, "Okinawa", "P65", "P75", "P125"),
                        Tuple.Create(7, "Red Velvet", "P65", "P75", "P125"),
                        Tuple.Create(8, "Winter Melon", "P65", "P75", "P125"),
                        Tuple.Create(9, "Salted Caramel", "P65", "P75", "P125"),
                        Tuple.Create(10, "Brown Sugar", "P65", "P75", "P125"),
                        Tuple.Create(11, "Java Chips", "P65", "P75", "P125")
                };
                Console.WriteLine(Mtea.ToStringTable(new[]
                { "Item Id", "Name", "Small","Medium","Large"},
                a => a.Item1, a => a.Item2, a => a.Item3, a => a.Item4, a => a.Item5));


            opt1:
                Console.Write("Enter Item Id: (press [0] to back MENU): ");
                int choose = Convert.ToInt32(Console.ReadLine());
                if (choose == 0)
                {
                    Console.Clear();
                    goto list1;
                }
                

                string ItemName = "";
                int qty;
                string size = "";
                int small = 65, med = 75, large = 125, amt;
                char again = 'Y';

                switch (choose)
                {
                    case 1:
                        ItemName = "Classic";
                        break;
                    case 2:
                        ItemName = "Cookies & Cream";
                        break;
                    case 3:
                        ItemName = "Dark Chocolate";
                        break;
                    case 4:
                        ItemName = "Hokkaido";
                        break;
                    case 5:
                        ItemName = "Matcha";
                        break;
                    case 6:
                        ItemName = "Okinawa";
                        break;
                    case 7:
                        ItemName = "Red Velvet";
                        break;
                    case 8:
                        ItemName = "Winter Melon";
                        break;
                    case 9:
                        ItemName = "Salted Caramel";
                        break;
                    case 10:
                        ItemName = "Brown Sugar";
                        break;
                    case 11:
                        ItemName = "Java Chips";
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Item Id!Please Select Again!");
                        Console.ResetColor();
                        goto opt1;
                }
                Console.WriteLine("=================================================");
                Console.WriteLine("        You've choosen " + ItemName + "!");
                Console.WriteLine("=================================================");
            gg:
                Console.Write("Enter size: ");
                size = Console.ReadLine();
                Console.Write("Enter quantity: ");
                qty = Convert.ToInt32(Console.ReadLine());
                if (string.Equals(size, "small", StringComparison.InvariantCultureIgnoreCase))
                {
                    amt = qty * small;
                }
                else if (string.Equals(size, "medium", StringComparison.InvariantCultureIgnoreCase))
                {
                    amt = qty * med;
                }
                else if (string.Equals(size, "large", StringComparison.InvariantCultureIgnoreCase))
                {
                    amt = qty * large;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Input");
                    Console.ResetColor();
                    goto gg;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Added to your Cart!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Please wait to checkout");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(".");
                    System.Threading.Thread.Sleep(300);
                }
                Console.WriteLine();
                Console.WriteLine("Done!");
                Console.ResetColor();

                //checkout:
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(currentTime);
                    Console.ResetColor();
                    Console.WriteLine("=================================================");
                    Console.WriteLine("                   CHECKOUT");
                    Console.WriteLine("=================================================");
                    Console.WriteLine("        Name: " + name);
                    Console.WriteLine("     Address: " + add);
                    Console.WriteLine("  Your Order: " + ItemName);
                    Console.WriteLine("        Size: " + size);
                    Console.WriteLine("    Quantity: " + qty);
                    Console.WriteLine("You will pay: " + amt + " pesos");
                    Console.WriteLine("=================================================");
                    Console.WriteLine("Thank You for always choosing TwenTeaOne Shop " + name);
                    Console.WriteLine();
                    dito:
                    Console.Write("Do you want to order again? Y/N: ");
                    again = Convert.ToChar(Console.ReadLine());
                    if (again == 'Y')
                    {
                        Console.Clear();
                        goto list1;
                    }
                    else if (again == 'y')
                    {
                        Console.Clear();
                        goto list1;
                    }
                    else
                    {
                        goto dito;
                    }

                }
            }//end ng menu 1
            else if (menu == 2)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Loading");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(".");
                    System.Threading.Thread.Sleep(300);
                }
                Console.WriteLine();
                Console.WriteLine("Done!");
                Console.ResetColor();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                // Print the date and time to the console
                Console.WriteLine(currentTime);
                Console.ResetColor();
                Console.WriteLine("       =========================================");
                Console.WriteLine("                       SMOOTHIE");
                Console.WriteLine("       =========================================");

                IEnumerable<Tuple<int, string, string, string, string>> Mtea = new[]
                {
                 Tuple.Create(1, "Buko", "P30", "P85", "P125"),
                 Tuple.Create(2, "Buko Pandan", "P30", "P85", "P125"),
                 Tuple.Create(3, "Choco Kisses", "P30", "P85", "P125"),
                 Tuple.Create(4, "Mango", "P30", "P85", "P125"),
                 Tuple.Create(5, "Melon", "P30", "P85", "P125"),
                 Tuple.Create(6, "Taro", "P30", "P85", "P125"),
                 Tuple.Create(7, "Taro Buko", "P30", "P85", "P125"),
                 Tuple.Create(8, "Ube", "P30", "P85", "P125")

                };
                Console.WriteLine(Mtea.ToStringTable(new[]
                { "Item Id", "Name", "Small","Medium","Large"},
                a => a.Item1, a => a.Item2, a => a.Item3, a => a.Item4, a => a.Item5));

            opt2:
                Console.Write("Enter Item Id: (press [0] to back MENU): ");
                int choose = Convert.ToInt32(Console.ReadLine());
                if (choose == 0)
                {
                    Console.Clear();
                    goto list1;
                }

                string iName;
                int qty;
                int small = 30, medium = 85, large = 125, amt;
                string size = "";
                char again = 'Y';

                switch (choose)
                {
                    case 1:
                        iName = "Buko";
                        break;
                    case 2:
                        iName = "Buko Pandan";
                        break;
                    case 3:
                        iName = "Choco Kisses";
                        break;
                    case 4:
                        iName = "Mango";
                        break;
                    case 5:
                        iName = "Melon";
                        break;
                    case 6:
                        iName = "Taro";
                        break;
                    case 7:
                        iName = "Taro Buko";
                        break;
                    case 8:
                        iName = "Ube";
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Item Id!");
                        Console.ResetColor();
                        goto opt2;
                }
                Console.WriteLine("=================================================");
                Console.WriteLine("          You've choosen " + iName + "!");
                Console.WriteLine("=================================================");
            gg:
                Console.Write("Enter size: ");
                size = Console.ReadLine();
                Console.Write("Enter quantity: ");
                qty = Convert.ToInt32(Console.ReadLine());
                if (string.Equals(size, "small", StringComparison.InvariantCultureIgnoreCase))
                {
                    amt = qty * small;
                }
                else if (string.Equals(size, "medium", StringComparison.InvariantCultureIgnoreCase))
                {
                    amt = qty * medium;
                }
                else if (string.Equals(size, "large", StringComparison.InvariantCultureIgnoreCase))
                {
                    amt = qty * large;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Input");
                    Console.ResetColor();
                    goto gg;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Added to your Cart!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Please wait to checkout");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(".");
                    System.Threading.Thread.Sleep(300);
                }
                Console.WriteLine();
                Console.WriteLine("Done!");
                Console.ResetColor();
                //checkout:
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(currentTime);
                    Console.ResetColor();
                    Console.WriteLine("=================================================");
                    Console.WriteLine("                   CHECKOUT");
                    Console.WriteLine("=================================================");
                    Console.WriteLine("        Name: " + name);
                    Console.WriteLine("     Address: " + add);
                    Console.WriteLine("  Your Order: " + iName);
                    Console.WriteLine("        Size: " + size);
                    Console.WriteLine("    Quantity: " + qty);
                    Console.WriteLine("You will pay: " + amt + " pesos");
                    Console.WriteLine("=================================================");
                    Console.WriteLine("Thank You for always choosing TwenTeaOne Shop " + name);
                    Console.WriteLine();
                    Console.Write("Do you want to order again? Y/N: ");
                    again = Convert.ToChar(Console.ReadLine());
                    if (again == 'Y')
                    {
                        Console.Clear();
                        goto list1;
                    }
                    else if (again == 'y')
                    {
                        Console.Clear();
                        goto list1;
                    }
                    else
                    {
                        return;
                    }
                }
            }//end ng fruittea
            else if (menu == 3)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Loading");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(".");
                    System.Threading.Thread.Sleep(300);
                }
                Console.WriteLine();
                Console.WriteLine("Done!");
                Console.ResetColor();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                // Print the date and time to the console
                Console.WriteLine(currentTime);
                Console.ResetColor();
                Console.WriteLine("       =========================================");
                Console.WriteLine("                       FRUITTEA");
                Console.WriteLine("       =========================================");
                IEnumerable<Tuple<int, string, string, string, string>> Mtea = new[]
                {

                  Tuple.Create(1, "Blueberry", "P65", "P75", "P125"),
                  Tuple.Create(2, "Green Apple", "P65", "P75", "P125"),
                  Tuple.Create(3, "Lychee", "P65", "P75", "P125"),
                  Tuple.Create(4, "Passion Fruit", "P65", "P75", "P125"),
                  Tuple.Create(5, "Strawberry", "P65", "P75", "P125")

                };
                Console.WriteLine(Mtea.ToStringTable(new[]
                { "Item Id", "Name", "Small","Medium","Large"},
                a => a.Item1, a => a.Item2, a => a.Item3, a => a.Item4, a => a.Item5));
            opt3:
                Console.Write("Enter Item Id: (press [0] to back MENU): ");
                int choose = Convert.ToInt32(Console.ReadLine());
                if (choose == 0)
                {
                    Console.Clear();
                    goto list1;
                }

                string iName;
                int qty;
                int small = 65, medium = 75, large = 125, amt;
                string size = "";
                char again = 'Y';

                switch (choose)
                {
                    case 1:
                        iName = "Blueberry";
                        break;
                    case 2:
                        iName = "Green Apple";
                        break;
                    case 3:
                        iName = "Lychee";
                        break;
                    case 4:
                        iName = "Passion Fruit";
                        break;
                    case 5:
                        iName = "Strawberry";
                        break;
                    default:
                        Console.WriteLine("Invalid Item Id!");
                        goto opt3;
                }
                Console.WriteLine("=================================================");
                Console.WriteLine("          You've choosen " + iName + "!");
                Console.WriteLine("=================================================");
            gg:
                Console.Write("Enter size: ");
                size = Console.ReadLine();
                Console.Write("Enter quantity: ");
                qty = Convert.ToInt32(Console.ReadLine());
                if (string.Equals(size, "small", StringComparison.InvariantCultureIgnoreCase))
                {
                    amt = qty * small;
                }
                else if (string.Equals(size, "medium", StringComparison.InvariantCultureIgnoreCase))
                {
                    amt = qty * medium;
                }
                else if (string.Equals(size, "large", StringComparison.InvariantCultureIgnoreCase))
                {
                    amt = qty * large;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Input");
                    Console.ResetColor();
                    goto gg;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Added to your Cart!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Please wait to checkout");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(".");
                    System.Threading.Thread.Sleep(300);
                }
                Console.WriteLine();
                Console.WriteLine("Done!");
                Console.ResetColor();
                //checkout:
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(currentTime);
                    Console.ResetColor();
                    Console.WriteLine("=================================================");
                    Console.WriteLine("                   CHECKOUT");
                    Console.WriteLine("=================================================");
                    Console.WriteLine("        Name: " + name);
                    Console.WriteLine("     Address: " + add);
                    Console.WriteLine("  Your Order: " + iName);
                    Console.WriteLine("        Size: " + size);
                    Console.WriteLine("    Quantity: " + qty);
                    Console.WriteLine("You will pay: " + amt + " pesos");
                    Console.WriteLine("=================================================");
                    Console.WriteLine("Thank You for always choosing TwenTeaOne Shop " + name);
                    Console.WriteLine();
                    Console.Write("Do you want to order again? Y/N: ");
                    again = Convert.ToChar(Console.ReadLine());

                    if (again == 'Y')
                    {
                        Console.Clear();
                        goto list1;
                    }
                    else if (again == 'y')
                    {
                        Console.Clear();
                        goto list1;
                    }
                    else
                    {
                        return;
                    }
                }
            }//end ng fruittea
            else if (menu == 4)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Loading");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(".");
                    System.Threading.Thread.Sleep(300);
                }
                Console.WriteLine();
                Console.WriteLine("Done!");
                Console.ResetColor();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                // Print the date and time to the console
                Console.WriteLine(currentTime);
                Console.ResetColor();
                Console.WriteLine("       =========================================");
                Console.WriteLine("                       ICED COFFEE");
                Console.WriteLine("       =========================================");
                IEnumerable<Tuple<int, string, string, string, string>> Mtea = new[]
             {
                 Tuple.Create(1, "Cappuccino", "P75", "P85", "P135"),
                  Tuple.Create(2, "Coffe Mocha", "P75", "P85", "P135"),
                   Tuple.Create(3, "Salted Caramel", "P75", "P85", "P135"),
                    Tuple.Create(4, "Java Chips", "P75", "P85", "P135"),

             };
                Console.WriteLine(Mtea.ToStringTable(new[]
                { "Item Id", "Name", "Small","Medium","Large"},
                a => a.Item1, a => a.Item2, a => a.Item3, a => a.Item4, a => a.Item5));
            opt3:
                Console.Write("Enter Item Id: (press [0] to back MENU): ");
                int choose = Convert.ToInt32(Console.ReadLine());
                if (choose == 0)
                {
                    Console.Clear();
                    goto list1;
                }

                string iName;
                int qty;
                int small = 75, medium = 85, large = 135, amt;
                string size = "";
                char again = 'Y';

                switch (choose)
                {
                    case 1:
                        iName = "Capuccino";
                        Console.WriteLine("Wow Great Choice!");
                        break;
                    case 2:
                        iName = "Coffee Mocha";
                        break;
                    case 3:
                        iName = "Salted Caramel";
                        break;
                    case 4:
                        iName = "Java Chips";
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Item Id!");
                        Console.ResetColor();
                        goto opt3;
                }
                Console.WriteLine("=================================================");
                Console.WriteLine("          You've choosen " + iName + "!");
                Console.WriteLine("=================================================");
            gg:
                Console.Write("Enter size: ");
                size = Console.ReadLine();
                Console.Write("Enter quantity: ");
                qty = Convert.ToInt32(Console.ReadLine());
                if (string.Equals(size, "small", StringComparison.InvariantCultureIgnoreCase))
                {
                    amt = qty * small;
                }
                else if (string.Equals(size, "medium", StringComparison.InvariantCultureIgnoreCase))
                {
                    amt = qty * medium;
                }
                else if (string.Equals(size, "large", StringComparison.InvariantCultureIgnoreCase))
                {
                    amt = qty * large;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Input");
                    Console.ResetColor();
                    goto gg;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Added to your Cart!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Please wait to checkout");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(".");
                    System.Threading.Thread.Sleep(300);
                }
                Console.WriteLine();
                Console.WriteLine("Done!");
                Console.ResetColor();
                //checkout:
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(currentTime);
                    Console.ResetColor();
                    Console.WriteLine("=================================================");
                    Console.WriteLine("                   CHECKOUT");
                    Console.WriteLine("=================================================");
                    Console.WriteLine("        Name: " + name);
                    Console.WriteLine("     Address: " + add);
                    Console.WriteLine("  Your Order: " + iName);
                    Console.WriteLine("        Size: " + size);
                    Console.WriteLine("    Quantity: " + qty);
                    Console.WriteLine("You will pay: " + amt + " pesos");
                    Console.WriteLine("=================================================");
                    Console.WriteLine("Thank You for always choosing TwenTeaOne Shop " + name);
                    Console.WriteLine();
                    Console.Write("Do you want to order again? Y/N: ");
                    again = Convert.ToChar(Console.ReadLine());

                    if (again == 'Y')
                    {
                        Console.Clear();
                        goto list1;
                    }
                    else if (again == 'y')
                    {
                        Console.Clear();
                        goto list1;
                    }
                    else
                    {
                        return;
                    }
                }
            }//end ng Iced Coffe
            else if (menu ==0)
            {
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your trying to choose out of Menu!Try Again!");
                Console.ResetColor();
                Console.Write(new string(' ', Console.WindowWidth));
                goto awit;
            }

        }
        }
    }
