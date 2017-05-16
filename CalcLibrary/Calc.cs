using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary
{
    public class Calc
    {
        /// <summary>
        /// Список доступных операций
        /// </summary>
        public IList<IOperation> Operations { get; private set; }

        public Calc()
        {
            Operations = new List<IOperation>();

            var types = new List<Type>();
            var ioper = typeof(IOperation);
            // найти библиотеку
            var dlls = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dll");
            foreach (var dll in dlls)
            {
                var assm = Assembly.LoadFrom(dll);
                types.AddRange(assm.GetTypes());
            }

            // загрузить как сборку
            // добавить типы

            foreach (var t in types)
            {
                if (t.IsInterface) continue;
                var interfaces = t.GetInterfaces();
                if (interfaces.Contains(ioper))
                {
                    var oper = Activator.CreateInstance(t) as IOperation;
                    if (oper != null) Operations.Add(oper);
                }
            }
            Operations = Operations
                .GroupBy(o => o.Name + o.GetType().FullName)
                .Select(group => group.FirstOrDefault())
                .ToList();
        }


        /// <summary>
        /// Выполнить операцию
        /// </summary>
        /// <param name="operation">Название операции</param>
        /// <param name="args">Аргументы операции</param>
        /// <returns>Результат операции</returns>
        [Obsolete]
        public object Execute(string operation, object[] args)
        {
            // находим операцию в списке доступных
            var oper = Operations.FirstOrDefault(it => it.Name == operation);

            // если не нашли - возвр ошибку
            if (oper == null) return "Error: no such operation defined";
            //double result = 0;
            // если нашли - вызывем новый Execute и возвращаем результат
            var result = Execute(oper, args);

            return result;
        }

        /// <summary>
        /// Новый метод Execute, принимает на вход операцию, а не ее имя
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public object Execute(IOperation operation, object[] args)
        {
            double x, y;
            double.TryParse(args[0].ToString(), out x);
            double.TryParse(args[1].ToString(), out y);
            double result = 0;

            var operArgs = operation as IOperationArgs;
            if (operArgs != null)
            {
                result = operArgs.Calc(args);
            }
            else
            {
                result = operation.Calc(x, y);
            }

            return result;
        }

        [Obsolete("не используйте это")]
        public int Sum(int x, int y)
        {
            var r = Execute("sum", new object[] { x, y });
            return int.Parse(r.ToString());
        }

        [Obsolete("не используйте это")]
        public double Divide(int x, int y)
        {
            var r = Execute("divide", new object[] { x, y });
            return double.Parse(r.ToString());
        }

    }
}
