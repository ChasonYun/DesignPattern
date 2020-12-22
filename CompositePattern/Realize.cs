using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    /// <summary>
    /// 抽象构件类  透明模式  抽象构件包含 addremove 方法
    ///             安全模式  抽象构件不提供 addremove方法模板 composite构件私有实现 addremove leaf 不包含 addremove
    /// </summary>
    abstract class Component
    {
        /// <summary>
        /// 增加成员
        /// </summary>
        /// <param name="component"></param>
        public abstract void Add(Component component);
        /// <summary>
        /// 删除成员
        /// </summary>
        /// <param name="component"></param>
        public abstract void Remove(Component component);
        /// <summary>
        /// 获取成员
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public abstract Component GetChild(int i);
        /// <summary>
        /// 业务方法
        /// </summary>
        public abstract void Operation();
    }

    /// <summary>
    /// 叶子构件 实现抽象构件的方法 但是叶子构件不能 包含叶子构件 在叶子构件的管理和访问时需要提供异常处理和错误提示
    /// </summary>
    class Leaf : Component
    {
        /// <summary>
        /// 叶子构件不拥有子构件  不需要实现 add 与remove方法
        /// </summary>
        /// <param name="component"></param>
        public override void Add(Component component)
        {
            throw new NotImplementedException();
        }

        public override Component GetChild(int i)
        {
            throw new NotImplementedException();
        }

        public override void Operation()
        {
            throw new NotImplementedException();
        }

        public override void Remove(Component component)
        {
            throw new NotImplementedException();
        }
    }

    class Composite : Component
    {
        List<Component> container = new List<Component>();
        public override void Add(Component component)
        {
            container.Add(component);
        }

        public override Component GetChild(int i)
        {
            return container[i];
        }

        public override void Operation()
        {
            foreach(var temp in container)
            {
                temp.Operation();
            }
        }

        public override void Remove(Component component)
        {
            container.Remove(component);
        }
    }
    class Realize
    {
    }
}
