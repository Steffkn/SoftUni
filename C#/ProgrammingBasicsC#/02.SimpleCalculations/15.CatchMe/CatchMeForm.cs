using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _15.CatchMe
{
    public partial class CatchMeForm : Form
    {
        public CatchMeForm()
        {
            InitializeComponent();
        }

        private void CatchMeBtn_MouseHover(object sender, EventArgs e)
        {
            Random rand = new Random();
            var maxWidth = this.ClientSize.Width - CatchMeBtn.ClientSize.Width;
            var maxHeight = this.ClientSize.Height - CatchMeBtn.ClientSize.Height;
            this.CatchMeBtn.Location = new Point(
            rand.Next(maxWidth), rand.Next(maxHeight));
        }

        private void CatchMeBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You made it!","Congrats");
        }
    }
}
