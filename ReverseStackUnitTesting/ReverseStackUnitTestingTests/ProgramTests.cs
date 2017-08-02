using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReverseStackUnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStackUnitTesting.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void reverseStackTestWithCorrectResult()
        {
            //arrange
            Stack<int> inputStack = new Stack<int>();
            inputStack.Push(1);
            inputStack.Push(2);
            inputStack.Push(3);
            Stack<int> expectedStack = new Stack<int>();
            expectedStack.Push(3);
            expectedStack.Push(2);
            expectedStack.Push(1);
            Stack<int> reversedStack = new Stack<int>();
            
            
            // act
            Program.reverseStack(ref inputStack, ref reversedStack);
            int a = expectedStack.Peek();
            int b = reversedStack.Peek();

            // assert
            Assert.IsFalse(reversedStack.Count==0);
            Assert.AreEqual(a, b);
            CollectionAssert.AreEqual(expectedStack, reversedStack);

        }

        [TestMethod()]
        public void reversedStackTestWithWrongResult() {
            //arrange
            Stack<int> inputStack = new Stack<int>();
            inputStack.Push(1);
            inputStack.Push(2);
            inputStack.Push(3);
            Stack<int> expectedStack = new Stack<int>();
            expectedStack.Push(1);
            expectedStack.Push(2);
            expectedStack.Push(3);
            Stack<int> reversedStack = new Stack<int>();


            // act
            Program.reverseStack(ref inputStack, ref reversedStack);
            int a = expectedStack.Peek();
            int b = reversedStack.Peek();

            // assert
            Assert.IsFalse(reversedStack.Count == 0);
            CollectionAssert.AreNotEqual(expectedStack, reversedStack);
        }
    }
}