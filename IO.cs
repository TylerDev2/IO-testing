using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace obj
{
    class Person
    {

        private string name;
        private int age;
        private int height;
        private string password;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                this.age = value;
            }
        }
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                this.height = value;
            }
        }

        Person(string name,string password)
        {
            this.name = name;
            this.password = password;
        }

        public void login()
        {
            Console.Write("username: ");
            string name = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            if (name == "Tyler" && password == "admin")
            {
                while (true)
                {
                    Console.WriteLine("Welcome back, {0}. You are successfully logged in", name);
                    Console.WriteLine("To exit simply type '-1'");
                    Console.WriteLine("");
                    Console.WriteLine("1) To read a text file, simply type '0'.");
                    Console.WriteLine("2) To write to a file, type '1'");
                    int input = Convert.ToInt32(Console.ReadLine());
                    
                    switch (input)
                    {
                        case 0:
                            Console.Write("Please enter a valid text file path: ");
                            string filename = Console.ReadLine();
                            StreamReader read = new StreamReader(filename);
                            try
                            {
                                using (read)
                                {
                                    Console.WriteLine("File Contents: ");
                                    Console.WriteLine("============================");
                                    Console.WriteLine("");
                                    Console.WriteLine(read.ReadToEnd());
                                    Console.WriteLine("");
                                    Console.WriteLine("============================");
                                }
                            }
                            catch (FileNotFoundException)
                            {
                                Console.Error.WriteLine("Error, file not found");
                            }
                            catch (IOException)
                            {
                                Console.Error.WriteLine("Error, Cannot read the file.");
                            }
                            break;


                        case 1:
                            Console.Write("Please enter a valid text file path: ");
                            string filename2 = Console.ReadLine();
                            StreamWriter write = new StreamWriter(filename2);
                            
                            using (write)
                            {
                                Console.Write("What would you like to write to the file? ");
                                string writeto = Console.ReadLine();
                                write.WriteLine(writeto);
                                Console.WriteLine("File successfully written to.");
                                Console.WriteLine("File now reads: ");
                            }
                            StreamReader reader = new StreamReader(filename2);
                            using (reader)
                            {
                                Console.WriteLine("============================");
                                Console.WriteLine("");
                                Console.WriteLine(reader.ReadToEnd());
                                Console.WriteLine("");
                                Console.WriteLine("============================");
                            }
                            break;
                    }

                    if (input == -1)
                    {
                        Console.WriteLine("Exiting...");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("its a no from me, {0}.", name);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                string name = "";
                string password = "";
                Person p1 = new Person(name, password);
                p1.login();
            }
        }
    }
}
