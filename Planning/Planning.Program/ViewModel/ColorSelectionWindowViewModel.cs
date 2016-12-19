using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planning.View;
using Planning.Model;

namespace Planning.ViewModel
{
    class ColorSelectionWindowViewModel : ViewModelBase
    {
        private ColorSelectionWindow _window;
        public ColorSelectionWindow window
        {   get
            {
                return _window;
            }
            set
            {
                _window = value;
            }
        }

        private string _color;
        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                OnPropertyChanged(nameof(Color));
            }
        }

        public RelayCommand ColorButtonClicked { get; }

        public ColorSelectionWindowViewModel(ColorSelectionWindow window)
        {
            _window = window;

            ColorButtonClicked = new RelayCommand(p => ColorHandler(p as string), p => true);
        }

        public void ColorHandler(string color)
        {
            Color = color;
            _window.Close();
        }
    }
}
