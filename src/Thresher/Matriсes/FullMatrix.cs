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
#endregion Using namespaces
#region Working namespace
namespace AIlins.Thresher
{
    public class FullMatrix<T> : Matrix<T>
    {
        #region Classes, structures, enumerators
        public struct FullEnumerator : IEnumerator<VectorT<T>>, IEnumerator
        {
            private FullMatrix<T> m_Matrix;
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
                    return m_Current;
                }
            }
            internal FullEnumerator(FullMatrix<T> matrix, bool isColumn = false)
            {
                m_Matrix = matrix;
                m_Index = -1;
                m_Version = matrix.m_Version;
                m_Current = null;
                m_IsColumn = isColumn;
            }
            /// <summary>Advances the enumerator to the next element of the <see cref="T:System.Collections.Generic.List`1" />.</summary>
            /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.</returns>
            /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
            public bool MoveNext()
            {
                if (m_Version != m_Matrix.m_Version)
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
                m_Current = new FullMatrixVector<T>(m_Index, m_Matrix, m_IsColumn);
                return true;
            }
            /// <summary>Sets the enumerator to its initial position, which is before the first element in the collection.</summary>
            /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
            void IEnumerator.Reset()
            {
                if (m_Version != m_Matrix.m_Version)
                    throw new InvalidOperationException();
                m_Index = -1;
                m_Current = null;
            }
            public void Dispose()
            {
            }
        }
        public class FullMatrixVector<T> : VectorT<T>
        {
            #region Classes, structures, enumerators
            public struct Enumerator : IEnumerator<Element<T>>, IEnumerator
            {
                private FullMatrixVector<T> m_List;
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
                        if (m_Index < 0 || (m_IsColumn && m_Index >= m_List.m_Matrix.m_ColumnsCount) || (!m_IsColumn && m_Index >= m_List.m_Matrix.m_RowsCount))
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
                        if (m_Index < 0 || (m_IsColumn && m_Index >= m_List.m_Matrix.m_ColumnsCount) || (!m_IsColumn && m_Index >= m_List.m_Matrix.m_RowsCount))
                            throw new InvalidOperationException();
                        return m_Current;
                    }
                }
                internal Enumerator(FullMatrixVector<T> list, bool isColumn = false)
                {
                    m_List = list;
                    m_Index = - 1;
                    m_Version = list.m_Matrix.m_Version;
                    m_IsColumn = isColumn;
                    m_Current = default(Element<T>);
                }
                /// <summary>Advances the enumerator to the next element of the <see cref="T:System.Collections.Generic.List`1" />.</summary>
                /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.</returns>
                /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
                public bool MoveNext()
                {
                    if (m_Version != m_List.m_Matrix.m_Version)
                        throw new InvalidOperationException();
                    m_Index++;
                    for (; m_Index < m_List.m_Matrix.m_RowsCount; ++m_Index)
                    {
                        int number; 
                        if (m_IsColumn)
                            number = m_Index * m_List.m_Matrix.m_ColumnsCount + m_List.m_Number;
                        else
                            number = m_Index + m_List.m_Matrix.m_ColumnsCount * m_List.m_Number;
                        T value = m_List.m_Matrix.m_Values[number];
                        if (object.Equals(value, default(T)))
                            continue;
                        m_Current = new Element<T>(m_Index, m_List.m_Matrix.m_Values[number]);
                        return true;
                    }
                    if (m_IsColumn)
                        m_Index = m_List.m_Matrix.m_RowsCount;
                    else
                        m_Index = m_List.m_Matrix.m_ColumnsCount;
                    m_Current = default(Element<T>);
                    return false;
                }
                /// <summary>Sets the enumerator to its initial position, which is before the first element in the collection.</summary>
                /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
                void IEnumerator.Reset()
                {
                    if (m_Version != m_List.m_Version)
                        throw new InvalidOperationException();
                    m_Index = -1;
                    m_Current = default(Element<T>);
                }
                public void Dispose()
                {
                }
            }
            #endregion Classes, structures, enumerators
            #region Constructors
            internal FullMatrixVector()
                : base()
            {
            }
            public FullMatrixVector(int number, FullMatrix<T> matrix, bool isColumn)
                : base()
            {
                m_Number = number;
                m_Count = matrix.ColumnsCount;
                m_Matrix = matrix;
                m_IsColumn = isColumn;
            }
            #endregion Constructors
            #region Variables
            /// <summary>
            /// Data value
            /// </summary>
            internal FullMatrix<T> m_Matrix;
            /// <summary>
            /// Number of elements of the vector.
            /// </summary>
            internal int m_Count;
            internal int m_Number;
            internal int m_Version;
            internal bool m_IsColumn;
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
                    if (m_IsColumn)
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
                return new Enumerator(this);
            }
            /// <summary>
            /// TODO!!
            /// </summary>
            /// <param name="array"></param>
            /// <param name="index"></param>
            /// <param name="arrayIndex"></param>
            /// <param name="length"></param>
            public override void CopyTo(T[] array, int index = 0, int arrayIndex = 0, int length = int.MaxValue)
            {
                ThrowHelper<T>.ThrowIfNull(array, "array");
                if (length == int.MaxValue)
                    length = Count - index;
                ThrowHelper<T>.ThrowIfOutOfRange("this", index, m_Count, length);
                ThrowHelper<T>.ThrowIfOutOfRange("array", arrayIndex, array.Length, length);
                for (int i = arrayIndex; i < length + arrayIndex; ++i)
                    array[i] = default(T);
                if (m_IsColumn)
                {
                    int columnsEnd = index + length;
                    int arrayCorrection = -index + arrayIndex;
                    T[] values = m_Matrix.m_Values;
                    for (int i = index, j = arrayIndex; i < index + length; ++i, ++j)
                        array[j] = values[i * m_Matrix.m_ColumnsCount + m_Number];
                }
                else
                    Array.Copy(m_Matrix.m_Values, m_Number * m_Matrix.m_ColumnsCount + index, array, arrayIndex, length);
            }
            public override void CopyTo(VectorT<T> vector, int index = 0, int arrayIndex = 0, int length = int.MaxValue)
            {
                ThrowHelper<T>.ThrowIfNull(vector, "vector");
                FullVector<T> fullVector = vector as FullVector<T>;
                if (fullVector == null)
                    throw new NotSupportedException(vector.GetType().ToString());
                CopyTo(fullVector.m_Values, index, arrayIndex, length);
            }        

            #endregion Events, overrides
            #endregion Methods
        }
        #endregion Classes, structures, enumerators
        #region Constructors
        internal FullMatrix()
        {
        }
        public FullMatrix(int m, int n, T[] values = null, MatrixSolver<T> solver = null)
        {
            int size = m * n;
            m_RowsCount = m;
            m_ColumnsCount = n;
            m_Values = new T[size];
            if (values != null)
            {
                if (values.Length != size)
                    throw new IndexOutOfRangeException("values");
                Array.Copy(values, m_Values, size);
            }
        }
        #endregion Constructors
        #region Variables
        /// <summary>
        /// Data value
        /// </summary>
        internal T[] m_Values;
        /// <summary>
        /// Number of rows of the matrix.
        /// </summary>
        internal int m_RowsCount;
        /// <summary>
        /// Number of columns of the matrix.
        /// </summary>
        internal int m_ColumnsCount; 
        #endregion Variables
        #region Fields
        /// <summary>
        /// Number of rows of the matrix.
        /// </summary>
        public override int RowsCount 
        { 
            get
            {
                return m_RowsCount;
            }
        }
        /// <summary>
        /// Number of columns of the matrix.
        /// </summary>
        public override int ColumnsCount 
        { 
            get
            {
                return m_ColumnsCount;
            }
        }
        public override T this[int m, int n]
        {
            get
            {
                if (m < 0)
                    throw new ArgumentOutOfRangeException();
                if (m >= m_RowsCount)
                    throw new ArgumentOutOfRangeException();
                if (n < 0)
                    throw new ArgumentOutOfRangeException();
                if (n >= m_ColumnsCount)
                    throw new ArgumentOutOfRangeException();
                return m_Values[m * m_ColumnsCount + n];
            }
            set
            {
                if (m < 0)
                    throw new ArgumentOutOfRangeException();
                if (m >= m_RowsCount)
                    throw new ArgumentOutOfRangeException();
                if (n < 0)
                    throw new ArgumentOutOfRangeException();
                if (n >= m_ColumnsCount)
                    throw new ArgumentOutOfRangeException();
                m_Values[m * m_ColumnsCount + n] = value;
            }
        }
        public override T this[int i]
        {
            get
            {
                return m_Values[i];
            }
            set
            {
                m_Values[i] = value;
            }
        }
        #endregion Fields
        #region Methods
        #region Public methods
        public void Clear()
        {

        }
        public T Get(int i, int j)
        {
            if (i < 0)
                throw new ArgumentOutOfRangeException();
            if (i >= m_RowsCount)
                throw new ArgumentOutOfRangeException();
            if (j < 0)
                throw new ArgumentOutOfRangeException();
            if (j >= m_ColumnsCount)
                throw new ArgumentOutOfRangeException();
            return m_Values[i * m_ColumnsCount + j];
        }
        public T Get(int i)
        {
            return m_Values[i];
        }
        public void Set(int i, int j, T value)
        {
            if (i < 0)
                throw new ArgumentOutOfRangeException();
            if (i >= m_RowsCount)
                throw new ArgumentOutOfRangeException();
            if (j < 0)
                throw new ArgumentOutOfRangeException();
            if (j >= m_ColumnsCount)
                throw new ArgumentOutOfRangeException();
            m_Values[i * m_ColumnsCount + j] = value;
        }
        public void Set(int i, T value)
        {
            m_Values[i] = value;
        }
        public FullMatrix<T> GetCopy()
        {
            return null;
        }
        #endregion Public methods
        #region Internal methods
        #endregion Internal methods
        #region Private methods
        #endregion Private methods
        #region Events, overrides
        public override VectorT<T> Row(int i)
        {
            return new FullMatrixVector<T>(i, this, false);
        }
        public override VectorT<T> Column(int i)
        {
            return new FullMatrixVector<T>(i, this, true);
        }
        /// <summary>
        /// Add new row to matrix, increase rows count
        /// </summary>
        /// <param name="rowIndex">Index of inserting row</param>
        /// <param name="values">Key-valued collection of row elements</param>
        public override void AddRow(SortedList<int, T> values = null, int rowIndex = int.MaxValue)
        {
            if (rowIndex == int.MaxValue)
                rowIndex = m_RowsCount;
            if (rowIndex < 0 || rowIndex > m_RowsCount)
                throw new IndexOutOfRangeException("rowIndex");

            T[] newValues = new T[m_Values.Length + m_ColumnsCount];
            int index = rowIndex * m_ColumnsCount;
            if (values != null)
            {
                foreach (var item in values)
                {
                    if (item.Key >= m_ColumnsCount || item.Key < 0)
                        throw new ArgumentOutOfRangeException("values");
                    newValues[index + item.Key] = item.Value;
                }
            }
            Array.Copy(m_Values, newValues, index);
            Array.Copy(m_Values, index, newValues, index + m_ColumnsCount, m_Values.Length - index);
            m_Version++;
            m_RowsCount++;
            m_Values = newValues;
        }
        /// <summary>
        /// Add new column to matrix, increase columns count
        /// </summary>
        /// <param name="columnIndex">Index of inserting column</param>
        /// <param name="values">Key-valued collection of column elements</param>
        public override void AddColumn(SortedList<int, T> values = null, int columnIndex = int.MaxValue)
        {
            if (columnIndex == int.MaxValue)
                columnIndex = m_ColumnsCount;
            if (columnIndex < 0 || columnIndex > m_ColumnsCount)
                throw new IndexOutOfRangeException("columnIndex");

            T[] newValues = new T[m_Values.Length + m_RowsCount];
            int newColumnsCount = m_ColumnsCount + 1;
            if (values != null)
            {
                foreach (var item in values)
                {
                    if (item.Key >= m_RowsCount || item.Key < 0)
                        throw new ArgumentOutOfRangeException("values");
                    newValues[newColumnsCount * item.Key + columnIndex] = item.Value;
                }
            }
            for (int i = 0; i < m_RowsCount; ++i)
            {
                Array.Copy(m_Values, i * m_ColumnsCount, newValues, i * newColumnsCount, columnIndex);
                Array.Copy(m_Values, i * m_ColumnsCount + columnIndex, newValues, i * newColumnsCount + columnIndex + 1, m_ColumnsCount - columnIndex);
            }
            m_Version++;
            m_ColumnsCount++;
            m_Values = newValues;
        }        
        /// <summary>
        /// Remove row from matrix, decrease rows count
        /// </summary>
        /// <param name="rowIndex">Index of removind row</param>
        public override void RemoveRow(int rowIndex = int.MaxValue)
        {
            if(rowIndex == int.MaxValue)
                rowIndex = m_RowsCount - 1;
            if (rowIndex < 0 || rowIndex >= m_RowsCount)
                throw new IndexOutOfRangeException("rowIndex");
            if(m_RowsCount == 0)
                throw new IndexOutOfRangeException("RowsCount");
            
            T[] newValues = new T[m_Values.Length - m_ColumnsCount];
            int index = rowIndex * m_ColumnsCount;
            Array.Copy(m_Values, newValues, index);
            Array.Copy(m_Values, index + m_ColumnsCount, newValues, index, newValues.Length - index);
            m_Version++;
            m_RowsCount--;
            m_Values = newValues;
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
            
            T[] newValues = new T[m_Values.Length - m_RowsCount];
            int newColumnsCount = m_ColumnsCount - 1;
            for (int i = 0; i < m_RowsCount; ++i)
            {
                Array.Copy(m_Values, i * m_ColumnsCount, newValues, i * newColumnsCount, columnIndex);
                Array.Copy(m_Values, i * m_ColumnsCount + columnIndex + 1, newValues, i * newColumnsCount + columnIndex, newColumnsCount - columnIndex);
            }
            m_Version++;
            m_ColumnsCount--;            
            m_Values = newValues;
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

            int index = rowIndex * m_ColumnsCount;
            if (values != null)
            {
                foreach (var item in values)
                    if (item.Key >= m_ColumnsCount || item.Key < 0)
                        throw new ArgumentOutOfRangeException("values");
            }
            int endIndex = index + m_ColumnsCount;
            for(;index < endIndex; ++index)
                m_Values[index] = default(T);
            if (values != null)
            {
                foreach (var item in values)
                    m_Values[index + item.Key] = item.Value;
            }
        }
        /// <summary>
        /// Change column in matrix
        /// </summary>
        /// <param name="columnIndex">Index of changing column</param>
        /// <param name="values">Key-valued collection of column elements</param>
        public override void SetColumn(SortedList<int, T> values = null, int columnIndex = 0)
        {
            if (columnIndex < 0 || columnIndex >= m_ColumnsCount)
                throw new IndexOutOfRangeException("columnIndex");

            if (values != null)
            {
                foreach (var item in values)
                    if (item.Key >= m_RowsCount || item.Key < 0)
                        throw new ArgumentOutOfRangeException("values");
            }
            for (int i = columnIndex; i < m_Values.Length; i += m_ColumnsCount)
                m_Values[i] = default(T);
            if (values != null)
                foreach (var item in values)
                    m_Values[m_ColumnsCount * item.Key + columnIndex] = item.Value;
        }
        
        public override IEnumerator<VectorT<T>> GetEnumerator()
        {
            return new FullEnumerator(this);
        }
        #region Equal
        public override bool Equals(object obj)
        {
            return this == (obj as FullMatrix<T>);
        }

        public static bool operator ==(FullMatrix<T> a, FullMatrix<T> b)
        {
            object a1 = (object)a;
            object b1 = (object)b;
            return a1 == b1 || (a1 != null && b1 != null && EqualsHelper(a, b));
        }
        public static bool operator !=(FullMatrix<T> a, FullMatrix<T> b)
        {
            return !(a == b);
        }
        private static bool EqualsHelper(FullMatrix<T> a, FullMatrix<T> b)
        {
            if (a.m_RowsCount != b.m_RowsCount || a.m_ColumnsCount != b.m_ColumnsCount)
                return false;
            for (int i = 0; i < a.m_Values.Length; ++i)
                if (!a.m_Values[i].Equals(b.m_Values[i]))
                    return false;
            return true;
        }
        #endregion Equal
        #region Explicit
        #endregion Explicit
        public override object Clone()
        {
            FullMatrix<T> returnValue = new FullMatrix<T>(RowsCount, ColumnsCount);
            Array.Copy(m_Values, returnValue.m_Values, m_Values.Length);
            return returnValue;
        }
        #endregion Events, overrides
        #endregion Methods
    }
}
#endregion Working namespace