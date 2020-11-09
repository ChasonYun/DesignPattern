using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern
{
    /// <summary>
    /// 抽象访问者 
    /// 为每一种类型的元素对象都提供一个访问方法，而访问者可以实现这些访问方法。
    /// 这些访问方法的命名一般有两种：（1）直接在名称中标明待访问元素对象的具体类型（2）统一 通过参数类型实现重载
    /// </summary>
    abstract class Visitor
    {
        public abstract void Visit(ConcreteElementA elementA);
        public abstract void Visit(ConcreteElementB elementB);

        public void Visit(ConcreteElementC elementC)
        {
            //elementc的操作代码
        }
    }

    /// <summary>
    /// 这里使用统一的命名实现对不同类型元素的访问操作
    /// </summary>
    class ConcreteVisitor : Visitor
    {
        public override void Visit(ConcreteElementA elementA)
        {
            //元素A的代码
        }

        public override void Visit(ConcreteElementB elementB)
        {
            //元素B的代码
        }
    }

    /// <summary>
    /// 元素类一般定义一个Accept（）方法，用于接收访问者的访问。
    /// 传入的参数为抽象访问者，即针对抽象编程
    /// </summary>
    interface Element
    {
        void Accept(Visitor visitor);
    }

    /// <summary>
    /// 在具体元素类的Accept()方法中，通过调用Visitor的Visit方法实现对元素的访问，并以当前对象作为Visit方法的参数。
    /// （1）调用具体元素类的Accept方法。将Visitor子类对象作为其参数
    /// （2）具体元素类Accept方法内部调用传入的Visitor对象的Visit()方法，例如Visit(ConcreteElementA elementA)，将当前具体元素类对象（this）作为参数
    /// （3）执行Visitor对象的Visit()方法，在其中还可以调用具体元素对象的业务方法。
    /// 双重分派机制，使得增加新的访问者无须修改现有的类库代码，只需将新的访问者对象作为参数传入具体元素对象的Accept（）方法，程序运行时将回调在新增Visitor类中定义的Visit方法，
    /// 从而增加新的元素访问方式。
    /// </summary>
    class ConcreteElementA : Element
    {
        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public void OperationA()
        {
            //业务方法
        }
    }

    class ConcreteElementB : Element
    {
        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }

        public void OperationB()
        {

        }
    }

    class ConcreteElementC : Element
    {
        public void Accept(Visitor visitor)
        {
            throw new NotImplementedException();
        }

        public void OperationC()
        {

        }
    }

    class ObjectStructure
    {
        private List<Element> list = new List<Element>();

        public void Accept(Visitor visitor)
        {
            foreach(object obj in list)
            {
                ((Element)obj).Accept(visitor);
            }
        }

        public void AddElement(Element element)
        {
            list.Add(element);
        }

        public void RemoveElement(Element element)
        {
            list.Remove(element);
        }
    }
    class Realize
    {
    }
}
