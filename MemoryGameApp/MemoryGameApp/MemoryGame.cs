using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGameApp
{
    public partial class MemoryGame : Form
    {
        List<Button> lstbuttons;
        List<List<Button>> lstmatchingsets;

        Button btn1test = new();
        Button btn2test = new();

        // dictionary<String, Color> colorMatches
        // private void SetColors{
        // foreach btn in lstbuttons
        //      color rnd = GetRandomColor();
        //      colorMatches.Add(btn.Name, color)
        //      otherBtn = .Where 

        //}
        public MemoryGame()
        {
            InitializeComponent();
            lstbuttons = new() { btn11, btn12, btn13, btn14, btn15, btn16, btn21, btn22, btn23, btn24, btn25, btn26, btn31, btn32, btn33, btn34, btn35, btn36,
                                 btn41, btn42, btn43, btn44, btn45, btn46, btn51, btn52, btn53, btn54, btn55, btn56, btn61, btn62, btn63, btn64,btn65, btn66};
            bStart.Click += BStart_Click;
            bNextTurn.Click += BNextTurn_Click;
            lstbuttons.ForEach(b => b.Click += B_Click);

            lstmatchingsets = new()
            {
                new(){btn33, btn56},
                new(){btn53, btn11},
                new(){btn12, btn46},
                new(){btn13, btn66},
                new(){btn14, btn42},
                new(){btn15, btn64},
                new(){btn16, btn21},
                new(){btn22, btn55},
                new(){btn23, btn52},
                new(){btn24, btn41},
                new(){btn25, btn26},
                new(){btn31, btn36},
                new(){btn32, btn43},
                new(){btn34, btn65},
                new(){btn35, btn63},
                new(){btn44, btn54},
                new(){btn61, btn51},
                new(){btn45, btn62},
            };
            foreach (List<Button> sublist in lstmatchingsets)
            {
                var c = GetRandomBackColor();
                sublist.ForEach(b => b.Tag = c);
            }
        }

        private void NextTurn(Button btn)
        {
            if (btn1test.BackColor != btn2test.BackColor)
            {
                btn1test.BackColor = Color.LightSteelBlue;
                btn2test.BackColor = Color.LightSteelBlue;
            }
            EnableButtons(true);
            int n = 0;
            bool bn = int.TryParse(lblTurnNumber.Text, out n);
            int numturns = n + 1;
            lblTurnNumber.Text = numturns.ToString();
            if (btn.Name.Contains("btn") == false)
            {
                ReSetBtns();
            }
            if (btn.Name.Contains("btn"))
            {
                DoTurn(btn);
            }
        }

        private void BNextTurn_Click(object? sender, EventArgs e)
        {
            NextTurn((Button)sender);
        }

        private void EnableButtons(bool enable)
        {
            lstbuttons.ForEach(b => b.Enabled = enable);
        }

        private void AddOneScore()
        {
            int n = 0;
            bool bn = int.TryParse(lblScoreNum.Text, out n);
            int scorenum = n + 1;
            lblScoreNum.Text = scorenum.ToString();
        }

        private Color GetRandomBackColor(int minr, int maxr, int ming, int maxg, int minb, int maxb)
        {
            Random rnd = new();
            var c = Color.FromArgb(rnd.Next(minr, maxr), rnd.Next(ming, maxg), rnd.Next(minb, maxb));
            return c;
        }

        private Color GetRandomBackColor()
        {
            return GetRandomBackColor(0, 256, 0, 256, 0, 256);
        }

        public void SetButtons(Button btn)
        {
            if (btn1test.Name.Contains("btn"))
            {
                btn2test = btn;
            }
            else
            {
                btn1test = btn;
            }

        }

        public void ReSetBtns()
        {
            btn1test = new();
            btn2test = new();
        }

        private void Winner()
        {
            lblWinner.BringToFront();
            lblWinner.BackColor = Color.Black;
            lblWinner.Text = "Game Over: " + lblTurnNumber.Text + " Tries!!";
            bNextTurn.Enabled = false;
        }

        private void DoTurn(Button btn)
        {
            SetButtons(btn);
            ClickedButtons(btn);
            if (btn2test.Name != "")
            {
                EnableButtons(false);
            }
            if (btn1test == btn11 && btn2test == btn53)
            //if (lstbuttons.TrueForAll(b => b.BackColor != Color.LightSteelBlue))
            {
                Winner();
            }
        }


        private void ClickedButtons(Button btn)
        {
            if (btn == btn1test || btn == btn2test)
            {
                btn.BackColor = (Color)btn.Tag;
            }

            if (btn1test.BackColor == btn2test.BackColor)
            {
                AddOneScore();
            }
            else
            {
                lblScoreNum.Text = lblScoreNum.Text;
            }
        }

        private void Start()
        {
            lblWinner.SendToBack();
            lblWinner.Text = "";
            lblWinner.BackColor = Color.Transparent;
            lstbuttons.ForEach(b => b.Enabled = true);
            lstbuttons.ForEach(b => b.BackColor = Color.LightSteelBlue);
            bNextTurn.Enabled = true;
            lblTurnNumber.Text = "0";
            lblScoreNum.Text = "0";
            lblStartToPlay.Text = "";
        }

        private void B_Click(object? sender, EventArgs e)
        {
            if (sender is Button)
            {
                DoTurn((Button)sender);
            }
        }

        private void BStart_Click(object? sender, EventArgs e)
        {
            Start();
            ReSetBtns();
        }

    }
}
