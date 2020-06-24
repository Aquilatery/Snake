using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Snake
{
    public partial class Game : Form
    {
        int VWidth, Width2, VHeight, Height2, X, Y, AX, AY, FX, FX2, FY, FY2;
        Direction Direct;
        int[] Locations1 = new int[999999];
        int[] Locations2 = new int[999999];
        int Queue, Queue2/*, Queue3*/, T1, T2 = 0;

        int Measurement = 5;
        int Growth = 5;
        bool Apple = false;
        bool Continue = true;
        Random Rastgele = new Random();

        /*
            Array.Clear(Locations, 0, Locations.Length);
            Locations[Queue] = Konum(X, Y);
            Queue++;
        */

        public Game()
        {
            InitializeComponent();
        }

        private void Game_Load(object sender, EventArgs e)
        {
            VWidth = SystemInformation.PrimaryMonitorSize.Width;
            VHeight = SystemInformation.PrimaryMonitorSize.Height;
            Width2 = VWidth / 2;
            Height2 = VHeight / 2;
            X = Width2;
            Y = Height2;
            Direct = Direction.Right;
            Width = VWidth;
            Height = VHeight;
            rectangleShape2.Location = new Point(Width2, Height2);
        }

        private enum Direction
        {
            Up, Down, Left, Right
        }

        private void Drawing(int AX, int AY)
        {
            Pen Pencil = new Pen(Color.Black, 5);
            Graphics Graph = null;
            Graph = CreateGraphics();
            SolidBrush Colored = new SolidBrush(Color.Black);
            while (Queue2 != Queue)
            {
                Graph.DrawRectangle(Pencil, new Rectangle(Locations1[Queue2], Locations2[Queue2], 10, 10));
                Graph.FillRectangle(Colored, Locations1[Queue2], Locations2[Queue2], 10, 10);
                if (AX == Locations1[Queue2] && AY == Locations2[Queue2])
                    AppleEat(AX, AY);
                Queue2++;
            }
            Pencil.Dispose();
            Graph.Dispose();
            Colored.Dispose();
            if (Queue >= 2)
                Queue2 = Queue - 2;
            else
                Queue2 = Queue;
        }

        private void AppleEat(int AX, int AY)
        {
            Apple = false;
            Measurement += Growth;
            Pen Pencil = new Pen(Color.White, 5);
            Graphics Graph = null;
            Graph = CreateGraphics();
            SolidBrush Colored = new SolidBrush(Color.White);
            Graph.DrawRectangle(Pencil, new Rectangle(AX, AY, 10, 10));
            Graph.FillRectangle(Colored, AX, AY, 10, 10);
            Pencil.Dispose();
            Graph.Dispose();
            Colored.Dispose();
        }

        private void Gaming_Tick(object sender, EventArgs e)
        {
            if (Continue)
            {
                X = Width2;
                Y = Height2;

                if (Direct == Direction.Right)
                {
                    if (Width2 >= VWidth - 12)
                        Width2 = 2;
                    else
                        Width2 += 10;
                }
                else if (Direct == Direction.Left)
                {
                    if (Width2 <= 1)
                        Width2 = VWidth - 13;
                    else
                        Width2 -= 10;
                }
                else if (Direct == Direction.Up)
                {
                    if (Height2 <= 1)
                        Height2 = VHeight - 13;
                    else
                        Height2 -= 10;
                }
                else if (Direct == Direction.Down)
                {
                    if (Height2 >= VHeight - 12)
                        Height2 = 2;
                    else
                        Height2 += 10;
                }
                Drawing(X, Y);
                rectangleShape2.Location = new Point(Width2, Height2);

                if (X != Width2 || Y != Height2)
                {
                    Locations1[Queue] = X;
                    Locations2[Queue] = Y;
                    Queue++;
                }
                if (Apple == false)
                {
                    Apple = true;
                    AX = Rastgele.Next(50, VWidth - 50);
                    AY = Rastgele.Next(50, VHeight - 50);
                    Pen Pencil = new Pen(Color.Red, 5);
                    Graphics Graph = null;
                    Graph = CreateGraphics();
                    SolidBrush Colored = new SolidBrush(Color.Red);
                    Graph.DrawRectangle(Pencil, new Rectangle(AX, AY, 10, 10));
                    Graph.FillRectangle(Colored, AX, AY, 10, 10);
                    Pencil.Dispose();
                    Graph.Dispose();
                    Colored.Dispose();
                }
                else
                {
                    Pen Pencil = new Pen(Color.Red, 5);
                    Graphics Graph = null;
                    Graph = CreateGraphics();
                    SolidBrush Colored = new SolidBrush(Color.Red);
                    Graph.DrawRectangle(Pencil, new Rectangle(AX, AY, 10, 10));
                    Graph.FillRectangle(Colored, AX, AY, 10, 10);
                    Pencil.Dispose();
                    Graph.Dispose();
                }
                if (Queue >= Measurement)
                {
                    Queue2 = Queue - Measurement;
                    Pen Pencil = new Pen(Color.White, 5);
                    Graphics Graph = null;
                    Graph = CreateGraphics();
                    SolidBrush Colored = new SolidBrush(Color.White);
                    Graph.DrawRectangle(Pencil, new Rectangle(Locations1[Queue2], Locations2[Queue2], 10, 10));
                    Graph.FillRectangle(Colored, Locations1[Queue2], Locations2[Queue2], 10, 10);
                    Pencil.Dispose();
                    Graph.Dispose();
                    Colored.Dispose();
                    /*Array.Clear(Locations1, 0, Queue2 + 1);
                    Array.Clear(Locations2, 0, Queue2 + 1);*/
                    Locations1[Queue2] = 99999;
                    Locations2[Queue2] = 99999;
                }
                if (Width2 == AX && Height2 == AY)
                    AppleEat(AX, AY);
                else
                {
                    FX = Width2 - AX;
                    FY = Height2 - AY;
                    if ((Math.Abs(FX) >= 0 && Math.Abs(FX) <= 8) && (Math.Abs(FY) >= 0 && Math.Abs(FY) <= 8))
                        AppleEat(AX, AY);
                }
                T2 += 50;
                if (T2 >= 1000)
                {
                    T1++;
                    T2 = 0;
                }
                label1.Text = "X = " + Width2 + " - FX = " + Math.Abs(FX) + "\n" + "Y = " + Height2 + " - FY = " + Math.Abs(FY);
                label2.Text = "Measurement = " + Measurement + "\n" + "Time = " + T1 + "." + T2 + " Second";
                label1.SendToBack();
                label2.SendToBack();
            }
        }

        private void Game_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
            string Key = e.KeyCode.ToString();
            if (Key == "Escape" || Key == "escape")
                Application.Exit();
            else if (Continue)
            {
                if (Key == "Right" || Key == "right" || Key == "D" || Key == "d")
                {
                    if (Direct != Direction.Left && Direct != Direction.Right)
                        Direct = Direction.Right;
                }
                else if (Key == "Left" || Key == "left" || Key == "A" || Key == "a")
                {
                    if (Direct != Direction.Right && Direct != Direction.Left)
                        Direct = Direction.Left;
                }
                else if (Key == "Up" || Key == "up" || Key == "W" || Key == "w")
                {
                    if (Direct != Direction.Down && Direct != Direction.Up)
                        Direct = Direction.Up;
                }
                else if (Key == "Down" || Key == "down" || Key == "S" || Key == "s")
                {
                    if (Direct != Direction.Up && Direct != Direction.Down)
                        Direct = Direction.Down;
                }
                else if (Key == "Pause" || Key == "pause" || Key == "P" || Key == "p")
                    Continue = !Continue;
            }
            else if (Key == "Pause" || Key == "pause" || Key == "P" || Key == "p")
                Continue = !Continue;
        }

        private void Death_Tick(object sender, EventArgs e)
        {
            if (Continue)
            {
                Parallel.For(0, Queue, i =>
                {
                    FX2 = Locations1[i] - Width2;
                    FY2 = Locations2[i] - Height2;
                    if ((Math.Abs(FX2) >= 0 && Math.Abs(FX2) <= 8) && (Math.Abs(FY2) >= 0 && Math.Abs(FY2) <= 8))
                    {
                        Gaming.Enabled = false;
                        Continue = false;
                        Application.Restart();
                    }
                });

                /*
                Queue3 = 0;
                while (Queue3 != Queue)
                {
                    FX2 = Locations1[Queue3] - Width2;
                    FY2 = Locations2[Queue3] - Height2;
                    if ((Math.Abs(FX2) >= 0 && Math.Abs(FX2) <= 8) && (Math.Abs(FY2) >= 0 && Math.Abs(FY2) <= 8))
                    {
                        Continue = false;
                        Application.Restart();
                    }
                    Queue3++;
                }*/
            }
        }
    }
}