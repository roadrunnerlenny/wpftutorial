using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemo {
    class PresenterViewModel : ViewModel{        
        public LogViewModel DemoLog { get; set; }
        public object CurrentView { get; set; }
        public DelegateCommand NextPageCommand { get; set; }
        public DelegateCommand PrevPageCommand { get; set; }
        public PresenterViewModel() {
            Log demoLog = LogFactory.ProduceDemoLog();
            DemoLog = new LogViewModel(demoLog);

            CurrentView = DemoLog;
            NextPageCommand = new DelegateCommand(
                nopar => {
                    CurrentView = new OnlyUIViewModel();
                    OnPropertyChanged("CurrentView");
                    PrevPageCommand.RaiseCanExecuteChanged();
                    NextPageCommand.RaiseCanExecuteChanged();
                },
                nopar => {
                    //return true;
                    return (CurrentView as OnlyUIViewModel == null);
                });
            PrevPageCommand = new DelegateCommand(
                nopar => {
                    CurrentView = DemoLog;
                    OnPropertyChanged("CurrentView");
                    PrevPageCommand.RaiseCanExecuteChanged();
                    NextPageCommand.RaiseCanExecuteChanged();
                },
                nopar => {
                    return (CurrentView as OnlyUIViewModel != null);
                });
        }
    }
}
