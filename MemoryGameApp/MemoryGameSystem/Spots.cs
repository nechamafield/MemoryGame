using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGameSystem
{
    public class Spots: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        System.Drawing.Color _backcolor;

        public System.Drawing.Color BackColor { get; set; }

        Game.SpotColorEnum _spotcolor = Game.SpotColorEnum.SpotNotClicked;

        public Game.SpotColorEnum SpotColor
        {
            get => _spotcolor;
            set
            {
                _spotcolor = value;
                this.InvokePropertyChanged();
            }
        }

        public void ClearSpots()
        {
            this.SpotColor = Game.SpotColorEnum.SpotNotClicked;
        }

        private void InvokePropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

  



        //public void SetRandomColorForMatch()
        //{
        //    //get random color
        //    // Match1.Color = Random color
        //    // Match2.Color = Random color
        //}
    }

}
