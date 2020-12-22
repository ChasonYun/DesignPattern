using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyweightPattern
{
    /// <summary>
    /// 抽象享元类的设计重要
    /// 要定义一个抽象享元类作为具体享元类的公共父类
    /// </summary>
    abstract class Flyweight
    {
        public abstract void Operation(string extringState);
    }

    class ConcreteFlyweight : Flyweight
    {
        private string intrinsicState;//作为成员变量，同一个享元对象其内部状态是一致的
        public ConcreteFlyweight(string intrinsicState)
        {
            this.intrinsicState = intrinsicState;
        }
        public override void Operation(string extringState)
        {
            //实现业务方法
        }
    }

    /// <summary>
    /// 不需要共享的抽象享元类
    /// </summary>
    class UnsharedConcreteFlyweight : Flyweight
    {
        public override void Operation(string extringState)
        {
            //实现业务方法
        }
    }

    class FlyweightFactory
    {
        private Hashtable flyweight = new Hashtable();//存储享元对象 实现享元池
        public Flyweight GetFlyweight(string key)
        {
            if (flyweight.ContainsKey(key))
            {
                return (Flyweight)flyweight[key];
            }
            else
            {
                Flyweight temp = new ConcreteFlyweight("state");
                flyweight.Add(key, temp);
                return temp;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
