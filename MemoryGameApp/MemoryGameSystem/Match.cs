using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGameSystem
{
    public class Match : Game, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        //public enum SpotColorEnum { SpotNotClicked, SpotClicked, SpotAlreadyMatched }
        SpotColorEnum _spotcolor = SpotColorEnum.SpotNotClicked;

        //public Spots()
        //{
        //    //initializer
        //}


        public System.Drawing.Color SpotNotClicked { get; set; } = System.Drawing.Color.LightSteelBlue;
        public System.Drawing.Color SpotAlreadyMatched { get; set; } = System.Drawing.Color.Empty;
        public System.Drawing.Color SpotClicked { get; set; }

    }
}
