using Logic;
using Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ViewModel
{
    public class VievModelController : INotifyPropertyChanged
    {
        private string _ballsNumber;
        private ObservableCollection<BallModel> _balls;
        private BallLogic _ballLogic = new BallLogic();
        private BallModel model;

        public ICommand CreateBallCommand { get; set; }

        public VievModelController()
        {
            BallsNumber = "0";
            CreateBallCommand = new RelayCommand(CreateBalls);
        }

        private void CreateBalls(object obj)
        {
            _ballLogic.CreateBalls(_ballsNumber);
            model = _ballLogic.Model;
            Balls = model.Balls;
        }

        public string BallsNumber
        {
            get { return _ballsNumber; }
            set
            {
                _ballsNumber = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<BallModel> Balls
        {
            get { return _balls; }
            set
            {
                _balls = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
