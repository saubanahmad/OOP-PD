using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lmsV1
{
    internal class Student
    {
        public int StNo;
        public string StName;
        public string Fathername;
        public string StCNIC;
        public int StAge;
        public string StContact;
        public string StGrade;
        public string Staddress;

        public Student(int stNo, string stName, string fathername, string stCNIC, int stAge, string stContact, string stGrade, string staddress)
        {
            StNo = stNo;
            StName = stName;
            Fathername = fathername;
            StCNIC = stCNIC;
            StAge = stAge;
            StContact = stContact;
            StGrade = stGrade;
            Staddress = staddress;
        }

        public void viewstudent()
        {
            Console.WriteLine($"Student No: {StNo}, Student Name:  {StName}, Father name = {Fathername}, CNIC No: {StCNIC}, Age: {StAge}, Contact No: {StContact}, Grade: {StGrade}, Address: {Staddress}");
        }
    }
}
