using MathLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLibraryMsTest
{
    [TestClass]
    public class MathLibraryTest
    {
        Calculator c;

        [TestInitialize]
        public void Setup()
        {
           c = new Calculator();
        }

        [TestMethod]
        public void Calculator_Add_Positive()
        {
            // Arrenge 
            
          //  Calculator c = new Calculator();
            int a = 10, b = 10;
            int ExeptedResult = 20;

            // Act 
            int ActualResult = c.Add(a,b);

            // Assert
            Assert.AreEqual(ExeptedResult, ActualResult);
        }

        [TestMethod]
        public void Calculator_Add_Negative()
        {
            // Arrenge 

           // Calculator c = new Calculator();
            int a = 10, b = 10;
            int ExeptedResult = 30;

            // Act 
            int ActualResult = c.Add(a,b);

            // Assert
            Assert.AreNotEqual(ExeptedResult, ActualResult);
        }

        [TestMethod]
        public void Calculator_Sub_Positive()
        {
            // Arrenge 

            //Calculator c = new Calculator();
            int a = 10, b = 10;
            int ExeptedResult = 0;

            // Act 
            int ActualResult = c.Subtract(a,b);

            // Assert
            Assert.AreEqual(ExeptedResult, ActualResult);
        }
        [TestMethod]
        public void Calculator_Sub_Negative()
        {
            // Arrenge 

           // Calculator c = new Calculator();
            int a = 10, b = 10;
            int ExeptedResult = 1;

            // Act 
            int ActualResult = c.Subtract(a, b);

            // Assert
            Assert.AreNotEqual(ExeptedResult, ActualResult);
        }
    }
}
