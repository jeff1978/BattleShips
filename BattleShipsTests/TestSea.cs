using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleShips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void SayHelloTest()
        {
            Program thisTest = new Program();
            var thisResult=thisTest.SayHello();
            //var thisResult = Console.ReadLine();
            Assert.AreEqual("Hello World", thisResult);
        }
    }
}