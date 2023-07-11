using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        List<Color> lstcolor;
        enum MatchedEnum { Matched, NotMatched };
        MatchedEnum IfMatched = MatchedEnum.NotMatched;

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
            lstcolor = new() { Color.Tan, Color.Sienna, Color.Silver , Color.PowderBlue, Color.Pink, Color.OliveDrab, Color.Peru, Color.Salmon, Color.RosyBrown, 
                                Color.Tomato,Color.Violet ,Color.Yellow ,Color.SpringGreen ,Color.SkyBlue ,Color.Purple ,Color.Orange,Color.MistyRose ,Color.Lime };
            btnStart.Click += BtnStart_Click;
            btnNextTurn.Click += BtnNextTurn_Click;
            lstbuttons.ForEach(b => b.Click += B_Click);

            //lstmatchingsets = new()
            //{
            //    new(){btn33, btn56},
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

        }

        private void NextTurn()
        {
            EnableButtons(true);
            int n = 0;
            bool bn = int.TryParse(lblTurnNumber.Text, out n);
            int numturns = n + 1;
            lblTurnNumber.Text = numturns.ToString();
            
        }

        private void BtnNextTurn_Click(object? sender, EventArgs e)
        {
            if (sender is Button)
            {
                NextTurn();
            }
        }

        private void EnableButtons(bool enable)
        {
            lstbuttons.ForEach(b => b.Enabled = enable);
        }

        private void ClickedButtons(Button btn, Button btn1, Button btn2, Color c)
        {
            if (btn == btn1 || btn == btn2)
            {
                btn.BackColor = c;
            }
            //every time click next turn the score goes up?
            if (btn1.BackColor == btn2.BackColor && btn1.BackColor == c)//)
            {
                //var lst = Color.where
                int n = 0;
                bool bn = int.TryParse(lblScoreNum.Text, out n);
                int scorenum = n + 1;
                lblScoreNum.Text = scorenum.ToString();
                //add c to list alreadymatched
            }
        }

        private void DoTurn(Button btn)
        {
            ClickedButtons(btn, btn33, btn56, lstcolor[0]);
            ClickedButtons(btn, btn53, btn11, lstcolor[2]);
            ClickedButtons(btn, btn12, btn46, lstcolor[3]);
            ClickedButtons(btn, btn13, btn66, lstcolor[4]);
            ClickedButtons(btn, btn14, btn42, lstcolor[5]);
            ClickedButtons(btn, btn15, btn64, lstcolor[6]);
            ClickedButtons(btn, btn16, btn21, lstcolor[7]);
            ClickedButtons(btn, btn22, btn55, lstcolor[8]);
            ClickedButtons(btn, btn23, btn52, lstcolor[9]);
            ClickedButtons(btn, btn24, btn41, lstcolor[10]);
            ClickedButtons(btn, btn25, btn26, lstcolor[11]);
            ClickedButtons(btn, btn31, btn36, lstcolor[12]);
            ClickedButtons(btn, btn32, btn43, lstcolor[13]);;
            ClickedButtons(btn, btn34, btn65, lstcolor[14]);
            ClickedButtons(btn, btn35, btn63, lstcolor[15]);
            ClickedButtons(btn, btn44, btn54, lstcolor[16]);
            ClickedButtons(btn, btn61, btn51, lstcolor[17]);
            ClickedButtons(btn, btn45, btn62, lstcolor[1]);
            if (lstbuttons.Count(b => b.BackColor != Color.LightSteelBlue) >= 2)
            {
                EnableButtons(false);
            }
        }

        private void B_Click(object? sender, EventArgs e)
        {
            if (sender is Button)
            {
                DoTurn((Button)sender);
            }
        }

        private void BtnStart_Click(object? sender, EventArgs e)
        {
            lstbuttons.ForEach(b => b.Enabled = true);
            lstbuttons.ForEach(b => b.BackColor = Color.LightSteelBlue);
            btnNextTurn.Enabled = true;
            lblTurnNumber.Text = "0";
            lblScoreNum.Text = "0";
            lblStartToPlay.Text = "";
        }

    }
}
