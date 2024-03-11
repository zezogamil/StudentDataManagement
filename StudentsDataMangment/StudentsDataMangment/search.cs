using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsDataMangment
{
    public partial class search : Form
    {
        public search()
        {
            InitializeComponent();
        }
        List<studentslist> mystudentlist = new List<studentslist>();
        int indexToShow = 0;


        private void search_Load(object sender, EventArgs e)
        {

            FileStream fs = new FileStream("studentslist.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] splittedLine = line.Split(',');
                studentslist sl = new studentslist(splittedLine[0], splittedLine[1], splittedLine[2], splittedLine[3], splittedLine[4], splittedLine[5]);
                mystudentlist.Add(sl);
            }
            sr.Close();
            fs.Close();
            showstudents();
        }
     

        private void btnbBack_Click(object sender, EventArgs e)
        {
            main f1 = new main();
            this.Hide();
            f1.ShowDialog();    
            this.Close();
        }
        private void showstudents()
        {
            lblCountt.Text = $"{indexToShow + 1}/{mystudentlist.Count}";


            lblN.Text = mystudentlist[indexToShow].name;
            lblLN.Text = mystudentlist[indexToShow].lastname;
            lblFN.Text = mystudentlist[indexToShow].fathername;
            lblBOD.Text = mystudentlist[indexToShow].birthday;
            lblJD.Text = mystudentlist[indexToShow].joindate;
            lblNATI.Text = mystudentlist[indexToShow].nationality;


            if (indexToShow < 0 || indexToShow >= mystudentlist.Count)
            {
              
                return;
            }

            if (indexToShow >= mystudentlist.Count - 1)
            {
                btnNext.Enabled = false;
            }
            if (indexToShow == 0)

            { btnPrevious.Enabled = false; }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            indexToShow++;
            showstudents();
            btnPrevious.Enabled = true;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            indexToShow--;  
            showstudents();
            btnNext.Enabled = true;
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchNationality = txSearch.Text.Trim();
            List<studentslist> filteredStudents = new List<studentslist>();
            
            if (searchNationality != "")
            {
                foreach (studentslist student in mystudentlist)
                {
                    if (student.nationality.ToLower().Contains(searchNationality.ToLower()))
                    {
                        filteredStudents.Add(student);
                    }
                    
                }
                mystudentlist = filteredStudents;
                


                indexToShow = 0;
                showstudents();
            }
            else
            {
                
                MessageBox.Show("Please enter a nationality to search for.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int lineIndexToDelete = indexToShow;

            List<string> lines = new List<string>();

            using (StreamReader sr = new StreamReader("studentslist.txt"))
            {
                string line;
                int count = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    count++;
                    if (count != lineIndexToDelete + 1)
                    {
                        lines.Add(line);
                    }
                }
            }


            using (FileStream fs = new FileStream("studentslist.txt", FileMode.Create, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                foreach (string updatedLine in lines)
                {
                    sw.WriteLine(updatedLine);
                }
            }


            mystudentlist.RemoveAt(lineIndexToDelete);
            if (indexToShow >= mystudentlist.Count)
            {
                indexToShow = mystudentlist.Count - 1;
            }

            showstudents();

            MessageBox.Show("Line deleted successfully.");
        }



    }
}
    