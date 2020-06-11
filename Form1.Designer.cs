namespace Backgammon
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
            this.rollDice = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox25 = new System.Windows.Forms.PictureBox();
            this.pictureBox24 = new System.Windows.Forms.PictureBox();
            this.CubePictureBox2 = new System.Windows.Forms.PictureBox();
            this.CubePictureBox1 = new System.Windows.Forms.PictureBox();
            this.BoardPictureBox = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CubePictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CubePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoardPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // rollDice
            // 
            this.rollDice.ForeColor = System.Drawing.Color.Black;
            this.rollDice.Location = new System.Drawing.Point(306, 28);
            this.rollDice.Name = "rollDice";
            this.rollDice.Size = new System.Drawing.Size(75, 23);
            this.rollDice.TabIndex = 35;
            this.rollDice.Text = "Roll";
            this.rollDice.UseVisualStyleBackColor = true;
            this.rollDice.Click += new System.EventHandler(this.RollTheDice_click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1073, 322);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(126, 23);
            this.textBox1.TabIndex = 38;
            this.textBox1.Text = "Checkers Human";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1209, 322);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(95, 23);
            this.textBox2.TabIndex = 39;
            this.textBox2.Text = "Checkers AI";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(546, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 42;
            this.label1.Text = "Sum of cubes";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SumCubesClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 43;
            this.label2.Text = "Player";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(727, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 44;
            this.label3.Text = "label3";
            this.label3.TextChanged += new System.EventHandler(this.label3_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(915, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 45;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1108, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 23);
            this.button2.TabIndex = 46;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox25
            // 
            this.pictureBox25.Location = new System.Drawing.Point(1204, 351);
            this.pictureBox25.Name = "pictureBox25";
            this.pictureBox25.Size = new System.Drawing.Size(100, 423);
            this.pictureBox25.TabIndex = 37;
            this.pictureBox25.TabStop = false;
            // 
            // pictureBox24
            // 
            this.pictureBox24.Location = new System.Drawing.Point(1088, 351);
            this.pictureBox24.Name = "pictureBox24";
            this.pictureBox24.Size = new System.Drawing.Size(100, 423);
            this.pictureBox24.TabIndex = 36;
            this.pictureBox24.TabStop = false;
            // 
            // CubePictureBox2
            // 
            this.CubePictureBox2.Location = new System.Drawing.Point(461, 12);
            this.CubePictureBox2.Name = "CubePictureBox2";
            this.CubePictureBox2.Size = new System.Drawing.Size(68, 61);
            this.CubePictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CubePictureBox2.TabIndex = 34;
            this.CubePictureBox2.TabStop = false;
            this.CubePictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Cube2Click);
            // 
            // CubePictureBox1
            // 
            this.CubePictureBox1.Location = new System.Drawing.Point(387, 12);
            this.CubePictureBox1.Name = "CubePictureBox1";
            this.CubePictureBox1.Size = new System.Drawing.Size(68, 61);
            this.CubePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CubePictureBox1.TabIndex = 33;
            this.CubePictureBox1.TabStop = false;
            this.CubePictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Cube1Click);
            // 
            // BoardPictureBox
            // 
            this.BoardPictureBox.Image = global::Backgammon.Properties.Resources.BoardTem;
            this.BoardPictureBox.Location = new System.Drawing.Point(100, 100);
            this.BoardPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.BoardPictureBox.Name = "BoardPictureBox";
            this.BoardPictureBox.Size = new System.Drawing.Size(1235, 720);
            this.BoardPictureBox.TabIndex = 0;
            this.BoardPictureBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(996, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 17);
            this.label4.TabIndex = 47;
            this.label4.Text = "1";
            this.label4.Click += new System.EventHandler(this.GetOnBoardPos1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(924, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 17);
            this.label5.TabIndex = 48;
            this.label5.Text = "2";
            this.label5.Click += new System.EventHandler(this.GetOnBoardPos2);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(845, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 17);
            this.label6.TabIndex = 49;
            this.label6.Text = "3";
            this.label6.Click += new System.EventHandler(this.GetOnBoardPos3);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(772, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 17);
            this.label7.TabIndex = 50;
            this.label7.Text = "4";
            this.label7.Click += new System.EventHandler(this.GetOnBoardPos4);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(698, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 17);
            this.label8.TabIndex = 51;
            this.label8.Text = "5";
            this.label8.Click += new System.EventHandler(this.GetOnBoardPos5);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(621, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 17);
            this.label9.TabIndex = 52;
            this.label9.Text = "6";
            this.label9.Click += new System.EventHandler(this.GetOnBoardPos6);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1151, 60);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 53;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 881);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox25);
            this.Controls.Add(this.pictureBox24);
            this.Controls.Add(this.rollDice);
            this.Controls.Add(this.CubePictureBox2);
            this.Controls.Add(this.CubePictureBox1);
            this.Controls.Add(this.BoardPictureBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkGray;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "BACKGAMMON";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CubePictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CubePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoardPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BoardPictureBox;
        private System.Windows.Forms.PictureBox CubePictureBox1;
        private System.Windows.Forms.PictureBox CubePictureBox2;
        private System.Windows.Forms.Button rollDice;
        private System.Windows.Forms.PictureBox pictureBox24;
        private System.Windows.Forms.PictureBox pictureBox25;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button3;
    }
}

