using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuliderPattern
{
    /// <summary>
    /// 产品类
    /// </summary>
    class Product
    {
        private string partA;//定义部件 部件可以是任何类型，包括值类型和引用类型
        private string partB;
        private string partC;

        public string PartA { get => partA; set => partA = value; }
        public string PartB { get => partB; set => partB = value; }
        public string PartC { get => partC; set => partC = value; }
    }

    /// <summary>
    /// 抽象建造者
    /// </summary>
    abstract class Builder
    {
        protected Product product = new Product();
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract void BuildPartC();

        public Product GetProduct()
        {
            return product;
        }
    }

    /// <summary>
    /// 具体建造者
    /// </summary>
    class ConcreteBuilder : Builder
    {
        public override void BuildPartA()
        {
            product.PartA = "A1";
        }

        public override void BuildPartB()
        {
            product.PartB = "B1";
        }

        public override void BuildPartC()
        {
            product.PartC = "C1";
        }
    }

    /// <summary>
    /// 指挥者类
    /// </summary>
    class Director
    {
        private Builder builder;//维持一个对抽象建造者对象的引用

        public Director(Builder builder)
        {
            this.builder = builder;
        }

        public void SetBuilder(Builder builder)
        {
            this.builder = builder;
        }

        public Product Construct()
        {
            builder.BuildPartA();
            builder.BuildPartB();
            builder.BuildPartC();
            return builder.GetProduct();
        }
    }

    class Realize
    {
    }
}
