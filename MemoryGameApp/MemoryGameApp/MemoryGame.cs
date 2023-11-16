using System.Text.RegularExpressions;
using MemoryGameSystem;

namespace MemoryGameApp
{
    public partial class MemoryGame : Form
    {
        Game game = new();
        List<Button> lstbuttons;
        //List<List<Button>> lstmatchingsets;
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
            //lstbuttons.ForEach(b => b.Click += B_Click);

            ////now, the matching sets are hard coded in.
            ////should really have a list of all buttons, and another list of buttons remaining - (that are not yet in a set)
            ////lstRemainingBtns = lstbuttons.ToList()  
            ////should get a random color and assign 2 random buttons from the lstButtonsRemaining
            ////then, it should remove those buttons from lstButtonRemaining, but make sure that they are not removed from lstButtons.
            //// the way to see if there is a winner should be to see if the colors match - not if the buttons match in the set
            ////private void AssignColors()
            //// {
            ////  while (lstRemainingBtns.Count > 1)
            ////  {
            ////      Color c = GetRandomBackColor();
            ////      assign 2 random btns from lstButtonsRemaining to that color
            ////      remove those buttons from lstRemainingButtons

            ///*
            ////List of Lists
            ////List of Match => new class
            ////    Property SetBackcolor => set both buttons to have the same backcolor

            ////lstmatchingsets = new()
            ////{
            ////    new Match(){btnMatch1 = btn33, btnMatch2 = btn56}
            ////}
            ////*/


            //lstmatchingsets = new()
            //{
            //    new List<Button>(){btn33, btn56},
            //    new(){btn53, btn11},
            //    new(){btn12, btn46},
            //    new(){btn13, btn66},
            //    new(){btn14, btn42},
            //    new(){btn15, btn64},
            //    new(){btn16, btn21},
            //    new(){btn22, btn55},
            //    new(){btn23, btn52},
            //    new(){btn24, btn41},
            //    new(){btn25, btn26},
            //    new(){btn31, btn36},
            //    new(){btn32, btn43},
            //    new(){btn34, btn65},
            //    new(){btn35, btn63},
            //    new(){btn44, btn54},
            //    new(){btn61, btn51},
            //    new(){btn45, btn62},
            //};
            //foreach (List<Button> sublist in lstmatchingsets)
            //{
            //    var c = GetRandomBackColor();
            //    sublist.ForEach(b => b.Tag = c);
            //}


            lstbuttons.ForEach(b =>
            {
                Spots spots = game.Spot[lstbuttons.IndexOf(b)];
                b.Click += B_Click;
            });

            lblTurnNumber.DataBindings.Add("Text", game, "TurnNumberText");
            lblScoreNum.DataBindings.Add("Text", game, "ScoreText");
            //lblWinner.DataBindings.Add("Color", game, "lblWinnerColor");
            //lblWinner.DataBindings.Add("Text", game, "WinnerLabel");
        }

        //private void NextTurn(Button btn)
        //{
        //    lblStartToPlay.Text = "";
        //    bNextTurn.Enabled = false;
        //    if (btn1test.BackColor != btn2test.BackColor)
        //    {
        //        ClearButtons(Color.LightSteelBlue);
        //    }
        //    else if (btn1test.BackColor == btn2test.BackColor)
        //    {
        //        ClearButtons(Color.Empty);
        //    }
        //    foreach (Button b in lstbuttons)
        //    {
        //        if (b.BackColor == Color.LightSteelBlue)
        //        {
        //            b.Enabled = true;
        //        }
        //    }
        //    int n = 0;
        //    bool bn = int.TryParse(lblTurnNumber.Text, out n);
        //    int numturns = n + 1;
        //    lblTurnNumber.Text = numturns.ToString();
        //    if (btn.Name.Contains("btn") == false)
        //    {
        //        ReSetBtns();
        //    }
        //    if (btn.Name.Contains("btn"))
        //    {
        //        DoTurn(btn);
        //    }
        //}

        private void BNextTurn_Click(object? sender, EventArgs e)
        {
            //NextTurn((Button)sender);
            game.NextTurn((Spots)sender);
        }

        private void EnableButtons(bool enable)
        {
            lstbuttons.ForEach(b => b.Enabled = enable);
        }

