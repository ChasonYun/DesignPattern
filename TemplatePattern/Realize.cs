using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePattern
{
    abstract class AbstractClass
    {
        public void TemplateMethod()
        {
            PrimitiveOperation1();
            PrimitiveOperation2();
            if (PrimitiveOperation3())
            {
                //进行操作
            }
        }

        /// <summary>
        /// 基本方法--具体
        /// </summary>
        public void PrimitiveOperation1()
        {
            Console.WriteLine("调用基本方法1" + this.GetType());
        }

        /// <summary>
        /// 基本方法--抽象
        /// </summary>
        public abstract void PrimitiveOperation2();

        /// <summary>
        /// 基本方法--钩子方法
        /// 是一个抽象或者具体实现  子类会进行扩展 判断某些条件 进行
        /// </summary>
        public virtual bool PrimitiveOperation3()
        {
            Console.WriteLine("调用基本方法3--钩子方法" + GetType());
            return true;
        }
    }

    class ConcreteClass : AbstractClass
    {
        public override void PrimitiveOperation2()
        {
            Console.WriteLine("调用基本方法2" + GetType());
        }

        public override bool PrimitiveOperation3()
        {
            //base.PrimitiveOperation3();
            Console.WriteLine("调用基本方法3--钩子方法" + GetType());
            return false;
        }
    }
    class Realize
    {
        AbstractClass test = new ConcreteClass();
        public void Test()
        {
            test.TemplateMethod();
            Console.ReadLine();
        }
    }
}
