namespace _07.Sumator
{
    using System;
    using System.Windows.Forms;

    public partial class FormCalculate : Form
    {
        public FormCalculate()
        {
            InitializeComponent();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            try {
            var num1 = decimal.Parse(this.textBox1.Text);
            var num2 = decimal.Parse(this.textBox2.Text);
            var sum = num1 + num2;
            textBoxSum.Text = sum.ToString();
            }
            catch (Exception)
            {
                textBoxSum.Text = "Error!";
            }
        }
    }
}
