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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion Using namespaces
#region Working namespace
namespace AIlins.Thresher
{
    public abstract class Vector<T> : IEnumerable<Element<T>>
    {
        #region Classes, structures, enumerators
        #endregion Classes, structures, enumerators
        #region Constructors
        public Vector()
        {
        }
        ~Vector()
        {

        }
        #endregion Constructors
        #region Variables
        #endregion Variables
        #region Fields
        public abstract int Count { get; }
        public abstract bool IsReadOnly { get; }
        public abstract T this[int index] { get; set; }
        #endregion Fields
        #region Methods
        #region Public methods
        public abstract void CopyTo(T[] array, int index = 0, int arrayIndex = 0, int length = int.MaxValue);
        public abstract void CopyTo(Vector<T> vector, int index = 0, int arrayIndex = 0, int length = int.MaxValue);
        #endregion Public methods
        #region Internal methods
        #endregion Internal methods
        #region Private methods
        #endregion Private methods
        #region Events, overrides
        public abstract IEnumerator<Element<T>> GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public override bool Equals(object obj)
        {
            return this == (obj as Vector<T>);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator ==(Vector<T> a, Vector<T> b)
        {
            object a1 = (object)a;
            object b1 = (object)b;
            return a1 == b1 || (a1 != null && b1 != null && EqualsHelper(a, b));
        }
        public static bool operator !=(Vector<T> a, Vector<T> b)
        {
            return !(a == b);
        }
        private static bool EqualsHelper(Vector<T> a, Vector<T> b)
        {
            if (a.Count != b.Count)
                return false;
            IEnumerator<Element<T>> ae = a.GetEnumerator();
            IEnumerator<Element<T>> be = b.GetEnumerator();
            for (; ; )
            {
                bool ares = ae.MoveNext();
                bool bres = be.MoveNext();
                if (ares != bres)
                    return false;
                if (!ares)
                    return true;
                if (ae.Current.Index != be.Current.Index)
                    return false;
                if (!object.Equals(ae.Current.Value, be.Current.Value))
                    return false;
            }
        }
        public static Vector<T> operator +(Vector<T> value1, Vector<T> value2)
        {
            FullVector<T> returnValue = null;
            var solver = SolversResolver.GetMatrixSolver<T>();
            solver.Addition(value1, value2, ref returnValue);
            return returnValue;
        }
        public static Vector<T> operator +(Vector<T> value1, T value2)
        {
            FullVector<T> returnValue = null;
            var solver = SolversResolver.GetMatrixSolver<T>();
            solver.Addition(value1, value2, ref returnValue);
            return returnValue;
        }
        public static Vector<T> operator -(Vector<T> value1, Vector<T> value2)
        {
            FullVector<T> returnValue = null;
            var solver = SolversResolver.GetMatrixSolver<T>();
            solver.Substraction(value1, value2, ref returnValue);
            return returnValue;
        }
        public static Vector<T> operator -(Vector<T> value)
        {
            FullVector<T> returnValue = null;
            var solver = SolversResolver.GetMatrixSolver<T>();
            solver.Negation(value, ref returnValue);
            return returnValue;
        }
        public static Vector<T> operator *(Vector<T> value1, T value2)
        {
            FullVector<T> returnValue = null;
            var solver = SolversResolver.GetMatrixSolver<T>();
            solver.Multiply(value1, value2, ref returnValue);
            return returnValue;
        }
        public static Vector<T> operator *(Vector<T> value1, Vector<T> value2)
        {
            FullVector<T> returnValue = null;
            var solver = SolversResolver.GetMatrixSolver<T>();
            solver.Multiply(value1, value2, ref returnValue);
            return returnValue;
        }
        public static Vector<T> operator /(Vector<T> value1, Vector<T> value2)
        {
            FullVector<T> returnValue = null;
            var solver = SolversResolver.GetMatrixSolver<T>();
            solver.Division(value1, value2, ref returnValue);
            return returnValue;
        }
        public static Vector<T> operator /(Vector<T> value1, T value2)
        {
            FullVector<T> returnValue = null;
            var gSolver = SolversResolver.GetGenericSolver<T>();
            T value2Inverted = gSolver.Inversion(value2);
            var solver = SolversResolver.GetMatrixSolver<T>();
            solver.Multiply(value1, value2Inverted, ref returnValue);
            return returnValue;
        }
        public override string ToString()
        {
            StringBuilder returnValue = new StringBuilder(Count * 10);
            foreach (Element<T> item in this)
            {
                // returnValue.AppendLine(string.Format("{0} {1}", item.Index, item.Value));
                returnValue.Append("(");
                returnValue.Append(item.Index);
                returnValue.Append(";");
                returnValue.Append(item.Value);
                returnValue.Append("),");
            }
            return returnValue.ToString();
        }
        #endregion Events, overrides
        #endregion Methods
    }
}
#endregion Working namespace