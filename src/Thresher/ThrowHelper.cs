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
    internal static class ThrowHelper<T>
    {
        #region Classes, structures, enums
        #endregion Classes, structures, enums
        #region Constructors
        #endregion Constructors
        #region Variables
        #endregion Variables
        #region Fields
        #endregion Fields
        #region Methods
        #region Public methods
        #endregion Public methods
        #region Internal methods
        internal static void ThrowNotImplementedMatrixType(string value)
        {
            throw new NotImplementedException(string.Format("Matrix type of {0} is not implemented!", value));
        }
        internal static void ThrowIfTwoValues(T[] value1, T[] value2, ref int length, int value1Index, int value2Index)
        {
            ThrowIfNull(value1, "value1");
            ThrowIfNull(value2, "value2");
            if (length == int.MaxValue)
                length = value1.Length - value1Index;
            ThrowIfOutOfRange("value1Index", value1Index, value1.Length, length);
            ThrowIfOutOfRange("value2Index", value2Index, value2.Length, length);
        }
        internal static void ThrowIfTwoValuesWithNullableResult(T[] value1, T[] value2, ref T[] result, ref int length, int value1Index, int value2Index, int resultIndex)
        {
            ThrowIfNull(value1, "value1");
            ThrowIfNull(value2, "value2");
            if (length == int.MaxValue)
                length = value1.Length - value1Index;
            ThrowIfOutOfRange("value1Index", value1Index, value1.Length, length);
            ThrowIfLessThenZero("resultIndex", resultIndex);
            if (result == null)
                result = value1;
            ThrowIfOutOfRange("resultIndex", resultIndex, result.Length, length);
            ThrowIfOutOfRange("value2Index", value2Index, value2.Length, length);
        }
        internal static void ThrowIfOneValue(T[] value, ref int length, int valueIndex)
        {
            ThrowIfNull(value, "value");
            if (length == int.MaxValue)
                length = value.Length - valueIndex;
            ThrowIfOutOfRange("valueIndex", valueIndex, value.Length, length);
        }
        internal static void ThrowOneValueWithNullableResult(T[] value, ref T[] result, ref int length, int valueIndex, int resultIndex)
        {
            ThrowIfNull(value, "value");
            if (length == int.MaxValue)
                length = value.Length - valueIndex;
            ThrowIfOutOfRange("valueIndex", valueIndex, value.Length, length);
            ThrowIfLessThenZero("resultIndex", resultIndex);
            if (result == null)
                result = value;
            else
                ThrowIfOutOfRange("resultIndex", resultIndex, result.Length, length);
        }
        internal static void ThrowOneValueWithoutNullableResult<K>(K[] value, T[] result, ref int length, int valueIndex, int resultIndex)
        {
            ThrowIfNull(value, "value");
            ThrowIfNull(result, "result");
            if (length == int.MaxValue)
                length = value.Length - valueIndex;
            ThrowIfOutOfRange("valueIndex", valueIndex, value.Length, length);
            ThrowIfOutOfRange("resultIndex", resultIndex, result.Length, length);
        }
        internal static void ThrowIfOutOfRange(string paramName, int index, int count = int.MaxValue, int length = 0)
        {
            if (index < 0 || index > count - length || length < 0)
            {
                if (length == 0 && count == int.MaxValue)
                    throw new ArgumentOutOfRangeException(paramName, index, paramName);
                if (length == 0)
                    throw new ArgumentOutOfRangeException(paramName, index, string.Format("Count {0}", count));
                if (count == int.MaxValue)
                    throw new ArgumentOutOfRangeException(paramName, index, string.Format("length {0}", length));
                throw new ArgumentOutOfRangeException(paramName, index, string.Format("Count {0}, length {1}", count, length));
            }
        }
        internal static void ThrowIfNull(object value, string paramName)
        {
            if (value == null)
                throw new ArgumentNullException(paramName);
        }
        internal static void ThrowIfNullSolver(object value)
        {
            if (value == null)
                throw new Exception($"Solver for type {nameof(T)} is not defined!");
        }
        unsafe internal static void ThrowCSRMatrixMatrix(int m, int n, T[] value1, int[] value1Columns, int[] value1RowsMapping, T[] value2, int[] value2Columns, int[] value2RowsMapping, ref T[] result, ref int[] resultColumns, ref int[] resultRowsMapping)
        {
            if (m < 0 || n < 0)
                throw new ArgumentOutOfRangeException("m or n");
            ThrowIfCSRMatrix(m, n, value1, value1Columns, value1RowsMapping, "value1");
            ThrowIfCSRMatrix(m, n, value2, value2Columns, value2RowsMapping, "value2");
            if (result == null)
            {
                int length = value1.Length > value2.Length ? value1.Length : value2.Length;
                result = new T[length];
                resultColumns = new int[length];
                resultRowsMapping = new int[m + 1];
            }
            else
            {
                ThrowIfCSRMatrix(m, n, result, resultColumns, resultRowsMapping, "result");
                if (result == value1 || result == value2)
                {
                    int length = value1.Length > value2.Length ? value1.Length : value2.Length;
                    result = new T[length];
                    resultColumns = new int[length];
                    resultRowsMapping = new int[m + 1];
                }
            }
        }
        unsafe internal static void ThrowCSRMatrixMatrixMultiply(int m1, int n1m2, T[] value1, int[] value1Columns, int[] value1RowsMapping, int n2, T[] value2, int[] value2Columns, int[] value2RowsMapping, ref T[] result, ref int[] resultColumns, ref int[] resultRowsMapping)
        {
            if (m1 < 0 || n1m2 < 0 || n2 < 0)
                throw new ArgumentOutOfRangeException("m1 or n1m2 or n2");
            ThrowIfCSRMatrix(m1, n1m2, value1, value1Columns, value1RowsMapping, "value1");
            ThrowIfCSRMatrix(n1m2, n2, value2, value2Columns, value2RowsMapping, "value2");
            if (result == null)
            {
                int length = value1.Length > value2.Length ? value1.Length : value2.Length;
                result = new T[length];
                resultColumns = new int[length];
                resultRowsMapping = new int[m1 + 1];
            }
            else
            {
                ThrowIfCSRMatrix(m1, n2, result, resultColumns, resultRowsMapping, "result");
                if (result == value1 || result == value2)
                {
                    int length = value1.Length > value2.Length ? value1.Length : value2.Length;
                    result = new T[length];
                    resultColumns = new int[length];
                    resultRowsMapping = new int[m1 + 1];
                }
            }
        }
        internal static void ThrowIfCSRMatrix(int m, int n, T[] value, int[] valueColumns, int[] valueRowsMapping, string paramName)
        {
            if (value == null)
                throw new ArgumentNullException(paramName);
            if (valueColumns == null)
                throw new ArgumentNullException(paramName + "Columns");
            if (valueRowsMapping == null)
                throw new ArgumentNullException(paramName + "RowsMapping");
            if (object.ReferenceEquals(value, valueColumns))
                throw new ArgumentException(string.Format("{0} is equal to {1}!", paramName, paramName + "Columns"));
            if (object.ReferenceEquals(value, valueRowsMapping))
                throw new ArgumentException(string.Format("{0} is equal to {1}!", paramName, paramName + "RowsMapping"));
            if (object.ReferenceEquals(valueColumns, valueRowsMapping))
                throw new ArgumentException(string.Format("{0} is equal to {1}!", paramName + "Columns", paramName + "RowsMapping"));
            
            if (m < 0 || n < 0)
                throw new ArgumentOutOfRangeException("m or n is less than zero!");
            if (value.Length != valueColumns.Length)
                throw new ArgumentOutOfRangeException(paramName);
            if (m + 1 != valueRowsMapping.Length)
                throw new ArgumentOutOfRangeException(paramName + "RowsMapping");
        }
        internal static void ThrowIfTwoCSRMatrix(int m, int n, T[] value1, int[] value1Columns, int[] value1RowsMapping, string param1Name, T[] value2, int[] value2Columns, int[] value2RowsMapping, string param2Name)
        {
            ThrowIfCSRMatrix(m, n, value1, value1Columns, value1RowsMapping, param1Name);
            ThrowIfCSRMatrix(m, n, value2, value2Columns, value2RowsMapping, param2Name);
            if (object.ReferenceEquals(value1, value2Columns))
                throw new ArgumentException(string.Format("{0} is equal to {1}!", param1Name, param2Name + "Columns"));
            if (object.ReferenceEquals(value1, value2RowsMapping))
                throw new ArgumentException(string.Format("{0} is equal to {1}!", param1Name, param2Name + "RowsMapping"));
            if (object.ReferenceEquals(value1Columns, value2))
                throw new ArgumentException(string.Format("{0} is equal to {1}!", param1Name + "Columns", param2Name));
            if (object.ReferenceEquals(value1Columns, value2RowsMapping))
                throw new ArgumentException(string.Format("{0} is equal to {1}!", param1Name + "Columns", param2Name + "RowsMapping"));
            if (object.ReferenceEquals(value1RowsMapping, value2))
                throw new ArgumentException(string.Format("{0} is equal to {1}!", param1Name + "RowsMapping", param2Name));
            if (object.ReferenceEquals(value1RowsMapping, value2Columns))
                throw new ArgumentException(string.Format("{0} is equal to {1}!", param1Name + "RowsMapping", param2Name + "Columns"));
        }
        internal static void ThrowIfFullMatrix(int m, int n, T[] value, string paramName)
        {
            int size = m * n;
            ThrowHelper<T>.ThrowIfNull(value, paramName);
            if (size != value.Length)
                throw new ArgumentOutOfRangeException(paramName);
        }
        internal static void ThrowIfLessThenZero(string paramName, int index)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException(paramName, index, paramName);
        }
        internal static void ThrowIfNotMultiply(Matrix<T> value1, Vector<T> value2)
        {
            int n = value1.ColumnsCount;
            if (n != value2.Count)
                throw new Exception("Rows count of matrix not equal to length of vector!");
        }
        #endregion Internal methods
        #region Private methods
        #endregion Private methods
        #region  Events, overrides
        #endregion Events, overrides
        #endregion Methods
    }
}
#endregion Working namespace