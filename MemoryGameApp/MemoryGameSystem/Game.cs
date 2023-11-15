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

        //SpotColorEnum _spotcolor = SpotColorEnum.SpotNotClicked;
        private Color _backcolor = Color.Empty;
        private string _turnnumber = "";
        private string _score = "";
        private string _winner = "";
        private string _message = "";

        List<List<Spots>> lstMatchingSets = new();
        GameStatusEnum _gamestatus = GameStatusEnum.NotStarted;

        Spots btn1test = new();
        Spots btn2test = new();

        public Game()
        {
            for (int i = 0; i <= 36; i++)
            {
                this.Spot.Add(new Spots());
            }

            lstMatchingSets = new()
            {
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
                new(){this.Spot[18], this.Spot[36]},
            };

            this.Spot.ForEach(b => b.BackColor = this.SpotNotClicked);
        }

        public List<Spots> Spot { get; private set; } = new();


        public string TurnNumberText { get => $"{this.TurnNumber.ToString()}"; }
        public string ScoreText { get => $"{this.Score.ToString()}"; }

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
                this.InvokePropertyChanged("Winner");
            }
        }

        public GameStatusEnum GameStatus
        {
            get => _gamestatus;
            set
            {
                _gamestatus = value;
                this.InvokePropertyChanged("TurnNumberTest");
                this.InvokePropertyChanged("ScoreTest");
                this.InvokePropertyChanged("GameStatusDescription");
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

        public Color SpotClickedBackColor
        {
            get
            {
                Color backcolor = GetRandomBackColor();
                return backcolor;
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
            return msg;
        }

        public void Start()
        {
            //this.Winner = winnner.SendToBack();
            //this.Winner = winner;
            //this.Winner.BackColor = Color.Transparent;
            //EnableButtons(true);
            //lstbuttons.ForEach(b => b.BackColor = Color.LightSteelBlue);
            //bNextTurn.Enabled = false;
            this.Spot.ForEach(b => b.ClearSpots());
            this.GameStatus = GameStatusEnum.NotStarted;
            MessageText();
        }


        private void ClickedButtons(Spots btn)
        {
            //bNextTurn.Enabled = false;
            if (btn == btn1test || btn == btn2test)
            {
                //btn.BackColor = (Color)btn.Tag;
            }

            //if (btn1test.BackColor == btn2test.BackColor)
            //{
            //    lblStartToPlay.Text = "GREAT JOB!";
            //    AddOneScore();
            //}
            //else
            //{
            //    lblScoreNum.Text = lblScoreNum.Text;
            //}
        }

        public void DoTurn()
        {

        }

        public void NextTurn()
        {

        }

        public void DetectMatch()
        {

        }

        private void InvokePropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

    }
}
