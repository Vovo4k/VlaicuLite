using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Sys = Cosmos.System;
namespace VlaicuOS
{
    public class Kernel : Sys.Kernel
    {
        private int num1;
        private int num2;
        private object sum;
        protected override void BeforeRun()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("      |\\      _,,,---,,_\r\nZZZzz /,`.-'`'    -.  ;-;;,_\r\n     |,4-  ) )-,_. ,\\ (  `'-'\r\n    '---''(_/--'  `-'\\_)  Nikusea :3 ");
            Console.Beep(422, 444);
            Console.Beep(440, 444);
            Console.Beep(422, 444);
            Console.Beep(440, 444);
            Console.Beep(422, 444);
            Console.Beep(440, 444);
            Console.WriteLine("Welcome to VlaicuLite");
            Console.Beep(422, 888);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("VlaicuLite version 0.02");
            Console.WriteLine("Powered by Cosmos");
            Console.WriteLine("Options:");
            Console.WriteLine("1: Boot Vlaicu OS normally");
            Console.WriteLine("2: Boot without FileSystem");
            Console.Write("Thanks to ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("for the logo!");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Chosen Option: ");
            Console.ForegroundColor = ConsoleColor.White;
            var option = Console.ReadLine();
            if (option.Contains("1"))
            {
                var fs = new Sys.FileSystem.CosmosVFS();
                Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            if (option.Contains("ms-dos"))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Loading VlaicuLite.elf...");
                Console.Beep();
                Console.WriteLine("");
                Console.Write("C:\\>");
                Console.ReadLine();
                Console.WriteLine("Starting Kernel.cs...");
                Console.Beep(1975, 200);
                Console.Beep(1318, 200);
                Console.Beep(880, 200);
                Console.Beep(987, 300);
                Console.Write("Do you want to initiate the FAT driver? Y/n: ");
                var yesorno = Console.ReadLine();
                Console.Beep();
                if (yesorno == "Y")
                {
                    Console.WriteLine("OK");
                    var fs = new Sys.FileSystem.CosmosVFS();
                    Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
                }
                else if (yesorno == "n")
                {
                    Console.WriteLine("OK");
                }
                else
                {
                    Console.WriteLine("Invalid answer, not enabling...");
                }
            }
            else if (option.Contains("1"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Vlaicu OS version 0.02");
                Console.WriteLine("For help, run command: help.");
            }
            else if (option.Contains("2"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("VlaicuOS version 0.02");
                Console.WriteLine("For help, run command: help.");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("WARNING: You have booted without a filesytem. DO NOT try to use it!");
            }
            else
            {
                Console.WriteLine("You have not chosen a valid boot option and");
                Console.WriteLine("therefore, you have booted into a broken system.");
                Console.WriteLine("Please reboot.");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("VlaicuOS @ nowhere (reboot now!!): ");
                Console.ReadLine();
                Console.Write("I told ya to reboot!: ");
                Console.ReadLine();
                Console.Write("Sigh...: ");
                Console.ReadLine();
                Console.Write("Fine, whatever: ");
            }
        }
        string dir = @"0:\";
        protected override void Run()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("VlaicuOS @ " + dir + ": ");
                Console.ForegroundColor = ConsoleColor.White;
                var input = Console.ReadLine();
                Console.Beep();
                if (input == "shutdown")
                {
                    Sys.Power.Shutdown();
                }
                else
                if (input.Contains("run"))
                {

                    var aquapptorun = input.Remove(0, 4);
                    string[] lines = System.IO.File.ReadAllLines(dir + aquapptorun);
                    var usrinput = "";
                    foreach (string line in lines)
                    {
                        if (line.Contains("info = "))
                        {
                            var info = line.Replace("info = ", "");
                            Console.WriteLine(info);
                            Console.Write("Press any key to start the aquapp! ");
                            Console.ReadLine();
                            Console.WriteLine();
                        }
                        if (line.Contains("write"))
                        {
                            var tempctr = line.Replace("(", "");
                            var tempctr2 = line.Replace(")", "");
                            var ctr = tempctr2.Remove(0, 6);
                            Console.Write(ctr);
                        }
                        else if (line.Contains("sayinput"))
                        {
                            Console.Write(usrinput);
                        }
                        else if (line.Contains("inputget"))
                        {
                            var tempctr = line.Replace("(", "");
                            var tempctr2 = line.Replace(")", "");
                            var ctr = tempctr2.Remove(0, 9);
                            Console.Write(ctr);
                            usrinput = Console.ReadLine();
                        }
                        else if (line.Contains("writeline"))
                        {
                            var tempctr = line.Replace("(", "");
                            var tempctr2 = line.Replace(")", "");
                            var ctr = tempctr2.Remove(0, 10);
                            Console.WriteLine(ctr);
                        }
                        if (line.Contains("time"))
                        {
                            var time = DateTime.Now;
                        }
                        else if (line.Contains("newline"))
                        {
                            Console.WriteLine("");
                        }
                        else
                        {
                            //Skips over unrecognized line, adds to log.
                        }
                    }
                }
                else
                if (input.Contains("mkfile"))
                {
                    var file = (input.Remove(0, 7));
                    var _ = Directory.GetCurrentDirectory();
                    File.Create(dir + "\\" + file);

                }
                else
                if (input.Contains("mkdir"))
                {
                    Directory.CreateDirectory(input.Remove(0, 6));
                    Console.WriteLine("OK");
                }
                else
                if (input.Contains("deldir"))
                {
                    Directory.Delete(@"0:\" + input.Remove(0, 7));
                }
                else
                if (input.Contains("delfile"))
                {
                    File.Delete(input.Remove(0, 8));
                    Console.WriteLine("OK");
                }
                else
                if (input.Contains("cd"))
                {
                    Directory.SetCurrentDirectory(@"0:\" + input.Remove(0, 3));
                    dir = (@"0:\" + input.Remove(0, 3));
                }
                else
                if (input == "ls")
                {
                    foreach (var directory in Directory.GetDirectories(dir))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(directory);
                    }
                    foreach (var file in Directory.GetFiles(dir))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine(file);
                    }

                }
                else
                if (input == ("creator"))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("          _____                    _____                    _____  ");
                    Console.WriteLine("         /\\    \\                  /\\    \\                  /\\    \\ ");
                    Console.WriteLine("        /::\\____\\                /::\\    \\                /::\\    \\     ");
                    Console.WriteLine("       /:::/    /               /::::\\    \\               \\:::\\    \\     ");
                    Console.WriteLine("      /:::/    /               /::::::\\    \\       .        \\:::\\    \\    ");
                    Console.WriteLine("     /:::/    /               /:::/\\:::\\    \\               \\:::\\    \\   ");
                    Console.WriteLine("    /:::/____/               /:::/__\\:::\\    \\               \\:::\\    \\    ");
                    Console.WriteLine("   /::::\\    \\              /::::\\   \\:::\\    \\              /::::\\    \\ ");
                    Console.WriteLine("  /::::::\\____\\________    /::::::\\   \\:::\\    \\    ____    /::::::\\    \\");
                    Console.WriteLine(" /:::/\\:::::::::::\\    \\  /:::/\\:::\\   \\:::\\    \\  /\\   \\  /:::/\\:::\\    \\");
                    Console.WriteLine("/:::/  |:::::::::::\\____\\/:::/  \\:::\\   \\:::\\____\\/::\\   \\/:::/  \\:::\\____\\");
                    Console.WriteLine("\\::/   |::|~~~|~~~~~     \\::/    \\:::\\  /:::/    /\\:::\\  /:::/    \\::/    / ");
                    Console.WriteLine(" \\/____|::|   |           \\/____/ \\:::\\/:::/    /  \\:::\\/:::/    / \\/____/ ");
                    Console.WriteLine("       |::|   |                    \\::::::/    /    \\::::::/    /");
                    Console.WriteLine("       |::|   |                     \\::::/    /      \\::::/____/");
                    Console.WriteLine("       |::|   |                     /:::/    /        \\:::\\    \\ ");
                    Console.WriteLine("       |::|   |                    /:::/    /          \\:::\\    \\");
                    Console.WriteLine("       |::|   |                   /:::/    /            \\:::\\    \\");
                    Console.WriteLine("       \\::|   |                  /:::/    /              \\:::\\____\\");
                    Console.WriteLine("        \\:|   |                  \\::/    /                \\::/    / ");
                    Console.WriteLine("         \\|___|                   \\/____/                  \\/____/ ");
                }
                else
                if (input == ("gettime"))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(DateTime.Now);
                }
                else
                if (input == ("echo"))
                {
                }
                else
                if (input.Contains("erase"))
                {
                    Console.Write("Old file (to erase from): ");
                    var ftef = Console.ReadLine();
                    Console.Write("New filename: ");
                    var nfn = Console.ReadLine();
                    string[] lines = System.IO.File.ReadAllLines(dir + ftef);
                    foreach (string line in lines)
                    {
                        Console.Write("Line: ");
                        Console.WriteLine(line);
                        Console.WriteLine("Delete line?(Y/n): ");
                        var yesorno = Console.ReadLine();
                        if (yesorno == "n")
                        {
                            using (var tw2 = new StreamWriter(dir + nfn, true))
                            {
                                tw2.WriteLine(line);
                            }
                        }
                        else
                        {
                        }
                    }
                    using (var tw3 = new StreamWriter(dir + nfn, true))
                    {
                        tw3.Close();
                    }
                    File.Delete(dir + ftef);
                }
                else
                if (input.Contains("scribble"))
                {
                    //Scribbler: a text editor written in 8 lines of code!
                    Console.WriteLine("1st line: txt file. 2nd line: text to add.");
                    var txtfile = Console.ReadLine();
                    Console.WriteLine("Contents of " + txtfile + ": ");
                    Console.WriteLine(File.ReadAllText(dir + txtfile));
                    Console.WriteLine("Text to add to file: ");
                    var ttw = Console.ReadLine();
                    using (var tw = new StreamWriter(txtfile, true))
                    {
                        tw.WriteLine(ttw);
                        tw.Close();
                    }
                    Console.WriteLine("");
                }
                else
                if (input.Contains("readfile"))
                {
                    Console.WriteLine("");
                    var filetoread = (input.Remove(0, 9));
                    Console.WriteLine(File.ReadAllText(dir + filetoread));
                }
                else
                if (input.Contains("echo"))
                {
                    Console.WriteLine(input.Remove(0, 5));
                }
                else
                if (input == "help")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("about = os information");
                    Console.WriteLine("help = list of commands");
                    Console.WriteLine("shutdown = shuts down system");
                    Console.WriteLine("mkfile (filename) = creates a file");
                    Console.WriteLine("mkdir (dirname) = makes a directory");
                    Console.WriteLine("deldir (dirname) = deletes a directory (not finished yet)");
                    Console.WriteLine("delfile (filename) = deletes a file");
                    Console.WriteLine("readfile (filename) = reads from file");
                    Console.WriteLine("ls = lists files and directories");
                    Console.WriteLine("cd (dirname) = changes directory");
                    Console.WriteLine("cd\\ = returns to 0:\\ directory");
                    Console.WriteLine("clear = clears the screen");
                    Console.WriteLine("echo (text) = echoes user input");
                    Console.WriteLine("gettime = displays date and time");
                    Console.WriteLine("run (program) = runs an aquapp");
                    Console.WriteLine("");
                    Console.WriteLine("Included applications: ");
                    Console.WriteLine("Scribbler: A text file editor written in 8 lines of code!");
                    Console.WriteLine("To use, run the command: scribble");
                    Console.WriteLine("AppWithInfo: A demonstrational aquapp that contains info");
                    Console.WriteLine("HelloUser: A demonstrational aquapp that says hello to the user");
                }
                else
                if (input == "clear")
                {
                    Console.Clear();
                }
                else
                if (input == "about")
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("VlaicuOS 0.01 For Very old pc");
                }
                else
                {
                    if (input == "")
                    {
                    }
                    else
                        Console.WriteLine("Unknown command: " + input);
                }
            }
            catch (Exception exbeforeformatting)
            {
                string exceptionfase2 = exbeforeformatting.ToString();
                var ex = exceptionfase2.Replace("Exception: ", "");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oops:" + ex);
            }
        }

        private static int Add(int n1, int n2, int n3)
        {
            int total = (n1 + n2 + n3);
            return total;
        }
    }
}