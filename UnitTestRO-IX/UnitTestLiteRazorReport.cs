using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared;

namespace UnitTestRO_IX
{
    [TestClass]
    public class UnitTestLiteRazorReport
    {
        [TestMethod]
        public void TestMethodLiteRazorReport()
        {
            // 1
            var LRR = new LiteRazorReport("Hello, @w!");
            LRR.Vars.Add("w", "World");
            Console.WriteLine(LRR.Template);
            Console.WriteLine(LRR.Report());
            Assert.AreEqual("Hello, World!", LRR.Report());
            // 2
            LRR = new LiteRazorReport("<vars>@a then @b</vars>");
            LRR.Vars.Add("a", "one");
            LRR.Vars.Add("b", "two");
            Console.WriteLine(LRR.Template);
            Console.WriteLine(LRR.Report());
            Assert.AreEqual("<vars>one then two</vars>", LRR.Report());
            // 3
            LRR = new LiteRazorReport("A@a, lets show AT: @@. Let's go on one more: @@@a");
            LRR.Vars.Add("a", "1");
            Console.WriteLine(LRR.Template);
            Console.WriteLine(LRR.Report());
            Assert.AreEqual("A1, lets show AT: @. Let's go on one more: @1", LRR.Report());
        }
    }
}
