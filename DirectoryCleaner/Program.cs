using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine("Removed Directories: " + EmptyDirectory(new DirectoryInfo(args[0])));
                Console.ReadLine();
            }            
        }

        static int EmptyDirectory(DirectoryInfo Directory)
        {
            int removedDirectories = 0;

            try
            {
                foreach (DirectoryInfo NestedDirectory in Directory.GetDirectories())
                {
                    removedDirectories += EmptyDirectory(NestedDirectory);
                }
            
                if (Directory.GetFiles().Length == 0 && Directory.GetDirectories().Length == 0)
                {
                    Console.Write("Removing " + Directory.Name + "...");

                    try
                    {
                        Directory.Delete();
                        removedDirectories++;

                        Console.WriteLine(" Success");
                    }
                    catch
                    {
                        Console.WriteLine(" Failed");
                    }
                }
            }
            catch
            {
                Console.WriteLine(Directory.Name + " is Restricted");
            }

            return removedDirectories;        
        }
    }
}
