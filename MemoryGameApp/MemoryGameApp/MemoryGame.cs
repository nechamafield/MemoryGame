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
        enum MatchedEnum { Matched, NotMatched };
        MatchedEnum IfMatched = MatchedEnum.NotMatched;
        public MemoryGame()
        {
            InitializeComponent();
            lstbuttons = new() { btn11, btn12, btn13, btn14, btn15, btn16, btn21, btn22, btn23, btn24, btn25, btn26, btn31, btn32, btn33, btn34, btn35, btn36,
                                 btn41, btn42, btn43, btn44, btn45, btn46, btn51, btn52, btn53, btn54, btn55, btn56, btn61, btn62, btn63, btn64,btn65, btn66};
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

        private void BtnNextTurn_Click(object? sender, EventArgs e)
        {
            if (sender is Button)
            {
                lstbuttons.ForEach(b => b.Enabled = true);
                DoTurn((Button)sender);
            }
        }

        private void ClickedButtons(Button btn, Button btn1, Button btn2, Color c)
        {
            if (btn == btn1 || btn == btn2)
            {
                btn.BackColor = c;
            }
        }

        private void DoTurn(Button btn)
        {
            ClickedButtons(btn, btn33, btn56, Color.Tan);
            ClickedButtons(btn, btn53, btn11, Color.Sienna);
            ClickedButtons(btn, btn12, btn46, Color.Silver);
            ClickedButtons(btn, btn13, btn66, Color.PowderBlue);
            ClickedButtons(btn, btn14, btn42, Color.Pink);
            ClickedButtons(btn, btn15, btn64, Color.OliveDrab);
            ClickedButtons(btn, btn16, btn21, Color.Peru);
            ClickedButtons(btn, btn22, btn55, Color.Salmon);
            ClickedButtons(btn, btn23, btn52, Color.RosyBrown);
            ClickedButtons(btn, btn24, btn41, Color.Tomato);
            ClickedButtons(btn, btn25, btn26, Color.Violet);
            ClickedButtons(btn, btn31, btn36, Color.Yellow);
            ClickedButtons(btn, btn32, btn43, Color.SpringGreen);
            ClickedButtons(btn, btn34, btn65, Color.SkyBlue);
            ClickedButtons(btn, btn35, btn63, Color.Purple);
            ClickedButtons(btn, btn44, btn54, Color.Orange);
            ClickedButtons(btn, btn61, btn51, Color.MistyRose);
            ClickedButtons(btn, btn45, btn62, Color.Lime);
        }

        private void B_Click(object? sender, EventArgs e)
        {
            if (sender is Button)
            {
                DoTurn((Button)sender);
                lstbuttons.ForEach(b => b.Enabled = false);
            }
        }

        private void BtnStart_Click(object? sender, EventArgs e)
        {
            lstbuttons.ForEach(b => b.Enabled = true);
            lstbuttons.ForEach(b => b.BackColor = Color.LightSteelBlue);
            lblTurnNumber.Text = "0";
            lblScoreNum.Text = "0";
            lblStartToPlay.Text = "";
        }

    }
}
