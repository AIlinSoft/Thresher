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
using System.Globalization;
using Th = AIlins.Thresher.ThrowHelper<System.Numerics.Complex>;
#endregion Using namespaces
#region Working namespace
namespace AIlins.Thresher
{
    public class ComplexMatrixSolver : MatrixSolver<Complex>
    {
        #region Classes, structures, enums
        #endregion Classes, structures, enums
        #region Constructors
        public ComplexMatrixSolver(ArraySolver<Complex> arraySolver = null)
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
        #endregion Private methods
        #region  Events, overrides
        #region Addition
        unsafe public override void CSRMatrixMatrixAddition(int m, int n, Complex[] value1, int[] value1Columns, int[] value1RowsMapping, Complex[] value2, int[] value2Columns, int[] value2RowsMapping, ref Complex[] result, ref int[] resultColumns, ref int[] resultRowsMapping)
        {
            Th.ThrowCSRMatrixMatrix(m, n, value1, value1Columns, value1RowsMapping, value2, value2Columns, value2RowsMapping, ref result, ref resultColumns, ref resultRowsMapping);
            Fixed resultFixed = result;
            Fixed resultColumnsFixed = resultColumns;
            try
            {
                Complex* resultPtr = (Complex*)resultFixed;
                int* resultColumnsPtr = (int*)resultColumnsFixed.Fix();
                fixed (Complex* value1Ptr = value1, value2Ptr = value2)
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
                                Complex[] newResult = new Complex[newCapacity];
                                int[] newResultColumns = new int[newCapacity];
                                Array.Copy(result, newResult, result.Length);
                                Array.Copy(resultColumns, newResultColumns, resultColumns.Length);
                                resultFixed = result = newResult;
                                resultColumnsFixed = resultColumns = newResultColumns;
                                resultPtr = (Complex*)resultFixed.Fix();
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
        unsafe public override void CSRMatrixMatrixSubstraction(int m, int n, Complex[] value1, int[] value1Columns, int[] value1RowsMapping, Complex[] value2, int[] value2Columns, int[] value2RowsMapping, ref Complex[] result, ref int[] resultColumns, ref int[] resultRowsMapping)
        {
            Th.ThrowCSRMatrixMatrix(m, n, value1, value1Columns, value1RowsMapping, value2, value2Columns, value2RowsMapping, ref result, ref resultColumns, ref resultRowsMapping);
            Fixed resultFixed = result;
            Fixed resultColumnsFixed = resultColumns;
            try
            {
                Complex* resultPtr = (Complex*)resultFixed;
                int* resultColumnsPtr = (int*)resultColumnsFixed.Fix();
                fixed (Complex* values1Ptr = value1, values2Ptr = value2)
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
                                Complex[] newResult = new Complex[newCapacity];
                                int[] newResultColumns = new int[newCapacity];
                                Array.Copy(result, newResult, result.Length);
                                Array.Copy(resultColumns, newResultColumns, resultColumns.Length);
                                resultFixed = result = newResult;
                                resultColumnsFixed = resultColumns = newResultColumns;
                                resultPtr = (Complex*)resultFixed.Fix();
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
        public static FullMatrix<Complex> Multiply(FullMatrix<Complex> value1, FullMatrix<Complex> value2)
        {
            return null;
        }
        //unsafe public static CSRMatrix<Complex> Multiply(CSRMatrix<Complex> value1, CSRMatrix<Complex> value2)
        //{
        //    int m = value1.RowsCount;
        //    int n = value2.ColumnsCount;
        //    if (value2.RowsCount != value1.ColumnsCount)
        //        throw new Exception("Rows count of first matrix not equal to columns count of second matrix!");
        //    CSRMatrix<Complex> returnValue = 
        //        new CSRMatrix<Complex>(0, m, (value1.m_RowsMapping[value1.m_RowsCount] + value2.m_RowsMapping[value2.m_RowsCount]) / 2);
        //    CSRMatrix<Complex> tempValue2 = Transpose(value2);

        //    fixed (Complex* values1Pointer = value1.m_Values, values2Pointer = tempValue2.m_Values)
        //    fixed (int* columns1Pointer = value1.m_Columns, columns2Pointer = tempValue2.m_Columns)
        //    {
        //        int index1;
        //        int end1;
        //        int index2;
        //        int end2;

        //        for (int i = 0; i < m; ++i)
        //        {
        //            Complex[] row1 = new Complex[value1.ColumnsCount];
        //            index1 = value1.m_RowsMapping[i];
        //            end1 = value1.m_RowsMapping[i + 1];
        //            while (index1 != end1)
        //            {
        //                row1[*(columns1Pointer + index1)] = *(values1Pointer + index1);
        //                index1++;
        //            }
        //            Complex[] row = new Complex[n];
        //            for (int j = 0; j < n; ++j)
        //            {
        //                index2 = tempValue2.m_RowsMapping[j];
        //                end2 = tempValue2.m_RowsMapping[j + 1];
        //                Complex item2 = 0;
        //                while (index2 != end2)
        //                {
        //                    item2 += row1[*(columns2Pointer + index2)] * *(values2Pointer + index2);
        //                    index2++;
        //                }
        //                row[j] = item2;
        //            }
        //         //   AddRow(returnValue, row);
        //        }
        //    }
        //    return returnValue;
        //}
        //unsafe public static FullMatrix<Complex> Multiply(CSRMatrix<Complex> value1, FullMatrix<Complex> value2)
        //{
        //    int m1 = value1.RowsCount;
        //    int n1 = value1.ColumnsCount;
        //    int m2 = value2.m_RowsCount;
        //    int n2 = value2.m_ColumnsCount;
        //    if (n1 != m2)
        //        throw new Exception("Rows count of first matrix not equal to columns count of second matrix!");

        //    Complex[] tempResult = new Complex[m1 * n2];
        //    Complex[] tempValues2 = new Complex[m2 * n2];
        //    Transpose(m2, n2, value2.m_Values, tempValues2);

        //    int[] rowIndex1 = value1.m_RowsMapping;

        //    fixed (Complex* values1Pointer = value1.m_Values, values2Pointer = tempValues2)
        //    fixed (int* columns1Pointer = value1.m_Columns)
        //    {
        //        int index;
        //        int end;
        //        // Main loop -- optimize for sparse matrix-vector multiply
        //        for (int j = 0; j < n2; ++j)
        //        {
        //            Complex* startValue2 = values2Pointer + j * m2;
        //            Complex item;
        //            for (int i = 0; i < m1; ++i)
        //            {
        //                item = 0;
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
        //    FullMatrix<Complex> returnValue = new FullMatrix<Complex>();
        //    returnValue.m_RowsCount = m1;
        //    returnValue.m_ColumnsCount = n2;
        //    returnValue.m_Values = tempResult;
        //    return returnValue;
        //}
        unsafe public override void FullMatrixVectorMultiply(int m, int n, Complex[] value1, Complex[] value2, Complex[] result)
        {
            Th.ThrowIfNull(value1, "value1");
            Th.ThrowIfNull(value2, "value2");
            Th.ThrowIfNull(result, "result");
            if (n != value2.Length)
                throw new ArgumentOutOfRangeException("Rows count of matrix not equal to length of vector!");
            if (m * n != value1.Length)
                throw new ArgumentOutOfRangeException("value1");
            Complex[] resultTemp = null;
            if (result == value1 || result == value2)
            {
                resultTemp = result;
                result = new Complex[result.Length];
            }
            fixed (Complex* value1Ptr = value1, value2Ptr = value2, resultPtr = result)
            {
                int value1End;
                Complex item;
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
        unsafe public override void CSRMatrixVectorMultiply(int m, int n, Complex[] value1, int[] value1Columns, int[] value1RowsMapping, Complex[] value2, Complex[] result)
        {
            Th.ThrowIfCSRMatrix(m, n, value1, value1Columns, value1RowsMapping, "value1");
            Th.ThrowIfNull(value2, "value2");
            Th.ThrowIfNull(result, "result");
            if (n != value2.Length)
                throw new ArgumentOutOfRangeException("Columns count of value1 matrix not equal to length of value2 vector!");
            if (m != result.Length)
                throw new ArgumentOutOfRangeException("Rows count of value1 matrix not equal to length of result vector!");
            Complex[] resultTemp = null;
            if (result == value1 || result == value2)
            {
                resultTemp = result;
                result = new Complex[result.Length];
            }
            fixed (Complex* values1Ptr = value1, values2Ptr = value2, resultPtr = result)
            fixed (int* columns1Pointer = value1Columns)
            {
                double* values1Ptr1 = (double*)values1Ptr;
                double* values2Ptr1 = (double*)values2Ptr;
                double* resultPtr1 = (double*)resultPtr;
                int index, index1;
                int end;
                double real = 0;
                double imaginary = 0;
                double real1 = 0;
                double imaginary1 = 0;
                double real2 = 0;
                double imaginary2 = 0;
                double* values1PtrTemp, values2PtrTemp;
                for (int i = 0, i1 = 0; i < m; ++i, i1 += 2)
                {
                    index = value1RowsMapping[i];
                    index1 = index * 2;
                    end = value1RowsMapping[i + 1];
                    real = 0;
                    imaginary = 0;
                    while (index != end)
                    {
                        values1PtrTemp = values1Ptr1 + index1;
                        values2PtrTemp = values2Ptr1 + columns1Pointer[index] * 2;
                        real1 = *values1PtrTemp;
                        imaginary1 = *(values1PtrTemp + 1);
                        real2 = *values2PtrTemp;
                        imaginary2 = *(values2PtrTemp + 1);
                        real += real1 * real2 - imaginary1 * imaginary2;
                        imaginary += imaginary1 * real2 + real1 * imaginary2;
                        index++;
                        index1 += 2;
                    }
                    resultPtr1[i1] = real;
                    resultPtr1[i1 + 1] = imaginary;
                }
            }
            if (resultTemp != null)
                Array.Copy(result, resultTemp, result.Length);
        }
        /// <summary>
        /// TODO:
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="isVertical"></param>
        /// <returns></returns>
        unsafe public override void FullMatrixVectorElementsMultiply(int m, int n, Complex[] value1, Complex[] value2, Complex[] result, bool isVertical = false)
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
            fixed (Complex* value1Ptr = value1, value2Ptr = value2, resultPtr = result)
            {
                int value1End;
                if (isVertical)
                {
                    if (value2.Length != m)
                        throw new Exception("Rows count of first matrix not equal to vector elements count!");
                    for (int i = 0; i < m; ++i)
                    {
                        Complex item = *(value2Ptr + i);
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
        unsafe public override void CSRMatrixVectorElementsMultiply(int m, int n, Complex[] value1, int[] value1Columns, int[] value1RowsMapping, Complex[] value2, Complex[] result, bool isVertical = false)
        {
            Th.ThrowIfCSRMatrix(m, n, value1, value1Columns, value1RowsMapping, "value1");
            Th.ThrowIfNull(value2, "value2");
            Th.ThrowIfNull(result, "result");
            Complex[] resultTemp = null;
            if (result == value1 || result == value2)
            {
                resultTemp = result;
                result = new Complex[result.Length];
            }
            fixed (Complex* value1Ptr = value1, value2Ptr = value2, resultPtr = result)
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
                        Complex item = *(value2Ptr + i);
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
        unsafe public override void FullMatrixMatrixMultiply(int m, int n1, Complex[] value1, int n2, Complex[] value2, Complex[] result)
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
            Complex[] resultTemp = null;
            if (result == value1 || result == value2)
            {
                resultTemp = result;
                result = new Complex[result.Length];
            }
            fixed (Complex* value1Ptr = value1, value2Ptr = value2, resultPtr = result)
            {
                if (resultTemp == null)
                    for (int i = 0; i < result.Length; ++i)
                        resultPtr[i] = 0;
                for (int i = 0; i < m; ++i)
                {
                    int value1End = n1 * (i + 1);
                    for (int value1Index = n1 * i, ii = 0; value1Index < value1End; ++value1Index, ++ii)
                    {
                        int value2End = n2 * (ii + 1);
                        Complex value1Value = value1Ptr[value1Index];
                        for (int value2Index = n2 * ii, resultIndex = n2 * i; value2Index < value2End; ++value2Index, ++resultIndex)
                            resultPtr[resultIndex] += value1Value * value2Ptr[value2Index];
                    }
                }
            }
            if (resultTemp != null)
                Array.Copy(result, resultTemp, result.Length);
        }
        unsafe public override void CSRMatrixMatrixMultiply(int m, int n1, Complex[] value1, int[] value1Columns, int[] value1RowsMapping, int n2, Complex[] value2, int[] value2Columns, int[] value2RowsMapping, ref Complex[] result, ref int[] resultColumns, ref int[] resultRowsMapping)
        {
            Th.ThrowCSRMatrixMatrixMultiply(m, n1, value1, value1Columns, value1RowsMapping, n2, value2, value2Columns, value2RowsMapping, ref result, ref resultColumns, ref resultRowsMapping);
            Fixed resultFixed = result;
            Fixed resultColumnsFixed = resultColumns;
            try
            {
                Complex* resultPtr = (Complex*)resultFixed;
                int* resultColumnsPtr = (int*)resultColumnsFixed;
                Complex[] values = new Complex[n2 + 2];
                int[] columns = new int[n2 + 2];
                int[] nexts = new int[n2 + 2];
                int head = 0;
                fixed (int* columnsPtr = columns, nextsPtr = nexts, value1ColumnsPtr = value1Columns, value2ColumnsPtr = value2Columns)
                fixed (Complex* valuesPtr = values, value1Ptr = value1, value2Ptr = value2)
                {
                    resultRowsMapping[0] = 0;
                    for (int i = 0; i < m; ++i)
                    {
                        int value1End = value1RowsMapping[i + 1];
                        for (int value1Index = value1RowsMapping[i]; value1Index < value1End; ++value1Index)
                        {
                            Complex value1Value = value1Ptr[value1Index];
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
                                Complex[] newResult = new Complex[newCapacity];
                                int[] newResultColumns = new int[newCapacity];
                                Array.Copy(result, newResult, result.Length);
                                Array.Copy(resultColumns, newResultColumns, resultColumns.Length);
                                resultFixed = result = newResult;
                                resultColumnsFixed = resultColumns = newResultColumns;
                                resultPtr = (Complex*)resultFixed;
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
        #region Conjugate
        /// <summary>
        /// Compute the complex conjugate of elements of the matrix
        /// </summary>
        /// <param name="value">The input matrix values</param>
        /// <param name="result">The result matrix values</param>
        public virtual void Conjugate(Matrix<Complex> value, ref Matrix<Complex> result)
        {
            var solver = m_ArraySolver as ComplexArraySolver;
            if (solver == null)
                solver = new ComplexArraySolver();
            var fullMatrix = value as FullMatrix<Complex>;
            if (fullMatrix != null)
            {
                var fullResult = result as FullMatrix<Complex>;
                if (fullResult == null)
                {
                    if (result != null)
                        throw new NotImplementedException("Result type is different value type");
                    fullResult = new FullMatrix<Complex>(value.RowsCount, value.ColumnsCount);
                }
                solver.Conjugate(fullMatrix.m_Values, fullResult.m_Values);
                result = fullResult;
            }
            else
            {
                var csrMatrix = value as CsrMatrix<Complex>;
                if (csrMatrix != null)
                {
                    var csrResult = result as CsrMatrix<Complex>;
                    if (csrResult == null)
                    {
                        if (result != null)
                            throw new NotImplementedException("Result type is different value type");
                        csrResult = new CsrMatrix<Complex>(csrMatrix.RowsCount, csrMatrix.ColumnsCount, csrMatrix.Capacity);
                    }
                    solver.Conjugate(csrMatrix.m_Values, csrResult.m_Values);
                    if (csrResult != csrMatrix)
                    {
                        Array.Copy(csrMatrix.m_Columns, csrResult.m_Columns, csrMatrix.Capacity);
                        Array.Copy(csrMatrix.m_RowsMapping, csrResult.m_RowsMapping, csrMatrix.RowsCount + 1);
                        result = csrResult;
                    }
                }
                else
                    throw new NotImplementedException();
            }
        }
        /// <summary>
        /// Compute the complex conjugate of elements of the vector
        /// </summary>
        /// <param name="value">The input vector values to conjugate</param>
        /// <param name="result">The result vactor of conjugated values</param>
        /// <param name="length">A 32-bit integer that represents the number of elements to conjugate</param>
        /// <param name="valueIndex">A 32-bit integer that represents the index in the <paramref name="value"/> vector at which conjugating begins</param>
        /// <param name="resultIndex">A 32-bit integer that represents the index in the <paramref name="result"/> vector at which copying result begins</param>
        /// <remarks>If the <paramref name="result"/> value is null, automatically creates a new instance of the <typeparamref name="FullVector<T>"/></remarks>
        public virtual void Conjugate(Vector<Complex> value, ref FullVector<Complex> result, int length = int.MaxValue, int valueIndex = 0, int resultIndex = 0)
        {
            var solver = m_ArraySolver as ComplexArraySolver;
            if (solver == null)
                solver = new ComplexArraySolver();
            Th.ThrowIfNull(value, "value");
            if (length == int.MaxValue)
                length = value.Count - valueIndex;
            Th.ThrowIfOutOfRange("valueIndex", valueIndex, value.Count, length);
            Th.ThrowIfLessThenZero("resultIndex", resultIndex);
            if (result == null)
                result = new FullVector<Complex>(resultIndex + length);
            else
                Th.ThrowIfOutOfRange("resultIndex", resultIndex, result.Count, length);
            Complex[] valueValues = CheckIsFull(value);
            solver.Conjugate(valueValues, result.m_Values, length, valueIndex, resultIndex);
        }
        #endregion Conjugate
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
        unsafe public override void CSRMatrixTranspose(int m, int n, Complex[] value, int[] valueColumns, int[] valueRowsMapping, Complex[] result, int[] resultColumns, int[] resultRowsMapping)
        {
            ThrowHelper<Complex>.ThrowIfTwoCSRMatrix(m, n, value, valueColumns, valueRowsMapping, "value", result, resultColumns, resultRowsMapping, "result");
            if (IsReferencesEquals(value, valueColumns, valueRowsMapping, result, resultColumns, resultRowsMapping))
            {
                value = new Complex[result.Length];
                valueColumns = new int[resultColumns.Length];
                valueRowsMapping = new int[resultRowsMapping.Length];
                Array.Copy(result, value, result.Length);
                Array.Copy(resultColumns, valueColumns, resultColumns.Length);
                Array.Copy(resultRowsMapping, valueRowsMapping, resultRowsMapping.Length);
            }
            int[] tempIndexes = new int[m];
            Array.Copy(valueRowsMapping, tempIndexes, tempIndexes.Length);
            resultRowsMapping[0] = 0;
            fixed (Complex* valuePtr = value, resultPtr = result)
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
        unsafe public override void FullMatrixTranspose(int m, int n, Complex[] value, Complex[] result)
        {
            Th.ThrowIfFullMatrix(m, n, value, "value");
            Th.ThrowIfFullMatrix(m, n, result, "result");
            int size = m * n;
            int n2 = n * 2;
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
                for (; ptrValue < ptrValueEnd; ptrValue += 2)
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
        unsafe public override void CSRMatrixDecomposition(int m, int n, Complex[] value, int[] valueColumns, int[] valueRowsMapping, ref Complex[] result, ref int[] resultColumns, int[] resultRowsMapping)
        {
            try
            {
                Complex[] diag = new Complex[n];
                int[] starts = new int[m];
                Complex[] values = new Complex[n + 2];
                int[] columns = new int[n + 2];
                int[] nexts = new int[n + 2];
                int head;
                double* temp;
                Complex diagValue;
                Complex temp1;
                double real, imaginary;
                fixed (int* columnsPtr = columns, nextsPtr = nexts, retColumnsPtr = resultColumns, retRowsMappingPtr = resultRowsMapping)
                fixed (Complex* valuesPtr = values, retValuesPtr = result)
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
                            temp = (double*)(valuesPtr + counter);
                            temp1 = *(valuesPtr + counter);
                            real = *temp = temp1.Real * diagValue.Real - temp1.Imaginary * diagValue.Imaginary;
                            imaginary = *(temp + 1) = temp1.Real * diagValue.Imaginary + temp1.Imaginary * diagValue.Real;
                            int iiHead = retRowsMappingPtr[ii + 1];
                            int iiColumnIndex;
                            int currentIndex = nexts[counter];
                            int previousIndex = counter;
                            int columnIndex;
                            for (int iiCounter = starts[ii]; iiCounter < iiHead; ++iiCounter)
                            {
                                iiColumnIndex = retColumnsPtr[iiCounter];
                                diagValue = retValuesPtr[iiCounter];
                                for (; ; )
                                {
                                    // Get the column index of current element
                                    columnIndex = columnsPtr[currentIndex];
                                    if (columnIndex == iiColumnIndex)
                                    {
                                        // Set element in current position
                                        temp = (double*)(valuesPtr + currentIndex);
                                        *temp -= (real * diagValue.Real - imaginary * diagValue.Imaginary);
                                        previousIndex = currentIndex;
                                        currentIndex = nextsPtr[currentIndex];
                                        *(temp + 1) -= (real * diagValue.Imaginary + imaginary * diagValue.Real);
                                        break;
                                    }
                                    if (columnIndex > iiColumnIndex)
                                    {
                                        // Reset the row current element
                                        nextsPtr[previousIndex] = head;
                                        nextsPtr[head] = currentIndex;
                                        columnsPtr[head] = iiColumnIndex;
                                        temp = (double*)(valuesPtr + head);
                                        *temp = -real * diagValue.Real + imaginary * diagValue.Imaginary;
                                        *(temp + 1) = -real * diagValue.Imaginary - imaginary * diagValue.Real;
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
                        diagValue = default(Complex);
                        for (int counter = nexts[0]; (column = columns[counter]) != int.MaxValue; counter = nexts[counter])
                        {
                            retColumnsPtr[iNewRow] = column;
                            if (column == i)
                            {
                                diag[i] = 1 / values[counter];
                                starts[i] = iNewRow + 1;
                            }
                            retValuesPtr[iNewRow] = values[counter];
                            iNewRow++;
                        }
                        retRowsMappingPtr[i + 1] = iNewRow;
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Factorization error", exception);
            }
        }
        /// <summary>
        /// Factorization of full matrix
        /// </summary>
        /// <param name="m">The matrices rows count</param>
        /// <param name="n">The matrices columns count</param>
        /// <param name="value">The input matrix values</param>
        /// <param name="result">The result matrix values</param>
        unsafe public override void FullMatrixDecomposition(int m, int n, Complex[] value, Complex[] result)
        {
            ThrowHelper<Complex>.ThrowIfFullMatrix(m, n, value, "value");
            ThrowHelper<Complex>.ThrowIfFullMatrix(m, n, result, "result");
            if (value != result)
                Array.Copy(value, result, value.Length);
            fixed (Complex* resultPtr = result)
            {
                Complex temp1, temp2;
                for (int i = 0; i < m; ++i)
                {
                    // Get current row
                    int index = i * n;
                    int endIndex = (i + 1) * n;
                    // Substract previous rows from current
                    for (int ii = 0; ii < i; ++ii)
                    {
                        int iiCounter = ii * (n + 1);
                        temp1 = 1 / resultPtr[iiCounter];
                        temp2 = result[index + ii] * temp1;
                        result[index + ii] = temp2;
                        iiCounter++;
                        for (int iCounter = index + ii + 1; iCounter < endIndex; ++iCounter, ++iiCounter)
                            result[iCounter] -= temp2 * result[iiCounter];
                    }
                }
            }
        }
        #endregion Decomposition
        #region Solve
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
        unsafe public override void CSRMatrixSolve(int m, int n, Complex[] factor, int[] factorColumns, int[] factorRowsMapping, Complex[] b, int bColumnsCount, Complex[] result)
        {
            if (b.Length != m)
                throw new ArgumentException("Matrix row dimensions must agree.");
            if (bColumnsCount == 1)
            {
                double real, imaginary;
                if (b != result)
                    Array.Copy(b, result, b.Length);
                double* yValues1, yValues2, yValues3;
                int columnIndex;
                fixed (Complex* yValues = result, factorValues = factor)
                fixed (int* factorColumnsPtr = factorColumns, factorRowsMappingPtr = factorRowsMapping)
                {
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
                            real = *yValues1;
                            imaginary = *(yValues1 + 1);
                            yValues3 = (double*)(factorValues + ii);
                            real1 += *yValues3 * real - *(yValues3 + 1) * imaginary;
                            imaginary1 += *yValues3 * imaginary + *(yValues3 + 1) * real;
                            // tempValue = factorValues[ii];
                            // real1 += tempValue.Real * real - tempValue.Imaginary * imaginary;
                            // imaginary1 += tempValue.Real * imaginary + tempValue.Imaginary * real;
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
                            yValues3 = (double*)(factorValues + ii);
                            real1 += *yValues3 * real - *(yValues3 + 1) * imaginary;
                            imaginary1 += *yValues3 * imaginary + *(yValues3 + 1) * real;
                            //tempValue = factorValues[ii];
                            //real1 += tempValue.Real * real - tempValue.Imaginary * imaginary;
                            //imaginary1 += tempValue.Real * imaginary + tempValue.Imaginary * real;
                        }
                        yValues2 = (double*)(yValues + i);
                        *yValues2 -= real1;
                        *(yValues2 + 1) -= imaginary1;
                        yValues[i] = yValues[i] / factorValues[diagonalIndexes[i]];
                    }
                }
            }
            else
            {
                int nx = bColumnsCount;
                if (b != result)
                    Array.Copy(b, result, b.Length);
                int columnIndex, temp1;
                fixed (Complex* yValues = result, factorValues = factor)
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
                        Complex val = 1 / factorValues[diagonalIndexes[k]];
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
        unsafe public override void FullMatrixSolve(int m, int n, Complex[] factor, Complex[] b, int bn, Complex[] result)
        {
            Th.ThrowIfFullMatrix(m, n, factor, "factor");
            Th.ThrowIfFullMatrix(m, bn, b, "b");
            Th.ThrowIfFullMatrix(n, bn, result, "result");
            if (m < n)
                throw new Exception("m < n");
            fixed (Complex* resultValues = result, factorValues = factor)
            {
                if (bn == 1)
                {
                    Complex resultValue;
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
                            Complex factorValue = factorValues[factorCounter];
                            for (int mulCounter = j, resultCounter = i; resultCounter < length; mulCounter += bn, resultCounter += bn)
                                resultValues[resultCounter] -= factorValue * resultValues[mulCounter];
                        }
                    }
                    // Solve U*X = Y;
                    for (int i = n - 1; i >= 0; --i)
                    {
                        for (int j = i + 1, factorCounter = i * n + i + 1; j < n; ++factorCounter, ++j)
                        {
                            Complex factorValue = factorValues[factorCounter];
                            for (int mulCounter = 0, resultCounter = 0; mulCounter < bn; ++mulCounter, resultCounter += bn)
                                resultValues[resultCounter] -= factorValue * resultValues[mulCounter];
                        }
                        Complex val = 1 / factorValues[i * n + i];
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
