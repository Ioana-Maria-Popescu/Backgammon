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
            this.CubePictureBox2 = new System.Windows.Forms.PictureBox();
            this.CubePictureBox1 = new System.Windows.Forms.PictureBox();
            this.BoardPictureBox = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.WinnerBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.undoMove = new System.Windows.Forms.Button();
            this.restartGame = new System.Windows.Forms.Button();
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
            this.textBox1.Location = new System.Drawing.Point(1073, 299);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(126, 23);
            this.textBox1.TabIndex = 38;
            this.textBox1.Text = "Checkers Human";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1218, 299);
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
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 42;
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
            this.label3.TextChanged += new System.EventHandler(this.Label3_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(866, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 45;
            this.button1.Text = "Move AI";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.MoveAI_Click);
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
            // WinnerBox
            // 
            this.WinnerBox.Location = new System.Drawing.Point(1129, 34);
            this.WinnerBox.Name = "WinnerBox";
            this.WinnerBox.Size = new System.Drawing.Size(126, 23);
            this.WinnerBox.TabIndex = 53;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1153, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 25);
            this.label10.TabIndex = 54;
            this.label10.Text = "Winner";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(1073, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 230);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Out Pieces";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(1073, 328);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(122, 492);
            this.groupBox2.TabIndex = 58;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(1209, 328);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(122, 492);
            this.groupBox3.TabIndex = 59;
            this.groupBox3.TabStop = false;
            // 
            // undoMove
            // 
            this.undoMove.ForeColor = System.Drawing.Color.Red;
            this.undoMove.Location = new System.Drawing.Point(1344, 28);
            this.undoMove.Name = "undoMove";
            this.undoMove.Size = new System.Drawing.Size(75, 23);
            this.undoMove.TabIndex = 60;
            this.undoMove.Text = "Undo";
            this.undoMove.UseVisualStyleBackColor = true;
            this.undoMove.Click += new System.EventHandler(this.UndoMove_Click);
            // 
            // restartGame
            // 
            this.restartGame.ForeColor = System.Drawing.Color.Black;
            this.restartGame.Location = new System.Drawing.Point(1344, 57);
            this.restartGame.Name = "restartGame";
            this.restartGame.Size = new System.Drawing.Size(75, 23);
            this.restartGame.TabIndex = 61;
            this.restartGame.Text = "Restart";
            this.restartGame.UseVisualStyleBackColor = true;
            this.restartGame.Click += new System.EventHandler(this.RestartGame_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 881);
            this.Controls.Add(this.restartGame);
            this.Controls.Add(this.undoMove);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.WinnerBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.rollDice);
            this.Controls.Add(this.CubePictureBox2);
            this.Controls.Add(this.CubePictureBox1);
            this.Controls.Add(this.BoardPictureBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkGray;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "BACKGAMMON";
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox WinnerBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button undoMove;
        private System.Windows.Forms.Button restartGame;
    }
}

