using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePattern
{
    /// <summary>
    /// 账户类 抽象类
    /// </summary>
    abstract class Account
    {
        public bool Login(string account, string password)
        {
            Console.WriteLine("账号：{0}", account);
            Console.WriteLine("密码：{0}", password);
            if (account.Equals("川普") && password.Equals("当选"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public abstract void CalculateInterest();

        public void Display()
        {
            Console.WriteLine("显示利息！");
        }

        public void Handle(string account,string password)
        {
            if (!Login(account, password))
            {
                Console.WriteLine("账号密码错误！");
            }
            CalculateInterest();
            Display();
        }
    }

    class CurrentAccount : Account
    {
        public override void CalculateInterest()
        {
            Console.WriteLine("计算活期利息！");
        }
    }

    class SavingAccount : Account
    {
        public override void CalculateInterest()
        {
            Console.WriteLine("计算定期利息！");
        }
    }
    class Sample
    {
        Account account;
        public void Test()
        {
            string accountType = ConfigurationManager.AppSettings["accountType"];
            account = (Account)Assembly.Load("TemplatePattern").CreateInstance(accountType);
            account.Handle("川普", "当选");
            Console.ReadLine();
        }
    }
}
