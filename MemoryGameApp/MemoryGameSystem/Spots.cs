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
    public class Spots : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        System.Drawing.Color _bluebackcolor = Color.LightSteelBlue;

        System.Drawing.Color _colorfulbackcolor;

        System.Drawing.Color _backcolor;

        public System.Drawing.Color BackColor
        {
            get => _backcolor;
            set 
            {
                _backcolor = value;
                this.InvokePropertyChanged();
                this.InvokePropertyChanged("BackColorMaui");
            }
        }

        public Microsoft.Maui.Graphics.Color BackColorMaui
        {
            get => this.ConvertToMauiColor(this.BackColor);
        }

        public System.Drawing.Color BlueBackColor
        {
            get => _bluebackcolor;
            set
            {
                _bluebackcolor = Color.LightSteelBlue;
                this.InvokePropertyChanged();
                this.InvokePropertyChanged("BlueBackColorMaui");
            }
        }

        public Microsoft.Maui.Graphics.Color BlueBackColorMaui
        {
            get => this.ConvertToMauiColor(this.BlueBackColor);
        }

        public System.Drawing.Color ColorfulBackColor
        {
            get => _colorfulbackcolor;
            set
            {
                _colorfulbackcolor = value;
                this.InvokePropertyChanged();
                this.InvokePropertyChanged("ColorfulBackColorMaui");
            }
        }

        public Microsoft.Maui.Graphics.Color ColorfulBackColorMaui
        {
            get => this.ConvertToMauiColor(this.ColorfulBackColor);
        }


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

        private void InvokePropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        private Microsoft.Maui.Graphics.Color ConvertToMauiColor(System.Drawing.Color systemColor)
        {
            float red = systemColor.R / 255f;
            float green = systemColor.G / 255f;
            float blue = systemColor.B / 255f;
            float alpha = systemColor.A / 255f;

            return new Microsoft.Maui.Graphics.Color(red, green, blue, alpha);
        }

    }

}
