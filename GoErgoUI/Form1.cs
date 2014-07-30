using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.IO.Ports;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

//using goErgo;


namespace GoErgoUI
{
    public partial class Form1 : Form
    {
        [DllImport("GoErgo.dll")]
        unsafe static extern int get_stats(int* blink, int* ambient_alarm, int* posture_alarm, int use_buf);

        [DllImport("GoErgo.dll")]
        static extern int webCamMain();

        void webCamMainWrapper()
        {
            webCamMain();
        }

        public Form1()
        {
            InitializeComponent();
            // Start of Webcam worker thread
            Thread camThread = new Thread(new ThreadStart(webCamMainWrapper));
            camThread.Start();

            Thread statsThread = new Thread(new ThreadStart(GetStats));
            statsThread.Start();
            statsThread.IsBackground = true;
            // End of WebCam worker thread
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Thread eyeblink = new Thread()
            serialPort1.Open();
            string[] ports = SerialPort.GetPortNames();
            //MessageBox.Show(ports.ToString());
            
        }

        static int temp_counter = 0;
        unsafe void GetStats()
        {
            while (true)
            {
                Thread.Sleep(1000);
                this.label2.BeginInvoke((MethodInvoker)delegate()
                {
                    int blink, ambient_alarm, posture_alarm;
                    get_stats(&blink, &ambient_alarm, &posture_alarm, 1);
                    label2.Text = String.Format(temp_counter++ + ":" + blink + ":" + ambient_alarm + ":" + posture_alarm);
                });
            }

        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
             
            try
            {
                //MessageBox.Show(serialPort1.ReadLine());
                this.label1.BeginInvoke((MethodInvoker) delegate() {
                    double rotationAngleInt =0.0 ;
                    try
                    {
                        string rotationAngle = serialPort1.ReadLine(); ;
                        rotationAngleInt = Convert.ToDouble(rotationAngle);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("NaN in rotation angle. " + ex.Message);
                    }
                    RotateImg(pictureBack, "../../Resources/back.jpg", (rotationAngleInt-90.0).ToString());

                }); 
            }
            catch(Exception ex)
            {
                MessageBox.Show(String.Format("Came here, but something is wrong: " + ex.Message));
            }
        }


        public static void RotateImg(PictureBox pb, String imgFile, string angle)
        {
            Image origimage = Image.FromFile(imgFile);
            Image imgclone;
            imgclone = origimage;
            imgclone = ApplyTransparency((Bitmap)imgclone); //ADDING THIS
            imgclone = (System.Drawing.Image)imgclone.Clone();
            pb.Image = new Bitmap(rotateCenter(imgclone, angle));
            pb.SizeMode = PictureBoxSizeMode.Normal;
            //return 0;
        }

        public static Bitmap ApplyTransparency(Bitmap imagedata)
        {
            Bitmap bmp = imagedata;
            bmp.MakeTransparent(Color.Fuchsia); // (0, 0, 0) is black

            return bmp;
        }

        public static Bitmap rotateCenter(Image b, string angle)
        {
            Bitmap returnBitmap = new Bitmap(b.Width, b.Height + 1);
            Graphics g = Graphics.FromImage(returnBitmap);
            g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
            g.RotateTransform(-float.Parse(angle));
            g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
            g.DrawImage(b, b.Width / 2 - b.Height / 2, b.Height / 2 - b.Width / 2, b.Height, b.Width);

            return returnBitmap;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


    }
}
