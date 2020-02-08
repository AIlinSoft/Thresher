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
using System.Runtime.InteropServices;
#endregion Using namespaces
#region Working namespace
namespace AIlins.Thresher
{
    public class FullVector<T> : Vector<T>
    {
        #region Classes, structures, enumerators
        public struct Enumerator : IEnumerator<Element<T>>, IEnumerator
        {
            private FullVector<T> m_Vector;
            private int m_Index;
            private int m_Version;
            private Element<T> m_Current;
            /// <summary>Gets the element at the current position of the enumerator.</summary>
            /// <returns>The element in the <see cref="T:System.Collections.Generic.List`1" /> at the current position of the enumerator.</returns>
            public Element<T> Current
            {
                get
                {
                    if (m_Index == -1 || m_Index >= m_Vector.m_Count)
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
                    if (m_Index == -1 || m_Index >= m_Vector.m_Count)
                        throw new InvalidOperationException();
                    return m_Current;
                }
            }
            internal Enumerator(FullVector<T> vector)
            {
                m_Vector = vector;
                m_Index = -1;
                m_Version = vector.m_Version;
                m_Current = default(Element<T>);
            }
            /// <summary>Advances the enumerator to the next element of the <see cref="T:System.Collections.Generic.List`1" />.</summary>
            /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.</returns>
            /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
            public bool MoveNext()
            {
                if (m_Version != m_Vector.m_Version)
                    throw new InvalidOperationException();
                FullVector<T> vector = m_Vector;
                m_Index++;
                for (; m_Index < vector.m_Count; ++m_Index)
                {
                    T value = vector.m_Values[m_Index];
                    if (object.Equals(value, default(T)))
                        continue;
                    m_Current = new Element<T>(m_Index, value);
                    return true;
                }
                m_Index = m_Vector.m_Count;
                m_Current = default(Element<T>);
                return false;
            }
            /// <summary>Sets the enumerator to its initial position, which is before the first element in the collection.</summary>
            /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
            void IEnumerator.Reset()
            {
                if (m_Version != m_Vector.m_Version)
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
        internal FullVector()
            : base()
        {
        
        }
        public FullVector(int count)
            : this(count, null)
        {}
        public FullVector(int count, T[] values)
            : base()
        {
            m_Count = count;
            m_Values = new T[m_Count];
            if (values != null)
            {
                if (values.Length != count)
                    throw new IndexOutOfRangeException("values");
                Array.Copy(values, m_Values, count);
            }
        }
        public FullVector(Vector<T> value)
        {
            m_Count = value.Count;
            m_Values = new T[m_Count];
            value.CopyTo(m_Values, 0);
        }
        #endregion Constructors
        #region Variables
        /// <summary>
        /// Data value
        /// </summary>
        internal T[] m_Values;
        /// <summary>
        /// Number of elements of the vector.
        /// </summary>
        internal int m_Count;
        internal int m_Version;
        protected GCHandle m_Fixed;
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
        unsafe public void* Fixed() 
        {
            if(!m_Fixed.IsAllocated)
                m_Fixed = GCHandle.Alloc(m_Values, GCHandleType.Pinned);
            return (void*)Marshal.UnsafeAddrOfPinnedArrayElement(m_Values, 0);
        }
        unsafe public void Free()
        {
            if (m_Fixed.IsAllocated)
                m_Fixed.Free();
        }
        
        public void Clear()
        {
            var solver = SolversResolver.GetMatrixSolver<T>();
            solver.ArraySolver.Set(m_Values);
        }
        #endregion Public methods
        #region Internal methods
        #endregion Internal methods
        #region Private methods
        private static bool EqualsHelper(FullVector<T> a, Vector<T> b)
        {
            if (a.m_Count != b.Count)
                return false;
            var fullMatrix = b as FullVector<T>;
            if (((object)fullMatrix) != null)
            {
                for (int i = 0; i < a.m_Values.Length; ++i)
                    if (!a.m_Values[i].Equals(fullMatrix.m_Values[i]))
                        return false;
            }
            else
            {
                T[] val = new T[a.m_Count];
                b.CopyTo(val);
                for (int i = 0; i < val.Length; ++i)
                    if (!a.m_Values[i].Equals(val[i]))
                        return false;
            }
            return true;
        }
        #endregion Private methods
        #region Events, overrides
        public override bool Equals(object obj)
        {
            return this == (obj as Vector<T>);
        }
        public static bool operator ==(FullVector<T> a, Vector<T> b)
        {
            object a1 = (object)a;
            object b1 = (object)b;
            return a1 == b1 || (a1 != null && b1 != null && EqualsHelper(a, b));
        }
        public static bool operator !=(FullVector<T> a, Vector<T> b)
        {
            return !(a == b);
        }
        public override IEnumerator<Element<T>> GetEnumerator()
        {
            return new Enumerator(this);
        }
        public override void CopyTo(T[] array, int index = 0, int arrayIndex = 0, int length = int.MaxValue)
        {
            ThrowHelper<T>.ThrowIfNull(array, "array");
            if (length == int.MaxValue)
                length = array.Length - arrayIndex;
            ThrowHelper<T>.ThrowIfOutOfRange("index", index, Count, length);
            ThrowHelper<T>.ThrowIfOutOfRange("arrayIndex", arrayIndex, array.Length, length);
            Array.Copy(m_Values, index, array, arrayIndex, length);
        }
        public override void CopyTo(Vector<T> vector, int index = 0, int arrayIndex = 0, int length = int.MaxValue)
        {
            FullVector<T> fullVector = vector as FullVector<T>;
            if (fullVector == null)
                throw new NotSupportedException(vector.GetType().ToString());
            CopyTo(fullVector.m_Values, index, arrayIndex, length);
        }        
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion Events, overrides
        #endregion Methods
    }
}
#endregion Working namespace