using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemo {
    class LogViewModel : ViewModel<Log> {
        public string Name {
            get {
                return Model.Name;
            }
            set {
                Model.Name = value;
                OnPropertyChanged();
            }
        }

        //public List<LogEntryViewModel> LogEntries {
        //    get {
        //        return Model.LogEntries.Select(entry => new LogEntryViewModel(entry)).ToList();
        //    }
        //}
        public ObservableCollection<LogEntryViewModel> LogEntries { get; set; }

        LogEntryViewModel _selectedEntry;
        public LogEntryViewModel SelectedEntry {
            get {
                return _selectedEntry;
            }
            set {
                _selectedEntry = value;
                OnPropertyChanged();
                DeleteLogEntryCommand?.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand DeleteLogEntryCommand { get; set; }
        

        public LogViewModel(Log model) : base(model) {
            SelectedEntry = new LogEntryViewModel(new LogEntry());
            DeleteLogEntryCommand = new DelegateCommand(DoDeleteLogEntry, CanDeleteLogEntry);
            LogEntries = new ObservableCollection<LogEntryViewModel>();
            foreach (LogEntry LogEntry in Model.LogEntries)
                LogEntries.Add(new LogEntryViewModel(LogEntry));
        }

        public bool CanDeleteLogEntry(object sender) {
            //return true;
            return SelectedEntry?.ID > 0;
        }

        public void DoDeleteLogEntry(object sender) {
            LogEntryViewModel selEntry = sender as LogEntryViewModel;
            Model.LogEntries = Model.LogEntries.Where(entry => entry.ID != selEntry.ID).ToList();
            LogEntries.Remove(selEntry);
        }
    }
}
