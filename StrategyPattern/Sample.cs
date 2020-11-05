using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    //电影票打折
    //学生票8折 十岁以下 减10元
    //VIP 半价 积分
    //可能有新的 打折方式


    class MovieTicket//充当环境类
    {
        private double price;
        private Discount discount;
        public void SetDisCount(Discount discount)
        {
            this.discount = discount;
        }

        public double Price
        {
            get { return discount.Calculate(price); }
            set { price = value; }
        }
    }

    abstract class Discount
    {
        public abstract double Calculate(double price);
    }

    class StudentDiscount : Discount
    {
        private const double DISCOUNT = 0.6;
        public override double Calculate(double price)
        {
            Console.WriteLine("学生票：");
            return price * DISCOUNT;
        }
    }

    class ChildrenDiscount : Discount
    {
        private const double DISCOUNT = 10;
        public override double Calculate(double price)
        {
            Console.WriteLine("儿童票：");
            return price - DISCOUNT;
        }
    }

    class VIPDiscount : Discount
    {
        private const double DISCOUNT = 0.5;
        public override double Calculate(double price)
        {
            Console.WriteLine("VIP票：");
            Console.WriteLine("积分增加");
            return price * DISCOUNT;
        }
    }

    class Sample
    {
        public void Test()
        {
            MovieTicket movieTicket = new MovieTicket();
            double price = 60;
            double currentPrice;
            movieTicket.Price = price;
            Console.WriteLine("初始票价：{0}", price);
            Console.WriteLine("--------------------------------");
            Discount discount;
            string discountType = ConfigurationManager.AppSettings["discountType"];
            discount = (Discount)Assembly.Load("StrategyPattern").CreateInstance(discountType);
            movieTicket.SetDisCount(discount);
            currentPrice = movieTicket.Price;
            Console.WriteLine("打折后价格为：{0}", currentPrice);
            Console.ReadLine();
        }
    }
}
