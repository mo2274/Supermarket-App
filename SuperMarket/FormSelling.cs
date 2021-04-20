using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarket
{
    public partial class FormSelling : Form
    {
        public FormSelling()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormSelling_MouseDown(object sender, MouseEventArgs e)
        {
            FrmLogin.ReleaseCapture();
            FrmLogin.SendMessage(this.Handle, FrmLogin.WM_NCLBUTTONDOWN, FrmLogin.HT_CAPTION, 0);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            new FrmLogin().Show();
            this.Close();
        }

        List<Seller> GetSellers()
        {
            using (var db = new Supermarket())
            {
                var sellers = db.Sellers.ToList();
                return sellers;             
            }
        }
        
    }
}
