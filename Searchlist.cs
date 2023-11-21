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
    public partial class Searchlist : Form
    {
        readonly SqlConnection con = new SqlConnection("server = DESKTOP-RQ9TRRH; database = Hsystem; integrated security = true");
        private SqlCommand cmd;
        private SqlDataAdapter da;
        private DataTable dt;
        private string sql;
        //readonly object id;
        //private object hns;
        PrintPreviewDialog prntprvw = new PrintPreviewDialog();
        //PrintDocument pntdoc = new PrintDocument();


        


        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            //e.Graphics.DrawImage(memoryimg, (pagearea.Width / 2) - (this.dtg.Width / 2), this.dtg.Location.Y);
            e.Graphics.DrawString(dtg, new Font());
        }


        //public void Print(Panel pnl)
        //{
        //    PrinterSettings ps = new PrinterSettings();
        //    dtg = pnl;
        //    getprintarea(pnl);
        //    prntprvw.Document = PrintDocument1;
        //    printDocument1.PrintPage += new PrintPageEventHandler(pntdoc_printpage);
        //    getprintarea(pnl);
        //    prntprvw.ShowDialog();
        //}

        Bitmap memoryimg;
        public void getprintarea(Panel pnl)
        {
            memoryimg = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(memoryimg, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }


        public Searchlist()
        {
            InitializeComponent();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home H = new Home();
            H.Show();
        }

        private void Searchlist_Load(object sender, EventArgs e)
        {
            sql = " select * from HDAAL";
            SearchData(sql, dtg);

            count.Text = dt.Rows.Count.ToString();
        }

        private void Search_TextChanged(object sender, EventArgs e)
        {
            sql = "select * from HDAAL where id like '%" + Search.Text + "%' or nam like '%" + Search.Text + "%' or nno like '%" + Search.Text + "%' or phn like '%" + Search.Text + "%' or mty like '%" + Search.Text + "%' or mnam like '%" + Search.Text + "%' or othermed like '%" + Search.Text + "%' or pay like '%" + Search.Text + "%' or otherclinic like '%" + Search.Text + "%' or rev like '%" + Search.Text + "%' or dd like '%" + Search.Text + "%' or nd like '%" + Search.Text + "%' or note like '%" + Search.Text + "%' and dd like '%" + SearchDate.Text + "%'"; SearchData(sql, dtg);

            foreach (DataRow dr in dt.Rows)
            {

                //Search.Text = dr["MedType"].ToString();
                //count.Text = "Avilable Stock is: " + dr["ID"].ToString();
                //count.Visible = true;
                //int count = SGV.Rows.Count;
                count.Text = dt.Rows.Count.ToString() + "   Patient: ";
                count2.Text = dr["dd"].ToString();
            }
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

        private void SearchDate_ValueChanged(object sender, EventArgs e)
        {
            con.Open();
            string query = "select * from HDAAL where dd like '" + SearchDate.Text + "%' or nd like '%" + SearchDate.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            //SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            dtg.DataSource = ds.Tables[0];
            con.Close();
            //if(e.KeyCode == Keys.Enter)
            //{
            //    if (string.IsNullOrEmpty(SearchDate.Text))
            //        WeeklyTableBindingSource .Filter = string.Empty;
            //    else
            //        productBindingSource.Filter = string.Format("{0}='{1}'", Search.Text, SearchDate.Text);
            //}
        }

        private void Count_Click(object sender, EventArgs e)
        {
            int count = dtg.Rows.Count;
            MessageBox.Show("Total Records =" + count);
        }

        private void Count2_Click(object sender, EventArgs e)
        {

        }

        private void Dtg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Guna2Button1_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }
    }
}
