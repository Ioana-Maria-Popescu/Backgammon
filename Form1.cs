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
        readonly int[,] MatrixBoard = new int[12, 12];
        readonly int[,] OutPieces = new int[2, 5];

        public Dice DiceRoll { get; set; }

        public int Moves = 0;
        public int MiniScoreCubes = 0;

        public int CoordX, CoordY;
        public bool IsDouble;
        public int PieceBackOnBoard = 0;

        Player playerHuman = new Player("Human", Player.PlayerColor.Black);
        Player playerAI = new Player("AI", Player.PlayerColor.Red);

        public Form1()
        {
            InitializeComponent();
            InitializeComponentsOnBoard();
            playerHuman.isTurn = true;
            label2.Text = "Human";
            label2.Font = new Font("Arial", 30);
            label3.Text = MiniScoreCubes.ToString();
            Redraw();
        }

        #region Initialization
        public void InitializeComponentsOnBoard()
        {
            //0-nimic 1-black 2-red
            for (int i = 0; i < 5; i++)
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
        #endregion
        #region Dices
        private void RollTheDice_click(object sender, EventArgs e)
        {
            DiceRoll = new Dice();
            DiceRoll.RollDice();
            MiniScoreCubes = 1;
            label3.Text = MiniScoreCubes.ToString();

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
                Moves = 1;
                MiniScoreCubes += 2;
                label3.Text = MiniScoreCubes.ToString();
            }
            else
            {
                Moves = 1;
                MiniScoreCubes++;
                label3.Text = MiniScoreCubes.ToString();
            }

        }

        private void Cube2Click(object sender, MouseEventArgs e)
        {
            if (IsDouble == false)
            {
                Moves = 2;
                MiniScoreCubes += 2;
                label3.Text = MiniScoreCubes.ToString();
            }
            else
            {
                Moves = 2;
                MiniScoreCubes++;
                label3.Text = MiniScoreCubes.ToString();
            }
        }

        private void SumCubesClick(object sender, MouseEventArgs e)
        {
            if (IsDouble == false)
            {
                Moves = 3;
                MiniScoreCubes += 4;
                label3.Text = MiniScoreCubes.ToString();
            }
            else
            {
                Moves = 3;
                MiniScoreCubes += 2;
                label3.Text = MiniScoreCubes.ToString();
            }

        }

        #endregion
        #region Game 
        public void Redraw()
        {
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
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
                        //pic.MouseClick += new MouseEventHandler(Pic_OnClickRed);
                        this.Controls.Add(pic);
                        pic.BringToFront();
                    }
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (OutPieces[i, j] == 1)
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

                    if (OutPieces[i, j] == 2)
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
                        //outPic.MouseClick += new MouseEventHandler(OutPics_OnClickRed);
                        this.Controls.Add(outPic);
                        outPic.BringToFront();
                    }
                }
            }
        }

        private void label3_TextChanged(object sender, EventArgs e)
        {
            if (MiniScoreCubes == 5)
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

        public PictureBox GetPictureBox(int x, int y)
        {
            var name = String.Format("pb_{0}_{1}", x, y);
            foreach (Control c in this.Controls)
            {
                if (c.Name == name)
                {
                    return c as PictureBox;
                }
            }
            return null;
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
                var a = DiceRoll.Cube1;
                var b = DiceRoll.Cube2;
                MatrixBoard[x, y] = 0;
                var pasi = 0;
                if (Moves == 1) { pasi = a; }
                if (Moves == 2) { pasi = b; }
                if (Moves == 3) { pasi = (a + b); }

                DeletePictureBox(x, y);
                if (x < 6)
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
                    }
                    else
                    {
                        y = Math.Abs(y - pasi) - 1;
                        if (MatrixBoard[11, y] == 2 && MatrixBoard[10, y] == 0)
                        {
                            MoveThePieceToMatrix(11, y);
                            MatrixBoard[11, y] = 1;
                            Redraw();

                        }
                        else
                        {
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

                                    if (MatrixBoard[11 - ct, y] == 1)
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
                    y += pasi;
                    if (MatrixBoard[11, y] == 2 && MatrixBoard[10, y] == 0)
                    {
                        MoveThePieceToMatrix(11, y);
                        MatrixBoard[11, y] = 1;
                        Redraw();

                    }
                    else
                    {
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

                                if (MatrixBoard[11 - ct, y] == 1)
                                {
                                    MatrixBoard[x, tempY] = 0;
                                }
                                ct--;
                            }
                        }
                    }
                }

            }
            Redraw();
            if (MiniScoreCubes == 5)
            {
                int p = 1;
                SwitchPlayer(p);
            }
        }


        private void GetOnBoardPos1(object sender, EventArgs e)
        {
            PieceBackOnBoard = 1;
        }

        private void GetOnBoardPos2(object sender, EventArgs e)
        {
            PieceBackOnBoard = 2;
        }

        private void GetOnBoardPos3(object sender, EventArgs e)
        {
            PieceBackOnBoard = 3;
        }

        private void GetOnBoardPos4(object sender, EventArgs e)
        {
            PieceBackOnBoard = 4;
        }

        private void GetOnBoardPos5(object sender, EventArgs e)
        {
            PieceBackOnBoard = 5;
        }

        private void GetOnBoardPos6(object sender, EventArgs e)
        {
            PieceBackOnBoard = 6;
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

            if (OutPieces[0, 0] != 0)
            {
                DeletePictureBoxOut(x, y);
                if (a == PieceBackOnBoard)
                {
                    InsertChecker(x, y, a);
                }
                else if (b == PieceBackOnBoard) { InsertChecker(x, y, b); }
            }
        }

        public void InsertChecker(int x, int y, int zar)
        {
            if (MatrixBoard[0, 12 - zar] == 2 && MatrixBoard[1, 12 - zar] == 2) { OutPieces[x, y] = 1; }
            if (MatrixBoard[0, 12 - zar] == 2 && MatrixBoard[1, 12 - zar] == 0)
            {
                MoveThePieceToMatrix(0, 12 - zar);
                MatrixBoard[0, 12 - zar] = 1;
                OutPieces[x, y] = 0;
                DeletePictureBoxOut(x, y);
            }
            if (MatrixBoard[0, 12 - zar] == 0)
            {
                MatrixBoard[0, 12 - zar] = 1;
                OutPieces[x, y] = 0;
                DeletePictureBoxOut(x, y);
            }
            else
            {
                int ct = 0;
                for (int i = 0; i < 6; i++)
                {
                    if (MatrixBoard[i, 12 - zar] == 1)
                    {
                        ct++;
                    }
                }
                MatrixBoard[ct, 12 - zar] = 1;
                OutPieces[x, y] = 0;
                DeletePictureBoxOut(x, y);
            }
            Redraw();
        }

        #endregion
        #region AI Player Controls

        public void InsertRedChecker(int pos, int zar)
        {
            if (MatrixBoard[11, 12 - zar] == 1 && MatrixBoard[10, 12 - zar] == 1) { OutPieces[1, pos] = 2; }
            if (MatrixBoard[11, 12 - zar] == 1 && MatrixBoard[10, 12 - zar] == 0)
            {
                MoveThePieceToMatrix(11, 12 - zar);
                MatrixBoard[11, 12 - zar] = 2;
                DeletePictureBoxOut(1, pos);
                OutPieces[1, pos] = 0;
                
            }
            if (MatrixBoard[11, 12 - zar] == 0)
            {
                MatrixBoard[11, 12 - zar] = 2;
                DeletePictureBoxOut(1, pos);
                OutPieces[1, pos] = 0;
            }
            else
            {
                int ct = 0;
                for (int i = 11; i > 5; i--)
                {
                    if (MatrixBoard[i, 12 - zar] == 2)
                    {
                        ct++;
                    }
                }
                MatrixBoard[ct, 12 - zar] = 2;
                DeletePictureBoxOut(1, pos);
                OutPieces[1, pos] = 0;
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
                if (MiniScoreCubes == 1)
                {
                    Random random = new Random();
                    Moves = random.Next(1, 3);
                }
                /*
                if (Moves == 1) { pasi = a; MiniScoreCubes++; Moves = 2; }
                else if (Moves == 2) { pasi = b; MiniScoreCubes++; Moves = 1; }
                else if (Moves == 3) { pasi = (a + b); MiniScoreCubes += 2; }
                */

                if (Moves == 1)
                {
                    if (IsDouble == false)
                    {
                        pasi = a;
                        MiniScoreCubes += 2;
                        Moves = 2;
                    }
                    else
                    {
                        pasi = a;
                        MiniScoreCubes++;
                        Moves = 1;
                    }
                }
                else if (Moves == 2)
                {
                    if (IsDouble == false)
                    {
                        pasi = b;
                        MiniScoreCubes += 2;
                        Moves = 1;
                    }
                    else
                    {
                        pasi = b;
                        MiniScoreCubes++;
                        Moves = 2;
                    }
                }
                else if (Moves == 3)
                {
                    if (IsDouble == false)
                    {
                        pasi = (a + b);
                        MiniScoreCubes += 4;
                    }
                    else
                    {
                        pasi = (a + b);
                        MiniScoreCubes += 2;
                        Moves = 3;
                    }
                }
                label3.Text = MiniScoreCubes.ToString();



                DeletePictureBox(x, y);
                if (OutPieces[1, 0] == 0)
                {
                    if (x > 6)
                    {
                        if (y - pasi >= 0)
                        {
                            y -= pasi;

                            if (MatrixBoard[11, y] == 1 && MatrixBoard[10, y] == 0)
                            {
                                MoveThePieceToMatrix(11, y);
                                MatrixBoard[11, y] = 2;
                                Redraw();

                            }
                            else
                            {
                                if (MatrixBoard[11, y] == 1 && MatrixBoard[10, y] == 1)
                                {
                                    MatrixBoard[x, tempY] = 2;
                                    if (IsDouble == true)
                                    {
                                        MiniScoreCubes--;
                                    }
                                    else MiniScoreCubes -= 2;
                                    label3.Text = MiniScoreCubes.ToString();
                                }
                                else
                                {
                                    if (MatrixBoard[11, y] == 0) { MatrixBoard[11, y] = 2; }
                                    else
                                    {
                                        int ct = 0;
                                        for (int i = 11; i > 5; i--)
                                        {
                                            if (MatrixBoard[i, y] == 2)
                                            {
                                                ct++;
                                            }
                                        }

                                        while (ct != 0)
                                        {
                                            MatrixBoard[11 - ct, y] = 2;

                                            if (MatrixBoard[11 - ct, y] == 2)
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
                                        MiniScoreCubes--;
                                    }
                                    else MiniScoreCubes -= 2;
                                    label3.Text = MiniScoreCubes.ToString();
                                }
                                else
                                {
                                    if (MatrixBoard[0, y] == 0) { MatrixBoard[0, y] = 2; }
                                    else
                                    {
                                        int ct = 0;
                                        for (int i = 0; i < 6; i++)
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
                        if (y < 12)
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
                                        MiniScoreCubes--;
                                    }
                                    else MiniScoreCubes -= 2;
                                    label3.Text = MiniScoreCubes.ToString();
                                }
                                else
                                {
                                    if (MatrixBoard[0, y] == 0) { MatrixBoard[0, y] = 2; }
                                    else
                                    {
                                        int ct = 0;
                                        for (int i = 0; i < 6; i++)
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
                            MatrixBoard[x, tempY] = 2;
                        }
                    }
                }
                else
                {
                    int pos = 0;
                    Random r = new Random();
                    int rand = r.Next(1, 3);
                    for (int i = 0; i < 5; i++)
                    {
                        if (OutPieces[1, i] == 2) { pos += 1; }
                    }
                    if (rand == 1)
                    {
                        InsertRedChecker(pos, a);
                        //MatrixBoard[x, y] = 2;
                        MiniScoreCubes = 5;
                    }
                    else
                    {
                        InsertRedChecker(pos, b);
                        //MatrixBoard[x, y] = 2;
                        MiniScoreCubes = 5;
                    }
                }

            }
            Redraw();
            if (MiniScoreCubes == 5)
            {
                int p = 0;
                SwitchPlayer(p);
            }
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
                y = random.Next(0, 24);

                if (y < 12)
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
                    x = 11;
                    y -= 12;
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
            for (int i = 5; i >= 0; i--)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (MatrixBoard[i, j] == 2 && MatrixBoard[i + 1, j] == 0)
                    {
                        p.Add(i);
                        p.Add(j);
                    }
                }
            }
            for (int i = 6; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
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
                label3.Text = MiniScoreCubes.ToString();
                MiniScoreCubes = 0;
                label3.Text = MiniScoreCubes.ToString();
            }
            if (p == 1)
            {
                playerHuman.isTurn = false;
                playerAI.isTurn = true;
                label2.Text = playerAI.Name;
                label3.Text = MiniScoreCubes.ToString();
                MiniScoreCubes = 0;
                label3.Text = MiniScoreCubes.ToString();
            }
        }

        private void MoveThePieceToMatrix(int x, int y)
        {
            if (MatrixBoard[x, y] == 1)
            {
                for (int i = 1; i < 5; i++)
                {
                    if (OutPieces[0, i - 1] == 1) { OutPieces[0, i] = 1; break; }
                    else { OutPieces[0, i - 1] = 1; break; }
                }
            }

            if (MatrixBoard[x, y] == 2)
            {
                for (int i = 1; i < 5; i++)
                {
                    if (OutPieces[1, i - 1] == 2) { OutPieces[1, i] = 2; break; }
                    else { OutPieces[1, i - 1] = 2; break; }
                }
            }
        }

        #endregion


        //ExpectiMiniMax algorithm (in Stochastic games) is a variation of the minimax algorithm, for use in AI systems that play two-player zero-sum games, such as backgammon.

        //Incarcare Implementare
        public void ExpectiMiniMax(int x, int y, int d1, int d2, int depth, bool maxPlayer)
        {
            if (depth == 0) { }
            GetAllPosibbleCheckersToMoveRedPlayer();
            
        }
    }

    
}
