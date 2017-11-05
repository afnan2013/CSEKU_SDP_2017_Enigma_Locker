namespace WindowsFormsApplication1
{
    partial class form_FileLocker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_FileLocker));
            this.panel_fpage = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label_fl = new System.Windows.Forms.Label();
            this.button_lock = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_fpage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_fpage
            // 
            this.panel_fpage.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel_fpage.Controls.Add(this.button1);
            this.panel_fpage.Controls.Add(this.label_fl);
            this.panel_fpage.Controls.Add(this.button_lock);
            this.panel_fpage.Controls.Add(this.pictureBox1);
            this.panel_fpage.Location = new System.Drawing.Point(-1, -1);
            this.panel_fpage.Name = "panel_fpage";
            this.panel_fpage.Size = new System.Drawing.Size(628, 281);
            this.panel_fpage.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.LimeGreen;
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 33);
            this.button1.TabIndex = 7;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_fl
            // 
            this.label_fl.AutoSize = true;
            this.label_fl.Font = new System.Drawing.Font("Century", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_fl.ForeColor = System.Drawing.Color.LimeGreen;
            this.label_fl.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_fl.Location = new System.Drawing.Point(200, 72);
            this.label_fl.Name = "label_fl";
            this.label_fl.Size = new System.Drawing.Size(226, 44);
            this.label_fl.TabIndex = 6;
            this.label_fl.Text = "File Locker";
            // 
            // button_lock
            // 
            this.button_lock.BackColor = System.Drawing.Color.Black;
            this.button_lock.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_lock.ForeColor = System.Drawing.Color.LimeGreen;
            this.button_lock.Location = new System.Drawing.Point(250, 211);
            this.button_lock.Name = "button_lock";
            this.button_lock.Size = new System.Drawing.Size(127, 45);
            this.button_lock.TabIndex = 4;
            this.button_lock.Text = "Get Started";
            this.button_lock.UseVisualStyleBackColor = false;
            this.button_lock.Click += new System.EventHandler(this.button_lock_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(625, 281);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // form_FileLocker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(624, 279);
            this.Controls.Add(this.panel_fpage);
            this.Name = "form_FileLocker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Locker";
            this.panel_fpage.ResumeLayout(false);
            this.panel_fpage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_fpage;
        private System.Windows.Forms.Label label_fl;
        private System.Windows.Forms.Button button_lock;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
    }
}

