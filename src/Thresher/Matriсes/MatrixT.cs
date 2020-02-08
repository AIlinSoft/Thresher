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
    /// Matrices database
    /// </summary>
    public abstract class Matrix<T> : IEnumerable<Vector<T>>, ICloneable
    {
        #region Classes, structures, enums
        #endregion Classes, structures, enums
        #region Constructors
        #endregion Constructors
        #region Variables
        internal int m_Version;
        #endregion Variables
        #region Fields
        public SolvingContext Context { get; set; }
        /// <summary>
        /// Count of rows in matrix
        /// </summary>
        public abstract int RowsCount { get; }
        /// <summary>
        /// Count of columns in matrix
        /// </summary>
        public abstract int ColumnsCount { get; }
        /// <summary>
        /// Get or set element of matrix
        /// </summary>
        /// <param name="i">Row index of element</param>
        /// <param name="j">Column index of element</param>
        /// <returns>Element of matrix</returns>
        public abstract T this[int i, int j] { get; set; }
        /// <summary>
        /// Get or set diagonal element
        /// </summary>
        /// <param name="i">Row and column index of diagonal element</param>
        /// <returns>i-th diagonal element</returns>
        public abstract T this[int i] { get; set; }
        #endregion Fields
        #region Methods
        #region Public methods
        public abstract Vector<T> Row(int i);
        public abstract Vector<T> Column(int i);
        /// <summary>
        /// Add new row to matrix, increase rows count
        /// </summary>
        /// <param name="rowIndex">Index of inserting row</param>
        /// <param name="values">Key-valued collection of row elements</param>
        public abstract void AddRow(SortedList<int, T> values = null, int rowIndex = int.MaxValue);
        /// <summary>
        /// Add new row to matrix, increase rows count
        /// </summary>
        /// <param name="rowIndex">Index of inserting row</param>
        /// <param name="values">Vector of row elements</param>
        public virtual void AddRow(Vector<T> values, int rowIndex = int.MaxValue)
        {
            if (values.Count != ColumnsCount)
                throw new ArgumentOutOfRangeException("values");
            if (((object)values) == null)
                AddRow((SortedList<int, T>)null, rowIndex);
            else
            {
                SortedList<int, T> list = new SortedList<int, T>(values.Count);
                foreach (Element<T> item in values)
                    list[item.Index] = item.Value;
                AddRow(list, rowIndex);
            }
        }
        /// <summary>
        /// Add new column to matrix, increase columns count
        /// </summary>
        /// <param name="columnIndex">Index of inserting column</param>
        /// <param name="values">Key-valued collection of column elements</param>
        public abstract void AddColumn(SortedList<int, T> values = null, int columnIndex = int.MaxValue);
        /// <summary>
        /// Add new column to matrix, increase columns count
        /// </summary>
        /// <param name="columnIndex">Index of inserting column</param>
        /// <param name="values">Vector of column elements</param>
        public virtual void AddColumn(Vector<T> values, int columnIndex = int.MaxValue)
        {
            if (values.Count != RowsCount)
                throw new ArgumentOutOfRangeException("values");
            if (((object)values) == null)
                AddColumn((SortedList<int, T>)null, columnIndex);
            else
            {
                SortedList<int, T> list = new SortedList<int, T>(values.Count);
                foreach (Element<T> item in values)
                    list[item.Index] = item.Value;
                AddColumn(list, columnIndex);
            }
        }
        /// <summary>
        /// Remove row from matrix, decrease rows count
        /// </summary>
        /// <param name="rowIndex">Index of removind row</param>
        public abstract void RemoveRow(int rowIndex = int.MaxValue);
        /// <summary>
        /// Remove new column from matrix, decrease columns count
        /// </summary>
        /// <param name="columnIndex">Index of removind column</param>
        public abstract void RemoveColumn(int columnIndex = int.MaxValue);
        /// <summary>
        /// Change row in matrix
        /// </summary>
        /// <param name="rowIndex">Index of changing row</param>
        /// <param name="values">Key-valued collection of row elements</param>
        public virtual void SetRow(SortedList<int, T> values = null, int rowIndex = 0)
        {
            RemoveRow(rowIndex);
            AddRow(values, rowIndex);
        }
        /// <summary>
        /// Change row in matrix
        /// </summary>
        /// <param name="rowIndex">Index of changing row</param>
        /// <param name="values">Vector of row elements</param>
        public virtual void SetRow(Vector<T> values, int rowIndex = 0)
        {
            if (values.Count != ColumnsCount)
                throw new ArgumentOutOfRangeException("values");
            if (((object)values) == null)
                SetRow((SortedList<int, T>)null, rowIndex);
            else
            {
                SortedList<int, T> list = new SortedList<int, T>(values.Count);
                foreach (Element<T> item in values)
                    list[item.Index] = item.Value;
                SetRow(list, rowIndex);
            }
        }
        /// <summary>
        /// Change column in matrix
        /// </summary>
        /// <param name="columnIndex">Index of changing column</param>
        /// <param name="values">Key-valued collection of column elements</param>
        public virtual void SetColumn(SortedList<int, T> values = null, int columnIndex = 0)
        {
            RemoveColumn(columnIndex);
            AddColumn(values, columnIndex);
        }
        /// <summary>
        /// Change column in matrix
        /// </summary>
        /// <param name="columnIndex">Index of changing column</param>
        /// <param name="values">Vector of column elements</param>
        public virtual void SetColumn(Vector<T> values, int columnIndex = 0)
        {
            if (values.Count != RowsCount)
                throw new ArgumentOutOfRangeException("values");
            if (((object)values) == null)
                SetColumn((SortedList<int, T>)null, columnIndex);
            else
            {
                SortedList<int, T> list = new SortedList<int, T>(values.Count);
                foreach (Element<T> item in values)
                    list[item.Index] = item.Value;
                SetColumn(list, columnIndex);
            }
        }
        #endregion Public methods
        #region Internal methods
        #endregion Internal methods
        #region Private methods
        private static bool EqualsHelper(Matrix<T> a, Matrix<T> b)
        {
            if (a.RowsCount != b.RowsCount || a.ColumnsCount != b.ColumnsCount)
                return false;
            for (int i = 0; i < a.RowsCount; ++i)
                if (a.Row(i) != b.Row(i))
                    return false;
            return true;
        }
        #endregion Private methods
        #region  Events, overrides
        public abstract IEnumerator<Vector<T>> GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public override bool Equals(object obj)
        {
            return this == (obj as Matrix<T>);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(Matrix<T> a, Matrix<T> b)
        {
            object a1 = (object)a;
            object b1 = (object)b;
            return a1 == b1 || (a1 != null && b1 != null && EqualsHelper(a, b));
        }
        public static bool operator !=(Matrix<T> a, Matrix<T> b)
        {
            return !(a == b);
        }
        public static Matrix<T> operator +(Matrix<T> value1, Matrix<T> value2)
        {
            Matrix<T> returnValue = null;
            var solver = SolversResolver.GetMatrixSolver<T>();
            solver.Addition(value1, value2, ref returnValue);
            return returnValue;
        }
        public static Matrix<T> operator -(Matrix<T> value1, Matrix<T> value2)
        {
            Matrix<T> returnValue = null;
            var solver = SolversResolver.GetMatrixSolver<T>();
            solver.Substraction(value1, value2, ref returnValue);
            return returnValue;
        }
        public static Matrix<T> operator -(Matrix<T> value)
        {
            Matrix<T> returnValue = null;
            var solver = SolversResolver.GetMatrixSolver<T>();
            solver.Negation(value, ref returnValue);
            return returnValue;
        }
        public static Matrix<T> operator *(Matrix<T> value1, Matrix<T> value2)
        {
            Matrix<T> returnValue = null;
            var solver = SolversResolver.GetMatrixSolver<T>();
            solver.Multiply(value1, value2, ref returnValue);
            return returnValue;
        }
        public static Matrix<T> operator *(Matrix<T> value1, T value2)
        {
            Matrix<T> returnValue = null;
            var solver = SolversResolver.GetMatrixSolver<T>();
            solver.Multiply(value1, value2, ref returnValue);
            return returnValue;
        }
        public static Vector<T> operator /(Vector<T> value1, Matrix<T> value2)
        {
            FullVector<T> returnValue = null;
            var solver = SolversResolver.GetMatrixSolver<T>();
            solver.Division(value1, value2, ref returnValue);
            return returnValue;
        }
        public override string ToString()
        {
            StringBuilder returnValue = new StringBuilder(RowsCount * 5);
            int i = 0;
            foreach (Vector<T> item in this)
            {
                foreach(Element<T> item1 in item)
                    if(!item1.Value.Equals(default(T)))
                        returnValue.AppendLine(string.Format("{0} {1} {2}", i, item1.Index, item1.Value));
                i++;
            }
            return returnValue.ToString();
        }
        public abstract object Clone();
        #endregion Events, overrides
        #endregion Methods
    }
}
#endregion Working namespace
