using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backgammon
{
    public partial class Form1 : Form
    {

        int[,] MatrixBoard = new int[12, 12];
        public List<PictureBox> pictureBoxes { get; set; }

        public List<PictureBox> dices { get; set; }
        public Dice DiceRoll { get; set; }

        public int Move = 0;

        public int CoordX, CoordY; 

        public Form1()
        {
            InitializeComponent();
            InitializeComponentsOnBoard();
            Redeseneaza();
        }


        //


        public void Redeseneaza()
        {
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (MatrixBoard[i, j] == 1)
                    {

                        PictureBox pic = new PictureBox();
                        pic.Name = String.Format("pb_{0}_{1}", i, j);
                        pic.Image = Properties.Resources.BlackChecker;
                        pic.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic.Width = 60;
                        pic.Height = 60;
                        pic.Location = new Point(j * 77 + 135, i * 52 + 120);
                        pic.MouseClick += new MouseEventHandler(pic_OnClick);
                        this.Controls.Add(pic);
                        pic.BringToFront();
                    }
                    if (MatrixBoard[i, j] == 2)
                    {

                        PictureBox pic = new PictureBox();
                        pic.Name = String.Format("pb_{0}_{1}", i, j);
                        pic.Image = Properties.Resources.RedChecker;
                        pic.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic.Width = 60;
                        pic.Height = 60;
                        pic.Location = new Point(j * 77 + 135, i * 52 + 120);
                        pic.MouseClick += new MouseEventHandler(pic_OnClick);
                        this.Controls.Add(pic);
                        pic.BringToFront();
                    }

                }
            }
        }
        public void InitializeComponentsOnBoard()
        {
            
            //0-nimic 1-black 2-red
            for(int i = 0; i < 5; i++)
            {
                MatrixBoard[i, 0] = 1;
                MatrixBoard[i, 6] = 2;
            }

            for (int i = 7; i < 12; i++)
            {
                MatrixBoard[i, 0] = 2;
                MatrixBoard[i, 6] = 1;
            }

            MatrixBoard[0, 4] = 2;
            MatrixBoard[1, 4] = 2;
            MatrixBoard[2, 4] = 2;


            MatrixBoard[9, 4] = 1;
            MatrixBoard[10, 4] = 1;
            MatrixBoard[11, 4] = 1;


            MatrixBoard[0, 11] = 1;
            MatrixBoard[1, 11] = 1;

            MatrixBoard[10, 11] = 2;
            MatrixBoard[11, 11] = 2;

        }

        private void RollTheDice_click(object sender, EventArgs e)
        {
            DiceRoll = new Dice();
            DiceRoll.RollDice();
            
            switch (DiceRoll.Cube1)
            {
                case 1: CubePictureBox1.Image = Properties.Resources._1;break;
                case 2: CubePictureBox1.Image = Properties.Resources._2;break;
                case 3: CubePictureBox1.Image = Properties.Resources._3; break;
                case 4: CubePictureBox1.Image = Properties.Resources._4; break;
                case 5: CubePictureBox1.Image = Properties.Resources._5; break;
                case 6: CubePictureBox1.Image = Properties.Resources._6; break;
            }
            switch (DiceRoll.Cube2)
            {
                case 1: CubePictureBox2.Image = Properties.Resources._1; break;
                case 2: CubePictureBox2.Image = Properties.Resources._2; break;
                case 3: CubePictureBox2.Image = Properties.Resources._3; break;
                case 4: CubePictureBox2.Image = Properties.Resources._4; break;
                case 5: CubePictureBox2.Image = Properties.Resources._5; break;
                case 6: CubePictureBox2.Image = Properties.Resources._6; break;
            }
            label1.Text = (DiceRoll.Cube1 + DiceRoll.Cube2).ToString();


        }

        public void DeletePictureBox(int x, int y)
        {
            var name = String.Format("pb_{0}_{1}", x, y);
            foreach (Control c in this.Controls)
            {
                if (c.Name == name)
                {
                    this.Controls.Remove(c);
                    c.Dispose();
                }
            }
            this.Refresh();
        }

        private void Cube1Click(object sender, MouseEventArgs e)
        {
            Move = 1;
        }

        private void Cube2Click(object sender, MouseEventArgs e)
        {
            Move = 2;
        }

        private void SumCubesClick(object sender, MouseEventArgs e)
        {
            Move = 3;
        }

        private void pic_OnClick(object sender, EventArgs e)
        {
            var pb = sender as PictureBox;
            var Coord = pb.Name.Split('_');
            CoordX = Convert.ToInt32(Coord[1]);
            CoordY = Convert.ToInt32(Coord[2]);

            Player playerHuman = new Player("Human", Player.PlayerColor.Black);
            Player playerAI = new Player("AI", Player.PlayerColor.Red);
            playerHuman.isTurn = true;
            playerAI.isTurn = false;
            var x = CoordX;
            var y = CoordY;
            int tempY = y;

            if (playerHuman.Name == "Human" && playerHuman.isTurn == true)
            {
                var a = DiceRoll.Cube1;
                var b = DiceRoll.Cube2;
                MatrixBoard[x, y] = 0;
                var pasi = 0;
                if (Move == 1) { pasi = a; }
                if (Move == 2) { pasi = b; }
                if (Move == 3) { pasi = (a + b); }

                DeletePictureBox(x, y);
                if (x < 6)
                {
                    if (y - pasi >= 0)
                    {
                        y -= pasi;

                        if (MatrixBoard[0, y] == 0) { MatrixBoard[0, y] = 1; }
                        else
                        {
                            int ct = 0;
                            for (int i = 0; i < 6; i++)
                            {
                                if (MatrixBoard[i, y] == 1)
                                {
                                    ct++;
                                }
                                MatrixBoard[x, tempY] = 1;
                            }

                            while (ct != 0)
                            {
                                MatrixBoard[ct, y] = 1;

                                if (MatrixBoard[ct, y] == 1)
                                {
                                    MatrixBoard[x, tempY] = 0;
                                }
                                ct--;
                            }
                        }
                    }
                    else
                    {
                        y = Math.Abs(y - pasi);
                        --y;
                        if (MatrixBoard[11, y] == 0) { MatrixBoard[11, y] = 1; }
                        else
                        {
                            int ct = 0;
                            for (int i = 11; i > 5; i--)
                            {
                                if (MatrixBoard[i, y] == 1)
                                {
                                    ct++;
                                }
                                MatrixBoard[x, tempY] = 1;
                            }

                            while (ct != 0)
                            {
                                MatrixBoard[11 - ct, y] = 1;
                                
                                if(MatrixBoard[11 - ct, y] == 1)
                                {
                                    MatrixBoard[x, tempY] = 0;
                                }
                                ct--;
                            }
                        }
                    }
                }
                else
                {
                    y += pasi;
                    for (int i = 11; i > 5; i--)
                    {
                        if (MatrixBoard[i, y] == 0)
                        {

                            MatrixBoard[i, y] = 1;
                            break;
                        }
                        else
                        MatrixBoard[x, tempY] = 1;
                    }
                }

            }
            Redeseneaza();
            /*
            playerHuman.isTurn = false;
            playerAI.isTurn = true;

            if (playerAI.Name == "AI" && playerAI.isTurn == true)
            {
                var a = DiceRoll.Cube1;
                var b = DiceRoll.Cube2;
                MatrixBoard[x, y] = 0;
                var pasi = 0;
                if (Move == 1) { pasi = a; }
                if (Move == 2) { pasi = b; }
                if (Move == 3) { pasi = (a + b); }

                DeletePictureBox(x, y);
                if (x < 6)
                {
                    if (y - pasi > 0)
                    {
                        y -= pasi;

                        for (int i = 0; i < 6; i++)
                        {
                            if (MatrixBoard[i, y] == 0)
                            {
                                MatrixBoard[i, y] = 2;
                                break;
                            }
                            else
                            {
                                MatrixBoard[x, tempY] = 2;
                            }
                        }
                    }
                    else
                    {
                        y = Math.Abs(y - pasi);
                        for (int i = 11; i > 5; i--)
                        {
                            MatrixBoard[i, y - 1] = 2;
                            break;
                        }
                    }

                }
                else
                {
                    y += pasi;
                    for (int i = 11; i > 5; i--)
                    {
                        if (MatrixBoard[i, y] == 0)
                        {

                            MatrixBoard[i, y] = 2;
                            break;
                        }
                        else
                        {
                            MatrixBoard[x, tempY] = 2;
                        }
                    }
                }

            }
            Redeseneaza();
            */

        }
        
    }


}
