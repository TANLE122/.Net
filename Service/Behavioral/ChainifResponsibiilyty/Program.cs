using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainifResponsibiilyty
{
    public class LogLevel
    {
        public static readonly LogLevel NONE = new LogLevel(0);
        public static readonly LogLevel INFO = new LogLevel(1);
        public static readonly LogLevel DEBUG = new LogLevel(2);
        public static readonly LogLevel WARNING = new LogLevel(4);
        public static readonly LogLevel ERROR = new LogLevel(8);
        public static readonly LogLevel FATAL = new LogLevel(16);
        public static readonly LogLevel ALL = new LogLevel(32);

        public int Level { get; }
        private LogLevel(int level)
        {
            Level = level;
        }
    }
    public abstract class Logger
    {
        protected LogLevel logLevel;
        protected Logger nextlogger;
        public Logger(LogLevel logLevel)
        {
            this.logLevel = logLevel;
        }
        public Loggel setNext(Logger nextlogger)
        {
            this.nextlogger = nextlogger;
            return nextlogger;
        }
        public void log(LogLevel severity , string msg)
        {
            if( logLeve)
        }
    }
}
/*
 *Chain of Response là một trong nhưungx pattern thuộc nhóm hành vi  (Behavior) nó cho phép 
 Một đối tượng gửi một yêu cầu nhưng không biết đối tượng nào sẽ nhận và xứ lý nó.Điều này được thực hiện bằng cách kết nối các đối tượng nhận yêu cầu thành một chuỗi.
 Chain of Responseblity pattern hoạt động như một danh sách liên kết (Linked list) với việc đệ quy duyệt qua các phần tử

Các thanhf phần tham gia mẫu Chain of Responsibilty:
Handler : Định nghĩa 1 inteface để xử lý các yêu cầu .Gán cho đối tượng succeror 
ConcreteHandler :Xử lý yêu cấu có thể truy cập đối tượng successor ( thuộc đối tượng Handler).Nếu đối tượng ConcreteHandler không thể xử lý được yêu cầu ,nó sẽ gửi lời yêu cầu cho successỏ của nó 
Client: tạo ra các yêu cầu và yêu cầu đó sẽ được gửi đến các đối tượng tiếp nhận 
 */