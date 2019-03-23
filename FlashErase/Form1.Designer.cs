namespace FlashErase
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonSendSync = new System.Windows.Forms.Button();
            this.checkBoxLPC1768 = new System.Windows.Forms.CheckBox();
            this.checkBoxLPC1857 = new System.Windows.Forms.CheckBox();
            this.buttonErase = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(270, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Com Port";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(30, 27);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "P2.7";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(30, 50);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(62, 17);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "RESET";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // buttonConnect
            // 
            this.buttonConnect.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonConnect.Location = new System.Drawing.Point(270, 51);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(121, 23);
            this.buttonConnect.TabIndex = 3;
            this.buttonConnect.Text = "OPEN COM PORT";
            this.buttonConnect.UseVisualStyleBackColor = false;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(30, 146);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(355, 205);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // buttonSendSync
            // 
            this.buttonSendSync.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonSendSync.Location = new System.Drawing.Point(30, 93);
            this.buttonSendSync.Name = "buttonSendSync";
            this.buttonSendSync.Size = new System.Drawing.Size(148, 23);
            this.buttonSendSync.TabIndex = 5;
            this.buttonSendSync.Text = "CONNECT TO TARGET";
            this.buttonSendSync.UseVisualStyleBackColor = false;
            this.buttonSendSync.Click += new System.EventHandler(this.buttonSendSync_Click);
            // 
            // checkBoxLPC1768
            // 
            this.checkBoxLPC1768.AutoSize = true;
            this.checkBoxLPC1768.Location = new System.Drawing.Point(6, 19);
            this.checkBoxLPC1768.Name = "checkBoxLPC1768";
            this.checkBoxLPC1768.Size = new System.Drawing.Size(73, 17);
            this.checkBoxLPC1768.TabIndex = 6;
            this.checkBoxLPC1768.Text = "LPC 1768";
            this.checkBoxLPC1768.UseVisualStyleBackColor = true;
            // 
            // checkBoxLPC1857
            // 
            this.checkBoxLPC1857.AutoSize = true;
            this.checkBoxLPC1857.Location = new System.Drawing.Point(6, 42);
            this.checkBoxLPC1857.Name = "checkBoxLPC1857";
            this.checkBoxLPC1857.Size = new System.Drawing.Size(73, 17);
            this.checkBoxLPC1857.TabIndex = 6;
            this.checkBoxLPC1857.Text = "LPC 1857";
            this.checkBoxLPC1857.UseVisualStyleBackColor = true;
            this.checkBoxLPC1857.CheckedChanged += new System.EventHandler(this.checkBoxLPC1857_CheckedChanged);
            // 
            // buttonErase
            // 
            this.buttonErase.BackColor = System.Drawing.Color.Tomato;
            this.buttonErase.Location = new System.Drawing.Point(184, 93);
            this.buttonErase.Name = "buttonErase";
            this.buttonErase.Size = new System.Drawing.Size(114, 23);
            this.buttonErase.TabIndex = 5;
            this.buttonErase.Text = "ERASE FLASH";
            this.buttonErase.UseVisualStyleBackColor = false;
            this.buttonErase.Click += new System.EventHandler(this.buttonEraseClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxLPC1768);
            this.groupBox1.Controls.Add(this.checkBoxLPC1857);
            this.groupBox1.Location = new System.Drawing.Point(98, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(85, 69);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Chip";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 425);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonErase);
            this.Controls.Add(this.buttonSendSync);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button buttonConnect;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonSendSync;
        private System.Windows.Forms.CheckBox checkBoxLPC1768;
        private System.Windows.Forms.CheckBox checkBoxLPC1857;
        private System.Windows.Forms.Button buttonErase;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

