using MathLibraryOld;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibraryTest.nUnit
{
    [TestFixture]
    public class CalculatorTest
    {
        Calculator c;

        [SetUp]
        public void Setup()
        {
            c = new Calculator();
        }

        [Test]
        public void Calculator_Add_Positive()
        {
            // Arrenge  
            //Calculator c = new Calculator();
            int a = 10 , b = 20 ;
            int ExpectedResult = 30;
      
            // Act
            int ActualResult = c.Add(a, b);

            // Assert
            Assert.AreEqual(ExpectedResult, ActualResult);
        }

        [Test]
        public void Calculator_Add_Negative()
        {
            // Arrenge 
           // Calculator c = new Calculator();
            int a = 10, b = 20;
            int ExpectedResult = 10;

            // Act
            int ActualResult = c.Add(a, b);

            // Assert
            Assert.AreNotEqual(ExpectedResult, ActualResult);
        }
    }
}
