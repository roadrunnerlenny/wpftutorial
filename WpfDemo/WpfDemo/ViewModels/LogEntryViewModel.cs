using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemo {
    class LogEntryViewModel : ViewModel<LogEntry> {
        public int ID {
            get {
                return Model.ID;
            }
        }
        public DateTime Date {
            get {
                return Model.Date;
            }
            set {
                Model.Date = value;
                OnPropertyChanged();
            }
        }
        public string Message {
            get {
                return Model.Message;
            }
            set {
                Model.Message = value;
                OnPropertyChanged();
            }
        }

        public string Level {
            get {
                return Model.Level;
            }
            set {
                Model.Message = value;
                OnPropertyChanged();
            }
        }

        public LogEntryViewModel(LogEntry model) : base(model) { }
        public string LevelAsColor => Model.Level == "ERROR" ? "Red" : "Blue";
        public bool IsError => Model.Level == "ERROR" ? true : false;
    }
}
