using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace CSharpLab1Saliy
{
    internal class ViewModel : INotifyPropertyChanged
    {
        private readonly Model _birthdayModel = new Model();

        public DateTime BirthDate
        {
            get
            {
                return _birthdayModel.Birthday;
            }
            set
            {
                _birthdayModel.Birthday = value;
                if (!_birthdayModel.Valid)
                {
                    MessageBox.Show("Wrong date!", "DatePickerError", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
                else
                {
                    if (_birthdayModel.IsBirthday)
                    {
                        MessageBox.Show("Happy birthday:)");
                    }
                }
                OnPropertyChanged();
                OnPropertyChanged(nameof(Age));
                OnPropertyChanged(nameof(ChineseZodiac));
                OnPropertyChanged(nameof(WestZodiac));
            }
        }

        public string Age
        {
            get
            {
                return $"Your age:{Environment.NewLine}{_birthdayModel.Age}";
            }
        }

        public string WestZodiac
        {
            get
            {
                return $"Western zodiac:{Environment.NewLine}{_birthdayModel.WestZodiac}";
            }
        }

        public string ChineseZodiac
        {
            get
            {
                return $"Chinese zodiac:{Environment.NewLine}{_birthdayModel.ChineseZodiac}";
            }
        }

        internal ViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

       
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
