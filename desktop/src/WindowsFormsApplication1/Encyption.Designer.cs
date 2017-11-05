namespace WindowsFormsApplication1
{
    partial class Form_Encyption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Encyption));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox_key = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_rKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_LockEncr = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_fLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-4, -294);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(666, 402);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textBox_key
            // 
            this.textBox_key.BackColor = System.Drawing.Color.Black;
            this.textBox_key.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_key.ForeColor = System.Drawing.Color.LimeGreen;
            this.textBox_key.Location = new System.Drawing.Point(283, 153);
            this.textBox_key.Name = "textBox_key";
            this.textBox_key.PasswordChar = '*';
            this.textBox_key.Size = new System.Drawing.Size(191, 20);
            this.textBox_key.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LimeGreen;
            this.label2.Location = new System.Drawing.Point(159, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Locker Password :";
            // 
            // textBox_rKey
            // 
            this.textBox_rKey.BackColor = System.Drawing.Color.Black;
            this.textBox_rKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_rKey.ForeColor = System.Drawing.Color.LimeGreen;
            this.textBox_rKey.Location = new System.Drawing.Point(283, 190);
            this.textBox_rKey.Name = "textBox_rKey";
            this.textBox_rKey.PasswordChar = '*';
            this.textBox_rKey.Size = new System.Drawing.Size(191, 20);
            this.textBox_rKey.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LimeGreen;
            this.label3.Location = new System.Drawing.Point(137, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Encryption Password :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button_LockEncr
            // 
            this.button_LockEncr.BackColor = System.Drawing.Color.Black;
            this.button_LockEncr.CausesValidation = false;
            this.button_LockEncr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_LockEncr.Location = new System.Drawing.Point(216, 236);
            this.button_LockEncr.Name = "button_LockEncr";
            this.button_LockEncr.Size = new System.Drawing.Size(100, 41);
            this.button_LockEncr.TabIndex = 8;
            this.button_LockEncr.Text = "Lock";
            this.button_LockEncr.UseVisualStyleBackColor = false;
            this.button_LockEncr.Click += new System.EventHandler(this.button_LockEncr_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(522, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 19;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btn_Browse1Click);
            // 
            // textBox_fLocation
            // 
            this.textBox_fLocation.BackColor = System.Drawing.Color.Black;
            this.textBox_fLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_fLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_fLocation.ForeColor = System.Drawing.Color.LimeGreen;
            this.textBox_fLocation.Location = new System.Drawing.Point(180, 111);
            this.textBox_fLocation.Name = "textBox_fLocation";
            this.textBox_fLocation.Size = new System.Drawing.Size(325, 21);
            this.textBox_fLocation.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.LimeGreen;
            this.label4.Location = new System.Drawing.Point(69, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 18);
            this.label4.TabIndex = 17;
            this.label4.Text = "File Location";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(505, 237);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 40);
            this.button2.TabIndex = 33;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(346, 237);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 40);
            this.button3.TabIndex = 34;
            this.button3.Text = "Unlock";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.btn_unlock_click);
            // 
            // Form_Encyption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(657, 316);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_fLocation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_LockEncr);
            this.Controls.Add(this.textBox_rKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_key);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.LimeGreen;
            this.Name = "Form_Encyption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " File Locker - Lock File";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox_key;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_rKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_LockEncr;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_fLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}