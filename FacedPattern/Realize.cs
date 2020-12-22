using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    /// <summary>
    /// 子系统类
    /// </summary>
    class SubSystemA
    {
        public void MethodA()
        {

        }
    }

    /// <summary>
    /// 子系统类
    /// </summary>
    class SubSystemB
    {
        public void MethodB()
        {

        }
    }

    /// <summary>
    /// 子系统类
    /// </summary>
    class SubSystemC
    {
        public void MethodC()
        {
            
        }
    }

    /// <summary>
    /// 外观类 与子系统业务之间的交互统一由外观类来完成
    /// </summary>
    class Facade
    {
        /// <summary>
        /// 在外观类中维持对子系统对象的引用，客户端可以通过外观类间接调用子系统对象的业务方法，无需与子系统对象直接交互
        /// </summary>
        private SubSystemA systemA = new SubSystemA();
        private SubSystemB systemB = new SubSystemB();
        private SubSystemC systemC = new SubSystemC();

        public void Method()
        {
            systemA.MethodA();
            systemB.MethodB();
            systemC.MethodC();
        }
    }

    class Realize
    {
        /// <summary>
        /// 引入外观设计模式后， 客户端直接与外观类交互，间接调用子系统业务方法，客户端代码将会变得非常简单
        /// </summary>
        public void Test()
        {
            Facade facade = new Facade();
            facade.Method();
        }

    }
}
