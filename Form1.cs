using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheDuke.CharaterRule;

namespace TheDuke
{
    public partial class Form1 : Form
    {
        private int currPlayer = 1;
        private int PreDuke = 0;
        private int PreFootMan = 0;
        private bool Summon = true;
        private Button[,] buttons;
        private Figure[,] listFigure;
        List<string> Player1Figure = new List<string>
        {
          "Duke","Footman","Footman"
        };
        List<string> Player2Figure = new List<string>
        {
          "Duke","Footman","Footman"
        };

        public Form1()
        {
            InitializeComponent();
            lblPlayerMove.Text = "Next Move:\n Player " + currPlayer;
            listFigure = new Figure[6, 6];
            buttons = new Button[6, 6] {
                { btnA1, btnA2, btnA3, btnA4, btnA5, btnA6 },
                { btnB1, btnB2, btnB3, btnB4, btnB5, btnB6 },
                { btnC1, btnC2, btnC3, btnC4, btnC5, btnC6 },
                { btnD1, btnD2, btnD3, btnD4, btnD5, btnD6 },
                { btnE1, btnE2, btnE3, btnE4, btnE5, btnE6 },
                { btnF1, btnF2, btnF3, btnF4, btnF5, btnF6 }
            };
            DeactivateAllButtons();
            ActiveButtonsFirstTime();
        }
        public void Summoner(Button btn, string Name, int Player)
        {
            Figure figure;
            Image part = new Bitmap(100, 100);
            Graphics g = Graphics.FromImage(part);
            switch (Name)
            {
                case "Duke":
                    figure = new Duke(Name, btn.Location.X / 100, btn.Location.Y / 100, Player, "A");
                    listFigure[btn.Location.X / 100, btn.Location.Y / 100] = figure;
                    break;
                case "Footman":
                    figure = new Footman(Name, btn.Location.X / 100, btn.Location.Y / 100, Player, "A");
                    listFigure[btn.Location.X / 100, btn.Location.Y / 100] = figure;
                    break;
                default:
                    figure = new Figure();
                    break;
            }
            g.DrawImage(figure.DEF, new Rectangle(7, 7, 100, 100), 0, 0, 150, 150, GraphicsUnit.Pixel);

            if (Player == 2)
            {
                part.RotateFlip(RotateFlipType.RotateNoneFlipY);
                btn.BackgroundImage = part;
            }
            else
            {
                btn.BackgroundImage = part;
            }
        }
        public void ShowMove(Button btn, int Player)
        {
            Figure figure = listFigure[btn.Location.X / 100, btn.Location.Y / 100];
            if (figure != null)
            {
                string[] FootStep = figure.CanMove().Split('|');
                btn.BackColor = Color.Red;
                for (int i = 0; i < FootStep.Length; i++)
                {
                    string[] Step = FootStep[i].Split(',');
                    int X = Convert.ToInt32(Step[0]);
                    int Y = Convert.ToInt32(Step[1]);
                    if (figure.LocationX + X >= 0 && figure.LocationX + X < 6 && figure.LocationY + Y >= 0 && figure.LocationY + Y < 6)
                    {
                        if (listFigure[figure.LocationX + X, figure.LocationY + Y] == null)
                        {
                            buttons[figure.LocationX + X, figure.LocationY + Y].Enabled = true;
                            buttons[figure.LocationX + X, figure.LocationY + Y].BackColor = Color.Yellow;
                        }
                    }
                }
            }

        }
        private void OnFigurePress(object sender, EventArgs e)
        {
            Button pressedButton = sender as Button;
            if (Summon) //triệu hồi
            {
                if (PreDuke < 2)
                {
                    Summoner(pressedButton, "Duke", currPlayer);
                    PreDuke++;
                    SwitchPlayer();
                    DeactivateAllButtons();
                    ActiveButtonsFirstTime();
                }
                else if (PreFootMan < 4)
                {
                    Summoner(pressedButton, "Footman", currPlayer);
                    PreFootMan++;
                    SwitchPlayer();
                    DeactivateAllButtons();
                    ActiveButtonsFirstTime();
                }
                else
                {
                    Summoner(pressedButton, GetRamdomFigure(), currPlayer);
                    SwitchPlayer();
                }
            }
            else //di chuyển
            {
                if (pressedButton.Enabled && pressedButton.BackColor == Color.Red)
                {

                }
                else
                {
                    ChangeFigureMove();
                    ShowMove(pressedButton, currPlayer);

                }
            }
            if (PreDuke == 2 && PreFootMan == 4 && Summon) //triệu hồi đầu game
            {
                Summon = false;
                ChangeFigureMove();
            }
        }
        public void SwitchPlayer()
        {
            if (currPlayer == 1)
                currPlayer = 2;
            else currPlayer = 1;
            lblPlayerMove.Text = "Next Move:\n Player " + currPlayer;
        }
        public string GetRamdomFigure()
        {
            string figure;
            if (currPlayer == 1)
            {
                if (Player1Figure.Count > 0)
                {
                    Random random = new Random();
                    int randomIndex = random.Next(0, Player1Figure.Count); // Lấy chỉ số ngẫu nhiên trong danh sách
                    figure = Player1Figure[randomIndex]; // Lấy ra quân cờ tại chỉ số ngẫu nhiên
                    Player1Figure.RemoveAt(randomIndex);

                }
                else figure = "";
            }
            else
            {
                if (Player2Figure.Count > 0)
                {
                    Random random = new Random();
                    int randomIndex = random.Next(0, Player2Figure.Count); // Lấy chỉ số ngẫu nhiên trong danh sách
                    figure = Player2Figure[randomIndex]; // Lấy ra quân cờ tại chỉ số ngẫu nhiên
                    Player2Figure.RemoveAt(randomIndex);
                }
                else figure = "";
            }
            return figure;
        }
        public void DeactivateAllButtons()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    buttons[i, j].Enabled = false;
                }
            }
        }
        public void ActiveButtonsFirstTime()
        {
            for (int i = 0; i < 6; i++)
            {
                if (currPlayer == 1 && listFigure[i, 5] == null)
                {
                    buttons[i, 5].Enabled = true;
                }
                else if (currPlayer == 2 && listFigure[i, 0] == null)
                {
                    buttons[i, 0].Enabled = true;
                }
            }
        }

        public void ChangeFigureMove()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    buttons[i, j].BackColor = Color.White;
                    if (listFigure[i, j] != null && listFigure[i, j].Side == currPlayer)
                    {
                        buttons[i, j].Enabled = true;
                    }
                    else buttons[i, j].Enabled = false;
                }
            }
        }
    }
}
