using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{

    abstract class AbstractStrategy
    {
        public abstract void Algorithm();//抽象算法
    }

    class ConcreteStrategy : AbstractStrategy
    {
        public override void Algorithm()
        {
            throw new NotImplementedException();//实现算法
        }
    }


    class Context
    {
        private AbstractStrategy strategy;//维持一个对抽象策略的引用

        public void SetStrategy(AbstractStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void Algorithm()
        {
            strategy.Algorithm();
        }
    }
    class Realize
    {
        public void Test()
        {
            Context context = new Context();
            context.SetStrategy(new ConcreteStrategy());//可以在运行时指定类型，通过配置文件和反射机制实现
            context.Algorithm();//使用算法
        }
      
        
    }
}
