using System;
using System.Diagnostics;
using DP.Domain.Samples.State;
using DP.UnitTest.Utility;
using Xunit;
using Xunit.Abstractions;

namespace DP.UnitTest
{
    public class UtState
    {
        private readonly ITestOutputHelper _output;

        public UtState(ITestOutputHelper output)
        {
            this._output = output;
            System.Diagnostics.Trace.Listeners.Add(new XunitTraceListener(this._output));
        }

        [Fact]
        public void TestState()
        {
            var expectedFinalState = "Done(已完成)";
            var actualFinalState = string.Empty;

            var context = new Context();
            int hasDefect = 0;
            while (context.CurrentState != null)
            {
                actualFinalState = context.CurrentState.ToString();
                Trace.WriteLine($"需求目前狀態={actualFinalState}");
                // 主程式(回到上一個狀態)
                if (hasDefect == 2) // StateTesting(第一次測試失敗)
                    context.ActionBack();
                else context.Action();
                hasDefect++;
            }

            Assert.Equal(expectedFinalState, actualFinalState);
        }
    }
}
