using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public abstract class Range<T> : INotifyPropertyChanged 
    {
        private T _to;
        private T _min;
        private T _max;
        private T _from;

        public T To
        {
            get { return _to; }
            set
            {
                _to = value;

                OnPropertyChanged("To");
            }
        }

        public T Min
        {
            get { return _min; }
            set
            {
                _min = value;

                OnPropertyChanged("Min");
            }
        }

        public T Max
        {
            get { return _max; }
            set
            {
                _max = value;

                OnPropertyChanged("Max");
            }
        }

        public T From
        {
            get { return _from; }
            set
            {
                _from = value;

                OnPropertyChanged("From");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Range(T to, T from)
        {
            Max = to;
            Min = from;

            To = to;
            From = from;
        }

        public abstract bool CheckСhanges();

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
