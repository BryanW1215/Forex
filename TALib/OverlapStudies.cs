using System;
using TicTacTec.TA.Library;

namespace TALib
{
    public static class OverlapStudies
    {
        public static double MovingAverage(float[] inReal, int period, Core.MAType type)
        {
            int begIndex;
            int numElements;
            double[] outReal = new double[inReal.Length];
            Core.MovingAverage(0, inReal.Length-1, inReal, period, type, out begIndex, out numElements, outReal);
            return outReal[0];
        }

        public static double SAR(float[] inHigh, float[] inLow, double acceleration = .02, double maximum = .2)
        {
            int begIndex;
            int numElements;
            double[] outReal = new double[inHigh.Length];            
            Core.Sar(0, inHigh.Length - 1, inHigh, inLow, acceleration, maximum, out begIndex, out numElements, outReal);
            return outReal[0];
        }
    }
}