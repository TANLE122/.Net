using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge_patttern
{
    public interface Account {
        void openAccount();
    }
    public class CheckingAccount : Account
    {
        public void openAccount()
        {
            Console.WriteLine("CHecking Account");
        }
    }
    public class SavingAccount : Account
    {
        public void openAccount()
        {
            Console.WriteLine("Saving Account");
        }
    }
    public abstract class Bank
    {
        protected Account account;
        public  Bank(Account account)
        {
            this.account = account;
        }
        public abstract void openAccount();
    }
    public class VietComBank:Bank
    {
        public VietComBank(Account account) : base(account)
        {
        }
        public override void openAccount()
        {
            Console.WriteLine("Open your account at VietCOMBANK");
            account.openAccount();
        }
    }
    public class TPBank : Bank
    {
        public TPBank(Account account) : base(account)
        {
        }
        public override void openAccount()
        {
            Console.WriteLine("Open your account at TPbank");
            account.openAccount();

        }
        public class Client
        {
            public static void Main(String[] args)
            {
                Bank vietcombank = new VietComBank(new CheckingAccount() );
                vietcombank.openAccount();
                Bank tpbank = new TPBank(new CheckingAccount());
                tpbank.openAccount();
            }
        }

    }
    }
/*
Bridge pattern là một trong những pattern thuộc nhóm cấu trúc ý tưognr của nó là tách tính trừu tượng ra khỏi tính
hiện thực của nó .Từ đó có thể dễ dàng thay thế mà không lamf ảnh hưognr đến những nơi sử dụng lớp ban đầu
Điều đó có nghĩa là ban đầu ta thiết kế một class với rất nhiều xử lý bây giờ chugns ta không muốn để những xử lý đó trong class đó nữa .Vì thế chúng ta sẽ tạo ra một class kahcs và move các xử lý đó qua class mới.
Khi đó trong lớp cũ sẽ giữ một đối tượng thuộc về lớp mới và đối tượng này sẽ chịu trách nhiệm xử lý thay cho lớp ban đầu.
Một Bridge Pattern  bao gồm các thành phần sau:
Client:Đại diện cho khác hàng sử dụng chức ăngn thông qua Abstraction
Abstraction: định ra mọot abstract interface quanr lý  viẹc tham chiếu đến đối tượng thực hiện cụ hteer (Implementor)
Refined Abstract 
 */