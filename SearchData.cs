using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment
{
    public partial class SearchData : Form
    {
        public SearchData()
        {
            InitializeComponent();
        }

        public int dataSearch;

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                dataSearch = Convert.ToInt32(tbxNum.Text);
            }
            catch
            {
                MessageBox.Show("Dữ liệu nhập không hợp lệ!");
                tbxNum.Clear();
                return;
            }
            Close();
        }
    }
}
