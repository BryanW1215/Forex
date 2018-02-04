using System;
using System.ComponentModel;
using TicTacTec.TA.Library;

namespace TALib
{
    public class stochasticResult
    {
        public double slowD;
        public double slowK;
    }

    public static class Oscillators
    {
        public static stochasticResult Stochastic(float[] inHigh, float[] inLow, float[] inClose, int FastK_Period,
            int SlowK_Period, int SlowD_Period, Core.MAType FastK_MAType = Core.MAType.Sma, 
            Core.MAType SlowD_MAType = Core.MAType.Sma)
        {
            var startIdx = 0;
            var endIdx = inHigh.Length - 1;
            var slowD = new double[inHigh.Length];
            var slowK = new double[inHigh.Length];
            int begIndex;
            int nbElements;
            Core.Stoch(startIdx, endIdx, inHigh, inLow, inClose, FastK_Period, SlowK_Period, FastK_MAType, SlowD_Period,
                SlowD_MAType, out begIndex, out nbElements, slowK, slowD);
            return new stochasticResult() {slowD = slowD[0], slowK = slowK[0]};
        }
    }
}