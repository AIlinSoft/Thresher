using AIlins.Thresher;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;

namespace Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 10000000;
            int len = 24;
            int seriesCount = 8;

            double[] source1 = new double[len];
            for (int i = 0; i < len; ++i)
                source1[i] = i;
            double[] source2 = new double[len];
            for (int i = 0; i < len; ++i)
                source2[i] = i;
            double[] dest = new double[len];

            for (int i = 0; i < seriesCount; ++i)
                RunSeries(count, source1, source2, dest);

            Console.WriteLine("Done! Press any key to exit.");
            Console.ReadKey();
        }
        static void RunSeries(int count, double[] source1, double[] source2, double[] dest)
        {
            Test1(count, source1, source2, dest);
            Test2(count, source1, source2, dest);
            Test3(count, source1, source2, dest);
        }
        static void Test1(int count, double[] source1, double[] source2, double[] dest)
        {
            for (int i = 0; i < dest.Length; ++i)
                dest[i] = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start(); 
            for (int i = 0; i < count; ++i)
                Addition2(source1, source2, dest);
            sw.Stop();
            Console.WriteLine($"{nameof(Test1)} time: {(sw.Elapsed)}");
        }
        static void Test2(int count, double[] source1, double[] source2, double[] dest)
        {
            for (int i = 0; i < dest.Length; ++i)
                dest[i] = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < count; ++i)
                Addition3(source1, source2, dest);
            sw.Stop();
            Console.WriteLine($"{nameof(Test2)} time: {(sw.Elapsed)}");
        }
        static void Test3(int count, double[] source1, double[] source2, double[] dest)
        {
            for (int i = 0; i < dest.Length; ++i)
                dest[i] = 0;
            DoubleArraySolver solver = new DoubleArraySolver();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < count; ++i)
                solver.Addition(source1, source2, dest);
            sw.Stop();
            Console.WriteLine($"{nameof(Test3)} time: {(sw.Elapsed)}");
        }

        //unsafe static void Addition(double[] source1, double[] source2, double[] dest, int length, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        //{
        //    var vlhs = MemoryMarshal.Cast<double, Vector<double>>(source1);
        //    var vrhs = MemoryMarshal.Cast<double, Vector<double>>(source2);
        //    var vres = MemoryMarshal.Cast<double, Vector<double>>(dest);
        //    for (var i = 0; i < vlhs.Length; i++)
        //        vres[i] = vlhs[i] + vrhs[i];
        //}
        unsafe static void Addition2(double[] value1, double[] value2, double[] result, int length = int.MaxValue, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            if (length == int.MaxValue)
                length = value1.Length - value1Index;
            fixed (double* ptrValue1 = value1)
            fixed (double* ptrValue2 = value2)
            fixed (double* ptrResult = result)
            {
                var i = 0;
                for (; i + 3 < length; i += 4)
                    Avx2.Store(ptrResult + i, Avx2.Add(Avx.LoadVector256(ptrValue1 + i), Avx2.LoadVector256(ptrValue2 + i)));
                if (length - i > 1)
                {
                    *(ptrResult + i) = *(ptrValue1 + i) + *(ptrValue2 + i);
                    *(ptrResult + i + 1) = *(ptrValue1 + i + 1) + *(ptrValue2 + i + 1);
                    i += 2;
                }
                if (length > i)
                    *(ptrResult + i) = *(ptrValue1 + i) + *(ptrValue2 + i);
            }
        }
        unsafe static void Addition3(double[] source1, double[] source2, double[] dest, int length = int.MaxValue, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            if (length == int.MaxValue)
                length = source1.Length - value1Index;
            fixed (double* plhs = source1)
            fixed (double* prhs = source2)
            fixed (double* pres = dest)
            {
                AdditionUnsafe(plhs, prhs, pres, length, value1Index, value2Index, resultIndex);
            }
        }

        unsafe internal static void AdditionUnsafe(double* value1, double* value2, double* result, int length, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            double* ptrValue1 = value1 + value1Index;
            double* ptrValue2 = value2 + value2Index;
            double* ptrResult = result + resultIndex;
            int count = 0;
            while (length - count > 31)
            {
                Avx.Store(ptrResult + count, Avx.Add(Avx.LoadVector256(ptrValue1 + count), Avx.LoadVector256(ptrValue2 + count)));
                count += 4;
                Avx.Store(ptrResult + count, Avx.Add(Avx.LoadVector256(ptrValue1 + count), Avx.LoadVector256(ptrValue2 + count)));
                count += 4;
                Avx.Store(ptrResult + count, Avx.Add(Avx.LoadVector256(ptrValue1 + count), Avx.LoadVector256(ptrValue2 + count)));
                count += 4;
                Avx.Store(ptrResult + count, Avx.Add(Avx.LoadVector256(ptrValue1 + count), Avx.LoadVector256(ptrValue2 + count)));
                count += 4;
                Avx.Store(ptrResult + count, Avx.Add(Avx.LoadVector256(ptrValue1 + count), Avx.LoadVector256(ptrValue2 + count)));
                count += 4;
                Avx.Store(ptrResult + count, Avx.Add(Avx.LoadVector256(ptrValue1 + count), Avx.LoadVector256(ptrValue2 + count)));
                count += 4;
                Avx.Store(ptrResult + count, Avx.Add(Avx.LoadVector256(ptrValue1 + count), Avx.LoadVector256(ptrValue2 + count)));
                count += 4;
                Avx.Store(ptrResult + count, Avx.Add(Avx.LoadVector256(ptrValue1 + count), Avx.LoadVector256(ptrValue2 + count)));
                count += 4;
            }
            if (length - count > 15)
            {
                Avx.Store(ptrResult + count, Avx.Add(Avx.LoadVector256(ptrValue1 + count), Avx.LoadVector256(ptrValue2 + count)));
                count += 4;
                Avx.Store(ptrResult + count, Avx.Add(Avx.LoadVector256(ptrValue1 + count), Avx.LoadVector256(ptrValue2 + count)));
                count += 4;
                Avx.Store(ptrResult + count, Avx.Add(Avx.LoadVector256(ptrValue1 + count), Avx.LoadVector256(ptrValue2 + count)));
                count += 4;
                Avx.Store(ptrResult + count, Avx.Add(Avx.LoadVector256(ptrValue1 + count), Avx.LoadVector256(ptrValue2 + count)));
                count += 4;
            }
            if (length - count > 7)
            {
                Avx.Store(ptrResult + count, Avx.Add(Avx.LoadVector256(ptrValue1 + count), Avx.LoadVector256(ptrValue2 + count)));
                count += 4;
                Avx.Store(ptrResult + count, Avx.Add(Avx.LoadVector256(ptrValue1 + count), Avx.LoadVector256(ptrValue2 + count)));
                count += 4;
            }
            if (length - count > 3)
            {
                Avx.Store(ptrResult + count, Avx.Add(Avx.LoadVector256(ptrValue1 + count), Avx.LoadVector256(ptrValue2 + count)));
                count += 4;
            }
            if (length - count > 1)
            {
                *(ptrResult + count) = *(ptrValue1 + count) + *(ptrValue2 + count);
                *(ptrResult + count + 1) = *(ptrValue1 + count + 1) + *(ptrValue2 + count + 1);
                count += 2;
            }
            if (length > count)
                *ptrResult = *ptrValue1 + *ptrValue2;
        }

    }
}
