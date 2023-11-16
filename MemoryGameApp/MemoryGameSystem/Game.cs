using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;


namespace MemoryGameSystem
{
    public class Game : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public enum GameStatusEnum { NotStarted, Playing, NextTurn, Won, Lost }
        public enum SpotColorEnum { SpotNotClicked, SpotClicked, SpotAlreadyMatched }

        private Color _backcolor = Color.Empty;
        private string _turnnumber = ""; 
        private string _score = ""; 
        private string _winner = ""; //bind to lblwinner
        private string _message = ""; //bind to lblclicktostart
        private Color _winnercolor = Color.Black; //bind to lblwinner

        List<List<Spots>> lstMatchingSets = new();
        GameStatusEnum _gamestatus = GameStatusEnum.NotStarted;

        //Spots spot1test = new();
        //Spots spot2test = new();

        public Game()
        {
            for (int i = 0; i <= 36; i++)
            {
                this.Spot.Add(new Spots());
            }

            lstMatchingSets = new()
            {
                new(){this.Spot[0], this.Spot[18]},
                new(){this.Spot[1], this.Spot[19]},
                new(){this.Spot[2], this.Spot[20]},
                new(){this.Spot[3], this.Spot[21]},
                new(){this.Spot[4], this.Spot[22]},
                new(){this.Spot[5], this.Spot[23]},
                new(){this.Spot[6], this.Spot[24]},
                new(){this.Spot[7], this.Spot[25]},
                new(){this.Spot[8], this.Spot[26]},
                new(){this.Spot[9], this.Spot[27]},
                new(){this.Spot[10], this.Spot[28]},
                new(){this.Spot[11], this.Spot[29]},
                new(){this.Spot[12], this.Spot[30]},
                new(){this.Spot[13], this.Spot[31]},
                new(){this.Spot[14], this.Spot[32]},
                new(){this.Spot[15], this.Spot[33]},
                new(){this.Spot[16], this.Spot[34]},
                new(){this.Spot[17], this.Spot[35]},
            };

            foreach (List<Spots> sublist in lstMatchingSets)
            {
                var c = GetRandomBackColor();
                sublist.ForEach(b => b.ColorfulBackColor = c);
            }
        }

        public List<Spots> Spot { get; private set; } = new();

        public Spots spot1test { get; set; } = new();
        public Spots spot2test { get; set; } = new();

        public Color lblWinnerColor { get => this.WinnerColor; }

        public string TurnNumberText { get => $"{this.TurnNumber.ToString()}"; }
        public string ScoreText { get => $"{this.Score.ToString()}"; }

        public Color WinnerColor
        {
            get => _winnercolor;
            set
            {
                _winnercolor = value;
                this.InvokePropertyChanged("lblWinnerColor");
            }
        }

        public string TurnNumber
        {
            get => _turnnumber;
            set
            {
                _turnnumber = value;
                this.InvokePropertyChanged("TurnNumberText");
            }
        }

        public string Score
        {
            get => _score;
            set
            {
                _score = value;
                this.InvokePropertyChanged("ScoreText");
            }
        }

        public string Winner
        {
            get => _winner;
            set
            {
                _winner = value;
                this.InvokePropertyChanged("WinnerLabel");
            }
        }

        private string WinnerLabel { get => $"CONGRATS: {this.TurnNumber.ToString()} TRIES!!"; }

        public GameStatusEnum GameStatus
        {
            get => _gamestatus;
            set
            {
                _gamestatus = value;
                this.InvokePropertyChanged("TurnNumberText");
                this.InvokePropertyChanged("ScoreText");
                this.InvokePropertyChanged("GameStatusDescription");
                this._backcolor = SpotNotClicked;
            }
        }

        private string GameStatusDescription { get => $"{this.GameStatus.ToString()}"; }

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

        public System.Drawing.Color SpotNotClicked { get; set; } = System.Drawing.Color.LightSteelBlue;

