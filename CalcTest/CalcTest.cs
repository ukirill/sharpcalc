using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalcTest
{
    [TestClass]
    public class CalcTest
    {
        [TestMethod]
        public void TestSum()
        {
            //Arrange, настройка объекта тестирования
            var test = new CalcLibrary.Calc();
            //Act, действие над объектом тестирования
            var result = test.Sum(1, 2);
            var result1 = test.Sum(3, 7);
            var result2 = test.Execute("sum", new object[] { 1, 2 });
            var result3 = test.Execute("sum", new object[] { 3, 7 });
            //Assert, проверка результата тестирования
            Assert.AreEqual(result, 3);
            Assert.AreEqual(result1, 10);

            Assert.AreEqual(result2, 3d);
            Assert.AreEqual(result3, 10d);

            //Добавить поддержку double, double.NaN
            //Добавить поддержку еще четырех функций (вкл. возведение в степень)
            //
        }

        [TestMethod]
        public void TestDivide()
        {
            
            var test = new CalcLibrary.Calc();
            
            var result = test.Divide(1, 2);
            var result1 = test.Divide(5, 2);
            var result2 = test.Divide(1, 0);

            var result3 = test.Execute("divide", new object[] { 1, 2 });
            var result4 = test.Execute("divide", new object[] { 5, 2 });
            var result5 = test.Execute("divide", new object[] { 1, 0 });

            Assert.AreEqual(result, 0.5);
            Assert.AreEqual(result1, 2.5);
            Assert.AreEqual(result2, Double.NaN);

            Assert.AreEqual(result3, 0.5);
            Assert.AreEqual(result4, 2.5);
            Assert.AreEqual(result5, Double.NaN);

        }

        [TestMethod]
        public void TestMultiply()
        {

            var test = new CalcLibrary.Calc();

            var result = test.Execute("multiply", new object[] { 1, 2 });
            var result1 = test.Execute("multiply", new object[] { 2, 2.5 });
            var result2 = test.Execute("multiply", new object[] { 1, 0 });

            Assert.AreEqual(result, 2d);
            Assert.AreEqual(result1, 5d);
            Assert.AreEqual(result2, 0d);
        }

        [TestMethod]
        public void TestDeduct()
        {

            var test = new CalcLibrary.Calc();

            var result = test.Execute("deduct", new object[] { 1, 2 });
            var result1 = test.Execute("deduct", new object[] { 3, 2.5 });
            var result2 = test.Execute("deduct", new object[] { 1, 0 });

            Assert.AreEqual(result, -1d);
            Assert.AreEqual(result1, 0.5);
            Assert.AreEqual(result2, 1d);
        }

        [TestMethod]
        public void TestPower()
        {

            var test = new CalcLibrary.Calc();

            var result = test.Execute("power", new object[] { 1, 2 });
            var result1 = test.Execute("power", new object[] { 3, 2 });
            var result2 = test.Execute("power", new object[] { 2, 0 });

            Assert.AreEqual(result, 1d);
            Assert.AreEqual(result1, 9d);
            Assert.AreEqual(result2, 1d);
        }
    }
}
