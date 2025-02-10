using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lmsV1
{
    internal class Program
    {
        static int STNO = 1001;
        static List<Student> students = new List<Student>();
        static bool flag;
        static void Main(string[] args)
        {
            string path = "C:\\OOP\\Projects\\lmsV1\\Admin.txt";
            string[] names = new string[5];
            string[] password = new string[5];
            

             


            while (true)
            {

                Console.Clear();
                header();

                int a = 0;
                a = menu();

                if (a == 1)
                {
                    int option = 0;
                    while (option != 3)
                    {
                        Console.Clear();
                        header();
                        option = adminSignupSignin();
                        readData(path, names, password);
                        if (option == 1)
                        {
                            Console.WriteLine("Enter UserName: ");
                            string n = Console.ReadLine();
                            Console.WriteLine("Enter Password: ");
                            string p = Console.ReadLine();
                            signIn(n, p, names, password);
                        }
                        else if (option == 2)
                        {
                            Console.WriteLine("Enter New Name: ");
                            string n = Console.ReadLine();
                            Console.WriteLine("Enter New Password: ");
                            string p = Console.ReadLine();
                            signUp(path, n, p);
                        }
                        else if (option == 3)
                        {
                            break;
                        }
                        if (flag == true)
                        {
                            while (true)
                            {
                                Console.Clear();
                                header();
                                int b = adminmenu();
                                if (b == 1)
                                {
                                    AddStudent();
                                    STNO++;
                                    Console.WriteLine("\n Student Added Successfully!");
                                }
                                else if (b == 2)
                                {
                                    ShowStudents();
                                    Console.Read();
                                }
                                else if(b ==3)
                                {
                                    UpdateStudentInfo();
                                    Console.Read();
                                }
                                else if (b == 4)
                                {
                                    DeleteStudent();
                                    Console.Read();
                                }
                                else if (b == 5)
                                {
                                    break;
                                }
                            }
                            break;
                        }
                        else if (!flag)
                        {
                            Console.WriteLine("Enter a valid Username or Password");
                            Console.Read();
                            break;
                        }
                    }
                }
                if (a ==4)
                {
                    break;
                }
               
            }

           
        }


        static void header()
        {
            System.Console.Clear();
            Console.WriteLine("**********************************************************************");
            Console.WriteLine("*                                                                    *");
            Console.WriteLine("*    #####   ##### #   #  ###   ###  #       #     #     #  #####    *");
            Console.WriteLine("*   #       #      #   # #   # #   # #       #     # # # # #         *");
            Console.WriteLine("*    #####  #      ##### #   # #   # #       #     #  #  #  #####    *");
            Console.WriteLine("*         # #      #   # #   # #   # #       #     #     #       #   *");
            Console.WriteLine("*    #####   ##### #   #  ###   ###  #####   ##### #     #  #####    *");
            Console.WriteLine("*                                                                    *");
            Console.WriteLine("**********************************************************************");
        }
        static int menu()
        {
            int option;
            Console.WriteLine("--Welcome to school learning management system--");
            Console.WriteLine("Select one of the following option numbers:- ");
            Console.WriteLine("1. Login as Admin");
            Console.WriteLine("2. Login as Teacher");
            Console.WriteLine("3. Login as a Student");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your option: ");
            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 4)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                Console.Write("Enter your option: ");
            }
            return option;
        }

        static int adminSignupSignin()
        {
            int option;
            Console.WriteLine("1. SignIn");
            Console.WriteLine("2. SignUp");
            Console.WriteLine("3. Back");
            Console.WriteLine("Enter Option");
            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 3)
            {
                Console.WriteLine("Invalid input. Please enter a valid option (1-3):");
            }
            return option;
        }
        static void readData(string path, string[] names, string[] password)
        {
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    names[x] = parseData(record, 1);
                    password[x] = parseData(record, 2);
                    x++;
                    if (x >= 5)
                    {
                        break;
                    }
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }
        }
        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        static void signIn(string n, string p, string[] names, string[] password)
        {
            flag = false;
            for (int x = 0; x < 5; x++)
            {
                if (n == names[x] && p == password[x])
                {
                    Console.WriteLine("Valid User");
                    flag = true;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("Invalid User");
            }
            
        }
        static void signUp(string path, string n, string p)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(n + "," + p);
            file.Flush();
            file.Close();
        }
        static int adminmenu()
        {
            int option;
            Console.WriteLine("--Welcome to school learning management system--");
            Console.WriteLine("Select one of the following option numbers:- ");
            Console.WriteLine("1. Add a new Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Update Student Credentials");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Back");


            Console.Write("Enter your option: ");
            while (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid input. Please enter a valid option number.");
                Console.Write("Enter your option: ");
            }
            return option;
        }

        static void AddStudent()
        {
            int stno = STNO;

            Console.Write("Enter Student Name: ");
            string stname = Console.ReadLine();

            Console.Write("Enter Father's Name: ");
            string fathername = Console.ReadLine();

            Console.Write("Enter Student CNIC: ");
            string stcnic = Console.ReadLine();

            Console.Write("Enter Student Age: ");
            if (!int.TryParse(Console.ReadLine(), out int stage))
            {
                Console.WriteLine("Invalid input for age. Please enter a valid number.");
                return;
            }

            Console.Write("Enter Student Contact: ");
            string stcontact = Console.ReadLine();

            Console.Write("Enter Student Grade: ");
            string stgrade = Console.ReadLine();

            Console.Write("Enter Student Address: ");
            string staddress = Console.ReadLine();
            students.Add(new Student(stno, stname, fathername, stcnic, stage, stcontact, stgrade, staddress));
            Student student = new Student(stno, stname, fathername, stcnic, stage, stcontact, stgrade, staddress);


        }
        static void ShowStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                return;
            }

            
            foreach (var student in students)
            {
                student.viewstudent();
            }
        }
        static void UpdateStudentInfo()
        {
            Console.Write("Enter Student Number to update: ");
            if (!int.TryParse(Console.ReadLine(), out int stno))
            {
                Console.WriteLine("Invalid input for student number. Please enter a valid number.");
                return;
            }

            var student = students.FirstOrDefault(s => s.StNo == stno);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.Write("Enter New Student Name: ");
            student.StName = Console.ReadLine();

            Console.Write("Enter New Father's Name: ");
            student.Fathername = Console.ReadLine();

            Console.Write("Enter New Student CNIC: ");
            student.StCNIC = Console.ReadLine();

            Console.Write("Enter New Student Age: ");
            if (!int.TryParse(Console.ReadLine(), out int stage))
            {
                Console.WriteLine("Invalid input for age. Please enter a valid number.");
                return;
            }
            student.StAge = stage;

            Console.Write("Enter New Student Contact: ");
            student.StContact = Console.ReadLine();

            Console.Write("Enter New Student Grade: ");
            student.StGrade = Console.ReadLine();

            Console.Write("Enter New Student Address: ");
            student.Staddress = Console.ReadLine();

            Console.WriteLine("Student information updated successfully.");
        }

        static void DeleteStudent()
        {
            Console.Write("Enter Student Number to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int stno))
            {
                Console.WriteLine("Invalid input for student number. Please enter a valid number.");
                return;
            }

            var student = students.FirstOrDefault(s => s.StNo == stno);
            if (student == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            students.Remove(student);
            Console.WriteLine("Student deleted successfully.");
        }



    }
}
