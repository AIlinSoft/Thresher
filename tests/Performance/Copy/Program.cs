using AIlins.Thresher;
using System;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace Copy
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 1000000;
            int len = 20000;
            int[] source = new int[len];
            for (int i = 0; i < len; ++i)
                source[i] = (int)i;
            int[] dest = new int[len];
            int seriesCount = 5;

            for (int i = 0; i < seriesCount; ++i)
                RunSeries(count, source, dest);

            Console.WriteLine("Done! Press any key to exit.");
            Console.ReadKey();
        }
        static void RunSeries(int count, int[] source, int[] dest)
        {
            Test1(count, source, dest);
            Test2(count, source, dest);
            Test3(count, source, dest);
            Test4(count, source, dest);
        }
        static void Test1(int count, int[] source, int[] dest)
        {
            DateTime now = DateTime.Now;
            for(int i = 0; i < count; ++i)
                Array.Copy(source, 0, dest, 0, source.Length);
            Console.WriteLine($"{nameof(Test1)} time: {(DateTime.Now - now)}");
        }
        static void Test2(int count, int[] source, int[] dest)
        {
            DateTime now = DateTime.Now;
            for (int i = 0; i < count; ++i)
                System.Buffer.BlockCopy(source, 0, dest, 0, source.Length);
            Console.WriteLine($"{nameof(Test2)} time: {(DateTime.Now - now)}");
        }
        static void Test3(int count, int[] source, int[] dest)
        {
            for (int i = 0; i < dest.Length; ++i)
                dest[i] = 0;
            DateTime now = DateTime.Now;
            for (int i = 0; i < count; ++i)
                ArrayCopyHelper.Copy(source, dest, source.Length);
            Console.WriteLine($"{nameof(Test3)} time: {(DateTime.Now - now)}");
        }
        static void Test4(int count, int[] source, int[] dest)
        {
            for (int i = 0; i < dest.Length; ++i)
                dest[i] = 0;
            DateTime now = DateTime.Now;
            for (int i = 0; i < count; ++i)
                Copy(source, dest, source.Length);
            Console.WriteLine($"{nameof(Test4)} time: {(DateTime.Now - now)}");
        }

        unsafe static void Copy(int[] source, int[] dest, int length = int.MaxValue, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            if (length == int.MaxValue)
                length = source.Length - value1Index;
            fixed (int* plhs = source)
            fixed (int* pres = dest)
            {
                CopyUnsafe(plhs, pres, length, value1Index, value2Index, resultIndex);
            }
        }

        unsafe internal static void CopyUnsafe(int* value, int* result, int length, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            int vin = 8;
            int* ptrValue = value + value1Index;
            int* ptrResult = result + resultIndex;
            int count = 0;
            while (length - count > 31)
            {
                Avx2.Store(ptrResult + count, Avx.LoadVector256(ptrValue + count));
                count += vin;
                Avx2.Store(ptrResult + count, Avx.LoadVector256(ptrValue + count));
                count += vin;
                Avx2.Store(ptrResult + count, Avx.LoadVector256(ptrValue + count));
                count += vin;
                Avx2.Store(ptrResult + count, Avx.LoadVector256(ptrValue + count));
                count += vin;
            }
            if (length - count > 15)
            {
                Avx2.Store(ptrResult + count, Avx.LoadVector256(ptrValue + count));
                count += vin;
                Avx2.Store(ptrResult + count, Avx.LoadVector256(ptrValue + count));
                count += vin;
            }
            if (length - count > 7)
            {
                Avx2.Store(ptrResult + count, Avx.LoadVector256(ptrValue + count));
                count += vin;
            }
            if (length - count > 3)
            {
                *(ptrResult + count) = *(ptrValue + count);
                *(ptrResult + count + 1) = *(ptrValue + count + 1);
                *(ptrResult + count + 2) = *(ptrValue + count + 2);
                *(ptrResult + count + 3) = *(ptrValue + count + 3);
                count += 4;
            }
            if (length - count > 1)
            {
                *(ptrResult + count) = *(ptrValue + count);
                *(ptrResult + count + 1) = *(ptrValue + count + 1);
                count += 2;
            }
            if (length > count)
                *ptrResult = *ptrValue;
        }

    }
}
