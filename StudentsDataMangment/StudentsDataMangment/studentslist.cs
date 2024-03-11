using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsDataMangment
{
    internal class studentslist
    {
        public string name;
        public string lastname;
        public string fathername;
        public string birthday;
        public string joindate;
        public string nationality;

        public studentslist(string Name, string Lastname, string Fathername, string Birthday, string Joindate, string Nationality)
        {
            name = Name;
            lastname = Lastname;
            fathername = Fathername;
            birthday = Birthday;
            joindate = Joindate;    
            nationality = Nationality;

        }

      
    }
}
