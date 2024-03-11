using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentsDataMangment
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            add f2 = new add();
            this.Hide();
            f2.ShowDialog();
            this.Close();   
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            show f3 = new show();
            this.Hide();    
            f3.ShowDialog(); 
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search f4 = new search();
            this.Hide();    
            f4.ShowDialog();    
            this.Close();   
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void main_Load(object sender, EventArgs e)
        {

        }
    }
}
