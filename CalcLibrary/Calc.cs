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

            var assm = Assembly.GetAssembly(typeof(IOperation));
            var types = assm.GetTypes().ToList();
            var ioper = typeof(IOperation);
            // найти библиотеку
            var dlls = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.dll");
            foreach(var dll in dlls)
            {
                assm = Assembly.LoadFrom(dll);
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
        }


        /// <summary>
        /// Выполнить операцию
        /// </summary>
        /// <param name="operation">Название операции</param>
        /// <param name="args">Аргументы операции</param>
        /// <returns>Результат операции</returns>
        public object Execute(string operation, object[] args)
        {
            // находим операцию в списке доступных
            var oper = Operations.FirstOrDefault(it => it.Name == operation);

            // если не нашли - возвр ошибку
            if (oper == null) throw new ArgumentException();

            // если нашли - разбираем и возвращаем результат
            double x, y;
            double.TryParse(args[0].ToString(), out x);
            double.TryParse(args[1].ToString(), out y);

            double result = 0;

            var operArgs = oper as IOperationArgs;
            if (operArgs != null)
            {
                result = operArgs.Calc(args.OfType<double>());
            }
            else
            {
                result = oper.Calc(x, y);
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
