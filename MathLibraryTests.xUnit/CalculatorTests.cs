using MathLibraryOld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MathLibraryTests.xUnit
{
    public class CalculatorTests
    {
        Calculator c;
         
        public CalculatorTests()
        {
            c = new Calculator();
        }
      
        [Fact]
        public void Calculator_Add_Positive()
        {
            // Arrege 
           // Calculator c = new Calculator();
            int a = 10, b = 10;
            int ExpectedResult = 20;

            // Act
            int ActualResult = c.Add(a, b);

            // Assert
            Assert.Equal(ExpectedResult, ActualResult);
        }

        [Fact]
        public void Calculator_Add_Nagative()
        {
            // Arrege 
            //Calculator c = new Calculator();
            int a = 10, b = 10;
            int ExpectedResult = 11;

            // Act
            int ActualResult = c.Add(a, b);

            // Assert
            Assert.NotEqual(ExpectedResult, ActualResult);
        }
    }
}
