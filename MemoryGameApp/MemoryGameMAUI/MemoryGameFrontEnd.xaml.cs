using MemoryGameSystem;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static MemoryGameSystem.Game;

namespace MemoryGameMAUI;


public partial class MemoryGameFrontEnd : ContentPage
{
    public event EventHandler? ScoreChanged;

    public enum GameRBEnum { game1, game2, game3 }

    GameRBEnum _gamerb = GameRBEnum.game1;

    Game game;
    List<Game> lstgame = new() { new Game(), new Game(), new Game() };
    List<Button> lstbuttons;
    List<RadioButton> lstrb;
    Color blue = Color.FromArgb("ACE2FF");
    Color gray = Color.FromArgb("D4D4D4");

    public static int game1score;
    public static int game2score;
    public static int game3score;

    public int gamescore;

    public MemoryGameFrontEnd()
    {
        InitializeComponent();
        ScoreChanged += G_ScoreChanged;
        Game1Rb.BindingContext = lstgame[0];
        Game2Rb.BindingContext = lstgame[1];
        Game3Rb.BindingContext = lstgame[2];
        game = lstgame[0];
        this.BindingContext = game;
        lstbuttons = new() { btn11, btn12, btn13, btn14, btn15, btn16, btn21, btn22, btn23, btn24, btn25, btn26, btn31, btn32, btn33, btn34, btn35, btn36,
                                 btn41, btn42, btn43, btn44, btn45, btn46, btn51, btn52, btn53, btn54, btn55, btn56, btn61, btn62, btn63, btn64,btn65, btn66};
        lstbuttons.ForEach(b => b.BackgroundColor = blue);
        lstrb = new() { Game1Rb, Game2Rb, Game3Rb };
        EnableButtons(false);
        bNextTurn.IsEnabled = false;
    }

    Button btn1test = new();
    Button btn2test = new();

    public GameRBEnum GameRb { get; set; }

    public string ScoreMAUI
    {
        get
        {
            string s = $"SCORE = {this.gamescore} ";
            //switch (this.GameRb)
            //{
            //    case GameRBEnum.game1:
            //        s = s + game1score.ToString();
            //        break;
            //    case GameRBEnum.game2:
            //        s = s + game2score.ToString();
            //        break;
            //    case GameRBEnum.game3:
            //        s = s + game3score.ToString();
            //        break;
            //}

            //string s = "SCORE = ";
            //if (GameRb == GameRBEnum.game1)
            //{
            //    s = s + game1score.ToString();
            //}
            //else if (GameRb == GameRBEnum.game2)
            //{
            //    s = s + game2score.ToString();
            //}
            //else if (GameRb == GameRBEnum.game3)
            //{
            //    s = s + game3score.ToString();
            //}
            return s;
        }
    }

    //Game 1 = {game1score}:   Game 2 = {game2score}:  Game 3 = {game3score} "; }

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
                btn.BackgroundColor = spot.BackColorMaui;
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
            Spots spot = new();
            game.NextTurn();
            if (game.spot1test.BackColor != game.spot2test.BackColor)
            {
                lstbuttons.ForEach(b =>
                {
                    if (b.BackgroundColor != gray)
                    {
                        b.BackgroundColor = blue;
                    }
                });
                game.Spot.ForEach(s =>
                {
                    if (s.BackColorMaui != gray)
                    {
                        s.BackColorMaui = blue;
                    }
                });

                //game.spot1test.BackColor = spot.BlueBackColor;
                //game.spot2test.BackColor = spot.BlueBackColor;

            }

            if (game.spot1test.BackColor == game.spot2test.BackColor)
            {
                if (Game1Rb.IsChecked == true)
                {
                    GameRb = GameRBEnum.game1;
                    game1score++;
                    gamescore = 0;
                    gamescore = game1score;
                }
                else if (Game2Rb.IsChecked == true)
                {
                    GameRb = GameRBEnum.game2;
                    game2score++;
                    gamescore = 0;
                    gamescore = game2score;
                }
                else if (Game3Rb.IsChecked == true)
                {
                    GameRb = GameRBEnum.game3;
                    game3score++;
                    gamescore = 0;
                    gamescore = game3score;
                }
                ScoreChanged?.Invoke(this, new EventArgs());
                lstbuttons.ForEach(b =>
                {
                    if (b.BackgroundColor != blue)
                    {
                        b.BackgroundColor = gray;
                    }
                }
                );
                game.Spot.ForEach(s =>
                {
                    if (s.BackColorMaui != blue)
                    {
                        s.BackColor = s.GrayBackColor;
                    }
                });
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

    private void NextTurn(Button btn)
    {
        Spots spot = new();
        game.NextTurn();
        if (btn == bNextTurn)
        {
            if (game.spot1test.BackColor != game.spot2test.BackColor)
            {
                lstbuttons.ForEach(b =>
                {
                    if (b.BackgroundColor != gray)
                    {
                        b.BackgroundColor = blue;
                    }
                });
                game.Spot.ForEach(s =>
                {
                    if (s.BackColorMaui != blue)
                    {
                        s.BackColor = s.GrayBackColor;
                    }
                });

                //game.spot1test.BackColor = spot.BlueBackColor;
                //game.spot2test.BackColor = spot.BlueBackColor;

            }
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
            //lblScore.Text = "";
            lstbuttons.ForEach(b => b.BackgroundColor = blue);
            EnableButtons(IsEnabled);
            bNextTurn.IsEnabled = false;
            game.ResetBtns();
        }
        else
        {
            try
            {
                game.ClearButtons(System.Drawing.Color.LightSteelBlue);
                lstbuttons.ForEach(b => b.Text = "");
                lblStartToPlay.Text = "WARNING: Clicking Start Will Restart The Game";
                EnableButtons(false);
            }
            catch (Exception ex) { }
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
            //SetSpots((Button)sender);
            NextTurn((Button)sender);
        }
    }

    private void Game_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        RadioButton rb = (RadioButton)sender;
        if (rb.IsChecked == true && rb.BindingContext != null)
        {
            game = (Game)rb.BindingContext;
            foreach (var item in game.Spot)
            {
                var ind = game.Spot.IndexOf(item);
                //lstbuttons.ForEach(b => b.BackgroundColor = item.BackColorMaui);
                lstbuttons[ind].BackgroundColor = item.BackColorMaui;
            }
            this.BindingContext = game;
        }
        // StartGame();
    }

    private void G_ScoreChanged(object sender, EventArgs e)
    {
        lblScore.Text = ScoreMAUI;
    }

}

