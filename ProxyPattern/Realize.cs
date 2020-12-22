using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    abstract class Subject
    {
        public abstract void Reuqest();
    }

    class RealSubject : Subject
    {
        public override void Reuqest()
        {
           //业务方法具体实现代码
        }
    }

    class Proxy : Subject
    {
        private RealSubject realSubject = new RealSubject();//维持一个对真实对象的引用
        public void PerRequest()
        {

        }

        public override void Reuqest()
        {
            PerRequest();
            realSubject.Reuqest();//调用真实主题对象的方法
            PostRequest();
        }

        public void PostRequest()
        {

        }
    }

    class Realize
    {
    }
}
