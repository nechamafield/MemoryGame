using MemoryGameSystem;
using System.Diagnostics;

namespace MemoryGameMAUI;


public partial class MemoryGameFrontEnd : ContentPage
{
    Game game = new();
    List<Button> lstbuttons;
    Color blue = Color.FromArgb("ACE2FF");
    Color gray = Color.FromArgb("D4D4D4");

public MemoryGameFrontEnd()
    {
        InitializeComponent();
        this.BindingContext = game;
        lstbuttons = new() { btn11, btn12, btn13, btn14, btn15, btn16, btn21, btn22, btn23, btn24, btn25, btn26, btn31, btn32, btn33, btn34, btn35, btn36,
                                 btn41, btn42, btn43, btn44, btn45, btn46, btn51, btn52, btn53, btn54, btn55, btn56, btn61, btn62, btn63, btn64,btn65, btn66};
        lstbuttons.ForEach(b => b.BackgroundColor = blue);
    }

    Button btn1test = new();
    Button btn2test = new();

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
                btn.BackgroundColor = spot.BackColorMaui;
            }
            else if (game.spot1test != null && game.spot2test is null)
            {
                game.spot2test = spot;
                game.spot2test.BackColor = spot.ColorfulBackColor;
                btn.BackgroundColor = spot.BackColorMaui ;
                bNextTurn.IsEnabled = true;
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
                    if (b.BackgroundColor != gray) //gray
                    {
                        b.BackgroundColor = blue; //blue
                    }
                }
                );
            }
            else if (game.spot1test.BackColor == game.spot2test.BackColor)
            {
                lstbuttons.ForEach(b =>
                {
                    if (b.BackgroundColor != blue) //blue
                    {
                        Debug.Print(b.BackgroundColor.ToString());
                        b.BackgroundColor = gray; //gray
                    }
                    else
                    {
                        Debug.Print("not the same");
                    }
                    //else
                    //{
                    //    b.BackgroundColor = Color.FromArgb("ACE2FF"); //blue
                    //}
                }
                );
                //Spots spot = new();
                //game.spot1test.BackColor = spot.GrayBackColor;
                //game.spot2test.BackColor = spot.GrayBackColor;
                //btn.BackgroundColor = spot.GrayBackColorMaui;
            }
            game.spot1test = null;
            game.spot2test = null;
            EnableButtons(true);
        }
    }

    private void EnableButtons(bool enable)
    {
        lstbuttons.ForEach(b =>
        {
            if (b.BackgroundColor != Color.FromArgb("D4D4D4")) //gray
            { 
                b.IsEnabled = enable;
            }
        });
    }

    private void StartGame()
    {
        if (lblStartToPlay.Text == "WARNING: Clicking Start Will Restart The Game" || lblStartToPlay.Text == "Click Start To Play")
        {
            game.Start();
            lstbuttons.ForEach(b => b.BackgroundColor = Color.FromArgb("ACE2FF")); //blue
            EnableButtons(IsEnabled);
            game.ResetBtns();
        }
        else
        {
            //game.ClearButtons(c.FromArgb("ACE2FF")); //blue
            lstbuttons.ForEach(b => b.Text = "");
            lblStartToPlay.Text = "WARNING: Clicking Start Will Restart The Game";
            EnableButtons(false);
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        StartGame();
    }

    private void btn_Clicked(object sender, EventArgs e)
    {
        if (sender is Button)
        {
            SetSpots((Button)sender);
            if (btn2test is null)
            {
                EnableButtons(false);
                bNextTurn.IsEnabled = true;
            }
        }
    }

    private void bNextTurn_Clicked(object sender, EventArgs e)
    {
        if (sender is Button)
        {
            SetSpots((Button)sender);
        }
    }
}

