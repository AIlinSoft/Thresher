#region License
//Copyright (c) 2009-2020, Alan Spelnikov
//All rights reserved.
//Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
//* Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
//* Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer 
//in the documentation and/or other materials provided with the distribution.
//* Neither the name of Alan Spelnikov nor the names of its contributors may be used to endorse or promote products derived from this 
//software without specific prior written permission.
//THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, 
//INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
//IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
//OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; 
//OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT 
//(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
#endregion License
#region Using namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Runtime.InteropServices;
#endregion Using namespaces
#region Working namespace
namespace AIlins.Thresher
{
    public class MatrixOperations
    {
        #region Classes, structures, enums
        [DllImport(@"Thresher.Unmanaged.dll", CallingConvention = CallingConvention.StdCall)]
        extern unsafe static IntPtr LuDecomposition(int m, int n, Block2x2* invalues, int* incolumns, int* inrowIndex);
        #endregion Classes, structures, enums
        #region Constructors
        #endregion Constructors
        #region Variables
        #endregion Variables
        #region Fields
        #endregion Fields
        #region Methods
        #region Public methods
        #region Addition
        #region double
        /// <summary>
        /// Addition two matrix of real values
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        unsafe public static void Addition(int m, int n, double[] value1, double[] value2, double[] result)
        {
            int size = m * n;
            if (size != value1.Length)
                throw new ArgumentOutOfRangeException("value1");
            if (size != value2.Length)
                throw new ArgumentOutOfRangeException("value2");
            if (size != result.Length)
                throw new ArgumentOutOfRangeException("result");
            fixed (double* value1Pointer = value1, value2Pointer = value2, resultPointer = result)
            {
                double* ptrValue1 = value1Pointer;
                double* ptrValue2 = value2Pointer;
                double* ptrResult = resultPointer;
                double* ptrEnd = resultPointer + size - 31;
                // Main loop, pointers for row values
                while (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 + *ptrValue2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) + *(ptrValue2 + 1);
                    *(ptrResult + 2) = *(ptrValue1 + 2) + *(ptrValue2 + 2);
                    *(ptrResult + 3) = *(ptrValue1 + 3) + *(ptrValue2 + 3);
                    *(ptrResult + 4) = *(ptrValue1 + 4) + *(ptrValue2 + 4);
                    *(ptrResult + 5) = *(ptrValue1 + 5) + *(ptrValue2 + 5);
                    *(ptrResult + 6) = *(ptrValue1 + 6) + *(ptrValue2 + 6);
                    *(ptrResult + 7) = *(ptrValue1 + 7) + *(ptrValue2 + 7);
                    *(ptrResult + 8) = *(ptrValue1 + 8) + *(ptrValue2 + 8);
                    *(ptrResult + 9) = *(ptrValue1 + 9) + *(ptrValue2 + 9);
                    *(ptrResult + 10) = *(ptrValue1 + 10) + *(ptrValue2 + 10);
                    *(ptrResult + 11) = *(ptrValue1 + 11) + *(ptrValue2 + 11);
                    *(ptrResult + 12) = *(ptrValue1 + 12) + *(ptrValue2 + 12);
                    *(ptrResult + 13) = *(ptrValue1 + 13) + *(ptrValue2 + 13);
                    *(ptrResult + 14) = *(ptrValue1 + 14) + *(ptrValue2 + 14);
                    *(ptrResult + 15) = *(ptrValue1 + 15) + *(ptrValue2 + 15);
                    *(ptrResult + 16) = *(ptrValue1 + 16) + *(ptrValue2 + 16);
                    *(ptrResult + 17) = *(ptrValue1 + 17) + *(ptrValue2 + 17);
                    *(ptrResult + 18) = *(ptrValue1 + 18) + *(ptrValue2 + 18);
                    *(ptrResult + 19) = *(ptrValue1 + 19) + *(ptrValue2 + 19);
                    *(ptrResult + 20) = *(ptrValue1 + 20) + *(ptrValue2 + 20);
                    *(ptrResult + 21) = *(ptrValue1 + 21) + *(ptrValue2 + 21);
                    *(ptrResult + 22) = *(ptrValue1 + 22) + *(ptrValue2 + 22);
                    *(ptrResult + 23) = *(ptrValue1 + 23) + *(ptrValue2 + 23);
                    *(ptrResult + 24) = *(ptrValue1 + 24) + *(ptrValue2 + 24);
                    *(ptrResult + 25) = *(ptrValue1 + 25) + *(ptrValue2 + 25);
                    *(ptrResult + 26) = *(ptrValue1 + 26) + *(ptrValue2 + 26);
                    *(ptrResult + 27) = *(ptrValue1 + 27) + *(ptrValue2 + 27);
                    *(ptrResult + 28) = *(ptrValue1 + 28) + *(ptrValue2 + 28);
                    *(ptrResult + 29) = *(ptrValue1 + 29) + *(ptrValue2 + 29);
                    *(ptrResult + 30) = *(ptrValue1 + 30) + *(ptrValue2 + 30);
                    *(ptrResult + 31) = *(ptrValue1 + 31) + *(ptrValue2 + 31);
                    ptrResult += 32;
                    ptrValue1 += 32;
                    ptrValue2 += 32;
                }
                ptrEnd += 16;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 + *ptrValue2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) + *(ptrValue2 + 1);
                    *(ptrResult + 2) = *(ptrValue1 + 2) + *(ptrValue2 + 2);
                    *(ptrResult + 3) = *(ptrValue1 + 3) + *(ptrValue2 + 3);
                    *(ptrResult + 4) = *(ptrValue1 + 4) + *(ptrValue2 + 4);
                    *(ptrResult + 5) = *(ptrValue1 + 5) + *(ptrValue2 + 5);
                    *(ptrResult + 6) = *(ptrValue1 + 6) + *(ptrValue2 + 6);
                    *(ptrResult + 7) = *(ptrValue1 + 7) + *(ptrValue2 + 7);
                    *(ptrResult + 8) = *(ptrValue1 + 8) + *(ptrValue2 + 8);
                    *(ptrResult + 9) = *(ptrValue1 + 9) + *(ptrValue2 + 9);
                    *(ptrResult + 10) = *(ptrValue1 + 10) + *(ptrValue2 + 10);
                    *(ptrResult + 11) = *(ptrValue1 + 11) + *(ptrValue2 + 11);
                    *(ptrResult + 12) = *(ptrValue1 + 12) + *(ptrValue2 + 12);
                    *(ptrResult + 13) = *(ptrValue1 + 13) + *(ptrValue2 + 13);
                    *(ptrResult + 14) = *(ptrValue1 + 14) + *(ptrValue2 + 14);
                    *(ptrResult + 15) = *(ptrValue1 + 15) + *(ptrValue2 + 15);
                    ptrResult += 16;
                    ptrValue1 += 16;
                    ptrValue2 += 16;
                }
                ptrEnd += 8;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 + *ptrValue2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) + *(ptrValue2 + 1);
                    *(ptrResult + 2) = *(ptrValue1 + 2) + *(ptrValue2 + 2);
                    *(ptrResult + 3) = *(ptrValue1 + 3) + *(ptrValue2 + 3);
                    *(ptrResult + 4) = *(ptrValue1 + 4) + *(ptrValue2 + 4);
                    *(ptrResult + 5) = *(ptrValue1 + 5) + *(ptrValue2 + 5);
                    *(ptrResult + 6) = *(ptrValue1 + 6) + *(ptrValue2 + 6);
                    *(ptrResult + 7) = *(ptrValue1 + 7) + *(ptrValue2 + 7);
                    ptrResult += 8;
                    ptrValue1 += 8;
                    ptrValue2 += 8;
                }
                ptrEnd += 4;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 + *ptrValue2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) + *(ptrValue2 + 1);
                    *(ptrResult + 2) = *(ptrValue1 + 2) + *(ptrValue2 + 2);
                    *(ptrResult + 3) = *(ptrValue1 + 3) + *(ptrValue2 + 3);
                    ptrResult += 4;
                    ptrValue1 += 4;
                    ptrValue2 += 4;
                }
                ptrEnd += 2;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 + *ptrValue2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) + *(ptrValue2 + 1);
                    ptrResult += 2;
                    ptrValue1 += 2;
                    ptrValue2 += 2;
                }
                if (ptrResult == ptrEnd)
                    *ptrResult = *ptrValue1 + *ptrValue2;
            }
        }
        unsafe public static void Addition(int m, int n, double[] value1, double value2, double[] result)
        {
            int size = m * n;
            if (size > value1.Length)
                throw new ArgumentOutOfRangeException("value1");
            if (size > result.Length)
                throw new ArgumentOutOfRangeException("result");
            fixed (double* value1Pointer = value1, resultPointer = result)
            {
                double* ptrValue1 = value1Pointer;
                double* ptrResult = resultPointer;
                double* ptrEnd = resultPointer + size - 31;
                // Main loop, pointers for row values
                while (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 + value2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) + value2;
                    *(ptrResult + 2) = *(ptrValue1 + 2) + value2;
                    *(ptrResult + 3) = *(ptrValue1 + 3) + value2;
                    *(ptrResult + 4) = *(ptrValue1 + 4) + value2;
                    *(ptrResult + 5) = *(ptrValue1 + 5) + value2;
                    *(ptrResult + 6) = *(ptrValue1 + 6) + value2;
                    *(ptrResult + 7) = *(ptrValue1 + 7) + value2;
                    *(ptrResult + 8) = *(ptrValue1 + 8) + value2;
                    *(ptrResult + 9) = *(ptrValue1 + 9) + value2;
                    *(ptrResult + 10) = *(ptrValue1 + 10) + value2;
                    *(ptrResult + 11) = *(ptrValue1 + 11) + value2;
                    *(ptrResult + 12) = *(ptrValue1 + 12) + value2;
                    *(ptrResult + 13) = *(ptrValue1 + 13) + value2;
                    *(ptrResult + 14) = *(ptrValue1 + 14) + value2;
                    *(ptrResult + 15) = *(ptrValue1 + 15) + value2;
                    *(ptrResult + 16) = *(ptrValue1 + 16) + value2;
                    *(ptrResult + 17) = *(ptrValue1 + 17) + value2;
                    *(ptrResult + 18) = *(ptrValue1 + 18) + value2;
                    *(ptrResult + 19) = *(ptrValue1 + 19) + value2;
                    *(ptrResult + 20) = *(ptrValue1 + 20) + value2;
                    *(ptrResult + 21) = *(ptrValue1 + 21) + value2;
                    *(ptrResult + 22) = *(ptrValue1 + 22) + value2;
                    *(ptrResult + 23) = *(ptrValue1 + 23) + value2;
                    *(ptrResult + 24) = *(ptrValue1 + 24) + value2;
                    *(ptrResult + 25) = *(ptrValue1 + 25) + value2;
                    *(ptrResult + 26) = *(ptrValue1 + 26) + value2;
                    *(ptrResult + 27) = *(ptrValue1 + 27) + value2;
                    *(ptrResult + 28) = *(ptrValue1 + 28) + value2;
                    *(ptrResult + 29) = *(ptrValue1 + 29) + value2;
                    *(ptrResult + 30) = *(ptrValue1 + 30) + value2;
                    *(ptrResult + 31) = *(ptrValue1 + 31) + value2;
                    ptrResult += 32;
                    ptrValue1 += 32;
                }
                ptrEnd += 16;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 + value2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) + value2;
                    *(ptrResult + 2) = *(ptrValue1 + 2) + value2;
                    *(ptrResult + 3) = *(ptrValue1 + 3) + value2;
                    *(ptrResult + 4) = *(ptrValue1 + 4) + value2;
                    *(ptrResult + 5) = *(ptrValue1 + 5) + value2;
                    *(ptrResult + 6) = *(ptrValue1 + 6) + value2;
                    *(ptrResult + 7) = *(ptrValue1 + 7) + value2;
                    *(ptrResult + 8) = *(ptrValue1 + 8) + value2;
                    *(ptrResult + 9) = *(ptrValue1 + 9) + value2;
                    *(ptrResult + 10) = *(ptrValue1 + 10) + value2;
                    *(ptrResult + 11) = *(ptrValue1 + 11) + value2;
                    *(ptrResult + 12) = *(ptrValue1 + 12) + value2;
                    *(ptrResult + 13) = *(ptrValue1 + 13) + value2;
                    *(ptrResult + 14) = *(ptrValue1 + 14) + value2;
                    *(ptrResult + 15) = *(ptrValue1 + 15) + value2;
                    ptrResult += 16;
                    ptrValue1 += 16;
                }
                ptrEnd += 8;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 + value2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) + value2;
                    *(ptrResult + 2) = *(ptrValue1 + 2) + value2;
                    *(ptrResult + 3) = *(ptrValue1 + 3) + value2;
                    *(ptrResult + 4) = *(ptrValue1 + 4) + value2;
                    *(ptrResult + 5) = *(ptrValue1 + 5) + value2;
                    *(ptrResult + 6) = *(ptrValue1 + 6) + value2;
                    *(ptrResult + 7) = *(ptrValue1 + 7) + value2;
                    ptrResult += 8;
                    ptrValue1 += 8;
                }
                ptrEnd += 4;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 + value2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) + value2;
                    *(ptrResult + 2) = *(ptrValue1 + 2) + value2;
                    *(ptrResult + 3) = *(ptrValue1 + 3) + value2;
                    ptrResult += 4;
                    ptrValue1 += 4;
                }
                ptrEnd += 2;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 + value2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) + value2;
                    ptrResult += 2;
                    ptrValue1 += 2;
                }
                if (ptrResult == ptrEnd)
                    *ptrResult = *ptrValue1 + value2;
            }
        }
        public static FullMatrix<double> Addition(FullMatrix<double> value1, FullMatrix<double> value2)
        {
            int m = value1.m_RowsCount;
            int n = value1.m_ColumnsCount;
            if (m != value2.m_RowsCount)
                throw new Exception("Value1 and value2 has different row counts!");
            if (n != value2.m_ColumnsCount)
                throw new Exception("Value1 and value2 has different column counts!");

            double[] tempResult = new double[m * n];
            Addition(m, n, value1.m_Values, value2.m_Values, tempResult);
            FullMatrix<double> returnValue = new FullMatrix<double>();
            returnValue.m_RowsCount = m;
            returnValue.m_ColumnsCount = n;
            returnValue.m_Values = tempResult;
            return returnValue;
        }
        unsafe public static CsrMatrix<double> Addition(CsrMatrix<double> value1, CsrMatrix<double> value2) 
        {
            int m = value1.RowsCount;
            int n = value2.ColumnsCount;
            if (value2.RowsCount != m)
                throw new Exception("Rows counts of first and second matrices not equals!");
            if (value2.ColumnsCount != n)
                throw new Exception("Columns counts of first and second matrices not equals!");
            CsrMatrix<double> returnValue = new CsrMatrix<double>(0, 0, n);

            //uint[] valueArray1 = value1.Values;
            //int[] rowBegins1 = value1.RowBegin;

            //uint[] valueArray2 = value2.Values;
            //int[] rowBegins2 = value2.RowBegin;

            //int[] indexes = new int[n];
            //double[] values = new double[n];
            //int length;
            //fixed (uint* valueArray1Pointer = valueArray1, valueArray2Pointer = valueArray2)
            //fixed (int* ptrRowBegins1 = rowBegins1, ptrRowBegins2 = rowBegins2)
            //{
            //    double sum;
            //    uint rowPosition2;
            //    uint rowPosition1;
            //    uint t1, t2;
            //    uint* counterPointerShiftColumn1 = valueArray1Pointer + value1.ShiftColumn;
            //    uint* counterPointerShiftColumn2 = valueArray2Pointer + value2.ShiftColumn;
            //    uint* counterPointerShiftNext1 = valueArray1Pointer + value1.ShiftNext;
            //    uint* counterPointerShiftNext2 = valueArray2Pointer + value2.ShiftNext;

            //    for (int i = 0; i < m; ++i)
            //    {
            //        rowPosition1 = (uint)rowBegins1[i];
            //        rowPosition2 = (uint)ptrRowBegins2[i];
            //        if (rowPosition1 == 4294967295 && rowPosition2 == 4294967295)
            //            continue;
                            
            //        length = 0;
            //        sum = 0.0;
            //        // Counter for j-column walker
            //        while (rowPosition2 != 4294967295)
            //        {
            //            if (rowPosition1 == 4294967295)
            //                break;
            //            t1 = *(counterPointerShiftColumn1 + rowPosition1);
            //            t2 = *(counterPointerShiftColumn2 + rowPosition2);
            //            if (t1 > t2)
            //            {
            //                rowPosition2 = (uint)*(counterPointerShiftNext2 + rowPosition2);
            //                if (rowPosition2 == 4294967295)
            //                    break;
            //                t2 = *(counterPointerShiftColumn2 + rowPosition2);
            //                if (t1 > t2)
            //                {
            //                    rowPosition2 = (uint)*(counterPointerShiftNext2 + rowPosition2);
            //                    if (rowPosition2 == 4294967295)
            //                        break;
            //                    t2 = *(counterPointerShiftColumn2 + rowPosition2);
            //                    if (t1 > t2)
            //                    {
            //                        rowPosition2 = (uint)*(counterPointerShiftNext2 + rowPosition2);
            //                        if (rowPosition2 == 4294967295)
            //                            break;
            //                        t2 = *(counterPointerShiftColumn2 + rowPosition2);
            //                        if (t1 > t2)
            //                        {
            //                            rowPosition2 = (uint)*(counterPointerShiftNext2 + rowPosition2);
            //                            if (rowPosition2 == 4294967295)
            //                                break;
            //                            t2 = *(counterPointerShiftColumn2 + rowPosition2);
            //                            if (t1 > t2)
            //                            {
            //                                rowPosition2 = (uint)*(counterPointerShiftNext2 + rowPosition2);
            //                                if (rowPosition2 == 4294967295)
            //                                    break;
            //                                t2 = *(counterPointerShiftColumn2 + rowPosition2);
            //                            }
            //                        }
            //                    }
            //                }
            //            }

            //            if (t2 > t1)
            //            {
            //                rowPosition1 = (uint)*(counterPointerShiftNext1 + rowPosition1);
            //                if (rowPosition1 == 4294967295)
            //                    break;
            //                t1 = *(counterPointerShiftColumn1 + rowPosition1);
            //                if (t2 > t1)
            //                {
            //                    rowPosition1 = (uint)*(counterPointerShiftNext1 + rowPosition1);
            //                    if (rowPosition1 == 4294967295)
            //                        break;
            //                    t1 = *(counterPointerShiftColumn1 + rowPosition1);
            //                    if (t2 > t1)
            //                    {
            //                        rowPosition1 = (uint)*(counterPointerShiftNext1 + rowPosition1);
            //                        if (rowPosition1 == 4294967295)
            //                            break;
            //                        t1 = *(counterPointerShiftColumn1 + rowPosition1);
            //                        if (t2 > t1)
            //                        {
            //                            rowPosition1 = (uint)*(counterPointerShiftNext1 + rowPosition1);
            //                            if (rowPosition1 == 4294967295)
            //                                break;
            //                            t1 = *(counterPointerShiftColumn1 + rowPosition1);
            //                            if (t2 > t1)
            //                            {
            //                                rowPosition1 = (uint)*(counterPointerShiftNext1 + rowPosition1);
            //                                if (rowPosition1 == 4294967295)
            //                                    break;
            //                                t1 = *(counterPointerShiftColumn1 + rowPosition1);
            //                            }
            //                        }
            //                    }
            //                }

            //            }
            //            if (t2 == t1)
            //            {
            //                sum += *(double*)*(valueArray1Pointer + rowPosition1) * *(double*)(valueArray2Pointer + rowPosition2);
            //                rowPosition2 = (uint)*(counterPointerShiftNext2 + rowPosition2);
            //                rowPosition1 = (uint)*(counterPointerShiftNext1 + rowPosition1);
            //            }
                        
            //            if (sum != 0)
            //            {
            //                values[length] = sum;
            //                indexes[length] = j;
            //                length++;
            //            }
            //        }
            //        if (length > 0)
            //        {
            //            int[] tempIndexes = new int[length];
            //            double[] tempValues = new double[length];
            //            CommonOperations.FastCopy(values, tempValues, length);
            //            Buffer.BlockCopy(indexes, 0, tempIndexes, 0, length * 4);
            //            returnValue.AddRow(tempIndexes, tempValues);
            //        }
            //    }
            //}
            return returnValue;
        }
        
        #endregion double
        #region Complex
        unsafe public static void Addition(int m, int n, Complex[] value1, Complex[] value2, Complex[] result)
        {
            int size = m * n;
            if (size != value1.Length)
                throw new ArgumentOutOfRangeException("value1");
            if (size != value2.Length)
                throw new ArgumentOutOfRangeException("value2");
            if (size != result.Length)
                throw new ArgumentOutOfRangeException("result");
            fixed (Complex* value1Pointer = value1, value2Pointer = value2, resultPointer = result)
            {
                double* ptrValue1 = (double*)value1Pointer;
                double* ptrValue2 = (double*)value2Pointer;
                double* ptrResult = (double*)resultPointer;
                double* ptrEnd = ptrResult + size * 2 - 31;
                // Main loop, pointers for row values
                while (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 + *ptrValue2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) + *(ptrValue2 + 1);
                    *(ptrResult + 2) = *(ptrValue1 + 2) + *(ptrValue2 + 2);
                    *(ptrResult + 3) = *(ptrValue1 + 3) + *(ptrValue2 + 3);
                    *(ptrResult + 4) = *(ptrValue1 + 4) + *(ptrValue2 + 4);
                    *(ptrResult + 5) = *(ptrValue1 + 5) + *(ptrValue2 + 5);
                    *(ptrResult + 6) = *(ptrValue1 + 6) + *(ptrValue2 + 6);
                    *(ptrResult + 7) = *(ptrValue1 + 7) + *(ptrValue2 + 7);
                    *(ptrResult + 8) = *(ptrValue1 + 8) + *(ptrValue2 + 8);
                    *(ptrResult + 9) = *(ptrValue1 + 9) + *(ptrValue2 + 9);
                    *(ptrResult + 10) = *(ptrValue1 + 10) + *(ptrValue2 + 10);
                    *(ptrResult + 11) = *(ptrValue1 + 11) + *(ptrValue2 + 11);
                    *(ptrResult + 12) = *(ptrValue1 + 12) + *(ptrValue2 + 12);
                    *(ptrResult + 13) = *(ptrValue1 + 13) + *(ptrValue2 + 13);
                    *(ptrResult + 14) = *(ptrValue1 + 14) + *(ptrValue2 + 14);
                    *(ptrResult + 15) = *(ptrValue1 + 15) + *(ptrValue2 + 15);
                    *(ptrResult + 16) = *(ptrValue1 + 16) + *(ptrValue2 + 16);
                    *(ptrResult + 17) = *(ptrValue1 + 17) + *(ptrValue2 + 17);
                    *(ptrResult + 18) = *(ptrValue1 + 18) + *(ptrValue2 + 18);
                    *(ptrResult + 19) = *(ptrValue1 + 19) + *(ptrValue2 + 19);
                    *(ptrResult + 20) = *(ptrValue1 + 20) + *(ptrValue2 + 20);
                    *(ptrResult + 21) = *(ptrValue1 + 21) + *(ptrValue2 + 21);
                    *(ptrResult + 22) = *(ptrValue1 + 22) + *(ptrValue2 + 22);
                    *(ptrResult + 23) = *(ptrValue1 + 23) + *(ptrValue2 + 23);
                    *(ptrResult + 24) = *(ptrValue1 + 24) + *(ptrValue2 + 24);
                    *(ptrResult + 25) = *(ptrValue1 + 25) + *(ptrValue2 + 25);
                    *(ptrResult + 26) = *(ptrValue1 + 26) + *(ptrValue2 + 26);
                    *(ptrResult + 27) = *(ptrValue1 + 27) + *(ptrValue2 + 27);
                    *(ptrResult + 28) = *(ptrValue1 + 28) + *(ptrValue2 + 28);
                    *(ptrResult + 29) = *(ptrValue1 + 29) + *(ptrValue2 + 29);
                    *(ptrResult + 30) = *(ptrValue1 + 30) + *(ptrValue2 + 30);
                    *(ptrResult + 31) = *(ptrValue1 + 31) + *(ptrValue2 + 31);
                    ptrResult += 32;
                    ptrValue1 += 32;
                    ptrValue2 += 32;
                }
                ptrEnd += 16;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 + *ptrValue2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) + *(ptrValue2 + 1);
                    *(ptrResult + 2) = *(ptrValue1 + 2) + *(ptrValue2 + 2);
                    *(ptrResult + 3) = *(ptrValue1 + 3) + *(ptrValue2 + 3);
                    *(ptrResult + 4) = *(ptrValue1 + 4) + *(ptrValue2 + 4);
                    *(ptrResult + 5) = *(ptrValue1 + 5) + *(ptrValue2 + 5);
                    *(ptrResult + 6) = *(ptrValue1 + 6) + *(ptrValue2 + 6);
                    *(ptrResult + 7) = *(ptrValue1 + 7) + *(ptrValue2 + 7);
                    *(ptrResult + 8) = *(ptrValue1 + 8) + *(ptrValue2 + 8);
                    *(ptrResult + 9) = *(ptrValue1 + 9) + *(ptrValue2 + 9);
                    *(ptrResult + 10) = *(ptrValue1 + 10) + *(ptrValue2 + 10);
                    *(ptrResult + 11) = *(ptrValue1 + 11) + *(ptrValue2 + 11);
                    *(ptrResult + 12) = *(ptrValue1 + 12) + *(ptrValue2 + 12);
                    *(ptrResult + 13) = *(ptrValue1 + 13) + *(ptrValue2 + 13);
                    *(ptrResult + 14) = *(ptrValue1 + 14) + *(ptrValue2 + 14);
                    *(ptrResult + 15) = *(ptrValue1 + 15) + *(ptrValue2 + 15);
                    ptrResult += 16;
                    ptrValue1 += 16;
                    ptrValue2 += 16;
                }
                ptrEnd += 8;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 + *ptrValue2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) + *(ptrValue2 + 1);
                    *(ptrResult + 2) = *(ptrValue1 + 2) + *(ptrValue2 + 2);
                    *(ptrResult + 3) = *(ptrValue1 + 3) + *(ptrValue2 + 3);
                    *(ptrResult + 4) = *(ptrValue1 + 4) + *(ptrValue2 + 4);
                    *(ptrResult + 5) = *(ptrValue1 + 5) + *(ptrValue2 + 5);
                    *(ptrResult + 6) = *(ptrValue1 + 6) + *(ptrValue2 + 6);
                    *(ptrResult + 7) = *(ptrValue1 + 7) + *(ptrValue2 + 7);
                    ptrResult += 8;
                    ptrValue1 += 8;
                    ptrValue2 += 8;
                }
                ptrEnd += 4;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 + *ptrValue2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) + *(ptrValue2 + 1);
                    *(ptrResult + 2) = *(ptrValue1 + 2) + *(ptrValue2 + 2);
                    *(ptrResult + 3) = *(ptrValue1 + 3) + *(ptrValue2 + 3);
                    ptrResult += 4;
                    ptrValue1 += 4;
                    ptrValue2 += 4;
                }
                ptrEnd += 2;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 + *ptrValue2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) + *(ptrValue2 + 1);
                    ptrResult += 2;
                    ptrValue1 += 2;
                    ptrValue2 += 2;
                }
                if (ptrResult == ptrEnd)
                    *ptrResult = *ptrValue1 + *ptrValue2;
            }
        }
        public static FullMatrix<Complex> Addition(FullMatrix<Complex> value1, FullMatrix<Complex> value2) 
        {
            int m = value1.m_RowsCount;
            int n = value1.m_ColumnsCount;
            if (m != value2.m_RowsCount)
                throw new Exception("Value1 and value2 has different row counts!");
            if (n != value2.m_ColumnsCount)
                throw new Exception("Value1 and value2 has different column counts!");

            Complex[] tempResult = new Complex[m * n];
            Addition(m, n, value1.m_Values, value2.m_Values, tempResult);
            FullMatrix<Complex> returnValue = new FullMatrix<Complex>();
            returnValue.m_RowsCount = m;
            returnValue.m_ColumnsCount = n;
            returnValue.m_Values = tempResult;
            return returnValue;
        }
        unsafe public static CsrMatrix<Complex> Addition(CsrMatrix<Complex> value1, CsrMatrix<Complex> value2)
        {
            int m = value1.RowsCount;
            int n = value1.ColumnsCount;
            if (value2.RowsCount != m)
                throw new Exception("Rows counts of first and second matrices not equals!");
            if (value2.ColumnsCount != n)
                throw new Exception("Columns counts of first and second matrices not equals!");

            CsrMatrix<Complex> returnValue = new CsrMatrix<Complex>(n);

            fixed (Complex* values1Pointer = value1.m_Values, values2Pointer = value2.m_Values)
            fixed (int* rowIndex1Pointer = value1.m_RowsMapping, rowIndex2Pointer = value2.m_RowsMapping, columns1Pointer = value1.m_Columns, columns2Pointer = value2.m_Columns)
            {
                int index1, end1, index2, end2;
                for (int i = 0; i < m; ++i)
                {
                    Complex[] row = new Complex[n];
                    index1 = *(rowIndex1Pointer + i);
                    index2 = *(rowIndex2Pointer + i);
                    end1 = *(rowIndex1Pointer + i + 1);
                    end2 = *(rowIndex2Pointer + i + 1);
                    
                    while (index1 != end1)
                    {
                        row[*(columns1Pointer + index1)] = *(values1Pointer + index1);
                        index1++;
                    }
                    while (index2 != end2)
                    {
                        row[*(columns2Pointer + index2)] += *(values2Pointer + index2);
                        index2++;
                    }
                  //  returnValue.AddRow(row);
                }
            }
            return returnValue;
        }
        unsafe public static void Addition(CsrMatrix<Complex> value1, FullMatrix<Complex> value2, FullMatrix<Complex> result) { }
        #endregion Complex
        #endregion Addition
        #region Substraction
        #region double
        unsafe public static void Negate(int m, int n, double[] value, double[] result)
        {
            int size = m * n;
            if (size != value.Length)
                throw new ArgumentOutOfRangeException("value1");
             if (size != result.Length)
                throw new ArgumentOutOfRangeException("result");
            fixed (double* valuePointer = value, resultPointer = result)
            {
                double* ptrValue1 = valuePointer;
                double* ptrResult = resultPointer;
                double* ptrEnd = resultPointer + size - 31;
                // Main loop, pointers for row values
                while (ptrResult < ptrEnd)
                {
                    *ptrResult = -*ptrValue1;
                    *(ptrResult + 1) = -*(ptrValue1 + 1);
                    *(ptrResult + 2) = -*(ptrValue1 + 2);
                    *(ptrResult + 3) = -*(ptrValue1 + 3);
                    *(ptrResult + 4) = -*(ptrValue1 + 4);
                    *(ptrResult + 5) = -*(ptrValue1 + 5);
                    *(ptrResult + 6) = -*(ptrValue1 + 6);
                    *(ptrResult + 7) = -*(ptrValue1 + 7);
                    *(ptrResult + 8) = -*(ptrValue1 + 8);
                    *(ptrResult + 9) = -*(ptrValue1 + 9);
                    *(ptrResult + 10) = -*(ptrValue1 + 10);
                    *(ptrResult + 11) = -*(ptrValue1 + 11);
                    *(ptrResult + 12) = -*(ptrValue1 + 12);
                    *(ptrResult + 13) = -*(ptrValue1 + 13);
                    *(ptrResult + 14) = -*(ptrValue1 + 14);
                    *(ptrResult + 15) = -*(ptrValue1 + 15);
                    *(ptrResult + 16) = -*(ptrValue1 + 16);
                    *(ptrResult + 17) = -*(ptrValue1 + 17);
                    *(ptrResult + 18) = -*(ptrValue1 + 18);
                    *(ptrResult + 19) = -*(ptrValue1 + 19);
                    *(ptrResult + 20) = -*(ptrValue1 + 20);
                    *(ptrResult + 21) = -*(ptrValue1 + 21);
                    *(ptrResult + 22) = -*(ptrValue1 + 22);
                    *(ptrResult + 23) = -*(ptrValue1 + 23);
                    *(ptrResult + 24) = -*(ptrValue1 + 24);
                    *(ptrResult + 25) = -*(ptrValue1 + 25);
                    *(ptrResult + 26) = -*(ptrValue1 + 26);
                    *(ptrResult + 27) = -*(ptrValue1 + 27);
                    *(ptrResult + 28) = -*(ptrValue1 + 28);
                    *(ptrResult + 29) = -*(ptrValue1 + 29);
                    *(ptrResult + 30) = -*(ptrValue1 + 30);
                    *(ptrResult + 31) = -*(ptrValue1 + 31);
                    ptrResult += 32;
                    ptrValue1 += 32;
                }
                ptrEnd += 16;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = -*ptrValue1;
                    *(ptrResult + 1) = -*(ptrValue1 + 1);
                    *(ptrResult + 2) = -*(ptrValue1 + 2);
                    *(ptrResult + 3) = -*(ptrValue1 + 3);
                    *(ptrResult + 4) = -*(ptrValue1 + 4);
                    *(ptrResult + 5) = -*(ptrValue1 + 5);
                    *(ptrResult + 6) = -*(ptrValue1 + 6);
                    *(ptrResult + 7) = -*(ptrValue1 + 7);
                    *(ptrResult + 8) = -*(ptrValue1 + 8);
                    *(ptrResult + 9) = -*(ptrValue1 + 9);
                    *(ptrResult + 10) = -*(ptrValue1 + 10);
                    *(ptrResult + 11) = -*(ptrValue1 + 11);
                    *(ptrResult + 12) = -*(ptrValue1 + 12);
                    *(ptrResult + 13) = -*(ptrValue1 + 13);
                    *(ptrResult + 14) = -*(ptrValue1 + 14);
                    *(ptrResult + 15) = -*(ptrValue1 + 15);
                    ptrResult += 16;
                    ptrValue1 += 16;
                }
                ptrEnd += 8;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = -*ptrValue1;
                    *(ptrResult + 1) = -*(ptrValue1 + 1);
                    *(ptrResult + 2) = -*(ptrValue1 + 2);
                    *(ptrResult + 3) = -*(ptrValue1 + 3);
                    *(ptrResult + 4) = -*(ptrValue1 + 4);
                    *(ptrResult + 5) = -*(ptrValue1 + 5);
                    *(ptrResult + 6) = -*(ptrValue1 + 6);
                    *(ptrResult + 7) = -*(ptrValue1 + 7);
                    ptrResult += 8;
                    ptrValue1 += 8;
                }
                ptrEnd += 4;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = -*ptrValue1;
                    *(ptrResult + 1) = -*(ptrValue1 + 1);
                    *(ptrResult + 2) = -*(ptrValue1 + 2);
                    *(ptrResult + 3) = -*(ptrValue1 + 3);
                    ptrResult += 4;
                    ptrValue1 += 4;
                }
                ptrEnd += 2;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = -*ptrValue1;
                    *(ptrResult + 1) = -*(ptrValue1 + 1);
                    ptrResult += 2;
                    ptrValue1 += 2;
                }
                if (ptrResult == ptrEnd)
                    *ptrResult = -*ptrValue1;
            }
        }
        unsafe public static void Substraction(int m, int n, double[] value1, double[] value2, double[] result)
        {
            int size = m * n;
            if (size > value1.Length)
                throw new ArgumentOutOfRangeException("value1");
            if (size > value2.Length)
                throw new ArgumentOutOfRangeException("value2");
            if (size > result.Length)
                throw new ArgumentOutOfRangeException("result");
            fixed (double* value1Pointer = value1, value2Pointer = value2, resultPointer = result)
            {
                double* ptrValue1 = value1Pointer;
                double* ptrValue2 = value2Pointer;
                double* ptrResult = resultPointer;
                double* ptrEnd = resultPointer + size - 31;
                // Main loop, pointers for row values
                while (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 - *ptrValue2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) - *(ptrValue2 + 1);
                    *(ptrResult + 2) = *(ptrValue1 + 2) - *(ptrValue2 + 2);
                    *(ptrResult + 3) = *(ptrValue1 + 3) - *(ptrValue2 + 3);
                    *(ptrResult + 4) = *(ptrValue1 + 4) - *(ptrValue2 + 4);
                    *(ptrResult + 5) = *(ptrValue1 + 5) - *(ptrValue2 + 5);
                    *(ptrResult + 6) = *(ptrValue1 + 6) - *(ptrValue2 + 6);
                    *(ptrResult + 7) = *(ptrValue1 + 7) - *(ptrValue2 + 7);
                    *(ptrResult + 8) = *(ptrValue1 + 8) - *(ptrValue2 + 8);
                    *(ptrResult + 9) = *(ptrValue1 + 9) - *(ptrValue2 + 9);
                    *(ptrResult + 10) = *(ptrValue1 + 10) - *(ptrValue2 + 10);
                    *(ptrResult + 11) = *(ptrValue1 + 11) - *(ptrValue2 + 11);
                    *(ptrResult + 12) = *(ptrValue1 + 12) - *(ptrValue2 + 12);
                    *(ptrResult + 13) = *(ptrValue1 + 13) - *(ptrValue2 + 13);
                    *(ptrResult + 14) = *(ptrValue1 + 14) - *(ptrValue2 + 14);
                    *(ptrResult + 15) = *(ptrValue1 + 15) - *(ptrValue2 + 15);
                    *(ptrResult + 16) = *(ptrValue1 + 16) - *(ptrValue2 + 16);
                    *(ptrResult + 17) = *(ptrValue1 + 17) - *(ptrValue2 + 17);
                    *(ptrResult + 18) = *(ptrValue1 + 18) - *(ptrValue2 + 18);
                    *(ptrResult + 19) = *(ptrValue1 + 19) - *(ptrValue2 + 19);
                    *(ptrResult + 20) = *(ptrValue1 + 20) - *(ptrValue2 + 20);
                    *(ptrResult + 21) = *(ptrValue1 + 21) - *(ptrValue2 + 21);
                    *(ptrResult + 22) = *(ptrValue1 + 22) - *(ptrValue2 + 22);
                    *(ptrResult + 23) = *(ptrValue1 + 23) - *(ptrValue2 + 23);
                    *(ptrResult + 24) = *(ptrValue1 + 24) - *(ptrValue2 + 24);
                    *(ptrResult + 25) = *(ptrValue1 + 25) - *(ptrValue2 + 25);
                    *(ptrResult + 26) = *(ptrValue1 + 26) - *(ptrValue2 + 26);
                    *(ptrResult + 27) = *(ptrValue1 + 27) - *(ptrValue2 + 27);
                    *(ptrResult + 28) = *(ptrValue1 + 28) - *(ptrValue2 + 28);
                    *(ptrResult + 29) = *(ptrValue1 + 29) - *(ptrValue2 + 29);
                    *(ptrResult + 30) = *(ptrValue1 + 30) - *(ptrValue2 + 30);
                    *(ptrResult + 31) = *(ptrValue1 + 31) - *(ptrValue2 + 31);
                    ptrResult += 32;
                    ptrValue1 += 32;
                    ptrValue2 += 32;
                }
                ptrEnd += 16;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 - *ptrValue2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) - *(ptrValue2 + 1);
                    *(ptrResult + 2) = *(ptrValue1 + 2) - *(ptrValue2 + 2);
                    *(ptrResult + 3) = *(ptrValue1 + 3) - *(ptrValue2 + 3);
                    *(ptrResult + 4) = *(ptrValue1 + 4) - *(ptrValue2 + 4);
                    *(ptrResult + 5) = *(ptrValue1 + 5) - *(ptrValue2 + 5);
                    *(ptrResult + 6) = *(ptrValue1 + 6) - *(ptrValue2 + 6);
                    *(ptrResult + 7) = *(ptrValue1 + 7) - *(ptrValue2 + 7);
                    *(ptrResult + 8) = *(ptrValue1 + 8) - *(ptrValue2 + 8);
                    *(ptrResult + 9) = *(ptrValue1 + 9) - *(ptrValue2 + 9);
                    *(ptrResult + 10) = *(ptrValue1 + 10) - *(ptrValue2 + 10);
                    *(ptrResult + 11) = *(ptrValue1 + 11) - *(ptrValue2 + 11);
                    *(ptrResult + 12) = *(ptrValue1 + 12) - *(ptrValue2 + 12);
                    *(ptrResult + 13) = *(ptrValue1 + 13) - *(ptrValue2 + 13);
                    *(ptrResult + 14) = *(ptrValue1 + 14) - *(ptrValue2 + 14);
                    *(ptrResult + 15) = *(ptrValue1 + 15) - *(ptrValue2 + 15);
                    ptrResult += 16;
                    ptrValue1 += 16;
                    ptrValue2 += 16;
                }
                ptrEnd += 8;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 - *ptrValue2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) - *(ptrValue2 + 1);
                    *(ptrResult + 2) = *(ptrValue1 + 2) - *(ptrValue2 + 2);
                    *(ptrResult + 3) = *(ptrValue1 + 3) - *(ptrValue2 + 3);
                    *(ptrResult + 4) = *(ptrValue1 + 4) - *(ptrValue2 + 4);
                    *(ptrResult + 5) = *(ptrValue1 + 5) - *(ptrValue2 + 5);
                    *(ptrResult + 6) = *(ptrValue1 + 6) - *(ptrValue2 + 6);
                    *(ptrResult + 7) = *(ptrValue1 + 7) - *(ptrValue2 + 7);
                    ptrResult += 8;
                    ptrValue1 += 8;
                    ptrValue2 += 8;
                }
                ptrEnd += 4;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 - *ptrValue2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) - *(ptrValue2 + 1);
                    *(ptrResult + 2) = *(ptrValue1 + 2) - *(ptrValue2 + 2);
                    *(ptrResult + 3) = *(ptrValue1 + 3) - *(ptrValue2 + 3);
                    ptrResult += 4;
                    ptrValue1 += 4;
                    ptrValue2 += 4;
                }
                ptrEnd += 2;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 - *ptrValue2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) - *(ptrValue2 + 1);
                    ptrResult += 2;
                    ptrValue1 += 2;
                    ptrValue2 += 2;
                }
                if (ptrResult == ptrEnd)
                    *ptrResult = *ptrValue1 - *ptrValue2;
            }
        }
        public static FullMatrix<double> Substraction(FullMatrix<double> value1, FullMatrix<double> value2)
        {
            int m = value1.m_RowsCount;
            int n = value1.m_ColumnsCount;
            if (m != value2.m_RowsCount)
                throw new Exception("Value1 and value2 has different row counts!");
            if (n != value2.m_ColumnsCount)
                throw new Exception("Value1 and value2 has different column counts!");

            
            double[] tempResult = new double[m * n];
            Substraction(m, n, value1.m_Values, value2.m_Values, tempResult);

            FullMatrix<double> returnValue = new FullMatrix<double>();
            returnValue.m_RowsCount = m;
            returnValue.m_ColumnsCount = n;
            returnValue.m_Values = tempResult;
            return returnValue;
        }
        //unsafe public static CSRMatrix<double> Substraction(CSRMatrix<double> value1, CSRMatrix<double> value2)
        //{
        //    int m = value1.RowsCount;
        //    int n = value2.ColumnsCount;
        //    if (value2.RowsCount != m)
        //        throw new Exception("Rows counts of first and second matrices not equals!");
        //    if (value2.ColumnsCount != n)
        //        throw new Exception("Columns counts of first and second matrices not equals!");
        //    CSRMatrix<double> returnValue = new CSRMatrix<double>(n);

        //    fixed (double* values1Pointer = value1.m_Values, values2Pointer = value2.m_Values)
        //    fixed (int* rowIndex1Pointer = value1.m_RowsMapping, rowIndex2Pointer = value2.m_RowsMapping, columns1Pointer = value1.m_Columns, columns2Pointer = value2.m_Columns)
        //    {
        //        int index1, end1, index2, end2;
        //        for (int i = 0; i < m; ++i)
        //        {
        //            double[] row = new double[n];
        //            index1 = *(rowIndex1Pointer + i);
        //            index2 = *(rowIndex2Pointer + i);
        //            end1 = *(rowIndex1Pointer + i + 1);
        //            end2 = *(rowIndex2Pointer + i + 1);

        //            while (index1 != end1)
        //            {
        //                row[*(columns1Pointer + index1)] = *(values1Pointer + index1);
        //                index1++;
        //            }
        //            while (index2 != end2)
        //            {
        //                row[*(columns2Pointer + index2)] -= *(values2Pointer + index2);
        //                index2++;
        //            }
        //            returnValue.AddRow(row);
        //        }
        //    }
        //    return returnValue;
        //}
        public static FullMatrix<double> Negate(FullMatrix<double> value)
        {
            int m = value.m_RowsCount;
            int n = value.m_ColumnsCount;
            
            double[] tempResult = new double[m * n];
            Negate(m, n, value.m_Values, tempResult);
            FullMatrix<double> returnValue = new FullMatrix<double>();
            returnValue.m_RowsCount = m;
            returnValue.m_ColumnsCount = n;
            returnValue.m_Values = tempResult;
            return returnValue;
        }
        #endregion double
        #region Complex
        unsafe public static void Negate(int m, int n, Complex[] value, Complex[] result)
        {
            int size = m * n;
            if (size != value.Length)
                throw new ArgumentOutOfRangeException("value1");
            if (size != result.Length)
                throw new ArgumentOutOfRangeException("result");
            fixed (Complex* valuePointer = value, resultPointer = result)
            {
                double* ptrValue1 = (double*)valuePointer;
                double* ptrResult = (double*)resultPointer;
                double* ptrEnd = ptrResult + size * 2 - 31;
                // Main loop, pointers for row values
                while (ptrResult < ptrEnd)
                {
                    *ptrResult = -*ptrValue1;
                    *(ptrResult + 1) = -*(ptrValue1 + 1);
                    *(ptrResult + 2) = -*(ptrValue1 + 2);
                    *(ptrResult + 3) = -*(ptrValue1 + 3);
                    *(ptrResult + 4) = -*(ptrValue1 + 4);
                    *(ptrResult + 5) = -*(ptrValue1 + 5);
                    *(ptrResult + 6) = -*(ptrValue1 + 6);
                    *(ptrResult + 7) = -*(ptrValue1 + 7);
                    *(ptrResult + 8) = -*(ptrValue1 + 8);
                    *(ptrResult + 9) = -*(ptrValue1 + 9);
                    *(ptrResult + 10) = -*(ptrValue1 + 10);
                    *(ptrResult + 11) = -*(ptrValue1 + 11);
                    *(ptrResult + 12) = -*(ptrValue1 + 12);
                    *(ptrResult + 13) = -*(ptrValue1 + 13);
                    *(ptrResult + 14) = -*(ptrValue1 + 14);
                    *(ptrResult + 15) = -*(ptrValue1 + 15);
                    *(ptrResult + 16) = -*(ptrValue1 + 16);
                    *(ptrResult + 17) = -*(ptrValue1 + 17);
                    *(ptrResult + 18) = -*(ptrValue1 + 18);
                    *(ptrResult + 19) = -*(ptrValue1 + 19);
                    *(ptrResult + 20) = -*(ptrValue1 + 20);
                    *(ptrResult + 21) = -*(ptrValue1 + 21);
                    *(ptrResult + 22) = -*(ptrValue1 + 22);
                    *(ptrResult + 23) = -*(ptrValue1 + 23);
                    *(ptrResult + 24) = -*(ptrValue1 + 24);
                    *(ptrResult + 25) = -*(ptrValue1 + 25);
                    *(ptrResult + 26) = -*(ptrValue1 + 26);
                    *(ptrResult + 27) = -*(ptrValue1 + 27);
                    *(ptrResult + 28) = -*(ptrValue1 + 28);
                    *(ptrResult + 29) = -*(ptrValue1 + 29);
                    *(ptrResult + 30) = -*(ptrValue1 + 30);
                    *(ptrResult + 31) = -*(ptrValue1 + 31);
                    ptrResult += 32;
                    ptrValue1 += 32;
                }
                ptrEnd += 16;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = -*ptrValue1;
                    *(ptrResult + 1) = -*(ptrValue1 + 1);
                    *(ptrResult + 2) = -*(ptrValue1 + 2);
                    *(ptrResult + 3) = -*(ptrValue1 + 3);
                    *(ptrResult + 4) = -*(ptrValue1 + 4);
                    *(ptrResult + 5) = -*(ptrValue1 + 5);
                    *(ptrResult + 6) = -*(ptrValue1 + 6);
                    *(ptrResult + 7) = -*(ptrValue1 + 7);
                    *(ptrResult + 8) = -*(ptrValue1 + 8);
                    *(ptrResult + 9) = -*(ptrValue1 + 9);
                    *(ptrResult + 10) = -*(ptrValue1 + 10);
                    *(ptrResult + 11) = -*(ptrValue1 + 11);
                    *(ptrResult + 12) = -*(ptrValue1 + 12);
                    *(ptrResult + 13) = -*(ptrValue1 + 13);
                    *(ptrResult + 14) = -*(ptrValue1 + 14);
                    *(ptrResult + 15) = -*(ptrValue1 + 15);
                    ptrResult += 16;
                    ptrValue1 += 16;
                }
                ptrEnd += 8;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = -*ptrValue1;
                    *(ptrResult + 1) = -*(ptrValue1 + 1);
                    *(ptrResult + 2) = -*(ptrValue1 + 2);
                    *(ptrResult + 3) = -*(ptrValue1 + 3);
                    *(ptrResult + 4) = -*(ptrValue1 + 4);
                    *(ptrResult + 5) = -*(ptrValue1 + 5);
                    *(ptrResult + 6) = -*(ptrValue1 + 6);
                    *(ptrResult + 7) = -*(ptrValue1 + 7);
                    ptrResult += 8;
                    ptrValue1 += 8;
                }
                ptrEnd += 4;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = -*ptrValue1;
                    *(ptrResult + 1) = -*(ptrValue1 + 1);
                    *(ptrResult + 2) = -*(ptrValue1 + 2);
                    *(ptrResult + 3) = -*(ptrValue1 + 3);
                    ptrResult += 4;
                    ptrValue1 += 4;
                }
                ptrEnd += 2;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = -*ptrValue1;
                    *(ptrResult + 1) = -*(ptrValue1 + 1);
                    ptrResult += 2;
                    ptrValue1 += 2;
                }
                if (ptrResult == ptrEnd)
                    *ptrResult = -*ptrValue1;
            }
        }
        public static FullMatrix<Complex> Negate(FullMatrix<Complex> value)
        {
            int m = value.m_RowsCount;
            int n = value.m_ColumnsCount;

            Complex[] tempResult = new Complex[m * n];
            Negate(m, n, value.m_Values, tempResult);
            FullMatrix<Complex> returnValue = new FullMatrix<Complex>();
            returnValue.m_RowsCount = m;
            returnValue.m_ColumnsCount = n;
            returnValue.m_Values = tempResult;
            return returnValue;
        }
        unsafe public static CsrMatrix<Complex> Substraction(CsrMatrix<Complex> value1, CsrMatrix<Complex> value2)
        {
            int m = value1.RowsCount;
            int n = value2.ColumnsCount;
            if (value2.RowsCount != m)
                throw new Exception("Rows counts of first and second matrices not equals!");
            if (value2.ColumnsCount != n)
                throw new Exception("Columns counts of first and second matrices not equals!");
            CsrMatrix<Complex> returnValue = new CsrMatrix<Complex>(n);

            fixed (Complex* values1Pointer = value1.m_Values, values2Pointer = value2.m_Values)
            fixed (int* rowIndex1Pointer = value1.m_RowsMapping, rowIndex2Pointer = value2.m_RowsMapping, columns1Pointer = value1.m_Columns, columns2Pointer = value2.m_Columns)
            {
                int index1, end1, index2, end2;
                for (int i = 0; i < m; ++i)
                {
                    Complex[] row = new Complex[n];
                    index1 = *(rowIndex1Pointer + i);
                    index2 = *(rowIndex2Pointer + i);
                    end1 = *(rowIndex1Pointer + i + 1);
                    end2 = *(rowIndex2Pointer + i + 1);

                    while (index1 != end1)
                    {
                        row[*(columns1Pointer + index1)] = *(values1Pointer + index1);
                        index1++;
                    }
                    while (index2 != end2)
                    {
                        row[*(columns2Pointer + index2)] -= *(values2Pointer + index2);
                        index2++;
                    }
                   // returnValue.AddRow(row);
                }
            }
            return returnValue;
        }
        #endregion Complex
        #endregion Substraction
        #region Multiply
        #region double
        unsafe public static void Multiply(int m, int n, double[] value1, double value2, double[] result)
        {
            int size = m * n;
            if (size > value1.Length)
                throw new ArgumentOutOfRangeException("value1");
            if (size > result.Length)
                throw new ArgumentOutOfRangeException("result");
            fixed (double* value1Pointer = value1, resultPointer = result)
            {
                double* ptrValue1 = value1Pointer;
                double* ptrResult = resultPointer;
                double* ptrEnd = resultPointer + size - 31;
                // Main loop, pointers for row values
                while (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 * value2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) * value2;
                    *(ptrResult + 2) = *(ptrValue1 + 2) * value2;
                    *(ptrResult + 3) = *(ptrValue1 + 3) * value2;
                    *(ptrResult + 4) = *(ptrValue1 + 4) * value2;
                    *(ptrResult + 5) = *(ptrValue1 + 5) * value2;
                    *(ptrResult + 6) = *(ptrValue1 + 6) * value2;
                    *(ptrResult + 7) = *(ptrValue1 + 7) * value2;
                    *(ptrResult + 8) = *(ptrValue1 + 8) * value2;
                    *(ptrResult + 9) = *(ptrValue1 + 9) * value2;
                    *(ptrResult + 10) = *(ptrValue1 + 10) * value2;
                    *(ptrResult + 11) = *(ptrValue1 + 11) * value2;
                    *(ptrResult + 12) = *(ptrValue1 + 12) * value2;
                    *(ptrResult + 13) = *(ptrValue1 + 13) * value2;
                    *(ptrResult + 14) = *(ptrValue1 + 14) * value2;
                    *(ptrResult + 15) = *(ptrValue1 + 15) * value2;
                    *(ptrResult + 16) = *(ptrValue1 + 16) * value2;
                    *(ptrResult + 17) = *(ptrValue1 + 17) * value2;
                    *(ptrResult + 18) = *(ptrValue1 + 18) * value2;
                    *(ptrResult + 19) = *(ptrValue1 + 19) * value2;
                    *(ptrResult + 20) = *(ptrValue1 + 20) * value2;
                    *(ptrResult + 21) = *(ptrValue1 + 21) * value2;
                    *(ptrResult + 22) = *(ptrValue1 + 22) * value2;
                    *(ptrResult + 23) = *(ptrValue1 + 23) * value2;
                    *(ptrResult + 24) = *(ptrValue1 + 24) * value2;
                    *(ptrResult + 25) = *(ptrValue1 + 25) * value2;
                    *(ptrResult + 26) = *(ptrValue1 + 26) * value2;
                    *(ptrResult + 27) = *(ptrValue1 + 27) * value2;
                    *(ptrResult + 28) = *(ptrValue1 + 28) * value2;
                    *(ptrResult + 29) = *(ptrValue1 + 29) * value2;
                    *(ptrResult + 30) = *(ptrValue1 + 30) * value2;
                    *(ptrResult + 31) = *(ptrValue1 + 31) * value2;
                    ptrResult += 32;
                    ptrValue1 += 32;
                }
                ptrEnd += 16;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 * value2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) * value2;
                    *(ptrResult + 2) = *(ptrValue1 + 2) * value2;
                    *(ptrResult + 3) = *(ptrValue1 + 3) * value2;
                    *(ptrResult + 4) = *(ptrValue1 + 4) * value2;
                    *(ptrResult + 5) = *(ptrValue1 + 5) * value2;
                    *(ptrResult + 6) = *(ptrValue1 + 6) * value2;
                    *(ptrResult + 7) = *(ptrValue1 + 7) * value2;
                    *(ptrResult + 8) = *(ptrValue1 + 8) * value2;
                    *(ptrResult + 9) = *(ptrValue1 + 9) * value2;
                    *(ptrResult + 10) = *(ptrValue1 + 10) * value2;
                    *(ptrResult + 11) = *(ptrValue1 + 11) * value2;
                    *(ptrResult + 12) = *(ptrValue1 + 12) * value2;
                    *(ptrResult + 13) = *(ptrValue1 + 13) * value2;
                    *(ptrResult + 14) = *(ptrValue1 + 14) * value2;
                    *(ptrResult + 15) = *(ptrValue1 + 15) * value2;
                    ptrResult += 16;
                    ptrValue1 += 16;
                }
                ptrEnd += 8;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 * value2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) * value2;
                    *(ptrResult + 2) = *(ptrValue1 + 2) * value2;
                    *(ptrResult + 3) = *(ptrValue1 + 3) * value2;
                    *(ptrResult + 4) = *(ptrValue1 + 4) * value2;
                    *(ptrResult + 5) = *(ptrValue1 + 5) * value2;
                    *(ptrResult + 6) = *(ptrValue1 + 6) * value2;
                    *(ptrResult + 7) = *(ptrValue1 + 7) * value2;
                    ptrResult += 8;
                    ptrValue1 += 8;
                }
                ptrEnd += 4;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 * value2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) * value2;
                    *(ptrResult + 2) = *(ptrValue1 + 2) * value2;
                    *(ptrResult + 3) = *(ptrValue1 + 3) * value2;
                    ptrResult += 4;
                    ptrValue1 += 4;
                }
                ptrEnd += 2;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 * value2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) * value2;
                    ptrResult += 2;
                    ptrValue1 += 2;
                }
                if (ptrResult == ptrEnd)
                    *ptrResult = *ptrValue1 * value2;
            }
        }
        unsafe public static void Multiply(int m1, int n1, double[] value1, int m2, int n2, double[] value2, double[] result)
        {
            if (n1 != m2)
                throw new Exception("Rows count of first matrix not equal to columns count of second matrix!");
            double[] value2Transpose = new double[value2.Length];
            Transpose(m2, n2, value2, value2Transpose);
            fixed (double* value1Pointer = value1, value2tPointer = value2Transpose, resultPointer = result)
            {
                double* ptrValue;
                double* ptrValue2 = value2tPointer;
                double* ptrResult = resultPointer;
                double* ptrEnd = resultPointer + result.Length;
                double* ptrValueEnd;
                // Offsets in matrices rows
                int value1Offset = 0;
                int value2Offset = 0;
                // Summators
                double sum1;
                double sum2;
                double sum3;
                double sum4;
                // Main loop, row changes
                for (; ptrResult < ptrEnd; ++ptrResult, value2Offset += m2)
                {
                    if (value2Offset >= result.Length)
                    {
                        value2Offset = 0;
                        value1Offset += n1;
                    }
                    ptrValue = value1Pointer + value1Offset;
                    ptrValueEnd = ptrValue + n1 - 31;
                    ptrValue2 = value2tPointer + value2Offset;
                    sum1 = 0;
                    sum2 = 0;
                    sum3 = 0;
                    sum4 = 0;
                    // Internal loop, pointers for row values
                    while (ptrValue < ptrValueEnd)
                    {
                        sum1 += *ptrValue * *ptrValue2
                        + *(ptrValue + 1) * *(ptrValue2 + 1)
                        + *(ptrValue + 2) * *(ptrValue2 + 2)
                        + *(ptrValue + 3) * *(ptrValue2 + 3)
                        + *(ptrValue + 4) * *(ptrValue2 + 4)
                        + *(ptrValue + 5) * *(ptrValue2 + 5)
                        + *(ptrValue + 6) * *(ptrValue2 + 6)
                        + *(ptrValue + 7) * *(ptrValue2 + 7);
                        sum2 += *(ptrValue + 8) * *(ptrValue2 + 8)
                        + *(ptrValue + 9) * *(ptrValue2 + 9)
                        + *(ptrValue + 10) * *(ptrValue2 + 10)
                        + *(ptrValue + 11) * *(ptrValue2 + 11)
                        + *(ptrValue + 12) * *(ptrValue2 + 12)
                        + *(ptrValue + 13) * *(ptrValue2 + 13)
                        + *(ptrValue + 14) * *(ptrValue2 + 14)
                        + *(ptrValue + 15) * *(ptrValue2 + 15);
                        sum3 += *(ptrValue + 16) * *(ptrValue2 + 16)
                        + *(ptrValue + 17) * *(ptrValue2 + 17)
                        + *(ptrValue + 18) * *(ptrValue2 + 18)
                        + *(ptrValue + 19) * *(ptrValue2 + 19)
                        + *(ptrValue + 20) * *(ptrValue2 + 20)
                        + *(ptrValue + 21) * *(ptrValue2 + 21)
                        + *(ptrValue + 22) * *(ptrValue2 + 22)
                        + *(ptrValue + 23) * *(ptrValue2 + 23);
                        sum4 += *(ptrValue + 24) * *(ptrValue2 + 24)
                        + *(ptrValue + 25) * *(ptrValue2 + 25)
                        + *(ptrValue + 26) * *(ptrValue2 + 26)
                        + *(ptrValue + 27) * *(ptrValue2 + 27)
                        + *(ptrValue + 28) * *(ptrValue2 + 28)
                        + *(ptrValue + 29) * *(ptrValue2 + 29)
                        + *(ptrValue + 30) * *(ptrValue2 + 30)
                        + *(ptrValue + 31) * *(ptrValue2 + 31);
                        ptrValue += 32;
                        ptrValue2 += 32;
                    }
                    ptrValueEnd += 16;
                    if (ptrValue < ptrValueEnd)
                    {
                        sum1 += *ptrValue * *ptrValue2
                        + *(ptrValue + 1) * *(ptrValue2 + 1)
                        + *(ptrValue + 2) * *(ptrValue2 + 2)
                        + *(ptrValue + 3) * *(ptrValue2 + 3)
                        + *(ptrValue + 4) * *(ptrValue2 + 4)
                        + *(ptrValue + 5) * *(ptrValue2 + 5)
                        + *(ptrValue + 6) * *(ptrValue2 + 6)
                        + *(ptrValue + 7) * *(ptrValue2 + 7);
                        sum2 += *(ptrValue + 8) * *(ptrValue2 + 8)
                        + *(ptrValue + 9) * *(ptrValue2 + 9)
                        + *(ptrValue + 10) * *(ptrValue2 + 10)
                        + *(ptrValue + 11) * *(ptrValue2 + 11)
                        + *(ptrValue + 12) * *(ptrValue2 + 12)
                        + *(ptrValue + 13) * *(ptrValue2 + 13)
                        + *(ptrValue + 14) * *(ptrValue2 + 14)
                        + *(ptrValue + 15) * *(ptrValue2 + 15);
                        ptrValue += 16;
                        ptrValue2 += 16;
                    }
                    ptrValueEnd += 8;
                    if (ptrValue < ptrValueEnd)
                    {
                        sum1 += *ptrValue * *ptrValue2
                        + *(ptrValue + 1) * *(ptrValue2 + 1)
                        + *(ptrValue + 2) * *(ptrValue2 + 2)
                        + *(ptrValue + 3) * *(ptrValue2 + 3);
                        sum2 += *(ptrValue + 4) * *(ptrValue2 + 4)
                        + *(ptrValue + 5) * *(ptrValue2 + 5)
                        + *(ptrValue + 6) * *(ptrValue2 + 6)
                        + *(ptrValue + 7) * *(ptrValue2 + 7);
                        ptrValue += 8;
                        ptrValue2 += 8;
                    }
                    ptrValueEnd += 4;
                    if (ptrValue < ptrValueEnd)
                    {
                        sum1 += *ptrValue * *ptrValue2
                        + *(ptrValue + 1) * *(ptrValue2 + 1)
                        + *(ptrValue + 2) * *(ptrValue2 + 2)
                        + *(ptrValue + 3) * *(ptrValue2 + 3);
                        ptrValue += 4;
                        ptrValue2 += 4;
                    }
                    ptrValueEnd += 2;
                    if (ptrValue < ptrValueEnd)
                    {
                        sum1 += *ptrValue * *ptrValue2
                         + *(ptrValue + 1) * *(ptrValue2 + 1);
                        ptrValue += 2;
                        ptrValue2 += 2;
                    }
                    if (ptrValue <= ptrValueEnd)
                        sum1 += *ptrValue * *ptrValue2;

                    *ptrResult = sum1 + sum2 + sum3 + sum4;
                }
            }
        }
        public static FullMatrix<double> Multiply(FullMatrix<double> value1, double value2)
        {
            int m1 = value1.m_RowsCount;
            int n1 = value1.m_ColumnsCount;
            double[] tempResult = new double[m1 * n1];
            Multiply(m1, n1, value1.m_Values, value2, tempResult);
            FullMatrix<double> returnValue = new FullMatrix<double>();
            returnValue.m_RowsCount = m1;
            returnValue.m_ColumnsCount = n1;
            returnValue.m_Values = tempResult;
            return returnValue;
        }
        public static FullMatrix<double> Multiply(FullMatrix<double> value1, FullMatrix<double> value2)
        {
            int m1 = value1.m_RowsCount;
            int n1 = value1.m_ColumnsCount;
            int m2 = value2.m_RowsCount;
            int n2 = value2.m_ColumnsCount;
            if (n1 != m2)
                throw new Exception("Rows count of first matrix not equal to columns count of second matrix!");
            double[] tempResult = new double[m1 * n2];
            Multiply(m1, n1, value1.m_Values, m2, n2, value2.m_Values, tempResult);

            FullMatrix<double> result = new FullMatrix<double>();
            result.m_RowsCount = m1;
            result.m_ColumnsCount = n2;
            result.m_Values = tempResult;
            return result;
        }
        //unsafe public static VerySparseMatrix<double> Multiply(VerySparseMatrix<double> value1, VerySparseMatrix<double> value2) 
        //{
        //    int m = value1.RowCount;
        //    int n = value2.ColumnCount;
        //    if (value2.RowCount != value1.ColumnCount)
        //        throw new Exception("Rows count of first matrix not equal to columns count of second matrix!");
        //    VerySparseMatrix<double> returnValue = new VerySparseMatrix<double>(m, n);
        //    int[] lastIndexes = new int[value2.RowCount];
        //    for (int i = 0; i < value2.RowCount; ++i)
        //        lastIndexes[i] = value2.m_Nexts[i][0];

        //    // Main loop -- optimize for sparse matrix-vector multiply
        //    for (int j = 0; j < n; ++j)
        //    {
        //        double[] values2 = new double[value2.RowCount];

        //        for (int i = 0; i < value2.RowCount; ++i)
        //            if (value2.m_Indexes[i][lastIndexes[i]] == j)
        //            {
        //                values2[i] = value2.m_Values[i][lastIndexes[i]];
        //                lastIndexes[i] = value2.m_Nexts[i][lastIndexes[i]];
        //            }

        //        int next;
        //        double result;
        //        double[] values1 = null;
        //        int[] nexts1 = null;
        //        int[] indexes1 = null;
        //        for (int i = 0; i < m; ++i)
        //        {
        //            values1 = value1.m_Values[i];
        //            nexts1 = value1.m_Nexts[i];
        //            indexes1 = value1.m_Indexes[i];
        //            result = 0;
        //            next = nexts1[0];
        //            while (next != 0)
        //            {
        //                result += values1[next] * values2[indexes1[next]];
        //                next = nexts1[next];
        //            }
        //            returnValue.Set(i, j, result);
        //        }
        //    }
        //    return returnValue;
        //}
        //unsafe public static CSRMatrix<double> Multiply(CSRMatrix<double> value1, CSRMatrix<double> value2)
        //{
        //    int m = value1.RowsCount;
        //    int n = value2.ColumnsCount;
        //    if (value2.RowsCount != value1.ColumnsCount)
        //        throw new Exception("Rows count of first matrix not equal to columns count of second matrix!");
        //    CSRMatrix<double> returnValue = new CSRMatrix<double>((value1.m_RowsMapping[value1.m_RowCount] + value2.m_RowsMapping[value2.m_RowCount])/2, 0, m);
        //    CSRMatrix<double> tempValue2 = Transpose(value2);

        //    fixed (double* values1Pointer = value1.m_Values, values2Pointer = tempValue2.m_Values)
        //    fixed (int* columns1Pointer = value1.m_Columns, columns2Pointer = tempValue2.m_Columns)
        //    {
        //        int index1;
        //        int end1;
        //        int index2;
        //        int end2;

        //        for (int i = 0; i < m; ++i)
        //        {
        //            double[] row1 = new double[value1.ColumnsCount];
        //            index1 = value1.m_RowsMapping[i];
        //            end1 = value1.m_RowsMapping[i + 1];
        //            while (index1 != end1)
        //            {
        //                row1[*(columns1Pointer + index1)] = *(values1Pointer + index1);
        //                index1++;
        //            }
        //            double[] row = new double[n];
        //            for (int j = 0; j < n; ++j)
        //            {
        //                index2 = tempValue2.m_RowsMapping[j];
        //                end2 = tempValue2.m_RowsMapping[j + 1];
        //                double item2 = 0;
        //                while (index2 != end2)
        //                {
        //                    item2 += row1[*(columns2Pointer + index2)] * *(values2Pointer + index2);
        //                    index2++;
        //                }
        //                row[j] = item2;
        //            }
        //            returnValue.AddRow(row);
        //        }
        //    }
        //    return returnValue;
        //}

        unsafe public static FullMatrix<double> Multiply(CsrMatrix<double> value1, FullMatrix<double> value2)
        {
            int m1 = value1.RowsCount;
            int n1 = value1.ColumnsCount;
            int m2 = value2.m_RowsCount;
            int n2 = value2.m_ColumnsCount;
            if (n1 != m2)
                throw new Exception("Rows count of first matrix not equal to columns count of second matrix!");
            
            double[] tempResult = new double[m1 * n2];
            double[] tempValues2 = new double[m2 * n2];
            Transpose(m2, n2, value2.m_Values, tempValues2);

            int[] rowIndex1 = value1.m_RowsMapping;

            fixed (double* values1Pointer = value1.m_Values, values2Pointer = tempValues2)
            fixed (int* columns1Pointer = value1.m_Columns)
            {
                int index;
                int end;
                // Main loop -- optimize for sparse matrix-vector multiply
                for (int j = 0; j < n2; ++j)
                {
                    double* startValue2 = values2Pointer + j * m2;
                    double item;
                    for (int i = 0; i < m1; ++i)
                    {
                        item = 0;
                        index = rowIndex1[i];
                        end = rowIndex1[i + 1];
                        while (index != end)
                        {
                            item += *(values1Pointer + index) * *(startValue2 + *(columns1Pointer + index));
                            index++;
                        }
                        tempResult[i * n2 + j] = item;
                    }
                }
            }
            FullMatrix<double> returnValue = new FullMatrix<double>();
            returnValue.m_RowsCount = m1;
            returnValue.m_ColumnsCount = n2;
            returnValue.m_Values = tempResult;
            return returnValue;
        }
        unsafe public static FullMatrix<double> Multiply(FullMatrix<double> value1, CsrMatrix<double> value2)
        {
            int m1 = value1.m_RowsCount;
            int n1 = value1.m_ColumnsCount;
            int m2 = value2.RowsCount;
            int n2 = value2.ColumnsCount;
            if (n1 != m2)
                throw new Exception("Rows count of first matrix not equal to columns count of second matrix!");
            // TODO: !!!!
            double[] tempResult = new double[m1 * n2];
            double[] tempValue2 = new double[m1 * n1];
            Transpose(m1, n1, value1.m_Values, tempValue2);
            
            
            //MultuplyRowToRow(value2, n2, m2, tempValue2, tempResult);
            FullMatrix<double> result = new FullMatrix<double>();
            result.m_RowsCount = m1;
            result.m_ColumnsCount = n2;
            result.m_Values = tempResult;
            return result;
        }
        //unsafe public static FullMatrix<double> Multiply(VerySparseMatrix<double> value1, FullMatrix<double> value2) 
        //{
        //    int m1 = value1.RowCount;
        //    int n1 = value1.ColumnCount;
        //    int m2 = value2.m_RowsCount;
        //    int n2 = value2.m_ColumnsCount;
        //    if (n1 != m2)
        //        throw new Exception("Rows count of first matrix not equal to columns count of second matrix!");

        //    double[] tempResult = new double[m1 * n2];
        //    double[] valueArray2 = new double[m2 * n2];
        //    Transpose(m2, n2, value2.m_Values, valueArray2);

        //    fixed (double* valueArray2Pointer = valueArray2)
        //    {
        //        int next;
        //        double result;
        //        double[] values = null;
        //        int[] nexts = null;
        //        int[] indexes = null;
        //        // Main loop -- optimize for sparse matrix-vector multiply
        //        for (int j = 0; j < n2; ++j)
        //        {
        //            double* startValue2 = valueArray2Pointer + j * m2;
                    
        //            for (int i = 0; i < m1; ++i)
        //            {
        //                values = value1.m_Values[i];
        //                nexts = value1.m_Nexts[i];
        //                indexes = value1.m_Indexes[i];
        //                result = 0;
        //                next = nexts[0];
        //                while (next != 0)
        //                {
        //                    result += values[next] * *(startValue2 + indexes[next]);
        //                    next = nexts[next];
        //                }
        //                tempResult[i * n2 + j] = result;
        //            }
        //        }
        //    }
        //    FullMatrix<double> returnValue = new FullMatrix<double>();
        //    returnValue.m_RowsCount = m1;
        //    returnValue.m_ColumnsCount = n2;
        //    returnValue.m_Values = tempResult;
        //    return returnValue;
        //}
       
        unsafe private static void ElementsMultiply(int m1, int n1, double[] value1, int m2, int n2, double[] value2, double[] result)
        {
            if (n2 == 1)
            {
                if (m2 != m1)
                    throw new Exception("Rows count of first matrix not equal to rows count of second matrix!");

                CommonOperations.FastCopy(value1, result, value1.Length);

                fixed (double* valueArray1Pointer = result)
                {
                    for (int i = 0; i < m1; ++i)
                    {
                        double value2Item = value2[i];
                        int start = i * n1;
                        int stop = start + n1;
                        for (int j = start; j < stop; ++j)
                            *(valueArray1Pointer + j) *= value2Item;
                    }
                }
                return;
            }
            if (m2 == 1)
            {
                if (n2 != n1)
                    throw new Exception("Columns count of first matrix not equal to columns count of second matrix!");
                double[] value1Temp = new double[value2.Length];
                MatrixOperations.Transpose(m1, n1, value1, value1Temp);
                fixed (double* valueArray1Pointer = value1Temp)
                {
                    for (int i = 0; i < n1; ++i)
                    {
                        double value2Item = value2[i];
                        int start = i * m1;
                        int stop = start + m1;
                        for (int j = start; j < stop; ++j)
                            *(valueArray1Pointer + j) *= value2Item;
                    }
                }
                MatrixOperations.Transpose(n1, m1, value1Temp, result);
                return;
            }
            if (m2 == m1 && n2 == n1)
            {
                CommonOperations.FastCopy(value1, result, value1.Length);

                fixed (double* valueArray1Pointer = result, valueArray2Pointer = value2)
                {
                    for (int i = 0; i < value1.Length; ++i)
                    {
                        *(valueArray1Pointer + i) *= *(valueArray2Pointer + i);
                    }
                }
                return;
            }
            throw new Exception("The second matrix is not vector!");
        }
        public static FullMatrix<double> ElementsMultiply(FullMatrix<double> value1, FullMatrix<double> value2)
        {
            int m1 = value1.m_RowsCount;
            int n1 = value1.m_ColumnsCount;
            int m2 = value2.m_RowsCount;
            int n2 = value2.m_ColumnsCount;
            double[] tempResult = new double[m1 * n1];
            ElementsMultiply(m1, n1, value1.m_Values, m2, n2, value2.m_Values, tempResult);

            FullMatrix<double> result = new FullMatrix<double>();
            result.m_RowsCount = m1;
            result.m_ColumnsCount = n1;
            result.m_Values = tempResult;
            return result;
        }
        #endregion double
        #region Complex
        /// <summary>
        /// TODO:!!!!!!!!!!!!!!!!!!!!
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        //public static VerySparseMatrix<Complex> Multiply(VerySparseMatrix<Complex> value1, VerySparseMatrix<Complex> value2) 
        //{
        //    int m = value1.RowCount;
        //    int n = value2.ColumnCount;
        //    if (value2.RowCount != value1.ColumnCount)
        //        throw new Exception("Rows count of first matrix not equal to columns count of second matrix!");
        //    VerySparseMatrix<Complex> returnValue = new VerySparseMatrix<Complex>(m, n);
        //    int[] lastIndexes = new int[value2.RowCount];
        //    for (int i = 0; i < value2.RowCount; ++i)
        //        lastIndexes[i] = value2.m_Nexts[i][0];

        //    // Main loop -- optimize for sparse matrix-vector multiply
        //    for (int j = 0; j < n; ++j)
        //    {
        //        Complex[] values2 = new Complex[value2.RowCount];

        //        for (int i = 0; i < value2.RowCount; ++i)
        //            if (value2.m_Indexes[i][lastIndexes[i]] == j)
        //            {
        //                values2[i] = value2.m_Values[i][lastIndexes[i]];
        //                lastIndexes[i] = value2.m_Nexts[i][lastIndexes[i]];
        //            }
                
        //        int next;
        //        Complex result;
        //        Complex[] values1 = null;
        //        int[] nexts1 = null;
        //        int[] indexes1 = null;
        //        for (int i = 0; i < m; ++i)
        //        {
        //            values1 = value1.m_Values[i];
        //            nexts1 = value1.m_Nexts[i];
        //            indexes1 = value1.m_Indexes[i];
        //            result = 0;
        //            next = nexts1[0];
        //            while (next != 0)
        //            {
        //                result += values1[next] * values2[indexes1[next]];
        //                next = nexts1[next];
        //            }
        //            if (result != Complex.Zero)
        //                returnValue.Set(i, j, result);
        //        }
        //    }
        //    return returnValue;
        //}
        unsafe public static CsrMatrix<Complex> Multiply(CsrMatrix<Complex> value1, CsrMatrix<Complex> value2) 
        {
            int m = value1.RowsCount;
            int n = value2.ColumnsCount;
            if (value2.RowsCount != value1.ColumnsCount)
                throw new Exception("Rows count of first matrix not equal to columns count of second matrix!");
            CsrMatrix<Complex> returnValue = new CsrMatrix<Complex>((value1.m_RowsMapping[value1.m_RowsCount] + value2.m_RowsMapping[value2.m_RowsCount]) / 2, 0, m);
            CsrMatrix<Complex> tempValue2 = Transpose(value2);

            fixed (Complex* values1Pointer = value1.m_Values, values2Pointer = tempValue2.m_Values)
            fixed (int* columns1Pointer = value1.m_Columns, columns2Pointer = tempValue2.m_Columns)
            {
                int index1;
                int end1;
                int index2;
                int end2;

                for (int i = 0; i < m; ++i)
                {
                    Complex[] row1 = new Complex[value1.ColumnsCount];
                    index1 = value1.m_RowsMapping[i];
                    end1 = value1.m_RowsMapping[i + 1];
                    while (index1 != end1)
                    {
                        row1[*(columns1Pointer + index1)] = *(values1Pointer + index1);
                        index1++;
                    }
                    Complex[] row = new Complex[n];
                    for (int j = 0; j < n; ++j)
                    {
                        index2 = tempValue2.m_RowsMapping[j];
                        end2 = tempValue2.m_RowsMapping[j + 1];
                        Complex item2 = 0;
                        while (index2 != end2)
                        {
                            item2 += row1[*(columns2Pointer + index2)] * *(values2Pointer + index2);
                            index2++;
                        }
                        row[j] = item2;
                    }
                   // AddRow(returnValue, row);
                }
            }
            return returnValue;
        }

        unsafe public static FullMatrix<Complex> Multiply(CsrMatrix<Complex> value1, FullMatrix<Complex> value2) 
        {
            int m1 = value1.RowsCount;
            int n1 = value1.ColumnsCount;
            int m2 = value2.m_RowsCount;
            int n2 = value2.m_ColumnsCount;
            if (n1 != m2)
                throw new Exception("Rows count of first matrix not equal to columns count of second matrix!");

            Complex[] tempResult = new Complex[m1 * n2];
            Complex[] tempValues2 = new Complex[m2 * n2];
            Transpose(m2, n2, value2.m_Values, tempValues2);

            int[] rowIndex1 = value1.m_RowsMapping;

            fixed (Complex* values1Pointer = value1.m_Values, values2Pointer = tempValues2)
            fixed (int* columns1Pointer = value1.m_Columns)
            {
                int index;
                int end;
                // Main loop -- optimize for sparse matrix-vector multiply
                for (int j = 0; j < n2; ++j)
                {
                    Complex* startValue2 = values2Pointer + j * m2;
                    Complex item;
                    for (int i = 0; i < m1; ++i)
                    {
                        item = 0;
                        index = rowIndex1[i];
                        end = rowIndex1[i + 1];
                        while (index != end)
                        {
                            item += *(values1Pointer + index) * *(startValue2 + *(columns1Pointer + index));
                            index++;
                        }
                        tempResult[i * n2 + j] = item;
                    }
                }
            }
            FullMatrix<Complex> returnValue = new FullMatrix<Complex>();
            returnValue.m_RowsCount = m1;
            returnValue.m_ColumnsCount = n2;
            returnValue.m_Values = tempResult;
            return returnValue;
        }
        public static FullMatrix<Complex> Multiply(FullMatrix<Complex> value1, CsrMatrix<Complex> value2) 
        {
            return null;
            //int m1 = value1.RowCount;
            //int n1 = value1.ColumnCount;
            //int m2 = value2.m_RowCount;
            //int n2 = value2.m_ColumnCount;
            //if (n1 != m2)
            //    throw new Exception("Rows count of first matrix not equal to columns count of second matrix!");
            //double[] tempResult = new double[m1 * n2 * 2];

            //double[] valueArray2 = new double[m1 * n1 * 2];
            //ComplexTranspose(m1, n1, value2.m_Values, valueArray2);

            //uint[] valueArray1 = value1.Values;
            //int[] rowBegins1 = value1.RowBegin;

            //fixed (uint* valueArray1Pointer = valueArray1)
            //fixed (double* valueArray2Pointer = valueArray2)
            //{
            //    uint rowPosition;
            //    uint columnIndex;
            //    double resultItemReal;
            //    double resultItemImaginary;
            //    double leftReal;
            //    double leftImaginary;
            //    double rightReal;
            //    double rightImaginary;
            //    double* startValue2;
            //    uint* counterPointerShiftColumn1 = valueArray1Pointer + value1.ShiftColumn;
            //    uint* counterPointerShiftNext1 = valueArray1Pointer + value1.ShiftNext;
            //    // Main loop -- optimize for sparse matrix-vector multiply
            //    for (int j = 0; j < n2; ++j)
            //    {
            //        startValue2 = valueArray2Pointer + j * m2 * 2;
            //        for (int i = 0; i < m1; ++i)
            //        {
            //            resultItemReal = 0;
            //            resultItemImaginary = 0;
            //            rowPosition = (uint)rowBegins1[i];
            //            while (rowPosition != 4294967295)
            //            {
            //                columnIndex = *(counterPointerShiftColumn1 + rowPosition);

            //                leftReal = *(double*)*(valueArray1Pointer + rowPosition);
            //                leftImaginary = *(double*)*(valueArray1Pointer + rowPosition + 1);
            //                rightReal = *(startValue2 + columnIndex);
            //                rightImaginary = *(startValue2 + columnIndex + 1);
            //                resultItemReal += leftReal * rightReal - leftImaginary * rightImaginary;
            //                resultItemImaginary += leftReal * rightImaginary + leftImaginary * rightReal;
            //                rowPosition = (uint)*(counterPointerShiftNext1 + rowPosition);
            //            }
            //            tempResult[i * n2 * 2 + j] = resultItemReal;
            //            tempResult[i * n2 * 2 + j + 1] = resultItemImaginary;
            //        }
            //    }
            //}
            //FullMatrix<Complex> result = new FullMatrix<Complex>();
            //result.m_RowCount = m1;
            //result.m_ColumnCount = n2;
            //result.m_Values = tempResult;
            //return result;
        }
        //unsafe public static FullMatrix<Complex> Multiply(VerySparseMatrix<Complex> value1, FullMatrix<Complex> value2)
        //{
        //    int m1 = value1.RowCount;
        //    int n1 = value1.ColumnCount;
        //    int m2 = value2.m_RowsCount;
        //    int n2 = value2.m_ColumnsCount;
        //    if (n1 != m2)
        //        throw new Exception("Rows count of first matrix not equal to columns count of second matrix!");

        //    Complex[] tempResult = new Complex[m1 * n2];
        //    Complex[] valueArray2 = new Complex[m2 * n2];
        //    Transpose(m2, n2, value2.m_Values, valueArray2);

        //    fixed (Complex* valueArray2Pointer = valueArray2)
        //    {
        //        int next;
        //        Complex result;
        //        Complex[] values = null;
        //        int[] nexts = null;
        //        int[] indexes = null;
        //        // Main loop -- optimize for sparse matrix-vector multiply
        //        for (int j = 0; j < n2; ++j)
        //        {
        //            Complex* startValue2 = valueArray2Pointer + j * m2;

        //            for (int i = 0; i < m1; ++i)
        //            {
        //                values = value1.m_Values[i];
        //                nexts = value1.m_Nexts[i];
        //                indexes = value1.m_Indexes[i];
        //                result = 0;
        //                next = nexts[0];
        //                while (next != 0)
        //                {
        //                    result += values[next] * *(startValue2 + indexes[next]);
        //                    next = nexts[next];
        //                }
        //                tempResult[i * n2 + j] = result;
        //            }
        //        }
        //    }
        //    FullMatrix<Complex> returnValue = new FullMatrix<Complex>();
        //    returnValue.m_RowsCount = m1;
        //    returnValue.m_ColumnsCount = n2;
        //    returnValue.m_Values = tempResult;
        //    return returnValue;
        //}
        //public static void Multiply(FullMatrix<Complex> value1, VerySparseMatrix<Complex> value2, FullMatrix<Complex> result) { }
        //public static void Multiply(VerySparseMatrix<Complex> value1, CSRMatrix<Complex> value2, VerySparseMatrix<Complex> result) { }
        
        unsafe private static void ElementsMultiply(int m1, int n1, Complex[] value1, int m2, int n2, Complex[] value2, Complex[] result)
        {
            if (n2 == 1)
            {
                if (m2 != m1)
                    throw new Exception("Rows count of first matrix not equal to rows count of second matrix!");

                Array.Copy(value1, result, value1.Length);
                double* ptrReal, prtEnd;
                double real1, imaginary1, real2, imaginary2;
                fixed (Complex* valueArray1Pointer = result)
                {
                    double* valueArray1Pointer1 = (double*)valueArray1Pointer;
                    for (int i = 0; i < m2; i++)
                    {
                        real2 = value2[i].Real;
                        imaginary2 = value2[i].Imaginary;
                        ptrReal = valueArray1Pointer1 + i * n1 * 2;
                        prtEnd = ptrReal + n1 * 2;
                        for (; ptrReal < prtEnd; ptrReal+=2)
                        {
                            real1 = *ptrReal;
                            imaginary1 = *(ptrReal + 1);
                            *ptrReal = real1 * real2 - imaginary1 * imaginary2;
                            *(ptrReal + 1) = real1 * imaginary2 + imaginary1 * real2;
                        }
                    }
                }
                return;
            }
            if (m2 == 1)
            {
                if (n2 != n1)
                    throw new Exception("Columns count of first matrix not equal to columns count of second matrix!");
                Complex[] value1Temp = new Complex[value2.Length];
                MatrixOperations.Transpose(m1, n1, value1, value1Temp);
                double* ptrReal, prtEnd;
                double real1, imaginary1, real2, imaginary2;
                fixed (Complex* valueArray1Pointer = value1Temp)
                {
                    double* valueArray1Pointer1 = (double*)valueArray1Pointer;
                    for (int i = 0; i < n1; i++)
                    {
                        real2 = value2[i].Real;
                        imaginary2 = value2[i].Imaginary;
                        ptrReal = valueArray1Pointer1 + i * m1 * 2;
                        prtEnd = ptrReal + m1 * 2;
                        for (; ptrReal < prtEnd; ptrReal+=2)
                        {
                            real1 = *ptrReal;
                            imaginary1 = *(ptrReal + 1);
                            *ptrReal = real1 * real2 - imaginary1 * imaginary2;
                            *(ptrReal + 1) = real1 * imaginary2 + imaginary1 * real2;
                        }
                    }
                }
                MatrixOperations.Transpose(n1, m1, value1Temp, result);
                return;
            }
            if (m2 == m1 && n2 == n1)
            {
                //CommonOperations.FastCopy(value1, returnValue, value1.Length);

                //double* ptrReal, ptrImaginary, prtEnd;
                //double real;
                //fixed (double* valueArray1Pointer = returnValue, valueArray2Pointer = value2)
                //{
                //    for (int i = 0; i < value1.Length; ++i)
                //    {
                //        *(valueArray1Pointer + i) *= *(valueArray2Pointer + i);
                //    }
                //}
                return;
            }
            throw new Exception("The second matrix is not vector!");
        }

        public static FullMatrix<Complex> ElementsMultiply(FullMatrix<Complex> value1, FullMatrix<Complex> value2)
        {
            int m1 = value1.m_RowsCount;
            int n1 = value1.m_ColumnsCount;
            int m2 = value2.m_RowsCount;
            int n2 = value2.m_ColumnsCount;
            Complex[] tempResult = new Complex[m1 * n1];
            ElementsMultiply(m1, n1, value1.m_Values, m2, n2, value2.m_Values, tempResult);

            FullMatrix<Complex> result = new FullMatrix<Complex>();
            result.m_RowsCount = m1;
            result.m_ColumnsCount = n2;
            result.m_Values = tempResult;
            return result;
        }
        /// <summary>
        /// Matrix-vector multiplier
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        //unsafe public static VerySparseMatrix<Complex> ElementsMultiply(VerySparseMatrix<Complex> value1, FullMatrix<Complex> value2)
        //{
        //    if (value2.ColumnsCount == 1)
        //    {
        //        if (value2.RowsCount != value1.RowCount)
        //            throw new Exception("Rows count of first matrix not equal to rows count of second matrix!");

        //        VerySparseMatrix<Complex> returnValue = new VerySparseMatrix<Complex>(value1);
        //        int m = returnValue.RowCount;
        //        int n = returnValue.ColumnCount;

        //        Complex[] values2 = value2.m_Values;

        //        int next;

        //        for (int i = 0; i < m; ++i)
        //        {
        //            Complex[] values1 = returnValue.m_Values[i];
        //            int[] nexts1 = returnValue.m_Nexts[i];
        //            Complex item = values2[i];
        //            next = nexts1[0];
        //            while (next != 0)
        //            {
        //                values1[next] = values1[next] * item;
        //                next = nexts1[next];
        //            }
        //        }
        //        return returnValue;
        //    }
        //    if (value2.RowsCount == 1)
        //    {
        //        if (value2.ColumnsCount != value1.ColumnCount)
        //            throw new Exception("Columns count of first matrix not equal to columns count of second matrix!");
        //        VerySparseMatrix<Complex> returnValue = new VerySparseMatrix<Complex>(value1);
        //        int m = returnValue.RowCount;
        //        int n = returnValue.ColumnCount;
        //        Complex[] values2 = value2.m_Values;
        //        int next;
        //        for (int i = 0; i < m; ++i)
        //        {
        //            Complex[] values1 = returnValue.m_Values[i];
        //            int[] nexts1 = returnValue.m_Nexts[i];
        //            int[] indexes1 = returnValue.m_Indexes[i];
        //            next = nexts1[0];
        //            while (next != 0)
        //            {
        //                values1[next] = values1[next] * values2[indexes1[next]];
        //                next = nexts1[next];
        //            }
        //        }
        //        return returnValue;
        //    }
        //    throw new Exception("The second matrix is not vector!");
        //}
        #endregion Complex
        #region Block
        unsafe public static CsrMatrix<Block2x2> MultiplyTest(CsrMatrix<Block2x2> value1, CsrMatrix<Block2x2> value2)
        {
            int tick = Environment.TickCount;
            int m = value1.RowsCount, all = 0;
            int n = value2.ColumnsCount;
            if (value2.RowsCount != value1.ColumnsCount)
                throw new Exception("Rows count of first matrix not equal to columns count of second matrix!");
            CsrMatrix<Block2x2> tempValue2 = Transpose(value2);
            Console.WriteLine("Транспонирование " + (Environment.TickCount - tick));
            tick = Environment.TickCount;
            // Temp row for return saving
            Block2x2[][] retRows = new Block2x2[m][];
            int[][] retColumns = new int[m][];
            // Temp row for temp results
            Block2x2[] row = new Block2x2[n];
            int[] columns = new int[n];
            double f11 = 0, f12 = 0, f21 = 0, f22 = 0;

            fixed (Block2x2* values1Pointer = value1.m_Values, values2Pointer = tempValue2.m_Values, rowPtr = row)
            fixed (int* columns1Pointer = value1.m_Columns, columns2Pointer = tempValue2.m_Columns)
            {
                int index1, end1, index2, end2, head;
                for (int i = 0; i < m; ++i)
                {
                    head = 0;
                    Block2x2[] row1 = new Block2x2[value1.ColumnsCount];
                    index1 = value1.m_RowsMapping[i];
                    end1 = value1.m_RowsMapping[i + 1];
                    while (index1 != end1)
                    {
                        row1[*(columns1Pointer + index1)] = *(values1Pointer + index1);
                        index1++;
                    }
                    for (int j = 0; j < n; ++j)
                    {
                        index2 = tempValue2.m_RowsMapping[j];
                        end2 = tempValue2.m_RowsMapping[j + 1];
                        f11 = f12 = f21 = f22 = 0;
                        while (index2 != end2)
                        {
                            Block2x2 a = row1[*(columns2Pointer + index2)];
                            double* b = (double*)(values2Pointer + index2);

                            f11 += a.f00 * *b + a.f01 * *(b + 2);
                            f12 += a.f00 * *(b + 1) + a.f01 * *(b + 3);
                            f21 += a.f10 * *b + a.f11 * *(b + 2);
                            f22 += a.f10 * *(b + 1) + a.f11 * *(b + 3);
                            index2++;
                        }
                        double* dRowPtr = (double*)(rowPtr + head);
                        *dRowPtr = f11;
                        *(dRowPtr + 1) = f12;
                        *(dRowPtr + 2) = f21;
                        *(dRowPtr + 3) = f22;
                        columns[head] = j;
                        head++;
                    }
                    retRows[i] = new Block2x2[head];
                    retColumns[i] = new int[head];
                    all += head;
                    Array.Copy(row, retRows[i], head);
                    Array.Copy(columns, retColumns[i], head);
                }
            }
            Console.WriteLine("Умножение " + (Environment.TickCount - tick));
            tick = Environment.TickCount;
            CsrMatrix<Block2x2> returnValue = new CsrMatrix<Block2x2>(all, m, n);
            int pos = 0;
            int i1 = 0;
            for (; i1 < m; ++i1)
            {
                returnValue.m_RowsMapping[i1] = pos;
                Array.Copy(retRows[i1], 0, returnValue.m_Values, pos, retRows[i1].Length);
                Array.Copy(retColumns[i1], 0, returnValue.m_Columns, pos, retColumns[i1].Length);
                pos += retRows[i1].Length;
            }
            returnValue.m_RowsMapping[i1] = pos;
            Console.WriteLine("Копирование " + (Environment.TickCount - tick));
            return returnValue;
        }
        unsafe public static CsrMatrix<Block2x2> MultiplyOld(CsrMatrix<Block2x2> value1, CsrMatrix<Block2x2> value2)
        {
            int tick = Environment.TickCount;
            int m = value1.RowsCount, all = 0;
            int n = value2.ColumnsCount;
            if (value2.RowsCount != value1.ColumnsCount)
                throw new Exception("Rows count of first matrix not equal to columns count of second matrix!");
            CsrMatrix<Block2x2> tempValue2 = Transpose(value2);
            Console.WriteLine("Транспонирование " + (Environment.TickCount - tick));
            tick = Environment.TickCount;
            // Temp row for return saving
            Block2x2[][] retRows = new Block2x2[m][];
            int[][] retColumns = new int[m][];
            // Temp row for temp results
            Block2x2[] row = new Block2x2[n];
            int[] columns = new int[n];
            double f11 = 0, f12 = 0, f21 = 0, f22 = 0;
                        
            fixed (Block2x2* values1Pointer = value1.m_Values, values2Pointer = tempValue2.m_Values, rowPtr = row)
            fixed (int* columns1Pointer = value1.m_Columns, columns2Pointer = tempValue2.m_Columns)
            {
                int index1, end1, index2, end2, head;
                for (int i = 0; i < m; ++i)
                {
                    head = 0;
                    Block2x2[] row1 = new Block2x2[value1.ColumnsCount];
                    index1 = value1.m_RowsMapping[i];
                    end1 = value1.m_RowsMapping[i + 1];
                    while (index1 != end1)
                    {
                        row1[*(columns1Pointer + index1)] = *(values1Pointer + index1);
                        index1++;
                    }
                    for (int j = 0; j < n; ++j)
                    {
                        index2 = tempValue2.m_RowsMapping[j];
                        end2 = tempValue2.m_RowsMapping[j + 1];
                        f11 = f12 = f21 = f22 = 0;
                        while (index2 != end2)
                        {
                            Block2x2 a = row1[*(columns2Pointer + index2)];
                            double* b = (double*)(values2Pointer + index2);

                            f11 += a.f00 * *b + a.f01 * *(b + 2);
                            f12 += a.f00 * *(b + 1) + a.f01 * *(b + 3);
                            f21 += a.f10 * *b + a.f11 * *(b + 2);
                            f22 += a.f10 * *(b + 1) + a.f11 * *(b + 3);
                            index2++;
                        }
                        double* dRowPtr = (double*)(rowPtr + head);
                        *dRowPtr = f11;
                        *(dRowPtr + 1) = f12;
                        *(dRowPtr + 2) = f21;
                        *(dRowPtr + 3) = f22;
                        columns[head] = j;
                        head++;
                    }
                    retRows[i] = new Block2x2[head];
                    retColumns[i] = new int[head];
                    all += head;
                    Array.Copy(row, retRows[i], head);
                    Array.Copy(columns, retColumns[i], head);
                }
            }
            Console.WriteLine("Умножение " + (Environment.TickCount - tick));
            tick = Environment.TickCount;
            CsrMatrix<Block2x2> returnValue = new CsrMatrix<Block2x2>(all, m, n);
            int pos = 0;
            int i1 = 0;
            for (; i1 < m; ++i1)
            {
                returnValue.m_RowsMapping[i1] = pos;
                Array.Copy(retRows[i1], 0, returnValue.m_Values, pos, retRows[i1].Length);
                Array.Copy(retColumns[i1], 0, returnValue.m_Columns, pos, retColumns[i1].Length);
                pos += retRows[i1].Length;
            }
            returnValue.m_RowsMapping[i1] = pos;
            Console.WriteLine("Копирование " + (Environment.TickCount - tick));
            return returnValue;
        }
        
        //unsafe public static FCSRMatrix<Block2x2> MultiplyInternal(CSRMatrix<Block2x2> value1, CSRMatrix<Block2x2> value2)
        //{
        //    int tick = Environment.TickCount;
        //    int m = value1.RowsCount;
        //    int n = value2.ColumnsCount;
        //    if (value2.RowsCount != value1.ColumnsCount)
        //        throw new Exception("Rows count of first matrix not equal to columns count of second matrix!");
        //    FCSRMatrix<Block2x2> returnValue = new FCSRMatrix<Block2x2>(m, n);
        //    // Temp row for temp results
        //    Block2x2[] values = new Block2x2[n];
        //    int[] columns = new int[n];
        //    int[] nexts = new int[n];
        //    int head;
        //    Block2x2 tempValue1, tempValue2;
        //    double* tempPtr;
        //    int columnIndex1, columnIndex2;
        //    fixed (Block2x2* values1Ptr = value1.m_Values, values2Ptr = value2.m_Values, valuesPtr = values)
        //    fixed (int* columns1Ptr = value1.m_Columns, columns2Ptr = value2.m_Columns, columnsPtr = columns, nextsPtr = nexts)
        //    for (int i = 0; i < m; i++)
        //    {
        //        //   st++;
        //        // Get current row
        //        int index1 = value1.m_RowsMapping[i];
        //        int endIndex1 = value1.m_RowsMapping[i + 1];
        //        head = 0;
        //        *nextsPtr = -1;
        //        // Multiply value1 elements to value2 rows
        //        int currentIndex = - 1;
        //        for (; index1 < endIndex1; ++index1)
        //        {
        //            //    st2++;
        //            columnIndex1 = columns1Ptr[index1];
        //            tempValue1 = values1Ptr[index1];

        //            // Block counterValue;
        //            int index2 = value1.m_RowsMapping[columnIndex1];
        //            int endIndex2 = value1.m_RowsMapping[columnIndex1 + 1];

        //            for (; index2 < endIndex2; ++index2)
        //            {
        //                //  st5++;
        //                tempValue2 = values2Ptr[index2];
        //                columnIndex2 = columns2Ptr[index2];
        //                int previousIndex = 0, columnIndex;
        //                for (; ; )
        //                {
        //                    //  st6++;
        //                    if (currentIndex == -1)
        //                    {
        //                        currentIndex = head;
        //                        // Нужно сначала для предыдущего, иначе проблема с нулевым элементом
        //                        *(nextsPtr + previousIndex) = currentIndex;
        //                        *(nextsPtr + currentIndex) = -1;
        //                        *(columnsPtr + currentIndex) = columnIndex2;
        //                        //st7++;
        //                        tempPtr = (double*)(valuesPtr + currentIndex);
        //                        *tempPtr = tempValue1.f00 * tempValue2.f00 + tempValue1.f01 * tempValue2.f10;
        //                        *(tempPtr + 1) = tempValue1.f00 * tempValue2.f01 + tempValue1.f01 * tempValue2.f11;
        //                        *(tempPtr + 2) = tempValue1.f10 * tempValue2.f00 + tempValue1.f11 * tempValue2.f10;
        //                        *(tempPtr + 3) = tempValue1.f10 * tempValue2.f01 + tempValue1.f11 * tempValue2.f11;
        //                        head++;
        //                        previousIndex = currentIndex;
        //                        currentIndex = *(nextsPtr + previousIndex);
        //                        break;
        //                    }
        //                    // Get the column index of current element
        //                    columnIndex = columns[currentIndex];
        //                    if (columnIndex == columnIndex2)
        //                    {
        //                        // Set element in current position
        //                        // st9++;
        //                        tempPtr = (double*)(valuesPtr + currentIndex);
        //                        *tempPtr += tempValue1.f00 * tempValue2.f00 + tempValue1.f01 * tempValue2.f10;
        //                        *(tempPtr + 1) += tempValue1.f00 * tempValue2.f01 + tempValue1.f01 * tempValue2.f11;
        //                        *(tempPtr + 2) += tempValue1.f10 * tempValue2.f00 + tempValue1.f11 * tempValue2.f10;
        //                        *(tempPtr + 3) += tempValue1.f10 * tempValue2.f01 + tempValue1.f11 * tempValue2.f11;
        //                        previousIndex = currentIndex;
        //                        currentIndex = *(nextsPtr + previousIndex);
        //                        break;
        //                    }
        //                    if (columnIndex > columnIndex2)
        //                    {
        //                        currentIndex = head;
        //                        // Reset the row current element
        //                        *(nextsPtr + currentIndex) = *(nextsPtr + previousIndex);
        //                        *(nextsPtr + previousIndex) = currentIndex;
        //                        *(columnsPtr + currentIndex) = columnIndex2;

        //                        //  st8++;
        //                        tempPtr = (double*)(valuesPtr + currentIndex);
        //                        *tempPtr = tempValue1.f00 * tempValue2.f00 + tempValue1.f01 * tempValue2.f10;
        //                        *(tempPtr + 1) = tempValue1.f00 * tempValue2.f01 + tempValue1.f01 * tempValue2.f11;
        //                        *(tempPtr + 2) = tempValue1.f10 * tempValue2.f00 + tempValue1.f11 * tempValue2.f10;
        //                        *(tempPtr + 3) = tempValue1.f10 * tempValue2.f01 + tempValue1.f11 * tempValue2.f11;
        //                        head++;
        //                        previousIndex = currentIndex;
        //                        currentIndex = *(nextsPtr + previousIndex);
        //                        break;
        //                    }
        //                    previousIndex = currentIndex;
        //                    currentIndex = *(nextsPtr + previousIndex);
        //                }
        //            }
        //            currentIndex = 0;
        //        }
        //        // Add new row
        //        int l = 0;
        //        int[] tempColumns = returnValue.m_Columns[i] = new int[head];
        //        Block2x2[] tempValues = returnValue.m_Values[i] = new Block2x2[head];
        //        returnValue.m_Heads[i] = head;
        //        for (int counter = 0; counter != -1; counter = nexts[counter])
        //        {
        //            //st10++;
        //            tempColumns[l] = columns[counter];
        //            tempValues[l] = values[counter];
        //            l++;
        //        }
        //    }
        //    return returnValue;
        //}
        //public static CSRMatrix<Block2x2> Multiply(CSRMatrix<Block2x2> value1, CSRMatrix<Block2x2> value2)
        //{
        //    FCSRMatrix<Block2x2> returnValue = MultiplyInternal(value1, value2);
        //    return Convert(returnValue);
        //}
        unsafe public static FullMatrix<Block2x2> Multiply(CsrMatrix<Block2x2> value1, FullMatrix<Block2x2> value2)
        {
            int m1 = value1.RowsCount;
            int n1 = value1.ColumnsCount;
            int m2 = value2.m_RowsCount;
            int n2 = value2.m_ColumnsCount;
            if (n1 != m2)
                throw new Exception("Rows count of first matrix not equal to columns count of second matrix!");

            Block2x2[] tempResult = new Block2x2[m1 * n2];
            Block2x2[] tempValues2 = new Block2x2[m2 * n2];
            Transpose(m2, n2, value2.m_Values, tempValues2);

            int[] rowIndex1 = value1.m_RowsMapping;

            fixed (Block2x2* values1Pointer = value1.m_Values, values2Pointer = tempValues2)
            fixed (int* columns1Pointer = value1.m_Columns)
            {
                int index;
                int end;
                // Main loop -- optimize for sparse matrix-vector multiply
                for (int j = 0; j < n2; ++j)
                {
                    Block2x2* startValue2 = (values2Pointer + j * m2);
                    Block2x2 item;
                    for (int i = 0; i < m1; ++i)
                    {
                        item = default(Block2x2);
                        index = rowIndex1[i];
                        end = rowIndex1[i + 1];
                        while (index != end)
                        {
                            item += *(values1Pointer + index) * *(startValue2 + *(columns1Pointer + index));
                            index++;
                        }
                        tempResult[i * n2 + j] = item;
                    }
                }
            }
            FullMatrix<Block2x2> returnValue = new FullMatrix<Block2x2>();
            returnValue.m_RowsCount = m1;
            returnValue.m_ColumnsCount = n2;
            returnValue.m_Values = tempResult;
            return returnValue;
        }
        #endregion Block
        #endregion Multiply
        #region Divide
        #region double
        unsafe public static void ElementsInverse(int m, int n, double[] value, double[] result)
        {
            int size = m * n;
            if (size != value.Length)
                throw new ArgumentOutOfRangeException("value");
            if (size != result.Length)
                throw new ArgumentOutOfRangeException("result");
            fixed (double* valuePointer = value, resultPointer = result)
            {
                double* ptrValue = valuePointer;
                double* ptrResult = resultPointer;
                double* ptrEnd = resultPointer + size - 31;
                // Main loop, pointers for row values
                while (ptrResult < ptrEnd)
                {
                    *ptrResult = 1 / *ptrValue;
                    *(ptrResult + 1) = 1 / *(ptrValue + 1);
                    *(ptrResult + 2) = 1 / *(ptrValue + 2);
                    *(ptrResult + 3) = 1 / *(ptrValue + 3);
                    *(ptrResult + 4) = 1 / *(ptrValue + 4);
                    *(ptrResult + 5) = 1 / *(ptrValue + 5);
                    *(ptrResult + 6) = 1 / *(ptrValue + 6);
                    *(ptrResult + 7) = 1 / *(ptrValue + 7);
                    *(ptrResult + 8) = 1 / *(ptrValue + 8);
                    *(ptrResult + 9) = 1 / *(ptrValue + 9);
                    *(ptrResult + 10) = 1 / *(ptrValue + 10);
                    *(ptrResult + 11) = 1 / *(ptrValue + 11);
                    *(ptrResult + 12) = 1 / *(ptrValue + 12);
                    *(ptrResult + 13) = 1 / *(ptrValue + 13);
                    *(ptrResult + 14) = 1 / *(ptrValue + 14);
                    *(ptrResult + 15) = 1 / *(ptrValue + 15);
                    *(ptrResult + 16) = 1 / *(ptrValue + 16);
                    *(ptrResult + 17) = 1 / *(ptrValue + 17);
                    *(ptrResult + 18) = 1 / *(ptrValue + 18);
                    *(ptrResult + 19) = 1 / *(ptrValue + 19);
                    *(ptrResult + 20) = 1 / *(ptrValue + 20);
                    *(ptrResult + 21) = 1 / *(ptrValue + 21);
                    *(ptrResult + 22) = 1 / *(ptrValue + 22);
                    *(ptrResult + 23) = 1 / *(ptrValue + 23);
                    *(ptrResult + 24) = 1 / *(ptrValue + 24);
                    *(ptrResult + 25) = 1 / *(ptrValue + 25);
                    *(ptrResult + 26) = 1 / *(ptrValue + 26);
                    *(ptrResult + 27) = 1 / *(ptrValue + 27);
                    *(ptrResult + 28) = 1 / *(ptrValue + 28);
                    *(ptrResult + 29) = 1 / *(ptrValue + 29);
                    *(ptrResult + 30) = 1 / *(ptrValue + 30);
                    *(ptrResult + 31) = 1 / *(ptrValue + 31);
                    ptrResult += 32;
                    ptrValue += 32;
                }
                ptrEnd += 16;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = 1 / *ptrValue;
                    *(ptrResult + 1) = 1 / *(ptrValue + 1);
                    *(ptrResult + 2) = 1 / *(ptrValue + 2);
                    *(ptrResult + 3) = 1 / *(ptrValue + 3);
                    *(ptrResult + 4) = 1 / *(ptrValue + 4);
                    *(ptrResult + 5) = 1 / *(ptrValue + 5);
                    *(ptrResult + 6) = 1 / *(ptrValue + 6);
                    *(ptrResult + 7) = 1 / *(ptrValue + 7);
                    *(ptrResult + 8) = 1 / *(ptrValue + 8);
                    *(ptrResult + 9) = 1 / *(ptrValue + 9);
                    *(ptrResult + 10) = 1 / *(ptrValue + 10);
                    *(ptrResult + 11) = 1 / *(ptrValue + 11);
                    *(ptrResult + 12) = 1 / *(ptrValue + 12);
                    *(ptrResult + 13) = 1 / *(ptrValue + 13);
                    *(ptrResult + 14) = 1 / *(ptrValue + 14);
                    *(ptrResult + 15) = 1 / *(ptrValue + 15);
                    ptrResult += 16;
                    ptrValue += 16;
                }
                ptrEnd += 8;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = 1 / *ptrValue;
                    *(ptrResult + 1) = 1 / *(ptrValue + 1);
                    *(ptrResult + 2) = 1 / *(ptrValue + 2);
                    *(ptrResult + 3) = 1 / *(ptrValue + 3);
                    *(ptrResult + 4) = 1 / *(ptrValue + 4);
                    *(ptrResult + 5) = 1 / *(ptrValue + 5);
                    *(ptrResult + 6) = 1 / *(ptrValue + 6);
                    *(ptrResult + 7) = 1 / *(ptrValue + 7);
                    ptrResult += 8;
                    ptrValue += 8;
                }
                ptrEnd += 4;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = 1 / *ptrValue;
                    *(ptrResult + 1) = 1 / *(ptrValue + 1);
                    *(ptrResult + 2) = 1 / *(ptrValue + 2);
                    *(ptrResult + 3) = 1 / *(ptrValue + 3);
                    ptrResult += 4;
                    ptrValue += 4;
                }
                ptrEnd += 2;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = 1 / *ptrValue;
                    *(ptrResult + 1) = 1 / *(ptrValue + 1);
                    ptrResult += 2;
                    ptrValue += 2;
                }
                if (ptrResult == ptrEnd)
                    *ptrResult = 1 / *ptrValue;
            }
        }
        public static FullMatrix<double> ElementsInverse(FullMatrix<double> value)
        {
            int m = value.m_RowsCount;
            int n = value.m_ColumnsCount;

            
            double[] tempResult = new double[m * n];
            ElementsInverse(m, n, value.m_Values, tempResult);

            FullMatrix<double> returnValue = new FullMatrix<double>();
            returnValue.m_RowsCount = m;
            returnValue.m_ColumnsCount = n;
            returnValue.m_Values = tempResult;
            return returnValue;
        }
        unsafe public static void ElementsDivide(int m, int n, double[] value1, double[] value2, double[] result)
        {
            int size = m * n;
            if (size != value1.Length/* || size * 2 != value1.Length*/)
                throw new ArgumentOutOfRangeException("value1");
            //size = value1.Length;
            if (size != value2.Length)
                throw new ArgumentOutOfRangeException("value2");
            if (size != result.Length)
                throw new ArgumentOutOfRangeException("result");
            fixed (double* value1Pointer = value1, value2Pointer = value2, resultPointer = result)
            {
                double* ptrValue1 = value1Pointer;
                double* ptrValue2 = value2Pointer;
                double* ptrResult = resultPointer;
                double* ptrEnd = resultPointer + size - 31;
                // Main loop, pointers for row values
                while (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 / *ptrValue2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) / *(ptrValue2 + 1);
                    *(ptrResult + 2) = *(ptrValue1 + 2) / *(ptrValue2 + 2);
                    *(ptrResult + 3) = *(ptrValue1 + 3) / *(ptrValue2 + 3);
                    *(ptrResult + 4) = *(ptrValue1 + 4) / *(ptrValue2 + 4);
                    *(ptrResult + 5) = *(ptrValue1 + 5) / *(ptrValue2 + 5);
                    *(ptrResult + 6) = *(ptrValue1 + 6) / *(ptrValue2 + 6);
                    *(ptrResult + 7) = *(ptrValue1 + 7) / *(ptrValue2 + 7);
                    *(ptrResult + 8) = *(ptrValue1 + 8) / *(ptrValue2 + 8);
                    *(ptrResult + 9) = *(ptrValue1 + 9) / *(ptrValue2 + 9);
                    *(ptrResult + 10) = *(ptrValue1 + 10) / *(ptrValue2 + 10);
                    *(ptrResult + 11) = *(ptrValue1 + 11) / *(ptrValue2 + 11);
                    *(ptrResult + 12) = *(ptrValue1 + 12) / *(ptrValue2 + 12);
                    *(ptrResult + 13) = *(ptrValue1 + 13) / *(ptrValue2 + 13);
                    *(ptrResult + 14) = *(ptrValue1 + 14) / *(ptrValue2 + 14);
                    *(ptrResult + 15) = *(ptrValue1 + 15) / *(ptrValue2 + 15);
                    *(ptrResult + 16) = *(ptrValue1 + 16) / *(ptrValue2 + 16);
                    *(ptrResult + 17) = *(ptrValue1 + 17) / *(ptrValue2 + 17);
                    *(ptrResult + 18) = *(ptrValue1 + 18) / *(ptrValue2 + 18);
                    *(ptrResult + 19) = *(ptrValue1 + 19) / *(ptrValue2 + 19);
                    *(ptrResult + 20) = *(ptrValue1 + 20) / *(ptrValue2 + 20);
                    *(ptrResult + 21) = *(ptrValue1 + 21) / *(ptrValue2 + 21);
                    *(ptrResult + 22) = *(ptrValue1 + 22) / *(ptrValue2 + 22);
                    *(ptrResult + 23) = *(ptrValue1 + 23) / *(ptrValue2 + 23);
                    *(ptrResult + 24) = *(ptrValue1 + 24) / *(ptrValue2 + 24);
                    *(ptrResult + 25) = *(ptrValue1 + 25) / *(ptrValue2 + 25);
                    *(ptrResult + 26) = *(ptrValue1 + 26) / *(ptrValue2 + 26);
                    *(ptrResult + 27) = *(ptrValue1 + 27) / *(ptrValue2 + 27);
                    *(ptrResult + 28) = *(ptrValue1 + 28) / *(ptrValue2 + 28);
                    *(ptrResult + 29) = *(ptrValue1 + 29) / *(ptrValue2 + 29);
                    *(ptrResult + 30) = *(ptrValue1 + 30) / *(ptrValue2 + 30);
                    *(ptrResult + 31) = *(ptrValue1 + 31) / *(ptrValue2 + 31);
                    ptrResult += 32;
                    ptrValue1 += 32;
                    ptrValue2 += 32;
                }
                ptrEnd += 16;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 / *ptrValue2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) / *(ptrValue2 + 1);
                    *(ptrResult + 2) = *(ptrValue1 + 2) / *(ptrValue2 + 2);
                    *(ptrResult + 3) = *(ptrValue1 + 3) / *(ptrValue2 + 3);
                    *(ptrResult + 4) = *(ptrValue1 + 4) / *(ptrValue2 + 4);
                    *(ptrResult + 5) = *(ptrValue1 + 5) / *(ptrValue2 + 5);
                    *(ptrResult + 6) = *(ptrValue1 + 6) / *(ptrValue2 + 6);
                    *(ptrResult + 7) = *(ptrValue1 + 7) / *(ptrValue2 + 7);
                    *(ptrResult + 8) = *(ptrValue1 + 8) / *(ptrValue2 + 8);
                    *(ptrResult + 9) = *(ptrValue1 + 9) / *(ptrValue2 + 9);
                    *(ptrResult + 10) = *(ptrValue1 + 10) / *(ptrValue2 + 10);
                    *(ptrResult + 11) = *(ptrValue1 + 11) / *(ptrValue2 + 11);
                    *(ptrResult + 12) = *(ptrValue1 + 12) / *(ptrValue2 + 12);
                    *(ptrResult + 13) = *(ptrValue1 + 13) / *(ptrValue2 + 13);
                    *(ptrResult + 14) = *(ptrValue1 + 14) / *(ptrValue2 + 14);
                    *(ptrResult + 15) = *(ptrValue1 + 15) / *(ptrValue2 + 15);
                    ptrResult += 16;
                    ptrValue1 += 16;
                    ptrValue2 += 16;
                }
                ptrEnd += 8;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 / *ptrValue2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) / *(ptrValue2 + 1);
                    *(ptrResult + 2) = *(ptrValue1 + 2) / *(ptrValue2 + 2);
                    *(ptrResult + 3) = *(ptrValue1 + 3) / *(ptrValue2 + 3);
                    *(ptrResult + 4) = *(ptrValue1 + 4) / *(ptrValue2 + 4);
                    *(ptrResult + 5) = *(ptrValue1 + 5) / *(ptrValue2 + 5);
                    *(ptrResult + 6) = *(ptrValue1 + 6) / *(ptrValue2 + 6);
                    *(ptrResult + 7) = *(ptrValue1 + 7) / *(ptrValue2 + 7);
                    ptrResult += 8;
                    ptrValue1 += 8;
                    ptrValue2 += 8;
                }
                ptrEnd += 4;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 / *ptrValue2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) / *(ptrValue2 + 1);
                    *(ptrResult + 2) = *(ptrValue1 + 2) / *(ptrValue2 + 2);
                    *(ptrResult + 3) = *(ptrValue1 + 3) / *(ptrValue2 + 3);
                    ptrResult += 4;
                    ptrValue1 += 4;
                    ptrValue2 += 4;
                }
                ptrEnd += 2;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue1 / *ptrValue2;
                    *(ptrResult + 1) = *(ptrValue1 + 1) / *(ptrValue2 + 1);
                    ptrResult += 2;
                    ptrValue1 += 2;
                    ptrValue2 += 2;
                }
                if (ptrResult == ptrEnd)
                    *ptrResult = *ptrValue1 / *ptrValue2;
            }
        }
        public static FullMatrix<double> ElementsDivide(FullMatrix<double> value1, FullMatrix<double> value2)
        {
            int m = value1.m_RowsCount;
            int n = value1.m_ColumnsCount;

            if (m != value2.m_RowsCount)
                throw new Exception("Value1 and value2 has different row counts!");
            if (n != value2.m_ColumnsCount)
                throw new Exception("Value1 and value2 has different column counts!");

            double[] tempResult = new double[m * n];
            ElementsDivide(m, n, value1.m_Values, value2.m_Values, tempResult);

            FullMatrix<double> returnValue = new FullMatrix<double>();
            returnValue.m_RowsCount = m;
            returnValue.m_ColumnsCount = n;
            returnValue.m_Values = tempResult;
            return returnValue;
        }
        public static void Divide(int m, int n, double[] value1, double value2, double[] result)
        {
            value2 = 1 / value2;
            Multiply(m, n, value1, value2, result);
        }
        public static void Divide(int m1, int n1, double[] value1, int m2, int n2, double[] value2, double[] result)
        {
            //if (m2 == n2)
            //{
            //    LuDecomposition(m2, n2, value2, new int[m2 * n2]);
            //    LuSolve(m2, n2, value2, m1, n1, value1);
            //}
            //else
            QrDivide(m1, n1, value1, m2, n2, value2, result);
        }

        public static void Divide(FullMatrix<double> value1, FullMatrix<double> value2, FullMatrix<double> result)
        {
            int m1 = value1.m_RowsCount;
            int n1 = value1.m_ColumnsCount;
            int m2 = value2.m_RowsCount;
            int n2 = value2.m_ColumnsCount;
            if (n1 != n2)
                throw new Exception("Conumns count of first and second matrix not equals!");
            double[] tempResult = new double[m2 * m1];
            Divide(m1, n1, value1.m_Values, m2, n2, value2.m_Values, tempResult);

            result.Clear();
            result.m_RowsCount = m2;
            result.m_ColumnsCount = m1;
            result.m_Values = tempResult;
        }
        public static FullMatrix<double> QrDecomposition(FullMatrix<double> value)
        {
            int m = value.m_RowsCount;
            int n = value.m_ColumnsCount;
            double[] diagonal = new double[n];
            int length = m * n;
            double[] valueTemp = new double[length];
            CommonOperations.FastCopy(value.m_Values, valueTemp, length);
            QrDecomposition(m, n, valueTemp, diagonal);

            FullMatrix<double> result = new FullMatrix<double>();
            result.Clear();
            result.m_RowsCount = m;
            result.m_ColumnsCount = n;
            result.m_Values = valueTemp;
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="n1"></param>
        /// <param name="value1"></param>
        /// <param name="m2"></param>
        /// <param name="n2"></param>
        /// <param name="value2"></param>
        /// <param name="result">Length = n*nB</param>
        unsafe public static void QrDivide(int m1, int n1, double[] value1, int m2, int n2, double[] value2, double[] result)
        {
            double[] diagonal = new double[n2];
            int length = m2 * n2;
            double[] valueTemp = new double[length];
            CommonOperations.FastCopy(value2, valueTemp, length);
            QrDecomposition(m2, n2, valueTemp, diagonal);
            QrSolve(m2, n2, valueTemp, m1, n1, value1, diagonal, result);
        }
        unsafe public static FullMatrix<double> QrDivide(FullMatrix<double> value1, CsrMatrix<double> value2) 
        {
            if (value1.RowsCount != value2.RowsCount)
                throw new System.ArgumentException("Row dimensions must agree.");
            int n = value2.ColumnsCount;
            int m = value2.RowsCount;
            int nB = value1.ColumnsCount;
            int mB = value1.RowsCount;
            //if (!FullRank(diagonal))
            //    throw new System.SystemException("Matrix is rank deficient.");
            double[] diagonal = new double[value2.RowsCount];
            //TODO: copy value2 to temp value
            //CSRMatrix<double> tempValue = QrDecomposition(value2, diagonal);
            //if (tempValue == null)
            //    return null;
            //FullMatrix<double> result = new FullMatrix<double>(value1);

            //int[] tempValueIndexes = new int[m];
            //double[] tempValueValues = new double[m];

            //int[] resultIndexes = new int[m];
            //double[] resultValues = new double[m];
            //uint indexShiftRow = (uint)tempValue.ShiftColumn;
            //uint columnShiftN = (uint)tempValue.ShiftNext;
            //// Compute Y = transpose(Q)*B
            //for (int j = 0; j < n; j++)
            //{
            //    for (int jb = 0; jb < nB; jb++)
            //    {
            //        double s = 0.0;
            //        for (int i = j; i < m; i++)
            //        {
            //            s += tempValue.Get(i, j) * result.Get(i, jb);
            //        }
            //        if (s == 0)
            //            continue;
            //        s = (-s) / tempValue.Get(j, j);
            //        for (int i = j; i < m; i++)
            //        {
            //            result.Set(i, jb, result.Get(i, jb) + s * tempValue.Get(i, j));
            //        }
            //    }
            //}
            //// Solve R*X = Y;
            //for (int j = n - 1; j >= 0; j--)
            //{
            //    for (int jb = 0; jb < nB; jb++)
            //    {
            //        result.Set(j, jb, result.Get(j, jb) / diagonal[j]);
            //    }
            //    for (int i = 0; i < j; i++)
            //    {
            //        for (int jb = 0; jb < nB; jb++)
            //        {
            //            result.Set(i, jb, result.Get(i, jb) - result.Get(j, jb) * tempValue.Get(i, j));
            //        }
            //    }
            //}
            //result.RowCount = tempValue.ColumnCount;
            return null;
        }

        /// <summary>
        /// Gauss solver for sparse matrix a*x = b
        /// </summary>
        /// <param name="b"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        //public static FullMatrix<double> GaussDivide(FullMatrix<double> b, CSRMatrix<double> a)
        //{
        //    if (a == null)
        //        throw new ArgumentNullException("a");
        //    if (b == null)
        //        throw new ArgumentNullException("b");
        //    // Initialize.
        //    int n = a.m_RowsCount;
        //    if (a.ColumnsCount != n)
        //        throw new ArgumentException("Matrix 'a' must be quad.");
        //    if (b.m_RowsCount != n)
        //        throw new ArgumentException("Matrix row dimensions must agree.");
        //    PieceMatrix<double> factorA = new PieceMatrix<double>(n, n);
        //    // Copy right hand side.
        //    FullMatrix<double> returnValue = new FullMatrix<double>(b);
        //    // Get pivots
        //    int[] firstIndex = new int[n];
        //    int[] pivots = new int[n];
        //    int[] rowIndex = a.m_RowsMapping;
        //    double[] values = a.m_Values;
        //    int[] columns = a.m_Columns;
        //    for (int i = 0; i < n; ++i)
        //    {
        //        int start = rowIndex[i];
        //        int end = rowIndex[i + 1];
        //        while (start != end)
        //        {
        //            if (values[start] != 0)
        //            {
        //                firstIndex[i] = columns[start];
        //                break;
        //            }
        //            start++;
        //        }
        //        if (start == end)
        //            return null;
        //        pivots[i] = i;
        //    }
        //    // Sort by pivots (better rows in top)
        //    int t = 0;
        //    for (int i = 0; i < n; ++i)
        //    {
        //        for (int j = i + 1; j < n; ++j)
        //        {
        //            if (firstIndex[j] < firstIndex[i])
        //            {
        //                t = firstIndex[i];
        //                firstIndex[i] = firstIndex[j];
        //                firstIndex[j] = t;
        //                t = pivots[i];
        //                pivots[i] = pivots[j];
        //                pivots[j] = t;
        //            }
        //        }
        //        if (firstIndex[i] > i)
        //            return null;
        //    }
        //    // Get triangular matrix
        //    for (int i = 0; i < n; ++i)
        //    {
        //        // Get the better row with non zero diagonal element
        //        bool flag = false;
        //        for (int st = i; st < pivots.Length; ++st)
        //        {
        //            int index1 = pivots[st];
        //            int start1 = rowIndex[index1];
        //            int end1 = rowIndex[index1 + 1];
        //            while (start1 != end1)
        //            {
        //                if (columns[start1] < i)
        //                {
        //                    start1++;
        //                    continue;
        //                }
        //                if (columns[start1] == i)
        //                {
        //                    if (values[start1] != 0)
        //                    {
        //                        t = firstIndex[i];
        //                        firstIndex[i] = firstIndex[st];
        //                        firstIndex[st] = t;
        //                        t = pivots[i];
        //                        pivots[i] = pivots[st];
        //                        pivots[st] = t;
        //                        flag = true;
        //                    }
        //                }
        //                break;
        //            }                
        //        }
        //        if (!flag)
        //            return null;
        //        int index = pivots[i];
        //        int startIndex = firstIndex[i];
        //        double[] tempArray = new double[n];
        //        int start = rowIndex[index];
        //        int end = rowIndex[index + 1];
        //        while (start != end)
        //        {
        //            tempArray[columns[start]] = values[start];
        //            start++;
        //        }
        //        while (startIndex < i)
        //        {
        //            double[] row = factorA.m_Values[startIndex];
        //            double multiplier = tempArray[startIndex] / row[0];
        //            tempArray[startIndex] = 0;
        //            // substract the row number 'startIndex'
        //            for (int j = startIndex + 1, k = 1; j < n; ++j, ++k)
        //                tempArray[j] -= row[k] * multiplier;
        //            returnValue[i, 0] -= returnValue[startIndex, 0] * multiplier;
        //            // Find new start index
        //            for (; startIndex < n; ++startIndex)
        //                if (tempArray[startIndex] != 0)
        //                    break;
        //        }
        //        if (startIndex > i)
        //            return null;
        //        factorA.m_Values[i] = new double[n - i];
        //        Array.Copy(tempArray, i, factorA.m_Values[i], 0, n - i);
        //      //  factorA.m_Zeros[i] = 0;
        //      //  factorA.m_Heads[i] = i + 1;
        //    }
        //    for (int i = n - 1; i >= 0; --i)
        //    {
        //        double[] row = factorA.m_Values[i];
        //        double tt = 0;
        //        for (int j = i + 1, k = 1; j < n; ++j, ++k)
        //            tt += returnValue[j, 0] * row[k];
        //        returnValue[i, 0] -= tt;
        //        returnValue[i, 0] /= row[0];
        //    }
        //    return returnValue;
        //}
        unsafe public static FullMatrix<double> ZeidelDivide(FullMatrix<double> b, CsrMatrix<double> a)
        {
            double eps = 0.00001;
            FullMatrix<double> x = new FullMatrix<double>(a.RowsCount, b.ColumnsCount);

            double prev = 0;
            int[] pivots = GetPivots(a);
            bool tmp;
            do
            {
                tmp = true;
                for (int i = 0; i < a.RowsCount; i++)
                {
                    int pivot = pivots[i];
                    double var = 0;
                    for (int j = 0; j < a.ColumnsCount; j++)
                        if (i != j)
                            var += a[pivot, j] * x[j];
                    prev = x[i];

                    x[i] = (b[pivot] - var) / a[pivot, i];
                    tmp = tmp && (Math.Abs(prev - x[i]) < eps);
                }
            } while (!tmp);

            return x;
        }
        //public static FullMatrix<double> LuDivide(FullMatrix<double> b, CSRMatrix<double> a)
        //{
        //    return LuSolve(LuDecomposition(a), b);
        //}
        private static int[] GetPivots(CsrMatrix<double> value)
        {
            int[] returnValue = new int[value.RowsCount];
            for (int i = 0; i < returnValue.Length; ++i)
                returnValue[i] = i;
            return returnValue;
        }
        #endregion double
        #region Complex
        unsafe public static void ElementsDivide(int m, int n, Complex[] value1, Complex[] value2, Complex[] result)
        {
            int size = m * n;
            if (size != value1.Length)
                throw new ArgumentOutOfRangeException("value1");
            if (size != value2.Length)
                throw new ArgumentOutOfRangeException("value2");
            if (size != result.Length)
                throw new ArgumentOutOfRangeException("result");
            fixed (Complex* value1Pointer = value1, value2Pointer = value2, resultPointer = result)
            {
                double* ptrValue1 = (double*)value1Pointer;
                double* ptrValue2 = (double*)value2Pointer;
                double* ptrResult = (double*)resultPointer;
                double* ptrEnd = ptrResult + size * 2 - 31;
                // Main loop, pointers for row values
                while (ptrResult < ptrEnd)
                {
                    ComplexDivide(ptrValue1, ptrValue2, ptrResult);
                    ComplexDivide(ptrValue1 + 2, ptrValue2 + 2, ptrResult + 2);
                    ComplexDivide(ptrValue1 + 4, ptrValue2 + 4, ptrResult + 4);
                    ComplexDivide(ptrValue1 + 6, ptrValue2 + 6, ptrResult + 6);
                    ComplexDivide(ptrValue1 + 8, ptrValue2 + 8, ptrResult + 8);
                    ComplexDivide(ptrValue1 + 10, ptrValue2 + 10, ptrResult + 10);
                    ComplexDivide(ptrValue1 + 12, ptrValue2 + 12, ptrResult + 12);
                    ComplexDivide(ptrValue1 + 14, ptrValue2 + 14, ptrResult + 14);
                    ComplexDivide(ptrValue1 + 16, ptrValue2 + 16, ptrResult + 16);
                    ComplexDivide(ptrValue1 + 18, ptrValue2 + 18, ptrResult + 18);
                    ComplexDivide(ptrValue1 + 20, ptrValue2 + 20, ptrResult + 20);
                    ComplexDivide(ptrValue1 + 22, ptrValue2 + 22, ptrResult + 22);
                    ComplexDivide(ptrValue1 + 24, ptrValue2 + 24, ptrResult + 24);
                    ComplexDivide(ptrValue1 + 26, ptrValue2 + 26, ptrResult + 26);
                    ComplexDivide(ptrValue1 + 28, ptrValue2 + 28, ptrResult + 28);
                    ComplexDivide(ptrValue1 + 30, ptrValue2 + 30, ptrResult + 30);
                    ptrResult += 32;
                    ptrValue1 += 32;
                    ptrValue2 += 32;
                }
                ptrEnd += 16;
                if (ptrResult < ptrEnd)
                {
                    ComplexDivide(ptrValue1, ptrValue2, ptrResult);
                    ComplexDivide(ptrValue1 + 2, ptrValue2 + 2, ptrResult + 2);
                    ComplexDivide(ptrValue1 + 4, ptrValue2 + 4, ptrResult + 4);
                    ComplexDivide(ptrValue1 + 6, ptrValue2 + 6, ptrResult + 6);
                    ComplexDivide(ptrValue1 + 8, ptrValue2 + 8, ptrResult + 8);
                    ComplexDivide(ptrValue1 + 10, ptrValue2 + 10, ptrResult + 10);
                    ComplexDivide(ptrValue1 + 12, ptrValue2 + 12, ptrResult + 12);
                    ComplexDivide(ptrValue1 + 14, ptrValue2 + 14, ptrResult + 14);
                    ptrResult += 16;
                    ptrValue1 += 16;
                    ptrValue2 += 16;
                }
                ptrEnd += 8;
                if (ptrResult < ptrEnd)
                {
                    ComplexDivide(ptrValue1, ptrValue2, ptrResult);
                    ComplexDivide(ptrValue1 + 2, ptrValue2 + 2, ptrResult + 2);
                    ComplexDivide(ptrValue1 + 4, ptrValue2 + 4, ptrResult + 4);
                    ComplexDivide(ptrValue1 + 6, ptrValue2 + 6, ptrResult + 6);
                    ptrResult += 8;
                    ptrValue1 += 8;
                    ptrValue2 += 8;
                }
                ptrEnd += 4;
                if (ptrResult < ptrEnd)
                {
                    ComplexDivide(ptrValue1, ptrValue2, ptrResult);
                    ComplexDivide(ptrValue1 + 2, ptrValue2 + 2, ptrResult + 2);
                    ptrResult += 4;
                    ptrValue1 += 4;
                    ptrValue2 += 4;
                }
                ptrEnd += 2;
                if (ptrResult < ptrEnd)
                {
                    ComplexDivide(ptrValue1, ptrValue2, ptrResult);
                    ptrResult += 2;
                    ptrValue1 += 2;
                    ptrValue2 += 2;
                }
            }
        }
        public static FullMatrix<Complex> ElementsDivide(FullMatrix<Complex> value1, FullMatrix<Complex> value2)
        {
            int m = value1.m_RowsCount;
            int n = value1.m_ColumnsCount;

            if (m != value2.m_RowsCount)
                throw new Exception("Value1 and value2 has different row counts!");
            if (n != value2.m_ColumnsCount)
                throw new Exception("Value1 and value2 has different column counts!");

            Complex[] tempResult = new Complex[m * n];
            ElementsDivide(m, n, value1.m_Values, value2.m_Values, tempResult);

            FullMatrix<Complex> returnValue = new FullMatrix<Complex>();
            returnValue.m_RowsCount = m;
            returnValue.m_ColumnsCount = n;
            returnValue.m_Values = tempResult;
            return returnValue;
        }
        #endregion Complex
        #endregion Divide
        #region Transpose
        #region double
        /// <summary>
        /// Matrices transpose
        /// </summary>
        /// <param name="m">Row count</param>
        /// <param name="n">Column count</param>
        /// <param name="value">Value array</param>
        /// <param name="result">Result array</param>
        unsafe public static void Transpose(int m, int n, double[] value, double[] result)
        {
            int size = m * n;
            if (size != value.Length)
                throw new ArgumentOutOfRangeException("value");
            if (size != result.Length)
                throw new ArgumentOutOfRangeException("result");
            if (result == value)
            {
                value = new double[size];
                CommonOperations.FastCopy(result, value, size);
            }

            fixed (double* valuePointer = value, resultPointer = result)
            {
                double* ptrValue = valuePointer;
                double* ptrResult = resultPointer;
                double* ptrValueEnd = valuePointer + n;
                // Main loop, pointers for row values
                for (; ptrValue < ptrValueEnd; ptrValue++)
                {
                    double* ptrEnd = ptrResult + m - 31;
                    double* ptrValue1 = ptrValue;
                    while (ptrResult < ptrEnd)
                    {
                        *ptrResult = *ptrValue1;
                        *(ptrResult + 1) = *(ptrValue1 += n);
                        *(ptrResult + 2) = *(ptrValue1 += n);
                        *(ptrResult + 3) = *(ptrValue1 += n);
                        *(ptrResult + 4) = *(ptrValue1 += n);
                        *(ptrResult + 5) = *(ptrValue1 += n);
                        *(ptrResult + 6) = *(ptrValue1 += n);
                        *(ptrResult + 7) = *(ptrValue1 += n);
                        *(ptrResult + 8) = *(ptrValue1 += n);
                        *(ptrResult + 9) = *(ptrValue1 += n);
                        *(ptrResult + 10) = *(ptrValue1 += n);
                        *(ptrResult + 11) = *(ptrValue1 += n);
                        *(ptrResult + 12) = *(ptrValue1 += n);
                        *(ptrResult + 13) = *(ptrValue1 += n);
                        *(ptrResult + 14) = *(ptrValue1 += n);
                        *(ptrResult + 15) = *(ptrValue1 += n);
                        *(ptrResult + 16) = *(ptrValue1 += n);
                        *(ptrResult + 17) = *(ptrValue1 += n);
                        *(ptrResult + 18) = *(ptrValue1 += n);
                        *(ptrResult + 19) = *(ptrValue1 += n);
                        *(ptrResult + 20) = *(ptrValue1 += n);
                        *(ptrResult + 21) = *(ptrValue1 += n);
                        *(ptrResult + 22) = *(ptrValue1 += n);
                        *(ptrResult + 23) = *(ptrValue1 += n);
                        *(ptrResult + 24) = *(ptrValue1 += n);
                        *(ptrResult + 25) = *(ptrValue1 += n);
                        *(ptrResult + 26) = *(ptrValue1 += n);
                        *(ptrResult + 27) = *(ptrValue1 += n);
                        *(ptrResult + 28) = *(ptrValue1 += n);
                        *(ptrResult + 29) = *(ptrValue1 += n);
                        *(ptrResult + 30) = *(ptrValue1 += n);
                        *(ptrResult + 31) = *(ptrValue1 += n);
                        ptrValue1 += n;
                        ptrResult += 32;
                    }
                    ptrEnd += 16;
                    if (ptrResult < ptrEnd)
                    {
                        *ptrResult = *ptrValue1;
                        *(ptrResult + 1) = *(ptrValue1 += n);
                        *(ptrResult + 2) = *(ptrValue1 += n);
                        *(ptrResult + 3) = *(ptrValue1 += n);
                        *(ptrResult + 4) = *(ptrValue1 += n);
                        *(ptrResult + 5) = *(ptrValue1 += n);
                        *(ptrResult + 6) = *(ptrValue1 += n);
                        *(ptrResult + 7) = *(ptrValue1 += n);
                        *(ptrResult + 8) = *(ptrValue1 += n);
                        *(ptrResult + 9) = *(ptrValue1 += n);
                        *(ptrResult + 10) = *(ptrValue1 += n);
                        *(ptrResult + 11) = *(ptrValue1 += n);
                        *(ptrResult + 12) = *(ptrValue1 += n);
                        *(ptrResult + 13) = *(ptrValue1 += n);
                        *(ptrResult + 14) = *(ptrValue1 += n);
                        *(ptrResult + 15) = *(ptrValue1 += n);
                        ptrValue1 += n;
                        ptrResult += 16;
                    }
                    ptrEnd += 8;
                    if (ptrResult < ptrEnd)
                    {
                        *ptrResult = *ptrValue1;
                        *(ptrResult + 1) = *(ptrValue1 += n);
                        *(ptrResult + 2) = *(ptrValue1 += n);
                        *(ptrResult + 3) = *(ptrValue1 += n);
                        *(ptrResult + 4) = *(ptrValue1 += n);
                        *(ptrResult + 5) = *(ptrValue1 += n);
                        *(ptrResult + 6) = *(ptrValue1 += n);
                        *(ptrResult + 7) = *(ptrValue1 += n);
                        ptrValue1 += n;
                        ptrResult += 8;
                    }
                    ptrEnd += 4;
                    if (ptrResult < ptrEnd)
                    {
                        *ptrResult = *ptrValue1;
                        *(ptrResult + 1) = *(ptrValue1 += n);
                        *(ptrResult + 2) = *(ptrValue1 += n);
                        *(ptrResult + 3) = *(ptrValue1 += n);
                        ptrValue1 += n;
                        ptrResult += 4;
                    }
                    ptrEnd += 2;
                    if (ptrResult < ptrEnd)
                    {
                        *ptrResult = *ptrValue1;
                        *(ptrResult + 1) = *(ptrValue1 += n);
                        ptrValue1 += n;
                        ptrResult += 2;
                    }
                    if (ptrResult == ptrEnd)
                    {
                        *ptrResult = *ptrValue1;
                        ptrValue1 += n;
                        ptrResult++;
                    }
                }
            }
        }
        public static FullMatrix<double> Transpose(FullMatrix<double> value)
        {
            int m = value.m_RowsCount;
            int n = value.m_ColumnsCount;

            double[] tempResult = new double[m * n];
            Transpose(m, n, value.m_Values, tempResult);
            FullMatrix<double> result = new FullMatrix<double>();
            result.m_RowsCount = n;
            result.m_ColumnsCount = m;
            result.m_Values = tempResult;
            return result;
        }
        /// <summary>
        /// Transpose with result in another matrix
        /// </summary>
        /// <param name="value">Transpozed matrix</param>
        /// <param name="result">Result of operation</param>
        unsafe public static CsrMatrix<double> Transpose(CsrMatrix<double> value)
        {
            CsrMatrix<double> returnValue = new CsrMatrix<double>(value.m_RowsMapping[value.m_RowsCount], value.ColumnsCount, value.RowsCount);

            int[] indexes = new int[value.RowsCount];
            int[] ends = new int[value.RowsCount];
            Array.Copy(value.m_RowsMapping, indexes, indexes.Length);
            Array.Copy(value.m_RowsMapping, 1, ends, 0, ends.Length);
            fixed (double* values1Pointer = value.m_Values, valuesPointer = returnValue.m_Values)
            fixed (int* columns1Pointer = value.m_Columns, columnsPointer = returnValue.m_Columns, indexesPointer = indexes, endsPointer = ends)
            {
                int returnIndex = 0;
                for (int n = 0; n < value.m_ColumnsCount; ++n)
                {
                    for (int m = 0; m < value.m_RowsCount; ++m)
                    {
                        int valueIndex = indexesPointer[m];
                        if (valueIndex == endsPointer[m])
                            continue;
                        if (columns1Pointer[valueIndex] == n)
                        {
                            valuesPointer[returnIndex] = values1Pointer[valueIndex];
                            columnsPointer[returnIndex] = m;
                            indexesPointer[m]++;
                            returnIndex++;
                        }
                    }
                    returnValue.m_RowsMapping[n + 1] = returnIndex;
                }
            }
            return returnValue;
        }
        #endregion double
        #region Complex
        unsafe public static void Transpose(int m, int n, Complex[] value, Complex[] result)
        {
            int size = m * n;
            int n2 = n * 2;
            if (size != value.Length)
                throw new ArgumentOutOfRangeException("value");
            if (size != result.Length)
                throw new ArgumentOutOfRangeException("result");
            // For own transposes
            if (result == value)
            {
                value = new Complex[size];
                Array.Copy(result, value, size);
            }
            fixed (Complex* valuePointer = value, resultPointer = result)
            {
                double* ptrValue = (double*)valuePointer;
                double* ptrValueEnd = ((double*)valuePointer) + n2;

                double* ptrResult = (double*)resultPointer;
                // Main loop, pointers for row values
                for (; ptrValue < ptrValueEnd; ptrValue+=2)
                {
                    double* ptrEnd = ptrResult + 2 * m - 15;
                    double* ptrValue1 = ptrValue;

                    while (ptrResult < ptrEnd)
                    {
                        *ptrResult = *ptrValue1;
                        *(ptrResult + 1) = *(ptrValue1 + 1);
                        *(ptrResult + 2) = *(ptrValue1 += n2);
                        *(ptrResult + 3) = *(ptrValue1 + 1);
                        *(ptrResult + 4) = *(ptrValue1 += n2);
                        *(ptrResult + 5) = *(ptrValue1 + 1);
                        *(ptrResult + 6) = *(ptrValue1 += n2);
                        *(ptrResult + 7) = *(ptrValue1 + 1);
                        *(ptrResult + 8) = *(ptrValue1 += n2);
                        *(ptrResult + 9) = *(ptrValue1 + 1);
                        *(ptrResult + 10) = *(ptrValue1 += n2);
                        *(ptrResult + 11) = *(ptrValue1 + 1);
                        *(ptrResult + 12) = *(ptrValue1 += n2);
                        *(ptrResult + 13) = *(ptrValue1 + 1);
                        *(ptrResult + 14) = *(ptrValue1 += n2);
                        *(ptrResult + 15) = *(ptrValue1 + 1);
                        ptrValue1 += n2;
                        ptrResult += 16;
                    }
                    ptrEnd += 8;
                    if (ptrResult < ptrEnd)
                    {
                        *ptrResult = *ptrValue1;
                        *(ptrResult + 1) = *(ptrValue1 + 1);
                        *(ptrResult + 2) = *(ptrValue1 += n2);
                        *(ptrResult + 3) = *(ptrValue1 + 1);
                        *(ptrResult + 4) = *(ptrValue1 += n2);
                        *(ptrResult + 5) = *(ptrValue1 + 1);
                        *(ptrResult + 6) = *(ptrValue1 += n2);
                        *(ptrResult + 7) = *(ptrValue1 + 1);
                        ptrValue1 += n2;
                        ptrResult += 8;
                    }
                    ptrEnd += 4;
                    if (ptrResult < ptrEnd)
                    {
                        *ptrResult = *ptrValue1;
                        *(ptrResult + 1) = *(ptrValue1 + 1);
                        *(ptrResult + 2) = *(ptrValue1 += n2);
                        *(ptrResult + 3) = *(ptrValue1 + 1);
                        ptrValue1 += n2;
                        ptrResult += 4;
                    }
                    ptrEnd += 2;
                    if (ptrResult < ptrEnd)
                    {
                        *ptrResult = *ptrValue1;
                        *(ptrResult + 1) = *(ptrValue1 + 1);
                        ptrValue1 += n2;
                        ptrResult += 2;
                    }
                }
            }
        }
        unsafe public static void Transpose(int m, int n, Block2x2[] value, Block2x2[] result)
        {
            int size = m * n;
            int n2 = n * 4;
            if (size != value.Length)
                throw new ArgumentOutOfRangeException("value");
            if (size != result.Length)
                throw new ArgumentOutOfRangeException("result");
            // For own transposes
            if (result == value)
            {
                value = new Block2x2[size];
                Array.Copy(result, value, size);
            }
            fixed (Block2x2* valuePointer = value, resultPointer = result)
            {
                double* ptrValue = (double*)valuePointer;
                double* ptrValueEnd = ((double*)valuePointer) + n2;

                double* ptrResult = (double*)resultPointer;
                // Main loop, pointers for row values
                for (; ptrValue < ptrValueEnd; ptrValue += 4)
                {
                    double* ptrEnd = ptrResult + 4 * m - 15;
                    double* ptrValue1 = ptrValue;

                    while (ptrResult < ptrEnd)
                    {
                        *ptrResult = *ptrValue1;
                        *(ptrResult + 1) = *(ptrValue1 + 1);
                        *(ptrResult + 2) = *(ptrValue1 + 2);
                        *(ptrResult + 3) = *(ptrValue1 + 3);
                        *(ptrResult + 4) = *(ptrValue1 += n2);
                        *(ptrResult + 5) = *(ptrValue1 + 1);
                        *(ptrResult + 6) = *(ptrValue1 + 2);
                        *(ptrResult + 7) = *(ptrValue1 + 3);
                        *(ptrResult + 8) = *(ptrValue1 += n2);
                        *(ptrResult + 9) = *(ptrValue1 + 1);
                        *(ptrResult + 10) = *(ptrValue1 + 2);
                        *(ptrResult + 11) = *(ptrValue1 + 3);
                        *(ptrResult + 12) = *(ptrValue1 += n2);
                        *(ptrResult + 13) = *(ptrValue1 + 1);
                        *(ptrResult + 14) = *(ptrValue1 + 2);
                        *(ptrResult + 15) = *(ptrValue1 + 3);
                        ptrValue1 += n2;
                        ptrResult += 16;
                    }
                    ptrEnd += 8;
                    if (ptrResult < ptrEnd)
                    {
                        *ptrResult = *ptrValue1;
                        *(ptrResult + 1) = *(ptrValue1 + 1);
                        *(ptrResult + 2) = *(ptrValue1 + 2);
                        *(ptrResult + 3) = *(ptrValue1 + 3);
                        *(ptrResult + 4) = *(ptrValue1 += n2);
                        *(ptrResult + 5) = *(ptrValue1 + 1);
                        *(ptrResult + 6) = *(ptrValue1 + 2);
                        *(ptrResult + 7) = *(ptrValue1 + 3);
                        ptrValue1 += n2;
                        ptrResult += 8;
                    }
                    ptrEnd += 4;
                    if (ptrResult < ptrEnd)
                    {
                        *ptrResult = *ptrValue1;
                        *(ptrResult + 1) = *(ptrValue1 + 1);
                        *(ptrResult + 2) = *(ptrValue1 + 2);
                        *(ptrResult + 3) = *(ptrValue1 + 3);
                        ptrValue1 += n2;
                        ptrResult += 4;
                    }
                }
            }
        }
        public static FullMatrix<Complex> Transpose(FullMatrix<Complex> value) 
        {
            int m = value.m_RowsCount;
            int n = value.m_ColumnsCount;

            Complex[] tempResult = new Complex[m * n];
            Transpose(m, n, value.m_Values, tempResult);

            FullMatrix<Complex> result = new FullMatrix<Complex>();
            result.m_RowsCount = n;
            result.m_ColumnsCount = m;
            result.m_Values = tempResult;
            return result;
        }
        public static FullMatrix<Block2x2> Transpose(FullMatrix<Block2x2> value)
        {
            int m = value.m_RowsCount;
            int n = value.m_ColumnsCount;

            Block2x2[] tempResult = new Block2x2[m * n];
            Transpose(m, n, value.m_Values, tempResult);

            FullMatrix<Block2x2> result = new FullMatrix<Block2x2>();
            result.m_RowsCount = n;
            result.m_ColumnsCount = m;
            result.m_Values = tempResult;
            return result;
        }
        /// <summary>
        /// Transpose with result in another matrix
        /// </summary>
        /// <param name="value">Transpozed matrix</param>
        /// <param name="result">Result of operation</param>
        unsafe public static CsrMatrix<Complex> Transpose(CsrMatrix<Complex> value)
        {
            CsrMatrix<Complex> returnValue = new CsrMatrix<Complex>(value.m_RowsMapping[value.m_RowsCount], value.ColumnsCount, value.RowsCount);

            int[] indexes = new int[value.RowsCount];
            int[] ends = new int[value.RowsCount];
            Array.Copy(value.m_RowsMapping, indexes, indexes.Length);
            Array.Copy(value.m_RowsMapping, 1, ends, 0, ends.Length);
            fixed (Complex* values1Pointer = value.m_Values, valuesPointer = returnValue.m_Values)
            fixed (int* columns1Pointer = value.m_Columns, columnsPointer = returnValue.m_Columns, indexesPointer = indexes, endsPointer = ends)
            {
                int returnIndex = 0;
                for (int n = 0; n < value.m_ColumnsCount; ++n)
                {
                    for (int m = 0; m < value.m_RowsCount; ++m)
                    {
                        int valueIndex = indexesPointer[m];
                        if (valueIndex == endsPointer[m])
                            continue;
                        if (columns1Pointer[valueIndex] == n)
                        {
                            valuesPointer[returnIndex] = values1Pointer[valueIndex];
                            columnsPointer[returnIndex] = m;
                            indexesPointer[m]++;
                            returnIndex++;
                        }
                    }
                    returnValue.m_RowsMapping[n + 1] = returnIndex;
                }
            }
            return returnValue;
        }
        #endregion Complex
        #region Block
        /// <summary>
        /// Transpose with result in another matrix
        /// </summary>
        /// <param name="value">Transpozed matrix</param>
        /// <param name="result">Result of operation</param>
        unsafe public static CsrMatrix<Block2x2> Transpose(CsrMatrix<Block2x2> value)
        {
            CsrMatrix<Block2x2> returnValue = new CsrMatrix<Block2x2>(value.m_RowsMapping[value.m_RowsCount], value.ColumnsCount, value.RowsCount);

            int[] indexes = new int[value.RowsCount];
            int[] ends = new int[value.RowsCount];
            Array.Copy(value.m_RowsMapping, indexes, indexes.Length);
            Array.Copy(value.m_RowsMapping, 1, ends, 0, ends.Length);
            fixed (Block2x2* valuesPointer = value.m_Values, returnValuesPointer = returnValue.m_Values)
            fixed (int* columnsPointer = value.m_Columns, returnColumnsPointer = returnValue.m_Columns, indexesPointer = indexes, endsPointer = ends)
            {
                int returnIndex = 0;
                for (int n = 0; n < value.m_ColumnsCount; ++n)
                {
                    for (int m = 0; m < value.m_RowsCount; ++m)
                    {
                        int valueIndex = indexesPointer[m];
                        if (valueIndex == endsPointer[m])
                            continue;
                        if (columnsPointer[valueIndex] == n)
                        {
                            returnValuesPointer[returnIndex] = valuesPointer[valueIndex];
                            returnColumnsPointer[returnIndex] = m;
                            indexesPointer[m]++;
                            returnIndex++;
                        }
                    }
                    returnValue.m_RowsMapping[n + 1] = returnIndex;
                }
            }
            return returnValue;
        }
        #endregion Block
        #endregion Transpose
        #region Factorization
        /// <summary>Cholesky algorithm for symmetric and positive definite matrix.</summary>
		/// <param name="value">Square, symmetric matrix.</param>
		/// <returns>Structure to access L and isspd flag.</returns>
        //public static FullMatrix<double> CholeskySolve(PieceMatrix<double> factorA, FullMatrix<double> b)
        //{
        //    if (factorA == null)
        //        throw new ArgumentNullException("AFactor");
        //    if (b == null)
        //        throw new ArgumentNullException("b");
        //    int n = factorA.m_RowCount;
        //    if (b.m_RowsCount != factorA.m_RowCount)
        //        throw new System.ArgumentException("Matrix row dimensions must agree.");
            
        //    // Copy right hand side.
        //    FullMatrix<double> returnValue = new FullMatrix<double>(b);
        //    int nx = b.m_ColumnsCount;

        //    // Solve L*Y = B;
        //    for (int k = 0; k < n; ++k)
        //    {
        //        for (int j = 0; j < nx; j++)
        //            returnValue[k, j] /= factorA[k,k];                
        //        for (int i = k + 1; i < n; ++i)
        //            for (int j = 0; j < nx; ++j)
        //                returnValue[i,j] -= returnValue[k,j] * factorA[i,k];

        //    }

        //    // Solve L'*X = Y;
        //    for (int k = n - 1; k >= 0; k--)
        //    {
        //        for (int j = 0; j < nx; j++)
        //            returnValue[k,j] /= factorA[k,k];
        //        for (int i = 0; i < k; i++)
        //            for (int j = 0; j < nx; j++)
        //                returnValue[i, j] -= returnValue[k, j] * factorA[k,i];
        //    }
        //    return returnValue;
        //}
        /// <summary>
        /// Метод гаусса с выбором главного элемента (прямой метод)
        /// </summary>
        /// <param name="value">Матрица задающая СЛАУ</param>
        /// <returns>Вектор решений</returns>
        //public static FullMatrix<double> GaussSolve(CSRMatrix<double> value, FullMatrix<double> b)
        //{
        //    /// Маска для восстановления изначального порядка
        //    /// неизвестных
        //    int[] mask = new int[value.m_RowsCount];
        //    for (int i = 0; i < mask.Length; ++i)
        //        mask[i] = i;
        //    FullMatrix<double> returnValue = new FullMatrix<double>(b);
        //    /// Прямой проход
        //    for (int i = 0; i < value.m_RowsCount; ++i)
        //    {
        //        int maxIndx = i;
        //        double maxval = value[i, i];

        //        /// Поиск главного элемента в строке
        //        for (int j = i + 1; j < value.m_ColumnsCount; ++j)
        //            if (Math.Abs(maxval) < Math.Abs(value[i, j]))
        //            {
        //                maxval = value[i, j];
        //                maxIndx = j;
        //            }

        //        if (maxval == 0)
        //        {
        //            //Row x = new Row(value.rowCount);
        //            //for (int ii = 0; ii < value.rowCount; ii++)
        //            //    x[ii] = double.NaN;
        //            //return x;
        //            return null;
        //        }

        //        /// Перестановка столбцов
        //        if (i != maxIndx)
        //        {
        //          //  value.ExchangeColumns(i, maxIndx);
        //            // returnValue.ExchangeColumns(i, maxIndx);
        //            int tmp = mask[i];
        //            mask[i] = mask[maxIndx];
        //            mask[maxIndx] = tmp;
        //        }

        //        /// Делим строчку на главный элемент
        //        value[i] = value[i] / maxval;

        //        /// Вычетаем текущую строчку
        //        /// (предварительно домножив) из ниже стоящих строк
        //        for (int j = i + 1; j < value.m_RowsCount; ++j)
        //            value[j] = value[j] - value[j, i] * value[i];
        //    }

        //    // Обратный проход
        //    for (int i = value.m_RowsCount; i >= 0; i--)
        //    {
        //        /// Вычетаем текущую строчку
        //        /// (предварительно домножив) из выше стоящих строк
        //        for (int j = i - 1; j >= 0; j--)
        //            value[j] = value[j] - value[j, i] * value[i];
        //    }

        //    /// Восстановление порядка вхождения неизвестных
        //    /// и формирование результирующего вектора
        //   // Row res = new Row(value.rowCount);
        //   // for (int i = 0; i < value.rowCount; i++)
        //   //     res[mask[i]] = value[i, value.colCount - 1];
        //    return returnValue;
        //}
        //public static FullMatrix<double> Jacobi(int N, CSRMatrix<double> A, FullMatrix<double> F, FullMatrix<double> X)
        //{
        //// N - размерность матрицы; A[N][N] - матрица коэффициентов, F[N] - столбец свободных членов,
        //// X[N] - начальное приближение, ответ записывается также в X[N];
        //    double eps = 0.01;
        //    double[] TempX = new double[N];
        //    double norm; // норма, определяемая как наибольшая разность компонент столбца иксов соседних итераций.
        //    FullMatrix<double> returnValue = new FullMatrix<double>(X);
        //    do
        //    {
        //        for (int i = 0; i < N; i++)
        //        {
        //            TempX[i] = -F[i];
        //            for (int g = 0; g < N; g++)
        //            {
        //                if (i != g)
        //                    TempX[i] += A[i,g] * X[g];
        //            }
        //            TempX[i] /= -A[i,i];
        //        }
        //        norm = Math.Abs(X[0] - TempX[0]);
        //        for (int h = 0; h < N; h++)
        //        {
        //            if (Math.Abs(X[h] - TempX[h]) > norm)
        //                norm = Math.Abs(X[h] - TempX[h]);
        //            X[h] = TempX[h];
        //        }
        //    } while (norm > eps);
        //    return returnValue;
        //}

        //public static FCSRMatrix<double> LuFind(CSRMatrix<double> a)
        //{
        //    int m = a.m_RowsCount;
        //    int n = a.m_ColumnsCount;
        //    FCSRMatrix<double> returnValue = new FCSRMatrix<double>(m, n);
        //    int st = 0;
        //    for (int i = 0; i < m; i++)
        //    {
        //        // Get current row
        //        double[] row = new double[n];
        //        int index = a.m_RowsMapping[i];
        //        int endIndex = a.m_RowsMapping[i + 1];
        //        for (; index < endIndex; ++index)
        //            row[a.m_Columns[index]] = a.m_Values[index];
        //        // Substract previous rows from current
        //        for (int ii = 0; ii < i; ++ii)
        //        {
        //            if (row[ii] == 0)
        //                continue;
        //            double kiValue = row[ii];
        //            int[] indexes = returnValue.m_Columns[ii];
        //            double[] values = returnValue.m_Values[ii];
        //            int columnIndex;
        //            for (int counter = 0; counter < returnValue.m_Heads[ii]; ++counter)
        //            {
        //                st++;
        //                columnIndex = indexes[counter];
        //                if (columnIndex > ii)
        //                    row[columnIndex] -= kiValue * values[counter];
        //            }
        //        }
        //        // Divide current row
        //        double kkValue = row[i];
        //        for (int j = i + 1; j < n; j++)
        //            row[j] /= kkValue;

        //        // Add new row
        //        int l = 0;
        //        int[] columns = new int[n];
        //        for (int j = 0; j < n; ++j)
        //        {
        //            if (row[j] != 0)
        //            {
        //                row[l] = row[j];
        //                columns[l] = j;
        //                l++;
        //            }
        //        }
        //        if (l > 0)
        //        {
        //            if (l < n)
        //            {
        //                int[] tempColumns = new int[l];
        //                double[] tempValues = new double[l];
        //                Array.Copy(columns, tempColumns, l);
        //                Array.Copy(row, tempValues, l);
        //                columns = tempColumns;
        //                row = tempValues;
        //            }
        //            returnValue.m_Columns[i] = columns;
        //            returnValue.m_Values[i] = row;
        //            returnValue.m_Heads[i] = l;
        //        }
        //        //returnValue.AddRow(row);
        //    }
        //    Console.WriteLine(st);
        //    return returnValue;
        //}

        //public static FCSRMatrix<double> LuDecompositionOld(CSRMatrix<double> a)
        //{
        //    int m = a.m_RowsCount;
        //    int n = a.m_ColumnsCount;
        //    FCSRMatrix<double> returnValue = new FCSRMatrix<double>(m, n);
        //    int st = 0;
        //    for (int i = 0; i < m; i++)
        //    {
        //        // Get current row
        //        double[] row = new double[n];
        //        int index = a.m_RowsMapping[i];
        //        int endIndex = a.m_RowsMapping[i + 1];
        //        for (; index < endIndex; ++index)
        //            row[a.m_Columns[index]] = a.m_Values[index];
        //        // Substract previous rows from current
        //        for (int ii = 0; ii < i; ++ii)
        //        {
        //            if (row[ii] == 0)
        //                continue;
        //            double kiValue = row[ii];
        //            int[] indexes = returnValue.m_Columns[ii];
        //            double[] values = returnValue.m_Values[ii];
        //            int columnIndex;
        //            for (int counter = 0; counter < returnValue.m_Heads[ii]; ++counter)
        //            {
        //                st++;
        //                columnIndex = indexes[counter];
        //                if (columnIndex > ii)
        //                    row[columnIndex] -= kiValue * values[counter];
        //            }
        //        }
        //        // Divide current row
        //        double kkValue = row[i];
        //        for (int j = i + 1; j < n; j++)
        //            row[j] /= kkValue;

        //        // Add new row
        //        int l = 0;
        //        int[] columns = new int[n];
        //        for (int j = 0; j < n; ++j)
        //        {
        //            if (row[j] != 0)
        //            {
        //                row[l] = row[j];
        //                columns[l] = j;
        //                l++;
        //            }
        //        }
        //        if (l > 0)
        //        {
        //            if (l < n)
        //            {
        //                int[] tempColumns = new int[l];
        //                double[] tempValues = new double[l];
        //                Array.Copy(columns, tempColumns, l);
        //                Array.Copy(row, tempValues, l);
        //                columns = tempColumns;
        //                row = tempValues;
        //            }
        //            returnValue.m_Columns[i] = columns;
        //            returnValue.m_Values[i] = row;
        //            returnValue.m_Heads[i] = l;
        //        }
        //        //returnValue.AddRow(row);
        //    }
        //    Console.WriteLine(st);
        //    return returnValue;
        //}
        //public static unsafe FCSRMatrix<double> LuDecompositionNew(CSRMatrix<double> a)
        //{
        //    int m = a.m_RowsCount;
        //    int n = a.m_ColumnsCount;
        //    FCSRMatrix<double> returnValue = new FCSRMatrix<double>(m, n);
        //    int st = 0;
        //    double[] diag = new double[n];
        //    for (int i = 0; i < m; i++)
        //    {
        //        // Get current row
        //        double[] row = new double[n];
        //        int index = a.m_RowsMapping[i];
        //        int endIndex = a.m_RowsMapping[i + 1];
        //        for (; index < endIndex; ++index)
        //            row[a.m_Columns[index]] = a.m_Values[index];
        //        // Substract previous rows from current
        //        for (int ii = 0; ii < i; ++ii)
        //        {
        //            if (row[ii] == 0)
        //                continue;
        //            double kiValue = row[ii] /= diag[ii];

        //            int[] indexes = returnValue.m_Columns[ii];
        //            double[] values = returnValue.m_Values[ii];
        //            int columnIndex;
        //            for (int counter = 0; counter < returnValue.m_Heads[ii]; ++counter)
        //            {
        //                st++;
        //                columnIndex = indexes[counter];
        //                if (columnIndex > ii)
        //                    row[columnIndex] -= kiValue * values[counter];
        //            }
        //        }
        //        diag[i] = row[i];
        //        // Add new row
        //        int l = 0;
        //        int[] columns = new int[n];
        //        for (int j = 0; j < n; ++j)
        //        {
        //            if (row[j] != 0)
        //            {
        //                row[l] = row[j];
        //                columns[l] = j;
        //                l++;
        //            }
        //        }
        //        if (l > 0)
        //        {
        //            if (l < n)
        //            {
        //                int[] tempColumns = new int[l];
        //                double[] tempValues = new double[l];
        //                Array.Copy(columns, tempColumns, l);
        //                Array.Copy(row, tempValues, l);
        //                columns = tempColumns;
        //                row = tempValues;
        //            }
        //            returnValue.m_Columns[i] = columns;
        //            returnValue.m_Values[i] = row;
        //            returnValue.m_Heads[i] = l;
        //        }
        //        //returnValue.AddRow(row);
        //    }
        //    Console.WriteLine(st);
        //    return returnValue;
        //}

        //public static unsafe FCSRMatrix<double> LuDecomposition(CSRMatrix<double> a)
        //{
        //    int m = a.m_RowsCount;
        //    int n = a.m_ColumnsCount;
        //    int st = 0, st1 = 0, st2 = 0, st3 = 0, st4 = 0, st5 = 0, st6 = 0, st7 = 0, st8 = 0, st9 = 0, st10 = 0;
        //    FCSRMatrix<double> returnValue = new FCSRMatrix<double>(m, n);
        //    double[] diag = new double[n];
        //    double f11 = 0;
        //    double[] values = new double[n];
        //    int[] columns = new int[n];
        //    int[] nexts = new int[n];
        //    double* temp;
        //    fixed (int* columnsPtr = columns, nextsPtr = nexts)
        //    fixed (double* valuesPtr = values)
        //    for (int i = 0; i < m; i++)
        //    {
        //        //   st++;
        //        // Get current row
        //        int index = a.m_RowsMapping[i];
        //        int endIndex = a.m_RowsMapping[i + 1];
        //        int start = 0;
        //        int head = 0;
        //        for (; index < endIndex; ++index)
        //        {
        //            //    st1++;
        //            values[head] = a.m_Values[index];
        //            columns[head] = a.m_Columns[index];
        //            nexts[head] = ++head;
        //        }
        //        if (head > 0)
        //            nexts[head - 1] = -1;
        //        // Substract previous rows from current

        //        for (int counter = start; counter != -1; counter = nexts[counter])
        //        {
        //            //    st2++;
        //            int ii = columns[counter];
        //            if (ii >= i)
        //                break;
        //            //   st3++;
        //            double kiValue = values[counter] /= diag[ii];
        //            int[] columns1 = returnValue.m_Columns[ii];
        //            double[] values1 = returnValue.m_Values[ii];
        //            int head1 = returnValue.m_Heads[ii];
        //            int columnIndex1;
        //            // Block counterValue;
        //            int currentIndex = counter;
        //            for (int counter1 = 0; counter1 < head1; ++counter1)
        //            {
        //                //  st4++;
        //                columnIndex1 = columns1[counter1];
        //                if (columnIndex1 <= ii)
        //                    continue;
        //                //  st5++;
        //                // counterValue = values[counter1];
        //                f11 = -kiValue * values1[counter1];
        //                int previousIndex, columnIndex;
        //                for (; ; )
        //                {
        //                    st6++;
        //                    previousIndex = currentIndex;
        //                    currentIndex = *(nextsPtr + previousIndex);
        //                    if (currentIndex == -1)
        //                    {
        //                        currentIndex = head;
        //                        *(nextsPtr + currentIndex) = -1;
        //                        *(nextsPtr + previousIndex) = currentIndex;
        //                        *(columnsPtr + currentIndex) = columnIndex1;
        //                        //st7++;
        //                        temp = (valuesPtr + currentIndex);
        //                        *temp = f11;
        //                        head++;
        //                        break;
        //                    }
        //                    // Get the column index of current element
        //                    columnIndex = columns[currentIndex];
        //                    if (columnIndex == columnIndex1)
        //                    {
        //                        // Set element in current position
        //                        // st9++;
        //                        temp = (valuesPtr + currentIndex);
        //                        *temp += f11;
        //                        break;
        //                    }
        //                    if (columnIndex > columnIndex1)
        //                    {
        //                        currentIndex = head;
        //                        // Reset the row current element
        //                        *(nextsPtr + currentIndex) = *(nextsPtr + previousIndex);
        //                        *(nextsPtr + previousIndex) = currentIndex;
        //                        *(columnsPtr + currentIndex) = columnIndex1;

        //                        //  st8++;
        //                        temp = (valuesPtr + currentIndex);
        //                        *temp = f11;
        //                        head++;
        //                        break;
        //                    }

        //                }
        //            }
        //        }
        //        // Add new row
        //        int l = 0;
        //        int[] tempColumns = returnValue.m_Columns[i] = new int[head];
        //        double[] tempValues = returnValue.m_Values[i] = new double[head];
        //        returnValue.m_Heads[i] = head;
        //        int num;
        //        for (int counter = start; counter != -1; counter = nexts[counter])
        //        {
        //            st10++;
        //            num = tempColumns[l] = columns[counter];
        //            tempValues[l] = values[counter];
        //            if (num == i)
        //                diag[i] = values[counter];
        //            l++;
        //        }
        //    }
        //    //Console.WriteLine("st " + st);
        //    //Console.WriteLine("st1 " + st1);
        //    //Console.WriteLine("st2 " + st2);
        //    //Console.WriteLine("st3 " + st3);
        //    //Console.WriteLine("st4 " + st4);
        //    //Console.WriteLine("st5 " + st5);
        //    Console.WriteLine("st6 " + st6);
        //    //Console.WriteLine("st7 " + st7);
        //    //Console.WriteLine("st8 " + st8);
        //    //Console.WriteLine("st9 " + st9);
        //    //Console.WriteLine("st10 " + st10);
        //    return returnValue;
        //}
        public static unsafe CsrMatrix<Block2x2> LuDecompositionTest(CsrMatrix<Block2x2> a)
        {
            int m = a.m_RowsCount;
            int n = a.m_ColumnsCount;
            int st = 0, st1 = 0, st2 = 0, st3 = 0, st4 = 0, st5 = 0, st6 = 0, st7 = 0, st8 = 0, st9 = 0, st10 = 0;
            
            Block2x2[] retValues = new Block2x2[m * n];
            int[] retColumns = new int[m * n];
            int[] retRowIndexes = new int[m + 1];
            int retHead = 0;
            Block2x2[] diag = new Block2x2[n];
            Block2x2[] values = new Block2x2[n];
            int[] columns = new int[n];
            int[] nexts = new int[n];
            double* temp;
            Block2x2 temp1;
            Block2x2 kiValue;
            fixed (int* columnsPtr = columns, nextsPtr = nexts, retColumnsPtr = retColumns)
            fixed (Block2x2* valuesPtr1 = values, retValuesPtr = retValues)
                for (int i = 0; i < m; i++)
                {
                    //   st++;
                    // Get current row
                    int index = a.m_RowsMapping[i];
                    int endIndex = a.m_RowsMapping[i + 1];
                    int start = 0;
                    int head = 0;
                    for (; index < endIndex; ++index)
                    {
                        //    st1++;
                        values[head] = a.m_Values[index];
                        columns[head] = a.m_Columns[index];
                        nexts[head] = ++head;
                    }
                    if (head > 0)
                        nexts[head - 1] = -1;
                    // Substract previous rows from current

                    for (int counter = start; counter != -1; counter = nexts[counter])
                    {
                        //    st2++;
                        int ii = columns[counter];
                        if (ii >= i)
                            break;
                        //   st3++;
                        temp1 = diag[ii];
                        kiValue = values[counter];
                        kiValue.f00 /= temp1.f00;
                        kiValue.f10 /= temp1.f00;
                        kiValue.f01 -= kiValue.f00 * temp1.f01;
                        kiValue.f11 -= kiValue.f10 * temp1.f01;
                        kiValue.f01 /= temp1.f11;
                        kiValue.f11 /= temp1.f11;
                        values[counter] = kiValue;
                        int counter1 = retRowIndexes[ii];
                        int head1 = retRowIndexes[ii + 1];
                        int columnIndex1;
                        // Block counterValue;
                        int currentIndex = counter;
                        for (; counter1 < head1; ++counter1)
                        {
                            //  st4++;
                            columnIndex1 = retColumnsPtr[counter1];
                            if (columnIndex1 <= ii)
                                continue;
                            //  st5++;
                            temp1 = retValuesPtr[counter1];
                            int previousIndex, columnIndex;
                            for (; ; )
                            {
                                 // st6++;
                                previousIndex = currentIndex;
                                currentIndex = *(nextsPtr + previousIndex);
                                if (currentIndex == -1)
                                {
                                    currentIndex = head;
                                    *(nextsPtr + currentIndex) = -1;
                                    *(nextsPtr + previousIndex) = currentIndex;
                                    *(columnsPtr + currentIndex) = columnIndex1;
                                    //st7++;
                                    temp = (double*)(valuesPtr1 + currentIndex);
                                    *temp = -kiValue.f00 * temp1.f00 - kiValue.f01 * temp1.f10;
                                    *(temp + 1) = -kiValue.f00 * temp1.f01 - kiValue.f01 * temp1.f11;
                                    *(temp + 2) = -kiValue.f10 * temp1.f00 - kiValue.f11 * temp1.f10;
                                    *(temp + 3) = -kiValue.f10 * temp1.f01 - kiValue.f11 * temp1.f11;
                                    head++;

                                    break;
                                }
                                // Get the column index of current element
                                columnIndex = columns[currentIndex];
                                if (columnIndex == columnIndex1)
                                {
                                    // Set element in current position
                                    // st9++;
                                    temp = (double*)(valuesPtr1 + currentIndex);
                                    *temp -= kiValue.f00 * temp1.f00 + kiValue.f01 * temp1.f10;
                                    *(temp + 1) -= kiValue.f00 * temp1.f01 + kiValue.f01 * temp1.f11;
                                    *(temp + 2) -= kiValue.f10 * temp1.f00 + kiValue.f11 * temp1.f10;
                                    *(temp + 3) -= kiValue.f10 * temp1.f01 + kiValue.f11 * temp1.f11;
                                    break;
                                }
                                if (columnIndex > columnIndex1)
                                {
                                    currentIndex = head;
                                    // Reset the row current element
                                    *(nextsPtr + currentIndex) = *(nextsPtr + previousIndex);
                                    *(nextsPtr + previousIndex) = currentIndex;
                                    *(columnsPtr + currentIndex) = columnIndex1;

                                    //  st8++;
                                    temp = (double*)(valuesPtr1 + currentIndex);
                                    *temp = -kiValue.f00 * temp1.f00 - kiValue.f01 * temp1.f10;
                                    *(temp + 1) = -kiValue.f00 * temp1.f01 - kiValue.f01 * temp1.f11;
                                    *(temp + 2) = -kiValue.f10 * temp1.f00 - kiValue.f11 * temp1.f10;
                                    *(temp + 3) = -kiValue.f10 * temp1.f01 - kiValue.f11 * temp1.f11;

                                    head++;
                                    break;
                                }

                            }
                        }
                    }
                    // Add new row
                    retHead = retRowIndexes[i];
                    int num;
                    Block2x2 diagI = default(Block2x2);
                    for (int counter = start; counter != -1; counter = nexts[counter])
                    {
                        st10++;
                        num = retColumns[retHead] = columns[counter];
                        if (num >= i)
                        {
                            if (num > i)
                            {
                                Block2x2 nonDiagI = values[counter];
                                nonDiagI.f10 -= diagI.f10 * nonDiagI.f00;
                                nonDiagI.f11 -= diagI.f10 * nonDiagI.f01;

                                retValues[retHead] = nonDiagI;
                            }
                            else
                            {
                                diagI = values[counter];
                                diagI.f10 /= diagI.f00;
                                diagI.f11 = diagI.f11 - diagI.f10 * diagI.f01;
                                retValues[retHead] = diag[i] = diagI;
                            }
                        }
                        else
                            retValues[retHead] = values[counter];
                        retHead++;
                    }
                    retRowIndexes[i + 1] = retHead;
                    
                }
            CsrMatrix<Block2x2> returnValue = new CsrMatrix<Block2x2>(retHead, m, n);
            //Array.Copy(retValues, returnValue.m_Values, retHead);
            //Array.Copy(retColumns, returnValue.m_Columns, retHead);
            returnValue.m_RowsMapping = retRowIndexes;
                
            //Console.WriteLine("st " + st);
            //Console.WriteLine("st1 " + st1);
            //Console.WriteLine("st2 " + st2);
            //Console.WriteLine("st3 " + st3);
            //Console.WriteLine("st4 " + st4);
            //Console.WriteLine("st5 " + st5);
            //  Console.WriteLine("st6 " + st6);
            //Console.WriteLine("st7 " + st7);
            //Console.WriteLine("st8 " + st8);
            //Console.WriteLine("st9 " + st9);
            //Console.WriteLine("st10 " + st10);
            return returnValue;
        }
        
        //public static CSRMatrix<Block2x2> LuDecompositionTest1(CSRMatrix<Block2x2> a)
        //{
        //    FCSRMatrix<Block2x2> returnValue = LuDecompositionTest2(a);
        //    return Convert(returnValue);
        //}

        //public static unsafe FCSRMatrix<Block2x2> LuDecompositionTest2(CSRMatrix<Block2x2> a)
        //{
        //    int m = a.m_RowsCount;
        //    int n = a.m_ColumnsCount;
        //    int st = 0, st1 = 0, st2 = 0, st3 = 0, st4 = 0, st5 = 0, st6 = 0, st7 = 0, st8 = 0, st9 = 0, st10 = 0;
        //    FCSRMatrix<Block2x2> returnValue = new FCSRMatrix<Block2x2>(m, n);
        //    Block2x2[] diag = new Block2x2[n];
        //    Block2x2[] values = new Block2x2[n];
        //    int[] columns = new int[n];
        //    int[] starts = new int[m];
        //    int[] nexts = new int[n];
        //    Block2x2* temp;
        //    Block2x2 temp1;
        //    Block2x2 iValue;
        //    fixed (int* columnsPtr = columns, nextsPtr = nexts)
        //    fixed (Block2x2* valuesPtr = values)
        //    for (int i = 0; i < m; i++)
        //    {
        //        //   st++;
        //        // Get current row
        //        int index = a.m_RowsMapping[i];
        //        int endIndex = a.m_RowsMapping[i + 1];
        //        int head = 0;
        //        for (; index < endIndex; ++index)
        //        {
        //            //    st1++;
        //            values[head] = a.m_Values[index];
        //            columns[head] = a.m_Columns[index];
        //            nexts[head] = ++head;
        //        }
        //        if (head > 0)
        //            nexts[head - 1] = -1;
        //        // Substract previous rows from current
        //        for (int counter = 0; counter != -1; counter = nexts[counter])
        //        {
        //            //    st2++;
        //            int ii = columns[counter];
        //            if (ii >= i)
        //                break;
        //            //   st3++;
        //            temp1 = diag[ii];
        //            iValue = values[counter];
        //            iValue.f00 /= temp1.f00;
        //            //if (double.IsNaN(iValue.f11))
        //            //    throw new Exception();
        //            iValue.f10 /= temp1.f00;
        //            iValue.f01 -= iValue.f00 * temp1.f01;
        //            iValue.f11 -= iValue.f10 * temp1.f01;
        //            iValue.f01 /= temp1.f11;
        //            iValue.f11 /= temp1.f11;
        //            values[counter] = iValue;
        //            int[] columns1 = returnValue.m_Columns[ii];
        //            Block2x2[] values1 = returnValue.m_Values[ii];
        //            int head1 = returnValue.m_Heads[ii];
        //            int columnIndex1;
        //            // Block counterValue;
        //            int currentIndex = counter;
        //            for (int counter1 = starts[ii] + 1; counter1 < head1; ++counter1)
        //            {
        //                columnIndex1 = columns1[counter1];
        //               //   st5++;
        //                temp1 = values1[counter1];
        //                int previousIndex, columnIndex;
        //                for (; ; )
        //                {
        //                   //   st6++;
        //                    previousIndex = currentIndex;
        //                    currentIndex = nextsPtr[previousIndex];
        //                    if (currentIndex == -1)
        //                    {
        //                        currentIndex = head;
        //                        *(nextsPtr + currentIndex) = -1;
        //                        *(nextsPtr + previousIndex) = currentIndex;
        //                        *(columnsPtr + currentIndex) = columnIndex1;
        //                    //    st7++;
        //                        temp = valuesPtr + currentIndex;
        //                        (*temp).f00 = -iValue.f00 * temp1.f00 - iValue.f01 * temp1.f10;
        //                        (*temp).f01 = -iValue.f00 * temp1.f01 - iValue.f01 * temp1.f11;
        //                        (*temp).f10 = -iValue.f10 * temp1.f00 - iValue.f11 * temp1.f10;
        //                        (*temp).f11 = -iValue.f10 * temp1.f01 - iValue.f11 * temp1.f11;
        //                        head++;
        //                        break;
        //                    }
        //                    // Get the column index of current element
        //                    columnIndex = columns[currentIndex];
        //                    if (columnIndex == columnIndex1)
        //                    {
        //                        // Set element in current position
        //                     //    st9++;
        //                        temp = valuesPtr + currentIndex;
        //                        (*temp).f00 -= iValue.f00 * temp1.f00 + iValue.f01 * temp1.f10;
        //                        (*temp).f01 -= iValue.f00 * temp1.f01 + iValue.f01 * temp1.f11;
        //                        (*temp).f10 -= iValue.f10 * temp1.f00 + iValue.f11 * temp1.f10;
        //                        (*temp).f11 -= iValue.f10 * temp1.f01 + iValue.f11 * temp1.f11;
        //                        break;
        //                    }
        //                    if (columnIndex > columnIndex1)
        //                    {
        //                        currentIndex = head;
        //                        // Reset the row current element
        //                        *(nextsPtr + currentIndex) = *(nextsPtr + previousIndex);
        //                        *(nextsPtr + previousIndex) = currentIndex;
        //                        *(columnsPtr + currentIndex) = columnIndex1;

        //                    //      st8++;
        //                        temp = valuesPtr + currentIndex;
        //                        (*temp).f00 = -iValue.f00 * temp1.f00 - iValue.f01 * temp1.f10;
        //                        (*temp).f01 = -iValue.f00 * temp1.f01 - iValue.f01 * temp1.f11;
        //                        (*temp).f10 = -iValue.f10 * temp1.f00 - iValue.f11 * temp1.f10;
        //                        (*temp).f11 = -iValue.f10 * temp1.f01 - iValue.f11 * temp1.f11;
        //                        //if (double.IsNaN((*temp).f11) || double.IsNaN((*temp).f12)
        //                        //    || double.IsNaN((*temp).f21) || double.IsNaN((*temp).f22))
        //                        //    throw new Exception();
        //                        head++;
        //                        break;
        //                    }

        //                }
        //            }
        //        }
        //        // Add new row
        //        int iNewRow = 0;
        //        int[] tempColumns = returnValue.m_Columns[i] = new int[head];
        //        Block2x2[] tempValues = returnValue.m_Values[i] = new Block2x2[head];
        //        returnValue.m_Heads[i] = head;
        //        int num;
        //        Block2x2 diagI = default(Block2x2);
        //        for (int counter = 0; counter != -1; counter = nexts[counter])
        //        {
        //            st10++;
        //            num = tempColumns[iNewRow] = columns[counter];
        //            if (num >= i)
        //            {
        //                if (num > i)
        //                {
        //                    Block2x2 nonDiagI = values[counter];
        //                    nonDiagI.f10 -= diagI.f10 * nonDiagI.f00;
        //                    nonDiagI.f11 -= diagI.f10 * nonDiagI.f01;
        //                    tempValues[iNewRow] = nonDiagI;
        //                }
        //                else
        //                {
        //                    diagI = values[counter];
        //                    diagI.f10 /= diagI.f00;

        //                    diagI.f11 = diagI.f11 - diagI.f10 * diagI.f01;
        //                    tempValues[iNewRow] = diag[i] = diagI;
        //                    //if (double.IsNaN(diagI.f11) || double.IsNaN(diagI.f12) || double.IsNaN(diagI.f21) || double.IsNaN(diagI.f22))
        //                    //    throw new Exception();
        //                    starts[i] = iNewRow;
        //                }
        //            }
        //            else
        //                tempValues[iNewRow] = values[counter];
        //            iNewRow++;
        //        }
        //    }
        //    //Console.WriteLine("st " + st);
        //    //Console.WriteLine("st1 " + st1);
        //    //Console.WriteLine("st2 " + st2);
        //    //Console.WriteLine("st3 " + st3);
        //    //Console.WriteLine("st4 " + st4);
        //    //Console.WriteLine("st5 " + st5);
        //    //Console.WriteLine("st6 " + st6);
        //    //Console.WriteLine("st7 " + st7);
        //    //Console.WriteLine("st8 " + st8);
        //    //Console.WriteLine("st9 " + st9);
        //    //Console.WriteLine("st10 " + st10);
        //    return returnValue;
        //}

        //public static unsafe FCSRMatrix<Block2x2> LuDecompositionBlock(CSRMatrix<Block2x2> a)
        //{
        //    int m = a.m_RowsCount;
        //    int n = a.m_ColumnsCount;
        //    int st = 0, st1 = 0, st2 = 0, st3 = 0, st4 = 0, st5 = 0, st6 = 0, st7 = 0, st8 = 0, st9 = 0, st10 = 0;
        //    FCSRMatrix<Block2x2> returnValue = new FCSRMatrix<Block2x2>(m, n);
        //    Block2x2[] diag = new Block2x2[n];
        //    Block2x2[] values = new Block2x2[n];
        //    int[] columns = new int[n];
        //    int[] starts = new int[m];
        //    int[] nexts = new int[n];
        //    Block2x2* temp;
        //    Block2x2 temp1;
        //    Block2x2 iValue;
        //    double f00, f01, f10, f11;
        //    fixed (int* columnsPtr = columns, nextsPtr = nexts)
        //    fixed (Block2x2* valuesPtr = values)
        //    for (int i = 0; i < m; i++)
        //    {
        //        //   st++;
        //        // Get current row
        //        int index = a.m_RowsMapping[i];
        //        int endIndex = a.m_RowsMapping[i + 1];
        //        int head = 0;
        //        for (; index < endIndex; ++index)
        //        {
        //            //    st1++;
        //            values[head] = a.m_Values[index];
        //            columns[head] = a.m_Columns[index];
        //            nexts[head] = ++head;
        //        }
        //        if (head > 0)
        //            nexts[head - 1] = -1;
        //        // Substract previous rows from current
        //        for (int counter = 0; counter != -1; counter = nexts[counter])
        //        {
        //                st2++;
        //            int ii = columns[counter];
        //            if (ii >= i)
        //                break;
        //               st3++;
        //            temp1 = diag[ii];
        //            temp = valuesPtr + counter;
        //            iValue = *temp;
        //            f00 = (*temp).f00 = iValue.f00 * temp1.f00 + iValue.f01 * temp1.f10;
        //            f01 = (*temp).f01 = iValue.f00 * temp1.f01 + iValue.f01 * temp1.f11;
        //            f10 = (*temp).f10 = iValue.f10 * temp1.f00 + iValue.f11 * temp1.f10;
        //            f11 = (*temp).f11 = iValue.f10 * temp1.f01 + iValue.f11 * temp1.f11;
        //           // iValue = *temp;
        //            // values[counter] = iValue;
        //            int[] columns1 = returnValue.m_Columns[ii];
        //            Block2x2[] values1 = returnValue.m_Values[ii];
        //            int head1 = returnValue.m_Heads[ii];
        //            int columnIndex1;
        //            // Block counterValue;
        //            int currentIndex = counter;
        //            for (int counter1 = starts[ii] + 1; counter1 < head1; ++counter1)
        //            {
        //                columnIndex1 = columns1[counter1];
        //                   st5++;
        //                temp1 = values1[counter1];
        //                int previousIndex, columnIndex;
        //                for (; ; )
        //                {
        //                       st6++;
        //                    previousIndex = currentIndex;
        //                    currentIndex = nextsPtr[previousIndex];
        //                    if (currentIndex == -1)
        //                    {
        //                        currentIndex = head;
        //                        nextsPtr[currentIndex] = -1;
        //                        nextsPtr[previousIndex] = currentIndex;
        //                        columnsPtr[currentIndex] = columnIndex1;
        //                            st7++;
        //                        temp = valuesPtr + currentIndex;
        //                        (*temp).f00 = -f00 * temp1.f00 - f01 * temp1.f10;
        //                        (*temp).f01 = -f00 * temp1.f01 - f01 * temp1.f11;
        //                        (*temp).f10 = -f10 * temp1.f00 - f11 * temp1.f10;
        //                        (*temp).f11 = -f10 * temp1.f01 - f11 * temp1.f11;
        //                        head++;
        //                        break;
        //                    }
        //                    // Get the column index of current element
        //                    columnIndex = columns[currentIndex];
        //                    if (columnIndex == columnIndex1)
        //                    {
        //                        // Set element in current position
        //                            st9++;
        //                        temp = valuesPtr + currentIndex;
        //                        (*temp).f00 -= f00 * temp1.f00 + f01 * temp1.f10;
        //                        (*temp).f01 -= f00 * temp1.f01 + f01 * temp1.f11;
        //                        (*temp).f10 -= f10 * temp1.f00 + f11 * temp1.f10;
        //                        (*temp).f11 -= f10 * temp1.f01 + f11 * temp1.f11;
        //                        break;
        //                    }
        //                    if (columnIndex > columnIndex1)
        //                    {
        //                        currentIndex = head;
        //                        // Reset the row current element
        //                        nextsPtr[currentIndex] = nextsPtr[previousIndex];
        //                        nextsPtr[previousIndex] = currentIndex;
        //                        columnsPtr[currentIndex] = columnIndex1;
        //                              st8++;
        //                        temp = valuesPtr + currentIndex;
        //                        (*temp).f00 = -f00 * temp1.f00 - f01 * temp1.f10;
        //                        (*temp).f01 = -f00 * temp1.f01 - f01 * temp1.f11;
        //                        (*temp).f10 = -f10 * temp1.f00 - f11 * temp1.f10;
        //                        (*temp).f11 = -f10 * temp1.f01 - f11 * temp1.f11;
        //                        head++;
        //                        break;
        //                    }

        //                }
        //            }
        //        }
        //        // Add new row
        //        int iNewRow = 0;
        //        int[] tempColumns = returnValue.m_Columns[i] = new int[head];
        //        Block2x2[] tempValues = returnValue.m_Values[i] = new Block2x2[head];
        //        returnValue.m_Heads[i] = head;
        //        int num;
        //        for (int counter = 0; counter != -1; counter = nexts[counter])
        //        {
        //            st10++;
        //            num = tempColumns[iNewRow] = columns[counter];
        //            if (num == i)
        //            {
        //                diag[i] = values[counter].Inverse();
        //                starts[i] = iNewRow;
        //            }
        //            tempValues[iNewRow] = values[counter];
        //            iNewRow++;
        //        }
        //    }
        //    //Console.WriteLine("st " + st);
        //    //Console.WriteLine("st1 " + st1);
        //    Console.WriteLine("st2 " + st2);
        //    Console.WriteLine("st3 " + st3);
        //    //Console.WriteLine("st4 " + st4);
        //    Console.WriteLine("st5 " + st5);
        //    Console.WriteLine("st6 " + st6);
        //    Console.WriteLine("st7 " + st7);
        //    Console.WriteLine("st8 " + st8);
        //    Console.WriteLine("st9 " + st9);
        //    //Console.WriteLine("st10 " + st10);
        //    return returnValue;
        //}
        //public static unsafe FCSRMatrix<Block2x2> LuDecompositionBlockTest(CSRMatrix<Block2x2> a)
        //{
        //    int m = a.m_RowsCount;
        //    int n = a.m_ColumnsCount;
        //    int st = 0, st1 = 0, st2 = 0, st3 = 0, st4 = 0, st5 = 0, st6 = 0, st7 = 0, st8 = 0, st9 = 0, st10 = 0;
        //    FCSRMatrix<Block2x2> returnValue = new FCSRMatrix<Block2x2>(m, n);
        //    Block2x2[] diag = new Block2x2[n];
        //    Block2x2[] values = new Block2x2[n];
        //    int[] columns = new int[n];
        //    int[] starts = new int[m];
        //    int[] nexts = new int[n];
        //    Block2x2* temp;
        //    Block2x2 temp1;
        //    Block2x2 temp2;
        //    double f00, f01, f10, f11;
        //    fixed (int* columnsPtr = columns, nextsPtr = nexts)
        //    fixed (Block2x2* valuesPtr = values)
        //    for (int i = 0; i < m; i++)
        //    {
        //        //   st++;
        //        // Get current row
        //        int index = a.m_RowsMapping[i];
        //        int endIndex = a.m_RowsMapping[i + 1];
        //        int head = 0;
        //        for (; index < endIndex; ++index)
        //        {
        //            //    st1++;
        //            values[head] = a.m_Values[index];
        //            columns[head] = a.m_Columns[index];
        //            nexts[head] = ++head;
        //        }
        //        if (head > 0)
        //            nexts[head - 1] = -1;
        //        // Substract previous rows from current
        //        for (int counter = 0; counter != -1; counter = nexts[counter])
        //        {
        //           //     st2++;
        //            int ii = columns[counter];
        //            if (ii >= i)
        //                break;
        //           //     st3++;
        //            temp1 = diag[ii];
        //            temp = valuesPtr + counter;
        //            temp2 = *temp;
        //            f00 = temp->f00 = -temp2.f00 * temp1.f00 - temp2.f01 * temp1.f10;
        //            f01 = temp->f01 = -temp2.f00 * temp1.f01 - temp2.f01 * temp1.f11;
        //            f10 = temp->f10 = -temp2.f10 * temp1.f00 - temp2.f11 * temp1.f10;
        //            f11 = temp->f11 = -temp2.f10 * temp1.f01 - temp2.f11 * temp1.f11;
        //            int[] iiColumns = returnValue.m_Columns[ii];
        //            Block2x2[] iiValues = returnValue.m_Values[ii];
        //            int iiHead = returnValue.m_Heads[ii];
        //            int columnIndex1;
        //            // Block counterValue;
        //            int currentIndex = counter;
        //            for (int counter1 = starts[ii]; counter1 < iiHead; ++counter1)
        //            {
        //                columnIndex1 = iiColumns[counter1];
        //                   // st5++;
        //                temp1 = iiValues[counter1];
        //                int previousIndex, columnIndex;
        //                for (; ; )
        //                {
        //                  //  st6++;
        //                    previousIndex = currentIndex;
        //                    currentIndex = nextsPtr[previousIndex];
        //                    if (currentIndex == -1)
        //                    {
        //                        currentIndex = head;
        //                        nextsPtr[currentIndex] = -1;
        //                        nextsPtr[previousIndex] = currentIndex;
        //                        columnsPtr[currentIndex] = columnIndex1;
        //                       //     st7++;
        //                        temp = valuesPtr + currentIndex;
        //                        temp->f00 = f00 * temp1.f00 + f01 * temp1.f10;
        //                        temp->f01 = f00 * temp1.f01 + f01 * temp1.f11;
        //                        temp->f10 = f10 * temp1.f00 + f11 * temp1.f10;
        //                        temp->f11 = f10 * temp1.f01 + f11 * temp1.f11;
        //                        head++;
        //                        break;
        //                    }
        //                    // Get the column index of current element
        //                    columnIndex = columnsPtr[currentIndex];
        //                    if (columnIndex == columnIndex1)
        //                    {
        //                        // Set element in current position
        //                       //     st9++;
        //                        temp = valuesPtr + currentIndex;
        //                        temp->f00 += f00 * temp1.f00 + f01 * temp1.f10;
        //                        temp->f01 += f00 * temp1.f01 + f01 * temp1.f11;
        //                        temp->f10 += f10 * temp1.f00 + f11 * temp1.f10;
        //                        temp->f11 += f10 * temp1.f01 + f11 * temp1.f11;
        //                        break;
        //                    }
        //                    if (columnIndex > columnIndex1)
        //                    {
        //                        currentIndex = head;
        //                        // Reset the row current element
        //                        nextsPtr[currentIndex] = nextsPtr[previousIndex];
        //                        nextsPtr[previousIndex] = currentIndex;
        //                        columnsPtr[currentIndex] = columnIndex1;
        //                //                st8++;
        //                        temp = valuesPtr + currentIndex;
        //                        temp->f00 = f00 * temp1.f00 + f01 * temp1.f10;
        //                        temp->f01 = f00 * temp1.f01 + f01 * temp1.f11;
        //                        temp->f10 = f10 * temp1.f00 + f11 * temp1.f10;
        //                        temp->f11 = f10 * temp1.f01 + f11 * temp1.f11;
        //                        head++;
        //                        break;
        //                    }
        //                }
        //            }
        //        }
        //        // Add new row
        //        int iNewRow = 0;
        //        int[] tempColumns = returnValue.m_Columns[i] = new int[head];
        //        Block2x2[] tempValues = returnValue.m_Values[i] = new Block2x2[head];
        //        returnValue.m_Heads[i] = head;
        //        int num;
        //        temp1 = default(Block2x2);
        //        for (int counter = 0; counter != -1; counter = nexts[counter])
        //        {
        //            st4++;
        //            num = tempColumns[iNewRow] = columns[counter];
        //            if (num >= i)
        //            {
        //                if (num > i)
        //                    tempValues[iNewRow] = -(temp1 * values[counter]);
        //                else
        //                {
        //                    temp1 = values[counter];
        //                    double det = temp1.f00 * temp1.f11 - temp1.f01 * temp1.f10;
        //                    temp1.f00 = temp1.f11 * det;
        //                    temp1.f01 = -temp1.f01 * det;
        //                    temp1.f10 = -temp1.f10 * det;
        //                    temp1.f11 = temp1.f00 * det;
        //                    tempValues[iNewRow] = diag[i] = temp1;
        //                    starts[i] = iNewRow + 1;
        //                }
        //            }
        //            else
        //                tempValues[iNewRow] = values[counter];
        //            iNewRow++;
        //        }
        //    }
        //    //Console.WriteLine("st " + st);
        //    //Console.WriteLine("st1 " + st1);
        //    //Console.WriteLine("st2 " + st2);
        //    //Console.WriteLine("st3 " + st3);
        //    //Console.WriteLine("st4 " + st4);
        //    //Console.WriteLine("st5 " + st5);
        //    //Console.WriteLine("st6 " + st6);
        //    //Console.WriteLine("st7 " + st7);
        //    //Console.WriteLine("st8 " + st8);
        //    //Console.WriteLine("st9 " + st9);
        //    ////Console.WriteLine("st10 " + st10);
        //    return returnValue;
        //}
        //public static unsafe FCSRMatrix<Block2x2> LuDecompositionBlockTest1(CSRMatrix<Block2x2> a)
        //{
        //    int m = a.m_RowsCount;
        //    int n = a.m_ColumnsCount;
        //    int st = 0, st1 = 0, st2 = 0, st3 = 0, st4 = 0, st5 = 0, st6 = 0, st7 = 0, st8 = 0, st9 = 0, st10 = 0;
        //    FCSRMatrix<Block2x2> returnValue = new FCSRMatrix<Block2x2>(m, n);
        //    Block2x2[] diag = new Block2x2[n];
        //    Block2x2[] values = new Block2x2[n];
        //    int[] columns = new int[n];
        //    int[] starts = new int[m];
        //    int[] nexts = new int[n];
        //    Block2x2* temp;
        //    Block2x2 temp1;
        //    Block2x2 temp2;
        //    double f00, f01, f10, f11;
        //    fixed (int* columnsPtr = columns, nextsPtr = nexts)
        //    fixed (Block2x2* valuesPtr = values)
        //    for (int i = 0; i < m; i++)
        //    {
        //        //   st++;
        //        // Get current row
        //        int index = a.m_RowsMapping[i];
        //        int endIndex = a.m_RowsMapping[i + 1];
        //        int head = 0;
        //        for (; index < endIndex; ++index)
        //        {
        //            //    st1++;
        //            values[head] = a.m_Values[index];
        //            columns[head] = a.m_Columns[index];
        //            nexts[head] = ++head;
        //        }
        //        if (head > 0)
        //            nexts[head - 1] = -1;
        //        // Substract previous rows from current
        //        for (int counter = 0; counter != -1; counter = nexts[counter])
        //        {
        //                // st2++;
        //            int ii = columns[counter];
        //            if (ii >= i)
        //                break;
        //                 //st3++;
        //            temp1 = diag[ii];
        //            temp = valuesPtr + counter;
        //            temp2 = *temp;
        //            f00 = temp->f00 = temp2.f00 * temp1.f00 + temp2.f01 * temp1.f10;
        //            f01 = temp->f01 = temp2.f00 * temp1.f01 + temp2.f01 * temp1.f11;
        //            f10 = temp->f10 = temp2.f10 * temp1.f00 + temp2.f11 * temp1.f10;
        //            f11 = temp->f11 = temp2.f10 * temp1.f01 + temp2.f11 * temp1.f11;
        //            int[] iiColumns = returnValue.m_Columns[ii];
        //            Block2x2[] iiValues = returnValue.m_Values[ii];
        //            int iiHead = returnValue.m_Heads[ii];
        //            int columnIndex1;
        //            // Block counterValue;
        //            int currentIndex = counter;
        //            for (int counter1 = starts[ii]; counter1 < iiHead; ++counter1)
        //            {
        //                columnIndex1 = iiColumns[counter1];
        //                 st5++;
        //                temp1 = iiValues[counter1];
        //                int previousIndex, columnIndex;
        //                for (; ; )
        //                {
        //              //        st6++;
        //                    previousIndex = currentIndex;
        //                    currentIndex = nextsPtr[previousIndex];
        //                    if (currentIndex == -1)
        //                    {
        //                        currentIndex = head;
        //                        nextsPtr[currentIndex] = -1;
        //                        nextsPtr[previousIndex] = currentIndex;
        //                        columnsPtr[currentIndex] = columnIndex1;
        //                       //      st7++;
        //                        temp = valuesPtr + currentIndex;
        //                        temp->f00 = -f00 * temp1.f00 - f01 * temp1.f10;
        //                        temp->f01 = -f00 * temp1.f01 - f01 * temp1.f11;
        //                        temp->f10 = -f10 * temp1.f00 - f11 * temp1.f10;
        //                        temp->f11 = -f10 * temp1.f01 - f11 * temp1.f11;
        //                        head++;
        //                        break;
        //                    }
        //                    // Get the column index of current element
        //                    columnIndex = columnsPtr[currentIndex];
        //                    if (columnIndex == columnIndex1)
        //                    {
        //                        // Set element in current position
        //            //                 st9++;
        //                        temp = valuesPtr + currentIndex;
        //                        temp->f00 -= (f00 * temp1.f00 + f01 * temp1.f10);
        //                        temp->f01 -= (f00 * temp1.f01 + f01 * temp1.f11);
        //                        temp->f10 -= (f10 * temp1.f00 + f11 * temp1.f10);
        //                        temp->f11 -= (f10 * temp1.f01 + f11 * temp1.f11);
        //                        break;
        //                    }
        //                    if (columnIndex > columnIndex1)
        //                    {
        //                        currentIndex = head;
        //                        // Reset the row current element
        //                        nextsPtr[currentIndex] = nextsPtr[previousIndex];
        //                        nextsPtr[previousIndex] = currentIndex;
        //                        columnsPtr[currentIndex] = columnIndex1;
        //              //                          st8++;
        //                        temp = valuesPtr + currentIndex;
        //                        temp->f00 = -f00 * temp1.f00 - f01 * temp1.f10;
        //                        temp->f01 = -f00 * temp1.f01 - f01 * temp1.f11;
        //                        temp->f10 = -f10 * temp1.f00 - f11 * temp1.f10;
        //                        temp->f11 = -f10 * temp1.f01 - f11 * temp1.f11;
        //                        head++;
        //                        break;
        //                    }
        //                }
        //            }
        //        }
        //        // Add new row
        //        int iNewRow = 0;
        //        int[] tempColumns = returnValue.m_Columns[i] = new int[head];
        //        Block2x2[] tempValues = returnValue.m_Values[i] = new Block2x2[head];
        //        returnValue.m_Heads[i] = head;
        //        int num;
        //        temp1 = default(Block2x2);
        //        for (int counter = 0; counter != -1; counter = nexts[counter])
        //        {
        //            //st4++;
        //            num = tempColumns[iNewRow] = columns[counter];
        //            if (num == i)
        //            {
        //                temp1 = values[counter];
        //                double det = 1/(temp1.f00 * temp1.f11 - temp1.f01 * temp1.f10);
        //                diag[i].f00 = temp1.f11 * det;
        //                diag[i].f01 = -temp1.f01 * det;
        //                diag[i].f10 = -temp1.f10 * det;
        //                diag[i].f11 = temp1.f00 * det;
        //                starts[i] = iNewRow + 1;
        //            }
        //            tempValues[iNewRow] = values[counter];
        //            iNewRow++;
        //        }
        //    }
        //    //Console.WriteLine("st " + st);
        //    //Console.WriteLine("st1 " + st1);
        //    //Console.WriteLine("st2 " + st2);
        //    //Console.WriteLine("st3 " + st3);
        //    //Console.WriteLine("st4 " + st4);
        //    //Console.WriteLine("st5 " + st5);
        //    //Console.WriteLine("st6 " + st6);
        //    //Console.WriteLine("st7 " + st7);
        //    //Console.WriteLine("st8 " + st8);
        //    //Console.WriteLine("st9 " + st9);
        //    //////Console.WriteLine("st10 " + st10);
        //    return returnValue;
        //}

        //unsafe public static CSRMatrix<Block2x2> Convert(FCSRMatrix<Block2x2> value)
        //{
        //    int m = value.m_RowCount;
        //    int n = value.m_ColumnCount;
        //    int all = 0;
        //    for (int i = 0; i < m; ++i)
        //        all += value.m_Heads[i];
        //    CSRMatrix<Block2x2> returnValue = new CSRMatrix<Block2x2>(all, m, n);
        //    Block2x2[] retValues = returnValue.m_Values;
        //    int[] retColumns = returnValue.m_Columns;
        //    int[] retRowIndexes = returnValue.m_RowsMapping;
        //    int niw = 0;
        //    for (int i = 0; i < m; ++i)
        //    {
        //        retRowIndexes[i] = niw;
        //        int[] tempColumns = value.m_Columns[i];
        //        Block2x2[] tempValues = value.m_Values[i];
        //        for (int j = 0; j < tempColumns.Length; ++j)
        //        {
        //            retValues[niw] = tempValues[j];
        //            retColumns[niw] = tempColumns[j];
        //            niw++;
        //        }
        //    }
        //    retRowIndexes[retRowIndexes.Length - 1] = niw;
        //    return returnValue;
        //}
        //public static unsafe FCSRMatrix<Block2x2> LuDecomposition(CSRMatrix<Block2x2> a)
        //{
        //    int m = a.m_RowsCount;
        //    int n = a.m_ColumnsCount;
        //    int st = 0, st1 = 0, st2 = 0, st3 = 0, st4 = 0, st5 = 0, st6 = 0, st7 = 0, st8 = 0, st9 = 0, st10 = 0;
        //    FCSRMatrix<Block2x2> returnValue = new FCSRMatrix<Block2x2>(m, n);
        //    Block2x2[] diag = new Block2x2[n];
        //    double f11, f12, f21, f22;
        //    Block2x2[] values = new Block2x2[n];
        //    int[] columns = new int[n];
        //    int[] nexts = new int[n];
        //    double* temp;
        //    Block2x2 temp1;
        //    Block2x2 kiValue;
        //    fixed (int* columnsPtr = columns, nextsPtr = nexts)
        //    fixed (Block2x2* valuesPtr1 = values)
        //        for (int i = 0; i < m; i++)
        //        {
        //            double* valuesPtr = (double*)valuesPtr1;
        //            //   st++;
        //            // Get current row
        //            int index = a.m_RowsMapping[i];
        //            int endIndex = a.m_RowsMapping[i + 1];
        //            int start = 0;
        //            int head = 0;
        //            for (; index < endIndex; ++index)
        //            {
        //                //    st1++;
        //                values[head] = a.m_Values[index];
        //                columns[head] = a.m_Columns[index];
        //                nexts[head] = ++head;
        //            }
        //            if (head > 0)
        //                nexts[head - 1] = -1;
        //            // Substract previous rows from current

        //            for (int counter = start; counter != -1; counter = nexts[counter])
        //            {
        //                //    st2++;
        //                int ii = columns[counter];
        //                if (ii >= i)
        //                    break;
        //                //   st3++;
        //                temp1 = diag[ii];
        //                kiValue = values[counter];
        //                kiValue.f00 /= temp1.f00;
        //                kiValue.f10 /= temp1.f00;
        //                kiValue.f01 -= kiValue.f00 * temp1.f01;
        //                kiValue.f11 -= kiValue.f10 * temp1.f01;
        //                kiValue.f01 /= temp1.f11;
        //                kiValue.f11 /= temp1.f11;
        //                values[counter] = kiValue;
        //                int[] columns1 = returnValue.m_Columns[ii];
        //                Block2x2[] values1 = returnValue.m_Values[ii];
        //                int head1 = returnValue.m_Heads[ii];
        //                int columnIndex1;
        //                // Block counterValue;
        //                int currentIndex = counter;
        //                for (int counter1 = 0; counter1 < head1; ++counter1)
        //                {
        //                    //  st4++;
        //                    columnIndex1 = columns1[counter1];
        //                    if (columnIndex1 <= ii)
        //                        continue;
        //                    //  st5++;
        //                    // counterValue = values[counter1];
        //                    temp1 = values1[counter1];
        //                    //f11 = -kiValue.f11 * temp1.f11 - kiValue.f12 * temp1.f21;
        //                    //f12 = -kiValue.f11 * temp1.f12 - kiValue.f12 * temp1.f22;
        //                    //f21 = -kiValue.f21 * temp1.f11 - kiValue.f22 * temp1.f21;
        //                    //f22 = -kiValue.f21 * temp1.f12 - kiValue.f22 * temp1.f22;
        //                    int previousIndex, columnIndex;
        //                    for (; ; )
        //                    {
        //                      //  st6++;
        //                        previousIndex = currentIndex;
        //                        currentIndex = *(nextsPtr + previousIndex);
        //                        if (currentIndex == -1)
        //                        {
        //                            currentIndex = head;
        //                            *(nextsPtr + currentIndex) = -1;
        //                            *(nextsPtr + previousIndex) = currentIndex;
        //                            *(columnsPtr + currentIndex) = columnIndex1;
        //                            //st7++;
        //                            temp = (double*)(valuesPtr1 + currentIndex);
        //                            //*temp = f11;
        //                            //*(temp + 1) = f12;
        //                            //*(temp + 2) = f21;
        //                            //*(temp + 3) = f22;
        //                            *temp = -kiValue.f00 * temp1.f00 - kiValue.f01 * temp1.f10;
        //                            *(temp + 1) = -kiValue.f00 * temp1.f01 - kiValue.f01 * temp1.f11;
        //                            *(temp + 2) = -kiValue.f10 * temp1.f00 - kiValue.f11 * temp1.f10;
        //                            *(temp + 3) = -kiValue.f10 * temp1.f01 - kiValue.f11 * temp1.f11;
        //                            head++;

        //                            break;
        //                        }
        //                        // Get the column index of current element
        //                        columnIndex = columns[currentIndex];
        //                        if (columnIndex == columnIndex1)
        //                        {
        //                            // Set element in current position
        //                            // st9++;
        //                            temp = (double*)(valuesPtr1 + currentIndex);
        //                            //*temp += f11;
        //                            //*(temp + 1) += f12;
        //                            //*(temp + 2) += f21;
        //                            //*(temp + 3) += f22;
        //                            *temp -= kiValue.f00 * temp1.f00 + kiValue.f01 * temp1.f10;
        //                            *(temp + 1) -= kiValue.f00 * temp1.f01 + kiValue.f01 * temp1.f11;
        //                            *(temp + 2) -= kiValue.f10 * temp1.f00 + kiValue.f11 * temp1.f10;
        //                            *(temp + 3) -= kiValue.f10 * temp1.f01 + kiValue.f11 * temp1.f11;
        //                            break;
        //                        }
        //                        if (columnIndex > columnIndex1)
        //                        {
        //                            currentIndex = head;
        //                            // Reset the row current element
        //                            *(nextsPtr + currentIndex) = *(nextsPtr + previousIndex);
        //                            *(nextsPtr + previousIndex) = currentIndex;
        //                            *(columnsPtr + currentIndex) = columnIndex1;

        //                            //  st8++;
        //                            temp = (double*)(valuesPtr1 + currentIndex);
        //                            //*temp = f11;
        //                            //*(temp + 1) = f12;
        //                            //*(temp + 2) = f21;
        //                            //*(temp + 3) = f22;

        //                            *temp = -kiValue.f00 * temp1.f00 - kiValue.f01 * temp1.f10;
        //                            *(temp + 1) = -kiValue.f00 * temp1.f01 - kiValue.f01 * temp1.f11;
        //                            *(temp + 2) = -kiValue.f10 * temp1.f00 - kiValue.f11 * temp1.f10;
        //                            *(temp + 3) = -kiValue.f10 * temp1.f01 - kiValue.f11 * temp1.f11;
                                    
        //                            head++;
        //                            break;
        //                        }

        //                    }
        //                }
        //            }
        //            // Add new row
        //            int l = 0;
        //            int[] tempColumns = returnValue.m_Columns[i] = new int[head];
        //            Block2x2[] tempValues = returnValue.m_Values[i] = new Block2x2[head];
        //            returnValue.m_Heads[i] = head;
        //            int num;
        //            Block2x2 diagI = default(Block2x2);
        //            for (int counter = start; counter != -1; counter = nexts[counter])
        //            {
        //                st10++;
        //                num = tempColumns[l] = columns[counter];
        //                if (num >= i)
        //                {
        //                    if (num > i)
        //                    {
        //                        Block2x2 nonDiagI = values[counter];
        //                        nonDiagI.f10 -= diagI.f10 * nonDiagI.f00;
        //                        nonDiagI.f11 -= diagI.f10 * nonDiagI.f01;
        //                        tempValues[l] = nonDiagI;
        //                    }
        //                    else
        //                    {
        //                        diagI = values[counter];
        //                        diagI.f10 /= diagI.f00;
        //                        diagI.f11 = diagI.f11 - diagI.f10 * diagI.f01;
        //                        tempValues[l] = diag[i] = diagI;
        //                    }
        //                }
        //                else
        //                    tempValues[l] = values[counter];
        //                l++;
        //            }
        //        }
        //    //Console.WriteLine("st " + st);
        //    //Console.WriteLine("st1 " + st1);
        //    //Console.WriteLine("st2 " + st2);
        //    //Console.WriteLine("st3 " + st3);
        //    //Console.WriteLine("st4 " + st4);
        //    //Console.WriteLine("st5 " + st5);
        //  //  Console.WriteLine("st6 " + st6);
        //    //Console.WriteLine("st7 " + st7);
        //    //Console.WriteLine("st8 " + st8);
        //    //Console.WriteLine("st9 " + st9);
        //    //Console.WriteLine("st10 " + st10);
        //    return returnValue;
        //}
        //public static unsafe FCSRMatrix<Block2x2> LuDecompositionOld1(CSRMatrix<Block2x2> a)
        //{
        //    int m = a.m_RowsCount;
        //    int n = a.m_ColumnsCount;
        //    int st = 0, st1 = 0, st2 = 0, st3 = 0, st4 = 0, st5 = 0, st6 = 0, st7 = 0, st8 = 0, st9 = 0, st10 = 0;
        //    FCSRMatrix<Block2x2> returnValue = new FCSRMatrix<Block2x2>(m, n);
        //    Block2x2[] diag = new Block2x2[n];
        //    double f11, f12, f21, f22;
        //    Block2x2[] values = new Block2x2[n];
        //    int[] columns = new int[n];
        //    int[] nexts = new int[n];
        //    double* temp;
        //    Block2x2 temp1;
        //    fixed (int* columnsPtr = columns, nextsPtr = nexts)
        //    fixed (Block2x2* valuesPtr1 = values)
        //    for (int i = 0; i < m; i++)
        //    {
        //        double* valuesPtr = (double*)valuesPtr1;
        //     //   st++;
        //        // Get current row
        //        int index = a.m_RowsMapping[i];
        //        int endIndex = a.m_RowsMapping[i + 1];
        //        int start = 0;
        //        int head = 0;
        //        for (; index < endIndex; ++index)
        //        {
        //        //    st1++;
        //            values[head] = a.m_Values[index];
        //            columns[head] = a.m_Columns[index];
        //            nexts[head] = ++head;
        //        }
        //        if (head > 0)
        //            nexts[head - 1] = -1;
        //        // Substract previous rows from current
                
        //        for (int counter = start; counter != -1; counter = nexts[counter])
        //        {
        //        //    st2++;
        //            int ii = columns[counter];
        //            if (ii >= i)
        //                break;
        //         //   st3++;
        //            Block2x2 kiValue = values[counter] *= diag[ii].Inverse();
        //            int[] columns1 = returnValue.m_Columns[ii];
        //            Block2x2[] values1 = returnValue.m_Values[ii];
        //            int head1 = returnValue.m_Heads[ii];
        //            int columnIndex1;
        //           // Block counterValue;
        //            int currentIndex = counter;
        //            for (int counter1 = 0; counter1 < head1; ++counter1)
        //            {
        //              //  st4++;
        //                columnIndex1 = columns1[counter1];
        //                if (columnIndex1 <= ii)
        //                    continue;
        //              //  st5++;
        //               // counterValue = values[counter1];
        //                temp1 = values1[counter1];
        //                f11 = -kiValue.f00 * temp1.f00 - kiValue.f01 * temp1.f10;
        //                f12 = -kiValue.f00 * temp1.f01 - kiValue.f01 * temp1.f11;
        //                f21 = -kiValue.f10 * temp1.f00 - kiValue.f11 * temp1.f10;
        //                f22 = -kiValue.f10 * temp1.f01 - kiValue.f11 * temp1.f11;      
        //                int previousIndex, columnIndex;
        //                for (; ; )
        //                {
        //                    st6++;
        //                    previousIndex = currentIndex;
        //                    currentIndex = *(nextsPtr + previousIndex);
        //                    if (currentIndex == -1)
        //                    {
        //                        currentIndex = head;
        //                        *(nextsPtr + currentIndex) = -1;
        //                        *(nextsPtr + previousIndex) = currentIndex;
        //                        *(columnsPtr + currentIndex) = columnIndex1;
        //                        //st7++;
        //                        temp = (double*)(valuesPtr1 + currentIndex);
        //                        *temp = f11;
        //                        *(temp + 1) = f12;
        //                        *(temp + 2) = f21;
        //                        *(temp + 3) = f22;
        //                        head++;

        //                        break;
        //                    }
        //                    // Get the column index of current element
        //                    columnIndex = columns[currentIndex];
        //                    if (columnIndex == columnIndex1)
        //                    {
        //                        // Set element in current position
        //                       // st9++;
        //                        temp = (double*)(valuesPtr1 + currentIndex);
        //                        *temp += f11;
        //                        *(temp + 1) += f12;
        //                        *(temp + 2) += f21;
        //                        *(temp + 3) += f22;

        //                        break;
        //                    }
        //                    if (columnIndex > columnIndex1)
        //                    {
        //                        currentIndex = head;
        //                        // Reset the row current element
        //                        *(nextsPtr + currentIndex) = *(nextsPtr + previousIndex);
        //                        *(nextsPtr + previousIndex) = currentIndex;
        //                        *(columnsPtr + currentIndex) = columnIndex1;
                                
        //                      //  st8++;
        //                        temp = (double*)(valuesPtr1 + currentIndex);
        //                        *temp = f11;
        //                        *(temp + 1) = f12;
        //                        *(temp + 2) = f21;
        //                        *(temp + 3) = f22;
        //                        head++;
        //                        break;
        //                    }

        //                }
        //            }
        //        }
        //        // Add new row
        //        int l = 0;
        //        int[] tempColumns = returnValue.m_Columns[i] = new int[head];
        //        Block2x2[] tempValues = returnValue.m_Values[i] = new Block2x2[head];
        //        returnValue.m_Heads[i] = head;
        //        int num;
        //        for (int counter = start; counter != -1; counter = nexts[counter])
        //        {
        //            st10++;
        //            num = tempColumns[l] = columns[counter];
        //            tempValues[l] = values[counter];
        //            if (num == i)
        //                diag[i] = values[counter];
        //            l++;
        //        }
        //    }
        //    //Console.WriteLine("st " + st);
        //    //Console.WriteLine("st1 " + st1);
        //    //Console.WriteLine("st2 " + st2);
        //    //Console.WriteLine("st3 " + st3);
        //    //Console.WriteLine("st4 " + st4);
        //    //Console.WriteLine("st5 " + st5);
        //    Console.WriteLine("st6 " + st6);
        //    //Console.WriteLine("st7 " + st7);
        //    //Console.WriteLine("st8 " + st8);
        //    //Console.WriteLine("st9 " + st9);
        //    //Console.WriteLine("st10 " + st10);
        //    return returnValue;
        //}
        
        //public static FCSRMatrix<Block2x2> LuDecompositionOld(CSRMatrix<Block2x2> a)
        //{
        //    int m = a.m_RowsCount;
        //    int st = 0;
        //    int n = a.m_ColumnsCount;
        //    FCSRMatrix<Block2x2> returnValue = new FCSRMatrix<Block2x2>(m, n);
        //    Block2x2[] diag = new Block2x2[n];
        //    for (int i = 0; i < m; i++)
        //    {
        //        // Get current row
        //        Block2x2[] row = new Block2x2[n];
        //        int index = a.m_RowsMapping[i];
        //        int endIndex = a.m_RowsMapping[i + 1];
        //        for (; index < endIndex; ++index)
        //            row[a.m_Columns[index]] = a.m_Values[index];
        //        // Substract previous rows from current
        //        for (int ii = 0; ii < i; ++ii)
        //        {
        //            if (row[ii].f00 == 0 && row[ii].f01 == 0 && row[ii].f10 == 0 && row[ii].f11 == 0)
        //                continue;
        //            Block2x2 kiValue = row[ii] *= diag[ii].Inverse();
        //            int[] indexes = returnValue.m_Columns[ii];
        //            Block2x2[] values = returnValue.m_Values[ii];
        //            int columnIndex;
        //            Block2x2 counterValue;
        //            for (int counter = 0; counter < returnValue.m_Heads[ii]; ++counter)
        //            {
        //                columnIndex = indexes[counter];
        //                if (columnIndex > ii)
        //                {
        //                    st++;
        //                    counterValue = values[counter];
        //                    Block2x2 temp = row[columnIndex];
        //                    temp.f00 =  temp.f00 - kiValue.f00 * counterValue.f00 - kiValue.f01 * counterValue.f10;
        //                    temp.f01 =  temp.f01 - kiValue.f00 * counterValue.f01 - kiValue.f01 * counterValue.f11;
        //                    temp.f10 =  temp.f10 - kiValue.f10 * counterValue.f00 - kiValue.f11 * counterValue.f10;
        //                    temp.f11 =  temp.f11 - kiValue.f10 * counterValue.f01 - kiValue.f11 * counterValue.f11;
        //                    row[columnIndex] = temp;
        //                }
        //            }
        //        }
        //        diag[i] = row[i];
                
        //        // Add new row
        //        int l = 0;
        //        int[] columns = new int[n];
        //        for (int j = 0; j < n; j++)
        //        {
        //            if (row[j].f00 != 0 || row[j].f01 != 0 || row[j].f10 != 0 || row[j].f11 != 0)
        //            {
        //                row[l] = row[j];
        //                columns[l] = j;
        //                l++;
        //            }
        //        }
        //        if (l > 0)
        //        {
        //            if (l < n)
        //            {
        //                int[] tempColumns = new int[l];
        //                Block2x2[] tempValues = new Block2x2[l];
        //                Array.Copy(columns, tempColumns, l);
        //                Array.Copy(row, tempValues, l);
        //                columns = tempColumns;
        //                row = tempValues;
        //            }
        //            returnValue.m_Columns[i] = columns;
        //            returnValue.m_Values[i] = row;
        //            returnValue.m_Heads[i] = l;
        //        }
        //        //returnValue.AddRow(row);
        //    }
        //    Console.WriteLine(st);
        //    return returnValue;
        //}
        //public static FullMatrix<double> LuSolve(FCSRMatrix<double> factorA, FullMatrix<double> b)
        //{
        //    int m = factorA.m_RowCount;
        //    int n = factorA.m_ColumnCount;
        //    int nx = b.m_ColumnsCount;

        //    if (b.m_RowsCount != m)
        //        throw new ArgumentException("Matrix row dimensions must agree.");
        //    //if (!IsNonSingular)
        //    //    throw new SystemException("Matrix is singular.");
            
        //    // Copy right hand side with pivoting
        //    FullMatrix<double> y = new FullMatrix<double>(b);
        //    int[] diagonalIndexes = new int[n];
        //    // Solve L*Y = B(piv,:)
        //    for (int i = 0; i < n; ++i)
        //    {
        //        int[] indexes = factorA.m_Columns[i];
        //        double[] values = factorA.m_Values[i];
        //        int columnIndex;
        //        for (int ii = 0; ii < factorA.m_Heads[i]; ++ii)
        //        {
        //            columnIndex = indexes[ii];
        //            if (columnIndex >= i)
        //            {
        //                if (columnIndex == i)
        //                    diagonalIndexes[i] = ii;
        //                else
        //                    return null;
        //                break;
        //            }
        //            for (int j = 0; j < nx; ++j)
        //                y[i, j] -= y[columnIndex, j] * values[ii];
        //        }
        //        for (int j = 0; j < nx; j++)
        //            y[i, j] /= values[diagonalIndexes[i]];
                
        //    }
        //    // Solve U*X = Y;
        //    for (int i = n - 1; i >= 0; --i)
        //    {
        //        int[] indexes = factorA.m_Columns[i];
        //        double[] values = factorA.m_Values[i];
        //        int columnIndex;
        //        for (int ii = diagonalIndexes[i] + 1; ii < factorA.m_Heads[i]; ++ii)
        //        {
        //            columnIndex = indexes[ii];
        //            for (int j = 0; j < nx; j++)
        //                y[i, j] -= y[columnIndex, j] * values[ii];
        //        }
        //    }
        //    return y;
        //}
        //public static FullMatrix<Block2x2> LuSolve(FCSRMatrix<Block2x2> factorA, FullMatrix<Block2x2> b)
        //{
        //    int m = factorA.m_RowCount;
        //    int n = factorA.m_ColumnCount;
        //    int nx = b.m_ColumnsCount;

        //    if (b.m_RowsCount != m)
        //        throw new ArgumentException("Matrix row dimensions must agree.");
        //    // Copy right hand side with pivoting
        //    FullMatrix<Block2x2> y = new FullMatrix<Block2x2>(b);
        //    int[] diagonalIndexes = new int[n];
        //    // Solve L*Y = B(piv,:)
        //    for (int i = 0; i < n; ++i)
        //    {
        //        int[] indexes = factorA.m_Columns[i];
        //        Block2x2[] values = factorA.m_Values[i];
        //        int columnIndex;
        //        for (int ii = 0; ii < factorA.m_Heads[i]; ++ii)
        //        {
        //            columnIndex = indexes[ii];
        //            if (columnIndex >= i)
        //            {
        //                if (columnIndex == i)
        //                    diagonalIndexes[i] = ii;
        //                else
        //                    return null;
        //                break;
        //            }
        //            for (int j = 0; j < nx; ++j)
        //                y[i, j] -= values[ii] * y[columnIndex, j];
        //        }
        //    }

        //    //// Solve U*X = Y;
        //    //for (int k = n - 1; k >= 0; k--)
        //    //{
        //    //    X[k] /= LU[k][k];
        //    //    for (int i = 0; i < k; i++)
        //    //    {
        //    //            X[i] -= X[k] * LU[i][k];
        //    //    }
        //    //}

        //    // Solve U*X = Y;
        //    for (int k = n - 1; k >= 0; --k)
        //    {
        //        int[] indexes = factorA.m_Columns[k];
        //        Block2x2[] values = factorA.m_Values[k];
        //        Block2x2 val = values[diagonalIndexes[k]].Inverse();
        //        //for (int j = 0; j < nx; j++)
        //        //    y[k, j] *= val;
        //        //for (int i = 0; i < k; i++)
        //        //{
        //        //    for (int j = 0; j < nx; j++)
        //        //    {
        //        //        y[i, j] -= y[k, j] * factorA[i, k];
        //        //    }
        //        //}

        //        int columnIndex;
        //        for (int i = diagonalIndexes[k] + 1; i < factorA.m_Heads[k]; ++i)
        //        {
        //            columnIndex = indexes[i];
        //            for (int j = 0; j < nx; j++)
        //                y[k, j] -= values[i] * y[columnIndex, j];
        //        }
        //        for (int j = 0; j < nx; j++)
        //            y[k, j] = val * y[k, j];
                
        //    }
        //    return y;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="value"></param>
        unsafe public static void LuDecomposition(int m, int n, double[] value, int[] pivots)
        {
            if (pivots == null)
                pivots = new int[m];
            if (pivots.Length != m)
                throw new ArgumentOutOfRangeException("pivots");
            // Use a "left-looking", dot-product, Crout/Doolittle algorithm.
            double[] jColumn = new double[m];
            for (int i = 0; i < m; i++)
                pivots[i] = i;
            int pivsign = 1;
            fixed (double* valuePointer = value, columnPointer = jColumn)
            {
                double* ptrValueEnd = valuePointer + value.Length;

                double* ptrColumn;
                double* ptrValue;
                double* ptrTemp;
                double* ptrTempEnd;
                // Summators
                double sum1;
                double sum2;
                double sum3;
                double sum4;
                // Outer loop.
                for (int j = 0; j < n; ++j)
                {
                    // Make a copy of the j-th column to localize memory, for cpu cache friendly
                    ptrValue = valuePointer + j;
                    ptrColumn = columnPointer;
                    for (; ptrValue < ptrValueEnd; ptrValue += n, ptrColumn++)
                        *ptrColumn = *ptrValue;

                    // Apply previous transformations.
                    for (int i = 0; i < m; ++i)
                    {
                        // Most of the time is spent in the following dot product.
                        int kmax = System.Math.Min(i, j);
                        sum1 = 0;
                        sum2 = 0;
                        sum3 = 0;
                        sum4 = 0;
                        ptrTemp = ptrValue = valuePointer + i * n;
                        ptrColumn = columnPointer;
                        ptrTempEnd = columnPointer + kmax - 31;

                        while (ptrColumn < ptrTempEnd)
                        {
                            sum1 += *ptrValue * *ptrColumn
                            + *(ptrValue + 1) * *(ptrColumn + 1)
                            + *(ptrValue + 2) * *(ptrColumn + 2)
                            + *(ptrValue + 3) * *(ptrColumn + 3);
                            sum2 += *(ptrValue + 4) * *(ptrColumn + 4)
                            + *(ptrValue + 5) * *(ptrColumn + 5)
                            + *(ptrValue + 6) * *(ptrColumn + 6)
                            + *(ptrValue + 7) * *(ptrColumn + 7);
                            sum3 += *(ptrValue + 8) * *(ptrColumn + 8)
                            + *(ptrValue + 9) * *(ptrColumn + 9)
                            + *(ptrValue + 10) * *(ptrColumn + 10)
                            + *(ptrValue + 11) * *(ptrColumn + 11);
                            sum4 += *(ptrValue + 12) * *(ptrColumn + 12)
                            + *(ptrValue + 13) * *(ptrColumn + 13)
                            + *(ptrValue + 14) * *(ptrColumn + 14)
                            + *(ptrValue + 15) * *(ptrColumn + 15);
                            sum1 += *(ptrValue + 16) * *(ptrColumn + 16)
                            + *(ptrValue + 17) * *(ptrColumn + 17)
                            + *(ptrValue + 18) * *(ptrColumn + 18)
                            + *(ptrValue + 19) * *(ptrColumn + 19);
                            sum2 += *(ptrValue + 20) * *(ptrColumn + 20)
                            + *(ptrValue + 21) * *(ptrColumn + 21)
                            + *(ptrValue + 22) * *(ptrColumn + 22)
                            + *(ptrValue + 23) * *(ptrColumn + 23);
                            sum3 += *(ptrValue + 24) * *(ptrColumn + 24)
                            + *(ptrValue + 25) * *(ptrColumn + 25)
                            + *(ptrValue + 26) * *(ptrColumn + 26)
                            + *(ptrValue + 27) * *(ptrColumn + 27);
                            sum4 += *(ptrValue + 28) * *(ptrColumn + 28)
                            + *(ptrValue + 29) * *(ptrColumn + 29)
                            + *(ptrValue + 30) * *(ptrColumn + 30)
                            + *(ptrValue + 31) * *(ptrColumn + 31);

                            ptrValue += 32;
                            ptrColumn += 32;
                        }
                        ptrTempEnd += 16;
                        if (ptrColumn < ptrTempEnd)
                        {
                            sum1 += *ptrValue * *ptrColumn
                            + *(ptrValue + 1) * *(ptrColumn + 1)
                            + *(ptrValue + 2) * *(ptrColumn + 2)
                            + *(ptrValue + 3) * *(ptrColumn + 3)
                            + *(ptrValue + 4) * *(ptrColumn + 4)
                            + *(ptrValue + 5) * *(ptrColumn + 5)
                            + *(ptrValue + 6) * *(ptrColumn + 6)
                            + *(ptrValue + 7) * *(ptrColumn + 7);
                            sum2 += *(ptrValue + 8) * *(ptrColumn + 8)
                            + *(ptrValue + 9) * *(ptrColumn + 9)
                            + *(ptrValue + 10) * *(ptrColumn + 10)
                            + *(ptrValue + 11) * *(ptrColumn + 11)
                            + *(ptrValue + 12) * *(ptrColumn + 12)
                            + *(ptrValue + 13) * *(ptrColumn + 13)
                            + *(ptrValue + 14) * *(ptrColumn + 14)
                            + *(ptrValue + 15) * *(ptrColumn + 15);
                            ptrValue += 16;
                            ptrColumn += 16;
                        }
                        ptrTempEnd += 8;
                        if (ptrColumn < ptrTempEnd)
                        {
                            sum1 += *ptrValue * *ptrColumn
                            + *(ptrValue + 1) * *(ptrColumn + 1)
                            + *(ptrValue + 2) * *(ptrColumn + 2)
                            + *(ptrValue + 3) * *(ptrColumn + 3)
                            + *(ptrValue + 4) * *(ptrColumn + 4)
                            + *(ptrValue + 5) * *(ptrColumn + 5)
                            + *(ptrValue + 6) * *(ptrColumn + 6)
                            + *(ptrValue + 7) * *(ptrColumn + 7);
                            ptrValue += 8;
                            ptrColumn += 8;
                        }
                        ptrTempEnd += 4;
                        if (ptrColumn < ptrTempEnd)
                        {
                            sum1 += *ptrValue * *ptrColumn
                            + *(ptrValue + 1) * *(ptrColumn + 1)
                            + *(ptrValue + 2) * *(ptrColumn + 2)
                            + *(ptrValue + 3) * *(ptrColumn + 3);
                            ptrValue += 4;
                            ptrColumn += 4;
                        }
                        ptrTempEnd += 2;
                        if (ptrColumn < ptrTempEnd)
                        {
                            sum1 += *ptrValue * *ptrColumn
                             + *(ptrValue + 1) * *(ptrColumn + 1);
                            ptrValue += 2;
                            ptrColumn += 2;
                        }
                        if (ptrColumn == ptrTempEnd)
                            sum1 += *ptrValue * *ptrColumn;
                        *(ptrTemp + j) = *(columnPointer + i) -= (sum1 + sum2 + sum3 + sum4);
                    }

                    // Find pivot and exchange if necessary.
                    int p = j;
                    for (int i = j + 1; i < m; ++i)
                    {
                        if (System.Math.Abs(jColumn[i]) > System.Math.Abs(jColumn[p]))
                            p = i;
                    }
                    ptrColumn = valuePointer + j * n;
                    if (p != j)
                    {
                        ptrValue = valuePointer + p * n;
                        ptrTemp = ptrColumn;
                        ptrTempEnd = ptrTemp + n;
                        for (; ptrTemp < ptrTempEnd; ptrValue++, ptrTemp++)
                        {
                            double t = *ptrValue;
                            *ptrValue = *ptrTemp;
                            *ptrTemp = t;
                        }

                        int k2 = pivots[p];
                        pivots[p] = pivots[j];
                        pivots[j] = k2;
                        pivsign = -pivsign;
                    }

                    // Compute multipliers.
                    double temp = *(ptrColumn + j);
                    if (j < m)
                        if (temp != 0.0)
                        {
                            ptrValue = valuePointer + (j + 1) * n + j;
                            for (; ptrValue < ptrValueEnd; ptrValue += n)
                                *ptrValue /= temp;
                        }
                }
            }
        }
        unsafe public static void LuSolve(int m1, int n1, double[] LU, int m2, int n2, double[] value)
        {
            //if (B.RowDimension != m)
            //{
            //    throw new System.ArgumentException("Matrix row dimensions must agree.");
            //}
            //if (!this.IsNonSingular)
            //{
            //    throw new System.SystemException("Matrix is singular.");
            //}

            // Copy right hand side with pivoting
            //int nx = B.ColumnDimension;
            //GeneralMatrix Xmat = B.GetMatrix(piv, 0, nx - 1);
            //double[][] X = Xmat.Array;

            //// Solve L*Y = B(piv,:)
            //for (int k = 0; k < n; k++)
            //{
            //    for (int i = k + 1; i < n; i++)
            //    {
            //        for (int j = 0; j < nx; j++)
            //        {
            //            X[i][j] -= X[k][j] * LU[i][k];
            //        }
            //    }
            //}
            //// Solve U*X = Y;
            //for (int k = n - 1; k >= 0; k--)
            //{
            //    for (int j = 0; j < nx; j++)
            //    {
            //        X[k][j] /= LU[k][k];
            //    }
            //    for (int i = 0; i < k; i++)
            //    {
            //        for (int j = 0; j < nx; j++)
            //        {
            //            X[i][j] -= X[k][j] * LU[i][k];
            //        }
            //    }
            //}
            //return Xmat;
        }
        unsafe public static void QrDecomposition(int m, int n, double[] value1, double[] rDiag)
        {
            if (rDiag == null)
                rDiag = new double[n];
            if (rDiag.Length != n)
                throw new ArgumentOutOfRangeException("rDiag");
            // Initialize.
            double[] value = new double[value1.Length];
            Transpose(m, n, value1, value);
            fixed (double* valuePointer = value)
            {
                double* ptrValueEnd = valuePointer + value.Length;

                double* ptrValue;
                double* ptrColumn;
                double* ptrTempEnd;

                // Main loop.
                for (int k = 0; k < n; k++)
                {
                    // Compute 2-norm of k-th column without under/overflow.
                    double nrm = 0;
                    int km = k * m;
                    int kmk = km + k;
                    for (int i = k; i < m; i++)
                        nrm = Hypot(nrm, value[km + i]);
                    if (nrm != 0.0)
                    {
                        // Form k-th Householder vector.
                        if (value[kmk] < 0)
                            nrm = -nrm;

                        for (int i = k; i < m; i++)
                            value[km + i] /= nrm;

                        value[kmk] += 1.0;

                        // Apply transformation to remaining columns.
                        for (int j = k + 1; j < n; j++)
                        {
                            double s = 0.0;
                            int jm = j * m;
                            ptrValue = valuePointer + kmk;
                            ptrColumn = valuePointer + jm + k;
                            ptrTempEnd = valuePointer + jm + m - 31;

                            while (ptrColumn < ptrTempEnd)
                            {
                                s += *ptrValue * *ptrColumn
                                + *(ptrValue + 1) * *(ptrColumn + 1)
                                + *(ptrValue + 2) * *(ptrColumn + 2)
                                + *(ptrValue + 3) * *(ptrColumn + 3)
                                + *(ptrValue + 4) * *(ptrColumn + 4)
                                + *(ptrValue + 5) * *(ptrColumn + 5)
                                + *(ptrValue + 6) * *(ptrColumn + 6)
                                + *(ptrValue + 7) * *(ptrColumn + 7)
                                + *(ptrValue + 8) * *(ptrColumn + 8)
                                + *(ptrValue + 9) * *(ptrColumn + 9)
                                + *(ptrValue + 10) * *(ptrColumn + 10)
                                + *(ptrValue + 11) * *(ptrColumn + 11)
                                + *(ptrValue + 12) * *(ptrColumn + 12)
                                + *(ptrValue + 13) * *(ptrColumn + 13)
                                + *(ptrValue + 14) * *(ptrColumn + 14)
                                + *(ptrValue + 15) * *(ptrColumn + 15)
                                + *(ptrValue + 16) * *(ptrColumn + 16)
                                + *(ptrValue + 17) * *(ptrColumn + 17)
                                + *(ptrValue + 18) * *(ptrColumn + 18)
                                + *(ptrValue + 19) * *(ptrColumn + 19)
                                + *(ptrValue + 20) * *(ptrColumn + 20)
                                + *(ptrValue + 21) * *(ptrColumn + 21)
                                + *(ptrValue + 22) * *(ptrColumn + 22)
                                + *(ptrValue + 23) * *(ptrColumn + 23)
                                + *(ptrValue + 24) * *(ptrColumn + 24)
                                + *(ptrValue + 25) * *(ptrColumn + 25)
                                + *(ptrValue + 26) * *(ptrColumn + 26)
                                + *(ptrValue + 27) * *(ptrColumn + 27)
                                + *(ptrValue + 28) * *(ptrColumn + 28)
                                + *(ptrValue + 29) * *(ptrColumn + 29)
                                + *(ptrValue + 30) * *(ptrColumn + 30)
                                + *(ptrValue + 31) * *(ptrColumn + 31);
                                ptrValue += 32;
                                ptrColumn += 32;
                            }
                            ptrTempEnd += 16;
                            if (ptrColumn < ptrTempEnd)
                            {
                                s += *ptrValue * *ptrColumn
                                + *(ptrValue + 1) * *(ptrColumn + 1)
                                + *(ptrValue + 2) * *(ptrColumn + 2)
                                + *(ptrValue + 3) * *(ptrColumn + 3)
                                + *(ptrValue + 4) * *(ptrColumn + 4)
                                + *(ptrValue + 5) * *(ptrColumn + 5)
                                + *(ptrValue + 6) * *(ptrColumn + 6)
                                + *(ptrValue + 7) * *(ptrColumn + 7)
                                + *(ptrValue + 8) * *(ptrColumn + 8)
                                + *(ptrValue + 9) * *(ptrColumn + 9)
                                + *(ptrValue + 10) * *(ptrColumn + 10)
                                + *(ptrValue + 11) * *(ptrColumn + 11)
                                + *(ptrValue + 12) * *(ptrColumn + 12)
                                + *(ptrValue + 13) * *(ptrColumn + 13)
                                + *(ptrValue + 14) * *(ptrColumn + 14)
                                + *(ptrValue + 15) * *(ptrColumn + 15);
                                ptrValue += 16;
                                ptrColumn += 16;
                            }
                            ptrTempEnd += 8;
                            if (ptrColumn < ptrTempEnd)
                            {
                                s += *ptrValue * *ptrColumn
                                + *(ptrValue + 1) * *(ptrColumn + 1)
                                + *(ptrValue + 2) * *(ptrColumn + 2)
                                + *(ptrValue + 3) * *(ptrColumn + 3)
                                + *(ptrValue + 4) * *(ptrColumn + 4)
                                + *(ptrValue + 5) * *(ptrColumn + 5)
                                + *(ptrValue + 6) * *(ptrColumn + 6)
                                + *(ptrValue + 7) * *(ptrColumn + 7);
                                ptrValue += 8;
                                ptrColumn += 8;
                            }
                            ptrTempEnd += 4;
                            if (ptrColumn < ptrTempEnd)
                            {
                                s += *ptrValue * *ptrColumn
                                + *(ptrValue + 1) * *(ptrColumn + 1)
                                + *(ptrValue + 2) * *(ptrColumn + 2)
                                + *(ptrValue + 3) * *(ptrColumn + 3);
                                ptrValue += 4;
                                ptrColumn += 4;
                            }
                            ptrTempEnd += 2;
                            if (ptrColumn < ptrTempEnd)
                            {
                                s += *ptrValue * *ptrColumn
                                 + *(ptrValue + 1) * *(ptrColumn + 1);
                                ptrValue += 2;
                                ptrColumn += 2;
                            }
                            if (ptrColumn <= ptrTempEnd)
                                s += *ptrValue * *ptrColumn;

                            ptrValue = valuePointer + kmk;
                            s = (-s) / *ptrValue;

                            ptrColumn = valuePointer + jm + k;
                            ptrTempEnd = valuePointer + jm + m - 31;

                            while (ptrColumn < ptrTempEnd)
                            {
                                *ptrColumn += s * *ptrValue;
                                *(ptrColumn + 1) += s * *(ptrValue + 1);
                                *(ptrColumn + 2) += s * *(ptrValue + 2);
                                *(ptrColumn + 3) += s * *(ptrValue + 3);
                                *(ptrColumn + 4) += s * *(ptrValue + 4);
                                *(ptrColumn + 5) += s * *(ptrValue + 5);
                                *(ptrColumn + 6) += s * *(ptrValue + 6);
                                *(ptrColumn + 7) += s * *(ptrValue + 7);
                                *(ptrColumn + 8) += s * *(ptrValue + 8);
                                *(ptrColumn + 9) += s * *(ptrValue + 9);
                                *(ptrColumn + 10) += s * *(ptrValue + 10);
                                *(ptrColumn + 11) += s * *(ptrValue + 11);
                                *(ptrColumn + 12) += s * *(ptrValue + 12);
                                *(ptrColumn + 13) += s * *(ptrValue + 13);
                                *(ptrColumn + 14) += s * *(ptrValue + 14);
                                *(ptrColumn + 15) += s * *(ptrValue + 15);
                                *(ptrColumn + 16) += s * *(ptrValue + 16);
                                *(ptrColumn + 17) += s * *(ptrValue + 17);
                                *(ptrColumn + 18) += s * *(ptrValue + 18);
                                *(ptrColumn + 19) += s * *(ptrValue + 19);
                                *(ptrColumn + 20) += s * *(ptrValue + 20);
                                *(ptrColumn + 21) += s * *(ptrValue + 21);
                                *(ptrColumn + 22) += s * *(ptrValue + 22);
                                *(ptrColumn + 23) += s * *(ptrValue + 23);
                                *(ptrColumn + 24) += s * *(ptrValue + 24);
                                *(ptrColumn + 25) += s * *(ptrValue + 25);
                                *(ptrColumn + 26) += s * *(ptrValue + 26);
                                *(ptrColumn + 27) += s * *(ptrValue + 27);
                                *(ptrColumn + 28) += s * *(ptrValue + 28);
                                *(ptrColumn + 29) += s * *(ptrValue + 29);
                                *(ptrColumn + 30) += s * *(ptrValue + 30);
                                *(ptrColumn + 31) += s * *(ptrValue + 31);
                                ptrValue += 32;
                                ptrColumn += 32;
                            }
                            ptrTempEnd += 16;
                            if (ptrColumn < ptrTempEnd)
                            {
                                *ptrColumn += s * *ptrValue;
                                *(ptrColumn + 1) += s * *(ptrValue + 1);
                                *(ptrColumn + 2) += s * *(ptrValue + 2);
                                *(ptrColumn + 3) += s * *(ptrValue + 3);
                                *(ptrColumn + 4) += s * *(ptrValue + 4);
                                *(ptrColumn + 5) += s * *(ptrValue + 5);
                                *(ptrColumn + 6) += s * *(ptrValue + 6);
                                *(ptrColumn + 7) += s * *(ptrValue + 7);
                                *(ptrColumn + 8) += s * *(ptrValue + 8);
                                *(ptrColumn + 9) += s * *(ptrValue + 9);
                                *(ptrColumn + 10) += s * *(ptrValue + 10);
                                *(ptrColumn + 11) += s * *(ptrValue + 11);
                                *(ptrColumn + 12) += s * *(ptrValue + 12);
                                *(ptrColumn + 13) += s * *(ptrValue + 13);
                                *(ptrColumn + 14) += s * *(ptrValue + 14);
                                *(ptrColumn + 15) += s * *(ptrValue + 15);
                                ptrValue += 16;
                                ptrColumn += 16;
                            }
                            ptrTempEnd += 8;
                            if (ptrColumn < ptrTempEnd)
                            {
                                *ptrColumn += s * *ptrValue;
                                *(ptrColumn + 1) += s * *(ptrValue + 1);
                                *(ptrColumn + 2) += s * *(ptrValue + 2);
                                *(ptrColumn + 3) += s * *(ptrValue + 3);
                                *(ptrColumn + 4) += s * *(ptrValue + 4);
                                *(ptrColumn + 5) += s * *(ptrValue + 5);
                                *(ptrColumn + 6) += s * *(ptrValue + 6);
                                *(ptrColumn + 7) += s * *(ptrValue + 7);
                                ptrValue += 8;
                                ptrColumn += 8;
                            }
                            ptrTempEnd += 4;
                            if (ptrColumn < ptrTempEnd)
                            {
                                *ptrColumn += s * *ptrValue;
                                *(ptrColumn + 1) += s * *(ptrValue + 1);
                                *(ptrColumn + 2) += s * *(ptrValue + 2);
                                *(ptrColumn + 3) += s * *(ptrValue + 3);
                                ptrValue += 4;
                                ptrColumn += 4;
                            }
                            ptrTempEnd += 2;
                            if (ptrColumn < ptrTempEnd)
                            {
                                *ptrColumn += s * *ptrValue;
                                *(ptrColumn + 1) += s * *(ptrValue + 1);
                                ptrValue += 2;
                                ptrColumn += 2;
                            }
                            if (ptrColumn <= ptrTempEnd)
                                *ptrColumn += s * *ptrValue;
                        }
                    }
                    rDiag[k] = -nrm;
                }
            }
            Transpose(n, m, value, value1);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="QR"></param>
        /// <param name="mB"></param>
        /// <param name="nB"></param>
        /// <param name="B"></param>
        /// <param name="rDiag"></param>
        /// <param name="result">Length = n * nB</param>
        unsafe public static void QrSolve(int m, int n, double[] QR, int mB, int nB, double[] B, double[] rDiag, double[] result)
        {
            if (mB != m)
                throw new System.ArgumentException("GeneralMatrix row dimensions must agree.");
            if (!FullRank(rDiag))
                throw new System.SystemException("Matrix is rank deficient.");


            // Compute Y = transpose(Q)*B
            for (int k = 0; k < n; k++)
            {
                for (int j = 0; j < nB; j++)
                {
                    double s = 0.0;
                    for (int i = k; i < m; i++)
                    {
                        s += QR[i * n + k] * B[i * nB + j];
                    }
                    s = (-s) / QR[k * n + k];
                    for (int i = k; i < m; i++)
                    {
                        B[i * nB + j] += s * QR[i * n + k];
                    }
                }
            }
            // Solve R*X = Y;
            for (int k = n - 1; k >= 0; k--)
            {
                for (int j = 0; j < nB; j++)
                {
                    B[k * nB + j] /= rDiag[k];
                }
                for (int i = 0; i < k; i++)
                {
                    for (int j = 0; j < nB; j++)
                    {
                        B[i * nB + j] -= B[k * nB + j] * QR[i * n + k];
                    }
                }
            }
            int length = n * nB;
            for (int i = 0; i < length; ++i)
                result[i] = B[i];
        }
        /// <summary>Return the upper triangular factor</summary>
        /// <returns>R</returns>
        public static double[] GetR(int m, int n, double[] QR, double[] rDiag)
        {
            double[] R = new double[n * n];
            //double[][] R = X.Array;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i < j)
                    {
                        R[i * n + j] = QR[i * n + j];
                    }
                    else if (i == j)
                    {
                        R[i * n + j] = rDiag[i];
                    }
                    else
                    {
                        R[i * n + j] = 0.0;
                    }
                }
            }
            return R;
        }
        /// <summary>
        /// Generate and return the (economy-sized) orthogonal factor
        /// </summary>
        /// <returns>Q</returns>
        public static double[] GetQ(int m, int n, double[] QR, double[] rDiag)
        {

            double[] Q = new double[m * n];
            for (int k = n - 1; k >= 0; k--)
            {
                for (int i = 0; i < m; i++)
                {
                    Q[i * n + k] = 0.0;
                }
                Q[k * n + k] = 1.0;
                for (int j = k; j < n; j++)
                {
                    if (QR[k * n + k] != 0)
                    {
                        double s = 0.0;
                        for (int i = k; i < m; i++)
                        {
                            s += QR[i * n + k] * Q[i * n + j];
                        }
                        s = (-s) / QR[k * n + k];
                        for (int i = k; i < m; i++)
                        {
                            Q[i * n + j] += s * QR[i * n + k];
                        }
                    }
                }
            }
            return Q;
        }
        #endregion Factorization
        #region Equals
        #region double
        public bool Equals(FullMatrix<double> value1, FullMatrix<double> value2)
        {

            return true;
        }
        #endregion double
        #region Complex
        public bool Equals(FullMatrix<Complex> value1, FullMatrix<Complex> value2)
        {

            return true;
        }
        #endregion Complex
        #endregion Equals
        #region To String
        public string ToString(string delimiter, string endRow)
        {

            return string.Empty;
        }
        #endregion To String
        #region Conversion
        public static FullMatrix<Complex> AsComplex(FullMatrix<double> value)
        {
            return null;
        }
        public static FullMatrix<Complex> AsComplex(FullMatrix<double> real, FullMatrix<double> image)
        {
            return null;
        }
        public static FullMatrix<double> AsReal(FullMatrix<Complex> value)
        {
            return null;
        }
        public static FullMatrix<double> AsImage(FullMatrix<Complex> value)
        {
            return null;
        }
        public static CsrMatrix<double> AsReal(CsrMatrix<Complex> value)
        {
            return AsRealAndImage(value)[0];
        }
        public static CsrMatrix<double> AsImage(CsrMatrix<Complex> value)
        {
            return AsRealAndImage(value)[1];
        }
        
        unsafe public static CsrMatrix<double>[] AsRealAndImage(CsrMatrix<Complex> value)
        {
            int m = value.RowsCount;
            int n = value.ColumnsCount;
            CsrMatrix<double> realMatrix = new CsrMatrix<double>(value.m_RowsMapping[value.m_RowsCount], m, n);
            CsrMatrix<double> imaginaryMatrix = new CsrMatrix<double>(value.m_RowsMapping[value.m_RowsCount], m, n);
            int[] rowIndex1 = realMatrix.m_RowsMapping;
            int[] rowIndex2 = imaginaryMatrix.m_RowsMapping;
            int[] rowIndex = value.m_RowsMapping;
            
            fixed (Complex* valuesPointer = value.m_Values)
            fixed (double* values1Pointer = realMatrix.m_Values, values2Pointer = imaginaryMatrix.m_Values)
            fixed (int* columnsPointer = value.m_Columns, columns1Pointer = realMatrix.m_Columns, columns2Pointer = imaginaryMatrix.m_Columns)
            {
                int index;
                int end;
                int index1;
                int index2;
                // Main loop -- optimize for sparse matrix-vector multiply
                for (int i = 0; i < m; ++i)
                {
                    index = rowIndex[i];
                    index1 = rowIndex1[i];
                    index2 = rowIndex2[i];
                    end = rowIndex[i + 1];
                    while (index != end)
                    {
                        double real = (*(valuesPointer + index)).Real;
                        double imaginary = (*(valuesPointer + index)).Imaginary;
                        if (real != 0)
                        {
                            *(values1Pointer + index1) = real;
                            *(columns1Pointer + index1) = *(columnsPointer + index);
                            index1++;
                        }
                        if (imaginary != 0)
                        {
                            *(values2Pointer + index2) = imaginary;
                            *(columns2Pointer + index2) = *(columnsPointer + index);
                            index2++;
                        }
                        index++;
                    }
                    rowIndex1[i + 1] = index1;
                    rowIndex2[i + 1] = index2;
                }
            }
            return new CsrMatrix<double>[2] { realMatrix, imaginaryMatrix };
        }
        #endregion Conversion
        #region Other
        /// <summary>
        /// Returns the complex conjugate of the elements of value matrix
        /// </summary>
        /// <returns></returns>
        unsafe public static void Conjugate(int m, int n, Complex[] value, Complex[] result)
        {
            int size = m * n;
            if (size != value.Length)
                throw new ArgumentOutOfRangeException("value");
            if (size != result.Length)
                throw new ArgumentOutOfRangeException("result");
            fixed (Complex* valuePointer = value, resultPointer = result)
            {
                double* ptrValue = (double*)valuePointer;
                double* ptrResult = (double*)resultPointer;
                double* ptrEnd = ptrResult + size * 2 - 31;
                // Main loop, pointers for row values
                while (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue;
                    *(ptrResult + 1) = -*(ptrValue + 1);
                    *(ptrResult + 2) = *(ptrValue + 2);
                    *(ptrResult + 3) = -*(ptrValue + 3);
                    *(ptrResult + 4) = *(ptrValue + 4);
                    *(ptrResult + 5) = -*(ptrValue + 5);
                    *(ptrResult + 6) = *(ptrValue + 6);
                    *(ptrResult + 7) = -*(ptrValue + 7);
                    *(ptrResult + 8) = *(ptrValue + 8);
                    *(ptrResult + 9) = -*(ptrValue + 9);
                    *(ptrResult + 10) = *(ptrValue + 10);
                    *(ptrResult + 11) = -*(ptrValue + 11);
                    *(ptrResult + 12) = *(ptrValue + 12);
                    *(ptrResult + 13) = -*(ptrValue + 13);
                    *(ptrResult + 14) = *(ptrValue + 14);
                    *(ptrResult + 15) = -*(ptrValue + 15);
                    *(ptrResult + 16) = *(ptrValue + 16);
                    *(ptrResult + 17) = -*(ptrValue + 17);
                    *(ptrResult + 18) = *(ptrValue + 18);
                    *(ptrResult + 19) = -*(ptrValue + 19);
                    *(ptrResult + 20) = *(ptrValue + 20);
                    *(ptrResult + 21) = -*(ptrValue + 21);
                    *(ptrResult + 22) = *(ptrValue + 22);
                    *(ptrResult + 23) = -*(ptrValue + 23);
                    *(ptrResult + 24) = *(ptrValue + 24);
                    *(ptrResult + 25) = -*(ptrValue + 25);
                    *(ptrResult + 26) = *(ptrValue + 26);
                    *(ptrResult + 27) = -*(ptrValue + 27);
                    *(ptrResult + 28) = *(ptrValue + 28);
                    *(ptrResult + 29) = -*(ptrValue + 29);
                    *(ptrResult + 30) = *(ptrValue + 30);
                    *(ptrResult + 31) = -*(ptrValue + 31);
                    ptrResult += 32;
                    ptrValue += 32;
                }
                ptrEnd += 16;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue;
                    *(ptrResult + 1) = -*(ptrValue + 1);
                    *(ptrResult + 2) = *(ptrValue + 2);
                    *(ptrResult + 3) = -*(ptrValue + 3);
                    *(ptrResult + 4) = *(ptrValue + 4);
                    *(ptrResult + 5) = -*(ptrValue + 5);
                    *(ptrResult + 6) = *(ptrValue + 6);
                    *(ptrResult + 7) = -*(ptrValue + 7);
                    *(ptrResult + 8) = *(ptrValue + 8);
                    *(ptrResult + 9) = -*(ptrValue + 9);
                    *(ptrResult + 10) = *(ptrValue + 10);
                    *(ptrResult + 11) = -*(ptrValue + 11);
                    *(ptrResult + 12) = *(ptrValue + 12);
                    *(ptrResult + 13) = -*(ptrValue + 13);
                    *(ptrResult + 14) = *(ptrValue + 14);
                    *(ptrResult + 15) = -*(ptrValue + 15);
                    ptrResult += 16;
                    ptrValue += 16;
                }
                ptrEnd += 8;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue;
                    *(ptrResult + 1) = -*(ptrValue + 1);
                    *(ptrResult + 2) = *(ptrValue + 2);
                    *(ptrResult + 3) = -*(ptrValue + 3);
                    *(ptrResult + 4) = *(ptrValue + 4);
                    *(ptrResult + 5) = -*(ptrValue + 5);
                    *(ptrResult + 6) = *(ptrValue + 6);
                    *(ptrResult + 7) = -*(ptrValue + 7);
                    ptrResult += 8;
                    ptrValue += 8;
                }
                ptrEnd += 4;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue;
                    *(ptrResult + 1) = -*(ptrValue + 1);
                    *(ptrResult + 2) = *(ptrValue + 2);
                    *(ptrResult + 3) = -*(ptrValue + 3);
                    ptrResult += 4;
                    ptrValue += 4;
                }
                ptrEnd += 2;
                if (ptrResult < ptrEnd)
                {
                    *ptrResult = *ptrValue;
                    *(ptrResult + 1) = -*(ptrValue + 1);
                    ptrResult += 2;
                    ptrValue += 2;
                }
            }            
        }
        #endregion Other
        #region Old
        unsafe public static void MultiplyOld(int m1, int n1, double[] value1, int m2, int n2, double[] value2, double[] result)
        {
            if (n1 != m2)
                throw new Exception("m != n2!");
            double[] value2Transpose = new double[value2.Length];
            Transpose(m2, n2, value2, value2Transpose);
            fixed (double* value1Pointer = value1, value2tPointer = value2Transpose, resultPointer = result)
            {
                double* ptrValue;
                double* ptrValue2 = value2tPointer;
                double* ptrResult = resultPointer;
                double* ptrEnd = resultPointer + result.Length;
                double* ptrValueEnd;
                int value1Offset = 0;
                int value2Offset = 0;
                for (; ptrResult < ptrEnd; ++ptrResult, value2Offset += m2)
                {
                    if (value2Offset >= result.Length)
                    {
                        value2Offset = 0;
                        value1Offset += n1;
                    }
                    ptrValue = value1Pointer + value1Offset;
                    ptrValueEnd = ptrValue + n1 - 31;
                    ptrValue2 = value2tPointer + value2Offset;
                    double s = 0;

                    //for (; ptrValue1 < ptrValue1End; ++ptrValue1, ++ptrValue2)
                    //    temp += (*ptrValue1 * *ptrValue2);

                    while (ptrValue < ptrValueEnd)
                    {
                        s += *ptrValue * *ptrValue2
                        + *(ptrValue + 1) * *(ptrValue2 + 1)
                        + *(ptrValue + 2) * *(ptrValue2 + 2)
                        + *(ptrValue + 3) * *(ptrValue2 + 3)
                        + *(ptrValue + 4) * *(ptrValue2 + 4)
                        + *(ptrValue + 5) * *(ptrValue2 + 5)
                        + *(ptrValue + 6) * *(ptrValue2 + 6)
                        + *(ptrValue + 7) * *(ptrValue2 + 7)
                        + *(ptrValue + 8) * *(ptrValue2 + 8)
                        + *(ptrValue + 9) * *(ptrValue2 + 9)
                        + *(ptrValue + 10) * *(ptrValue2 + 10)
                        + *(ptrValue + 11) * *(ptrValue2 + 11)
                        + *(ptrValue + 12) * *(ptrValue2 + 12)
                        + *(ptrValue + 13) * *(ptrValue2 + 13)
                        + *(ptrValue + 14) * *(ptrValue2 + 14)
                        + *(ptrValue + 15) * *(ptrValue2 + 15)
                        + *(ptrValue + 16) * *(ptrValue2 + 16)
                        + *(ptrValue + 17) * *(ptrValue2 + 17)
                        + *(ptrValue + 18) * *(ptrValue2 + 18)
                        + *(ptrValue + 19) * *(ptrValue2 + 19)
                        + *(ptrValue + 20) * *(ptrValue2 + 20)
                        + *(ptrValue + 21) * *(ptrValue2 + 21)
                        + *(ptrValue + 22) * *(ptrValue2 + 22)
                        + *(ptrValue + 23) * *(ptrValue2 + 23)
                        + *(ptrValue + 24) * *(ptrValue2 + 24)
                        + *(ptrValue + 25) * *(ptrValue2 + 25)
                        + *(ptrValue + 26) * *(ptrValue2 + 26)
                        + *(ptrValue + 27) * *(ptrValue2 + 27)
                        + *(ptrValue + 28) * *(ptrValue2 + 28)
                        + *(ptrValue + 29) * *(ptrValue2 + 29)
                        + *(ptrValue + 30) * *(ptrValue2 + 30)
                        + *(ptrValue + 31) * *(ptrValue2 + 31);

                        ptrValue += 32;
                        ptrValue2 += 32;
                    }
                    ptrValueEnd += 16;
                    if (ptrValue < ptrValueEnd)
                    {
                        s += *ptrValue * *ptrValue2
                        + *(ptrValue + 1) * *(ptrValue2 + 1)
                        + *(ptrValue + 2) * *(ptrValue2 + 2)
                        + *(ptrValue + 3) * *(ptrValue2 + 3)
                        + *(ptrValue + 4) * *(ptrValue2 + 4)
                        + *(ptrValue + 5) * *(ptrValue2 + 5)
                        + *(ptrValue + 6) * *(ptrValue2 + 6)
                        + *(ptrValue + 7) * *(ptrValue2 + 7)
                        + *(ptrValue + 8) * *(ptrValue2 + 8)
                        + *(ptrValue + 9) * *(ptrValue2 + 9)
                        + *(ptrValue + 10) * *(ptrValue2 + 10)
                        + *(ptrValue + 11) * *(ptrValue2 + 11)
                        + *(ptrValue + 12) * *(ptrValue2 + 12)
                        + *(ptrValue + 13) * *(ptrValue2 + 13)
                        + *(ptrValue + 14) * *(ptrValue2 + 14)
                        + *(ptrValue + 15) * *(ptrValue2 + 15);
                        ptrValue += 16;
                        ptrValue2 += 16;
                    }
                    ptrValueEnd += 8;
                    if (ptrValue < ptrValueEnd)
                    {
                        s += *ptrValue * *ptrValue2
                        + *(ptrValue + 1) * *(ptrValue2 + 1)
                        + *(ptrValue + 2) * *(ptrValue2 + 2)
                        + *(ptrValue + 3) * *(ptrValue2 + 3)
                        + *(ptrValue + 4) * *(ptrValue2 + 4)
                        + *(ptrValue + 5) * *(ptrValue2 + 5)
                        + *(ptrValue + 6) * *(ptrValue2 + 6)
                        + *(ptrValue + 7) * *(ptrValue2 + 7);
                        ptrValue += 8;
                        ptrValue2 += 8;
                    }
                    ptrValueEnd += 4;
                    if (ptrValue < ptrValueEnd)
                    {
                        s += *ptrValue * *ptrValue2
                        + *(ptrValue + 1) * *(ptrValue2 + 1)
                        + *(ptrValue + 2) * *(ptrValue2 + 2)
                        + *(ptrValue + 3) * *(ptrValue2 + 3);
                        ptrValue += 4;
                        ptrValue2 += 4;
                    }
                    ptrValueEnd += 2;
                    if (ptrValue < ptrValueEnd)
                    {
                        s += *ptrValue * *ptrValue2
                         + *(ptrValue + 1) * *(ptrValue2 + 1);
                        ptrValue += 2;
                        ptrValue2 += 2;
                    }
                    if (ptrValue <= ptrValueEnd)
                        s += *ptrValue * *ptrValue2;

                    *ptrResult = s;
                }
            }
        }
        /// <summary>
        /// Performs LU-decomposition of this instance and saves L and U
        /// </summary>
        public static void LU(int m, int n, double[] value, double[] resultL, double[] resultU)
        {
            if (m != n)
                throw new InvalidOperationException("Cannot perform LU-decomposition of non-square matrix.");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    resultU[i] = value[i];
                    resultL[i * n] = value[i * n] / resultU[0];
                    double sum = 0;
                    for (int k = 0; k < i; k++)
                    {
                        sum += resultL[i * n + k] * resultU[k * n + j];
                    }
                    resultU[i * n + j] = value[i * n + j] - sum;
                    if (i > j)
                    {
                        resultL[j * n + i] = 0;
                    }
                    else
                    {
                        sum = 0;
                        for (int k = 0; k < i; k++)
                        {
                            sum += resultL[j * n + k] * resultU[k * n + i];
                        }
                        resultL[j * n + i] = (value[j * n + i] - sum) / resultU[i * n + i];
                    }
                }
            }

        }
        public static void LU1(int m, int n, double[] value, double[] resultL, double[] resultU)
        {
            if (m != n)
                throw new InvalidOperationException("Cannot perform LU-decomposition of non-square matrix.");

            for (int i = 0; i < n; i++)
            {
                resultU[i] = value[i];
                resultL[i * n] = value[i * n] / resultU[0];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {

                    double sum = 0;
                    for (int k = 0; k < i; k++)
                    {
                        sum += resultL[i * n + k] * resultU[k * n + j];
                    }
                    resultU[i * n + j] = value[i * n + j] - sum;
                    if (i > j)
                    {
                        resultL[j * n + i] = 0;
                    }
                    else
                    {
                        sum = 0;
                        for (int k = 0; k < i; k++)
                        {
                            sum += resultL[j * n + k] * resultU[k * n + i];
                        }
                        resultL[j * n + i] = (value[j * n + i] - sum) / resultU[i * n + i];
                    }
                }
            }

        }
        public static void LUDecompositionOld(int m, int n, double[][] value)
        {
            // Use a "left-looking", dot-product, Crout/Doolittle algorithm.

            int[] piv = new int[m];
            for (int i = 0; i < m; i++)
                piv[i] = i;
            int pivsign = 1;
            double[] iRow;
            double[] jColumn = new double[m];
            // Outer loop.
            for (int j = 0; j < n; j++)
            {
                // Make a copy of the j-th column to localize memory, for cpu cache
                for (int i = 0; i < m; i++)
                {
                    jColumn[i] = value[i][j];
                }
                // Apply previous transformations.

                for (int i = 0; i < m; i++)
                {
                    iRow = value[i];

                    // Most of the time is spent in the following dot product.

                    int kmax = System.Math.Min(i, j);
                    double s = 0.0;
                    for (int k = 0; k < kmax; k++)
                    {
                        s += iRow[k] * jColumn[k];
                    }

                    iRow[j] = jColumn[i] -= s;
                }

                // Find pivot and exchange if necessary.

                int p = j;
                for (int i = j + 1; i < m; i++)
                {
                    if (System.Math.Abs(jColumn[i]) > System.Math.Abs(jColumn[p]))
                    {
                        p = i;
                    }
                }
                if (p != j)
                {
                    for (int k = 0; k < n; k++)
                    {
                        double t = value[p][k];
                        value[p][k] = value[j][k];
                        value[j][k] = t;
                    }
                    int k2 = piv[p];
                    piv[p] = piv[j];
                    piv[j] = k2;
                    pivsign = -pivsign;
                }

                // Compute multipliers.

                if (j < m & value[j][j] != 0.0)
                {
                    for (int i = j + 1; i < m; i++)
                    {
                        value[i][j] /= value[j][j];
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="value"></param>
        public static void LUDecomposition1(int m, int n, double[] value)
        {
            // Use a "left-looking", dot-product, Crout/Doolittle algorithm.

            int[] piv = new int[m];
            for (int i = 0; i < m; i++)
                piv[i] = i;
            int pivsign = 1;
            double[] jColumn = new double[m];

            // Outer loop.

            for (int j = 0; j < n; j++)
            {

                // Make a copy of the j-th column to localize memory, for cpu cache friendly
                for (int i = 0; i < m; i++)
                    jColumn[i] = value[i * n + j];

                // Apply previous transformations.

                for (int i = 0; i < m; i++)
                {
                    //  iRow = value[i];

                    // Most of the time is spent in the following dot product.

                    int kmax = System.Math.Min(i, j);
                    double s = 0.0;
                    for (int k = 0; k < kmax; k++)
                    {
                        s += value[i * n + k] * jColumn[k];
                    }

                    value[i * n + j] = jColumn[i] -= s;
                }

                // Find pivot and exchange if necessary.

                int p = j;
                for (int i = j + 1; i < m; i++)
                {
                    if (System.Math.Abs(jColumn[i]) > System.Math.Abs(jColumn[p]))
                    {
                        p = i;
                    }
                }
                if (p != j)
                {
                    for (int k = 0; k < n; k++)
                    {
                        double t = value[p * n + k];
                        value[p * n + k] = value[j * n + k];
                        value[j * n + k] = t;
                    }
                    int k2 = piv[p];
                    piv[p] = piv[j];
                    piv[j] = k2;
                    pivsign = -pivsign;
                }

                // Compute multipliers.

                if (j < m & value[j * n + j] != 0.0)
                {
                    for (int i = j + 1; i < m; i++)
                    {
                        value[i * n + j] /= value[j * n + j];
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="value"></param>
        unsafe public static void LUDecomposition2(int m, int n, double[] value)
        {
            // Use a "left-looking", dot-product, Crout/Doolittle algorithm.
            double[] jColumn = new double[m];
            int[] piv = new int[m];
            for (int i = 0; i < m; i++)
                piv[i] = i;
            int pivsign = 1;
            fixed (double* valuePointer = value, columnPointer = jColumn)
            {
                double* ptrValueEnd = valuePointer + value.Length;

                double* ptrColumn;
                double* ptrValue;
                double* ptrTemp;
                double* ptrTempEnd;
                // Outer loop.
                for (int j = 0; j < n; ++j)
                {
                    // Make a copy of the j-th column to localize memory, for cpu cache friendly
                    ptrValue = valuePointer + j;
                    ptrColumn = columnPointer;
                    for (; ptrValue < ptrValueEnd; ptrValue += n, ptrColumn++)
                        *ptrColumn = *ptrValue;

                    // Apply previous transformations.
                    for (int i = 0; i < m; ++i)
                    {
                        // Most of the time is spent in the following dot product.
                        int kmax = System.Math.Min(i, j);
                        double s = 0.0;
                        ptrTemp = ptrValue = valuePointer + i * n;
                        ptrColumn = columnPointer;
                        ptrTempEnd = columnPointer + kmax - 31;

                        while (ptrColumn < ptrTempEnd)
                        {
                            s += *ptrValue * *ptrColumn;
                            s += *(ptrValue + 1) * *(ptrColumn + 1);
                            s += *(ptrValue + 2) * *(ptrColumn + 2);
                            s += *(ptrValue + 3) * *(ptrColumn + 3);
                            s += *(ptrValue + 4) * *(ptrColumn + 4);
                            s += *(ptrValue + 5) * *(ptrColumn + 5);
                            s += *(ptrValue + 6) * *(ptrColumn + 6);
                            s += *(ptrValue + 7) * *(ptrColumn + 7);
                            s += *(ptrValue + 8) * *(ptrColumn + 8);
                            s += *(ptrValue + 9) * *(ptrColumn + 9);
                            s += *(ptrValue + 10) * *(ptrColumn + 10);
                            s += *(ptrValue + 11) * *(ptrColumn + 11);
                            s += *(ptrValue + 12) * *(ptrColumn + 12);
                            s += *(ptrValue + 13) * *(ptrColumn + 13);
                            s += *(ptrValue + 14) * *(ptrColumn + 14);
                            s += *(ptrValue + 15) * *(ptrColumn + 15);
                            s += *(ptrValue + 16) * *(ptrColumn + 16);
                            s += *(ptrValue + 17) * *(ptrColumn + 17);
                            s += *(ptrValue + 18) * *(ptrColumn + 18);
                            s += *(ptrValue + 19) * *(ptrColumn + 19);
                            s += *(ptrValue + 20) * *(ptrColumn + 20);
                            s += *(ptrValue + 21) * *(ptrColumn + 21);
                            s += *(ptrValue + 22) * *(ptrColumn + 22);
                            s += *(ptrValue + 23) * *(ptrColumn + 23);
                            s += *(ptrValue + 24) * *(ptrColumn + 24);
                            s += *(ptrValue + 25) * *(ptrColumn + 25);
                            s += *(ptrValue + 26) * *(ptrColumn + 26);
                            s += *(ptrValue + 27) * *(ptrColumn + 27);
                            s += *(ptrValue + 28) * *(ptrColumn + 28);
                            s += *(ptrValue + 29) * *(ptrColumn + 29);
                            s += *(ptrValue + 30) * *(ptrColumn + 30);
                            s += *(ptrValue + 31) * *(ptrColumn + 31);
                            ptrValue += 32;
                            ptrColumn += 32;
                        }
                        ptrTempEnd += 16;
                        if (ptrColumn < ptrTempEnd)
                        {
                            s += *ptrValue * *ptrColumn;
                            s += *(ptrValue + 1) * *(ptrColumn + 1);
                            s += *(ptrValue + 2) * *(ptrColumn + 2);
                            s += *(ptrValue + 3) * *(ptrColumn + 3);
                            s += *(ptrValue + 4) * *(ptrColumn + 4);
                            s += *(ptrValue + 5) * *(ptrColumn + 5);
                            s += *(ptrValue + 6) * *(ptrColumn + 6);
                            s += *(ptrValue + 7) * *(ptrColumn + 7);
                            s += *(ptrValue + 8) * *(ptrColumn + 8);
                            s += *(ptrValue + 9) * *(ptrColumn + 9);
                            s += *(ptrValue + 10) * *(ptrColumn + 10);
                            s += *(ptrValue + 11) * *(ptrColumn + 11);
                            s += *(ptrValue + 12) * *(ptrColumn + 12);
                            s += *(ptrValue + 13) * *(ptrColumn + 13);
                            s += *(ptrValue + 14) * *(ptrColumn + 14);
                            s += *(ptrValue + 15) * *(ptrColumn + 15);
                            ptrValue += 16;
                            ptrColumn += 16;
                        }
                        ptrTempEnd += 8;
                        if (ptrColumn < ptrTempEnd)
                        {
                            s += *ptrValue * *ptrColumn;
                            s += *(ptrValue + 1) * *(ptrColumn + 1);
                            s += *(ptrValue + 2) * *(ptrColumn + 2);
                            s += *(ptrValue + 3) * *(ptrColumn + 3);
                            s += *(ptrValue + 4) * *(ptrColumn + 4);
                            s += *(ptrValue + 5) * *(ptrColumn + 5);
                            s += *(ptrValue + 6) * *(ptrColumn + 6);
                            s += *(ptrValue + 7) * *(ptrColumn + 7);
                            ptrValue += 8;
                            ptrColumn += 8;
                        }
                        ptrTempEnd += 4;
                        if (ptrColumn < ptrTempEnd)
                        {
                            s += *ptrValue * *ptrColumn;
                            s += *(ptrValue + 1) * *(ptrColumn + 1);
                            s += *(ptrValue + 2) * *(ptrColumn + 2);
                            s += *(ptrValue + 3) * *(ptrColumn + 3);
                            ptrValue += 4;
                            ptrColumn += 4;
                        }
                        ptrTempEnd += 2;
                        if (ptrColumn < ptrTempEnd)
                        {
                            s += *ptrValue * *ptrColumn;
                            s += *(ptrValue + 1) * *(ptrColumn + 1);
                            ptrValue += 2;
                            ptrColumn += 2;
                        }
                        //ptrTempEnd += 1;
                        if (ptrColumn <= ptrTempEnd)
                            s += *ptrValue * *ptrColumn;
                        *(ptrTemp + j) = *(columnPointer + i) -= s;
                    }

                    // Find pivot and exchange if necessary.
                    int p = j;
                    for (int i = j + 1; i < m; ++i)
                    {
                        if (System.Math.Abs(jColumn[i]) > System.Math.Abs(jColumn[p]))
                            p = i;
                    }
                    ptrColumn = valuePointer + j * n;
                    if (p != j)
                    {
                        ptrValue = valuePointer + p * n;
                        ptrTemp = ptrColumn;
                        ptrTempEnd = ptrTemp + n;
                        for (; ptrTemp < ptrTempEnd; ptrValue++, ptrTemp++)
                        {
                            double t = *ptrValue;
                            *ptrValue = *ptrTemp;
                            *ptrTemp = t;
                        }

                        int k2 = piv[p];
                        piv[p] = piv[j];
                        piv[j] = k2;
                        pivsign = -pivsign;
                    }

                    // Compute multipliers.
                    double temp = *(ptrColumn + j);
                    if (j < m)
                        if (temp != 0.0)
                        {
                            ptrValue = valuePointer + (j + 1) * n + j;
                            for (; ptrValue < ptrValueEnd; ptrValue += n)
                                *ptrValue /= temp;
                        }
                }
            }
        }

        /// <summary>Cholesky algorithm for symmetric and positive definite matrix</summary>
        /// <param name="Arg">Square, symmetric matrix</param>
        /// <returns>Structure to access L and isspd flag</returns>
        unsafe public static void CholeskyDecomposition(int m, int n, double[][] A, double[][] L)
        {
            // Initialize.
            bool isspd = (m == n);
            // Main loop.
            for (int i = 0; i < n; i++)
            {
                double[] iRow = L[i];
                double d = 0.0;
                for (int ii = 0; ii < i; ii++)
                {
                    double[] iiRow = L[ii];
                    double s = 0.0;
                    for (int j = 0; j < ii; j++)
                        s += iiRow[j] * iRow[j];
                    iRow[ii] = s = (A[i][ii] - s) / iiRow[ii];
                    d = d + s * s;
                    isspd = isspd & (A[ii][i] == A[i][ii]);
                }
                d = A[i][i] - d;
                isspd = isspd & (d > 0.0);
                iRow[i] = System.Math.Sqrt(System.Math.Max(d, 0.0));
                for (int k = i + 1; k < n; k++)
                    iRow[k] = 0.0;
            }
        }
        public static double[][] CholeskyDecomposition(double[][] A)
        {
            double[][] L = new double[A.Length][];
            for (int i = 0; i < A.Length; i++)
            {
                L[i] = new double[i + 1]; //L - треугольная матрица, поэтому в i-ой строке i+1 элементов

                double temp;
                //Сначала вычисляем значения элементов слева от диагонального элемента,
                //так как эти значения используются при вычислении диагонального элемента.
                for (int j = 0; j < i; j++)
                {
                    temp = 0;
                    for (int k = 0; k < j; k++)
                    {
                        temp += L[i][k] * L[j][k];
                    }
                    L[i][j] = (A[i][j] - temp) / L[j][j];
                }

                //Находим значение диагонального элемента
                temp = A[i][i];
                for (int k = 0; k < i; k++)
                {
                    temp -= L[i][k] * L[i][k];
                }
                L[i][i] = Math.Sqrt(temp);
            }

            return L;
        }
        unsafe public static void CholeskyDecomposition2(int m, int n, double[] A, double[] L)
        {
            // Initialize.
            bool isspd = (m == n);
            // Main loop.
            for (int j = 0; j < n; j++)
            {
                double[] Lrowj = null/* L[j]*/;
                double d = 0.0;
                for (int k = 0; k < j; k++)
                {
                    double[] Lrowk = /*L[k]*/null;
                    double s = 0.0;
                    for (int i = 0; i < k; i++)
                    {
                        s += Lrowk[i] * Lrowj[i];
                    }
                    Lrowj[k] = s = (A[j * n + k] - s) / L[k * n + k];
                    d = d + s * s;
                    isspd = isspd & (A[k * n + j] == A[j * n + k]);
                }
                d = A[j * n + j] - d;
                isspd = isspd & (d > 0.0);
                L[j * n + j] = System.Math.Sqrt(System.Math.Max(d, 0.0));
                for (int k = j + 1; k < n; k++)
                {
                    L[j * n + k] = 0.0;
                }
            }
        }
        unsafe public static void QRDecompositionOld(int m, int n, double[][] QR, double[] rDiag)
        {
            if (rDiag == null)
                rDiag = new double[n];
            if (rDiag.Length != n)
                throw new ArgumentOutOfRangeException("rDiag");
            // Initialize.

            // Main loop.
            for (int j = 0; j < n; j++)
            {
                // Compute 2-norm of k-th column without under/overflow.
                double nrm = 0;
                for (int i = j; i < m; ++i)
                {
                    double b = QR[i][j];
                    if (Math.Abs(nrm) > Math.Abs(b))
                        nrm = Math.Abs(nrm) * Math.Sqrt(1 + Math.Pow(b / nrm, 2));
                    else
                        if (b != 0)
                            nrm = Math.Abs(b) * Math.Sqrt(1 + Math.Pow(nrm / b, 2));
                        else
                            nrm = 0.0;
                }

                if (nrm != 0.0)
                {
                    // Form k-th Householder vector.
                    if (QR[j][j] < 0)
                        nrm = -nrm;

                    for (int i = j; i < m; ++i)
                        QR[i][j] /= nrm;

                    QR[j][j] += 1.0;

                    // Apply transformation to remaining columns.
                    for (int jn = j + 1; jn < n; jn++)
                    {
                        double s = 0.0;
                        for (int i = j; i < m; i++)
                        {
                            s += QR[i][j] * QR[i][jn];
                        }
                        s = (-s) / QR[j][j];
                        for (int i = j; i < m; i++)
                        {
                            QR[i][jn] += s * QR[i][j];
                        }
                    }
                }
                rDiag[j] = -nrm;
            }
        }
        unsafe public static void QRDecomposition1(int m, int n, double[] QR, double[] rDiag)
        {
            if (rDiag == null)
                rDiag = new double[n];
            if (rDiag.Length != n)
                throw new ArgumentOutOfRangeException("rDiag");
            // Initialize.

            // Main loop.
            for (int k = 0; k < n; k++)
            {
                // Compute 2-norm of k-th column without under/overflow.
                double nrm = 0;
                for (int i = k; i < m; i++)
                    nrm = Hypot(nrm, QR[i * n + k]);

                if (nrm != 0.0)
                {
                    // Form k-th Householder vector.
                    if (QR[k * n + k] < 0)
                        nrm = -nrm;

                    for (int i = k; i < m; i++)
                        QR[i * n + k] /= nrm;

                    QR[k * n + k] += 1.0;

                    // Apply transformation to remaining columns.
                    for (int j = k + 1; j < n; j++)
                    {
                        double s = 0.0;
                        for (int i = k; i < m; i++)
                        {
                            s += QR[i * n + k] * QR[i * n + j];
                        }
                        s = (-s) / QR[k * n + k];
                        for (int i = k; i < m; i++)
                        {
                            QR[i * n + j] += s * QR[i * n + k];
                        }
                    }
                }
                rDiag[k] = -nrm;
            }
        }
        unsafe public static void QRDecomposition2(int m, int n, double[] value, double[] rDiag)
        {
            if (rDiag == null)
                rDiag = new double[n];
            if (rDiag.Length != n)
                throw new ArgumentOutOfRangeException("rDiag");
            // Initialize.

            fixed (double* valuePointer = value)
            {
                double* ptrValueEnd = valuePointer + value.Length;

                double* ptrValue;
                double* ptrColumn;
                double* ptrTempEnd;

                // Main loop.
                for (int k = 0; k < n; k++)
                {
                    // Compute 2-norm of k-th column without under/overflow.
                    double nrm = 0;
                    for (int i = k; i < m; i++)
                        nrm = Hypot(nrm, value[i * n + k]);

                    if (nrm != 0.0)
                    {
                        // Form k-th Householder vector.
                        if (value[k * n + k] < 0)
                            nrm = -nrm;

                        for (int i = k; i < m; i++)
                            value[i * n + k] /= nrm;

                        value[k * n + k] += 1.0;

                        // Apply transformation to remaining columns.
                        for (int j = k + 1; j < n; j++)
                        {
                            double s = 0.0;

                            ptrValue = valuePointer + k * n + k;
                            ptrColumn = valuePointer + k * n + j;
                            ptrTempEnd = valuePointer + m * n + j;
                            for (; ptrColumn < ptrTempEnd; ptrValue += n, ptrColumn += n)
                                s += *ptrValue * *ptrColumn;
                            s = (-s) / value[k * n + k];

                            ptrValue = valuePointer + k * n + k;
                            ptrColumn = valuePointer + k * n + j;
                            ptrTempEnd = valuePointer + m * n + j;
                            for (; ptrColumn < ptrTempEnd; ptrValue += n, ptrColumn += n)
                                *ptrColumn += s * *ptrValue;
                        }
                    }
                    rDiag[k] = -nrm;
                }
            }
        }
        /// <summary>Least squares solution of A*X = B</summary>
        /// <param name="B">   A Matrix with as many rows as A and any number of columns.
        /// </param>
        /// <returns>     X that minimizes the two norm of Q*R*X-B.
        /// </returns>
        /// <exception cref="System.ArgumentException"> Matrix row dimensions must agree.
        /// </exception>
        /// <exception cref="System.SystemException"> Matrix is rank deficient.
        /// </exception>
        unsafe public static double[][] SolveQR(int m, int n, double[][] QR, int mB, int nB, double[][] B, double[] rDiag)
        {
            if (mB != m)
                throw new System.ArgumentException("GeneralMatrix row dimensions must agree.");
            if (!FullRank(rDiag))
                throw new System.SystemException("Matrix is rank deficient.");


            // Compute Y = transpose(Q)*B
            for (int k = 0; k < n; k++)
            {
                for (int j = 0; j < nB; j++)
                {
                    double s = 0.0;
                    for (int i = k; i < m; i++)
                    {
                        s += QR[i][k] * B[i][j];
                    }
                    s = (-s) / QR[k][k];
                    for (int i = k; i < m; i++)
                    {
                        B[i][j] += s * QR[i][k];
                    }
                }
            }
            // Solve R*X = Y;
            for (int k = n - 1; k >= 0; k--)
            {
                for (int j = 0; j < nB; j++)
                {
                    B[k][j] /= rDiag[k];
                }
                for (int i = 0; i < k; i++)
                {
                    for (int j = 0; j < nB; j++)
                    {
                        B[i][j] -= B[k][j] * QR[i][k];
                    }
                }
            }
            double[][] returnValue = new double[n][];
            for (int i = 0; i < n; i++)
                returnValue[i] = new double[nB];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= nB; j++)
                    returnValue[i][j] = B[i][j];
            }

            return returnValue;
        }
        #endregion Old
        #region Copy
        #region double
        unsafe public static void Copy(int m1, int n1, CsrMatrix<double> value1, int m2, int n2, CsrMatrix<double> value2, int rowLength, int columnLength)
        {





        }
        #endregion double
        #region Complex
        #endregion Complex
        #endregion Copy

        /// <summary>
        /// Remove selected columns
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="numbers"></param>
        /// <returns></returns>
        unsafe public static CsrMatrix<double> RemoveColumns(CsrMatrix<double> value1, int[] numbers)
        {
            int m = value1.RowsCount;
            int n1 = value1.ColumnsCount;
            int[] renums = new int[n1];
            for (int i = 0; i < numbers.Length; ++i)
            {
                int item = numbers[i];
                if (item >= n1 || item < 0)
                    throw new ArgumentOutOfRangeException("numbers");
                renums[item] = -1;
            }
            int n = 0;
            for (int i = 0; i < n1; ++i)
            {
                if (renums[i] != -1)
                    renums[i] = n++;
            }

            CsrMatrix<double> returnValue = new CsrMatrix<double>(value1.m_RowsMapping[value1.m_RowsCount], m, n);

            fixed (double* values1Pointer = value1.m_Values, valuesPointer = returnValue.m_Values)
            fixed (int* columns1Pointer = value1.m_Columns, columnsPointer = returnValue.m_Columns)
            {
                int index = 0;
                int index1;
                int end1;
                int column1;
                for (int i = 0; i < m; ++i)
                {
                    index1 = value1.m_RowsMapping[i];
                    end1 = value1.m_RowsMapping[i + 1];
                    while (index1 != end1)
                    {
                        column1 = *(columns1Pointer + index1);
                        if (renums[column1] != -1)
                        {
                            *(valuesPointer + index) = *(values1Pointer + index1);
                            *(columnsPointer + index) = renums[column1];
                            index++;
                        }
                        index1++;
                    }
                    returnValue.m_RowsMapping[i + 1] = index;
                }
            }
            return returnValue;
        }
        unsafe public static int[] EmptyColumns(CsrMatrix<double> value)
        {
            int m = value.RowsCount;
            int n = value.ColumnsCount;
            int[] renums = new int[n];
            int[] returnValue = null;
            fixed (double* valuesPointer = value.m_Values)
            fixed (int* columnsPointer = value.m_Columns, renumsPointer = renums)
            {
                int start;
                int end;
                for (int i = 0; i < m; ++i)
                {
                    start = value.m_RowsMapping[i];
                    end = value.m_RowsMapping[i + 1];
                    while (start != end)
                    {
                        if (valuesPointer[start] != 0)
                            renumsPointer[columnsPointer[start]] = 1;
                        start++;
                    }
                }
                int index = 0;
                for (int i = 0; i < n; ++i)
                    if (renumsPointer[i] == 0)
                        index++;
                returnValue = new int[index];
                index = 0;
                for (int i = 0; i < n; ++i)
                    if (renumsPointer[i] == 0)
                        returnValue[index++] = i;
            }
            return returnValue;
        }
        //unsafe public static VerySparseMatrix<double> RemoveColumns(VerySparseMatrix<double> value1, int[] numbers)
        //{
        //    VerySparseMatrix<double> temp = Transpose(value1);
            
        //    double[][] newValues = new double[temp.RowCount - numbers.Length][];
        //    int[][] newNexts = new int[temp.RowCount - numbers.Length][];
        //    int[][] newIndexes = new int[temp.RowCount - numbers.Length][];
        //    int[] newHeads = new int[temp.RowCount - numbers.Length];

        //    for (int i = 0, j = 0; i < temp.RowCount; ++i)
        //    {
        //        bool flag = false;
        //        foreach (int number in numbers)
        //        {
        //            if (number == i)
        //                flag = true;
        //        }
        //        if (flag)
        //            continue;
        //        newValues[j] = temp.m_Values[i];
        //        newNexts[j] = temp.m_Nexts[i];
        //        newIndexes[j] = temp.m_Indexes[i];
        //        newHeads[j] = temp.m_Heads[i];
        //        j++;
        //    }
        //    temp.m_Values = newValues;
        //    temp.m_Nexts = newNexts;
        //    temp.m_Indexes = newIndexes;
        //    temp.m_Heads = newHeads;
        //    temp.m_RowCount = newHeads.Length;
        //    return Transpose(temp);
        //}
        #region Concat
        #region double
        unsafe public static CsrMatrix<double> GorizontalConcatination(CsrMatrix<double> value1, CsrMatrix<double> value2)
        {
            int m = value1.RowsCount;
            int n1 = value1.ColumnsCount;
            int n2 = value2.ColumnsCount;
            int n = n1 + n2;
            if (value2.RowsCount != m)
                throw new Exception("Rows counts of first and second matrices not equals!");
            CsrMatrix<double> returnValue = new CsrMatrix<double>(value1.m_RowsMapping[value1.m_RowsCount] + value2.m_RowsMapping[value2.m_RowsCount], m, n);
            fixed (double* values1Pointer = value1.m_Values, values2Pointer = value2.m_Values, valuesPointer = returnValue.m_Values)
            fixed (int* columns1Pointer = value1.m_Columns, columns2Pointer = value2.m_Columns, columnsPointer = returnValue.m_Columns)
            {
                int index = 0;
                int index1;
                int end1;
                int index2;
                int end2;

                for (int i = 0; i < m; ++i)
                {
                    index1 = value1.m_RowsMapping[i];
                    end1 = value1.m_RowsMapping[i + 1];
                    index2 = value2.m_RowsMapping[i];
                    end2 = value2.m_RowsMapping[i + 1];
                    while (index1 != end1)
                    {
                        *(valuesPointer + index) = *(values1Pointer + index1);
                        *(columnsPointer + index) = *(columns1Pointer + index1);
                        index1++;
                        index++;
                    }
                    while (index2 != end2)
                    {
                        *(valuesPointer + index) = *(values2Pointer + index2);
                        *(columnsPointer + index) = *(columns2Pointer + index2) + n1;
                        index2++;
                        index++;
                    }
                    returnValue.m_RowsMapping[i + 1] = index;
                }
            }
            return returnValue;
        }
        unsafe public static CsrMatrix<double> VerticalConcatination(CsrMatrix<double> value1, CsrMatrix<double> value2)
        {
            int m = value1.RowsCount;
            int n = value1.ColumnsCount;
            CsrMatrix<double> realMatrix = new CsrMatrix<double>(value1.Capacity, m, n);

            return realMatrix;
        }
        #endregion double
        #endregion Concat
        #endregion Public methods
        #region Internal methods
        #endregion Internal methods
        #region Private methods
        unsafe private static void ComplexDivide(double* ptrValue1, double* ptrValue2, double* ptrResult)
        {
            double real1 = *ptrValue1;
            double imaginary1 = *(ptrValue1 + 1);
            double real2 = *ptrValue2;
            double imaginary2 = *(ptrValue2 + 1);
            double temp1, temp2;
            if (Math.Abs(imaginary2) < Math.Abs(real2))
            {
                temp1 = imaginary2 / real2;
                temp2 = real2 + imaginary2 * temp1;
                *ptrResult = (real1 + imaginary1 * temp1) / temp2;
                *(ptrResult + 1) = (imaginary1 - real1 * temp1) / temp2;
                return;
            }
            temp1 = real2 / imaginary2;
            temp2 = imaginary2 + real2 * temp1;
            *ptrResult = (imaginary1 + real1 * temp1) / temp2;
            *(ptrResult + 1) = (-real1 + imaginary1 * temp1) / temp2;
        }
        /// <summary>Is the matrix full rank?</summary>
        /// <returns>     true if R, and hence A, has full rank.
        /// </returns>
        public static bool FullRank(double[] rDiag)
        {
            for (int j = 0; j < rDiag.Length; j++)
                if (rDiag[j] == 0)
                    return false;
            return true;
        }
        public static double Hypot(double a, double b)
        {
            double r;
            if (Math.Abs(a) > Math.Abs(b))
            {
                r = b / a;
                r = Math.Abs(a) * Math.Sqrt(1 + r * r);
            }
            else
                if (b != 0)
                {
                    r = a / b;
                    r = Math.Abs(b) * Math.Sqrt(1 + r * r);
                }
                else
                {
                    r = 0.0;
                }
            return r;
        }
        #endregion Private methods
        #region  Events, overrides
        #endregion Events, overrides
        #endregion Methods
    }
}
#endregion Working namespace