        public System.Drawing.Color SpotAlreadyMatched { get; set; } = System.Drawing.Color.Empty;
        public System.Drawing.Color SpotClicked
        {
            get => _backcolor;
            set
            {
                _backcolor = value;
                InvokePropertyChanged();
                InvokePropertyChanged("SpotClickedBackColor");
            }
        }

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                this.InvokePropertyChanged(MessageText());
            }
        }

        public string MessageText()
        {
            string msg = "";
            if (_gamestatus == GameStatusEnum.NotStarted)
            {
                msg = "Click Start to Play";
                TurnNumber = "0";
                Score = "0";
            }
            else if (_gamestatus == GameStatusEnum.NextTurn)
            {
                msg = "";
            }
            else if (_gamestatus == GameStatusEnum.NextTurn)
            {
                msg = "Great Job!";
            }
            if (spot1test.BackColor == spot2test.BackColor)
            {
                msg = "Great Job!";
            }
                return msg;
        }

        public void Start()
        {
            //lblWinner.SendToBack();
            //EnableButtons(true);
            //bNextTurn.Enabled = false;
            _winner = "";
            _winnercolor = Color.Transparent;
            Spot.ForEach(b => b.BackColor = b.BlueBackColor);
            //this.Spot.ForEach(b => b.ClearSpots());
            this.GameStatus = GameStatusEnum.NotStarted;
            MessageText();
        }

        public void SetButtons(Spots btn)
        {
            //if (spot1test.BackColor == btn.ColorfulBackColor)
            //{
            //    btn = spot2test;
            //}
            //else
            //{
            //    spot1test = btn;
            //    btn.ColorfulBackColor = spot1test.ColorfulBackColor;
            //    spot1test.ColorfulBackColor = spot1test.BackColor;
            //}
            if (spot1test.ToString().Contains("btn"))
            {
                spot2test = btn;
            }
            else
            {
                spot1test = btn;
            }
        }

        private void AddOneScore()
        {
            int n = 0;
            bool bn = int.TryParse(_score, out n);
            int scorenum = n + 1;
            _score = scorenum.ToString();
        }

        private void ClickedButtons(Spots btn)
        {
            //bNextTurn.Enabled = false;
            if (btn == spot1test || btn == spot2test)
            {
                btn.BackColor = btn.ColorfulBackColor;
            }

            if (spot1test.BackColor == spot2test.BackColor && spot1test.BackColor == btn.ColorfulBackColor)
            {
                AddOneScore();
            }
            else
            {
                _score = _score;
            }
        }

        public void ClearButtons(Color c)
        {
            spot1test.BackColor = c;
            spot2test.BackColor = c;
            //btn1test = "";
            //btn2test = "";
        }

        private void WonGame()
        {
            ClearButtons(Color.Empty);
            //lblWinner.BringToFront();
            _winnercolor = Color.Black;
            //bNextTurn.Enabled = false;
        }

        public void DoTurn(Spots spot)
        {
            SetButtons(spot);
            ClickedButtons(spot);
            if (spot2test.ToString() != "")
            {
                //EnableButtons(false);
                //bNextTurn.Enabled = true;
            }
            if (Spot.TrueForAll(b => b.BackColor != b.BlueBackColor))
            {
                WonGame();
            }
        }

        public void ResetBtns()
        {
            spot1test = new();
            spot2test = new();
        }

        public void NextTurn(Spots btn)
        {
            MessageText();
            //bNextTurn.Enabled = false;
            if (spot1test.BackColor != spot2test.BackColor)
            {
                ClearButtons(Color.LightSteelBlue);
            }
            else if (spot1test.BackColor == spot2test.BackColor)
            {
                ClearButtons(Color.Empty);
            }
            foreach (Spots b in Spot)
            {
                if (b.BackColor == Color.LightSteelBlue)
                {
                    //b.Enabled = true;
                }
            }
            int n = 0;
            bool bn = int.TryParse(TurnNumber, out n);
            int numturns = n + 1;
            TurnNumber = numturns.ToString();
            if (Spot.ToString().Contains("btn") == false)
            {
                ResetBtns();
            }
            if (Spot.ToString().Contains("btn"))
            {
               this.DoTurn(btn);
            }
        }

        private void InvokePropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

    }
}
