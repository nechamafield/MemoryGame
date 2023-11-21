using MemoryGameSystem;
using System.Diagnostics;

namespace MemoryGameMAUI;


public partial class MemoryGameFrontEnd : ContentPage
{
    public event EventHandler? ScoreChanged;

    Game game;// = new();
    Game activegame;
    List<Game> lstgame = new() { new Game(), new Game(), new Game() };
    List<Button> lstbuttons;
    Color blue = Color.FromArgb("ACE2FF");
    Color gray = Color.FromArgb("D4D4D4");

    public static int game1score;
    public static int game2score;
    public static int game3score;

    public MemoryGameFrontEnd()
    {
        InitializeComponent();
        //lstgame.ForEach(g => g.ScoreChanged += G_ScoreChanged);
        ScoreChanged += G_ScoreChanged;
        Game1Rb.BindingContext = lstgame[0];
        Game2Rb.BindingContext = lstgame[1];
        Game3Rb.BindingContext = lstgame[2];
        game = lstgame[0];
        //activegame = lstgame[0];
        this.BindingContext = game;
        lstbuttons = new() { btn11, btn12, btn13, btn14, btn15, btn16, btn21, btn22, btn23, btn24, btn25, btn26, btn31, btn32, btn33, btn34, btn35, btn36,
                                 btn41, btn42, btn43, btn44, btn45, btn46, btn51, btn52, btn53, btn54, btn55, btn56, btn61, btn62, btn63, btn64,btn65, btn66};
        lstbuttons.ForEach(b => b.BackgroundColor = blue);
    }

    Button btn1test = new();
    Button btn2test = new();

    public static string ScoreMAUI { get => $"      SCORES: Game 1 = {game1score}:   Game 2 = {game2score}:  Game 3 = {game3score} "; }

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
                    if (b.BackgroundColor != gray) 
                    {
                        b.BackgroundColor = blue;
                        if(Game1Rb.IsChecked == true)
                        {
                            
                        }
                    }
                }
                );
            }
            else if (game.spot1test.BackColor == game.spot2test.BackColor)
            {
                lstbuttons.ForEach(b =>
                {
                    if (b.BackgroundColor != blue)
                    {
                        b.BackgroundColor = gray;
                        if(Game1Rb.IsChecked == true)
                        {
                            game1score++;
                        }
                        else if (Game2Rb.IsChecked == true)
                        {
                            game2score++;
                        }
                        else if (Game3Rb.IsChecked == true)
                        {
                            game3score++;
                        }
                        ScoreChanged?.Invoke(this, new EventArgs());
                    }
                }
                );
            }
            if (lstbuttons.TrueForAll(b => b.BackgroundColor == gray))
            {
                game.GameStatus = Game.GameStatusEnum.Won;
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
            if (b.BackgroundColor != gray) 
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
            lstbuttons.ForEach(b => b.BackgroundColor = blue); 
            EnableButtons(IsEnabled);
            game.ResetBtns();
        }
        else
        {
            game.ClearButtons(System.Drawing.Color.LightSteelBlue);
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

    private void Game_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        RadioButton rb = (RadioButton)sender;
        if (rb.IsChecked == true && rb.BindingContext != null)
        {
            game = (Game)rb.BindingContext;
            this.BindingContext = game;
            //activegame = (Game)rb.BindingContext;
            //this.BindingContext = activegame;
        }
    }

    private void G_ScoreChanged(object sender, EventArgs e)
    {
        lblScore.Text = ScoreMAUI;
    }
}

