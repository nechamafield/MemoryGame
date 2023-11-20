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
        public enum GameStatusEnum { NotStarted, Playing, NextTurn, Won}
        public enum SpotColorEnum { SpotNotClicked, SpotClicked, SpotAlreadyMatched }

        private Color _backcolor = Color.Empty;
        private string _turnnumber = ""; 
        private string _score = ""; 

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
            GameStatus = GameStatusEnum.NotStarted;
        }

        public List<Spots> Spot { get; private set; } = new();

        public Spots? spot1test { get; set; }
        public Spots? spot2test { get; set; }
        public string TurnNumberText { get => $"{this.TurnNumber.ToString()}"; }
        public string ScoreText { get => this.Score.ToString(); }


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

        public GameStatusEnum GameStatus
        {
            get => _gamestatus;
            set
            {
                _gamestatus = value;
                this.InvokePropertyChanged("TurnNumberText");
                this.InvokePropertyChanged("ScoreText");
                this.InvokePropertyChanged("Message");
            }
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
            get
            {
                string s = "";
                switch (this.GameStatus)
                {
                    case GameStatusEnum.NotStarted:
                        s = "Click Start To Play";
                        break;
                    case GameStatusEnum.Playing:
                        s = "";
                        break;
                    case GameStatusEnum.NextTurn:
                        s = "Great Job!!";
                        break;
                    case GameStatusEnum.Won:
                        s = $"CONGRATS: {this.TurnNumber} TRIES!!";
                        break;
                }
                return s;
            }
        }

        public void Start()
        {
            TurnNumber = "0";
            Score = "0";
            Spot.ForEach(b => b.BackColor = b.BlueBackColor);
            this.GameStatus = GameStatusEnum.Playing;
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
            if (spot2test != null)
            {
                if (spot1test.BackColor == spot2test.BackColor)
                {
                    AddOneScore();
                }
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
        }

        private void WonGame()
        {
            GameStatus = GameStatusEnum.Won;
            ClearButtons(Color.Empty);
        }

        public void DoTurn(Spots spot)
        {
            ClickedButtons(spot);
            if (Spot.TrueForAll(b => b.BackColor == Color.LightGray))
            {
                WonGame();
            }
            
        }

        public void ResetBtns()
        {
            spot1test = null;
            spot2test = null;
        }

        public void NextTurn()
        {
            GameStatus = GameStatusEnum.NextTurn;
            if(spot1test.BackColor == spot2test.BackColor)
            {
                GameStatus = GameStatusEnum.NextTurn;
            }
            else if (spot1test.BackColor != spot2test.BackColor)
            {
                GameStatus = GameStatusEnum.Playing;
            }
            int n = 0;
            bool bn = int.TryParse(TurnNumber, out n);
            int numturns = n + 1;
            TurnNumber = numturns.ToString();
        }

        private void InvokePropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

    }
}
