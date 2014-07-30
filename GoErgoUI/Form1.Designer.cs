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
            this.button1 = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pictureFace = new System.Windows.Forms.PictureBox();
            this.pictureLeg = new System.Windows.Forms.PictureBox();
            this.pictureBack = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLeg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBack)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open Port";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM11";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 509);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Inclination Angle";
            // 
            // pictureFace
            // 
            this.pictureFace.Image = global::GoErgoUI.Properties.Resources.face;
            this.pictureFace.Location = new System.Drawing.Point(197, 46);
            this.pictureFace.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureFace.Name = "pictureFace";
            this.pictureFace.Size = new System.Drawing.Size(110, 94);
            this.pictureFace.TabIndex = 4;
            this.pictureFace.TabStop = false;
            // 
            // pictureLeg
            // 
            this.pictureLeg.Image = global::GoErgoUI.Properties.Resources.leg;
            this.pictureLeg.Location = new System.Drawing.Point(197, 436);
            this.pictureLeg.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureLeg.Name = "pictureLeg";
            this.pictureLeg.Size = new System.Drawing.Size(232, 53);
            this.pictureLeg.TabIndex = 3;
            this.pictureLeg.TabStop = false;
            // 
            // pictureBack
            // 
            this.pictureBack.Image = global::GoErgoUI.Properties.Resources.back1;
            this.pictureBack.Location = new System.Drawing.Point(97, 139);
            this.pictureBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBack.Name = "pictureBack";
            this.pictureBack.Size = new System.Drawing.Size(300, 292);
            this.pictureBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBack.TabIndex = 2;
            this.pictureBack.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(670, 573);
            this.Controls.Add(this.pictureFace);
            this.Controls.Add(this.pictureLeg);
            this.Controls.Add(this.pictureBack);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureFace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLeg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBack;
        private System.Windows.Forms.PictureBox pictureLeg;
        private System.Windows.Forms.PictureBox pictureFace;
    }
}

