using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class progressbar : UserControl
    {
        public int empezar = 1;
        public string user = null;
        public login login;
        public progressbar()
        {
            InitializeComponent();
            /*backgroundWorker1.ProgressChanged+= backgroundWorker1_ProgressChanged;
            backgroundWorker1.DoWork+= backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted+= backgroundWorker1_RunWorkerCompleted;
            backgroundWorker1.RunWorkerAsync();*/
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (0.Equals(empezar))
            {
                if (pgb1.Value < 100)
                {
                    pgb1.Value+=2;
                }
                else
                {
                    timer1.Stop();
                    var form3 = new menu(user);
                    form3.Show();
                    
                    this.Hide();
                    login.Hide();
                }
            }
        }

        private void progressbar_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var form3 = new menu(user);
            form3.Show();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgb1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
