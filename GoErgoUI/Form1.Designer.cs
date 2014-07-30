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
            this.button2 = new System.Windows.Forms.Button();
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
            this.serialPort1.PortName = "COM5";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(475, 628);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Inclination Angle";
            // 
            // eyeBlinkCounter
            // 
            this.eyeBlinkCounter.AutoSize = true;
            this.eyeBlinkCounter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.eyeBlinkCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eyeBlinkCounter.Location = new System.Drawing.Point(12, 139);
            this.eyeBlinkCounter.Name = "eyeBlinkCounter";
            this.eyeBlinkCounter.Size = new System.Drawing.Size(0, 20);
            this.eyeBlinkCounter.TabIndex = 5;
            this.eyeBlinkCounter.Click += new System.EventHandler(this.label2_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(423, 1);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 56);
            this.button2.TabIndex = 6;
            this.button2.Text = "Calibrate";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // laptopPicture
            // 
            this.laptopPicture.Image = global::GoErgoUI.Properties.Resources.laptop;
            this.laptopPicture.Location = new System.Drawing.Point(663, 258);
            this.laptopPicture.Name = "laptopPicture";
            this.laptopPicture.Size = new System.Drawing.Size(142, 187);
            this.laptopPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.laptopPicture.TabIndex = 9;
            this.laptopPicture.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::GoErgoUI.Properties.Resources.OpenEye;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(-2, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 151);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // pictureFace
            // 
            this.pictureFace.Image = global::GoErgoUI.Properties.Resources.face;
            this.pictureFace.Location = new System.Drawing.Point(389, 165);
            this.pictureFace.Margin = new System.Windows.Forms.Padding(2);
            this.pictureFace.Name = "pictureFace";
            this.pictureFace.Size = new System.Drawing.Size(110, 94);
            this.pictureFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureFace.TabIndex = 4;
            this.pictureFace.TabStop = false;
            // 
            // pictureLeg
            // 
            this.pictureLeg.Image = global::GoErgoUI.Properties.Resources.leg;
            this.pictureLeg.Location = new System.Drawing.Point(389, 555);
            this.pictureLeg.Margin = new System.Windows.Forms.Padding(2);
            this.pictureLeg.Name = "pictureLeg";
            this.pictureLeg.Size = new System.Drawing.Size(232, 53);
            this.pictureLeg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLeg.TabIndex = 3;
            this.pictureLeg.TabStop = false;
            // 
            // pictureBack
            // 
            this.pictureBack.Image = global::GoErgoUI.Properties.Resources.back1;
            this.pictureBack.Location = new System.Drawing.Point(289, 258);
            this.pictureBack.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBack.Name = "pictureBack";
            this.pictureBack.Size = new System.Drawing.Size(300, 292);
            this.pictureBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBack.TabIndex = 2;
            this.pictureBack.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.laptopPicture);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.eyeBlinkCounter);
            this.Controls.Add(this.pictureFace);
            this.Controls.Add(this.pictureLeg);
            this.Controls.Add(this.pictureBack);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox laptopPicture;
    }
}

