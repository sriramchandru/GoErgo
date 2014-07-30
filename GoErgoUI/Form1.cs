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

//using goErgo;


namespace GoErgoUI
{
    public partial class Form1 : Form
    {
        private string angle;
        public Form1()
        {
            InitializeComponent();
            angle = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Thread eyeblink = new Thread()
            serialPort1.Open();
            string[] ports = SerialPort.GetPortNames();
            //MessageBox.Show(ports.ToString());
            
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


    }
}
