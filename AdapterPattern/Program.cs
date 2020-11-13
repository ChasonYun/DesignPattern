using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    class Program
    {
        

        /// <summary>
        /// 需要进行适配的 适配者类
        /// </summary>
        class Adaptee
        {
            public void SpecificRequest()
            {

            }
        }

        /// <summary>
        /// 适配和需要实现了 目标接口
        /// </summary>
        interface Target
        {
            void Request();//目标接口 需要实现的功能
        }

        #region //类适配器
        /// <summary>
        /// 适配器类  继承适配者 同时 实现目标接口
        /// </summary>
        class Adapter : Adaptee, Target
        {
            /// <summary>
            /// 调用适配者类的函数方法， 实现 接口目标需求
            /// </summary>
            public void Request()
            {
                base.SpecificRequest();
            }
        }
        #endregion

        #region//对象适配器
        class Adapter_ : Target
        {
            private Adaptee adaptee;//维持一个对适配者对象的引用
            public Adapter_(Adaptee adaptee)
            {
                this.adaptee = adaptee;
            }
            public void Request()
            {
                adaptee.SpecificRequest();//实现接口需求
            }
        }
        #endregion
        static void Main(string[] args)
        {
        }
    }
}
