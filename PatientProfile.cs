using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace New_DAAL
{
    public partial class PatientProfile : Form
    {
        readonly SqlConnection con = new SqlConnection("server = DESKTOP-RQ9TRRH; database = Hsystem; integrated security = true");
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private DataTable dt;
        private string sql;

        public void increment()
        {
            Database.INCREMENT.autoincrement("select max(HID) from HDAAL", hid);
        }

        public void Grid()
        {
            Database.GridView.retriving("select * from HDAAL", PatGV);
        }

        public PatientProfile()
        {
            InitializeComponent();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home H = new Home();
            H.Show();
        }

        private void Guna2Button1_Click(object sender, EventArgs e)
        {
            Database.ADD.add("insert into HDAAL (HID,id, nam, nno, phn, mty, mnam, othermed, pay, otherclinic,rev, dd, nd, note,exdate) values ('"+ hid.Text+ "','" + id.Text + "',N'" + nam.Text + "'," + nno.Text + ",'" + phn.Text + "',N'" + mty.Text + "', N'" + mnam.Text + "', N'" + othermed.Text + "',N'" + pay.Text + "', N'" + otherclinic.Text + "',N'" + rev.Text + "','" + dd.Text + "','" + nd.Text + "', N'" + note.Text + "', '"+ ed.Text +"')");
            Database.CLEAR.clear(this);
            increment();
            Grid();
        }

        private void Guna2Button3_Click(object sender, EventArgs e)
        {
            Database.DELETE.delete("Delete from HDAAL where Id='" + id.Text + "'");
            //increment();
            Grid();
        }

        private void Guna2Button2_Click(object sender, EventArgs e)
        {
            Database.UPDATE.update("Update HDAAL set id='"+ id.Text+ "',nam = N'" + nam.Text + "', nno =" + nno.Text + ", phn = " + phn.Text + ", mty =N'" + mty.Text + "', mnam= N'" + mnam.Text + "', othermed= N'" + othermed.Text + "', pay= N'" + pay.Text + "', otherclinic= N'" + otherclinic.Text + "', rev= N'" + rev.Text + "', dd= '" + dd.Text + "', nd= '" + nd.Text + "', note= N'" + note.Text + "', exdate='"+ed.Text+"' where HID = '" +hid.Text + "'");
            Database.CLEAR.clear(this);
            //increment();
            Grid();
        }

        private void PatientProfile_Load(object sender, EventArgs e)
        {
            //increment();
            Grid();
            sql = " select * from HDAAL";
            SearchData(sql, PatGV);



            kn.Text = dt.Rows.Count.ToString();
            SqlConnection conn = new SqlConnection("Data Source = .; Intial Catalog=mty ; Integrated Secuirty=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select Count(mty) from HDAAL", con);
            var count1 = cmd.ExecuteScalar();
            kn.Text = count1.ToString();
            con.Close();
            

        }

        

        
        private void SearchData(string sql, DataGridView dtg)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                da = new SqlDataAdapter();
                dt = new DataTable();
                {
                    var withBlock = cmd;
                    withBlock.Connection = con;
                    withBlock.CommandText = sql;
                }
                {
                    var withBlock = da;
                    withBlock.SelectCommand = cmd;
                    withBlock.Fill(dt);
                }
                dtg.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                da.Dispose();
            }
        }
        private void Search_TextChanged(object sender, EventArgs e)
        {
            sql = "select * from HDAAL where id like '%" + id.Text + "%' or nam like '%" + Search.Text + "%' or nno like '%" + Search.Text + "%' or phn like '%" + Search.Text + "%' or mty like '%" + Search.Text + "%' or mnam like '%" + Search.Text + "%' or othermed like '%" + Search.Text + "%' or pay like '%" + Search.Text + "%' or otherclinic like '%" + Search.Text + "%' or rev like '%" + Search.Text + "%' or dd like '%" + Search.Text + "%' or nd like '%" + Search.Text + "%' or note like '%" + Search.Text + "%'"; SearchData(sql, PatGV);

        }

        private void PatGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            hid.Text = PatGV.SelectedRows[0].Cells[0].Value.ToString();
            id.Text = PatGV.SelectedRows[0].Cells[1].Value.ToString();
            nam.Text = PatGV.SelectedRows[0].Cells[2].Value.ToString();
            nno.Text = PatGV.SelectedRows[0].Cells[3].Value.ToString();
            phn.Text = PatGV.SelectedRows[0].Cells[4].Value.ToString();
            mty.Text = PatGV.SelectedRows[0].Cells[5].Value.ToString();
            mnam.Text = PatGV.SelectedRows[0].Cells[6].Value.ToString();
            othermed.Text = PatGV.SelectedRows[0].Cells[7].Value.ToString();
            pay.Text = PatGV.SelectedRows[0].Cells[8].Value.ToString();
            otherclinic.Text = PatGV.SelectedRows[0].Cells[9].Value.ToString();
            rev.Text = PatGV.SelectedRows[0].Cells[10].Value.ToString();
            dd.Text = PatGV.SelectedRows[0].Cells[11].Value.ToString();
            nd.Text = PatGV.SelectedRows[0].Cells[12].Value.ToString();
            note.Text = PatGV.SelectedRows[0].Cells[13].Value.ToString();
            ed.Text = PatGV.SelectedRows[0].Cells[14].Value.ToString();
        }

        private void Search_TextChanged_1(object sender, EventArgs e)
        {
            sql = "select * from HDAAL where id like '%" + Search.Text + "%' or nam like '%" + Search.Text + "%' or nno like '%" + Search.Text + "%' or phn like '%" + Search.Text + "%' or mty like '%" + Search.Text + "%' or mnam like '%" + Search.Text + "%' or othermed like '%" + Search.Text + "%' or pay like '%" + Search.Text + "%' or otherclinic like '%" + Search.Text + "%' or rev like '%" + Search.Text + "%' or dd like '%" + Search.Text + "%' or nd like '%" + Search.Text + "%' or note like '%" + Search.Text + "%' and dd like '%" + Search.Text + "%'"; SearchData(sql, PatGV);
            //kn = "Count * from PatientProfile where pay  like 'C'";
            foreach (DataRow dr in dt.Rows)
            {




                if (dt.Rows.Count.ToString() + "  pay: " == dt.Rows.Count.ToString() + "  mty: ")
                {
                    kn.Text = dt.Rows.Count.ToString() + "  pay: ";
                    //kn.Text = dr["nd"].ToString();
                }

            }
        }

        private void Dd_ValueChanged(object sender, EventArgs e)
        {
            dd.Value = DateTime.Today;
        }

        private void One_CheckedChanged(object sender, EventArgs e)
        {
            //DateTimePicker.Value = DateTime.Today.AddDays(+7);
            nd.Value = DateTime.Today.AddDays(+7);
        }

        private void Three_CheckedChanged(object sender, EventArgs e)
        {
            nd.Value = DateTime.Today.AddDays(+21);
        }

        private void Four_CheckedChanged(object sender, EventArgs e)
        {
            nd.Value = DateTime.Today.AddDays(+28);
        }

        private void Twelve_CheckedChanged(object sender, EventArgs e)
        {
            nd.Value = DateTime.Today.AddDays(+84);
        }

        private void Twentyfour_CheckedChanged(object sender, EventArgs e)
        {
            nd.Value = DateTime.Today.AddDays(+168);
        }

        private void Fourtyeight_CheckedChanged(object sender, EventArgs e)
        {
            nd.Value = DateTime.Today.AddDays(+336);
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Id_TextChanged(object sender, EventArgs e)
        {

        }

        private void Nam_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Nno_TextChanged(object sender, EventArgs e)
        {

        }

        private void Phn_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void Mty_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Mnam_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Guna2HtmlLabel30_Click(object sender, EventArgs e)
        {

        }

        private void Guna2HtmlLabel29_Click(object sender, EventArgs e)
        {

        }

        private void Guna2HtmlLabel28_Click(object sender, EventArgs e)
        {

        }

        

        private void Nd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Guna2CustomRadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            ed.Value = DateTime.Today.AddDays(+25);
        }

        private void Guna2CustomRadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            ed.Value = DateTime.Today.AddDays(+35);

        }

        private void Guna2CustomRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ed.Value = DateTime.Today.AddDays(+55);
        }

        private void Guna2CustomRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            ed.Value = DateTime.Today.AddDays(+85);
        }

        private void Guna2CustomRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ed.Value = DateTime.Today.AddDays(+115);
        }

        private void Guna2CustomRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            ed.Value = DateTime.Today.AddDays(+145);
        }

        private void Guna2CustomRadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            ed.Value = DateTime.Today.AddDays(+175);
        }

        private void Guna2HtmlLabel15_Click(object sender, EventArgs e)
        {
            int kn = PatGV.Rows.Count;
            

        }

        private void Guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Guna2HtmlLabel18_Click(object sender, EventArgs e)
        {

        }

        private void Hid_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
