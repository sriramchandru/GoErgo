using System;
using System.Runtime.InteropServices;
using System.Threading;
namespace GoErgoUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.eyeBlinkCounter = new System.Windows.Forms.Label();
            this.laptopPicture = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureFace = new System.Windows.Forms.PictureBox();
            this.pictureLeg = new System.Windows.Forms.PictureBox();
            this.pictureBack = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.laptopPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLeg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBack)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM3";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(800, 776);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Inclination Angle";
            // 
            // eyeBlinkCounter
            // 
            this.eyeBlinkCounter.AutoSize = true;
            this.eyeBlinkCounter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eyeBlinkCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eyeBlinkCounter.Location = new System.Drawing.Point(41, 214);
            this.eyeBlinkCounter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.eyeBlinkCounter.Name = "eyeBlinkCounter";
            this.eyeBlinkCounter.Size = new System.Drawing.Size(0, 25);
            this.eyeBlinkCounter.TabIndex = 5;
            this.eyeBlinkCounter.Click += new System.EventHandler(this.label2_Click);
            // 
            // laptopPicture
            // 
            this.laptopPicture.Image = global::GoErgoUI.Properties.Resources.laptop1;
            this.laptopPicture.Location = new System.Drawing.Point(1095, 321);
            this.laptopPicture.Margin = new System.Windows.Forms.Padding(4);
            this.laptopPicture.Name = "laptopPicture";
            this.laptopPicture.Size = new System.Drawing.Size(189, 230);
            this.laptopPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.laptopPicture.TabIndex = 9;
            this.laptopPicture.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::GoErgoUI.Properties.Resources.OpenEye;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(0, 1);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(235, 186);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pictureFace
            // 
            this.pictureFace.Image = global::GoErgoUI.Properties.Resources.face1;
            this.pictureFace.Location = new System.Drawing.Point(686, 126);
            this.pictureFace.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureFace.Name = "pictureFace";
            this.pictureFace.Size = new System.Drawing.Size(147, 116);
            this.pictureFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureFace.TabIndex = 4;
            this.pictureFace.TabStop = false;
            // 
            // pictureLeg
            // 
            this.pictureLeg.Image = global::GoErgoUI.Properties.Resources.leg1;
            this.pictureLeg.Location = new System.Drawing.Point(731, 689);
            this.pictureLeg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureLeg.Name = "pictureLeg";
            this.pictureLeg.Size = new System.Drawing.Size(309, 65);
            this.pictureLeg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLeg.TabIndex = 3;
            this.pictureLeg.TabStop = false;
            // 
            // pictureBack
            // 
            this.pictureBack.Image = global::GoErgoUI.Properties.Resources.back11;
            this.pictureBack.Location = new System.Drawing.Point(551, 247);
            this.pictureBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBack.Name = "pictureBack";
            this.pictureBack.Size = new System.Drawing.Size(400, 425);
            this.pictureBack.TabIndex = 2;
            this.pictureBack.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1344, 897);
            this.Controls.Add(this.laptopPicture);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.eyeBlinkCounter);
            this.Controls.Add(this.pictureFace);
            this.Controls.Add(this.pictureLeg);
            this.Controls.Add(this.pictureBack);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "GoErGo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.laptopPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLeg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBack;
        private System.Windows.Forms.PictureBox pictureLeg;
        private System.Windows.Forms.PictureBox pictureFace;
        private System.Windows.Forms.Label eyeBlinkCounter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox laptopPicture;
    }
}

