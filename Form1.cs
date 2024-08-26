using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backgammon
{
    public partial class Form1 : Form
    {
        readonly int[,] MatrixBoard = new int[16, 12];
        readonly int[,] OutPiecesMatrix = new int[2, 5];
        List<int> FinalOutPiecesBlack = new List<int>(15);
        List<int> FinalOutPiecesRed = new List<int>(15);

        public Dice DiceRoll { get; set; }

        public int DiceNumber = 0;
        public int MiniScoreDice = 0;

        public int CoordX, CoordY;
        public bool IsDouble;
        public int PositionPieceBackOnBoard = 0;
        public int MaxCheckersOnBoard = 15;
        

        ////////////
        int times = 0;

        Player playerHuman = new Player("Human", Player.PlayerColor.Black);
        Player playerAI = new Player("AI", Player.PlayerColor.Red);

        public Form1()
        {
            InitializeComponent();
            InitializeComponentsOnBoard();
            InitializeComponentsOffBoard();
            playerHuman.isTurn = true;
            label2.Text = "Human";
            label2.Font = new Font("Arial", 30);
            label3.Text = MiniScoreDice.ToString();


            MoveAIButton.FlatStyle = FlatStyle.Flat;
            MoveAIButton.FlatAppearance.BorderColor = BackColor;
            MoveAIButton.FlatAppearance.MouseOverBackColor = BackColor;
            MoveAIButton.FlatAppearance.MouseDownBackColor = BackColor;


            Redraw();
        }

        #region Initialization
        public void InitializeComponentsOnBoard()
        {

            //0-nimic 1-black 2-red
            for (int i = 0; i < (MatrixBoard.GetLength(1) / 2) - 1; i++) 
            {
                MatrixBoard[i, 0] = 1;
                MatrixBoard[i, 6] = 2;
            }

            for (int i = MatrixBoard.GetLength(0) - 5 ; i < MatrixBoard.GetLength(0); i++) 
            {
                MatrixBoard[i, 0] = 2;
                MatrixBoard[i, MatrixBoard.GetLength(1) / 2] = 1;
            }

            MatrixBoard[0, MatrixBoard.GetLength(1) / 3] = 2;
            MatrixBoard[1, MatrixBoard.GetLength(1) / 3] = 2;
            MatrixBoard[2, MatrixBoard.GetLength(1) / 3] = 2;

            MatrixBoard[MatrixBoard.GetLength(0) - 3, MatrixBoard.GetLength(1) / 3] = 1;
            MatrixBoard[MatrixBoard.GetLength(0) - 2, MatrixBoard.GetLength(1) / 3] = 1;
            MatrixBoard[MatrixBoard.GetLength(0) - 1, MatrixBoard.GetLength(1) / 3] = 1;


            MatrixBoard[0, MatrixBoard.GetLength(1) - 1] = 1;
            MatrixBoard[1, MatrixBoard.GetLength(1) - 1] = 1;

            MatrixBoard[MatrixBoard.GetLength(0) - 2, MatrixBoard.GetLength(1) - 1] = 2;
            MatrixBoard[MatrixBoard.GetLength(0) - 1, MatrixBoard.GetLength(1) - 1] = 2;
            /*
            for (int i = 7; i < 12; i++)
            {
                //MatrixBoard[i, 0] = 2;
                MatrixBoard[i, 6] = 1;
            }
            for (int i = 7; i < 12; i++)
            {
               // MatrixBoard[i, 0] = 2;
                MatrixBoard[i, 7] = 1;
            }
            for (int i = 7; i < 12; i++)
            {
                //MatrixBoard[i, 0] = 2;
                MatrixBoard[i, 8] = 1;
            }

            for (int i = 0; i < 5; i++)
            {
                //MatrixBoard[i, 0] = 2;
                MatrixBoard[i, 6] = 2;
                MatrixBoard[i, 7] = 2;
                MatrixBoard[i, 8] = 2;
            }
*/

        }
        public void InitializeComponentsOffBoard()
        {
            for (int i = 0; i < FinalOutPiecesBlack.Capacity; i++)
            {
                FinalOutPiecesBlack.Add(0);
            }
            for (int i = 0; i < FinalOutPiecesRed.Capacity; i++)
            {
                FinalOutPiecesRed.Add(0);
            }
        }
        #endregion
        #region Dices
        private void RollTheDice_click(object sender, EventArgs e)
        {
            DiceRoll = new Dice();
            DiceRoll.RollDice();
            MiniScoreDice = 1;
            label3.Text = MiniScoreDice.ToString();

            switch (DiceRoll.Cube1)
            {
                case 1: CubePictureBox1.Image = Properties.Resources._1; break;
                case 2: CubePictureBox1.Image = Properties.Resources._2; break;
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
            label1.Font = new Font("Arial", 30);
            IsDouble = DiceRoll.IsDouble;
            rollDice.Enabled = false;
        }

        private void Cube1Click(object sender, MouseEventArgs e)
        {
            if (IsDouble == false)
            {
                DiceNumber = 1;
                MiniScoreDice += 2;
                if(e.Clicks != 0)
                {
                    CubePictureBox1.Enabled = false;
                }
                times = 2;
            }
            else
            {
                DiceNumber = 1;
                MiniScoreDice++;
                times = 4;
            }
            label3.Text = MiniScoreDice.ToString();
        }

        private void Cube2Click(object sender, MouseEventArgs e)
        {
            if (IsDouble == false)
            {
                DiceNumber = 2;
                MiniScoreDice += 2;
                if (e.Clicks != 0)
                {
                    CubePictureBox2.Enabled = false;
                }
                times = 2;
            }
            else
            {
                DiceNumber = 2;
                MiniScoreDice++;
                times = 4;
            }
            label3.Text = MiniScoreDice.ToString();
        }

        private void SumCubesClick(object sender, MouseEventArgs e)
        {
            if (IsDouble == false)
            {
                DiceNumber = 3;
                MiniScoreDice += 4;
                if (e.Clicks != 0)
                {
                    label1.Enabled = false;
                }
                times = 1;
            }
            else
            {
                DiceNumber = 3;
                MiniScoreDice += 2;
                times = 2;
            }
            
            label3.Text = MiniScoreDice.ToString();
        }

        #endregion
        #region Game 
        public void Redraw()
        {
            for (int i = 0; i < MatrixBoard.GetLength(0); i++)
            {
                for (int j = 0; j < MatrixBoard.GetLength(1); j++)
                {
                    if (MatrixBoard[i, j] == 1)
                    {
                        PictureBox pic = new PictureBox
                        {
                            Name = String.Format("pb_{0}_{1}", i, j),
                            Image = Properties.Resources.BlackChecker,
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Width = 60,
                            Height = 60,
                            Location = new Point(j * 77 + 135, i * 52 + 120)
                        };
                        pic.MouseClick += new MouseEventHandler(Pic_OnClickBlack);
                        this.Controls.Add(pic);
                        pic.BringToFront();
                    }

                    if (MatrixBoard[i, j] == 2)
                    {
                        PictureBox pic = new PictureBox
                        {
                            Name = String.Format("pb_{0}_{1}", i, j),
                            Image = Properties.Resources.RedChecker,
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Width = 60,
                            Height = 60,
                            Location = new Point(j * 77 + 135, i * 52 + 120)
                        };
                        this.Controls.Add(pic);
                        pic.BringToFront();
                    }
                }
            }

            for (int i = 0; i < OutPiecesMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < OutPiecesMatrix.GetLength(1); j++)
                {
                    if (OutPiecesMatrix[i, j] == 1)
                    {
                        PictureBox outPic = new PictureBox
                        {
                            Name = String.Format("outpb_{0}_{1}", i, j),
                            Image = Properties.Resources.BlackChecker,
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Width = 60,
                            Height = 60,
                            Location = new Point(j * 50 + 1100, i * 52 + 100)
                        };
                        outPic.MouseClick += new MouseEventHandler(OutPics_OnClickBlack);
                        this.Controls.Add(outPic);
                        outPic.BringToFront();
                    }

                    if (OutPiecesMatrix[i, j] == 2)
                    {
                        PictureBox outPic = new PictureBox
                        {
                            Name = String.Format("outpb_{0}_{1}", i, j),
                            Image = Properties.Resources.RedChecker,
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Width = 60,
                            Height = 60,
                            Location = new Point(j * 50 + 1100, i * 52 + 100)
                        };
                        this.Controls.Add(outPic);
                        outPic.BringToFront();
                    }
                }
            }


            for (int j = 0; j < FinalOutPiecesBlack.Capacity; j++)
            {
                if (FinalOutPiecesBlack[j] == 1)
                {
                    PictureBox pic = new PictureBox
                    {
                        Name = String.Format("finalpb_{0}",j),
                        Image = Properties.Resources.BlackChecker,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Width = 60,
                        Height = 60,
                        Location = new Point(0 * 30 + 1100, j * 30 + 350)
                    };
                    this.Controls.Add(pic);
                    pic.BringToFront();
                }
            }

            for (int j = 0; j < FinalOutPiecesRed.Capacity; j++)
            {
                if (FinalOutPiecesRed[j] == 2)
                {
                    PictureBox pic = new PictureBox
                    {
                        Name = String.Format("finalpb_{0}", j),
                        Image = Properties.Resources.RedChecker,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Width = 60,
                        Height = 60,
                        Location = new Point(5 * 30 + 1100, j * 30 + 350)
                    };
                    this.Controls.Add(pic);
                    pic.BringToFront();
                }
            }
        }
        
        private void Label3_TextChanged(object sender, EventArgs e)
        {
            if (MiniScoreDice == 5)
            {
                rollDice.Enabled = true;
            }
        }

        #endregion
        #region Checkers Control
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

        public void DeletePictureBoxOut(int x, int y)
        {

            var name = String.Format("outpb_{0}_{1}", x, y);
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

        public void DeletePictureBoxFinal(int j)
        {
            var name = String.Format("finalpb_{0}", j);
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

        #endregion
        #region Human Player Controls

        private void Pic_OnClickBlack(object sender, EventArgs e)
        {
            var pb = sender as PictureBox;
            var Coord = pb.Name.Split('_');
            CoordX = Convert.ToInt32(Coord[1]);
            CoordY = Convert.ToInt32(Coord[2]);

            var x = CoordX;
            var y = CoordY;
            int tempY = y;

            if (playerHuman.isTurn == true)
            {
                if (OutPiecesMatrix[0, 0] == 0)
                {
                    if (times != 0)
                    {
                        try
                        {
                            var a = DiceRoll.Cube1;
                            var b = DiceRoll.Cube2;
                            MatrixBoard[x, y] = 0;
                            var pasi = 0;
                            switch (DiceNumber)
                            {
                                case 1:
                                    {
                                        pasi = a;
                                        break;
                                    }
                                case 2:
                                    {
                                        pasi = b;
                                        break;
                                    }
                                case 3:
                                    {
                                        pasi = a + b;
                                        break;
                                    }
                                default:
                                    {
                                        MessageBox.Show("Choose a dice");
                                        return;
                                    }
                            }

                            if (CheckUpperCheckers(x, y) == false)
                            {
                                DeletePictureBox(x, y);
                                if (x < MatrixBoard.GetLength(0) / 2)
                                {
                                    if (y - pasi >= 0)
                                    {
                                        y -= pasi;
                                        if (MatrixBoard[0, y] == 2 && MatrixBoard[1, y] == 0)
                                        {
                                            MoveThePieceToMatrix(0, y);
                                            MatrixBoard[0, y] = 1;
                                            Redraw();

                                        }
                                        else
                                        {
                                            if (MatrixBoard[0, y] == 0) { MatrixBoard[0, y] = 1; }
                                            else
                                            {
                                                int ct = 0;
                                                for (int i = 0; i < MatrixBoard.GetLength(0) / 2; i++)
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
                                    }
                                    else
                                    {
                                        y = Math.Abs(y - pasi) - 1;
                                        if (MatrixBoard[MatrixBoard.GetLength(0) - 1, y] == 2 && MatrixBoard[MatrixBoard.GetLength(0) - 2, y] == 0)
                                        {
                                            MoveThePieceToMatrix(MatrixBoard.GetLength(0) - 1, y);
                                            MatrixBoard[MatrixBoard.GetLength(0) - 1, y] = 1;
                                            Redraw();

                                        }
                                        else
                                        {
                                            if (MatrixBoard[MatrixBoard.GetLength(0) - 1, y] == 0) { MatrixBoard[MatrixBoard.GetLength(0) - 1, y] = 1; }
                                            else
                                            {
                                                int ct = 0;


                                                if (MatrixBoard[MatrixBoard.GetLength(0) - 1, y] == 2 && MatrixBoard[MatrixBoard.GetLength(0) - 2, y] == 2)
                                                {
                                                    MatrixBoard[x, tempY] = 1;
                                                    if (IsDouble == true)
                                                    {
                                                        MiniScoreDice--;
                                                    }
                                                    else MiniScoreDice -= 2;
                                                    label3.Text = MiniScoreDice.ToString();
                                                }


                                                for (int i = MatrixBoard.GetLength(0) - 1; i > (MatrixBoard.GetLength(0) / 2) - 1; i--)
                                                //for (int i = 11; i > 5; i--)
                                                {
                                                    if (MatrixBoard[i, y] == 1)
                                                    {
                                                        ct++;
                                                    }
                                                    MatrixBoard[x, tempY] = 1;
                                                }

                                                while (ct != 0)
                                                {
                                                    MatrixBoard[MatrixBoard.GetLength(0) - 1 - ct, y] = 1;

                                                    if (MatrixBoard[MatrixBoard.GetLength(0) - 1 - ct, y] == 1)
                                                    {
                                                        MatrixBoard[x, tempY] = 0;
                                                    }
                                                    ct--;
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (y + pasi < MatrixBoard.GetLength(1))
                                    {
                                        y += pasi;
                                        if (MatrixBoard[MatrixBoard.GetLength(0) - 1, y] == 2 && MatrixBoard[MatrixBoard.GetLength(0) - 2, y] == 0)
                                        {
                                            MoveThePieceToMatrix(MatrixBoard.GetLength(0) - 1, y);
                                            MatrixBoard[MatrixBoard.GetLength(0) - 1, y] = 1;
                                            Redraw();

                                        }
                                        else
                                        {
                                            if (MatrixBoard[MatrixBoard.GetLength(0) - 1, y] == 0) { MatrixBoard[MatrixBoard.GetLength(0) - 1, y] = 1; }
                                            else
                                            {
                                                int ct = 0;
                                                //if(MatrixBoard[11,y]==2 && MatrixBoard[10, y] == 2)
                                                //{
                                                //    MatrixBoard[x, tempY] = 1;
                                                //    if (IsDouble == true)
                                                //    {
                                                //        MiniScoreDice--;
                                                //    }
                                                //    else MiniScoreDice -= 2;
                                                //}


                                                for (int i = MatrixBoard.GetLength(0) - 1; i > (MatrixBoard.GetLength(0) / 2) - 1; i--)
                                                //for (int i = 11; i > 5; i--)
                                                {
                                                    if (MatrixBoard[i, y] == 1)
                                                    {
                                                        ct++;
                                                    }
                                                    MatrixBoard[x, tempY] = 1;
                                                }

                                                while (ct != 0)
                                                {
                                                    MatrixBoard[MatrixBoard.GetLength(0) - 1 - ct, y] = 1;

                                                    if (MatrixBoard[MatrixBoard.GetLength(0) - 1 - ct, y] == 1)
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
                                        if (CheckDoneBlack() == true)
                                        {
                                            MoveCheckerToFinalMatrix(true, y, pasi);
                                        }
                                        else MatrixBoard[x, y] = 1;
                                    }
                                }
                            }
                            else
                            {
                                MatrixBoard[x, y] = 1;
                                //if (IsDouble == true) MiniScoreDice--;
                                //else MiniScoreDice -= 2;
                                label3.Text = MiniScoreDice.ToString();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Roll the dice");
                        }
                        times--;
                    }
                }
                else
                {
                    MiniScoreDice = 5;
                }
            }
            Redraw();
            
            if (MiniScoreDice == 5)
            {
                int p = 1;
                SwitchPlayer(p);
            }
            Winner(AreThereAnyBlackPiecesOnTheBoard(), AreThereAnyRedPiecesOnTheBoard());
        }

        private bool CheckUpperCheckers(int x, int y)
        {
            int ct = 0;
            if (x < MatrixBoard.GetLength(0) / 2)
            {
                for (int i = 0; i < MatrixBoard.GetLength(1) / 2; i++) 
                //for (int i = 0; i < 6; i++)
                {
                    if (MatrixBoard[i, y] == 1)
                    {
                        ct++;
                    }
                }
                if (x == ct) return false;
                else return true;
            }
            else
            {
                for (int i = MatrixBoard.GetLength(0) - 1; i > MatrixBoard.GetLength(1) / 2; i--) 
                //for (int i = 11; i > 6; i--)
                {
                    if (MatrixBoard[i, y] == 1)
                    {
                        ct++;
                    }
                }
                if (x == MatrixBoard.GetLength(0) - 1 - ct) return false;
                else return true;
            }
        }

        private bool CheckDoneBlack()
        {
            int ctCheckersOut = 0;
            for (int i = 0; i < FinalOutPiecesBlack.Capacity; i++)
            {
                if (FinalOutPiecesBlack[i] == 1) { ctCheckersOut++; }
            }
            if (ctCheckersOut > 0) return true;
            int ct = 0;

            for (int i = MatrixBoard.GetLength(0) / 2; i < MatrixBoard.GetLength(0); i++) 
            //for (int i = 6; i <= 11; i++)
            //for (int i = 6; i < 12; i++)
            {
                for (int j = MatrixBoard.GetLength(1) / 2; j < MatrixBoard.GetLength(1); j++) 
                //for (int j = 6; j <= 11; j++)
                //for (int j = 6; j < 12; j++)
                {
                    if (MatrixBoard[i, j] == 1)
                    {
                        ct++;
                    }
                }
            }
            if (ct + 1 == MaxCheckersOnBoard) { return true; }
            return false;
        }

        private void GetOnBoardPos1(object sender, EventArgs e)
        {
            PositionPieceBackOnBoard = 1;
        }

        private void GetOnBoardPos2(object sender, EventArgs e)
        {
            PositionPieceBackOnBoard = 2;
        }

        private void GetOnBoardPos3(object sender, EventArgs e)
        {
            PositionPieceBackOnBoard = 3;
        }

        private void GetOnBoardPos4(object sender, EventArgs e)
        {
            PositionPieceBackOnBoard = 4;
        }

        private void GetOnBoardPos5(object sender, EventArgs e)
        {
            PositionPieceBackOnBoard = 5;
        }

        private void GetOnBoardPos6(object sender, EventArgs e)
        {
            PositionPieceBackOnBoard = 6;
        }

        private void OutPics_OnClickBlack(object sender, MouseEventArgs e)
        {
            var pb = sender as PictureBox;
            var Coord = pb.Name.Split('_');
            CoordX = Convert.ToInt32(Coord[1]);
            CoordY = Convert.ToInt32(Coord[2]);

            var x = CoordX;
            var y = CoordY;

            var a = DiceRoll.Cube1;
            var b = DiceRoll.Cube2;

            if (OutPiecesMatrix[0, 0] != 0)
            {
                DeletePictureBoxOut(x, y);
                if (a == PositionPieceBackOnBoard)
                {
                    InsertChecker(x, y, a);
                }
                else if (b == PositionPieceBackOnBoard) { InsertChecker(x, y, b); }
            }
        }

        public void InsertChecker(int x, int y, int zar)
        {
            if (MatrixBoard[0, MatrixBoard.GetLength(1) - zar] == 2 && MatrixBoard[1, MatrixBoard.GetLength(1) - zar] == 2) { OutPiecesMatrix[x, y] = 1; return; }
            if (MatrixBoard[0, MatrixBoard.GetLength(1) - zar] == 2 && MatrixBoard[1, 12 - zar] == 0)
            {
                MoveThePieceToMatrix(0, MatrixBoard.GetLength(1) - zar);
                MatrixBoard[0, MatrixBoard.GetLength(1) - zar] = 1;
                OutPiecesMatrix[x, y] = 0;
                DeletePictureBoxOut(x, y);
                Redraw();
                return;
            }

            if (MatrixBoard[0, MatrixBoard.GetLength(1) - zar] == 0)
            {
                MatrixBoard[0, MatrixBoard.GetLength(1) - zar] = 1;
                OutPiecesMatrix[x, y] = 0;
                DeletePictureBoxOut(x, y);
                Redraw();
                return;
            }

            else
            {
                int ct = 0;
                for (int i = 0; i < MatrixBoard.GetLength(1) / 2; i++)
                {
                    if (MatrixBoard[i, MatrixBoard.GetLength(1) - zar] == 1)
                    {
                        ct++;
                    }
                }
                MatrixBoard[ct, MatrixBoard.GetLength(1) - zar] = 1;
                OutPiecesMatrix[x, y] = 0;
                DeletePictureBoxOut(x, y);
                Redraw();
                return;
            }
        }

        private bool AreThereAnyBlackPiecesOnTheBoard()
        {
            int ct = 0;
            for (int i = MatrixBoard.GetLength(0) / 2; i < MatrixBoard.GetLength(0); i++)
            //for (int i = 6; i <= 11; i++)
            //for (int i = 6; i < 12; i++)
            {
                for (int j = MatrixBoard.GetLength(1) / 2; j < MatrixBoard.GetLength(1); j++) 
                //for (int j = 6; j <= 11; j++)
                //for (int j = 6; j < 12; j++)
                {
                    if (MatrixBoard[i, j] == 1)
                    {
                        ct++;
                    }
                }
            }
            if (ct > 0) return true;
            else return false;
        }
        #endregion
        #region AI Player Controls

        public void InsertRedChecker(int pos, int zar)
        {
            //if (MatrixBoard[11, 12 - zar] == 1 && MatrixBoard[10, 12 - zar] == 1) { OutPiecesMatrix[1, pos] = 2; }
            //if (MatrixBoard[11, 12 - zar] == 1 && MatrixBoard[10, 12 - zar] == 0)
            //{
            //    MoveThePieceToMatrix(11, 12 - zar);
            //    MatrixBoard[11, 12 - zar] = 2;
            //    DeletePictureBoxOut(1, pos);
            //    OutPiecesMatrix[1, pos] = 0;

            //}
            //if (MatrixBoard[11, 12 - zar] == 0)
            //{
            //    MatrixBoard[11, 12 - zar] = 2;
            //    DeletePictureBoxOut(1, pos);
            //    OutPiecesMatrix[1, pos] = 0;
            //}
            //else
            //{
            //    int ct = 0;
            //    for (int i = 11; i > 5; i--)
            //    {
            //        if (MatrixBoard[i, 12 - zar] == 2)
            //        {
            //            ct++;
            //        }
            //    }
            //    MatrixBoard[ct, 12 - zar] = 2;
            //    DeletePictureBoxOut(1, pos);
            //    OutPiecesMatrix[1, pos] = 0;
            //}
            //Redraw();


            Redraw();
            if (MatrixBoard[MatrixBoard.GetLength(0) - 1, MatrixBoard.GetLength(1) - zar] == 1 && MatrixBoard[MatrixBoard.GetLength(0) - 2, MatrixBoard.GetLength(1) - zar] == 1)
            {
                OutPiecesMatrix[1, pos] = 2;
            }
            else
            {
                if (MatrixBoard[MatrixBoard.GetLength(0) - 1, MatrixBoard.GetLength(1) - zar] == 1 && MatrixBoard[MatrixBoard.GetLength(0) - 2, MatrixBoard.GetLength(1) - zar] == 0)
                {
                    MoveThePieceToMatrix(MatrixBoard.GetLength(0) - 1, MatrixBoard.GetLength(1) - zar);
                    MatrixBoard[MatrixBoard.GetLength(0) - 1, MatrixBoard.GetLength(1) - zar] = 2;
                    DeletePictureBoxOut(1, pos);
                    OutPiecesMatrix[1, pos] = 0;

                }
                else
                {
                    if (MatrixBoard[MatrixBoard.GetLength(0) - 1, MatrixBoard.GetLength(1) - zar] == 0)
                    {
                        MatrixBoard[MatrixBoard.GetLength(0) - 1, MatrixBoard.GetLength(1) - zar] = 2;
                        DeletePictureBoxOut(1, pos);
                        OutPiecesMatrix[1, pos] = 0;
                    }
                    else
                    {
                        int ct = 0;
                        for (int i = MatrixBoard.GetLength(0) - 1; i > (MatrixBoard.GetLength(0) / 2) + 1; i--) 
                        //for (int i = 11; i > 5; i--)
                        {
                            if (MatrixBoard[i, MatrixBoard.GetLength(1) - zar] == 2)
                            {
                                ct++;
                            }
                        }
                        MatrixBoard[MatrixBoard.GetLength(0) - 1 - ct, MatrixBoard.GetLength(1) - zar] = 2;
                        DeletePictureBoxOut(1, pos);
                        OutPiecesMatrix[1, pos] = 0;
                    }
                }
                
            }
            Redraw();
        }

        private void MoveAI_Click(object sender, EventArgs e)
        {

            //var temp = RandomRedChecker();
            //var x = temp.X;
            //var y = temp.Y;

            ////
            int[] temp = RandomRedChecker();
            var x = temp[0];
            var y = temp[1];
            ////

            int tempY = y;

            if (playerAI.isTurn == true)
            {
                var a = DiceRoll.Cube1;
                var b = DiceRoll.Cube2;
                MatrixBoard[x, y] = 0;
                var pasi = 0;
                if (MiniScoreDice == 1)
                {
                    Random random = new Random();
                    DiceNumber = random.Next(1, 3);
                }
                /*
                if (Moves == 1) { pasi = a; MiniScoreDice++; Moves = 2; }
                else if (Moves == 2) { pasi = b; MiniScoreDice++; Moves = 1; }
                else if (Moves == 3) { pasi = (a + b); MiniScoreDice += 2; }
                */

                /*
                if (DiceNumber == 1)
                {
                    if (IsDouble == false)
                    {
                        pasi = a;
                        MiniScoreDice += 2;
                        DiceNumber = 2;
                    }
                    else
                    {
                        pasi = a;
                        MiniScoreDice++;
                        DiceNumber = 1;
                    }
                }
                else if (DiceNumber == 2)
                {
                    if (IsDouble == false)
                    {
                        pasi = b;
                        MiniScoreDice += 2;
                        DiceNumber = 1;
                    }
                    else
                    {
                        pasi = b;
                        MiniScoreDice++;
                        DiceNumber = 2;
                    }
                }
                else if (DiceNumber == 3)
                {
                    if (IsDouble == false)
                    {
                        pasi = (a + b);
                        MiniScoreDice += 4;
                    }
                    else
                    {
                        pasi = (a + b);
                        MiniScoreDice += 2;
                        DiceNumber = 3;
                    }
                }
                */

                if (DiceNumber == 1)
                {
                    if (IsDouble == false)
                    {
                        pasi = a;
                        MiniScoreDice += 2;
                        DiceNumber = 2;
                    }
                    else
                    {
                        pasi = a;
                        MiniScoreDice++;
                        DiceNumber = 1;
                    }
                }
                else
                {
                    if (DiceNumber == 2)
                    {
                        if (IsDouble == false)
                        {
                            pasi = b;
                            MiniScoreDice += 2;
                            DiceNumber = 1;
                        }
                        else
                        {
                            pasi = b;
                            MiniScoreDice++;
                            DiceNumber = 2;
                        }
                    }
                    else
                    {
                        if (DiceNumber == 3)
                        {
                            if (IsDouble == false)
                            {
                                pasi = (a + b);
                                MiniScoreDice += 4;
                            }
                            else
                            {
                                pasi = (a + b);
                                MiniScoreDice += 2;
                                DiceNumber = 3;
                            }
                        }
                    }
                }
                label3.Text = MiniScoreDice.ToString();

                ///
                Redraw();

                //DeletePictureBox(x, y);
                if (OutPiecesMatrix[1, 0] == 0)
                {
                    DeletePictureBox(x, y);
                    if (x > MatrixBoard.GetLength(0) / 2)
                    {
                        if (y - pasi >= 0)
                        {
                            y -= pasi;

                            if (MatrixBoard[MatrixBoard.GetLength(0) - 1, y] == 1 && MatrixBoard[MatrixBoard.GetLength(0) - 2, y] == 0)
                            {
                                MoveThePieceToMatrix(MatrixBoard.GetLength(0) - 1, y);
                                MatrixBoard[MatrixBoard.GetLength(0) - 1, y] = 2;
                                Redraw();

                            }
                            else
                            {
                                if (MatrixBoard[MatrixBoard.GetLength(0) - 1, y] == 1 && MatrixBoard[MatrixBoard.GetLength(0) - 2, y] == 1)
                                {
                                    MatrixBoard[x, tempY] = 2;
                                    if (IsDouble == true)
                                    {
                                        MiniScoreDice--;
                                    }
                                    else MiniScoreDice -= 2;
                                    label3.Text = MiniScoreDice.ToString();
                                }
                                else
                                {
                                    if (MatrixBoard[MatrixBoard.GetLength(0) - 1, y] == 0) { MatrixBoard[MatrixBoard.GetLength(0) - 1, y] = 2; }
                                    else
                                    {
                                        int ct = 0;
                                        for (int i = MatrixBoard.GetLength(0) - 1; i > (MatrixBoard.GetLength(0) / 2) - 1; i--) 
                                        //for (int i = 11; i > 5; i--)
                                        {
                                            if (MatrixBoard[i, y] == 2)
                                            {
                                                ct++;
                                            }
                                        }

                                        while (ct != 0)
                                        {
                                            MatrixBoard[MatrixBoard.GetLength(0) - 1 - ct, y] = 2;

                                            if (MatrixBoard[MatrixBoard.GetLength(0) - 1 - ct, y] == 2)
                                            {
                                                MatrixBoard[x, tempY] = 0;
                                            }
                                            ct--;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            y = Math.Abs(y - pasi) - 1;
                            if (MatrixBoard[0, y] == 1 && MatrixBoard[1, y] == 0)
                            {
                                MoveThePieceToMatrix(0, y);
                                MatrixBoard[0, y] = 2;
                                Redraw();
                            }
                            else
                            {
                                if (MatrixBoard[0, y] == 1 && MatrixBoard[1, y] == 1)
                                {
                                    MatrixBoard[x, tempY] = 2;
                                    if (IsDouble == true)
                                    {
                                        MiniScoreDice--;
                                    }
                                    else MiniScoreDice -= 2;
                                    label3.Text = MiniScoreDice.ToString();
                                }
                                else
                                {
                                    if (MatrixBoard[0, y] == 0) { MatrixBoard[0, y] = 2; }
                                    else
                                    {
                                        int ct = 0;
                                        for (int i = 0; i < MatrixBoard.GetLength(0) / 2; i++) 
                                        //for (int i = 0; i < 6; i++)
                                        {
                                            if (MatrixBoard[i, y] == 2)
                                            {
                                                ct++;
                                            }
                                        }

                                        while (ct != 0)
                                        {
                                            MatrixBoard[ct, y] = 2;

                                            if (MatrixBoard[ct, y] == 2)
                                            {
                                                MatrixBoard[x, tempY] = 0;
                                            }
                                            ct--;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        y += pasi;
                        if (y < MatrixBoard.GetLength(1))
                        {
                            if (MatrixBoard[0, y] == 1 && MatrixBoard[1, y] == 0)
                            {
                                MoveThePieceToMatrix(0, y);
                                MatrixBoard[0, y] = 2;
                                Redraw();
                            }
                            else
                            {
                                if (MatrixBoard[0, y] == 1 && MatrixBoard[1, y] == 1)
                                {
                                    MatrixBoard[x, tempY] = 2;
                                    if (IsDouble == true)
                                    {
                                        MiniScoreDice--;
                                    }
                                    else MiniScoreDice -= 2;
                                    label3.Text = MiniScoreDice.ToString();
                                }
                                else
                                {
                                    if (MatrixBoard[0, y] == 0) { MatrixBoard[0, y] = 2; }
                                    else
                                    {
                                        int ct = 0;
                                        for (int i = 0; i < MatrixBoard.GetLength(0) / 2; i++)
                                        //for (int i = 0; i < 6; i++)
                                        {
                                            if (MatrixBoard[i, y] == 2)
                                            {
                                                ct++;
                                            }
                                        }

                                        while (ct != 0)
                                        {
                                            MatrixBoard[ct, y] = 2;

                                            if (MatrixBoard[ct, y] == 2)
                                            {
                                                MatrixBoard[x, tempY] = 0;
                                            }
                                            ct--;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            //MatrixBoard[x, y] = 2;
                            if (CheckDoneRed() == true)
                            {
                                MoveCheckerToFinalMatrix(false, y, pasi);
                            }
                            else
                            {
                                MatrixBoard[x, y - pasi] = 2;
                                if (IsDouble == true)
                                {
                                    MiniScoreDice--;
                                }
                                else MiniScoreDice -= 2;
                                label3.Text = MiniScoreDice.ToString();
                            }
                        }
                    }
                }
                else
                {
                    int pos = 0;
                    Random r = new Random();
                    int rand = r.Next(1, 3);
                    //MiniScoreDice += 1;
                    
                    for (int i = 0; i < OutPiecesMatrix.GetLength(1); i++) 
                    //for (int i = 0; i < 5; i++)
                    {
                        if (OutPiecesMatrix[1, i] == 2) { pos += 1; }
                    }
                    if (rand == 1)
                    {
                        Redraw();
                        Thread.Sleep(2000);
                        InsertRedChecker(pos - 1, a);
                        //MatrixBoard[x, y] = 2;
                        MiniScoreDice = 5;
                    }
                    else
                    {
                        Redraw();
                        Thread.Sleep(2000);
                        InsertRedChecker(pos - 1, b);
                        //MatrixBoard[x, y] = 2;
                        MiniScoreDice = 5;
                    }
                }

            }
            Redraw();
            if (MiniScoreDice == 5)
            {
                int p = 0;
                SwitchPlayer(p);
            }
            Winner(AreThereAnyBlackPiecesOnTheBoard(), AreThereAnyRedPiecesOnTheBoard());
        }

        private bool AreThereAnyRedPiecesOnTheBoard()
        {
            int ct = 0;
            for (int i = 0; i < MatrixBoard.GetLength(0) / 2; i++)
            //for (int i = 0; i < 6; i++)
            {
                for (int j = MatrixBoard.GetLength(1) / 2; j < MatrixBoard.GetLength(1); j++) 
                //for (int j = 6; j <= 11; j++)
                //for (int j = 6; j < 12; j++)
                {
                    if (MatrixBoard[i, j] == 2)
                    {
                        ct++;
                    }
                }
            }
            if (ct > 0) return true;
            else return false;
        }

        //private (int X, int Y) RandomRedChecker()
        private int[] RandomRedChecker()
        {

            int[] rez = new int[2];
            int x = 0, y = 0;

            bool found = false;

            while (found == false)
            {
                Random random = new Random();
                //y = random.Next(0, 24);
                y = random.Next(0, MatrixBoard.GetLength(1) + MatrixBoard.GetLength(1));

                //if (y < 12)
                if (y < MatrixBoard.GetLength(1))
                {
                    x = 0;
                    while (MatrixBoard[x, y] == 2)
                    {
                        x++;
                        found = true;
                    }
                    x--;
                }
                else
                {
                    //x = 11;
                    //y -= 12;
                    x = MatrixBoard.GetLength(0) - 1;
                    y -= MatrixBoard.GetLength(1);
                    while (MatrixBoard[x, y] == 2)
                    {
                        x--;
                        found = true;
                    }
                    x++;
                }
            }
            rez[0] = x;
            rez[1] = y;
            return rez;
        }

        public List<int> GetAllPosibbleCheckersToMoveRedPlayer()
        {
            List<int> p = new List<int>();

            for (int i = MatrixBoard.GetLength(0) / 2; i >= 0; i--) 
            //for (int i = 5; i >= 0; i--)
            {
                for (int j = 0; j < MatrixBoard.GetLength(1); j++) 
                //for (int j = 0; j < 12; j++)
                {
                    if (MatrixBoard[i, j] == 2 && MatrixBoard[i + 1, j] == 0)
                    {
                        p.Add(i);
                        p.Add(j);
                    }
                }
            }
            for (int i = MatrixBoard.GetLength(0) / 2; i < MatrixBoard.GetLength(0); i++)
            {
                for (int j = 0; j < MatrixBoard.GetLength(1); j++)
                {
                    if (MatrixBoard[i, j] == 2 && MatrixBoard[i - 1, j] == 0)
                    {
                        p.Add(i);
                        p.Add(j);
                    }
                }
            }

            return p;
        }


        public List<int> GetAllPosibbleCheckersToMoveBlackPlayer()
        {
            List<int> p = new List<int>();

            for (int i = MatrixBoard.GetLength(0) / 2; i >= 0; i--)
            //for (int i = 5; i >= 0; i--)
            {
                for (int j = 0; j < MatrixBoard.GetLength(1); j++)
                //for (int j = 0; j < 12; j++)
                {
                    if (MatrixBoard[i, j] == 1 && MatrixBoard[i + 1, j] == 0)
                    {
                        p.Add(i);
                        p.Add(j);
                    }
                }
            }
            for (int i = MatrixBoard.GetLength(0) / 2; i < MatrixBoard.GetLength(0); i++)
            {
                for (int j = 0; j < MatrixBoard.GetLength(1); j++)
                {
                    if (MatrixBoard[i, j] == 1 && MatrixBoard[i - 1, j] == 0)
                    {
                        p.Add(i);
                        p.Add(j);
                    }
                }
            }

            return p;
        }

        private bool CheckDoneRed()
        {
            int ctCheckersOut = 0;
            for (int i = 0; i < FinalOutPiecesRed.Capacity; i++)
            {
                if (FinalOutPiecesRed[i] == 2) { ctCheckersOut++; }
            }
            if (ctCheckersOut > 0) return true;
            int ct = 0;

            for (int i = 0; i < MatrixBoard.GetLength(0) / 2; i++) 
            //for (int i = 0; i < 6; i++)
            {
                for (int j = MatrixBoard.GetLength(1) / 2; j < MatrixBoard.GetLength(1); j++)
                //for (int j = 6; j <= 11; j++)
                //for (int j = 6; j < 12; j++)
                {
                    if (MatrixBoard[i, j] == 2)
                    {
                        ct++;
                    }
                }
            }
            if (ct + 1 == MaxCheckersOnBoard) { return true; }
            return false;
        }
        #endregion
        #region Both Players Controls
        private void SwitchPlayer(int p)
        {
            //=0 Turn: Human
            //=1 Turn: AI
            if (p == 0)
            {
                playerHuman.isTurn = true;
                playerAI.isTurn = false;
                label2.Text = playerHuman.Name;
                label3.Text = MiniScoreDice.ToString();
                MiniScoreDice = 0;
                label3.Text = MiniScoreDice.ToString();



                CubePictureBox1.Enabled = true;
                CubePictureBox2.Enabled = true;
                label1.Enabled = true;
            }
            if (p == 1)
            {
                playerHuman.isTurn = false;
                playerAI.isTurn = true;
                label2.Text = playerAI.Name;
                label3.Text = MiniScoreDice.ToString();
                MiniScoreDice = 0;
                label3.Text = MiniScoreDice.ToString();



                CubePictureBox1.Enabled = true;
                CubePictureBox2.Enabled = true;
                label1.Enabled = true;



                MoveAI();
                Thread.Sleep(1000);
            }
        }

        private void MoveThePieceToMatrix(int x, int y)
        {
            int ct = 0;
            if (MatrixBoard[x, y] == 1)
            {
                //for (int i = 1; i < OutPiecesMatrix.GetLength(1); i++)
                //{
                //    if (OutPiecesMatrix[0, i - 1] == 1) { OutPiecesMatrix[0, i] = 1; break; }
                //    else { OutPiecesMatrix[0, i - 1] = 1; break; }
                //}


                for (int i = 0; i < OutPiecesMatrix.GetLength(1); i++)
                {
                    if (OutPiecesMatrix[0, i] == 1) ct++;
                }

                if (ct == 0)
                {
                    OutPiecesMatrix[0, 0] = 1;
                }
                else
                {
                    for(int i = 1; i <= ct; i++)
                    {
                        OutPiecesMatrix[0, i] = 1;
                    }
                }
                
            }

            if (MatrixBoard[x, y] == 2)
            {
                for (int i = 0; i < OutPiecesMatrix.GetLength(1); i++) 
                {
                    if (OutPiecesMatrix[1, i] == 2) ct++;
                }

                if (ct == 0)
                {
                    OutPiecesMatrix[1, 0] = 2;
                }
                else
                {
                    for (int i = 1; i <= ct; i++)
                    {
                        OutPiecesMatrix[1, i] = 2;
                    }
                }

                //for (int i = 1; i < OutPiecesMatrix.GetLength(1); i++)
                //{
                //    if (OutPiecesMatrix[1, i - 1] == 2) { OutPiecesMatrix[1, i] = 2; break; }
                //    else { OutPiecesMatrix[1, i - 1] = 2; break; }
                //}
            }
        }

        //////////////////
        private void MoveCheckerToFinalMatrix(bool isHuman, int y, int pasi)
        {
            if (isHuman == true)
            {
                int ct = 0;

                if (y + pasi > MatrixBoard.GetLength(1) - 1) 
                //if (y + pasi > 11)
                {
                    if (FinalOutPiecesBlack[0] == 0)
                    {
                        FinalOutPiecesBlack[0] = 1;
                    }
                    else
                    {
                        for (int i = 0; i < FinalOutPiecesBlack.Capacity; i++)
                        {
                            if (FinalOutPiecesBlack[i] == 1) ct++;
                        }
                        for (int i = 0; i < ct + 1; i++)
                        {
                            FinalOutPiecesBlack[i] = 1;
                        }
                    }
                }
            }
            else
            {
                int ct = 0;

                if (y + pasi > MatrixBoard.GetLength(1) - 1)
                //if (y + pasi > 11)
                {
                    if (FinalOutPiecesRed[0] == 0)
                    {
                        FinalOutPiecesRed[0] = 2;
                    }
                    else
                    {
                        for (int i = 0; i < FinalOutPiecesRed.Capacity; i++)
                        {
                            if (FinalOutPiecesRed[i] == 2) ct++;
                        }
                        for (int i = 0; i < ct + 1; i++)
                        {
                            FinalOutPiecesRed[i] = 2;
                        }
                    }
                }
            }
        }

        private void Winner(bool black, bool red)
        {
            if (black == false && red == true)
            {
                WinnerBox.Text = "HUMAN";
                MessageBox.Show("Winner is HUMAN");
            }
            if (black == true && red == false)
            {
                WinnerBox.Text = "AI";
                MessageBox.Show("Winner is AI");
            }
            else WinnerBox.Text = "-------------------------";
        }
        #endregion

        //ExpectiMiniMax algorithm (in Stochastic games) is a variation of the minimax algorithm, for use in AI systems that play two-player zero-sum games, such as backgammon.

        //Incarcare Implementare
        public void ExpectiMiniMax(int x, int y, int d1, int d2, int depth, bool maxPlayer)
        {
    //        if node is a terminal node or depth = 0
    //    return the heuristic value of node
    //if the adversary is to play at node
    //    // Return value of minimum-valued child node
    //    let α := +∞;
    //    foreach child of node
    //        α:= min(α, expectiminimax(child, depth - 1));
    //else if we are to play at node
    //    // Return value of maximum-valued child node
    //    let α:= -∞;
    //    foreach child of node
    //        α:= max(α, expectiminimax(child, depth - 1));
    //else if random event at node
    //    // Return weighted average of all child nodes' values
    //    let α := 0;
    //    foreach child of node
    //        α := α + (Probability[child] × expectiminimax(child, depth-1));
    //return α;




            double probabilityCubes = 0.0;
            double score = 0.0;
            
            if (d1 == d2) probabilityCubes = 1.0 / 36.0;
            else probabilityCubes = 1.0 / 18.0;

            List<int> l = new List<int>();
            l = GetAllPosibbleCheckersToMoveRedPlayer();
            
        }


        private void RestartGame_Click(object sender, EventArgs e)
        {

            //for (int i = 0; i < OutPiecesMatrix.GetLength(0); i++)
            //{
            //    for (int j = 0; j < OutPiecesMatrix.GetLength(1); j++)
            //    {
            //        if (OutPiecesMatrix[i, j] == 1 || OutPiecesMatrix[i, j] == 2)
            //        {
            //            OutPiecesMatrix[i, j] = 0;
            //            DeletePictureBoxOut(i, j);
            //        }
            //    }
            //}

            //for (int i = 0; i < FinalOutPiecesBlack.Capacity; i++)
            //{
            //    FinalOutPiecesBlack[i] = 0;
            //    DeletePictureBoxFinal(i);
            //}

            //for (int i = 0; i < FinalOutPiecesRed.Capacity; i++)
            //{
            //    FinalOutPiecesRed[i] = 0;
            //    DeletePictureBoxFinal(i);
            //}


            //for (int i = 0; i < MatrixBoard.GetLength(0); i++)
            //{
            //    for (int j = 0; j < MatrixBoard.GetLength(1); j++)
            //    {
            //        if (MatrixBoard[i, j] == 1 || MatrixBoard[i, j] == 2)
            //        {
            //            MatrixBoard[i, j] = 0;
            //            DeletePictureBox(i, j);
            //        }
            //        else
            //        {
            //            MatrixBoard[i, j] = 0;
            //            DeletePictureBox(i, j);
            //        }
            //    }
            //}

            //Redraw();
            //InitializeComponentsOnBoard();

            //MiniScoreDice = 0;
            //playerHuman.isTurn = true;
            //rollDice.Enabled = true;
            //Redraw();

            Application.Restart();
        }

        

        /// <summary>
        /// Incercare MoveAI
        /// </summary>
        private void Get()
        {
            int x = 0,  y = 0;
            List<int> list = new List<int>();
            list = GetAllPosibbleCheckersToMoveBlackPlayer();

            for(int i = 0; i < list.Capacity; i++)
            {
                if (i % 2 != 0) { y = list[i]; }
                else x = list[i];
            }
        }

        public void MoveAI()
        {
            rollDice.PerformClick();
            while (playerAI.isTurn == true)
            {
                MoveAI_Click(null, null);
                Thread.Sleep(500);
                Redraw();
            }
        }

        private void UndoMove_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Get();
        }

        private void UndoMove(int xFrom, int yFrom, int xTo, int yTo)
        {

        }
    }
}
