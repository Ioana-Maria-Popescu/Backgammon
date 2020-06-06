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
            this.pictureBox25 = new System.Windows.Forms.PictureBox();
            this.pictureBox24 = new System.Windows.Forms.PictureBox();
            this.CubePictureBox2 = new System.Windows.Forms.PictureBox();
            this.CubePictureBox1 = new System.Windows.Forms.PictureBox();
            this.BoardPictureBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.rollDice.Location = new System.Drawing.Point(480, 28);
            this.rollDice.Name = "rollDice";
            this.rollDice.Size = new System.Drawing.Size(75, 23);
            this.rollDice.TabIndex = 35;
            this.rollDice.Text = "Roll";
            this.rollDice.UseVisualStyleBackColor = true;
            this.rollDice.Click += new System.EventHandler(this.RollTheDice_click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1138, 211);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(133, 23);
            this.textBox1.TabIndex = 38;
            this.textBox1.Text = "Checkers Player1";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1290, 211);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(133, 23);
            this.textBox2.TabIndex = 39;
            this.textBox2.Text = "Checkers Player2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(745, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 42;
            this.label1.Text = "Sum of cubes";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SumCubesClick);
            // 
            // pictureBox25
            // 
            this.pictureBox25.Location = new System.Drawing.Point(1301, 240);
            this.pictureBox25.Name = "pictureBox25";
            this.pictureBox25.Size = new System.Drawing.Size(100, 423);
            this.pictureBox25.TabIndex = 37;
            this.pictureBox25.TabStop = false;
            // 
            // pictureBox24
            // 
            this.pictureBox24.Location = new System.Drawing.Point(1156, 240);
            this.pictureBox24.Name = "pictureBox24";
            this.pictureBox24.Size = new System.Drawing.Size(100, 423);
            this.pictureBox24.TabIndex = 36;
            this.pictureBox24.TabStop = false;
            // 
            // CubePictureBox2
            // 
            this.CubePictureBox2.Location = new System.Drawing.Point(644, 12);
            this.CubePictureBox2.Name = "CubePictureBox2";
            this.CubePictureBox2.Size = new System.Drawing.Size(68, 61);
            this.CubePictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CubePictureBox2.TabIndex = 34;
            this.CubePictureBox2.TabStop = false;
            this.CubePictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Cube2Click);
            // 
            // CubePictureBox1
            // 
            this.CubePictureBox1.Location = new System.Drawing.Point(561, 12);
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
            this.BoardPictureBox.Size = new System.Drawing.Size(1500, 846);
            this.BoardPictureBox.TabIndex = 0;
            this.BoardPictureBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 43;
            this.label2.Text = "Player";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 881);
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
    }
}

