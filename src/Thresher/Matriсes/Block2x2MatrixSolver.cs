#region License
//Copyright (c) 2009, Alan Spelnikov
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
using System.Globalization;
using Th = AIlins.Thresher.ThrowHelper<AIlins.Thresher.Block2x2>;
#endregion Using namespaces
#region Working namespace
namespace AIlins.Thresher
{
    public class Block2x2MatrixSolver : MatrixSolver<Block2x2>
    {
        #region Classes, structures, enums
        #endregion Classes, structures, enums
        #region Constructors
        public Block2x2MatrixSolver(ArraySolver<Block2x2> arraySolver = null)
            : base(arraySolver)
        {
        }
        #endregion Constructors
        #region Variables
        #endregion Variables
        #region Fields
        #endregion Fields
        #region Methods
        #region Public methods
        #endregion Public methods
        #region Internal methods
        #endregion Internal methods
        #region Private methods
        #endregion Private methods
        #region  Events, overrides 
        #region Addition
        unsafe public override void CSRMatrixMatrixAddition(int m, int n, Block2x2[] value1, int[] value1Columns, int[] value1RowsMapping, Block2x2[] value2, int[] value2Columns, int[] value2RowsMapping, ref Block2x2[] result, ref int[] resultColumns, ref int[] resultRowsMapping)
        {
            Th.ThrowCSRMatrixMatrix(m, n, value1, value1Columns, value1RowsMapping, value2, value2Columns, value2RowsMapping, ref result, ref resultColumns, ref resultRowsMapping);
            Fixed resultFixed = result;
            Fixed resultColumnsFixed = resultColumns;
            try
            {
                Block2x2* resultPtr = (Block2x2*)resultFixed;
                int* resultColumnsPtr = (int*)resultColumnsFixed.Fix();
                fixed (Block2x2* value1Ptr = value1, value2Ptr = value2)
                fixed (int* value1ColumnsPtr = value1Columns, value2ColumnsPtr = value2Columns)
                {
                    int head = 0, index1, end1, index2, end2, columns1, columns2;
                    resultRowsMapping[0] = 0;
                    for (int i = 0; i < m; ++i)
                    {
                        index1 = value1RowsMapping[i];
                        end1 = value1RowsMapping[i + 1];
                        index2 = value2RowsMapping[i];
                        end2 = value2RowsMapping[i + 1];

                        while (index1 != end1 && index2 != end2)
                        {
                            if ((columns1 = value1ColumnsPtr[index1]) == (columns2 = value2ColumnsPtr[index2]))
                            {
                                resultPtr[head] = value1Ptr[index1] + value2Ptr[index2];
                                resultColumnsPtr[head] = columns1;
                                index1++;
                                index2++;
                                head++;
                            }
                            else
                                if (columns1 > columns2)
                                {
                                    resultPtr[head] = value2Ptr[index2];
                                    resultColumnsPtr[head] = columns2;
                                    index2++;
                                    head++;
                                }
                                else
                                {
                                    resultPtr[head] = value1Ptr[index1];
                                    resultColumnsPtr[head] = columns1;
                                    index1++;
                                    head++;
                                }
                            if (head == result.Length)
                            {
                                resultColumnsFixed.Free();
                                resultFixed.Free();
                                int newCapacity = result.Length * 2;
                                Block2x2[] newResult = new Block2x2[newCapacity];
                                int[] newResultColumns = new int[newCapacity];
                                Array.Copy(result, newResult, result.Length);
                                Array.Copy(resultColumns, newResultColumns, resultColumns.Length);
                                resultFixed = result = newResult;
                                resultColumnsFixed = resultColumns = newResultColumns;
                                resultPtr = (Block2x2*)resultFixed.Fix();
                                resultColumnsPtr = (int*)resultColumnsFixed.Fix();
                            }
                        }
                        resultRowsMapping[i + 1] = head;
                    }
                }
            }
            finally
            {
                resultFixed.Free();
                resultColumnsFixed.Free();
            }
        }
        #endregion Addition
        #region Substraction
        unsafe public override void CSRMatrixMatrixSubstraction(int m, int n, Block2x2[] value1, int[] value1Columns, int[] value1RowsMapping, Block2x2[] value2, int[] value2Columns, int[] value2RowsMapping, ref Block2x2[] result, ref int[] resultColumns, ref int[] resultRowsMapping)
        {
            Th.ThrowCSRMatrixMatrix(m, n, value1, value1Columns, value1RowsMapping, value2, value2Columns, value2RowsMapping, ref result, ref resultColumns, ref resultRowsMapping);
            Fixed resultFixed = result;
            Fixed resultColumnsFixed = resultColumns;
            try
            {
                Block2x2* resultPtr = (Block2x2*)resultFixed;
                int* resultColumnsPtr = (int*)resultColumnsFixed.Fix();
                fixed (Block2x2* values1Ptr = value1, values2Ptr = value2)
                fixed (int* value1ColumnsPtr = value1Columns, value2ColumnsPtr = value2Columns)
                {
                    int head = 0, index1, end1, index2, end2, columns1, columns2;
                    resultRowsMapping[0] = 0;
                    for (int i = 0; i < m; ++i)
                    {
                        index1 = value1RowsMapping[i];
                        end1 = value1RowsMapping[i + 1];
                        index2 = value2RowsMapping[i];
                        end2 = value2RowsMapping[i + 1];

                        while (index1 != end1 && index2 != end2)
                        {
                            if ((columns1 = value1ColumnsPtr[index1]) == (columns2 = value2ColumnsPtr[index2]))
                            {
                                resultPtr[head] = values1Ptr[index1] - values2Ptr[index2];
                                resultColumnsPtr[head] = columns1;
                                index1++;
                                index2++;
                                head++;
                            }
                            else
                                if (columns1 > columns2)
                                {
                                    resultPtr[head] = -values2Ptr[index2];
                                    resultColumnsPtr[head] = columns2;
                                    index2++;
                                    head++;
                                }
                                else
                                {
                                    resultPtr[head] = values1Ptr[index1];
                                    resultColumnsPtr[head] = columns1;
                                    index1++;
                                    head++;
                                }
                            if (head == result.Length)
                            {
                                resultColumnsFixed.Free();
                                resultFixed.Free();
                                int newCapacity = result.Length * 2;
                                Block2x2[] newResult = new Block2x2[newCapacity];
                                int[] newResultColumns = new int[newCapacity];
                                Array.Copy(result, newResult, result.Length);
                                Array.Copy(resultColumns, newResultColumns, resultColumns.Length);
                                resultFixed = result = newResult;
                                resultColumnsFixed = resultColumns = newResultColumns;
                                resultPtr = (Block2x2*)resultFixed.Fix();
                                resultColumnsPtr = (int*)resultColumnsFixed.Fix();
                            }
                        }
                        resultRowsMapping[i + 1] = 0;
                    }
                }
            }
            finally
            {
                resultFixed.Free();
                resultColumnsFixed.Free();
            }
        }
        #endregion Substraction
        #region Multiply
        //public static FullMatrix<Block2x2> Multiply(FullMatrix<Block2x2> value1, FullMatrix<Block2x2> value2)
        //{
        //    int m1 = value1.m_RowsCount;
        //    int n1 = value1.m_ColumnsCount;
        //    int m2 = value2.m_RowsCount;
        //    int n2 = value2.m_ColumnsCount;
        //    if (n1 != m2)
        //        throw new Exception("Rows count of first matrix not equal to columns count of second matrix!");
        //    Block2x2[] tempResult = new Block2x2[m1 * n2];
        //    Multiply(m1, n1, value1.m_Values, m2, n2, value2.m_Values, tempResult);

