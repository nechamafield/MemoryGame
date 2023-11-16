using MemoryGameSystem;
using System;

namespace MemoryGameMAUI;


public partial class MemoryGameFrontEnd : ContentPage
{
    Game game = new();
    List<Button> lstbuttons;

    Button btn1test = new();
    Button btn2test = new();

    public MemoryGameFrontEnd()
    {
        InitializeComponent();
        this.BindingContext = game;
        lstbuttons = new() { btn11, btn12, btn13, btn14, btn15, btn16, btn21, btn22, btn23, btn24, btn25, btn26, btn31, btn32, btn33, btn34, btn35, btn36,
                                 btn41, btn42, btn43, btn44, btn45, btn46, btn51, btn52, btn53, btn54, btn55, btn56, btn61, btn62, btn63, btn64,btn65, btn66};
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        game.Start();
    }

    //private void DoTurnButton(Button btn)
    //{
    //    int num = lstbuttons.IndexOf(btn);
    //    Spots spot = game.Spot[num];
    //    btn.BackColor = spot.BackColor;
    //    game.DoTurn(spot);
    //    if (btn2test.Name != "")
    //    {
    //        //EnableButtons(false);
    //        //bNextTurn.Enabled = true;
    //    }
    //}

    private void btn_Clicked(object sender, EventArgs e)
    {
        //if (sender is Button)
        //{
           // game.DoTurn(lstbuttons.IndexOf((Button)sender));
            //DoTurnButton((Button)sender);
        //}
    }
}

