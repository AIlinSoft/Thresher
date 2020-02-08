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
using System.Reflection;
using System.Reflection.Emit;
using System.Numerics;
using System.IO;
#endregion Using namespaces
#region Working namespace
namespace AIlins.Thresher
{
    public enum StreamType
    {
        CSRBinary,
        FullBinary,
        ElementByRowText,

    }
    public abstract class MatrixSolver<T>
    {
        #region Classes, structures, enums
        #endregion Classes, structures, enums
        #region Constructors
        public MatrixSolver(ArraySolver<T> arraySolver = null)
        {
            m_ArraySolver = arraySolver;
            if (m_ArraySolver == null)
            {
                if (typeof(T) == typeof(double))
                    m_ArraySolver = new DoubleArraySolver() as ArraySolver<T>;
                else
                    if (typeof(T) == typeof(Complex))
                        m_ArraySolver = new ComplexArraySolver() as ArraySolver<T>;
                    else
                        if (typeof(T) == typeof(Block2x2))
                            m_ArraySolver = new Block2x2ArraySolver() as ArraySolver<T>;
                        else
                            throw new NotImplementedException("Type is not implemented");
            }
        }
        #endregion Constructors
        #region Variables
        protected ArraySolver<T> m_ArraySolver;
        #endregion Variables
        #region Fields
        public ArraySolver<T> ArraySolver 
        {
            get
            {
                return m_ArraySolver;
            }
            set
            {
                if (value == null)
                    throw new NullReferenceException("value");
                m_ArraySolver = value;
            }
        }
        #endregion Fields
        #region Methods
        #region Public methods
        #region Addition
        /// <summary>
        /// Addition of two matrices, represeneted in Compressed Storage Row format
        /// </summary>
        /// <param name="m">The matrices rows count</param>
        /// <param name="n">The matrices columns count</param>
        /// <param name="value1">The first matrix values</param>
        /// <param name="value1Columns">The first matrix column indexes</param>
        /// <param name="value1RowsMapping">The first matrix indexes of rows beginning</param>
        /// <param name="value2">The second matrix values</param>
        /// <param name="value2Columns">The second matrix column indexes</param>
        /// <param name="value2RowsMapping">The second matrix indexes of rows beginning</param>
        /// <param name="result">The result matrix values</param>
        /// <param name="resultColumns">The result matrix column indexes</param>
        /// <param name="resultRowsMapping">The result matrix indexes of rows beginning</param>
        /// <remarks>If the capacity of <paramref name="result"/> and <paramref name="resultColumns"/> is not enough,
        /// automatically creates a new instances of this parameters of sufficient capacity</remarks>
        public virtual void CSRMatrixMatrixAddition(int m, int n, T[] value1, int[] value1Columns, int[] value1RowsMapping, T[] value2, int[] value2Columns, int[] value2RowsMapping, ref T[] result, ref int[] resultColumns, ref int[] resultRowsMapping)
        {
            ThrowHelper<T>.ThrowCSRMatrixMatrix(m, n, value1, value1Columns, value1RowsMapping, value2, value2Columns, value2RowsMapping, ref result, ref resultColumns, ref resultRowsMapping);
            var solver = SolversResolver.GetGenericSolver<T>();
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
                    if ((columns1 = value1Columns[index1]) == (columns2 = value2Columns[index2]))
                    {
                        result[head] = solver.Addition(value1[index1], value2[index2]);
                        resultColumns[head] = columns1;
                        index1++;
                        index2++;
                        head++;
                    }
                    else
                        if (columns1 > columns2)
                        {
                            result[head] = value2[index2];
                            resultColumns[head] = columns2;
                            index2++;
                            head++;
                        }
                        else
                        {
                            result[head] = value1[index1];
                            resultColumns[head] = columns1;
                            index1++;
                            head++;
                        }
                    if (head == result.Length)
                    {
                        int newCapacity = result.Length * 2;
                        T[] newResult = new T[newCapacity];
                        int[] newResultColumns = new int[newCapacity];
                        Array.Copy(result, newResult, result.Length);
                        Array.Copy(resultColumns, newResultColumns, resultColumns.Length);
                    }
                }
                resultRowsMapping[i + 1] = head;
            }
        }
        /// <summary>
        /// Addition of two vectors
        /// </summary>
        /// <param name="value1">The first vector to addition</param>
        /// <param name="value2">The second vector to addition</param>
        /// <param name="result">The result of vectors addition</param>
        /// <param name="length">A 32-bit integer that represents the number of elements to addition</param>
        /// <param name="value1Index">A 32-bit integer that represents the index in the <paramref name="value1"/> vector at which addition begins</param>
        /// <param name="value2Index">A 32-bit integer that represents the index in the <paramref name="value2"/> vector at which addition begins</param>
        /// <param name="resultIndex">A 32-bit integer that represents the index in the <paramref name="result"/> vector at which copying result begins</param>
        /// <remarks>If the <paramref name="result"/> value is null, automatically creates a new instance of the <typeparamref name="FullVector<T>"/></remarks>
        public virtual void Addition(Vector<T> value1, Vector<T> value2, ref FullVector<T> result, int length = int.MaxValue, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            ThrowHelper<T>.ThrowIfNull(value1, "value1");
            ThrowHelper<T>.ThrowIfNull(value2, "value2");
            if (length == int.MaxValue)
                length = value1.Count - value1Index;
            ThrowHelper<T>.ThrowIfOutOfRange("value1Index", value1Index, value1.Count, length);
            ThrowHelper<T>.ThrowIfLessThenZero("resultIndex", resultIndex);
            if (result == null)
                result = new FullVector<T>(resultIndex + length);
            else
                ThrowHelper<T>.ThrowIfOutOfRange("resultIndex", resultIndex, result.Count, length);
            ThrowHelper<T>.ThrowIfOutOfRange("value2Index", value2Index, value2.Count, length);
            T[] value2Values = CheckIsFull(value2);
            T[] value1Values = CheckIsFull(value1);
            m_ArraySolver.Addition(value1Values, value2Values, result.m_Values, length, value1Index, value2Index, resultIndex);
        }
        /// <summary>
        /// Addition of vector and vectorized number
        /// </summary>
        /// <param name="value1">The vector to addition</param>
        /// <param name="value2">The number, which will be addition with <paramref name="value1"/> vector</param>
        /// <param name="result">The result of addition</param>
        /// <param name="length">A 32-bit integer that represents the number of elements to addition</param>
        /// <param name="value1Index">A 32-bit integer that represents the index in the <paramref name="value1"/> array at which addition begins</param>
        /// <param name="resultIndex">A 32-bit integer that represents the index in the <paramref name="result"/> array at which copying result begins</param>
        /// <remarks>If the <paramref name="result"/> value is null, automatically creates a new instance of the <typeparamref name="FullVector<T>"/></remarks>
        public virtual void Addition(Vector<T> value1, T value2, ref FullVector<T> result, int length = int.MaxValue, int value1Index = 0, int resultIndex = 0)
        {
            ThrowHelper<T>.ThrowIfNull(value1, "value1");
            if (length == int.MaxValue)
                length = value1.Count - value1Index;
            ThrowHelper<T>.ThrowIfOutOfRange("value1Index", value1Index, value1.Count, length);
            ThrowHelper<T>.ThrowIfLessThenZero("resultIndex", resultIndex);
            if (result == null)
                result = new FullVector<T>(resultIndex + length);
            else
                ThrowHelper<T>.ThrowIfOutOfRange("resultIndex", resultIndex, result.Count, length);
            T[] value1Values = CheckIsFull(value1);
            m_ArraySolver.Addition(value1Values, value2, result.m_Values, length, value1Index, resultIndex);
        }
        /// <summary>
        /// Addition of two matrices
        /// </summary>
        /// <param name="value1">The first matrix to addition</param>
        /// <param name="value2">The second matrix to addition</param>
        /// <param name="result">The result of matrices addition</param>
        /// <remarks>If the <paramref name="result"/> value is null, automatically creates a new instance of the <typeparamref name="FullMatrix<T>"/> or the  <typeparamref name="CSRMatrix<T>"/>, 
        /// depends of the <paramref name="value1"/> and <paramref name="value2"/> types</remarks>
        public virtual void Addition(Matrix<T> value1, Matrix<T> value2, ref Matrix<T> result)
        {
            ThrowHelper<T>.ThrowIfNull(value1, "value1");
            ThrowHelper<T>.ThrowIfNull(value2, "value2");
            if(value1.RowsCount != value2.RowsCount || value1.ColumnsCount != value2.ColumnsCount)
                throw new ArgumentOutOfRangeException("Rows or columns counts are not equal!");
            var fullMatrix1 = value1 as FullMatrix<T>;
            if (fullMatrix1 != null)
            {
                var fullMatrix2 = value2 as FullMatrix<T>;
                if (fullMatrix2 == null)
                    throw new NotImplementedException("The type of value1 is different than value2 type!");
                FullMatrix<T> fullResult = CheckFullResultMatrix(value1, ref result);
                m_ArraySolver.Addition(fullMatrix1.m_Values, fullMatrix2.m_Values, fullResult.m_Values);
            }
            else
            {
                var csrMatrix1 = value1 as CsrMatrix<T>;
                if (csrMatrix1 != null)
                {
                    var csrMatrix2 = value2 as CsrMatrix<T>;
                    if (csrMatrix2 == null)
                        throw new NotImplementedException("The type of value1 is different than value2 type!");
                    int minimumCapacity = csrMatrix1.Filling > csrMatrix2.Filling ? csrMatrix1.Filling : csrMatrix2.Filling;
                    var csrResult = result as CsrMatrix<T>;

                    if (csrResult == null)
                    {
                        if (result != null)
                            throw new NotImplementedException("Result type is different than value type");
                        csrResult = new CsrMatrix<T>(csrMatrix1.RowsCount, csrMatrix1.ColumnsCount, minimumCapacity);
                    }
                    else
                    {
                        if (value1.RowsCount != result.RowsCount || value1.ColumnsCount != result.ColumnsCount)
                            throw new ArgumentOutOfRangeException("Rows or columns counts are not equal!");
                        if (csrResult.Capacity < minimumCapacity)
                            csrResult.Capacity = minimumCapacity;
                    }
                    result = csrResult;
                    CSRMatrixMatrixAddition(csrMatrix1.RowsCount, csrMatrix1.ColumnsCount, 
                        csrMatrix1.m_Values, csrMatrix1.m_Columns, csrMatrix1.m_RowsMapping,
                        csrMatrix2.m_Values, csrMatrix2.m_Columns, csrMatrix2.m_RowsMapping, 
                        ref csrResult.m_Values, ref csrResult.m_Columns, ref csrResult.m_RowsMapping);
                }
                else
                    throw new NotImplementedException("Matrix type of value1 is not implemented!");
            }
        }
        /// <summary>
        /// Summarizes the elements of the vector <paramref name="value"/>
        /// </summary>
        /// <param name="value">The vector to summariez</param>
        /// <param name="length">A 32-bit integer that represents the number of elements to summariez</param>
        /// <param name="valueIndex">A 32-bit integer that represents the index in the <paramref name="value"/> vector at which summariez begins</param>
        /// <returns>Result of the elements summariez</returns>
        public virtual T Summary(Vector<T> value, int length = int.MaxValue, int valueIndex = 0)
        {
            ThrowHelper<T>.ThrowIfNull(value, "value");
            if (length == int.MaxValue)
                length = value.Count - valueIndex;
            ThrowHelper<T>.ThrowIfOutOfRange("valueIndex", valueIndex, value.Count, length);
            var fullVector = value as FullVector<T>;
            if (fullVector != null)
                return m_ArraySolver.Summary(fullVector.m_Values, length, valueIndex);
            else
            {
                var solver = SolversResolver.GetGenericSolver<T>();
                T returnValue = default(T);
                foreach (Element<T> item in value)
                    if (item.Index >= valueIndex && item.Index < valueIndex + length)
                        returnValue = solver.Addition(returnValue, item.Value);
                return returnValue;
            }
        }
        #endregion Addition
        #region Substraction
        /// <summary>
        /// Substraction second vector from first
        /// </summary>
        /// <param name="value1">The minuend vector</param>
        /// <param name="value2">The subtrahend vector</param>
        /// <param name="result">The difference of vectors substraction</param>
        /// <param name="length">A 32-bit integer that represents the number of elements to substraction</param>
        /// <param name="value1Index">A 32-bit integer that represents the index in the <paramref name="value1"/> vector at which substraction begins</param>
        /// <param name="value2Index">A 32-bit integer that represents the index in the <paramref name="value2"/> vector at which substraction begins</param>
        /// <param name="resultIndex">A 32-bit integer that represents the index in the <paramref name="result"/> vector at which copying result begins</param>
        /// <remarks>If the <paramref name="result"/> value is null, automatically creates a new instance of the <typeparamref name="FullVector<T>"/></remarks>
        public virtual void Substraction(Vector<T> value1, Vector<T> value2, ref FullVector<T> result, int length = int.MaxValue, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            ThrowHelper<T>.ThrowIfNull(value1, "value1");
            ThrowHelper<T>.ThrowIfNull(value2, "value2");
            if (length == int.MaxValue)
                length = value1.Count - value1Index;
            ThrowHelper<T>.ThrowIfOutOfRange("value1Index", value1Index, value1.Count, length);
            ThrowHelper<T>.ThrowIfLessThenZero("resultIndex", resultIndex);
            if (result == null)
                result = new FullVector<T>(resultIndex + length);
            else
                ThrowHelper<T>.ThrowIfOutOfRange("resultIndex", resultIndex, result.Count, length);
            ThrowHelper<T>.ThrowIfOutOfRange("value2Index", value2Index, value2.Count, length);
            T[] value2Values = CheckIsFull(value2);
            T[] value1Values = CheckIsFull(value1);
            m_ArraySolver.Substraction(value1Values, value2Values, result.m_Values, length, value1Index, value2Index, resultIndex);
        }
        /// <summary>
        /// Substraction of two matrices, represeneted in Compressed Storage Row format
        /// </summary>
        /// <param name="m">The matrices rows count</param>
        /// <param name="n">The matrices columns count</param>
        /// <param name="value1">The first matrix values</param>
        /// <param name="value1Columns">The first matrix column indexes</param>
        /// <param name="value1RowsMapping">The first matrix indexes of rows beginning</param>
        /// <param name="value2">The second matrix values</param>
        /// <param name="value2Columns">The second matrix column indexes</param>
        /// <param name="value2RowsMapping">The second matrix indexes of rows beginning</param>
        /// <param name="result">The result matrix values</param>
        /// <param name="resultColumns">The result matrix column indexes</param>
        /// <param name="resultRowsMapping">The result matrix indexes of rows beginning</param>
        /// <remarks>If the capacity of <paramref name="result"/> and <paramref name="resultColumns"/> is not enough,
        /// automatically creates a new instances of this parameters of sufficient capacity</remarks>
        public virtual void CSRMatrixMatrixSubstraction(int m, int n, T[] value1, int[] value1Columns, int[] value1RowsMapping, T[] value2, int[] value2Columns, int[] value2RowsMapping, ref T[] result, ref int[] resultColumns, ref int[] resultRowsMapping)
        {
            ThrowHelper<T>.ThrowCSRMatrixMatrix(m, n, value1, value1Columns, value1RowsMapping, value2, value2Columns, value2RowsMapping, ref result, ref resultColumns, ref resultRowsMapping);
            var solver = SolversResolver.GetGenericSolver<T>();
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
                    if ((columns1 = value1Columns[index1]) == (columns2 = value2Columns[index2]))
                    {
                        result[head] = solver.Substraction(value1[index1], value2[index2]);
                        resultColumns[head] = columns1;
                        index1++;
                        index2++;
                        head++;
                    }
                    else
                        if (columns1 > columns2)
                        {
                            result[head] = solver.Negation(value2[index2]);
                            resultColumns[head] = columns2;
                            index2++;
                            head++;
                        }
                        else
                        {
                            result[head] = value1[index1];
                            resultColumns[head] = columns1;
                            index1++;
                            head++;
                        }
                    if (head == result.Length)
                    {
                        int newCapacity = result.Length * 2;
                        T[] newResult = new T[newCapacity];
                        int[] newResultColumns = new int[newCapacity];
                        Array.Copy(result, newResult, result.Length);
                        Array.Copy(resultColumns, newResultColumns, resultColumns.Length);
                    }
                }
                resultRowsMapping[i + 1] = head;
            }
        }
        /// <summary>
        /// Substraction of two matrices
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        public virtual void Substraction(Matrix<T> value1, Matrix<T> value2, ref Matrix<T> result)
        {
            ThrowHelper<T>.ThrowIfNull(value1, "value1");
            ThrowHelper<T>.ThrowIfNull(value2, "value2");
            if (value1.RowsCount != value2.RowsCount || value1.ColumnsCount != value2.ColumnsCount)
                throw new ArgumentOutOfRangeException("Rows or columns counts are not equal!");
            var fullMatrix1 = value1 as FullMatrix<T>;
            if (fullMatrix1 != null)
            {
                var fullMatrix2 = value2 as FullMatrix<T>;
                if (fullMatrix2 == null)
                    throw new NotImplementedException("The type of value1 is different than value2 type!");
                FullMatrix<T> fullResult = CheckFullResultMatrix(value1, ref result);
                m_ArraySolver.Substraction(fullMatrix1.m_Values, fullMatrix2.m_Values, fullResult.m_Values);
            }
            else
            {
                var csrMatrix1 = value1 as CsrMatrix<T>;
                if (csrMatrix1 != null)
                {
                    var csrMatrix2 = value2 as CsrMatrix<T>;
                    if (csrMatrix2 == null)
                        throw new NotImplementedException("The type of value1 is different than value2 type!");
                    int minimumCapacity = csrMatrix1.Filling > csrMatrix2.Filling ? csrMatrix1.Filling : csrMatrix2.Filling;
                    var csrResult = result as CsrMatrix<T>;
                    if (csrResult == null)
                    {
                        if (result != null)
                            throw new NotImplementedException("Result type is different than value type");
                        csrResult = new CsrMatrix<T>(csrMatrix1.RowsCount, csrMatrix1.ColumnsCount, minimumCapacity);
                    }
                    else
                    {
                        if (value1.RowsCount != result.RowsCount || value1.ColumnsCount != result.ColumnsCount)
                            throw new ArgumentOutOfRangeException("Rows or columns counts are not equal!");
                        if (csrResult.Capacity < minimumCapacity)
                            csrResult.Capacity = minimumCapacity;
                    }
                    result = csrResult;
                    CSRMatrixMatrixSubstraction(csrMatrix1.RowsCount, csrMatrix1.ColumnsCount,
                        csrMatrix1.m_Values, csrMatrix1.m_Columns, csrMatrix1.m_RowsMapping,
                        csrMatrix2.m_Values, csrMatrix2.m_Columns, csrMatrix2.m_RowsMapping,
                        ref csrResult.m_Values, ref csrResult.m_Columns, ref csrResult.m_RowsMapping);
                }
                else
                    throw new NotImplementedException("Matrix type of value1 is not implemented!");
            }
        }
        /// <summary>
        /// Negates the elements of the vector <paramref name="value"/>
        /// </summary>
        /// <param name="value">The vector to negates</param>
        /// <param name="result">The result of negates</param>
        /// <param name="length">A 32-bit integer that represents the number of elements to negates</param>
        /// <param name="valueIndex">A 32-bit integer that represents the index in the <paramref name="value"/> vector at which negates begins</param>
        /// <param name="resultIndex">A 32-bit integer that represents the index in the <paramref name="result"/> vactor at which copying result begins</param>
        /// <remarks>If the <paramref name="result"/> value is null, automatically creates a new instance of the <typeparamref name="FullVector<T>"/></remarks>
        public virtual void Negation(Vector<T> value, ref FullVector<T> result, int length = int.MaxValue, int valueIndex = 0, int resultIndex = 0)
        {
            ThrowHelper<T>.ThrowIfNull(value, "value");
            if (length == int.MaxValue)
                length = value.Count - valueIndex;
            ThrowHelper<T>.ThrowIfOutOfRange("valueIndex", valueIndex, value.Count, length);
            ThrowHelper<T>.ThrowIfLessThenZero("resultIndex", resultIndex);
            if (result == null)
                result = new FullVector<T>(resultIndex + length);
            else
                ThrowHelper<T>.ThrowIfOutOfRange("resultIndex", resultIndex, result.Count, length);
            T[] valueValues = CheckIsFull(value);
            m_ArraySolver.Negation(valueValues, result.m_Values, length, valueIndex, resultIndex);
        }
        /// <summary>
        /// Negates the elements of the matrix <paramref name="value"/>
        /// </summary>
        /// <param name="value">The matrix to negates</param>
        /// <param name="result">The result of negates</param>
        public virtual void Negation(Matrix<T> value, ref Matrix<T> result)
        {
            ThrowHelper<T>.ThrowIfNull(value, "value");
            var fullMatrix = value as FullMatrix<T>;
            if (fullMatrix != null)
            {
                FullMatrix<T> fullResult = CheckFullResultMatrix(value, ref result);
                m_ArraySolver.Negation(fullMatrix.m_Values, fullResult.m_Values);
            }
            else
            {
                var csrMatrix = value as CsrMatrix<T>;
                if (csrMatrix != null)
                {
                    CsrMatrix<T> csrResult = CheckCSRResultMatrix(csrMatrix, ref result);
                    m_ArraySolver.Negation(csrMatrix.m_Values, csrResult.m_Values, csrMatrix.Filling);
                }
                else
                    ThrowHelper<T>.ThrowNotImplementedMatrixType("value");
            }
        }
        #endregion Substraction
        #region Multiply
        /// <summary>
        /// Multiply of two matrices, represeneted in Compressed Storage Row format
        /// </summary>
        /// <param name="m1">The first matrix rows count</param>
        /// <param name="n1m2">The first matrix columns and the second matrix rows count</param>
        /// <param name="value1">The first matrix values</param>
        /// <param name="value1Columns">The first matrix column indexes</param>
        /// <param name="value1RowsMapping">The first matrix indexes of rows beginning</param>
        /// <param name="n2">The second matrix columns count</param>
        /// <param name="value2">The second matrix values</param>
        /// <param name="value2Columns">The second matrix column indexes</param>
        /// <param name="value2RowsMapping">The second matrix indexes of rows beginning</param>
        /// <param name="result">The result matrix values</param>
        /// <param name="resultColumns">The result matrix column indexes</param>
        /// <param name="resultRowsMapping">The result matrix indexes of rows beginning</param>
        /// <remarks>If the capacity of <paramref name="result"/> and <paramref name="resultColumns"/> is not enough,
        /// automatically creates a new instances of this parameters of sufficient capacity</remarks>
        public virtual void CSRMatrixMatrixMultiply(int m1, int n1m2, T[] value1, int[] value1Columns, int[] value1RowsMapping, int n2, T[] value2, int[] value2Columns, int[] value2RowsMapping, ref T[] result, ref int[] resultColumns, ref int[] resultRowsMapping)
        {
            ThrowHelper<T>.ThrowCSRMatrixMatrixMultiply(m1, n1m2, value1, value1Columns, value1RowsMapping, n2, value2, value2Columns, value2RowsMapping, ref result, ref resultColumns, ref resultRowsMapping);
            var solver = SolversResolver.GetGenericSolver<T>();
            T[] values = new T[n2 + 2];
            int[] columns = new int[n2 + 2];
            int[] nexts = new int[n2 + 2];
            int head = 0;
            resultRowsMapping[0] = 0;
            for (int i = 0; i < m1; ++i)
            {
                int value1End = value1RowsMapping[i + 1];
                for (int value1Index = value1RowsMapping[i]; value1Index < value1End; ++value1Index)
                {
                    T value1Value = value1[value1Index];
                    int value1Column = value1Columns[value1Index];
                    int value2End = value2RowsMapping[value1Column + 1];
                    int currentIndex = nexts[0];
                    int previousIndex = 0;
                    int columnIndex;
                    for (int value2Index = value2RowsMapping[value1Column]; value2Index < value2End; ++value2Index)
                    {
                        int value2Column = value2Columns[value2Index];
                        // resValue = value1Value * value2Ptr[value2Index];
                        for (; ; )
                        {
                            // Get the column index of current element
                            columnIndex = columns[currentIndex];
                            if (columnIndex == value2Column)
                            {
                                // Set element in current position
                                values[currentIndex] = solver.Addition(values[currentIndex], solver.Multiply(value1Value, value2[value2Index]));
                                previousIndex = currentIndex;
                                currentIndex = nexts[currentIndex];
                                break;
                            }
                            if (columnIndex > value2Column)
                            {
                                // Reset the row current element
                                nexts[previousIndex] = head;
                                nexts[head] = currentIndex;
                                columns[head] = value2Column;
                                values[head] = solver.Multiply(value1Value, value2[value2Index]);
                                previousIndex = head;
                                head++;
                                break;
                            }
                            previousIndex = currentIndex;
                            currentIndex = nexts[currentIndex];
                        }
                    }
                    // Add new row
                    int iNewRow = resultRowsMapping[i];
                    if (head - 2 > result.Length - iNewRow)
                    {
                        int newCapacity = result.Length * 2;
                        T[] newResult = new T[newCapacity];
                        int[] newResultColumns = new int[newCapacity];
                        Array.Copy(result, newResult, result.Length);
                        Array.Copy(resultColumns, newResultColumns, resultColumns.Length);
                        result = newResult;
                        resultColumns = newResultColumns;
                    }
                    int column;
                    for (int counter = nexts[0]; (column = columns[counter]) != int.MaxValue; counter = nexts[counter])
                    {
                        resultColumns[iNewRow] = column;
                        result[iNewRow] = values[counter];
                        iNewRow++;
                    }
                    resultRowsMapping[i + 1] = iNewRow;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n1"></param>
        /// <param name="value1"></param>
        /// <param name="n2"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        public virtual void FullMatrixMatrixMultiply(int m, int n1, T[] value1, int n2, T[] value2, T[] result)
        {
            if (m < 0 || n1 < 0 || n2 < 0)
                throw new ArgumentOutOfRangeException("m or n1 or n2 less than zero");
            ThrowHelper<T>.ThrowIfNull(value1, "value1");
            if (m * n1 != value1.Length)
                throw new ArgumentOutOfRangeException("value1");
            ThrowHelper<T>.ThrowIfNull(value2, "value2");
            if (n1 * n2 != value2.Length)
                throw new ArgumentOutOfRangeException("value2");
            ThrowHelper<T>.ThrowIfNull(result, "result");
            if (m * n2 != result.Length)
                throw new ArgumentOutOfRangeException("result");
            var solver = SolversResolver.GetGenericSolver<T>();
            T[] resultTemp = null;
            if (result == value1 || result == value2)
            {
                resultTemp = result;
                result = new T[result.Length];
            }
            if (resultTemp == null)
                for (int i = 0; i < result.Length; ++i)
                    result[i] = default(T);
            for (int i = 0; i < m; ++i)
            {
                int value1End = n1 * (i + 1);
                for (int value1Index = n1 * i, ii = 0; value1Index < value1End; ++value1Index, ++ii)
                {
                    int value2End = n2 * (ii + 1);
                    T value1Value = value1[value1Index];
                    for (int value2Index = n2 * ii, resultIndex = n2 * i; value2Index < value2End; ++value2Index, ++resultIndex)
                        result[resultIndex] = solver.Addition(result[resultIndex], solver.Multiply(value1Value, value2[value2Index]));
                }
            }
            if (resultTemp != null)
                Array.Copy(result, resultTemp, result.Length);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        public virtual void Multiply(Matrix<T> value1, Matrix<T> value2, ref Matrix<T> result)
        {
            ThrowHelper<T>.ThrowIfNull(value1, "value1");
            ThrowHelper<T>.ThrowIfNull(value2, "value2");
            if (value1.ColumnsCount != value2.RowsCount)
                throw new ArgumentOutOfRangeException("Columns count of first value must be equal to rows count of second value!");
            var fullMatrix1 = value1 as FullMatrix<T>;
            if (fullMatrix1 != null)
            {
                var fullMatrix2 = value2 as FullMatrix<T>;
                if (fullMatrix2 == null)
                    throw new NotImplementedException("The type of value1 is different than value2 type!");
                var fullResult = result as FullMatrix<T>;
                if (fullResult == null)
                {
                    if (result != null)
                        throw new NotImplementedException("Result type is different than value types!");
                    fullResult = new FullMatrix<T>(value1.RowsCount, value1.ColumnsCount);
                }
                else
                    if (value1.RowsCount != result.RowsCount || value2.ColumnsCount != result.ColumnsCount)
                        throw new ArgumentOutOfRangeException("Rows counts of first value and result must be equal! Columns counts of second value and result must be equal!");
                result = fullResult;
                FullMatrixMatrixMultiply(fullMatrix1.RowsCount, fullMatrix1.ColumnsCount, fullMatrix1.m_Values, fullMatrix2.ColumnsCount, fullMatrix2.m_Values, fullResult.m_Values);
            }
            else
            {
                var csrMatrix1 = value1 as CsrMatrix<T>;
                if (csrMatrix1 != null)
                {
                    var csrMatrix2 = value2 as CsrMatrix<T>;
                    if (csrMatrix2 == null)
                        throw new NotImplementedException("The type of value1 is different than value2 type!");
                    int minimumCapacity = csrMatrix1.Filling > csrMatrix2.Filling ? csrMatrix1.Filling : csrMatrix2.Filling;
                    var csrResult = result as CsrMatrix<T>;
                    if (csrResult == null)
                    {
                        if (result != null)
                            throw new NotImplementedException("Result type is different than value type!");
                        csrResult = new CsrMatrix<T>(csrMatrix1.RowsCount, csrMatrix1.ColumnsCount, minimumCapacity);
                    }
                    else
                    {
                        if (value1.RowsCount != result.RowsCount || value2.ColumnsCount != result.ColumnsCount)
                            throw new ArgumentOutOfRangeException("Rows counts of first value and result must be equal! Columns counts of second value and result must be equal!");
                        if (csrResult.Capacity < minimumCapacity)
                            csrResult.Capacity = minimumCapacity;
                    }
                    result = csrResult;
                    CSRMatrixMatrixMultiply(csrMatrix1.RowsCount, csrMatrix1.ColumnsCount,
                        csrMatrix1.m_Values, csrMatrix1.m_Columns, csrMatrix1.m_RowsMapping,
                        csrMatrix2.ColumnsCount, csrMatrix2.m_Values, csrMatrix2.m_Columns, csrMatrix2.m_RowsMapping,
                        ref csrResult.m_Values, ref csrResult.m_Columns, ref csrResult.m_RowsMapping);
                }
                else
                    throw new NotImplementedException("Matrix type of value1 is not implemented!");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="value1"></param>
        /// <param name="value1Columns"></param>
        /// <param name="value1RowsMapping"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        public virtual void CSRMatrixVectorMultiply(int m, int n, T[] value1, int[] value1Columns, int[] value1RowsMapping, T[] value2, T[] result)
        {
            ThrowHelper<T>.ThrowIfCSRMatrix(m, n, value1, value1Columns, value1RowsMapping, "value1");
            ThrowHelper<T>.ThrowIfNull(value2, "value2");
            ThrowHelper<T>.ThrowIfNull(result, "result");
            if (n != value2.Length)
                throw new ArgumentOutOfRangeException("Columns count of value1 matrix not equal to length of value2 vector!");
            if (m != result.Length)
                throw new ArgumentOutOfRangeException("Rows count of value1 matrix not equal to length of result vector!");
            var solver = SolversResolver.GetGenericSolver<T>();
            T[] resultTemp = null;
            if (result == value1 || result == value2)
            {
                resultTemp = result;
                result = new T[result.Length];
            }
            int value1End;
            T item;
            for (int i = 0; i < m; ++i)
            {
                item = default(T);
                value1End = value1RowsMapping[i + 1];
                for (int value1Index = value1RowsMapping[i]; value1Index < value1End; ++value1Index)
                    item = solver.Addition(item, solver.Multiply(value1[value1Index], value2[value1Columns[value1Index]]));
                result[i] = item;
            }
            if (resultTemp != null)
                Array.Copy(result, resultTemp, result.Length);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        public virtual void FullMatrixVectorMultiply(int m, int n, T[] value1, T[] value2, T[] result)
        {
            ThrowHelper<T>.ThrowIfNull(value1, "value1");
            ThrowHelper<T>.ThrowIfNull(value2, "value2");
            ThrowHelper<T>.ThrowIfNull(result, "result");
            if (m * n != value1.Length)
                throw new ArgumentOutOfRangeException("value1");
            if (n != value2.Length)
                throw new ArgumentOutOfRangeException("Columns count of value1 matrix not equal to length of value2 vector!");
            if (m != result.Length)
                throw new ArgumentOutOfRangeException("Rows count of value1 matrix not equal to length of result vector!");
            var solver = SolversResolver.GetGenericSolver<T>();
            T[] resultTemp = null;
            if (result == value1 || result == value2)
            {
                resultTemp = result;
                result = new T[result.Length];
            }
            int value1End;
            T item;
            for (int i = 0; i < m; ++i)
            {
                item = default(T);
                value1End = n * (i + 1);
                for (int value1Index = n * i, j = 0; value1Index < value1End; ++value1Index, ++j)
                    item = solver.Addition(item, solver.Multiply(value1[value1Index], value2[j]));
                result[i] = item;
            }
            if (resultTemp != null)
                Array.Copy(result, resultTemp, result.Length);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        public virtual void Multiply(Matrix<T> value1, Vector<T> value2, ref FullVector<T> result)
        {
            ThrowHelper<T>.ThrowIfNull(value1, "value1");
            ThrowHelper<T>.ThrowIfNull(value2, "value2");
            T[] value2Values = CheckIsFull(value2);
            ThrowHelper<T>.ThrowIfNotMultiply(value1, value2);
            if (value1.ColumnsCount != value2.Count)
                throw new ArgumentOutOfRangeException("Columns count of value1 matrix are not equal the vector length!");
            if (result == null)
                result = new FullVector<T>(value1.RowsCount);
            else
                if (value1.RowsCount != result.Count)
                    throw new ArgumentOutOfRangeException("Rows count of value1 matrix are not equal the result length!");
            var fullMatrix = value1 as FullMatrix<T>;
            if (fullMatrix != null)
                FullMatrixVectorMultiply(value1.RowsCount, value1.ColumnsCount, fullMatrix.m_Values, value2Values, result.m_Values);
            else
            {
                var csrMatrix = value1 as CsrMatrix<T>;
                if (csrMatrix != null)
                    CSRMatrixVectorMultiply(value1.RowsCount, value1.ColumnsCount, csrMatrix.m_Values, csrMatrix.m_Columns, csrMatrix.m_RowsMapping, value2Values, result.m_Values);
                else
                    throw new NotImplementedException("Matrix type of value1 is not implemented!");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        public virtual void Multiply(Matrix<T> value1, T value2, ref Matrix<T> result)
        {
            ThrowHelper<T>.ThrowIfNull(value1, "value");
            var fullMatrix = value1 as FullMatrix<T>;
            if (fullMatrix != null)
            {
                FullMatrix<T> fullResult = CheckFullResultMatrix(value1, ref result);
                m_ArraySolver.Multiply(fullMatrix.m_Values, value2, fullResult.m_Values);
            }
            else
            {
                var csrMatrix = value1 as CsrMatrix<T>;
                if (csrMatrix != null)
                {
                    CsrMatrix<T> csrResult = CheckCSRResultMatrix(csrMatrix, ref result);
                    m_ArraySolver.Multiply(csrMatrix.m_Values, value2, csrResult.m_Values, csrMatrix.Filling);
                }
                else
                    ThrowHelper<T>.ThrowNotImplementedMatrixType("value1");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        /// <param name="length"></param>
        /// <param name="value1Index"></param>
        /// <param name="resultIndex"></param>
        public virtual void Multiply(Vector<T> value1, T value2, ref FullVector<T> result, int length = int.MaxValue, int value1Index = 0, int resultIndex = 0)
        {
            ThrowHelper<T>.ThrowIfNull(value1, "value1");
            if (length == int.MaxValue)
                length = value1.Count - value1Index;
            ThrowHelper<T>.ThrowIfOutOfRange("value1Index", value1Index, value1.Count, length);
            ThrowHelper<T>.ThrowIfLessThenZero("resultIndex", resultIndex);
            if (result == null)
                result = new FullVector<T>(resultIndex + length);
            else
                ThrowHelper<T>.ThrowIfOutOfRange("resultIndex", resultIndex, result.Count, length);
            T[] value1Values = CheckIsFull(value1);
            m_ArraySolver.Multiply(value1Values, value2, result.m_Values, length, value1Index, resultIndex);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="value1"></param>
        /// <param name="value1Columns"></param>
        /// <param name="value1RowsMapping"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        /// <param name="isVertical"></param>
        public virtual void CSRMatrixVectorElementsMultiply(int m, int n, T[] value1, int[] value1Columns, int[] value1RowsMapping, T[] value2, T[] result, bool isVertical = false)
        {
            ThrowHelper<T>.ThrowIfCSRMatrix(m, n, value1, value1Columns, value1RowsMapping, "value1");
            ThrowHelper<T>.ThrowIfNull(value2, "value2");
            ThrowHelper<T>.ThrowIfNull(result, "result");
            T[] resultTemp = null;
            if (result == value2)
            {
                resultTemp = result;
                result = new T[result.Length];
            }
            var solver = SolversResolver.GetGenericSolver<T>();
            int index;
            int end;
            if (isVertical)
            {
                if (value2.Length != m)
                    throw new Exception("Rows count of value1 matrix not equal to length value2 vector!");
                for (int i = 0; i < m; ++i)
                {
                    T item = value2[i];
                    index = value1RowsMapping[i];
                    end = value1RowsMapping[i + 1];
                    while (index != end)
                    {
                        result[index] = solver.Multiply(value1[index], item);
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
                        value1[index] = solver.Multiply(value1[index], value2[value1Columns[index]]);
                        index++;
                    }
                }
            }
            if (resultTemp != null)
                Array.Copy(result, resultTemp, result.Length);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        /// <param name="isVertical"></param>
        public virtual void FullMatrixVectorElementsMultiply(int m, int n, T[] value1, T[] value2, T[] result, bool isVertical = false)
        {
            ThrowHelper<T>.ThrowIfNull(value1, "value1");
            ThrowHelper<T>.ThrowIfNull(value2, "value2");
            if (result == null)
                result = value1;
            if (m < 0 || n < 0)
                throw new ArgumentOutOfRangeException("m or n is less than zero!");
            if (m * n != value1.Length)
                throw new ArgumentOutOfRangeException("value1");
            if (m * n != result.Length)
                throw new ArgumentOutOfRangeException("Rows count of value1 matrix not equal to length of result vector!");
            var solver = SolversResolver.GetGenericSolver<T>();
            int value1End;
            if (isVertical)
            {
                if (value2.Length != m)
                    throw new Exception("Rows count of first matrix not equal to vector elements count!");

                for (int i = 0; i < m; ++i)
                {
                    T item = value2[i];
                    value1End = i * (n + 1);
                    for (int j = i * n; i < value1End; ++j)
                        result[j] = solver.Multiply(value1[j], item);
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
                        result[j] = solver.Multiply(value1[j], value2[k]);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        /// <param name="isVertical"></param>
        public virtual void ElementsMultiply(Matrix<T> value1, Vector<T> value2, ref Matrix<T> result, bool isVertical = false)
        {
            ThrowHelper<T>.ThrowIfNull(value1, "value1");
            ThrowHelper<T>.ThrowIfNull(value2, "value2");
            T[] value2Values = CheckIsFull(value2);
            var fullMatrix = value1 as FullMatrix<T>;
            if (fullMatrix != null)
            {
                FullMatrix<T> fullResult = CheckFullResultMatrix(value1, ref result);
                FullMatrixVectorElementsMultiply(value1.RowsCount, value1.ColumnsCount, fullMatrix.m_Values, value2Values, fullResult.m_Values, isVertical);
            }
            else
            {
                var csrMatrix = value1 as CsrMatrix<T>;
                if (csrMatrix != null)
                {
                    CsrMatrix<T> csrResult = CheckCSRResultMatrix(csrMatrix, ref result);
                    CSRMatrixVectorElementsMultiply(value1.RowsCount, value1.ColumnsCount, csrMatrix.m_Values, csrMatrix.m_Columns, csrMatrix.m_RowsMapping, value2Values, csrResult.m_Values, isVertical);
                }
                else
                    throw new NotImplementedException("Matrix type of value1 is not implemented!");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        /// <param name="length"></param>
        /// <param name="value1Index"></param>
        /// <param name="value2Index"></param>
        /// <param name="resultIndex"></param>
        public virtual void Multiply(Vector<T> value1, Vector<T> value2, ref FullVector<T> result, int length = int.MaxValue, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            ThrowHelper<T>.ThrowIfNull(value1, "value1");
            ThrowHelper<T>.ThrowIfNull(value2, "value2");
            if (length == int.MaxValue)
                length = value1.Count - value1Index;
            ThrowHelper<T>.ThrowIfOutOfRange("value1Index", value1Index, value1.Count, length);
            ThrowHelper<T>.ThrowIfLessThenZero("resultIndex", resultIndex);
            if (result == null)
                result = new FullVector<T>(resultIndex + length);
            else
                ThrowHelper<T>.ThrowIfOutOfRange("resultIndex", resultIndex, result.Count, length);
            ThrowHelper<T>.ThrowIfOutOfRange("value2Index", value2Index, value2.Count, length);
            T[] value2Values = CheckIsFull(value2);
            T[] value1Values = CheckIsFull(value1);
            m_ArraySolver.Multiply(value1Values, value2Values, result.m_Values, length, value1Index, value2Index, resultIndex);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="length"></param>
        /// <param name="value1Index"></param>
        /// <param name="value2Index"></param>
        /// <returns></returns>
        public virtual T DotMultiply(Vector<T> value1, Vector<T> value2, int length = int.MaxValue, int value1Index = 0, int value2Index = 0)
        {
            FullVector<T> temp = null;
            Multiply(value1, value2, ref temp, length, value1Index, value2Index);
            return Summary(temp, length, 0);
        }
        #endregion Multiply
        #region Division
        public virtual void Division(Vector<T> b, Matrix<T> a, ref FullVector<T> result)
        {
            Matrix<T> temp = null;
            Decomposition(a, ref temp);
            Solve(temp, b, ref result);
        }
        public virtual void ElementsDivision(Matrix<T> value1, Vector<T> value2, ref Matrix<T> result, bool isVertical = false)
        {
            FullVector<T> temp = null;
            Negation(value2, ref temp);
            ElementsMultiply(value1, temp, ref result, isVertical);
        }
        /// <summary>
        /// Division the elements of vector <paramref name="value1"/> by elements of the vector <paramref name="value2"/>
        /// </summary>
        /// <param name="value1">The dividend vector</param>
        /// <param name="value2">The divisor vector</param>
        /// <param name="result">The result of division</param>
        /// <param name="length">A 32-bit integer that represents the number of elements to division</param>
        /// <param name="value1Index">A 32-bit integer that represents the index in the <paramref name="value1"/> vector at which division begins</param>
        /// <param name="value2Index">A 32-bit integer that represents the index in the <paramref name="value2"/> vector at which division begins</param>
        /// <param name="resultIndex">A 32-bit integer that represents the index in the <paramref name="result"/> vector at which copying result begins</param>
        /// <remarks>If the <paramref name="result"/> value is null, automatically creates a new instance of the <typeparamref name="FullVector<T>"/></remarks>
        public virtual void Division(Vector<T> value1, Vector<T> value2, ref FullVector<T> result, int length = int.MaxValue, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            ThrowHelper<T>.ThrowIfNull(value1, "value1");
            ThrowHelper<T>.ThrowIfNull(value2, "value2");
            if (length == int.MaxValue)
                length = value1.Count - value1Index;
            ThrowHelper<T>.ThrowIfOutOfRange("value1Index", value1Index, value1.Count, length);
            ThrowHelper<T>.ThrowIfLessThenZero("resultIndex", resultIndex);
            if (result == null)
                result = new FullVector<T>(resultIndex + length);
            else
                ThrowHelper<T>.ThrowIfOutOfRange("resultIndex", resultIndex, result.Count, length);
            ThrowHelper<T>.ThrowIfOutOfRange("value2Index", value2Index, value2.Count, length);
            T[] value2Values = CheckIsFull(value2);
            T[] value1Values = CheckIsFull(value1);
            m_ArraySolver.Division(value1Values, value2Values, result.m_Values, length, value1Index, value2Index, resultIndex);
        }

        public virtual void ElementsInversion(Matrix<T> value, ref Matrix<T> result)
        {
            ThrowHelper<T>.ThrowIfNull(value, "value");
            var fullMatrix = value as FullMatrix<T>;
            if (fullMatrix != null)
            {
                FullMatrix<T> fullResult = CheckFullResultMatrix(value, ref result);
                m_ArraySolver.Inversion(fullMatrix.m_Values, fullResult.m_Values);
            }
            else
            {
                var csrMatrix = value as CsrMatrix<T>;
                if (csrMatrix != null)
                {
                    CsrMatrix<T> csrResult = CheckCSRResultMatrix(csrMatrix, ref result);                  
                    m_ArraySolver.Inversion(csrMatrix.m_Values, csrResult.m_Values, csrMatrix.Filling);
                }
                else
                    ThrowHelper<T>.ThrowNotImplementedMatrixType("value");
            }
        }
        /// <summary>
        /// Invert the elements of vector <paramref name="value"/>/>
        /// </summary>
        /// <param name="value">The vector will be invert</param>
        /// <param name="result">The result of inverting</param>
        /// <param name="length">A 32-bit integer that represents the number of elements to invert</param>
        /// <param name="valueIndex">A 32-bit integer that represents the index in the <paramref name="value"/> vector at which inverting begins</param>
        /// <param name="resultIndex">A 32-bit integer that represents the index in the <paramref name="result"/> vector at which copying result begins</param>
        /// <remarks>If the <paramref name="result"/> value is null, automatically creates a new instance of the <typeparamref name="FullVector<T>"/></remarks>
        public virtual void ElementsInversion(Vector<T> value, ref FullVector<T> result, int length = int.MaxValue, int valueIndex = 0, int resultIndex = 0)
        {
            ThrowHelper<T>.ThrowIfNull(value, "value");
            if (length == int.MaxValue)
                length = value.Count - valueIndex;
            ThrowHelper<T>.ThrowIfOutOfRange("valueIndex", valueIndex, value.Count, length);
            ThrowHelper<T>.ThrowIfLessThenZero("resultIndex", resultIndex);
            if (result == null)
                result = new FullVector<T>(resultIndex + length);
            else
                ThrowHelper<T>.ThrowIfOutOfRange("resultIndex", resultIndex, result.Count, length);
            T[] valueValues = CheckIsFull(value);
            m_ArraySolver.Inversion(valueValues, result.m_Values, length, valueIndex, resultIndex);
        }
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
        public virtual void CSRMatrixTranspose(int m, int n, T[] value, int[] valueColumns, int[] valueRowsMapping, T[] result, int[] resultColumns, int[] resultRowsMapping)
        {
            ThrowHelper<T>.ThrowIfTwoCSRMatrix(m, n, value, valueColumns, valueRowsMapping, "value", result, resultColumns, resultRowsMapping, "result");
            if (IsReferencesEquals(value, valueColumns, valueRowsMapping, result, resultColumns, resultRowsMapping))
            {
                value = new T[result.Length];
                valueColumns = new int[resultColumns.Length];
                valueRowsMapping = new int[resultRowsMapping.Length];
                Array.Copy(result, value, result.Length);
                Array.Copy(resultColumns, valueColumns, resultColumns.Length);
                Array.Copy(resultRowsMapping, valueRowsMapping, resultRowsMapping.Length);
            }
            int[] tempIndexes = new int[m];
            Array.Copy(valueRowsMapping, tempIndexes, tempIndexes.Length);
            int head = 0;
            resultRowsMapping[0] = 0;
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m; ++j)
                {
                    int valueIndex = tempIndexes[j];
                    if (valueIndex == valueRowsMapping[j + 1])
                        continue;
                    if (valueColumns[valueIndex] == i)
                    {
                        result[head] = value[valueIndex];
                        resultColumns[head] = j;
                        tempIndexes[j]++;
                        head++;
                    }
                }
                resultRowsMapping[i + 1] = head;
            }
        }
        /// <summary>
        /// Transpose full matrix
        /// </summary>
        /// <param name="m">The first matrix rows count and second matrix columns count</param>
        /// <param name="n">The matrix columns count and second matrix rows count</param>
        /// <param name="value">The input matrix values</param>
        /// <param name="result">The result matrix values</param>
        public virtual void FullMatrixTranspose(int m, int n, T[] value, T[] result)
        {
            int size = m * n;
            ThrowHelper<T>.ThrowIfFullMatrix(m, n, value, "value");
            ThrowHelper<T>.ThrowIfFullMatrix(m, n, result, "result");
            // For own transposes
            if (result == value)
            {
                value = new T[size];
                Array.Copy(result, value, size);
            }
            // Main loop, pointers for row values
            int j = 0;
            int t = 0;
            for (int i = 0; i < size; ++i, j+=n)
            {
                if(j >= size)
                {
                    t++;
                    j = t;
                }
                result[i] = value[j];
            }
        }
        public virtual void Transpose(Matrix<T> value, ref Matrix<T> result)
        {
            ThrowHelper<T>.ThrowIfNull(value, "value");
            var fullMatrix = value as FullMatrix<T>;
            if (fullMatrix != null)
            {
                FullMatrix<T> fullResult = CheckFullResultMatrix(fullMatrix, ref result);
                FullMatrixTranspose(value.RowsCount, value.ColumnsCount, fullMatrix.m_Values, fullResult.m_Values);
            }
            else
            {
                var csrMatrix = value as CsrMatrix<T>;
                if (csrMatrix != null)
                {
                    CsrMatrix<T> csrResult = CheckCSRResultMatrix(csrMatrix, ref result);
                    CSRMatrixTranspose(value.RowsCount, value.ColumnsCount, csrMatrix.m_Values, csrMatrix.m_Columns, csrMatrix.m_RowsMapping, csrResult.m_Values, csrResult.m_Columns, csrResult.m_RowsMapping);
                }
                else
                    ThrowHelper<T>.ThrowNotImplementedMatrixType("value");
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
        public virtual void CSRMatrixDecomposition(int m, int n, T[] value, int[] valueColumns, int[] valueRowsMapping, ref T[] result, ref int[] resultColumns, int[] resultRowsMapping)
        {
            ThrowHelper<T>.ThrowIfCSRMatrix(m, n, value, valueColumns, valueRowsMapping, "value");
            var solver = SolversResolver.GetGenericSolver<T>();
            T[] diag = new T[n];
            int[] starts = new int[m];
            T[] values = new T[n + 2];
            int[] columns = new int[n + 2];
            int[] nexts = new int[n + 2];
            int head;
            T iiValue;
            T temp1;
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
                    temp1 = values[counter] = solver.Multiply(values[counter], diag[ii]);
                    int iiHead = resultRowsMapping[ii + 1];
                    int iiColumnIndex;
                    int currentIndex = nexts[counter];
                    int previousIndex = counter;
                    int columnIndex;
                    for (int iiCounter = starts[ii]; iiCounter < iiHead; ++iiCounter)
                    {
                        iiColumnIndex = resultColumns[iiCounter];
                        iiValue = result[iiCounter];
                        for (; ; )
                        {
                            // Get the column index of current element
                            columnIndex = columns[currentIndex];
                            if (columnIndex == iiColumnIndex)
                            {
                                // Set element in current position
                                values[currentIndex] = solver.Substraction(values[currentIndex], solver.Multiply(temp1, iiValue));
                                previousIndex = currentIndex;
                                currentIndex = nexts[currentIndex];
                                break;
                            }
                            if (columnIndex > iiColumnIndex)
                            {
                                // Reset the row current element
                                nexts[previousIndex] = head;
                                nexts[head] = currentIndex;
                                columns[head] = iiColumnIndex;
                                values[head] = solver.Negation(solver.Multiply(temp1, iiValue));
                                previousIndex = head;
                                head++;
                                break;
                            }
                            previousIndex = currentIndex;
                            currentIndex = nexts[currentIndex];
                        }
                    }
                }
                // Add new row
                int iNewRow = resultRowsMapping[i];
                if (head - 2 > result.Length - iNewRow)
                {
                    int newCapacity = result.Length * 2;
                    T[] newResult = new T[newCapacity];
                    int[] newResultColumns = new int[newCapacity];
                    Array.Copy(result, newResult, result.Length);
                    Array.Copy(resultColumns, newResultColumns, resultColumns.Length);
                }
                int column;
                for (int counter = nexts[0]; (column = columns[counter]) != int.MaxValue; counter = nexts[counter])
                {
                    resultColumns[iNewRow] = column;
                    if (column == i)
                    {
                        diag[i] = solver.Inversion(values[counter]);
                        starts[i] = iNewRow + 1;
                    }
                    result[iNewRow] = values[counter];
                    iNewRow++;
                }
                resultRowsMapping[i + 1] = iNewRow;
            }
        }
        /// <summary>
        /// Factorization of full matrix
        /// </summary>
        /// <param name="m">The matrices rows count</param>
        /// <param name="n">The matrices columns count</param>
        /// <param name="value">The input matrix values</param>
        /// <param name="result">The result matrix values</param>
        public virtual void FullMatrixDecomposition(int m, int n, T[] value, T[] result)
        {
            ThrowHelper<T>.ThrowIfFullMatrix(m, n, value, "value");
            ThrowHelper<T>.ThrowIfFullMatrix(m, n, result, "result");
            var solver = SolversResolver.GetGenericSolver<T>();
            if (value != result)
                Array.Copy(value, result, value.Length);
            for (int i = 0; i < m; ++i)
            {
                T temp1, temp2;
                // Get current row
                int index = i * n;
                int endIndex = (i + 1) * n;
                // Substract previous rows from current
                for (int ii = 0; ii < i; ++ii)
                {
                    int iiCounter = ii * (n + 1);
                    temp1 = solver.Inversion(result[iiCounter]);
                    temp2 = solver.Multiply(result[index + ii], temp1);
                    result[index + ii] = temp2;
                    iiCounter++;
                    for (int iCounter = index + ii + 1; iCounter < endIndex; ++iCounter, ++iiCounter)
                        result[iCounter] = solver.Substraction(result[iCounter], solver.Multiply(temp2, result[iiCounter]));
                }
            }
        }
        /// <summary>
        /// Factorization of matrix
        /// </summary>
        /// <param name="value">The input matrix</param>
        /// <param name="result">The result matrix</param>
        /// <param name="context">Factorization context</param>
        public virtual void Decomposition(Matrix<T> value, ref Matrix<T> result, SolvingContext context = null)
        {
            ThrowHelper<T>.ThrowIfNull(value, "value");
            var fullMatrix = value as FullMatrix<T>;
            if (fullMatrix != null)
            {
                FullMatrix<T> fullResult = CheckFullResultMatrix(value, ref result);
                FullMatrixDecomposition(value.RowsCount, value.ColumnsCount, fullMatrix.m_Values, fullResult.m_Values);
                result = fullResult;
            }
            else
            {
                var csrMatrix = value as CsrMatrix<T>;
                if (csrMatrix != null)
                {
                    var csrResult = result as CsrMatrix<T>;
                    if (csrResult == null)
                    {
                        if (result != null)
                            throw new NotImplementedException("Result type is different value type");
                        if (context == null)
                            context = GetSortingContext(csrMatrix);
                        csrResult = new CsrMatrix<T>(value.RowsCount, value.ColumnsCount, context.Count);
                    }
                    else
                        if (context != null && context.Count > csrResult.Capacity)
                            csrResult = new CsrMatrix<T>(value.RowsCount, value.ColumnsCount, context.Count);
                    result = csrResult;
                    CSRMatrixDecomposition(value.RowsCount, value.ColumnsCount, csrMatrix.m_Values, csrMatrix.m_Columns, csrMatrix.m_RowsMapping, ref csrResult.m_Values, ref csrResult.m_Columns, csrResult.m_RowsMapping);
                }
                else
                    ThrowHelper<T>.ThrowNotImplementedMatrixType("value");
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
        public virtual void CSRMatrixSolve(int m, int n, T[] factor, int[] factorColumns, int[] factorRowsMapping, T[] b, int bColumnsCount, T[] result)
        {
            if (b.Length != m)
                throw new ArgumentException("Matrix row dimensions must agree.");
            var solver = SolversResolver.GetGenericSolver<T>();
            if (bColumnsCount == 1)
            {
                if (b != result)
                    Array.Copy(b, result, b.Length);
                int columnIndex;
                T temp;
                int[] diagonalIndexes = new int[n];
                // Solve L*Y = B(piv,:)
                for (int i = 0; i < n; ++i)
                {
                    int head = factorRowsMapping[i + 1];
                    temp = default(T);
                    for (int ii = factorRowsMapping[i]; ii < head; ++ii)
                    {
                        columnIndex = factorColumns[ii];
                        if (columnIndex >= i)
                        {
                            if (columnIndex == i)
                                diagonalIndexes[i] = ii;
                            else
                                throw new Exception();
                            break;
                        }
                        temp = solver.Addition(temp, solver.Multiply(factor[ii], result[columnIndex]));
                    }
                    result[i] = solver.Substraction(result[i], temp);
                }
                // Solve U*X = Y;
                for (int i = n - 1; i >= 0; --i)
                {
                    int head = factorRowsMapping[i + 1];
                    temp = default(T);
                    for (int ii = diagonalIndexes[i] + 1; ii < head; ++ii)
                        temp = solver.Addition(temp, solver.Multiply(factor[ii], result[factorColumns[ii]]));
                    result[i] = solver.Substraction(result[i], temp);
                    result[i] = solver.Division(result[i], factor[diagonalIndexes[i]]);
                }
            }
            else
            {
                int nx = bColumnsCount;
                if (b != result)
                    Array.Copy(b, result, b.Length);
                int columnIndex, temp1;
                {
                    int[] diagonalIndexes = new int[n];
                    // Solve L*Y = B(piv,:)
                    for (int i = 0; i < n; ++i)
                    {
                        int count = factorRowsMapping[i + 1];
                        for (int ii = factorRowsMapping[i]; ii < count; ++ii)
                        {
                            columnIndex = factorColumns[ii];
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
                                result[temp1 + j] = solver.Substraction(result[temp1 + j], solver.Multiply(factor[ii], result[columnIndex + j]));
                        }
                    }
                    // Solve U*X = Y;
                    for (int i = n - 1; i >= 0; --i)
                    {
                        T val = solver.Inversion(factor[diagonalIndexes[i]]);
                        int count = factorRowsMapping[i + 1];
                        temp1 = i * bColumnsCount;
                        for (int ii = diagonalIndexes[i] + 1; ii < count; ++ii)
                        {
                            columnIndex = factorColumns[ii] * bColumnsCount;
                            for (int j = 0; j < nx; ++j)
                                result[temp1 + j] = solver.Substraction(result[temp1 + j], solver.Multiply(factor[ii], result[columnIndex + j]));
                        }
                        for (int j = 0; j < nx; ++j)
                            result[temp1 + j] = solver.Multiply(result[temp1 + j], val);
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
        public virtual void FullMatrixSolve(int m, int n, T[] factor, T[] b, int bn, T[] result)
        {
            ThrowHelper<T>.ThrowIfFullMatrix(m, n, factor, "factor");
            ThrowHelper<T>.ThrowIfFullMatrix(m, bn, b, "b");
            ThrowHelper<T>.ThrowIfFullMatrix(n, bn, result, "result");
            if (m < n)
                throw new Exception("m < n");
            if (b != result)
                Array.Copy(b, result, b.Length);
            var solver = SolversResolver.GetGenericSolver<T>();
            if (bn == 1)
            {
                T resultValue;
                // Solve L*Y = B(piv,:)
                for (int i = 0; i < n; ++i)
                {
                    resultValue = result[i];
                    for (int j = 0, factorCounter = i * n; j < i; ++j, ++factorCounter)
                        resultValue = solver.Substraction(resultValue, solver.Multiply(factor[factorCounter], result[j]));
                    result[i] = resultValue;
                }
                // Solve U*X = Y;
                for (int i = n - 1; i >= 0; --i)
                {
                    resultValue = result[i];
                    for (int j = i + 1, factorCounter = i * n + i + 1; j < n; ++j, ++factorCounter)
                        resultValue = solver.Substraction(resultValue, solver.Multiply(factor[factorCounter], result[j]));
                    result[i] = solver.Division(resultValue, factor[i * n + i]);
                }
            }
            else
            {
                // Solve L*Y = B(piv,:)
                int length = result.Length;
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0, factorCounter = i * n; j < i; ++j, ++factorCounter)
                    {
                        T factorValue = factor[factorCounter];
                        for (int mulCounter = j, resultCounter = i; resultCounter < length; mulCounter += bn, resultCounter += bn)
                            result[resultCounter] = solver.Substraction(result[resultCounter], solver.Multiply(factorValue, result[mulCounter]));
                    }
                }
                // Solve U*X = Y;
                for (int i = n - 1; i >= 0; --i)
                {
                    for (int j = i + 1, factorCounter = i * n + i + 1; j < n; ++factorCounter, ++j)
                    {
                        T factorValue = factor[factorCounter];
                        for (int mulCounter = j, resultCounter = i; resultCounter < length; ++resultCounter, mulCounter += bn)
                            result[resultCounter] = solver.Substraction(result[resultCounter], solver.Multiply(factorValue, result[mulCounter]));
                    }
                    T val = solver.Inversion(factor[i * n + i]);
                    for (int resultCounter = i; resultCounter < length; resultCounter += bn)
                        result[resultCounter] = solver.Multiply(result[resultCounter], val);
                }
            }
        }
        public virtual void Solve(Matrix<T> factor, FullMatrix<T> b, ref FullMatrix<T> result)
        {
            ThrowHelper<T>.ThrowIfNull(factor, "factor");
            ThrowHelper<T>.ThrowIfNull(b, "b");
            if (result == null)
                result = new FullMatrix<T>(factor.ColumnsCount, b.ColumnsCount);
            var fullMatrix = factor as FullMatrix<T>;
            if (fullMatrix != null)
                FullMatrixSolve(factor.RowsCount, factor.ColumnsCount, fullMatrix.m_Values, b.m_Values, b.ColumnsCount, result.m_Values);
            else
            {
                var csrMatrix = factor as CsrMatrix<T>;
                if (csrMatrix != null)
                    CSRMatrixSolve(factor.RowsCount, factor.ColumnsCount, csrMatrix.m_Values, csrMatrix.m_Columns, csrMatrix.m_RowsMapping, b.m_Values, b.ColumnsCount, result.m_Values);
                else
                    ThrowHelper<T>.ThrowNotImplementedMatrixType("factor");
            }
        }
        public virtual void Solve(Matrix<T> factor, Vector<T> b, ref FullVector<T> result)
        {
            ThrowHelper<T>.ThrowIfNull(factor, "factor");
            ThrowHelper<T>.ThrowIfNull(b, "b");
            if (result == null)
                result = new FullVector<T>(factor.ColumnsCount);
            T[] bValues = CheckIsFull(b);
            var fullMatrix = factor as FullMatrix<T>;
            if (fullMatrix != null)
                FullMatrixSolve(factor.RowsCount, factor.ColumnsCount, fullMatrix.m_Values, bValues, 1, result.m_Values);
            else
            {
                var csrMatrix = factor as CsrMatrix<T>;
                if (csrMatrix != null)
                    CSRMatrixSolve(factor.RowsCount, factor.ColumnsCount, csrMatrix.m_Values, csrMatrix.m_Columns, csrMatrix.m_RowsMapping, bValues, 1, result.m_Values);
                else
                    ThrowHelper<T>.ThrowNotImplementedMatrixType("factor");
            }
        }
        #endregion Solve
        #region Sorting
        class Node
        {
            public int Connectivity;
            public bool IsUsed;
            public int Index;
            public int StartIndex;
            public int EndIndex;
        }
        public virtual int[] CSRSorting(int m, int n, T[] value, int[] valueColumns, int[] valueRowsMapping)
        {
            Stack<Node> stack = new Stack<Node>(m);
            Node[] nodes = new Node[m];
            List<int> sortedIds = new List<int>(m);
            int currentNumber = 0;
            int currentConnectivity = 0;
            for (int i = 0; i < m; ++i)
            {
                int index = valueRowsMapping[i];
                int endIndex = valueRowsMapping[i + 1];
                int connectivity = endIndex - index - 1;
                if (connectivity > currentConnectivity)
                {
                    currentConnectivity = connectivity;
                    currentNumber = i;
                }
                nodes[i] = new Node() { Connectivity = connectivity, Index = i };
            }
            Node currentNode = nodes[currentNumber];
            stack.Push(currentNode);
            sortedIds.Add(currentNumber);
            while (stack.Count > 0)
            {
                currentNode = stack.Peek();
                currentNode.IsUsed = true;
                Node pretendent = null;
                int bestUsedCount = 0;
                for (int i = currentNode.StartIndex; i < currentNode.EndIndex; ++i)
                {
                    if (i == currentNode.Index)
                        continue;
                    Node anotherNode = nodes[i];
                    if (anotherNode.IsUsed)
                        continue;
                    int usedCount = 0;
                    for (int j = anotherNode.StartIndex; j < anotherNode.EndIndex; ++j)
                    {
                        if (j == i)
                            continue;
                        if (nodes[j].IsUsed)
                            usedCount++;
                    }
                    if (usedCount > bestUsedCount || pretendent == null)
                    {
                        pretendent = anotherNode;
                        bestUsedCount = usedCount;
                    }
                    else
                        if (usedCount == bestUsedCount)
                            if (pretendent != null && pretendent.Connectivity < anotherNode.Connectivity)
                                pretendent = anotherNode;
                }
                if (pretendent != null)
                {
                    pretendent.IsUsed = true;
                    sortedIds.Add(pretendent.Index);
                    stack.Push(pretendent);
                }
                else
                    stack.Pop();
            }
            sortedIds.Reverse();
            return sortedIds.ToArray();
        }
        unsafe public virtual SolvingContext GetSortingContext(CsrMatrix<T> a)
        {
            int totalCount = 0;
            int m = a.m_RowsCount;
            int n = a.m_ColumnsCount;
            int[][] retColumns = new int[m][];
            int[] starts = new int[m];
            int[] columns = new int[n + 2];
            int[] nexts = new int[n + 2];
            int head;
            fixed (int* columnsPtr = columns, nextsPtr = nexts)
            for (int i = 0; i < m; ++i)
            {
                // Get current row
                int index = a.m_RowsMapping[i];
                int endIndex = a.m_RowsMapping[i + 1];
                head = 1; 
                nexts[0] = 1;
                columns[0] = -1;
                for (; index < endIndex; ++index)
                {
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
                    int[] iiColumns = retColumns[ii];
                    int iiColumnIndex;
                    // Block counterValue;
                    int currentIndex = nexts[counter];
                    int previousIndex = counter;
                    for (int iiCounter = starts[ii]; iiCounter < iiColumns.Length; ++iiCounter)
                    {
                        iiColumnIndex = iiColumns[iiCounter];
                        int columnIndex;
                        for (; ; )
                        {
                            // Get the column index of current element
                            columnIndex = columnsPtr[currentIndex];
                            if (columnIndex == iiColumnIndex)
                            {
                                // Set element in current position
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
                int[] tempColumns = retColumns[i] = new int[head - 2];
                head = 0;
                int column;
                for (int counter = nexts[0]; (column = columns[counter]) != int.MaxValue; counter = nexts[counter])
                {
                    tempColumns[head] = column;
                    if (column == i)
                        starts[i] = head + 1;
                    head++;
                }
                totalCount += tempColumns.Length;
            }
            return new SolvingContext(totalCount) { vv = retColumns };
        }
        public virtual SolvingContext GetSortingContext(FullMatrix<T> a)
        {
            return null;
        }
        #endregion Sorting
        #region Equals
        public virtual bool CSRMatrixEquality(int m, int n, T[] value1, int[] value1Columns, int[] value1RowsMapping, T[] value2, int[] value2Columns, int[] value2RowsMapping)
        {
            ThrowHelper<T>.ThrowIfCSRMatrix(m, n, value1, value1Columns, value1RowsMapping, "value1");
            ThrowHelper<T>.ThrowIfCSRMatrix(m, n, value2, value2Columns, value2RowsMapping, "value2");

            for (int i = 0; i < m; ++i)
            {
                int index1 = value1RowsMapping[i];
                int end1 = value1RowsMapping[i + 1];
                int index2 = value2RowsMapping[i];
                int end2 = value2RowsMapping[i + 1];

                while (index1 != end1 || index2 != end2)
                {
                    if (value1Columns[index1] == value2Columns[index2])
                    {
                        if (!value1[index1].Equals(value2[index2]))
                            return false;
                        index1++;
                        index2++;
                        continue;
                    }
                    else
                    {
                        if (value1Columns[index1] > value2Columns[index2])
                        {
                            if (!value2[index2].Equals(default(T)))
                                return false;
                            index2++;
                        }
                        else
                        {
                            if (!value1[index1].Equals(default(T)))
                                return false;
                            index1++;
                        }
                    }
                }
                for(;index1 != end1; ++index1)
                    if (!value1[index1].Equals(default(T)))
                        return false;
                for (; index2 != end2; ++index2)
                    if (!value2[index1].Equals(default(T)))
                        return false;
            }
            return true;
        }
        public virtual bool Equality(Matrix<T> value1, Matrix<T> value2)
        {
            if ((object)value1 == (object)value2)
                return true;
            if ((object)value1 == null)
                return false;
            if ((object)value2 == null)
                return false;
            if (value1.RowsCount != value2.RowsCount || value1.ColumnsCount != value2.ColumnsCount)
                return false;
            var fullMatrix1 = value1 as FullMatrix<T>;
            if (fullMatrix1 != null)
            {
                var fullMatrix2 = value2 as FullMatrix<T>;
                if (fullMatrix2 == null)
                    throw new NotImplementedException("The type of value1 is different than value2 type!");
                return m_ArraySolver.Equality(fullMatrix1.m_Values, fullMatrix2.m_Values);
            }
            else
            {
                var csrMatrix1 = value1 as CsrMatrix<T>;
                if (csrMatrix1 != null)
                {
                    var csrMatrix2 = value2 as CsrMatrix<T>;
                    if (csrMatrix2 == null)
                        throw new NotImplementedException("The type of value1 is different than value2 type!");
                    return CSRMatrixEquality(csrMatrix1.RowsCount, csrMatrix1.ColumnsCount,
                        csrMatrix1.m_Values, csrMatrix1.m_Columns, csrMatrix1.m_RowsMapping,
                        csrMatrix2.m_Values, csrMatrix2.m_Columns, csrMatrix2.m_RowsMapping);
                }
                else
                    throw new NotImplementedException("Matrix type of value1 is not implemented!");
            }
        }
        #endregion Equals
        #region IO
        public virtual void CreateCSRMatrix(int m, int n, SortedList<int, T>[] values, ref CsrMatrix<T> result)
        {
            if (m < 0 || n < 0)
                throw new ArgumentOutOfRangeException("m or n");
            ThrowHelper<T>.ThrowIfNull(values, "values");
            if(m != values.Length)
                throw new ArgumentOutOfRangeException("values");
            if (((object)result) == null)
                result = new CsrMatrix<T>(m, n, m * 5);
            else
            {
                result.m_Version++;
                result.m_RowsMapping = new int[1];
                result.m_RowsCount = 0;
            }
            for (int i = 0; i < m; ++i)
                result.AddRow(values[i]);
        }
        public virtual void ReadCSRMatrix(Stream stream, int m, int n, int count, ref CsrMatrix<T> result, StreamType type = StreamType.ElementByRowText)
        {
            if (m < 0 || n < 0)
                throw new ArgumentOutOfRangeException("m or n");
            ThrowHelper<T>.ThrowIfNull(stream, "stream");
            SortedList<int, T>[] readedValues = new SortedList<int, T>[m];
            for (int i = 0; i < m; ++i)
                readedValues[i] = new SortedList<int, T>();
            switch (type)
            {
                case StreamType.ElementByRowText:
                    {
                        var solver = SolversResolver.GetGenericSolver<T>();
                        StreamReader reader = new StreamReader(stream);
                        System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;
                        for (int i = 0; i < count; ++i)
                        {
                            string line = reader.ReadLine();
                            if (string.IsNullOrWhiteSpace(line))
                                continue;
                            string[] elements = line.Split();
                            if (elements == null || elements.Length != 3)
                                continue;
                            int rowIndex, columnIndex;
                            T value;
                            if (!int.TryParse(elements[0], out rowIndex))
                                continue;
                            if (rowIndex < 0 || rowIndex >= m)
                                continue;
                            if (!int.TryParse(elements[1], out columnIndex))
                                continue;
                            if (columnIndex < 0 || columnIndex >= n)
                                continue;
                            if (solver.TryParse(elements[2], culture, out value))
                                continue;
                            readedValues[rowIndex][columnIndex] = value;
                        }
                    }
                    break;
                case StreamType.CSRBinary:
                    {
                        var solver = SolversResolver.GetGenericSolver<T>();
                        BinaryReader reader = new BinaryReader(stream);
                        int length = System.Runtime.InteropServices.Marshal.SizeOf(default(T));
                        int length1 = length * count;
                        byte[] values = reader.ReadBytes(length1);
                        byte[] columns = reader.ReadBytes(count * 4);
                        int[] rowsMapping = new int[m + 1];
                        int rowIndex = rowsMapping[0] = reader.ReadInt32();
                        if (rowIndex < 0 || rowIndex > count)
                            throw new IndexOutOfRangeException("stream");
                        for (int i = 0; i < m; ++i)
                        {
                            rowsMapping[i + 1] = reader.ReadInt32();
                            if (rowIndex < 0 || rowIndex > count)
                                throw new IndexOutOfRangeException("stream");
                            for (int j = rowsMapping[i]; j < rowIndex; ++j)
                            {
                                T res;
                                if (!solver.TryConvert(values, j * length, out res))
                                    continue;
                                int column = BitConverter.ToInt32(columns, j * 4);
                                if (column < 0 || column > n)
                                    continue;
                                readedValues[i].Add(column, res);
                            }
                        }

                    }
                    break;
                default:
                    throw new NotImplementedException();
            }
            if (result == null)
                result = new CsrMatrix<T>(m, n, count);
            else
            {
                if (result.RowsCount != m || result.ColumnsCount != n)
                    throw new ArgumentOutOfRangeException("result.RowsCount != m || result.ColumnsCount != n!");
                if (result.Capacity < count)
                    result.Capacity = count;
            }
            CreateCSRMatrix(m, n, readedValues, ref result);
        }
        public virtual void ReadFullMatrix(Stream stream, int m, int n, ref FullMatrix<T> result, StreamType type = StreamType.ElementByRowText)
        {
            if (m < 0 || n < 0)
                throw new ArgumentOutOfRangeException("m or n");
            ThrowHelper<T>.ThrowIfNull(stream, "stream");
            if (result == null)
                result = new FullMatrix<T>(m, n);
            else
            {
                if (result.RowsCount != m || result.ColumnsCount != n)
                    throw new ArgumentOutOfRangeException("result.RowsCount != m || result.ColumnsCount != n!");
            }
            int count = m * n;
            switch (type)
            {
                case StreamType.ElementByRowText:
                    {
                        var solver = SolversResolver.GetGenericSolver<T>();
                        StreamReader reader = new StreamReader(stream);
                        System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;
                        while(!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            if (string.IsNullOrWhiteSpace(line))
                                continue;
                            string[] elements = line.Split();
                            if (elements == null || elements.Length != 3)
                                continue;
                            int rowIndex, columnIndex;
                            T value;
                            if (!int.TryParse(elements[0], out rowIndex))
                                continue;
                            if (rowIndex < 0 || rowIndex >= m)
                                continue;
                            if (!int.TryParse(elements[1], out columnIndex))
                                continue;
                            if (columnIndex < 0 || columnIndex >= n)
                                continue;
                            if (solver.TryParse(elements[2], culture, out value))
                                continue;
                            result[rowIndex, columnIndex] = value;
                        }
                    }
                    break;
                case StreamType.FullBinary:
                    {
                        var solver = SolversResolver.GetGenericSolver<T>();
                        BinaryReader reader = new BinaryReader(stream);
                        int length = System.Runtime.InteropServices.Marshal.SizeOf(default(T));
                        int length1 = length * count;
                        byte[] values = reader.ReadBytes(length1);
                        for (int i = 0; i < m; ++i)
                        {
                            int end = (i + 1) * n;
                            for (int j = i * n; j < end; ++j)
                            {
                                T value;
                                if (!solver.TryConvert(values, j * length, out value))
                                    continue;
                                result[i, j] = value;
                            }
                        }
                    }
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        #endregion IO
        #region Convert
        /// <summary>
        /// Convert from <typeparamref name="K"/> matrix to <typeparamref name="T"/> matrix
        /// </summary>
        /// <param name="value">The value will be convert</param>
        /// <param name="result">The result of matrix conversion</param>
        public virtual void From<K>(Matrix<K> value, ref Matrix<T> result)
        {
            ThrowHelper<T>.ThrowIfNull(value, "value");
            var fullMatrix = value as FullMatrix<K>;
            if (fullMatrix != null)
            {
                var fullResult = result as FullMatrix<T>;
                if (fullResult == null)
                {
                    if (result != null)
                        throw new NotImplementedException("Result type is different value type");
                    fullResult = new FullMatrix<T>(value.RowsCount, value.ColumnsCount);
                }
                else
                    if (value.RowsCount != result.RowsCount || value.ColumnsCount != result.ColumnsCount)
                        throw new ArgumentOutOfRangeException("Matrix sizes are not equal!");
                result = fullResult;
                m_ArraySolver.From<K>(fullMatrix.m_Values, fullResult.m_Values);
            }
            else
            {
                var csrMatrix = value as CsrMatrix<K>;
                if (csrMatrix != null)
                {
                    var csrResult = result as CsrMatrix<T>;
                    if (csrResult == null)
                    {
                        if (result != null)
                            throw new NotImplementedException("Result type is different value type");
                        csrResult = new CsrMatrix<T>(value.RowsCount, value.ColumnsCount, csrMatrix.Filling);
                    }
                    else
                    {
                        if (value.RowsCount != result.RowsCount || value.ColumnsCount != result.ColumnsCount)
                            throw new ArgumentOutOfRangeException("Matrix sizes are not equal!");
                        if (csrResult.Capacity < csrMatrix.Filling)
                            csrResult.Capacity = csrMatrix.Filling;
                    }
                    if (!object.ReferenceEquals(csrMatrix, csrResult))
                    {
                        Array.Copy(csrMatrix.m_RowsMapping, 0, csrResult.m_RowsMapping, 0, csrMatrix.m_RowsMapping.Length);
                        Array.Copy(csrMatrix.m_Columns, 0, csrResult.m_Columns, 0, csrMatrix.Filling);
                    }
                    result = csrResult;
                    m_ArraySolver.From<K>(csrMatrix.m_Values, csrResult.m_Values, csrMatrix.Filling);
                }
                else
                    ThrowHelper<T>.ThrowNotImplementedMatrixType("value");
            }
        }
        /// <summary>
        /// Convert from <typeparamref name="K"/> vector to <typeparamref name="T"/> FullVector
        /// </summary>
        /// <param name="value">The value will be convert</param>
        /// <param name="result">The result of vector conversion</param>
        /// <param name="length">A 32-bit integer that represents the number of elements to conversion</param>
        /// <param name="valueIndex">A 32-bit integer that represents the index in the <paramref name="value"/> vector at which conversion begins</param>
        /// <param name="resultIndex">A 32-bit integer that represents the index in the <paramref name="result"/> vector at which conversion begins</param>
        public virtual void From<K>(Vector<K> value, ref FullVector<T> result, int length = int.MaxValue, int valueIndex = 0, int resultIndex = 0)
        {
            ThrowHelper<T>.ThrowIfNull(value, "value");
            if (length == int.MaxValue)
                length = value.Count - valueIndex;
            ThrowHelper<T>.ThrowIfOutOfRange("valueIndex", valueIndex, value.Count, length);
            if (result == null)
                result = new FullVector<T>(resultIndex + length);
            else
                ThrowHelper<T>.ThrowIfOutOfRange("resultIndex", resultIndex, result.Count, length);
            K[] valueValues;
            var temp = value as FullVector<K>;
            if (temp != null)
                valueValues = temp.m_Values;
            else
            {
                valueValues = new K[value.Count];
                value.CopyTo(valueValues, 0);
            }
            m_ArraySolver.From<K>(valueValues, result.m_Values, length, valueIndex, resultIndex);
        }
        #endregion Convert
        #region Set
        #endregion Set
        #endregion Public methods
        #region Internal methods
        protected static bool IsReferencesEquals(T[] value, int[] valueColumns, int[] valueRowsMapping, T[] result, int[] resultColumns, int[] resultRowsMapping)
        {
            bool probablyEqual = (value == result);
            if (valueColumns == resultColumns != probablyEqual)
                throw new ArgumentException();
            if (valueRowsMapping == resultRowsMapping != probablyEqual)
                throw new ArgumentException();
            return probablyEqual;
        }
        #endregion Internal methods
        #region Private methods
        unsafe protected internal static void GetCurrentRow(int i, T[] values, int[] columns, int[] nexts, T[] valueValues, int[] valueColumns, int[] valueRowsMapping, ref int head)
        {
            int index = valueRowsMapping[i];
            int endIndex = valueRowsMapping[i + 1];
            head = 1;
            nexts[0] = 1;
            columns[0] = -1;
            for (; index < endIndex; ++index)
            {
                values[head] = valueValues[index];
                columns[head] = valueColumns[index];
                nexts[head] = ++head;
            }
            nexts[head] = -1;
            columns[head] = int.MaxValue;
            head++;
        }
        protected internal static FullMatrix<T> CheckFullResultMatrix(Matrix<T> value, ref Matrix<T> result)
        {
            var fullResult = result as FullMatrix<T>;
            if (fullResult == null)
            {
                if (result != null)
                    throw new NotImplementedException("Result and value types are different!");
                fullResult = new FullMatrix<T>(value.RowsCount, value.ColumnsCount);
            }
            else
                if (value.RowsCount != result.RowsCount || value.ColumnsCount != result.ColumnsCount)
                    throw new ArgumentOutOfRangeException("Rows or columns counts are not equal!");
            result = fullResult;
            return fullResult;
        }
        protected internal static CsrMatrix<T> CheckCSRResultMatrix(CsrMatrix<T> csrMatrix, ref Matrix<T> result)
        {
            var csrResult = result as CsrMatrix<T>;
            if (csrResult == null)
            {
                if (result != null)
                    throw new NotImplementedException("Result type is different value type");
                csrResult = new CsrMatrix<T>(csrMatrix.RowsCount, csrMatrix.ColumnsCount, csrMatrix.Filling);
            }
            else
            {
                if (csrMatrix.RowsCount != result.RowsCount || csrMatrix.ColumnsCount != result.ColumnsCount)
                    throw new ArgumentOutOfRangeException("Rows or columns counts are not equal!");
                if (csrResult.Capacity < csrMatrix.Filling)
                    csrResult.Capacity = csrMatrix.Filling;
            }
            if (!object.ReferenceEquals(csrResult, csrMatrix))
            {
                Array.Copy(csrMatrix.m_Columns, csrResult.m_Columns, csrMatrix.Filling);
                Array.Copy(csrMatrix.m_RowsMapping, csrResult.m_RowsMapping, csrMatrix.RowsCount + 1);
            }
            result = csrResult;
            return csrResult;
        }
        
        protected static T[] CheckIsFull(Vector<T> value2)
        {
            T[] value2Values;
            var temp = value2 as FullVector<T>;
            if (temp != null)
                value2Values = temp.m_Values;
            else
            {
                value2Values = new T[value2.Count];
                value2.CopyTo(value2Values, 0);
            }
            return value2Values;
        }
        #endregion Private methods
        #region  Events, overrides
        #endregion Events, overrides
        #endregion Methods
    }
}
#endregion Working namespace