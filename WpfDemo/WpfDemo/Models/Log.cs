using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemo {
    class Log {
        public string Name { get; set; }
        public List<LogEntry> LogEntries { get; set; }
        public Log() {
            LogEntries = new List<LogEntry>();
        }
    }
}
