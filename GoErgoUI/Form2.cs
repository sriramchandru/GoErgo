using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoErgoUI
{
    public partial class FormWidget : Form
    {
        public FormWidget()
        {
            InitializeComponent();
            Thread bgThread = new Thread(new ThreadStart(changeColor));
            bgThread.Start();
        }

        void changeColor()
        {
            
            while (true)
            {
                Thread.Sleep(500);
                try
                {
                    this.BeginInvoke((MethodInvoker)delegate()
                    {

                        int red = Convert.ToInt32(Math.Round((Math.Abs(90.0 - Form1.phoneAngle) * 255.0 / 90.0), 0));
                        int green = 255 - red;
                        this.BackColor = Color.FromArgb(red, green, 0);
                    });
                }
                catch (Exception e)
                {

                }
            }
        }
    }
}
