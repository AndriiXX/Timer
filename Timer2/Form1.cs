using System;
using System.Windows.Forms;

namespace Timer2
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer vTimer = new System.Windows.Forms.Timer();
        private ErrorProvider errorProvider1 = new ErrorProvider();

        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;


            vTimer.Tick += new EventHandler(ShowTimer);
        }

        private void ShowTimer(object vObject, EventArgs e)
        {

            int remainingSeconds = Decimal.ToInt32(numericUpDown1.Value);
            remainingSeconds--;


            numericUpDown1.Value = Math.Max(remainingSeconds, 0);

            if (remainingSeconds <= 0)
            {

                vTimer.Stop();
                button2.Enabled = false;
                MessageBox.Show("Таймер спрацював!", "Таймер");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            errorProvider1.Clear();


            if (numericUpDown1.Value <= 0)
            {
                errorProvider1.SetError(numericUpDown1, "Кількість секунд має бути більше 0!");
                return;
            }


            if (vTimer.Enabled)
            {
                MessageBox.Show("Таймер вже запущено!");
                return;
            }


            button2.Enabled = true;


            vTimer.Interval = 1000;


            vTimer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            vTimer.Stop();
            MessageBox.Show("Таймер не встиг спрацювати!", "Таймер");
            button2.Enabled = false;
        }

    }
}