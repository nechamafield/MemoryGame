using System.Net.Sockets;
using System.Text.RegularExpressions;
using MemoryGameSystem;

namespace MemoryGameApp
{
    public partial class MemoryGame : Form
    {
        Game game = new();
        List<Button> lstbuttons;
        //List<Button> lstRemainingBtns = new();

        Button btn1test = new();
        Button btn2test = new();

        public MemoryGame()
        {
            InitializeComponent();
            lstbuttons = new() { btn11, btn12, btn13, btn14, btn15, btn16, btn21, btn22, btn23, btn24, btn25, btn26, btn31, btn32, btn33, btn34, btn35, btn36,
                                 btn41, btn42, btn43, btn44, btn45, btn46, btn51, btn52, btn53, btn54, btn55, btn56, btn61, btn62, btn63, btn64,btn65, btn66};
            bStart.Click += BStart_Click;
            bNextTurn.Click += BNextTurn_Click;

            lstbuttons.ForEach(b =>
            {
                Spots spots = game.Spot[lstbuttons.IndexOf(b)];
                b.Click += B_Click;
            });

            lblTurnNumber.DataBindings.Add("Text", game, "TurnNumberText");
            lblScoreNum.DataBindings.Add("Text", game, "ScoreText");
            lblStartToPlay.DataBindings.Add("Text", game, "Message");
        }

        private void EnableButtons(bool enable)
        {

            lstbuttons.ForEach(b =>
            {
                if (b.BackColor != Color.LightGray)
                    b.Enabled = enable;
            });
        }

        private void SetSpots(Button btn)
        {
            if (lstbuttons.Contains(btn))
            {
                int num = lstbuttons.IndexOf(btn);
                Spots spot = game.Spot[num];
                if (game.spot1test is null)
                {
                    game.spot1test = spot;
                    game.spot1test.BackColor = spot.ColorfulBackColor;
                    btn.BackColor = spot.BackColor;
                }
                else if (game.spot1test != null && game.spot2test is null)
                {
                    game.spot2test = spot;
                    game.spot2test.BackColor = spot.ColorfulBackColor;
                    btn.BackColor = spot.BackColor;
                    bNextTurn.Enabled = true;
                }
                if (game.spot1test != null && game.spot2test != null)
                {
                    EnableButtons(false);
                }
                game.DoTurn(spot);
            }
            else if (btn == bNextTurn)
            {
                game.NextTurn();
                if (game.spot1test.BackColor != game.spot2test.BackColor)
                {
                    lstbuttons.ForEach(b =>
                    {
                        if (b.BackColor != Color.LightGray)
                        {
                            b.BackColor = Color.LightSteelBlue;
                        }
                    }
                    );
                }
                else if (game.spot1test.BackColor == game.spot2test.BackColor)
                {
                    lstbuttons.ForEach(b =>
                    {
                        if (b.BackColor != Color.LightSteelBlue)
                        {
                            b.BackColor = Color.LightGray;
                        }
                    }
                    );
                }
                game.spot1test = null;
                game.spot2test = null;
                EnableButtons(true);
            }
        }

        private void StartGame()
        {
            if (lblStartToPlay.Text == "WARNING: Clicking Start Will Restart The Game" || lblStartToPlay.Text == "Click Start To Play")
            {
                game.Start();
                lstbuttons.ForEach(b => b.BackColor = Color.LightSteelBlue);
                EnableButtons(Enabled);
                game.ResetBtns();
            }
            else
            {
                var response = MessageBox.Show("Are you sure you want to start over?", "Memory Game", MessageBoxButtons.YesNo);
                if (response == DialogResult.No)
                {
                    return;
                }
                Application.UseWaitCursor = true;
                try
                {
                    game.ClearButtons(Color.LightSteelBlue);
                    lstbuttons.ForEach(b => b.Text = "");
                    lblStartToPlay.Text = "WARNING: Clicking Start Will Restart The Game";
                    EnableButtons(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Memory Game");
                }
                finally
                {
                    Application.UseWaitCursor = false;
                }

            }
        }

        private void B_Click(object? sender, EventArgs e)
        {
            if (sender is Button)
            {
                SetSpots((Button)sender);
                if (btn2test is null)
                {
                    EnableButtons(false);
                    bNextTurn.Enabled = true;
                }
            }
        }

        private void BNextTurn_Click(object? sender, EventArgs e)
        {
            if (sender is Button)
            {
                SetSpots((Button)sender);
            }
        }

        private void BStart_Click(object? sender, EventArgs e)
        {
            StartGame();
        }

    }
}
