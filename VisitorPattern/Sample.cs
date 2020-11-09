using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern
{
    //财务部 人力部 对员工数据进行汇总
    //员工包括 正式员工  临时工
    //

    /// <summary>
    /// 员工类接口 充当抽象元素类 
    /// 
    /// </summary>
    interface IEmployee
    {
        void Accept(Department department);//员工数据接受一个访问者对象的访问
    }

    /// <summary>
    /// 全职员工类  具体元素
    /// </summary>
    class FulltimeEmployee : IEmployee
    {
        string name;
        double weeklyWage;
        int workTime;

        public string Name { get => name; set => name = value; }
        public double WeeklyWage { get => weeklyWage; set => weeklyWage = value; }
        public int WorkTime { get => workTime; set => workTime = value; }

        public FulltimeEmployee(string name, double weeklyWage, int workTime)
        {
            this.name = name;
            this.weeklyWage = weeklyWage;
            this.workTime = workTime;
        }
        public void Accept(Department department)
        {
            department.Visit(this);
        }
    }

    class ParttimeEmployee : IEmployee
    {
        string name;
        double hourWage;
        int workTime;

        public string Name { get => name; set => name = value; }
        public double HourWage { get => hourWage; set => hourWage = value; }
        public int WorkTime { get => workTime; set => workTime = value; }

        public ParttimeEmployee(string name,double hourWage,int workTime)
        {
            this.name = name;
            this.hourWage = hourWage;
            this.workTime = workTime;
        }

        public void Accept(Department department)
        {
            department.Visit(this);
        }
    }

    /// <summary>
    /// 部门类 充当抽象访问者
    /// </summary>
    abstract class Department
    {
        public abstract void Visit(FulltimeEmployee fulltime);
        public abstract void Visit(ParttimeEmployee parttime);
    }

    class FADepartment : Department
    {
        /// <summary>
        /// 财务部对 全职员工的访问
        /// </summary>
        /// <param name="fulltime"></param>
        public override void Visit(FulltimeEmployee fulltime)
        {
            int worktime = fulltime.WorkTime;
            double wage = fulltime.WeeklyWage;
            if (worktime > 40)
            {
                wage = wage + (worktime - 40) * 100;
            }else if (worktime < 40)
            {
                wage = wage - (40 - worktime) * 80;
            }
            Console.WriteLine("正式员工{0}的实际工资为：{1}元", fulltime.Name, wage);
        }

        /// <summary>
        /// 财务部对 兼职员工的访问
        /// </summary>
        /// <param name="parttime"></param>
        public override void Visit(ParttimeEmployee parttime)
        {
            int worktime = parttime.WorkTime;
            double wage = parttime.HourWage;
            Console.WriteLine("临时工{0}的实际工资为：{1}元", parttime.Name, worktime * wage);
        }
    }

    class HRDepartment : Department
    {
        /// <summary>
        /// 人力资源部对 全职人员的访问
        /// </summary>
        /// <param name="fulltime"></param>
        public override void Visit(FulltimeEmployee fulltime)
        {
            int workTime = fulltime.WorkTime;
            Console.WriteLine("正式员工{0}的实际工时为：{1}", fulltime.Name, fulltime.WorkTime);
            if (workTime > 40)
            {
                Console.WriteLine("正式员工{0}的加班时间为：{1}", fulltime.Name, fulltime.WorkTime - 40);
            }else if (workTime < 40)
            {
                Console.WriteLine("正式员工{0}的请假时间为：{1}", fulltime.Name, fulltime.WorkTime - 40);
            }
        }

        /// <summary>
        /// 全职人员对兼职员工的访问
        /// </summary>
        /// <param name="parttime"></param>
        public override void Visit(ParttimeEmployee parttime)
        {
            Console.WriteLine("临时工{0}的实际工时时间为：{1}", parttime.Name, parttime.WorkTime);
        }
    }

    class EmployeeList
    {
        private List<IEmployee> employees = new List<IEmployee>();
        public void AddEmployee(IEmployee employee)
        {
            employees.Add(employee);
        }

        public void Accept(Department department)
        {
            foreach(IEmployee employee in employees)
            {
                employee.Accept(department);
            }
        }

        public void RemoveEmployee(IEmployee employee)
        {
            employees.Remove(employee);
        }
    }
    class Sample
    {
        /// <summary>
        /// 如果需要增加新的访问者 只需要增加一个新的具体访问者类即可，在该具体访问者棕封装新的操作元素的方法
        /// 如果需要增加新的具体元素，“返聘人员”，需要在原有的访问者类和具体访问者中增加相应的访问方法
        /// 对开闭原则的支持具有倾斜性，可以很方便的添加新的访问者，但是添加新的元素较为麻烦
        /// </summary>
        public void Test()
        {
            EmployeeList employeeList = new EmployeeList();
            IEmployee ft1, ft2, pt1, pt2;
            ft1 = new FulltimeEmployee("张无忌", 3200, 45);
            ft2 = new FulltimeEmployee("杨过", 2000, 40);
            pt1 = new ParttimeEmployee("段誉", 80, 30);
            pt2 = new ParttimeEmployee("王语嫣", 200, 20);

            employeeList.AddEmployee(ft1);
            employeeList.AddEmployee(ft2);
            employeeList.AddEmployee(pt1);
            employeeList.AddEmployee(pt2);

            Department department;
            string departmentType = ConfigurationManager.AppSettings["visitorType"];
            department = (Department)Assembly.Load("VisitorPattern").CreateInstance(departmentType);//修改配置文件即可实现具体访问者类的更换
            employeeList.Accept(department);
            Console.Read();
        }
    }
}
