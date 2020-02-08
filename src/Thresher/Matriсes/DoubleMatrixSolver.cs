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
using System.IO;
using System.Globalization;
using Th = AIlins.Thresher.ThrowHelper<double>;
#endregion Using namespaces
#region Working namespace
namespace AIlins.Thresher
{
    public class DoubleMatrixSolver : MatrixSolver<double>
    {
        #region Classes, structures, enums
        #endregion Classes, structures, enums
        #region Constructors
        public DoubleMatrixSolver(ArraySolver<double> arraySolver = null)
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
        unsafe public override void CSRMatrixMatrixAddition(int m, int n, double[] value1, int[] value1Columns, int[] value1RowsMapping, double[] value2, int[] value2Columns, int[] value2RowsMapping, ref double[] result, ref int[] resultColumns, ref int[] resultRowsMapping)
        {
            Th.ThrowCSRMatrixMatrix(m, n, value1, value1Columns, value1RowsMapping, value2, value2Columns, value2RowsMapping, ref result, ref resultColumns, ref resultRowsMapping);
            Fixed resultFixed = result;
            Fixed resultColumnsFixed = resultColumns;
            try
            {
                double* resultPtr = (double*)resultFixed;
                int* resultColumnsPtr = (int*)resultColumnsFixed.Fix();
                fixed (double* value1Ptr = value1, value2Ptr = value2)
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
                                double[] newResult = new double[newCapacity];
                                int[] newResultColumns = new int[newCapacity];
                                Array.Copy(result, newResult, result.Length);
                                Array.Copy(resultColumns, newResultColumns, resultColumns.Length);
                                resultFixed = result = newResult;
                                resultColumnsFixed = resultColumns = newResultColumns;
                                resultPtr = (double*)resultFixed.Fix();
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
        unsafe public override void CSRMatrixMatrixSubstraction(int m, int n, double[] value1, int[] value1Columns, int[] value1RowsMapping, double[] value2, int[] value2Columns, int[] value2RowsMapping, ref double[] result, ref int[] resultColumns, ref int[] resultRowsMapping)
        {
            Th.ThrowCSRMatrixMatrix(m, n, value1, value1Columns, value1RowsMapping, value2, value2Columns, value2RowsMapping, ref result, ref resultColumns, ref resultRowsMapping);
            Fixed resultFixed = result;
            Fixed resultColumnsFixed = resultColumns;
            try
            {
                double* resultPtr = (double*)resultFixed;
                int* resultColumnsPtr = (int*)resultColumnsFixed.Fix();
                fixed (double* values1Ptr = value1, values2Ptr = value2)
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
                                double[] newResult = new double[newCapacity];
                                int[] newResultColumns = new int[newCapacity];
                                Array.Copy(result, newResult, result.Length);
                                Array.Copy(resultColumns, newResultColumns, resultColumns.Length);
                                resultFixed = result = newResult;
                                resultColumnsFixed = resultColumns = newResultColumns;
                                resultPtr = (double*)resultFixed.Fix();
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
        unsafe public override void FullMatrixVectorMultiply(int m, int n, double[] value1, double[] value2, double[] result)
        {
            Th.ThrowIfNull(value1, "value1");
            Th.ThrowIfNull(value2, "value2");
            Th.ThrowIfNull(result, "result");
            if (m * n != value1.Length)
                throw new ArgumentOutOfRangeException("value1");
            if (n != value2.Length)
                throw new ArgumentOutOfRangeException("Columns count of value1 matrix not equal to length of value2 vector!");
            if (m != result.Length)
                throw new ArgumentOutOfRangeException("Rows count of value1 matrix not equal to length of result vector!");
            double[] resultTemp = null;
            if (result == value1 || result == value2)
            {
                resultTemp = result;
                result = new double[result.Length];
            }
            fixed (double* value1Ptr = value1, value2Ptr = value2, resultPtr = result)
            {
                int value1End;
                double item;
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
        unsafe public override void CSRMatrixVectorMultiply(int m, int n, double[] value1, int[] value1Columns, int[] value1RowsMapping, double[] value2, double[] result)
        {
            Th.ThrowIfCSRMatrix(m, n, value1, value1Columns, value1RowsMapping, "value1");
            Th.ThrowIfNull(value2, "value2");
            Th.ThrowIfNull(result, "result");
            if (n != value2.Length)
                throw new ArgumentOutOfRangeException("Columns count of value1 matrix not equal to length of value2 vector!");
            if (m != result.Length)
                throw new ArgumentOutOfRangeException("Rows count of value1 matrix not equal to length of result vector!");
            double[] resultTemp = null;
            if (result == value1 || result == value2)
            {
                resultTemp = result;
                result = new double[result.Length];
            }
            fixed (double* value1Ptr = value1, value2Ptr = value2, resultPtr = result)
            fixed (int* value1ColumnsPtr = value1Columns, value1RowsMappingPtr = value1RowsMapping)
            {
                int value1End;
                double item;
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
        /// <summary>
        /// Multiply dense matrix to dense vector
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        /// <param name="isVertical"></param>
        unsafe public override void FullMatrixVectorElementsMultiply(int m, int n, double[] value1, double[] value2, double[] result, bool isVertical = false)
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
            
            fixed (double* value1Ptr = value1, value2Ptr = value2, resultPtr = result)
            {
                int value1End;
                if (isVertical)
                {
                    if (value2.Length != m)
                        throw new Exception("Rows count of first matrix not equal to vector elements count!");

                    for (int i = 0; i < m; ++i)
                    {
                        double item = *(value2Ptr + i);
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
        unsafe public override void CSRMatrixVectorElementsMultiply(int m, int n, double[] value1, int[] value1Columns, int[] value1RowsMapping, double[] value2, double[] result, bool isVertical = false)
        {
            Th.ThrowIfCSRMatrix(m, n, value1, value1Columns, value1RowsMapping, "value1");
            Th.ThrowIfNull(value2, "value2");
            Th.ThrowIfNull(result, "result");
            double[] resultTemp = null;
            if (result == value2)
            {
                resultTemp = result;
                result = new double[result.Length];
            }
            fixed (double* value1Ptr = value1, value2Ptr = value2, resultPtr = result)
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
                        double item = *(value2Ptr + i);
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
                            *(value1Ptr + index) *= *(value2Ptr + *(value1ColumnsPtr + index));
                            index++;
                        }
                    }
                }
            }
            if (resultTemp != null)
                Array.Copy(result, resultTemp, result.Length);
        }
        unsafe public override void FullMatrixMatrixMultiply(int m, int n1, double[] value1, int n2, double[] value2, double[] result)
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
            double[] resultTemp = null;
            if (result == value1 || result == value2)
            {
                resultTemp = result;
                result = new double[result.Length];
            }
            fixed (double* value1Ptr = value1, value2Ptr = value2, resultPtr = result)
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
                        double value1Value = value1Ptr[value1Index];
                        for (int value2Index = n2 * ii, resultIndex = n2 * i; value2Index < value2End; ++value2Index, ++resultIndex)
                            resultPtr[resultIndex] += value1Value * value2Ptr[value2Index];
                    }
                }
            }
            if (resultTemp != null)
                Array.Copy(result, resultTemp, result.Length);
        }
        unsafe public override void CSRMatrixMatrixMultiply(int m, int n1, double[] value1, int[] value1Columns, int[] value1RowsMapping, int n2, double[] value2, int[] value2Columns, int[] value2RowsMapping, ref double[] result, ref int[] resultColumns, ref int[] resultRowsMapping)
        {
            Th.ThrowCSRMatrixMatrixMultiply(m, n1, value1, value1Columns, value1RowsMapping, n2, value2, value2Columns, value2RowsMapping, ref result, ref resultColumns, ref resultRowsMapping);
            Fixed resultFixed = result;
            Fixed resultColumnsFixed = resultColumns;
            try
            {
                double* resultPtr = (double*)resultFixed;
                int* resultColumnsPtr = (int*)resultColumnsFixed;
                double[] values = new double[n2 + 2];
                int[] columns = new int[n2 + 2];
                int[] nexts = new int[n2 + 2];
                int head = 0;
                fixed (int* columnsPtr = columns, nextsPtr = nexts, value1ColumnsPtr = value1Columns, value2ColumnsPtr = value2Columns)
                fixed (double* valuesPtr = values, value1Ptr = value1, value2Ptr = value2)
                {
                    resultRowsMapping[0] = 0;
                    for (int i = 0; i < m; ++i)
                    {
                        int value1End = value1RowsMapping[i + 1];
                        for (int value1Index = value1RowsMapping[i]; value1Index < value1End; ++value1Index)
                        {
                            double value1Value = value1Ptr[value1Index];
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
                                double[] newResult = new double[newCapacity];
                                int[] newResultColumns = new int[newCapacity];
                                Array.Copy(result, newResult, result.Length);
                                Array.Copy(resultColumns, newResultColumns, resultColumns.Length);
                                resultFixed = result = newResult;
                                resultColumnsFixed = resultColumns = newResultColumns;
                                resultPtr = (double*)resultFixed;
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
        unsafe public override void CSRMatrixTranspose(int m, int n, double[] value, int[] valueColumns, int[] valueRowsMapping, double[] result, int[] resultColumns, int[] resultRowsMapping)
        {
            ThrowHelper<double>.ThrowIfTwoCSRMatrix(m, n, value, valueColumns, valueRowsMapping, "value", result, resultColumns, resultRowsMapping, "result");
            if (IsReferencesEquals(value, valueColumns, valueRowsMapping, result, resultColumns, resultRowsMapping))
            {
                value = new double[result.Length];
                valueColumns = new int[resultColumns.Length];
                valueRowsMapping = new int[resultRowsMapping.Length];
                Array.Copy(result, value, result.Length);
                Array.Copy(resultColumns, valueColumns, resultColumns.Length);
                Array.Copy(resultRowsMapping, valueRowsMapping, resultRowsMapping.Length);
            }
            int[] tempIndexes = new int[m];
            Array.Copy(valueRowsMapping, tempIndexes, tempIndexes.Length);
            resultRowsMapping[0] = 0;
            fixed (double* valuePtr = value, resultPtr = result)
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
        unsafe public override void FullMatrixTranspose(int m, int n, double[] value, double[] result)
        {
            Th.ThrowIfFullMatrix(m, n, value, "value");
            Th.ThrowIfFullMatrix(m, n, result, "result");
            int size = m * n;
            // For own transposes
            if (result == value)
            {
                value = new double[size];
                Array.Copy(result, value, size);
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
        unsafe public override void CSRMatrixDecomposition(int m, int n, double[] value, int[] valueColumns, int[] valueRowsMapping, ref double[] result, ref int[] resultColumns, int[] resultRowsMapping)
        {
            try
            {
                double[] diag = new double[n];
                int[] starts = new int[m];
                double[] values = new double[n + 2];
                int[] columns = new int[n + 2];
                int[] nexts = new int[n + 2];
                int head;
                double* temp;
                double temp1;
                double temp2;
                fixed (int* columnsPtr = columns, nextsPtr = nexts, resultColumnsPtr = resultColumns, resultRowsMappingPtr = resultRowsMapping)
                fixed (double* valuesPtr = values, resultPtr = result)
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
                            temp1 = diag[ii];
                            temp = (double*)(valuesPtr + counter);
                            temp2 = *temp;
                            temp2 = *temp = temp2 * temp1;
                            int iiHead = resultRowsMappingPtr[ii + 1];
                            int iiColumnIndex;
                            int currentIndex = nexts[counter];
                            int previousIndex = counter;
                            int columnIndex;
                            for (int iiCounter = starts[ii]; iiCounter < iiHead; ++iiCounter)
                            {
                                iiColumnIndex = resultColumnsPtr[iiCounter];
                                temp1 = resultPtr[iiCounter];
                                for (; ; )
                                {
                                    // Get the column index of current element
                                    columnIndex = columnsPtr[currentIndex];
                                    if (columnIndex == iiColumnIndex)
                                    {
                                        // Set element in current position
                                        temp = (double*)(valuesPtr + currentIndex);
                                        *temp -= temp2 * temp1;
                                        previousIndex = currentIndex;
                                        currentIndex = nextsPtr[previousIndex];
                                        break;
                                    }
                                    if (columnIndex > iiColumnIndex)
                                    {
                                        // Reset the row current element
                                        nextsPtr[previousIndex] = head;
                                        nextsPtr[head] = currentIndex;
                                        columnsPtr[head] = iiColumnIndex;
                                        temp = (double*)(valuesPtr + head);
                                        *temp = -temp2 * temp1;
                                        previousIndex = head;
                                        head++;
                                        break;
                                    }
                                    previousIndex = currentIndex;
                                    currentIndex = nextsPtr[previousIndex];
                                }
                            }
                        }
                        // Add new row
                        int iNewRow = resultRowsMappingPtr[i];
                        int column;
                        temp1 = 0;
                        for (int counter = nexts[0]; (column = columns[counter]) != int.MaxValue; counter = nexts[counter])
                        {
                            resultColumnsPtr[iNewRow] = column;
                            if (column == i)
                            {
                                diag[i] = 1 / values[counter];
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
        }
        /// <summary>
        /// Factorization of full matrix
        /// </summary>
        /// <param name="m">The matrices rows count</param>
        /// <param name="n">The matrices columns count</param>
        /// <param name="value">The input matrix values</param>
        /// <param name="result">The result matrix values</param>
        unsafe public override void FullMatrixDecomposition(int m, int n, double[] value, double[] result)
        {
            ThrowHelper<double>.ThrowIfFullMatrix(m, n, value, "value");
            ThrowHelper<double>.ThrowIfFullMatrix(m, n, result, "result");
            if (value != result)
                Array.Copy(value, result, value.Length);
            fixed (double* resultPtr = result)
            {
                double temp1, temp2;
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
        /// Solve equatations with factorized matrix
        /// </summary>
        /// <param name="m">The matrices rows count</param>
        /// <param name="n">The matrices columns count</param>
        /// <param name="factor">The factorized matrix values</param>
        /// <param name="factorColumns">The factorized matrix column indexes</param>
        /// <param name="factorRowsMapping">The factorized matrix indexes of rows beginning</param>
        /// <param name="b">The full matrix values for solve</param>
        /// <param name="bn">Columns count for <paramref name="b"/></param>
        /// <param name="result">Solving result</param>
        unsafe public override void CSRMatrixSolve(int m, int n, double[] factor, int[] factorColumns, int[] factorRowsMapping, double[] b, int bn, double[] result)
        {
            if (b.Length != m)
                throw new ArgumentException("Matrix row dimensions must agree.");
            if (b != result)
                Array.Copy(b, result, b.Length);
            fixed (double* yValues = result, factorValues = factor)
            fixed (int* factorColumnsPtr = factorColumns, factorRowsMappingPtr = factorRowsMapping)
            {
                int[] diagonalIndexes = new int[n];
                if (bn == 1)
                {
                    double* yValues1, yValues2;
                    int columnIndex;
                    // Solve L*Y = B(piv,:)
                    for (int i = 0; i < n; ++i)
                    {
                        int head = factorRowsMappingPtr[i + 1];
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
                            *(yValues + i) -= factorValues[ii] * *yValues1;
                        }
                    }
                    // Solve U*X = Y;
                    for (int i = n - 1; i >= 0; --i)
                    {
                        int head = factorRowsMappingPtr[i + 1];
                        yValues2 = (double*)(yValues + i);
                        for (int ii = diagonalIndexes[i] + 1; ii < head; ++ii)
                        {
                            yValues1 = (double*)(yValues + factorColumnsPtr[ii]);
                            *yValues2 -= factorValues[ii] * *yValues1;
                        }
                        yValues[i] = yValues[i] / factorValues[diagonalIndexes[i]];
                    }
                }
                else
                {
                    int nx = bn;
                    int columnIndex, temp1;
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
                            temp1 = i * bn;
                            columnIndex *= bn;
                            for (int j = 0; j < nx; ++j)
                                yValues[temp1 + j] -= factorValues[ii] * yValues[columnIndex + j];
                        }
                    }
                    // Solve U*X = Y;
                    for (int k = n - 1; k >= 0; --k)
                    {
                        double val = 1 / factorValues[diagonalIndexes[k]];
                        int count = factorRowsMappingPtr[k + 1];
                        temp1 = k * bn;
                        for (int i = diagonalIndexes[k] + 1; i < count; ++i)
                        {
                            columnIndex = factorColumnsPtr[i] * bn;
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
        unsafe public override void FullMatrixSolve(int m, int n, double[] factor, double[] b, int bn, double[] result)
        {
            Th.ThrowIfFullMatrix(m, n, factor, "factor");
            Th.ThrowIfFullMatrix(m, bn, b, "b");
            Th.ThrowIfFullMatrix(n, bn, result, "result");
            if (m < n)
                throw new Exception("m < n");
            fixed (double* resultValues = result, factorValues = factor)
            {
                if (bn == 1)
                {
                    double resultValue;
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
                            double factorValue = factorValues[factorCounter];
                            for (int mulCounter = j, resultCounter = i; resultCounter < length; mulCounter += bn, resultCounter += bn)
                                resultValues[resultCounter] -= factorValue * resultValues[mulCounter];
                        }
                    }
                    // Solve U*X = Y;
                    for (int i = n - 1; i >= 0; --i)
                    {
                        for (int j = i + 1, factorCounter = i * n + i + 1; j < n; ++factorCounter, ++j)
                        {
                            double factorValue = factorValues[factorCounter];
                            for (int mulCounter = 0, resultCounter = 0; mulCounter < bn; ++mulCounter, resultCounter += bn)
                                resultValues[resultCounter] -= factorValue * resultValues[mulCounter];
                        }
                        double val = 1 / factorValues[i * n + i];
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
        #region IO
        //public override void ReadCSRMatrix(Stream stream, int m, int n, int count, ref CSRMatrix<double> result, StreamType type = StreamType.ElementByRowText)
        //{
        //    ThrowIfNull(stream, "stream");
        //    switch (type)
        //    {
        //        case StreamType.ElementByRowText:
        //            {
        //                StreamReader reader = new StreamReader(stream);
        //                SortedList<int, double>[] readedValues = new SortedList<int, double>[m];
        //                for (int i = 0; i < m; ++i)
        //                    readedValues[i] = new SortedList<int, double>();
        //                for (int i = 0; i < count; ++i)
        //                {
        //                    string line = reader.ReadLine();
        //                    if (string.IsNullOrWhiteSpace(line))
        //                        continue;
        //                    string[] elements = line.Split();
        //                    if (elements == null || elements.Length != 3)
        //                        continue;
        //                    int rowIndex, columnIndex;
        //                    double value;
        //                    if (!int.TryParse(elements[0], out rowIndex))
        //                        continue;
        //                    if (rowIndex < 0 || rowIndex >= m)
        //                        continue;
        //                    if (!int.TryParse(elements[1], out columnIndex))
        //                        continue;
        //                    if (columnIndex < 0 || columnIndex >= n)
        //                        continue;
        //                    if (double.TryParse(elements[2], out value))
        //                        continue;
        //                    readedValues[rowIndex][columnIndex] = value;
        //                }
        //                if (result == null)
        //                    result = new CSRMatrix<double>(m, n, count);
        //                else
        //                    if (result.Capacity < count)
        //                        result.Capacity = count;
        //                CreateCSRMatrix(m, n, readedValues, ref result);
        //            }
        //            break;
        //        case StreamType.CSRBinary:
        //            {
        //                BinaryReader reader = new BinaryReader(stream);
        //                SortedList<int, double>[] readedValues = new SortedList<int, double>[m];
        //                for (int i = 0; i < m; ++i)
        //                    readedValues[i] = new SortedList<int, double>();
                        
        //            }
        //            break;
        //    }
        //}
        #endregion IO
        #region Set
        #endregion Set
        #endregion Events, overrides
        #endregion Methods
    }
}
#endregion Working namespace
