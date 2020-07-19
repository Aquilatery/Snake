using System;
using System.Drawing;
using System.Threading;
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
        int Queue, Queue2/*, Queue3*/, T1, T2, Measurement2 = 0;

        int Measurement = 5;
        int Growth = 5;
        bool Apple = false;
        bool Continue = true;
        Random RNDM = new Random();

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
            Measurement2 = Measurement;
            Game_Restart();
        }

        private void Game_Start(object GS)
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
            SnakeHead.Location = new Point(Width2, Height2);
        }

        private void Game_Restart()
        {
            Pen Pencil = new Pen(Color.White, 9999);
            Graphics Graph = null;
            Graph = CreateGraphics();
            SolidBrush Colored = new SolidBrush(Color.White);
            Graph.DrawRectangle(Pencil, new Rectangle(VWidth / 2, VHeight / 2, 9999, 9999));
            Graph.FillRectangle(Colored, VWidth / 2, VHeight / 2, 9999, 9999);
            Pencil.Dispose();
            Graph.Dispose();
            Colored.Dispose();
            ThreadPool.QueueUserWorkItem(new WaitCallback(Game_Start));
            Measurement = Measurement2;
            Queue = 0;
            Queue2 = 0;
            T1 = 0;
            T2 = 0;
            Array.Clear(Locations1, 0, 999999);
            Array.Clear(Locations2, 0, 999999);
            Direct = Direction.Right;
            Gaming.Enabled = true;
            Continue = true;
        }

        private enum Direction
        {
            Up, Down, Left, Right
        }

        private void Tail_Draw(int AX, int AY)
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
                    Apple_Eat(AX, AY);
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

        private void Apple_Eat(int AX, int AY)
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

        private void Apple_Control(object AC)
        {
            if (!Apple)
            {
                Apple = true;
                AX = RNDM.Next(50, VWidth - 50);
                AY = RNDM.Next(50, VHeight - 50);
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
        }

        private void Apple_Look(object AL)
        {
            if (Width2 == AX && Height2 == AY)
                Apple_Eat(AX, AY);
            else
            {
                FX = Width2 - AX;
                FY = Height2 - AY;
                if (Math.Abs(FX) >= 0 && Math.Abs(FX) <= 8 && Math.Abs(FY) >= 0 && Math.Abs(FY) <= 8)
                    Apple_Eat(AX, AY);
            }
        }

        private void Snake_Move()
        {
            X = Width2;
            Y = Height2;

            switch (Direct)
            {
                case Direction.Up:
                    if (Height2 <= 1)
                        Height2 = VHeight - 13;
                    else
                        Height2 -= 10;
                    break;
                case Direction.Down:
                    if (Height2 >= VHeight - 12)
                        Height2 = 2;
                    else
                        Height2 += 10;
                    break;
                case Direction.Left:
                    if (Width2 <= 1)
                        Width2 = VWidth - 13;
                    else
                        Width2 -= 10;
                    break;
                case Direction.Right:
                    if (Width2 >= VWidth - 12)
                        Width2 = 2;
                    else
                        Width2 += 10;
                    break;
            }
            Tail_Draw(X, Y);
            SnakeHead.Location = new Point(Width2, Height2);

            if (X != Width2 || Y != Height2)
            {
                Locations1[Queue] = X;
                Locations2[Queue] = Y;
                Queue++;
            }
        }

        private void Snake_Tail(object ST)
        {
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
                Locations1[Queue2] = 999999;
                Locations2[Queue2] = 999999;
            }
        }

        private void Time_Plus(object TP)
        {
            T2 += 50;
            if (T2 >= 1000)
            {
                T1++;
                T2 = 0;
            }
        }

        private void Label_Write(object LW)
        {
            InfoLabel.Text = "X = " + Width2 + " - FX = " + Math.Abs(FX) + "\n" + "Y = " + Height2 + " - FY = " + Math.Abs(FY);
            StateLabel.Text = "Measurement = " + Measurement + "\n" + "Time = " + T1 + "." + T2 + " Second";

            InfoLabel.SendToBack();
            StateLabel.SendToBack();
            SnakeHead.BringToFront();
        }

        private void Death_Control()
        {
            Parallel.For(0, Queue, i =>
            {
                FX2 = Locations1[i] - Width2;
                FY2 = Locations2[i] - Height2;
                if (Math.Abs(FX2) >= 0 && Math.Abs(FX2) <= 8 && Math.Abs(FY2) >= 0 && Math.Abs(FY2) <= 8)
                {
                    Gaming.Enabled = false;
                    Continue = false;
                    Game_Restart();
                }
            });

            /*
                Queue3 = 0;
                while (Queue3 != Queue)
                {
                    FX2 = Locations1[Queue3] - Width2;
                    FY2 = Locations2[Queue3] - Height2;
                    if (Math.Abs(FX2) >= 0 && Math.Abs(FX2) <= 8 && Math.Abs(FY2) >= 0 && Math.Abs(FY2) <= 8)
                    {
                        Gaming.Enabled = false;
                        Continue = false;
                        Game_Restart();
                    }
                    Queue3++;
                }
            */
        }

        private void Gaming_Tick(object sender, EventArgs e)
        {
            if (Continue)
            {
                Snake_Move();

                ThreadPool.QueueUserWorkItem(new WaitCallback(Apple_Control));

                ThreadPool.QueueUserWorkItem(new WaitCallback(Snake_Tail));

                ThreadPool.QueueUserWorkItem(new WaitCallback(Apple_Look));

                ThreadPool.QueueUserWorkItem(new WaitCallback(Time_Plus));

                ThreadPool.QueueUserWorkItem(new WaitCallback(Label_Write));
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
                PauseLabel.Visible = false;

                Death_Control();
            }
            else
            {
                PauseLabel.Visible = true;
                PauseLabel.BringToFront();
            }
        }
    }
}