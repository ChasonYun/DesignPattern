using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AsyncAttention
{
    class Program
    {
        ///异步编程注意点
        static void Main(string[] args)
        {
            new Test().Method();
        }
    }

    /// <summary>
    /// 一直异步到底
    /// </summary>
    class Test
    {
        /// <summary>
        /// Method方法使用task.run方法创建新的任务 间隔100ms模拟多次请求
        /// </summary>
        public void Method()
        {
            while (true)
            {
                //Task.Run(MethodSync);
                Task.Run(MethodSync_);
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// 同步方法MethodSync 中调用异步方法MethodAsync
        /// 同时使用wait()方法进行等待
        /// 线程A执行MethodSync，执行到wait()时，产生新的线程去调用异步方法MethodAsync
        /// 线程A等待B完成继续wait(),A继续执行 并发较大 线程池不够，死锁
        /// </summary>
        public void MethodSync()
        {
            MethodAsync().Wait();
        }

        public async Task MethodSync_()
        {
            await MethodAsync();
        }

        public async Task<string> MethodAsync()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(2000);
            });

            Console.WriteLine("MethodAsync End");
            return "Success";
        }
    }

    class Test_
    {


        /// <summary>
        /// 同步方法中无法捕获异步方法的异常
        /// </summary>
        public void Method()
        {
            try
            {
                TestExceptionAsync();
            }
            catch (Exception ex)//无法捕捉异常
            {

                throw;
            }
        }

        /// <summary>
        /// 想要捕捉异步方法的异常 需要使用await()修饰符 或者访问Result属性 一般不使用Wait()
        /// </summary>
        /// <returns></returns>
        public async Task Method_()
        {
            try
            {
                await TestExceptionAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private async Task TestExceptionAsync()
        {
            await Task.Delay(200);
            throw new Exception("Test_ TestExceptionAsync");

        }
    }
    class Test__
    {
        /// <summary>
        /// 可选参数  赋值的方式
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public void Method(int a, int b = 0, int c = 1)
        {

        }

        public void MethodCall()
        {
            Method(1);
            Method(1, 2);
            Method(1, 2, 3);
        }

        /// <summary>
        /// 可变参数
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void Method_(int a, params int[] b)
        {

        }

        public void MethodCall_()
        {
            Method_(1, new int[] { 1 });//可以传入对应类型的数组
            Method_(1, 1, 2);//可以传入多个对应类型的参数
        }
    }
}
