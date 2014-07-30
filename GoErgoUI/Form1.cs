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
        unsafe static extern int get_stats(int* blink, int* ambient_alarm, int* posture_alarm, float * percent_ambient, int use_buf);

        [DllImport("GoErgo.dll")]
        unsafe static extern void calibrate();
        [DllImport("GoErgo.dll")]
        static extern int webCamMain();

        static public double phoneAngle;

        void webCamMainWrapper()
        {
            webCamMain();
        }

        public Form1()
        {
            InitializeComponent();
            serialPort1.Open();
            string[] ports = SerialPort.GetPortNames();
        }

        private void processBlink(int blink)
        {
            string imgfile;
            if (blink == 1)
            {
                imgfile = "../../Resources/ClosedEye.jpg";
                blink_cntr++;
            }
            else
            {
                imgfile = "../../Resources/OpenEye.jpg";
            }
            button1.BeginInvoke((MethodInvoker)delegate()
            {
                button1.BackgroundImage = Image.FromFile(imgfile);
            });

            eyeBlinkCounter.BeginInvoke((MethodInvoker)delegate()
            {
                eyeBlinkCounter.Text = String.Format("Blink Counter = " + blink_cntr);
            });

        }

/*
        static int lightMax;
        static int lightMin;
        private void processAmbientLight(float percent_ambient)
        {
            Color color = Color.F

            Form1.DefaultBackColor = new Color()
        }
 */
        /*
        static bool isInitialized = false;
        static int xLocation = 0;
        static int yLocation = 0;
         */

        static int pastPosition = 0;
        void processProximity(int posture_alarm)
        {

            /*
            if (!isInitialized)
            {
                xLocation = laptopPicture.Location.X;
                yLocation = laptopPicture.Location.Y;
                isInitialized = true;
            }
             */

            if (pastPosition == 1 && posture_alarm == 1)
                return;
            if (pastPosition == 0 && posture_alarm == 0)
                return;
            pastPosition = posture_alarm;
            int displacement = 0;
            if(posture_alarm == 1)
                displacement = -100;
            else
                displacement = 100;
            laptopPicture.BeginInvoke((MethodInvoker)delegate()
            {
                int x = laptopPicture.Location.X;
                int y = laptopPicture.Location.Y;

                Point p = new Point(x + displacement, y);
                laptopPicture.Location = p;
            });
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Thread eyeblink = new Thread()
            //MessageBox.Show(ports.ToString());
            
        }

        static int temp_counter = 0;
        static int blink_cntr = 0;
        static int posture_cntr = 0;
        static int ambient_light_cntr = 0;
        unsafe void GetStats()
        {
            while (true)
            {
                Thread.Sleep(500);
                try
                {
                    int blink, ambient_alarm, posture_alarm;
                    float percent_ambient;
                    get_stats(&blink, &ambient_alarm, &posture_alarm, &percent_ambient, 1);
                    processBlink(blink);

                    processProximity(posture_alarm);
//                    processAmbientLight(percent_ambient);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unknown Exception while processing image output");
                }
/*
                try
                {
                    this.label2.BeginInvoke((MethodInvoker)delegate()
                        {
                            int blink, ambient_alarm, posture_alarm;
                            float percent_ambient;
                            get_stats(&blink, &ambient_alarm, &posture_alarm, &percent_ambient, 1);
                            ambient_light_cntr += ambient_alarm;
                            blink_cntr += blink;
                            posture_cntr += posture_alarm;
                            label2.Text = String.Format(temp_counter++ + ":" + blink_cntr + ":" + ambient_light_cntr + ":" + posture_cntr);
                        });
                } catch (Exception ex)
                {
                    break;
                }
 */
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
                        phoneAngle = rotationAngleInt;
                        RotateImg(pictureBack, "../../Resources/back.jpg", (rotationAngleInt - 90.0).ToString());
                    }
                    catch(Exception ex)
                    {
                    }

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

        private void button2_Click(object sender, EventArgs e)
        {
            // Start of Webcam worker thread
            Thread camThread = new Thread(new ThreadStart(webCamMainWrapper));
            camThread.Start();

            // End of WebCam worker thread
            Thread statsThread = new Thread(new ThreadStart(GetStats));
            statsThread.Start();
            statsThread.IsBackground = true;


            Form formwid = new FormWidget();
            formwid.Show();


        }


    }
}
