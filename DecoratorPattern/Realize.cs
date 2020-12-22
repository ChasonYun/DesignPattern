using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    /// <summary>
    /// 抽象构件类
    /// 一般为抽象类或者 接口 
    /// </summary>
    abstract class Component
    {
        public abstract void Operation();
    }

    /// <summary>
    /// 具体构件类 实现基本功能
    /// </summary>
    class ConcreteComponent : Component
    {
        public override void Operation()
        {
            //基本功能实现
        }
    }

    /// <summary>
    /// 抽象装饰类
    /// 装饰模式的核心在于抽象装饰类的设计
    /// </summary>
    class Decorator : Component
    {
        private Component component;//维持一个对抽象构件对象的引用

        //注入一个抽象构件类型的对象
        public Decorator(Component component)
        {
            this.component = component;
        }
        public override void Operation()
        {
            component.Operation();//调用原有业务方法
        }
    }

    class ConcreteDecorator : Decorator
    {
        public ConcreteDecorator(Component component):base(component)
        {

        }

        public override void Operation()
        {
            base.Operation();//调用原有业务方法
            AddedBehavior();//调用新增业务方法
        }
        /// <summary>
        /// 新增业务方法
        /// </summary>
        public void AddedBehavior()
        {
            //功能扩展
        }
    }
    class Realize
    {
    }
}
