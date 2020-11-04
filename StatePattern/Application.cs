using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    /// 银行账户
    /// 三个状态 
    /// 金额》=0 正常 可存 可取
    /// 金额-2000 ——0  透支 可存 可取 算利息
    /// 金额 <-2000 受限 只存 算利息
    /// 

    ///账户状态类 充当抽象状态类
    abstract class AccountState
    {
        private Account acc;//维持一个对 环境类的引用

        public Account Acc { get => acc; set => acc = value; }

        /// <summary>
        /// 存款
        /// </summary>
        /// <param name="amount"></param>
        public abstract void Deposit(double amount);//声明各种状态需要实现的抽象方法  各个状态子类的实现方式不同
        /// <summary>
        /// 取款
        /// </summary>
        /// <param name="amount"></param>
        public abstract void Withdraw(double amount);
        /// <summary>
        /// 计算利息
        /// </summary>
        public abstract void ComputeInterset();
        /// <summary>
        /// 状态检查
        /// </summary>
        public abstract void StateCheck();
    }

    class NormalState : AccountState
    {
        public NormalState(Account account)//注入环境类对象
        {
            this.Acc = account;
        }

        public NormalState(AccountState state)//供初始化时  设置初始状态使用
        {
            this.Acc = state.Acc;
        }

        public override void ComputeInterset()
        {
            Console.WriteLine("状态正常，无需支付利息！");
        }

        public override void Deposit(double amount)//改变环境类中的属性  同时可以根据环境类中属性决定不同的操作  改变状态等
        {
            this.Acc.Balance += amount;
            StateCheck();
        }

        public override void StateCheck()
        {
            if (this.Acc.Balance > -2000 && Acc.Balance <= 0)
            {
                Acc.SetState(new OverdraftState(this));
            }
            else if (Acc.Balance == -2000)
            {
                Acc.SetState(new RestrictedState(this));
            }
            else if (Acc.Balance < -2000)
            {
                Console.WriteLine("操作受限");
            }
        }

        public override void Withdraw(double amount)
        {
            this.Acc.Balance -= amount;
            StateCheck();
        }
    }

    class OverdraftState : AccountState
    {
        public OverdraftState(AccountState state)
        {
            this.Acc = state.Acc;
        }
        public override void ComputeInterset()
        {
            Console.WriteLine("计算利息！");
        }

        public override void Deposit(double amount)
        {
            Acc.Balance += amount;
            StateCheck();
        }

        public override void StateCheck()
        {
            if (this.Acc.Balance > 0)
            {
                Acc.SetState(new NormalState(this));
            }
            else if (Acc.Balance == -2000)
            {
                Acc.SetState(new RestrictedState(this));
            }
            else if (Acc.Balance < -2000)
            {
                Console.WriteLine("操作受限");
            }
        }

        public override void Withdraw(double amount)
        {
            Acc.Balance -= amount;
            StateCheck();
        }
    }

    class RestrictedState : AccountState
    {
        public RestrictedState(AccountState state)
        {
            this.Acc = state.Acc;
        }
        public override void ComputeInterset()
        {
            Console.WriteLine("计算利息！");
        }

        public override void Deposit(double amount)
        {
            Acc.Balance += amount;
            StateCheck();
        }

        public override void StateCheck()
        {
            if (this.Acc.Balance > 0)
            {
                Acc.SetState(new NormalState(this));
            }
            else if (Acc.Balance > -2000)
            {
                Acc.SetState(new OverdraftState(this));
            }
        }

        public override void Withdraw(double amount)
        {
            Console.WriteLine("账号受限，操作失败!");
        }
    }

    class Account
    {
        private AccountState state;//维持一个对抽象状态对象的应用
        private string owner;//开户名
        private double balance = 0;//账户余额

        public Account(string owner, double balance)
        {
            this.owner = owner;
            this.Balance = balance;
            this.state = new NormalState(this);
            Console.WriteLine("{0}开户成功，初始化金额为{1}", this.owner, this.balance);
        }

        public double Balance { get => balance; set => balance = value; }

        public void SetState(AccountState state)//存取完款后  改变账户状态
        {
            this.state = state;
        }

        public void Deposit(double amount)
        {
            Console.WriteLine("{0}存款{1}", this.owner, this.balance);
            state.Deposit(amount);
            Console.WriteLine("现金余额为{0}", this.Balance);
            Console.WriteLine("现在的账户状态为{0}", this.state.GetType().ToString());
            Console.WriteLine("------------------------------------------------------");
        }

        public void Withdraw(double amount)
        {
            Console.WriteLine("{0}取款{1}", this.owner, this.balance);
            state.Withdraw(amount);
            Console.WriteLine("现金余额为{0}", this.Balance);
            Console.WriteLine("现在的账户状态为{0}", this.state.GetType().ToString());
            Console.WriteLine("------------------------------------------------------");
        }

        public void ComputeInterest()
        {
            state.ComputeInterset();//调用对象的方法
        }
    }

    class Application
    {
        public void Test()
        {
            Account acc = new Account("建国", 0.0);
            acc.Deposit(1000);
            acc.Withdraw(2000);
            acc.Deposit(3000);
            acc.Withdraw(4000);
            acc.Withdraw(1000);
            acc.ComputeInterest();
            Console.ReadKey();
        }
    }
}
