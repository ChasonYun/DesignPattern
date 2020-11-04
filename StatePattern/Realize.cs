using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    /// <summary>
    /// 抽象业务方法，不同的具体状态可有不同的实现
    /// </summary>
    abstract class State
    {
        public abstract void Handle();
    }

    /// <summary>
    /// 实现抽象类中的业务方法，不同的具体状态类提供完全不同的方法实现。在实际使用时，在一个状态类中可以包含多个业务方法，
    /// 如果在具体状态类中某些业务方法的实现完全相同，则可以将之移动至抽象状态类，实现代码复用。
    /// </summary>
    class ConcreteState : State
    {
        /// <summary>
        /// 方法具体实现
        /// </summary>
        public override void Handle()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 由具体状态类负责状态之间的转换，在业务方法中判断环境类某些属性值，转换状态。
        /// </summary>
        /// <param name="context"></param>
        public void ChangeState(Context context)
        {
            if(context.value==0)
            {
                context.SetState(new ConcreteState());
            }else if (context.value == 1)
            {
                context.SetState(new ConcreteState());
            }
        }
    }

    /// <summary>
    /// 环境类维持一个抽象状态类的引用，通过SetState()方法可以向环境类注入不同的状态对象，再在环境类的业务方法中调用状态对象的方法。
    /// </summary>
    class Context
    {
        private State state;//维持一个对抽象状态类的引用
        public int value;//属性值，该值的变化可能会导致对象的状态发生变化

        /// <summary>
        /// 设置状态对象
        /// </summary>
        /// <param name="state"></param>
        public void SetState(State state)
        {
            this.state = state;
        }

        /// <summary>
        /// 统一由环境类来负责状态之间的转换 
        /// </summary>
        public void ChangeState()
        {
            if (value == 0)
            {
                this.SetState(new ConcreteState());
            }
            else if (value == 1)
            {
                this.SetState(new ConcreteState());
            }
        }

        public void Request()
        {
            state.Handle();//调用状态对象的业务方法
        }
    }
    class Realize
    {
    }
}
