
namespace CameraApplication
{
    partial class MainForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Capturebtn = new System.Windows.Forms.Button();
            this.Printbtn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Gallery = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(522, 358);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Capturebtn
            // 
            this.Capturebtn.Location = new System.Drawing.Point(185, 405);
            this.Capturebtn.Name = "Capturebtn";
            this.Capturebtn.Size = new System.Drawing.Size(99, 33);
            this.Capturebtn.TabIndex = 1;
            this.Capturebtn.Text = "Capture";
            this.Capturebtn.UseVisualStyleBackColor = true;
            this.Capturebtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Printbtn
            // 
            this.Printbtn.Location = new System.Drawing.Point(784, 405);
            this.Printbtn.Name = "Printbtn";
            this.Printbtn.Size = new System.Drawing.Size(75, 32);
            this.Printbtn.TabIndex = 2;
            this.Printbtn.Text = "Print";
            this.Printbtn.UseVisualStyleBackColor = true;
            this.Printbtn.Click += new System.EventHandler(this.Printbtn_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(149, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(168, 23);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Camera:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(562, 41);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(558, 358);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // Gallery
            // 
            this.Gallery.Location = new System.Drawing.Point(504, 409);
            this.Gallery.Name = "Gallery";
            this.Gallery.Size = new System.Drawing.Size(98, 28);
            this.Gallery.TabIndex = 6;
            this.Gallery.Text = "Gallery";
            this.Gallery.UseVisualStyleBackColor = true;
            this.Gallery.Click += new System.EventHandler(this.Gallery_Click);
            // 
            // CameraFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 454);
            this.Controls.Add(this.Gallery);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Printbtn);
            this.Controls.Add(this.Capturebtn);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CameraFrom";
            this.Text = "Camera";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CameraFrom_FormClosed);
            this.Load += new System.EventHandler(this.CameraFrom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Capturebtn;
        private System.Windows.Forms.Button Printbtn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button Gallery;
    }
}