        //    FullMatrix<Block2x2> result = new FullMatrix<Block2x2>();
        //    result.m_RowsCount = m1;
        //    result.m_ColumnsCount = n2;
        //    result.m_Values = tempResult;
        //    return result;
        //}
        //unsafe public static void Multiply(int m1, int n1, Block2x2[] value1, int m2, int n2, Block2x2[] value2, Block2x2[] result)
        //{
        //    if (n1 != m2)
        //        throw new Exception("Rows count of first matrix not equal to columns count of second matrix!");
        //    Block2x2[] value2Transpose = new Block2x2[value2.Length];
        //    Transpose(m2, n2, value2, value2Transpose);
        //    fixed (Block2x2* value1Pointer = value1, value2tPointer = value2Transpose, resultPointer = result)
        //    {
        //        Block2x2* ptrValue;
        //        Block2x2* ptrValue2 = value2tPointer;
        //        Block2x2* ptrResult = resultPointer;
        //        Block2x2* ptrEnd = resultPointer + result.Length;
        //        Block2x2* ptrValueEnd;
        //        // Offsets in matrices rows
        //        int value1Offset = 0;
        //        int value2Offset = 0;
        //        // Summators
        //        Block2x2 sum1;
        //        Block2x2 sum2;
        //        Block2x2 sum3;
        //        Block2x2 sum4;
        //        // Main loop, row changes
        //        for (; ptrResult < ptrEnd; ++ptrResult, value2Offset += m2)
        //        {
        //            if (value2Offset >= result.Length)
        //            {
        //                value2Offset = 0;
        //                value1Offset += n1;
        //            }
        //            ptrValue = value1Pointer + value1Offset;
        //            ptrValueEnd = ptrValue + n1 - 31;
        //            ptrValue2 = value2tPointer + value2Offset;
        //            sum1 = default(Block2x2);
        //            sum2 = default(Block2x2);
        //            sum3 = default(Block2x2);
        //            sum4 = default(Block2x2);
        //            // Internal loop, pointers for row values
        //            while (ptrValue < ptrValueEnd)
        //            {
        //                sum1 += *ptrValue * *ptrValue2
        //                + *(ptrValue + 1) * *(ptrValue2 + 1)
        //                + *(ptrValue + 2) * *(ptrValue2 + 2)
        //                + *(ptrValue + 3) * *(ptrValue2 + 3)
        //                + *(ptrValue + 4) * *(ptrValue2 + 4)
        //                + *(ptrValue + 5) * *(ptrValue2 + 5)
        //                + *(ptrValue + 6) * *(ptrValue2 + 6)
        //                + *(ptrValue + 7) * *(ptrValue2 + 7);
        //                sum2 += *(ptrValue + 8) * *(ptrValue2 + 8)
        //                + *(ptrValue + 9) * *(ptrValue2 + 9)
        //                + *(ptrValue + 10) * *(ptrValue2 + 10)
        //                + *(ptrValue + 11) * *(ptrValue2 + 11)
        //                + *(ptrValue + 12) * *(ptrValue2 + 12)
        //                + *(ptrValue + 13) * *(ptrValue2 + 13)
        //                + *(ptrValue + 14) * *(ptrValue2 + 14)
        //                + *(ptrValue + 15) * *(ptrValue2 + 15);
        //                sum3 += *(ptrValue + 16) * *(ptrValue2 + 16)
        //                + *(ptrValue + 17) * *(ptrValue2 + 17)
        //                + *(ptrValue + 18) * *(ptrValue2 + 18)
        //                + *(ptrValue + 19) * *(ptrValue2 + 19)
        //                + *(ptrValue + 20) * *(ptrValue2 + 20)
        //                + *(ptrValue + 21) * *(ptrValue2 + 21)
        //                + *(ptrValue + 22) * *(ptrValue2 + 22)
        //                + *(ptrValue + 23) * *(ptrValue2 + 23);
        //                sum4 += *(ptrValue + 24) * *(ptrValue2 + 24)
        //                + *(ptrValue + 25) * *(ptrValue2 + 25)
        //                + *(ptrValue + 26) * *(ptrValue2 + 26)
        //                + *(ptrValue + 27) * *(ptrValue2 + 27)
        //                + *(ptrValue + 28) * *(ptrValue2 + 28)
        //                + *(ptrValue + 29) * *(ptrValue2 + 29)
        //                + *(ptrValue + 30) * *(ptrValue2 + 30)
        //                + *(ptrValue + 31) * *(ptrValue2 + 31);
        //                ptrValue += 32;
        //                ptrValue2 += 32;
        //            }
        //            ptrValueEnd += 16;
        //            if (ptrValue < ptrValueEnd)
        //            {
        //                sum1 += *ptrValue * *ptrValue2
        //                + *(ptrValue + 1) * *(ptrValue2 + 1)
        //                + *(ptrValue + 2) * *(ptrValue2 + 2)
        //                + *(ptrValue + 3) * *(ptrValue2 + 3)
        //                + *(ptrValue + 4) * *(ptrValue2 + 4)
        //                + *(ptrValue + 5) * *(ptrValue2 + 5)
        //                + *(ptrValue + 6) * *(ptrValue2 + 6)
        //                + *(ptrValue + 7) * *(ptrValue2 + 7);
        //                sum2 += *(ptrValue + 8) * *(ptrValue2 + 8)
        //                + *(ptrValue + 9) * *(ptrValue2 + 9)
        //                + *(ptrValue + 10) * *(ptrValue2 + 10)
        //                + *(ptrValue + 11) * *(ptrValue2 + 11)
        //                + *(ptrValue + 12) * *(ptrValue2 + 12)
        //                + *(ptrValue + 13) * *(ptrValue2 + 13)
        //                + *(ptrValue + 14) * *(ptrValue2 + 14)
        //                + *(ptrValue + 15) * *(ptrValue2 + 15);
        //                ptrValue += 16;
        //                ptrValue2 += 16;
        //            }
        //            ptrValueEnd += 8;
        //            if (ptrValue < ptrValueEnd)
        //            {
        //                sum1 += *ptrValue * *ptrValue2
        //                + *(ptrValue + 1) * *(ptrValue2 + 1)
        //                + *(ptrValue + 2) * *(ptrValue2 + 2)
        //                + *(ptrValue + 3) * *(ptrValue2 + 3);
        //                sum2 += *(ptrValue + 4) * *(ptrValue2 + 4)
        //                + *(ptrValue + 5) * *(ptrValue2 + 5)
        //                + *(ptrValue + 6) * *(ptrValue2 + 6)
        //                + *(ptrValue + 7) * *(ptrValue2 + 7);
        //                ptrValue += 8;
        //                ptrValue2 += 8;
        //            }
        //            ptrValueEnd += 4;
        //            if (ptrValue < ptrValueEnd)
        //            {
        //                sum1 += *ptrValue * *ptrValue2
        //                + *(ptrValue + 1) * *(ptrValue2 + 1)
        //                + *(ptrValue + 2) * *(ptrValue2 + 2)
        //                + *(ptrValue + 3) * *(ptrValue2 + 3);
        //                ptrValue += 4;
        //                ptrValue2 += 4;
        //            }
        //            ptrValueEnd += 2;
        //            if (ptrValue < ptrValueEnd)
        //            {
        //                sum1 += *ptrValue * *ptrValue2
        //                 + *(ptrValue + 1) * *(ptrValue2 + 1);
        //                ptrValue += 2;
        //                ptrValue2 += 2;
        //            }
        //            if (ptrValue <= ptrValueEnd)
        //                sum1 += *ptrValue * *ptrValue2;

