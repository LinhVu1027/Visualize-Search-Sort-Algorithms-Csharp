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
    public partial class FileNew : Form
    {
        public FileNew()
        {
            InitializeComponent();
        }

        public int numOfElement;

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                numOfElement = Convert.ToInt32(tbxNumOfElement.Text);
            }
            catch
            {
                MessageBox.Show("Số phần tử vừa nhập vào không hợp lệ!");
                tbxNumOfElement.Clear();
                return;
            }
            Close();
        }


    }
}
