using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_DAAL
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientProfile PP = new PatientProfile();
            PP.Show();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Searchlist SL = new Searchlist();
            SL.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login L = new Login();
            L.Show();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientProfile PP = new PatientProfile();
            PP.Show();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Searchlist SL = new Searchlist();
            SL.Show();
        }
    }
}