        //            *ptrResult = sum1 + sum2 + sum3 + sum4;
        //        }
        //    }
        //}

        //unsafe public static FullMatrix<Block2x2> Multiply(CSRMatrix<Block2x2> value1, FullMatrix<Block2x2> value2)
        //{
        //    int m1 = value1.RowsCount;
        //    int n1 = value1.ColumnsCount;
        //    int m2 = value2.m_RowsCount;
        //    int n2 = value2.m_ColumnsCount;
        //    if (n1 != m2)
        //        throw new Exception("Rows count of first matrix not equal to columns count of second matrix!");

        //    Block2x2[] tempResult = new Block2x2[m1 * n2];
        //    Block2x2[] tempValues2 = new Block2x2[m2 * n2];
        //    Transpose(m2, n2, value2.m_Values, tempValues2);

        //    int[] rowIndex1 = value1.m_RowsMapping;

        //    fixed (Block2x2* values1Pointer = value1.m_Values, values2Pointer = tempValues2)
        //    fixed (int* columns1Pointer = value1.m_Columns)
        //    {
        //        int index;
        //        int end;
        //        // Main loop -- optimize for sparse matrix-vector multiply
        //        for (int j = 0; j < n2; ++j)
        //        {
        //            Block2x2* startValue2 = (values2Pointer + j * m2);
        //            Block2x2 item;
        //            for (int i = 0; i < m1; ++i)
        //            {
        //                item = default(Block2x2);
        //                index = rowIndex1[i];
        //                end = rowIndex1[i + 1];
        //                while (index != end)
        //                {
        //                    item += *(values1Pointer + index) * *(startValue2 + *(columns1Pointer + index));
        //                    index++;
        //                }
        //                tempResult[i * n2 + j] = item;
        //            }
        //        }
        //    }
        //    FullMatrix<Block2x2> returnValue = new FullMatrix<Block2x2>();
        //    returnValue.m_RowsCount = m1;
        //    returnValue.m_ColumnsCount = n2;
        //    returnValue.m_Values = tempResult;
        //    return returnValue;
        //}
        unsafe public override void FullMatrixVectorMultiply(int m, int n, Block2x2[] value1, Block2x2[] value2, Block2x2[] result)
        {
            Th.ThrowIfNull(value1, "value1");
            Th.ThrowIfNull(value2, "value2");
            Th.ThrowIfNull(result, "result");
            if (n != value2.Length)
                throw new ArgumentOutOfRangeException("Rows count of matrix not equal to length of vector!");
            if (m * n != value1.Length)
                throw new ArgumentOutOfRangeException("value1");
            Block2x2[] resultTemp = null;
            if (result == value1 || result == value2)
            {
                resultTemp = result;
                result = new Block2x2[result.Length];
            }
            fixed (Block2x2* value1Ptr = value1, value2Ptr = value2, resultPtr = result)
            {
                int value1End;
                Block2x2 item;
                for (int i = 0; i < m; ++i)
                {
                    item = 0;
                    value1End = n * (i + 1);
                    for (int value1Index = n * i, j = 0; value1Index < value1End; ++value1Index, ++j)
                        item += value1Ptr[value1Index] * value2Ptr[j];
                    resultPtr[i] = item;
                }
            }
            if (resultTemp != null)
                Array.Copy(result, resultTemp, result.Length);
        }
        unsafe public override void CSRMatrixVectorMultiply(int m, int n, Block2x2[] value1, int[] value1Columns, int[] value1RowsMapping, Block2x2[] value2, Block2x2[] result)
        {
            Th.ThrowIfCSRMatrix(m, n, value1, value1Columns, value1RowsMapping, "value1");
            Th.ThrowIfNull(value2, "value2");
            Th.ThrowIfNull(result, "result");
            if (n != value2.Length)
                throw new ArgumentOutOfRangeException("Columns count of value1 matrix not equal to length of value2 vector!");
            if (m != result.Length)
                throw new ArgumentOutOfRangeException("Rows count of value1 matrix not equal to length of result vector!");
            Block2x2[] resultTemp = null;
            if (result == value1 || result == value2)
            {
                resultTemp = result;
                result = new Block2x2[result.Length];
            }
            fixed (Block2x2* value1Ptr = value1, value2Ptr = value2, resultPtr = result)
            fixed (int* value1ColumnsPtr = value1Columns, value1RowsMappingPtr = value1RowsMapping)
            {
                int value1End;
                Block2x2 item;
                for (int i = 0; i < m; ++i)
                {
                    item = 0;
                    value1End = value1RowsMappingPtr[i + 1];
                    for (int value1Index = value1RowsMappingPtr[i]; value1Index < value1End; ++value1Index)
                        item += value1Ptr[value1Index] * value2Ptr[value1ColumnsPtr[value1Index]];
                    resultPtr[i] = item;
                }
            }
            if (resultTemp != null)
                Array.Copy(result, resultTemp, result.Length);
        }
        unsafe public override void FullMatrixVectorElementsMultiply(int m, int n, Block2x2[] value1, Block2x2[] value2, Block2x2[] result, bool isVertical = false)
        {
            Th.ThrowIfNull(value1, "value1");
            Th.ThrowIfNull(value2, "value2");
            if (result == null)
                result = value1;
            if (m < 0 || n < 0)
                throw new ArgumentOutOfRangeException("m or n is less than zero!");
            if (m * n != value1.Length)
                throw new ArgumentOutOfRangeException("value1");
            if (m * n != result.Length)
                throw new ArgumentOutOfRangeException("Rows count of value1 matrix not equal to length of result vector!");
            fixed (Block2x2* value1Ptr = value1, value2Ptr = value2, resultPtr = result)
            {
                int value1End;
                if (isVertical)
                {
                    if (value2.Length != m)
                        throw new Exception("Rows count of first matrix not equal to vector elements count!");
                    for (int i = 0; i < m; ++i)
                    {
                        Block2x2 item = *(value2Ptr + i);
                        value1End = i * (n + 1);
                        for (int j = i * n; i < value1End; ++j)
                            *(resultPtr + j) = *(value1Ptr + j) * item;
                    }
                }
                else
                {
                    if (value2.Length != n)
                        throw new Exception("Columns count of first matrix not equal to vector elements count!");
                    for (int i = 0; i < m; ++i)
                    {
                        value1End = i * (n + 1);
                        for (int j = i * n, k = 0; i < value1End; ++j, ++k)
                            *(resultPtr + j) = *(value1Ptr + j) * *(value2Ptr + k);
                    }
                }
            }
        }
        unsafe public override void CSRMatrixVectorElementsMultiply(int m, int n, Block2x2[] value1, int[] value1Columns, int[] value1RowsMapping, Block2x2[] value2, Block2x2[] result, bool isVertical = false)
        {
            Th.ThrowIfCSRMatrix(m, n, value1, value1Columns, value1RowsMapping, "value1");
            Th.ThrowIfNull(value2, "value2");
            Th.ThrowIfNull(result, "result");
            Block2x2[] resultTemp = null;
            if (result == value1 || result == value2)
            {
                resultTemp = result;
                result = new Block2x2[result.Length];
            }
            fixed (Block2x2* value1Ptr = value1, value2Ptr = value2, resultPtr = result)
            fixed (int* value1ColumnsPtr = value1Columns)
            {
                int index;
                int end;
                if (isVertical)
                {
                    if (value2.Length != m)
                        throw new Exception("Rows count of value1 matrix not equal to length value2 vector!");
                    for (int i = 0; i < m; ++i)
                    {
                        Block2x2 item = *(value2Ptr + i);
                        index = value1RowsMapping[i];
                        end = value1RowsMapping[i + 1];
                        while (index != end)
                        {
                            *(resultPtr + index) = *(value1Ptr + index) * item;
                            index++;
                        }
                    }
                }
                else
                {
                    if (value2.Length != n)
                        throw new Exception("Columns count of value1 matrix not equal to length of value2 vector!");
                    for (int i = 0; i < m; ++i)
                    {
                        index = value1RowsMapping[i];
                        end = value1RowsMapping[i + 1];
                        while (index != end)
                        {
                            *(resultPtr + index) = *(value1Ptr + index) * *(value2Ptr + *(value1ColumnsPtr + index));
                            index++;
                        }
                    }

                }
            }
            if (resultTemp != null)
                Array.Copy(result, resultTemp, result.Length);
        }
        unsafe public override void FullMatrixMatrixMultiply(int m, int n1, Block2x2[] value1, int n2, Block2x2[] value2, Block2x2[] result)
        {
            if (m < 0 || n1 < 0 || n2 < 0)
                throw new ArgumentOutOfRangeException("m or n1 or n2 less than zero");
            Th.ThrowIfNull(value1, "value1");
            if (m * n1 != value1.Length)
                throw new ArgumentOutOfRangeException("value1");
            Th.ThrowIfNull(value2, "value2");
            if (n1 * n2 != value2.Length)
                throw new ArgumentOutOfRangeException("value2");
            Th.ThrowIfNull(result, "result");
            if (m * n2 != result.Length)
                throw new ArgumentOutOfRangeException("result");
            Block2x2[] resultTemp = null;
            if (result == value1 || result == value2)
            {
                resultTemp = result;
                result = new Block2x2[result.Length];
            }
            fixed (Block2x2* value1Ptr = value1, value2Ptr = value2, resultPtr = result)
            {
                if(resultTemp == null)
                    for (int i = 0; i < result.Length; ++i)
                        resultPtr[i] = 0;
                for (int i = 0; i < m; ++i)
                {
                    int value1End = n1 * (i + 1);
                    for (int value1Index = n1 * i, ii = 0; value1Index < value1End; ++value1Index, ++ii)
                    {
                        int value2End = n2 * (ii + 1);
                        Block2x2 value1Value = value1Ptr[value1Index];
                        for (int value2Index = n2 * ii, resultIndex = n2 * i; value2Index < value2End; ++value2Index, ++resultIndex)
                            resultPtr[resultIndex] += value1Value * value2Ptr[value2Index];
                    }
                }
            }
            if(resultTemp != null)
                Array.Copy(result, resultTemp, result.Length);
        }
        unsafe public override void CSRMatrixMatrixMultiply(int m, int n1, Block2x2[] value1, int[] value1Columns, int[] value1RowsMapping, int n2, Block2x2[] value2, int[] value2Columns, int[] value2RowsMapping, ref Block2x2[] result, ref int[] resultColumns, ref int[] resultRowsMapping)
        {
            Th.ThrowCSRMatrixMatrixMultiply(m, n1, value1, value1Columns, value1RowsMapping, n2, value2, value2Columns, value2RowsMapping, ref result, ref resultColumns, ref resultRowsMapping);
            Fixed resultFixed = result;
            Fixed resultColumnsFixed = resultColumns;
            try
            {
                Block2x2* resultPtr = (Block2x2*)resultFixed;
                int* resultColumnsPtr = (int*)resultColumnsFixed;
                Block2x2[] values = new Block2x2[n2 + 2];
                int[] columns = new int[n2 + 2];
                int[] nexts = new int[n2 + 2];
                int head = 0;
                fixed (int* columnsPtr = columns, nextsPtr = nexts, value1ColumnsPtr = value1Columns, value2ColumnsPtr = value2Columns)
                fixed (Block2x2* valuesPtr = values, value1Ptr = value1, value2Ptr = value2)
                {
                    resultRowsMapping[0] = 0;
                    for (int i = 0; i < m; ++i)
                    {
                        int value1End = value1RowsMapping[i + 1];
                        for (int value1Index = value1RowsMapping[i]; value1Index < value1End; ++value1Index)
                        {
                            Block2x2 value1Value = value1Ptr[value1Index];
                            int value1Column = value1ColumnsPtr[value1Index];
                            int value2End = value2RowsMapping[value1Column + 1];
                            //double resValue = 0;
                            int currentIndex = nexts[0];
                            int previousIndex = 0;
                            int columnIndex;
                            for (int value2Index = value2RowsMapping[value1Column]; value2Index < value2End; ++value2Index)
                            {
                                int value2Column = value2ColumnsPtr[value2Index];
                                // resValue = value1Value * value2Ptr[value2Index];
                                for (; ; )
                                {
                                    // Get the column index of current element
                                    columnIndex = columnsPtr[currentIndex];
                                    if (columnIndex == value2Column)
                                    {
                                        // Set element in current position
                                        *(valuesPtr + currentIndex) += value1Value * value2Ptr[value2Index];
                                        previousIndex = currentIndex;
                                        currentIndex = nextsPtr[currentIndex];
                                        break;
                                    }
                                    if (columnIndex > value2Column)
                                    {
                                        // Reset the row current element
                                        nextsPtr[previousIndex] = head;
                                        nextsPtr[head] = currentIndex;
                                        columnsPtr[head] = value2Column;
                                        *(valuesPtr + head) = value1Value * value2Ptr[value2Index];
                                        previousIndex = head;
                                        head++;
                                        break;
                                    }
                                    previousIndex = currentIndex;
                                    currentIndex = nextsPtr[currentIndex];
                                }
                            }
                            // Add new row
                            int iNewRow = resultRowsMapping[i];
                            if (head - 2 > result.Length - iNewRow)
                            {
                                int newCapacity = result.Length * 2;
                                resultColumnsFixed.Free();
                                resultFixed.Free();
                                Block2x2[] newResult = new Block2x2[newCapacity];
                                int[] newResultColumns = new int[newCapacity];
                                Array.Copy(result, newResult, result.Length);
                                Array.Copy(resultColumns, newResultColumns, resultColumns.Length);
                                resultFixed = result = newResult;
                                resultColumnsFixed = resultColumns = newResultColumns;
                                resultPtr = (Block2x2*)resultFixed;
                                resultColumnsPtr = (int*)resultColumnsFixed;
                            }
                            int column;
                            for (int counter = nexts[0]; (column = columns[counter]) != int.MaxValue; counter = nexts[counter])
                            {
                                resultColumnsPtr[iNewRow] = column;
                                resultPtr[iNewRow] = values[counter];
                                iNewRow++;
                            }
                            resultRowsMapping[i + 1] = iNewRow;
                        }
                    }
                }
            }
            finally
            {
                resultFixed.Free();
                resultColumnsFixed.Free();
            }
        }
        #endregion Multiply
        #region Division
        #endregion Division
        #region Transpose
        /// <summary>
        /// Transpose matrix, saved in CSR stotage format
        /// </summary>
        /// <param name="m">The first matrix rows count and second matrix columns count</param>
        /// <param name="n">The matrix columns count and second matrix rows count</param>
        /// <param name="value">The input matrix values</param>
        /// <param name="valueColumns">The matrix column indexes</param>
        /// <param name="valueRowsMapping">The matrix indexes of rows beginning</param>
        /// <param name="result">The result matrix values</param>
        /// <param name="resultColumns">The result matrix column indexes</param>
        /// <param name="resultRowsMapping">The result matrix indexes of rows beginning</param>
        unsafe public override void CSRMatrixTranspose(int m, int n, Block2x2[] value, int[] valueColumns, int[] valueRowsMapping, Block2x2[] result, int[] resultColumns, int[] resultRowsMapping)
        {
            ThrowHelper<Block2x2>.ThrowIfTwoCSRMatrix(m, n, value, valueColumns, valueRowsMapping, "value", result, resultColumns, resultRowsMapping, "result");
            if (IsReferencesEquals(value, valueColumns, valueRowsMapping, result, resultColumns, resultRowsMapping))
            {
                value = new Block2x2[result.Length];
                valueColumns = new int[resultColumns.Length];
                valueRowsMapping = new int[resultRowsMapping.Length];
                Array.Copy(result, value, result.Length);
                Array.Copy(resultColumns, valueColumns, resultColumns.Length);
                Array.Copy(resultRowsMapping, valueRowsMapping, resultRowsMapping.Length);
            }
            int[] tempIndexes = new int[m];
            Array.Copy(valueRowsMapping, tempIndexes, tempIndexes.Length);
            resultRowsMapping[0] = 0;
            fixed (Block2x2* valuePtr = value, resultPtr = result)
            fixed (int* valueColumnsPtr = valueColumns, resultColumnsPtr = resultColumns)
            {
                int head = 0;
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < m; ++j)
                    {
                        int valueIndex = tempIndexes[j];
                        if (valueIndex == valueRowsMapping[j + 1])
                            continue;
                        if (valueColumnsPtr[valueIndex] == i)
                        {
                            resultPtr[head] = valuePtr[valueIndex];
                            resultColumnsPtr[head] = j;
                            tempIndexes[j]++;
                            head++;
                        }
                    }
                    resultRowsMapping[i + 1] = head;
                }
            }
        }
        /// <summary>
        /// Transpose full matrix
        /// </summary>
        /// <param name="m">The first matrix rows count and second matrix columns count</param>
        /// <param name="n">The matrix columns count and second matrix rows count</param>
        /// <param name="value">The input matrix values</param>
        /// <param name="result">The result matrix values</param>
        unsafe public override void FullMatrixTranspose(int m, int n, Block2x2[] value, Block2x2[] result)
        {
            int size = m * n;
            Th.ThrowIfFullMatrix(m, n, value, "value");
            Th.ThrowIfFullMatrix(m, n, result, "result");
            // For own transposes
            if (result == value)
            {
                value = new Block2x2[size];
                Array.Copy(result, value, size);
            }
            int n2 = n * 2;
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
        #endregion Transpose
        #region Decomposition
        /// <summary>
        /// Factorization of matrix, stored in CSR format
        /// </summary>
        /// <param name="m">The matrices rows count</param>
        /// <param name="n">The matrices columns count</param>
        /// <param name="value">The input matrix values</param>
        /// <param name="valueColumns">The matrix column indexes</param>
        /// <param name="valueRowsMapping">The matrix indexes of rows beginning</param>
        /// <param name="result">The result matrix values</param>
        /// <param name="resultColumns">The result matrix column indexes</param>
        /// <param name="resultRowsMapping">The result matrix indexes of rows beginning</param>
        unsafe public override void CSRMatrixDecomposition(int m, int n, Block2x2[] value, int[] valueColumns, int[] valueRowsMapping, ref Block2x2[] result, ref int[] resultColumns, int[] resultRowsMapping)
        {
            Fixed resultFixed = result;
            Fixed resultColumnsFixed = resultColumns;
            try
            {
                Block2x2* resultPtr = (Block2x2*)resultFixed;
                int* resultColumnsPtr = (int*)resultColumnsFixed.Fix();
                Block2x2[] diag = new Block2x2[n];
                int[] starts = new int[m];
                Block2x2[] values = new Block2x2[n + 2];
                int[] columns = new int[n + 2];
                int[] nexts = new int[n + 2];
                int head;
                Block2x2* temp;
                Block2x2 diagValue;
                Block2x2 temp1;
                double f00, f01, f10, f11;
                fixed (int* columnsPtr = columns, nextsPtr = nexts, resultRowsMappingPtr = resultRowsMapping)
                fixed (Block2x2* valuesPtr = values)
                {
                    for (int i = 0; i < m; ++i)
                    {
                        // Get current row
                        int index = valueRowsMapping[i];
                        int endIndex = valueRowsMapping[i + 1];
                        head = 1;
                        nexts[0] = 1;
                        columns[0] = -1;
                        for (; index < endIndex; ++index)
                        {
                            values[head] = value[index];
                            columns[head] = valueColumns[index];
                            nexts[head] = ++head;
                        }
                        nexts[head] = -1;
                        columns[head] = int.MaxValue;
                        head++;
                        int ii;
                        // Substract previous rows from current
                        for (int counter = nexts[0]; (ii = columns[counter]) < i; counter = nexts[counter])
                        {
                            if (ii == int.MaxValue)
                                break;
                            diagValue = diag[ii];
                            temp = valuesPtr + counter;
                            temp1 = *temp;
                            f00 = temp->f00 = temp1.f00 * diagValue.f00 + temp1.f01 * diagValue.f10;
                            f01 = temp->f01 = temp1.f00 * diagValue.f01 + temp1.f01 * diagValue.f11;
                            f10 = temp->f10 = temp1.f10 * diagValue.f00 + temp1.f11 * diagValue.f10;
                            f11 = temp->f11 = temp1.f10 * diagValue.f01 + temp1.f11 * diagValue.f11;
                            int iiHead = resultRowsMappingPtr[ii + 1];
                            int iiColumnIndex;
                            int currentIndex = nexts[counter];
                            int previousIndex = counter;
                            int columnIndex;
                            for (int iiCounter = starts[ii]; iiCounter < iiHead; ++iiCounter)
                            {
                                iiColumnIndex = resultColumnsPtr[iiCounter];
                                diagValue = resultPtr[iiCounter];
                                for (; ; )
                                {
                                    // Get the column index of current element
                                    columnIndex = columnsPtr[currentIndex];
                                    if (columnIndex == iiColumnIndex)
                                    {
                                        // Set element in current position
                                        temp = valuesPtr + currentIndex;
                                        temp->f00 -= (f00 * diagValue.f00 + f01 * diagValue.f10);
                                        temp->f01 -= (f00 * diagValue.f01 + f01 * diagValue.f11);
                                        temp->f10 -= (f10 * diagValue.f00 + f11 * diagValue.f10);
                                        temp->f11 -= (f10 * diagValue.f01 + f11 * diagValue.f11);
                                        previousIndex = currentIndex;
                                        currentIndex = nextsPtr[currentIndex];
                                        break;
                                    }
                                    if (columnIndex > iiColumnIndex)
                                    {
                                        // Reset the row current element
                                        nextsPtr[previousIndex] = head;
                                        nextsPtr[head] = currentIndex;
                                        columnsPtr[head] = iiColumnIndex;
                                        temp = valuesPtr + head;
                                        temp->f00 = -f00 * diagValue.f00 - f01 * diagValue.f10;
                                        temp->f01 = -f00 * diagValue.f01 - f01 * diagValue.f11;
                                        temp->f10 = -f10 * diagValue.f00 - f11 * diagValue.f10;
                                        temp->f11 = -f10 * diagValue.f01 - f11 * diagValue.f11;
                                        previousIndex = head;
                                        head++;
                                        break;
                                    }
                                    previousIndex = currentIndex;
                                    currentIndex = nextsPtr[currentIndex];
                                }
                            }
                        }
                        // Add new row
                        int iNewRow = resultRowsMappingPtr[i];
                        diagValue = default(Block2x2);
                        if (head - 2 > result.Length - iNewRow)
                        {
                            resultColumnsFixed.Free();
                            resultFixed.Free();
                            int newCapacity = result.Length * 2;
                            Block2x2[] newResult = new Block2x2[newCapacity];
                            int[] newResultColumns = new int[newCapacity];
                            Array.Copy(result, newResult, result.Length);
                            Array.Copy(resultColumns, newResultColumns, resultColumns.Length);
                            resultFixed = result = newResult;
                            resultColumnsFixed = resultColumns = newResultColumns;
                            resultPtr = (Block2x2*)resultFixed.Fix();
                            resultColumnsPtr = (int*)resultColumnsFixed.Fix();
                        }
                        int column;
                        for (int counter = nexts[0]; (column = columns[counter]) != int.MaxValue; counter = nexts[counter])
                        {
                            resultColumnsPtr[iNewRow] = column;
                            if (column == i)
                            {
                                diagValue = values[counter];
                                double det = 1 / (diagValue.f00 * diagValue.f11 - diagValue.f01 * diagValue.f10);
                                diag[i].f00 = diagValue.f11 * det;
                                diag[i].f01 = -diagValue.f01 * det;
                                diag[i].f10 = -diagValue.f10 * det;
                                diag[i].f11 = diagValue.f00 * det;
                                starts[i] = iNewRow + 1;
                            }
                            resultPtr[iNewRow] = values[counter];
                            iNewRow++;
                        }
                        resultRowsMappingPtr[i + 1] = iNewRow;
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Factorization error", exception);
            }
            finally
            {
                resultFixed.Free();
                resultColumnsFixed.Free();
            }
        }
        /// <summary>
        /// Factorization of full matrix
        /// </summary>
        /// <param name="m">The matrices rows count</param>
        /// <param name="n">The matrices columns count</param>
        /// <param name="value">The input matrix values</param>
        /// <param name="result">The result matrix values</param>
        unsafe public override void FullMatrixDecomposition(int m, int n, Block2x2[] value, Block2x2[] result)
        {
            ThrowHelper<Block2x2>.ThrowIfFullMatrix(m, n, value, "value");
            ThrowHelper<Block2x2>.ThrowIfFullMatrix(m, n, result, "result");
            if (value != result)
                Array.Copy(value, result, value.Length);
            fixed (Block2x2* resultPtr = result)
            {
                Block2x2 temp1, temp2;
                for (int i = 0; i < m; ++i)
                {
                    // Get current row
                    int index = i * n;
                    int endIndex = (i + 1) * n;
                    // Substract previous rows from current
                    for (int ii = 0; ii < i; ++ii)
                    {
                        int iiCounter = ii * (n + 1);
                        temp1 = resultPtr[iiCounter].Inverse;
                        temp2 = result[index + ii] * temp1;
                        result[index + ii] = temp2;
                        iiCounter++;
                        for (int iCounter = index + ii + 1; iCounter < endIndex; ++iCounter, ++iiCounter)
                            result[iCounter] -= temp2 * result[iiCounter];
                    }
                }
            }
        }
        unsafe public CsrMatrix<Block2x2> Decomposition(CsrMatrix<Block2x2> a, SolvingContext context = null)
        {
            if (context == null)
                context = GetSortingContext(a);
            try
            {
                int m = a.m_RowsCount;
                int n = a.m_ColumnsCount;
                CsrMatrix<Block2x2> returnValue = new CsrMatrix<Block2x2>(m, n, context.m_Count);
                Block2x2[] diag = new Block2x2[n];
                int[] starts = new int[m];
                Block2x2[] values = new Block2x2[n + 2];
                int[] columns = new int[n + 2];
                int[] nexts = new int[n + 2];
                int head = 1;
                Block2x2* temp;
                Block2x2 iiValue;
                Block2x2 temp2;
                double f00, f01, f10, f11;
                fixed (int* columnsPtr = columns, nextsPtr = nexts, retColumnsPtr = returnValue.m_Columns, retRowsMappingPtr = returnValue.m_RowsMapping)
                fixed (Block2x2* valuesPtr = values, retValuesPtr = returnValue.m_Values)
                {
                    for (int i = 0; i < m; ++i)
                    {
                        // Get current row
                        int index = a.m_RowsMapping[i];
                        int endIndex = a.m_RowsMapping[i + 1];
                        nexts[0] = 1;
                        columns[0] = -1;
                        for (; index < endIndex; ++index)
                        {
                            values[head] = a.m_Values[index];
                            columns[head] = a.m_Columns[index];
                            nexts[head] = ++head;
                        }
                        nexts[head] = -1;
                        columns[head] = int.MaxValue;
                        head++;
                        int ii;
                        // Substract previous rows from current
                        for (int counter = nexts[0]; (ii = columns[counter]) < i; counter = nexts[counter])
                        {
                            if (ii == int.MaxValue)
                                break;
                            iiValue = diag[ii];
                            temp = valuesPtr + counter;
                            temp2 = *temp;
                            f00 = temp->f00 = temp2.f00 * iiValue.f00 + temp2.f01 * iiValue.f10;
                            f01 = temp->f01 = temp2.f00 * iiValue.f01 + temp2.f01 * iiValue.f11;
                            f10 = temp->f10 = temp2.f10 * iiValue.f00 + temp2.f11 * iiValue.f10;
                            f11 = temp->f11 = temp2.f10 * iiValue.f01 + temp2.f11 * iiValue.f11;
                            int iiHead = retRowsMappingPtr[ii + 1];
                            int iiColumnIndex;
                            int currentIndex = nexts[counter];
                            int previousIndex = counter;
                            for (int iiCounter = starts[ii]; iiCounter < iiHead; ++iiCounter)
                            {
                                //              st1++;
                                iiColumnIndex = retColumnsPtr[iiCounter];
                                iiValue = retValuesPtr[iiCounter];
                                // Get the column index of current element
                                int columnIndex;
                                for (; ;)
                                {
                                    //            st2++;
                                    columnIndex = columnsPtr[currentIndex];
                                    if (columnIndex == iiColumnIndex)
                                    {
                                        // Set element in current position
                                        //                   st3++;
                                        temp = valuesPtr + currentIndex;
                                        temp->f00 -= (f00 * iiValue.f00 + f01 * iiValue.f10);
                                        temp->f01 -= (f00 * iiValue.f01 + f01 * iiValue.f11);
                                        temp->f10 -= (f10 * iiValue.f00 + f11 * iiValue.f10);
                                        temp->f11 -= (f10 * iiValue.f01 + f11 * iiValue.f11);
                                        previousIndex = currentIndex;
                                        currentIndex = nextsPtr[currentIndex];
                                        break;
                                    }
                                    if (columnIndex > iiColumnIndex)
                                    {
                                        // Reset the row current element
                                        nextsPtr[previousIndex] = head;
                                        nextsPtr[head] = currentIndex;
                                        columnsPtr[head] = iiColumnIndex;
                                        //                            st4++;
                                        temp = valuesPtr + head;
                                        temp->f00 = -f00 * iiValue.f00 - f01 * iiValue.f10;
                                        temp->f01 = -f00 * iiValue.f01 - f01 * iiValue.f11;
                                        temp->f10 = -f10 * iiValue.f00 - f11 * iiValue.f10;
                                        temp->f11 = -f10 * iiValue.f01 - f11 * iiValue.f11;
                                        previousIndex = head;
                                        head++;
                                        break;
                                    }
                                    previousIndex = currentIndex;
                                    currentIndex = nextsPtr[currentIndex];
                                }
                            }
                        }
                        // Add new row
                        int iNewRow = retRowsMappingPtr[i];
                        int column;
                        iiValue = default(Block2x2);
                        for (int counter = nexts[0]; (column = columns[counter]) != int.MaxValue; counter = nexts[counter])
                        {
                            retColumnsPtr[iNewRow] = column;
                            if (column == i)
                            {
                                iiValue = values[counter];
                                double det = 1 / (iiValue.f00 * iiValue.f11 - iiValue.f01 * iiValue.f10);
                                diag[i].f00 = iiValue.f11 * det;
                                diag[i].f01 = -iiValue.f01 * det;
                                diag[i].f10 = -iiValue.f10 * det;
                                diag[i].f11 = iiValue.f00 * det;
                                starts[i] = iNewRow + 1;
                            }
                            retValuesPtr[iNewRow] = values[counter];
                            iNewRow++;
                        }
                        retRowsMappingPtr[i + 1] = iNewRow;
                        head = 1;
                    }
                }
                return returnValue;
            }
            catch { return null; }
        }
        #endregion Decomposition
        #region Solve
        unsafe public void Solve(CsrMatrix<Block2x2> factor, Vector<Complex> b, ref FullVector<Complex> result)
        {
            Th.ThrowIfNull(factor, "value");
            Th.ThrowIfNull(b, "b");
            if (result == null)
                result = new FullVector<Complex>(factor.ColumnsCount);
            b.CopyTo(result);
            int m = factor.m_RowsCount;
            int n = factor.m_ColumnsCount;
            if (b.Count != m)
                throw new ArgumentException("Matrix row dimensions must agree.");
            // Copy right hand side with pivoting
            Block2x2 tempValue;
            double* yValues1;
            double* yValues2;
            int columnIndex;
            fixed (Complex* yValues = result.m_Values)
            fixed (Block2x2* factorValues = factor.m_Values)
            fixed (int* factorColumnsPtr = factor.m_Columns, factorRowsMappingPtr = factor.m_RowsMapping)
            {
                double real, imaginary;
                double real1 = 0;
                double imaginary1 = 0;
                int[] diagonalIndexes = new int[n];
                // Solve L*Y = B(piv,:)
                for (int i = 0; i < n; ++i)
                {
                    int head = factorRowsMappingPtr[i + 1];
                    real1 = 0;
                    imaginary1 = 0;
                    for (int ii = factorRowsMappingPtr[i]; ii < head; ++ii)
                    {
                        columnIndex = factorColumnsPtr[ii];
                        if (columnIndex >= i)
                        {
                            if (columnIndex == i)
                                diagonalIndexes[i] = ii;
                            else
                                throw new Exception();
                            break;
                        }
                        yValues1 = (double*)(yValues + columnIndex);
                        yValues2 = (double*)(factorValues + ii);
                        real1 += (*yValues2 * *yValues1 + *(yValues2 + 1) * *(yValues1 + 1));
                        imaginary1 += (*(yValues2 + 2) * *yValues1 + *(yValues2 + 3) * *(yValues1 + 1));
                    }
                    yValues2 = (double*)(yValues + i);
                    *yValues2 -= real1;
                    *(yValues2 + 1) -= imaginary1;
                }
                // Solve U*X = Y;
                for (int i = n - 1; i >= 0; --i)
                {
                    int head = factorRowsMappingPtr[i + 1];
                    real1 = 0;
                    imaginary1 = 0;
                    for (int ii = diagonalIndexes[i] + 1; ii < head; ++ii)
                    {
                        yValues1 = (double*)(yValues + factorColumnsPtr[ii]);
                        real = *yValues1;
                        imaginary = *(yValues1 + 1);
                        yValues2 = (double*)(factorValues + ii);
                        real1 += (*yValues2 * real + *(yValues2 + 1) * imaginary);
                        imaginary1 += (*(yValues2 + 2) * real + *(yValues2 + 3) * imaginary);
                    }
                    yValues2 = (double*)(yValues + i);
                    *yValues2 -= real1;
                    *(yValues2 + 1) -= imaginary1;
                    tempValue = factorValues[diagonalIndexes[i]].Inverse;
                    Complex yValues4 = yValues[i];
                    *yValues2 = (tempValue.f00 * yValues4.Real + tempValue.f01 * yValues4.Imaginary);
                    *(yValues2 + 1) = (tempValue.f10 * yValues4.Real + tempValue.f11 * yValues4.Imaginary);
                  //  yValues[i] = tempValue * yValues[i];
                }
            }
        }
        /// <summary>
        /// Solve equatation with factorized matrix
        /// </summary>
        /// <param name="m">The matrices rows count</param>
        /// <param name="n">The matrices columns count</param>
        /// <param name="factor">The factorized matrix values</param>
        /// <param name="factorColumns">The factorized matrix column indexes</param>
        /// <param name="factorRowsMapping">The factorized matrix indexes of rows beginning</param>
        /// <param name="b">The full matrix values for solve</param>
        /// <param name="bColumnsCount">Columns count for <paramref name="b"/></param>
        /// <param name="result">Solving result</param>
        unsafe public override void CSRMatrixSolve(int m, int n, Block2x2[] factor, int[] factorColumns, int[] factorRowsMapping, Block2x2[] b, int bColumnsCount, Block2x2[] result)
        {
            if (b.Length != m)
                throw new ArgumentException("Matrix row dimensions must agree.");
            if (bColumnsCount == 1)
            {

                if (b != result)
                    Array.Copy(b, result, b.Length);
                Block2x2 yValues1, tempValue;
                Block2x2* yValues2;
                int columnIndex;
                fixed (Block2x2* yValues = result, factorValues = factor)
                fixed (int* factorColumnsPtr = factorColumns, factorRowsMappingPtr = factorRowsMapping)
                {
                    int[] diagonalIndexes = new int[n];
                    // Solve L*Y = B(piv,:)
                    for (int i = 0; i < n; ++i)
                    {
                        int count = factorRowsMappingPtr[i + 1];
                        for (int ii = factorRowsMappingPtr[i]; ii < count; ++ii)
                        {
                            columnIndex = factorColumnsPtr[ii];
                            if (columnIndex >= i)
                            {
                                if (columnIndex == i)
                                    diagonalIndexes[i] = ii;
                                else
                                    throw new Exception();
                                break;
                            }
                            yValues1 = yValues[columnIndex];
                            tempValue = factorValues[ii];
                            yValues2 = yValues + i;
                            yValues2->f00 -= (tempValue.f00 * yValues1.f00 + tempValue.f01 * yValues1.f10);
                            yValues2->f01 -= (tempValue.f00 * yValues1.f01 + tempValue.f01 * yValues1.f11);
                            yValues2->f10 -= (tempValue.f10 * yValues1.f00 + tempValue.f11 * yValues1.f10);
                            yValues2->f11 -= (tempValue.f10 * yValues1.f01 + tempValue.f11 * yValues1.f11);
                        }
                    }
                    // Solve U*X = Y;
                    for (int i = n - 1; i >= 0; --i)
                    {
                        int head = factorRowsMappingPtr[i + 1];
                        for (int ii = diagonalIndexes[i] + 1; ii < head; ++ii)
                        {
                            yValues1 = yValues[factorColumnsPtr[ii]];
                            tempValue = factorValues[ii];
                            yValues2 = yValues + i;
                            yValues2->f00 -= (tempValue.f00 * yValues1.f00 + tempValue.f01 * yValues1.f10);
                            yValues2->f01 -= (tempValue.f00 * yValues1.f01 + tempValue.f01 * yValues1.f11);
                            yValues2->f10 -= (tempValue.f10 * yValues1.f00 + tempValue.f11 * yValues1.f10);
                            yValues2->f11 -= (tempValue.f10 * yValues1.f01 + tempValue.f11 * yValues1.f11);
                        }
                        tempValue = factorValues[diagonalIndexes[i]].Inverse;
                        yValues[i] = tempValue * yValues[i];
                    }
                }
            }
            else
            {
                int nx = bColumnsCount;
                if (b != result)
                    Array.Copy(b, result, b.Length);
                int columnIndex, temp1;
                fixed (Block2x2* yValues = result, factorValues = factor)
                fixed (int* factorColumnsPtr = factorColumns, factorRowsMappingPtr = factorRowsMapping)
                {
                    int[] diagonalIndexes = new int[n];
                    // Solve L*Y = B(piv,:)
                    for (int i = 0; i < n; ++i)
                    {
                        int count = factorRowsMappingPtr[i + 1];
                        for (int ii = factorRowsMappingPtr[i]; ii < count; ++ii)
                        {
                            columnIndex = factorColumnsPtr[ii];
                            if (columnIndex >= i)
                            {
                                if (columnIndex == i)
                                    diagonalIndexes[i] = ii;
                                else
                                    throw new Exception("Singular matrix");
                                break;
                            }
                            temp1 = i * bColumnsCount;
                            columnIndex *= bColumnsCount;
                            for (int j = 0; j < nx; ++j)
                                yValues[temp1 + j] -= factorValues[ii] * yValues[columnIndex + j];
                        }
                    }
                    // Solve U*X = Y;
                    for (int k = n - 1; k >= 0; --k)
                    {
                        Block2x2 val = factorValues[diagonalIndexes[k]].Inverse;
                        int count = factorRowsMappingPtr[k + 1];
                        temp1 = k * bColumnsCount;
                        for (int i = diagonalIndexes[k] + 1; i < count; ++i)
                        {
                            columnIndex = factorColumnsPtr[i] * bColumnsCount;
                            for (int j = 0; j < nx; ++j)
                                yValues[temp1 + j] -= factorValues[i] * yValues[columnIndex + j];
                        }
                        for (int j = 0; j < nx; ++j)
                            yValues[temp1 + j] = val * yValues[temp1 + j];
                    }
                }
            }
        }
        /// <summary>
        /// Solve equatations with factorized matrix
        /// </summary>
        /// <param name="m">The matrices rows count</param>
        /// <param name="n">The matrices columns count</param>
        /// <param name="factor">The factorized matrix values</param>
        /// <param name="b">The full matrix values for solve</param>
        /// <param name="bn">Columns count for <paramref name="b"/></param>
        /// <param name="result">Solving result</param>
        unsafe public override void FullMatrixSolve(int m, int n, Block2x2[] factor, Block2x2[] b, int bn, Block2x2[] result)
        {
            Th.ThrowIfFullMatrix(m, n, factor, "factor");
            Th.ThrowIfFullMatrix(m, bn, b, "b");
            Th.ThrowIfFullMatrix(n, bn, result, "result");
            if (m < n)
                throw new Exception("m < n");
            fixed (Block2x2* resultValues = result, factorValues = factor)
            {
                if (bn == 1)
                {
                    Block2x2 resultValue;
                    // Solve L*Y = B(piv,:)
                    for (int i = 0; i < n; ++i)
                    {
                        resultValue = resultValues[i];
                        for (int j = 0, factorCounter = i * n; j < i; ++j, ++factorCounter)
                            resultValue -= factorValues[factorCounter] * resultValues[j];
                        resultValues[i] = resultValue;
                    }
                    // Solve U*X = Y;
                    for (int i = n - 1; i >= 0; --i)
                    {
                        resultValue = resultValues[i];
                        for (int j = i + 1, factorCounter = i * n + i + 1; j < n; ++j, ++factorCounter)
                            resultValue -= factorValues[factorCounter] * resultValues[j];
                        resultValues[i] = resultValue / factorValues[i * n + i];
                    }
                }
                else
                {
                    int length = result.Length;
                    // Solve L*Y = B(piv,:)
                    for (int i = 0; i < n; ++i)
                    {
                        for (int j = 0, factorCounter = i * n; j < i; ++j, ++factorCounter)
                        {
                            Block2x2 factorValue = factorValues[factorCounter];
                            for (int mulCounter = j, resultCounter = i; resultCounter < length; mulCounter += bn, resultCounter += bn)
                                resultValues[resultCounter] -= factorValue * resultValues[mulCounter];
                        }
                    }
                    // Solve U*X = Y;
                    for (int i = n - 1; i >= 0; --i)
                    {
                        for (int j = i + 1, factorCounter = i * n + i + 1; j < n; ++factorCounter, ++j)
                        {
                            Block2x2 factorValue = factorValues[factorCounter];
                            for (int mulCounter = 0, resultCounter = 0; mulCounter < bn; ++mulCounter, resultCounter += bn)
                                resultValues[resultCounter] -= factorValue * resultValues[mulCounter];
                        }
                        Block2x2 val = 1 / factorValues[i * n + i];
                        for (int resultCounter = i; resultCounter < length; resultCounter += bn)
                            resultValues[resultCounter] = resultValues[resultCounter] * val;
                    }
                }
            }
        }
        #endregion Solve
        #region Sorting
        #endregion Sorting
        #region Equals
        #endregion Equals
        #region Set
        #endregion Set
        #endregion Events, overrides
        #endregion Methods
    }
}
#endregion Working namespace
