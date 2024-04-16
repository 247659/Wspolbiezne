using Logic;
using Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ViewModel
{
    public class ViewModelController : INotifyPropertyChanged
    {
        private string _ballsNumber;
        private BallLogic _ballLogic = new BallLogic();
        private ModelRepo _repo;

        public ICommand CreateBallCommand { get; set; }

        public ViewModelController()
        {
            BallsNumber = "0";
            CreateBallCommand = new RelayCommand(CreateBalls);
        }

        private void CreateBalls(object obj)
        {
            _ballLogic.CreateBalls(_ballsNumber);
            Repo = _ballLogic.RepoModel;
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

        public ModelRepo Repo
        {
            get { return _repo; }
            set
            {
                _repo = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
