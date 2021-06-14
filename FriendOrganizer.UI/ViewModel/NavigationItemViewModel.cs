using FriendOrganizer.UI.Event;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private string _displayMember;

        public NavigationItemViewModel(int id, string displayMember,
            string detailViewModelName,
            IEventAggregator eventAggregator
            )
        {
            _eventAggregator = eventAggregator;
            Id = id;
            DisplayMember = displayMember;
            _detailViewModelName = detailViewModelName;
            OpenDetailViewCommand = new DelegateCommand(OnOpenDetailViewExecute);
        }

        private IEventAggregator _eventAggregator;

        public int Id { get; }
        public string DisplayMember
        {
            get { return _displayMember; }
            set
            {
                _displayMember = value;
                OnPropertyChanged();
            }
        }

        private string _detailViewModelName;

        public ICommand OpenDetailViewCommand { get; }

         private void OnOpenDetailViewExecute()
        {
            _eventAggregator.GetEvent<OpenDetailViewEvent>()
                       .Publish(
                new OpenDetailViewEventArgs
                {
                    Id = Id,
                    ViewModelName = _detailViewModelName
                });
        }
    }
}
