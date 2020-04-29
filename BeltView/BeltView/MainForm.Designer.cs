namespace BeltView
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
            this.buildButton = new System.Windows.Forms.Button();
            this.lengthTapeTextBox = new System.Windows.Forms.TextBox();
            this.widthTapeTextBox = new System.Windows.Forms.TextBox();
            this.heightTapeTextBox = new System.Windows.Forms.TextBox();
            this.diametrHoleTextBox = new System.Windows.Forms.TextBox();
            this.distanceHoleTextBox = new System.Windows.Forms.TextBox();
            this.lengthBuckleTextBox = new System.Windows.Forms.TextBox();
            this.widthBuckleTextBox = new System.Windows.Forms.TextBox();
            this.diametrTongueBuckleTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buildButton
            // 
            this.buildButton.Location = new System.Drawing.Point(12, 306);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(168, 23);
            this.buildButton.TabIndex = 9;
            this.buildButton.Text = "Построить ремень";
            this.buildButton.UseVisualStyleBackColor = true;
            this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // lengthTapeTextBox
            // 
            this.lengthTapeTextBox.Location = new System.Drawing.Point(80, 45);
            this.lengthTapeTextBox.Name = "lengthTapeTextBox";
            this.lengthTapeTextBox.Size = new System.Drawing.Size(48, 20);
            this.lengthTapeTextBox.TabIndex = 2;
            this.lengthTapeTextBox.Text = "20";
            this.lengthTapeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // widthTapeTextBox
            // 
            this.widthTapeTextBox.Location = new System.Drawing.Point(80, 19);
            this.widthTapeTextBox.Name = "widthTapeTextBox";
            this.widthTapeTextBox.Size = new System.Drawing.Size(48, 20);
            this.widthTapeTextBox.TabIndex = 1;
            this.widthTapeTextBox.Text = "800";
            this.widthTapeTextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.widthTapeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // heightTapeTextBox
            // 
            this.heightTapeTextBox.Location = new System.Drawing.Point(80, 71);
            this.heightTapeTextBox.Name = "heightTapeTextBox";
            this.heightTapeTextBox.Size = new System.Drawing.Size(48, 20);
            this.heightTapeTextBox.TabIndex = 3;
            this.heightTapeTextBox.Text = "4";
            this.heightTapeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // diametrHoleTextBox
            // 
            this.diametrHoleTextBox.Location = new System.Drawing.Point(80, 19);
            this.diametrHoleTextBox.Name = "diametrHoleTextBox";
            this.diametrHoleTextBox.Size = new System.Drawing.Size(48, 20);
            this.diametrHoleTextBox.TabIndex = 4;
            this.diametrHoleTextBox.Text = "4";
            this.diametrHoleTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // distanceHoleTextBox
            // 
            this.distanceHoleTextBox.Location = new System.Drawing.Point(80, 45);
            this.distanceHoleTextBox.Name = "distanceHoleTextBox";
            this.distanceHoleTextBox.Size = new System.Drawing.Size(48, 20);
            this.distanceHoleTextBox.TabIndex = 5;
            this.distanceHoleTextBox.Text = "15";
            this.distanceHoleTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // lengthBuckleTextBox
            // 
            this.lengthBuckleTextBox.Location = new System.Drawing.Point(80, 19);
            this.lengthBuckleTextBox.Name = "lengthBuckleTextBox";
            this.lengthBuckleTextBox.Size = new System.Drawing.Size(48, 20);
            this.lengthBuckleTextBox.TabIndex = 6;
            this.lengthBuckleTextBox.Text = "40";
            this.lengthBuckleTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // widthBuckleTextBox
            // 
            this.widthBuckleTextBox.Location = new System.Drawing.Point(80, 45);
            this.widthBuckleTextBox.Name = "widthBuckleTextBox";
            this.widthBuckleTextBox.Size = new System.Drawing.Size(48, 20);
            this.widthBuckleTextBox.TabIndex = 7;
            this.widthBuckleTextBox.Text = "20";
            this.widthBuckleTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // diametrTongueBuckleTextBox
            // 
            this.diametrTongueBuckleTextBox.Location = new System.Drawing.Point(80, 71);
            this.diametrTongueBuckleTextBox.Name = "diametrTongueBuckleTextBox";
            this.diametrTongueBuckleTextBox.Size = new System.Drawing.Size(48, 20);
            this.diametrTongueBuckleTextBox.TabIndex = 8;
            this.diametrTongueBuckleTextBox.Text = "3";
            this.diametrTongueBuckleTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lengthTapeTextBox);
            this.groupBox1.Controls.Add(this.widthTapeTextBox);
            this.groupBox1.Controls.Add(this.heightTapeTextBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 100);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры ремня";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(134, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "мм";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(134, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "мм";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(134, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "мм";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Длина:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Ширина:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Толщина:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.diametrHoleTextBox);
            this.groupBox2.Controls.Add(this.distanceHoleTextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(168, 73);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры отверстий";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(134, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "мм";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(134, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 13);
            this.label13.TabIndex = 17;
            this.label13.Text = "мм";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Диаметр:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Расстояние:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.lengthBuckleTextBox);
            this.groupBox3.Controls.Add(this.widthBuckleTextBox);
            this.groupBox3.Controls.Add(this.diametrTongueBuckleTextBox);
            this.groupBox3.Location = new System.Drawing.Point(12, 197);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(168, 103);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Параметры бляшки";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(134, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 13);
            this.label14.TabIndex = 18;
            this.label14.Text = "мм";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(134, 48);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 13);
            this.label15.TabIndex = 19;
            this.label15.Text = "мм";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(134, 74);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(23, 13);
            this.label16.TabIndex = 20;
            this.label16.Text = "мм";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Длина:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Ширина:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 26);
            this.label8.TabIndex = 15;
            this.label8.Text = "Диаметр\r\nязычка:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(195, 340);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buildButton);
            this.MaximumSize = new System.Drawing.Size(211, 379);
            this.MinimumSize = new System.Drawing.Size(211, 379);
            this.Name = "MainForm";
            this.Text = "Belt";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buildButton;
        private System.Windows.Forms.TextBox lengthTapeTextBox;
        private System.Windows.Forms.TextBox widthTapeTextBox;
        private System.Windows.Forms.TextBox heightTapeTextBox;
        private System.Windows.Forms.TextBox diametrHoleTextBox;
        private System.Windows.Forms.TextBox distanceHoleTextBox;
        private System.Windows.Forms.TextBox lengthBuckleTextBox;
        private System.Windows.Forms.TextBox widthBuckleTextBox;
        private System.Windows.Forms.TextBox diametrTongueBuckleTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
    }
}

