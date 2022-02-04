using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeSpendForm.Forms
{
    public partial class frmGetPersonalKey : Form
    {
        public frmGetPersonalKey()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            var key = personalUserKey.Text;
            list.Add(key);

            if (!String.IsNullOrEmpty(key))
            {

                if (!Directory.Exists(@"C:\temp"))
                    Directory.CreateDirectory(@"C:\temp");

                File.WriteAllLines(@"C:\temp\Personalkey.txt", list);
                Form frm = new frmMain(this);
                frm.Show();
                this.Hide();
            }

        }

        private void personalUserKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                this.button1_Click(sender, e);
        }
    }
}
