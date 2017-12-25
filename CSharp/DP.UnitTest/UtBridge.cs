using System;
using System.Diagnostics;
using DP.Domain.Samples.Strategy;
using DP.Domain.Samples.Facade;
using DP.UnitTest.Utility;
using Xunit;
using Xunit.Abstractions;
using DP.Domain.Samples.Bridge;

namespace DP.UnitTest
{
    public class UtBridge
    {
        private readonly ITestOutputHelper output;

        public UtBridge(ITestOutputHelper output)
        {
            this.output = output;
            System.Diagnostics.Trace.Listeners.Add(new XunitTraceListener(this.output));
        }

        [Fact]
        public void TestStrategy()
        {
            #region 列印第一家廠商:產品B的訂單
            IPrinter prtUsual = new PrinterUsual();
            prtUsual.OrderB();
            #endregion

            #region 列印第二家廠商:產品A的急單
            IPrinter prtEmg = new PrinterEmergency();
            prtEmg.OrderA();
            #endregion
        }

        [Fact]
        public void TestBridge()
        {
            #region 列印第一家廠商:產品B的訂單
            IOrder order1 = new FatbookOrder(new PrinterUsual());
            order1.PrintOrderB();
            #endregion

            #region 列印第二家廠商:產品A的急單
            IOrder order2 = new GoopleOrder(new PrinterEmergency());
            order2.PrintOrderA();
            #endregion

            #region 列印第二家廠商:產品B的訂單=>但該廠商並無產品B
            IOrder order3 = new GoopleOrder(new PrinterUsual());
            order2.PrintOrderB();
            #endregion
        }
    }
}