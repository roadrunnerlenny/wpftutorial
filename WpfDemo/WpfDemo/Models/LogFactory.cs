using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDemo {
    static class LogFactory {
        public static Log ProduceDemoLog() {
            Log log = new Log() { Name = "DemoLog" };
            for (int i=1;i<20;i++) {
                LogEntry entry = new LogEntry() {
                    ID = i,
                    Message = $"This is a Test Message #{i}",
                    Date = DateTime.Now.AddHours(-i)
                };
                entry.Level = i % 3 == 0 ? "ERROR" : "WARN";
                log.LogEntries.Add(entry);
            }
            return log;
        }
    }
}
