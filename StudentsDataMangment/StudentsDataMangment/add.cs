using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsDataMangment
{
    public partial class add : Form
    {
        public add()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            main f1= new main();
            this.Hide();
            f1.ShowDialog();    
            this.Close();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txN.Text == "" || txFN.Text == "" || txLN.Text == "" || txBOD.Text == "" || txJD.Text == "" || txNATI.Text == "")
            {
                MessageBox.Show("Error !, fields must not be empty!!");
                return;
            };
            
            FileStream fs = new FileStream("studentslist.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine($"{txN.Text},{txFN.Text},{txLN.Text},{txBOD.Text},{txJD.Text},{txNATI.Text}");

            txN.Clear();
            txFN.Clear();
            txLN.Clear();   
            txBOD.Clear();
            txJD.Clear();
            txNATI.Clear();

            sw.Close();
            fs.Close();
            MessageBox.Show("The student have been added successfully");
           
        }

        private void txBOD_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }
    }
}
