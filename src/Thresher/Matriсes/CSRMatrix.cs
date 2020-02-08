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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Runtime;
using System.Runtime.InteropServices;
#endregion Using namespaces
#region Working namespace
namespace AIlins.Thresher
{
    /// <summary>
    /// Very sparsity matrices database, only for assembly math
    /// </summary>
    public class CSRMatrix<T> : Matrix<T>
    {
        #region Classes, structures, enums
        public struct CSREnumerator : IEnumerator<VectorT<T>>, IEnumerator
        {
            private CSRMatrix<T> m_Matrix;
            private int m_Index;
            private int m_Version;
            private VectorT<T> m_Current;
            private bool m_IsColumn;
            /// <summary>Gets the element at the current position of the enumerator.</summary>
            /// <returns>The element in the <see cref="T:System.Collections.Generic.List`1" /> at the current position of the enumerator.</returns>
            public VectorT<T> Current
            {
                get
                {
                    if (m_Index < 0 || (m_IsColumn && m_Index >= m_Matrix.m_ColumnsCount) || (!m_IsColumn && m_Index >= m_Matrix.m_RowsCount))
                        throw new InvalidOperationException();
                    return m_Current;
                }
            }
            /// <summary>Gets the element at the current position of the enumerator.</summary>
            /// <returns>The element in the <see cref="T:System.Collections.Generic.List`1" /> at the current position of the enumerator.</returns>
            /// <exception cref="T:System.InvalidOperationException">The enumerator is positioned before the first element of the collection or after the last element. </exception>
            object IEnumerator.Current
            {
                get
                {
                    if (m_Index < 0 || (m_IsColumn && m_Index >= m_Matrix.m_ColumnsCount) || (!m_IsColumn && m_Index >= m_Matrix.m_RowsCount))
                        throw new InvalidOperationException();
                    return Current;
                }
            }
            internal CSREnumerator(CSRMatrix<T> list, bool isColumn = false)
            {
                m_Matrix = list;
                m_Index = -1;
                m_Version = list.m_Version;
                m_Current = null;
                m_IsColumn = isColumn;
            }
            /// <summary>Advances the enumerator to the next element of the <see cref="T:System.Collections.Generic.List`1" />.</summary>
            /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.</returns>
            /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
            public bool MoveNext()
            {
                CSRMatrix<T> matrix = m_Matrix;
                if (m_Version != matrix.m_Version)
                    throw new InvalidOperationException();
                m_Index++;
                if (m_IsColumn)
                {
                    if (m_Index >= m_Matrix.m_ColumnsCount)
                    {
                        m_Index = m_Matrix.m_ColumnsCount;
                        m_Current = null;
                        return false;
                    }
                }
                else
                {
                    if (m_Index >= m_Matrix.m_RowsCount)
                    {
                        m_Index = m_Matrix.m_RowsCount;
                        m_Current = null;
                        return false;
                    }
                }
                m_Current = new CSRMatrixVector<T>(m_Index, m_Matrix, m_IsColumn);
                return true;
            }
            /// <summary>Sets the enumerator to its initial position, which is before the first element in the collection.</summary>
            /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
            void IEnumerator.Reset()
            {
                if (m_Version != m_Matrix.m_Version)
                    throw new InvalidOperationException();
                m_Index = -1; ;
                m_Current = null;
            }
            public void Dispose()
            {
            }
        }
        public class CSRMatrixVector<T> : VectorT<T>
        {
            #region Classes, structures, enumerators
            public struct Enumerator : IEnumerator<Element<T>>, IEnumerator
            {
                private CSRMatrixVector<T> m_Vector;
                private int m_Index;
                private int m_Version;
                private Element<T> m_Current;
                private bool m_IsColumn;
                /// <summary>Gets the element at the current position of the enumerator.</summary>
                /// <returns>The element in the <see cref="T:System.Collections.Generic.List`1" /> at the current position of the enumerator.</returns>
                public Element<T> Current
                {
                    get
                    {
                        if (this.m_Index == m_Vector.m_Start - 1 || m_Index >= m_Vector.m_End)
                            throw new InvalidOperationException();
                        return m_Current;
                    }
                }
                /// <summary>Gets the element at the current position of the enumerator.</summary>
                /// <returns>The element in the <see cref="T:System.Collections.Generic.List`1" /> at the current position of the enumerator.</returns>
                /// <exception cref="T:System.InvalidOperationException">The enumerator is positioned before the first element of the collection or after the last element. </exception>
                object IEnumerator.Current
                {
                    get
                    {
                        if (m_Index == m_Vector.m_Start - 1 || m_Index >= m_Vector.m_End)
                            throw new InvalidOperationException();
                        return m_Current;
                    }
                }
                internal Enumerator(CSRMatrixVector<T> vector, bool isColumn = false)
                {
                    m_Vector = vector;
                    m_Index = vector.m_Start - 1;
                    m_Version = vector.m_Matrix.m_Version;
                    m_IsColumn = isColumn;
                    m_Current = default(Element<T>);
                }
                /// <summary>Advances the enumerator to the next element of the <see cref="T:System.Collections.Generic.List`1" />.</summary>
                /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.</returns>
                /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
                public bool MoveNext()
                {
                    if (m_Version != m_Vector.m_Matrix.m_Version)
                        throw new InvalidOperationException();
                    CSRMatrixVector<T> vector = m_Vector;
                    if (m_IsColumn)
                    {
                        m_Index++;
                        for (; m_Index < vector.m_Matrix.m_RowsCount; ++m_Index)
                        {
                            int end = vector.m_Matrix.m_RowsMapping[m_Index + 1];
                            for (int i = vector.m_Matrix.m_RowsMapping[m_Index]; i < end; ++i)
                            {
                                int column = vector.m_Matrix.m_Columns[i];
                                if (column > vector.m_Number)
                                    break;
                                if (column == vector.m_Number)
                                {
                                    T value = vector.m_Matrix.m_Values[i];
                                    if (object.Equals(value, default(T)))
                                        break;
                                    m_Current = new Element<T>(column, value);
                                    return true;
                                }
                            }
                        }
                        return false;
                    }
                    else
                    {
                        if (m_Index < m_Vector.m_End)
                        {
                            m_Index++;
                            for (; m_Index < vector.m_End; ++m_Index)
                            {
                                T value = vector.m_Matrix.m_Values[m_Index];
                                if (object.Equals(value, default(T)))
                                    continue;
                                int column = vector.m_Matrix.m_Columns[m_Index];
                                m_Current = new Element<T>(column, value);
                                return true;
                            }
                        }
                        m_Index = m_Vector.m_End;
                        m_Current = default(Element<T>);
                        return false;
                    }
                }
                /// <summary>Sets the enumerator to its initial position, which is before the first element in the collection.</summary>
                /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
                void IEnumerator.Reset()
                {
                    if (m_Version != m_Vector.m_Matrix.m_Version)
                        throw new InvalidOperationException();
                    if (m_IsColumn)
                        m_Index = -1;
                    else
                        m_Index = m_Vector.m_Start - 1;
                    m_Current = default(Element<T>);
                }
                public void Dispose()
                {
                }
            }
            #endregion Classes, structures, enumerators
            #region Constructors
            public CSRMatrixVector(int number, CSRMatrix<T> matrix, bool isColumn)
                : base()
            {
                m_Number = number;
                m_Count = matrix.ColumnsCount;
                m_Matrix = matrix;
                m_IsColumn = isColumn;
                m_Start = matrix.m_RowsMapping[m_Number];
                m_End = matrix.m_RowsMapping[m_Number + 1];
            }
            #endregion Constructors
            #region Variables
            /// <summary>
            /// Data value
            /// </summary>
            internal CSRMatrix<T> m_Matrix;
            /// <summary>
            /// Number of elements of the vector.
            /// </summary>
            internal int m_Count;
            internal int m_Number;
            internal int m_Version;
            internal bool m_IsColumn;
            internal int m_Start;
            internal int m_End;
            #endregion Variables
            #region Fields
            /// <summary>
            /// Number of elements of the vector.
            /// </summary>
            public override int Count
            {
                get
                {
                    return m_Count;
                }
            }
            public override bool IsReadOnly
            {
                get
                {
                    return false;
                }
            }
            public override T this[int i]
            {
                get
                {
                    if(m_IsColumn)
                        return m_Matrix[i, m_Number];
                    else
                        return m_Matrix[m_Number, i];
                }
                set
                {
                    if (m_IsColumn)
                        m_Matrix[i, m_Number] = value;
                    else
                        m_Matrix[m_Number, i] = value;
                }
            }
            #endregion Fields
            #region Methods
            #region Public methods
            #endregion Public methods
            #region Internal methods
            #endregion Internal methods
            #region Private methods
            #endregion Private methods
            #region Events, overrides
            public override IEnumerator<Element<T>> GetEnumerator()
            {
                if (m_Version != m_Matrix.m_Version)
                    throw new InvalidOperationException();
                return new Enumerator(this);
            }
            public override void CopyTo(T[] array, int index = 0, int arrayIndex = 0, int length = int.MaxValue)
            {
                if(m_Version != m_Matrix.m_Version)
                    throw new InvalidOperationException();
                ThrowHelper<T>.ThrowIfNull(array, "array");
                if (length == int.MaxValue)
                    length = Count - index;
                ThrowHelper<T>.ThrowIfOutOfRange("this", index, m_Count, length);
                ThrowHelper<T>.ThrowIfOutOfRange("array", arrayIndex, array.Length, length);
                if (m_IsColumn)
                {
                    for(int i = index, j = arrayIndex; i < index + length; ++i, ++j)
                        array[j] = m_Matrix[i, m_Number];
                }
                else
                {
                    T[] values = m_Matrix.m_Values;
                    int[] columns = m_Matrix.m_Columns;
                    for (int i = arrayIndex; i < length + arrayIndex; ++i)
                        array[i] = default(T);
                    int columnsEnd = index + length;
                    int arrayCorrection = -index + arrayIndex;
                    for (int i = m_Start; i < m_End; ++i)
                    {
                        int column = columns[i];
                        if (column >= index && column < columnsEnd)
                            array[column + arrayCorrection] = values[i];
                    }
                }
            }
            public override void CopyTo(VectorT<T> vector, int index = 0, int arrayIndex = 0, int length = int.MaxValue)
            {
                if (m_Version != m_Matrix.m_Version)
                    throw new InvalidOperationException();
                ThrowHelper<T>.ThrowIfNull(vector, "vector");
                FullVector<T> fullVector = vector as FullVector<T>;
                if (fullVector == null)
                    throw new NotSupportedException(vector.GetType().ToString());
                CopyTo(fullVector.m_Values, index, arrayIndex, length);
            }  
            #endregion Events, overrides
            #endregion Methods
        }
        #endregion Classes, structures, enums
        #region Constructors
        public CSRMatrix(int n)
            :this(0, n)
        {
        }
        public CSRMatrix(int m, int n, int capacity = 0)
        {
            m_Values = new T[capacity];
            m_Columns = new int[capacity];
            m_RowsMapping = new int[m + 1];
            m_ColumnsCount = n;
            m_RowsCount = m;
            m_RowsMapping[0] = 0;
        }
        #endregion Constructors
        #region Variables
        /// <summary>
        /// Data value
        /// </summary>
        internal T[] m_Values;
        /// <summary>
        /// First row element index
        /// </summary>
        internal int[] m_RowsMapping;
        /// <summary>
        /// Column index
        /// </summary>
        internal int[] m_Columns;
        /// <summary>
        /// Count of rows in matrix
        /// </summary>
        internal int m_RowsCount;
        /// <summary>
        /// Count of columns in matrix
        /// </summary>
        internal int m_ColumnsCount;
        internal int m_Version;
        #endregion Variables
        #region Fields
        /// <summary>
        /// Count of rows in matrix
        /// </summary>
        public override int RowsCount
        {
            get
            {
                return m_RowsCount;
            }
        }
        /// <summary>
        /// Count of columns in matrix
        /// </summary>
        public override int ColumnsCount
        {
            get
            {
                return m_ColumnsCount;
            }
        }
        /// <summary>
        /// Capasity of matrix cache
        /// </summary>
        internal int Capacity
        {
            get
            {
                return m_Values.Length;
            }
            set
            {
                EnsureCapacity(value);
            }
        }
        /// <summary>
        /// Count of filling part of CSR-storage
        /// </summary>
        internal int Filling
        {
            get
            {
                return m_RowsMapping[m_RowsMapping.Length - 1];
            }
        }
        /// <summary>
        /// Get or set element of matrix
        /// </summary>
        /// <param name="i">Row index of element</param>
        /// <param name="j">Column index of element</param>
        /// <returns>Element of matrix</returns>
        public override T this[int i, int j]
        {
            get
            {
                return Get(i, j);
            }
            set
            {
                Set(i, j, value);
            }
        }
        /// <summary>
        /// Get or set diagonal element
        /// </summary>
        /// <param name="i">Row and column index of diagonal element</param>
        /// <returns>i-th diagonal element</returns>
        public override T this[int i]
        {
            get
            {
                return Get(i, i);
            }
            set
            {
                Set(i, i, value);
            }
        }
        #endregion Fields
        #region Methods
        #region Public methods
        public List<int> Find(int column)
        {
            T def = default(T);
            List<int> returnValue = new List<int>();
            for (int m = 0; m < m_RowsCount; ++m)
            {
                int index = m_RowsMapping[m];
                int endIndex = m_RowsMapping[m + 1];
                for (; index < endIndex; ++index)
                {
                    if (m_Columns[index] == column)
                        if (!m_Values[index].Equals(def))
                            returnValue.Add(m);
                }
            }
            return returnValue;
        }
        public void Set(int m, int n, T value)
        {
            if (m >= m_RowsCount)
                throw new ArgumentOutOfRangeException("m");
            if (m < 0)
                throw new ArgumentOutOfRangeException("m");
            if (n >= m_ColumnsCount)
                throw new ArgumentOutOfRangeException("n");
            if (n < 0)
                throw new ArgumentOutOfRangeException("n");

            int index = m_RowsMapping[m];
            int endIndex = m_RowsMapping[m + 1];
            int l = m_RowsMapping[m_RowsMapping.Length - 1];
            for (; index < endIndex; ++index)
            {
                if (m_Columns[index] >= n)
                {
                    if (m_Columns[index] == n)
                    {
                        m_Values[index] = value;
                        break;
                    }
                    m_Version++;
                    if (m_Values.Length <= l)
                        EnsureCapacity(m_Values.Length + 1);
                    Array.Copy(m_Values, index, m_Values, index + 1, l - index);
                    Array.Copy(m_Columns, index, m_Columns, index + 1, l - index);
                    for (int t = m + 1; t < m_RowsMapping.Length; ++t)
                        m_RowsMapping[t]++;
                    m_Values[index] = value;
                    m_Columns[index] = n;
                    break;
                }
            }
            if (index == endIndex)
            {
                if (m_Values.Length <= l)
                    EnsureCapacity(m_Values.Length + 1);
                Array.Copy(m_Values, index, m_Values, index + 1, l - index);
                Array.Copy(m_Columns, index, m_Columns, index + 1, l - index);
                for (int t = m + 1; t < m_RowsMapping.Length; ++t)
                    m_RowsMapping[t]++;
                m_Values[index] = value;
                m_Columns[index] = n;
            }
        }
        public T Get(int m, int n)
        {
            if (m < 0)
                throw new ArgumentOutOfRangeException();
            if (m >= m_RowsCount)
                throw new ArgumentOutOfRangeException();
            if (n < 0)
                throw new ArgumentOutOfRangeException();
            if (n >= m_ColumnsCount)
                throw new ArgumentOutOfRangeException();
            int index = m_RowsMapping[m];
            int endIndex = m_RowsMapping[m + 1];
            for (; index < endIndex; ++index)
            {
                if (m_Columns[index] >= n)
                {
                    if (m_Columns[index] == n)
                        return m_Values[index];
                    return default(T);
                }
            }
            return default(T);
        }
        #endregion Public methods
        #region Internal methods
        #endregion Internal methods
        #region Private methods
        /// <summary>
        /// Ensure the matrix cache capacity
        /// </summary>
        /// <param name="newCapacity">New capacity of matrix cache</param>
        internal void EnsureCapacity(int min)
        {
            if (m_Values.Length < min)
            {
                m_Version++;
                int num = m_Values.Length * 2;
                if (num < min)
                    num = min;

                T[] values = new T[num];
                int[] columns = new int[num];

                Array.Copy(m_Values, values, m_RowsMapping[m_RowsCount]);
                Array.Copy(m_Columns, columns, m_RowsMapping[m_RowsCount]);
                m_Values = values;
                m_Columns = columns;
            }
        }
        #endregion Private methods
        #region  Events, overrides
        #region Explicit
        #endregion Explicit
        public override VectorT<T> Row(int i)
        {
            return new CSRMatrixVector<T>(i, this, false);
        }
        public override VectorT<T> Column(int i)
        {
            return new CSRMatrixVector<T>(i, this, true);
        }
        /// <summary>
        /// Add new row to matrix, increase rows count
        /// </summary>
        /// <param name="values">Key-valued collection of row elements</param>
        /// <param name="rowIndex">Index of inserting row</param>
        public override void AddRow(SortedList<int, T> values = null, int rowIndex = int.MaxValue)
        {
            if (rowIndex == int.MaxValue)
                rowIndex = m_RowsCount;
            if (rowIndex < 0 || rowIndex > m_RowsCount)
                throw new IndexOutOfRangeException("rowIndex");
            
            int shift = 0;
            if (values != null)
            {
                foreach (KeyValuePair<int, T> item in values)
                    if (item.Key >= m_ColumnsCount || item.Key < 0)
                        throw new ArgumentOutOfRangeException("values");
                int needCapacity = Filling + values.Count;
                if (Capacity < needCapacity)
                    EnsureCapacity(needCapacity);
                int index = m_RowsMapping[rowIndex];
                shift = values.Count;
                Array.Copy(m_Values, index, m_Values, index + shift, m_RowsMapping[m_RowsCount] - index);
                Array.Copy(m_Columns, index, m_Columns, index + shift, m_RowsMapping[m_RowsCount] - index);
                foreach (KeyValuePair<int, T> item in values)
                {
                    m_Columns[index] = item.Key;
                    m_Values[index] = item.Value;
                    index++;
                }
            }
            m_RowsCount++;
            m_Version++;
            int[] tempRowsMapping = new int[m_RowsCount + 1];
            Array.Copy(m_RowsMapping, tempRowsMapping, rowIndex);
            tempRowsMapping[rowIndex] = m_RowsMapping[rowIndex];
            for (int i = rowIndex; i < m_RowsCount; ++i)
                tempRowsMapping[i + 1] = m_RowsMapping[i] + shift;
            m_RowsMapping = tempRowsMapping;
        }
        /// <summary>
        /// Add new column to matrix, increase columns count
        /// </summary>
        /// <param name="values">Key-valued collection of column elements</param>
        /// <param name="columnIndex">Index of adding column</param>
        public override void AddColumn(SortedList<int, T> values = null, int columnIndex = int.MaxValue)
        {
            if (columnIndex == int.MaxValue)
                columnIndex = m_ColumnsCount;
            if (columnIndex < 0 || columnIndex > m_ColumnsCount)
                throw new IndexOutOfRangeException("columnIndex");

            if (values != null)
            {
                foreach (KeyValuePair<int, T> item in values)
                    if (item.Key >= m_RowsCount || item.Key < 0)
                        throw new ArgumentOutOfRangeException("values");
                int needCapacity = Filling + values.Count;
                if (Capacity < needCapacity)
                    EnsureCapacity(needCapacity);
            }
            m_ColumnsCount++;
            m_Version++;
            int newHead = m_RowsMapping[m_RowsCount] + values.Count;
            for (int i = m_RowsCount - 1; i >= 0; --i)
            {
                int index = m_RowsMapping[i + 1];
                int end = m_RowsMapping[i];
                m_RowsMapping[i + 1] = newHead;
                T element = default(T);
                bool needSet= false;
                if (values != null)
                    needSet = values.TryGetValue(i, out element);
                bool changed = false;
                for (; index > end; --index)
                {
                    int column = m_Columns[index];
                    if (column >= columnIndex)
                    {
                        newHead--;
                        m_Values[newHead] = m_Values[index];
                        m_Columns[newHead] = column + 1;
                    }
                    else
                    {
                        changed = true;
                        if (!changed && needSet)
                        {
                            needSet = false;
                            newHead--;
                            m_Values[newHead] = element;
                            m_Columns[newHead] = columnIndex;
                        }
                        changed = true;
                        newHead--;
                        m_Values[newHead] = m_Values[index];
                        m_Columns[newHead] = column;
                    }
                }
                if(needSet)
                {
                    newHead--;
                    m_Values[newHead] = element;
                    m_Columns[newHead] = columnIndex;
                }
            }
        }
        /// <summary>
        /// Remove row from matrix, decrease rows count
        /// </summary>
        /// <param name="rowIndex">Index of removind row</param>
        public override void RemoveRow(int rowIndex = int.MaxValue)
        {
            if (rowIndex == int.MaxValue)
                rowIndex = m_RowsCount - 1;
            if (rowIndex < 0 || rowIndex >= m_RowsCount)
                throw new IndexOutOfRangeException("rowIndex");
            if (m_RowsCount == 0)
                throw new IndexOutOfRangeException("RowsCount");

            int index = m_RowsMapping[rowIndex];
            int shift = m_RowsMapping[rowIndex + 1] - index;
            Array.Copy(m_Values, index + shift, m_Values, index, m_RowsMapping[m_RowsCount] - index - shift);
            Array.Copy(m_Columns, index + shift, m_Columns, index, m_RowsMapping[m_RowsCount] - index - shift);
            m_RowsCount--;
            m_Version++;
            int[] tempRowsMapping = new int[m_RowsCount + 1];
            Array.Copy(m_RowsMapping, tempRowsMapping, rowIndex);
            for (int i = rowIndex + 1; i < m_RowsCount; ++i)
                tempRowsMapping[i - 1] = m_RowsMapping[i] + shift;
            m_RowsMapping = tempRowsMapping;
        }
        /// <summary>
        /// Remove new column from matrix, decrease columns count
        /// </summary>
        /// <param name="columnIndex">Index of removind column</param>
        public override void RemoveColumn(int columnIndex = int.MaxValue)
        {
            if (columnIndex == int.MaxValue)
                columnIndex = m_ColumnsCount - 1;
            if (columnIndex < 0 || columnIndex >= m_ColumnsCount)
                throw new IndexOutOfRangeException("columnIndex");
            if (m_ColumnsCount == 0)
                throw new IndexOutOfRangeException("ColumnsCount");

            m_ColumnsCount++;
            m_Version++;
            int newHead = m_RowsMapping[0];
            for (int i = 0; i < m_RowsCount; ++i)
            {
                int index = m_RowsMapping[i];
                int end = m_RowsMapping[i + 1];
                for (; index < end; ++index)
                {
                    int column = m_Columns[index];
                    if (column > columnIndex)
                    {
                        m_Values[newHead] = m_Values[index];
                        m_Columns[newHead] = column - 1;
                        newHead++;
                    }
                    else
                        if(column < columnIndex)
                        {
                            m_Values[newHead] = m_Values[index];
                            m_Columns[newHead] = column;
                            newHead++;
                        }
                }
                m_RowsMapping[i + 1] = newHead;
            }
        }
        /// <summary>
        /// Change row in matrix
        /// </summary>
        /// <param name="rowIndex">Index of changing row</param>
        /// <param name="values">Key-valued collection of row elements</param>
        public override void SetRow(SortedList<int, T> values = null, int rowIndex = 0)
        {
            if (rowIndex < 0 || rowIndex >= m_RowsCount)
                throw new IndexOutOfRangeException("rowIndex");

            int shift = 0;
            if (values != null)
            {
                foreach (KeyValuePair<int, T> item in values)
                    if (item.Key >= m_ColumnsCount || item.Key < 0)
                        throw new ArgumentOutOfRangeException("values");
                int newLength = values.Count;
                int oldLength = m_RowsMapping[rowIndex + 1] - m_RowsMapping[rowIndex];
                int needCapacity = Filling + newLength - oldLength;
                if (Capacity < needCapacity)
                    EnsureCapacity(needCapacity);
                int index = m_RowsMapping[rowIndex];
                shift = newLength - oldLength;
                if (shift != 0)
                {
                    int movingLength = m_RowsMapping[m_RowsCount] - m_RowsMapping[rowIndex + 1];
                    Array.Copy(m_Values, index + oldLength, m_Values, index + newLength, movingLength);
                    Array.Copy(m_Columns, index + oldLength, m_Columns, index + newLength, movingLength);
                }
                foreach (KeyValuePair<int, T> item in values)
                {
                    m_Columns[index] = item.Key;
                    m_Values[index] = item.Value;
                    index++;
                }
            }
            m_Version++;
            for (int i = rowIndex; i < m_RowsCount; ++i)
                m_RowsMapping[i + 1] += shift;
        }
        public override IEnumerator<VectorT<T>> GetEnumerator()
        {
            return new CSREnumerator(this);
        }
        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="value"></param>
        public override object Clone()
        {
            CSRMatrix<T> returnValue = new CSRMatrix<T>(m_RowsCount, m_ColumnsCount, Capacity);
            Array.Copy(m_RowsMapping, returnValue.m_RowsMapping, m_RowsMapping.Length);
            Array.Copy(m_Columns, returnValue.m_Columns, m_Columns.Length);
            Array.Copy(m_Values, returnValue.m_Values, m_Values.Length);
            return returnValue;
        }
        #endregion Events, overrides
        #endregion Methods
    }
}
#endregion Working namespace