        //private void AddOneScore()
        //{
        //    int n = 0;
        //    bool bn = int.TryParse(lblScoreNum.Text, out n);
        //    int scorenum = n + 1;
        //    lblScoreNum.Text = scorenum.ToString();
        //}

        //private Color GetRandomBackColor(int minr, int maxr, int ming, int maxg, int minb, int maxb)
        //{
        //    Random rnd = new();
        //    var c = Color.FromArgb(rnd.Next(minr, maxr), rnd.Next(ming, maxg), rnd.Next(minb, maxb));
        //    return c;
        //}

        //private Color GetRandomBackColor()
        //{
        //    return GetRandomBackColor(0, 256, 0, 256, 0, 256);
        //}

        //public void SetButtons(Button btn)
        //{
        //    if (btn1test.Name.Contains("btn"))
        //    {
        //        btn2test = btn;
        //    }
        //    else
        //    {
        //        btn1test = btn;
        //    }
        //}

        private void ClearButtons(Color c)
        {
            btn1test.BackColor = c;
            btn2test.BackColor = c;
            btn1test.Text = "";
            btn2test.Text = "";
        }

        public void ReSetBtns()
        {
            btn1test = new();
            btn2test = new();
        }

        //private void WonGame()
        //{
        //    ClearButtons(Color.Empty);
        //    lblWinner.BringToFront();
        //    lblWinner.BackColor = Color.Black;
        //    lblWinner.Text = "CONGRATS: " + lblTurnNumber.Text + " TRIES!!";
        //    bNextTurn.Enabled = false;
        //}

        //private void DoTurn(Button btn)
        //{
        //    SetButtons(btn);
        //    ClickedButtons(btn);
        //    if (btn2test.Name != "")
        //    {
        //        EnableButtons(false);
        //        bNextTurn.Enabled = true;
        //    }
        //    if (lstbuttons.TrueForAll(b => b.BackColor != Color.LightSteelBlue))
        //    {
        //        WonGame();
        //    }
        //}

        //private void ClickedButtons(Button btn)
        //{
        //    bNextTurn.Enabled = false;
        //    if (btn == btn1test || btn == btn2test)
        //    {
        //        btn.BackColor = (Color)btn.Tag;
        //        //btn.Text = btn.Tag.ToString(); - will write the color name on the button
        //    }

        //    if (btn1test.BackColor == btn2test.BackColor)
        //    {
        //        lblStartToPlay.Text = "GREAT JOB!";
        //        AddOneScore();
        //    }
        //    else
        //    {
        //        lblScoreNum.Text = lblScoreNum.Text;
        //    }
        //}

        //private void Start()
        //{
        //    lblWinner.SendToBack();
        //    lblWinner.Text = "";
        //    lblWinner.BackColor = Color.Transparent;
        //    EnableButtons(true);
        //    lstbuttons.ForEach(b => b.BackColor = Color.LightSteelBlue);
        //    bNextTurn.Enabled = false;
        //    lblTurnNumber.Text = "0";
        //    lblScoreNum.Text = "0";
        //    lblStartToPlay.Text = "";
        //}

        private void DoTurnButton(Button btn)
        {
            int num = lstbuttons.IndexOf(btn);
            Spots spot = game.Spot[num];
            btn.BackColor = spot.BackColor;
            game.DoTurn(spot);
            //game.DoTurn(spot);
            if (btn2test.Name != "")
            {
                EnableButtons(false);
                bNextTurn.Enabled = true;
            }
        }

        private void B_Click(object? sender, EventArgs e)
        {
            if (sender is Button)
            {
                //DoTurn((Button)sender);
                DoTurnButton((Button)sender);
            }
        }

        private void BStart_Click(object? sender, EventArgs e)
        {
            if (lblStartToPlay.Text == "WARNING: Clicking Start Will Restart The Game" || lblStartToPlay.Text == "Click Start To Play")
            {
                game.Start();
                EnableButtons(Enabled);
                game.ResetBtns();
            }
            else
            {
                game.ClearButtons(Color.LightSteelBlue);
                lstbuttons.ForEach(b => b.Text = "");
                lblStartToPlay.Text = "WARNING: Clicking Start Will Restart The Game";
                EnableButtons(false);
            }
        }

    }
}
