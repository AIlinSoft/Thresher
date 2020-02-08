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
using System.Runtime.InteropServices;
#endregion Using namespaces
#region Working namespace
namespace AIlins.Thresher
{
    /// <summary>
    /// The elliptic curve y^2 + x*y = x^3 + a4*x^2 + a6
    /// </summary>
    /// <remarks>
    /// Lopez-Dahab projective coordinats
    /// </remarks>
    [Serializable, StructLayout(LayoutKind.Sequential), ComVisible(true)]
    public class EllipticCurvePointC : IEllipticCurvePoint
    {
        #region Classes, structures, enums
        #endregion Classes, structures, enums
        #region Constructors
        /// <summary>
        /// Hide the default constructor
        /// </summary>
        private EllipticCurvePointC()
        {
        }
        public EllipticCurvePointC(IntBig x, IntBig y, EllipticCurvePointC point)
        {
            m_x = x;
            m_y = y;
            m_Modulo = point.m_Modulo;
            m_a4 = point.m_a4;
            m_a6 = point.m_a6;
            m_X = new IntBig(x.m_Value) % m_Modulo;
            m_Y = new IntBig(y.m_Value) % m_Modulo;
            m_Z = new IntBig(1);
            if (!IsValid(m_X, m_Y, m_Z, m_a4, m_a6, m_Modulo))
                throw new Exception("Point is not from elliptic curve");
        }
        public EllipticCurvePointC(IntBig x, IntBig y, IntBig a4, IntBig a6, IntBig modulo)
        {
            m_x = x;
            m_y = y;
            m_Modulo = modulo;
            m_a4 = a4;
            m_a6 = a6;
            m_X = new IntBig(x.m_Value) % m_Modulo;
            m_Y = new IntBig(y.m_Value) % m_Modulo;
            m_Z = new IntBig(1);
            if (!IsValid(m_X, m_Y, m_Z, m_a4, m_a6, m_Modulo))
                throw new Exception("Point is not from elliptic curve");
        }
        internal EllipticCurvePointC(uint[] x, uint[] y, uint[] z, EllipticCurvePointC point)
        {
            m_Modulo = point.m_Modulo;
            m_a4 = point.m_a4;
            m_a6 = point.m_a6;
            m_X = new IntBig(x) % m_Modulo;
            m_Y = new IntBig(y) % m_Modulo;
            m_Z = new IntBig(z) % m_Modulo;
            if (!IsValid(m_X, m_Y, m_Z, m_a4, m_a6, m_Modulo))
                throw new Exception("Point is not from elliptic curve");
            
        }
        internal EllipticCurvePointC(IntBig x, IntBig y, IntBig z, EllipticCurvePointC point)
        {
            m_Modulo = point.m_Modulo;
            m_a4 = point.m_a4;
            m_a6 = point.m_a6;
            m_X = x % m_Modulo;
            m_Y = y % m_Modulo;
            m_Z = z % m_Modulo;
            if (!IsValid(m_X, m_Y, m_Z, m_a4, m_a6, m_Modulo))
                throw new Exception("Point is not from elliptic curve");
        }
        internal EllipticCurvePointC(uint x, uint y, uint z, EllipticCurvePointC point)
        {
            m_Modulo = point.m_Modulo;
            m_a4 = point.m_a4;
            m_a6 = point.m_a6;
            m_X = new IntBig(x);
            m_Y = new IntBig(y);
            m_Z = new IntBig(z);
            if (!IsValid(m_X, m_Y, m_Z, m_a4, m_a6, m_Modulo))
                throw new Exception("Point is not from elliptic curve");
        }
        #endregion Constructors
        #region Variables
        /// <summary>
        /// Афинные и Якобиановы координаты точки
        /// </summary>
        internal IntBig m_x, m_y, m_X, m_Y, m_Z;
        /// <summary>
        /// Параметры вычислителя
        /// </summary>
        private IntBig m_a4, m_a6, m_Modulo;
        #endregion Variables
        #region Fields
        public bool Infinity
        {
            get
            {
                return m_Y.Zero;
            }
        }
        /// <summary>
        /// Значение по оси абсцисс в афинных координатах
        /// </summary>
        public IntBig x
        {
            get
            {
                if (m_x == null)
                {
                    uint[] result = new uint[m_Modulo.m_Value.Length];
                    ModuloOperations.Divide(m_X.m_Value, m_Z.m_Value, m_Modulo.m_Value, result);
                    m_x = new IntBig(result);
                }
                return m_x;
            }
        }
        /// <summary>
        /// Значение по оси ординат в афинных координатах
        /// </summary>
        public IntBig y
        {
            get
            {
                if (m_y == null)
                {
                    uint[] temp = new uint[m_Modulo.m_Value.Length];
                    uint[] result = new uint[m_Modulo.m_Value.Length];
                    uint[] tempMultiply = new uint[m_Modulo.m_Value.Length * 2];
                    ModuloOperations.Multiply(m_Z.m_Value, m_Z.m_Value, m_Modulo.m_Value, temp, tempMultiply);

                    ModuloOperations.Divide(m_Y.m_Value, temp, m_Modulo.m_Value, result);
                    m_y = new IntBig(result);
                }
                return m_y;
            }
        }
        #endregion Fields
        #region Methods
        #region Public methods
        public static bool IsValid(IntBig x, IntBig y, IntBig z, IntBig a4, IntBig a6, IntBig modulo)
        {
            MIntBig my = new MIntBig(y, modulo);
            MIntBig mx = new MIntBig(x, modulo);
            MIntBig mz = new MIntBig(z, modulo);
            MIntBig ma4 = new MIntBig(a4, modulo);
            MIntBig ma6 = new MIntBig(a6, modulo);

            MIntBig mz2 = mz * mz;
            MIntBig mz4 = mz2 * mz2;
            MIntBig mz6 = mz4 * mz2;

            MIntBig my2 = my * my;
            MIntBig mx2 = mx * mx * mx + ma4 * mx * mz4 + ma6 * mz6;
            return my2 == mx2;
        }
        public IEllipticCurvePoint GetInfinity()
        {
            return new EllipticCurvePointC(1, 0, 0, this);
        }
        /// <summary>
        /// Doubling the point in elliptic curve
        /// </summary>
        /// <returns></returns>
        public IEllipticCurvePoint Doubling()
        {
            if (Infinity)
                return GetInfinity();
            // Coordinates
            uint[] a = m_a4.m_Value;
            uint[] b = m_a6.m_Value;
            uint[] x = m_X.m_Value;
            uint[] y = m_Y.m_Value;
            uint[] z = m_Z.m_Value;
            uint[] modulo = m_Modulo.m_Value;
            int maxModuloBitIndex = BigHelper.MaxNonZeroBitIndex(modulo);
            int length = modulo.Length;
            // Get the cache
            uint[] cache = new uint[length * 2];
            uint[] s = new uint[length];
            uint[] m = new uint[length];

            uint[] x1 = new uint[length];
            uint[] y1 = new uint[length];
            uint[] z1 = new uint[length];


            // X^2
            ModuloOperations.Multiply(x, x, modulo, x1, cache);
            // Z^2
            ModuloOperations.Multiply(z, z, modulo, y1, cache);
            // Z1 = Z^2*X^2
            ModuloOperations.Multiply(x1, y1, modulo, z1, cache);

            // X^4
            ModuloOperations.Multiply(x1, x1, modulo, x1, cache);
            // Z^4
            ModuloOperations.Multiply(y1, y1, modulo, y1, cache);
            // b*Z^4
            ModuloOperations.Multiply(y1, y1, modulo, y1, cache);
            // X1 = X^4 + b*Z^4
            ModuloOperations.Addition(x1, y1, modulo);

            // a*Z1
            ModuloOperations.Multiply(z1, a, modulo, s, cache);
            // Y^2
            ModuloOperations.Multiply(y, y, modulo, m, cache);
            // a*Z1 + Y^2
            ModuloOperations.Addition(s, m, modulo);
            // a*Z1 + Y^2 + b*Z^4
            ModuloOperations.Addition(s, y1, modulo);
            // X1*(a*Z1 + Y^2 + b*Z^4)
            ModuloOperations.Multiply(s, x1, modulo, s, cache);
            // b*Z^4*Z1
            ModuloOperations.Multiply(y1, z1, modulo, y1, cache);

            // Y1 = b*Z^4*Z1 + X1*(a*Z1 + Y^2 + b*Z^4)
            ModuloOperations.Addition(y1, s, modulo);
            
            return new EllipticCurvePointC(x1, y1, z1, this);
        }
        /// <summary>
        /// Adds the this value with another value in elliptic curve
        /// </summary>
        /// <param name="value">The value to add with this value</param>
        /// <returns>The sum of values</returns>
        public IEllipticCurvePoint Addition(IEllipticCurvePoint value)
        {
            EllipticCurvePointC value2 = value as EllipticCurvePointC;
            if (value2 as object == null)
                throw new Exception("Incorrect point type!");
            if (m_a4 != value2.m_a4 || m_a6 != value2.m_a6 || m_Modulo != value2.m_Modulo)
                throw new Exception("Incorrect value elliptic curve parameters!");
            if (value2.Infinity)
                return new EllipticCurvePointC(m_X, m_Y, m_Z, this);
            if (Infinity)
                return new EllipticCurvePointC(value2.m_X, value2.m_Y, value2.m_Z, value2);
            if (Equals(value2))
                return Doubling();
            // Coordinates
            uint[] a = m_a4.m_Value;
            uint[] x1 = m_X.m_Value;
            uint[] y1 = m_Y.m_Value;
            uint[] z1 = m_Z.m_Value;
            uint[] x2 = value2.m_X.m_Value;
            uint[] y2 = value2.m_Y.m_Value;
            uint[] z2 = value2.m_Z.m_Value;
            uint[] modulo = m_Modulo.m_Value;
            int maxModuloBitIndex = BigHelper.MaxNonZeroBitIndex(modulo);
            int length = modulo.Length;
            // Get the cache
            uint[] cache = new uint[length * 2];

            uint[] A = new uint[length];
            uint[] D = new uint[length];
            uint[] B = new uint[length];
            uint[] C = new uint[length];

            uint[] xr = new uint[length];
            uint[] yr = new uint[length];
            uint[] zr = new uint[length];
            // Z1^2
            ModuloOperations.Multiply(z1, z1, modulo, A, cache);
            // Z1^2 * a
            ModuloOperations.Multiply(z1, a, modulo, D, cache);
            // X2 * Z1
            ModuloOperations.Multiply(x2, z1, modulo, B, cache);
            // B = X2 * Z1 + X1
            ModuloOperations.Addition(B, x1, modulo);

            // C = Z1*B
            ModuloOperations.Multiply(z1, B, modulo, C, cache);

            // C + Z1^2 * a
            ModuloOperations.Addition(D, C, modulo);
            // B * (C + Z1^2 * a)
            ModuloOperations.Multiply(D, B, modulo, D, cache);
            // D = B^2 * (C + Z1^2 * a)
            ModuloOperations.Multiply(D, B, modulo, D, cache);
            
            // Y2 * Z1^2
            ModuloOperations.Multiply(A, y2, modulo, A, cache);
            // A =  Y2 * Z1^2 + Y1
            ModuloOperations.Addition(A, y1, modulo);

            if (BigHelper.IfZero(B))
            {
                if (BigHelper.IfZero(A))
                    return value2.Doubling();
                else
                    return GetInfinity();
            }

            // Z3 = C^2
            ModuloOperations.Multiply(C, C, modulo, zr, cache);

            // E = A * C
            ModuloOperations.Multiply(C, A, modulo, C, cache);

            // A^2
            ModuloOperations.Multiply(A, A, modulo, xr, cache);
            // A^2 + D
            ModuloOperations.Addition(xr, D, modulo);
            // X3 = A^2 + D + E
            ModuloOperations.Addition(xr, C, modulo);

            // X2 * Z3
            ModuloOperations.Multiply(x2, zr, modulo, A, cache);
            // F = X3 + X2 * Z3
            ModuloOperations.Addition(A, xr, modulo);

            // X2 + Y2
            ModuloOperations.Addition(x2, y2, modulo, B);
            // (X2 + Y2) * Z3
            ModuloOperations.Multiply(B, zr, modulo, B, cache);
            // G = (X2 + Y2) * Z3^2
            ModuloOperations.Multiply(B, zr, modulo, B, cache);

            // E + Z3
            ModuloOperations.Addition(C, zr, modulo, yr);
            // (E + Z3) * F
            ModuloOperations.Multiply(yr, A, modulo, yr, cache);
            // (E + Z3) * F + G
            ModuloOperations.Addition(yr, B, modulo, yr);
            
            return new EllipticCurvePointC(xr, yr, zr, this);
        }
        /// <summary>
        /// Multiplies the this value at IntBig value
        /// </summary>
        /// <param name="value">IntBig multiplier</param>
        /// <returns>Result of operation</returns>
        public IEllipticCurvePoint Multiply(IntBig value2)
        {
            EllipticCurvePointC tempPoint = null;
            EllipticCurvePointC[] points = new EllipticCurvePointC[16];
            points[0] = GetInfinity() as EllipticCurvePointC;
            points[1] = this;
            points[2] = points[1].Doubling() as EllipticCurvePointC;
            points[3] = points[1].Addition(points[2]) as EllipticCurvePointC;
            points[4] = points[2].Doubling() as EllipticCurvePointC;
            points[5] = points[1].Addition(points[4]) as EllipticCurvePointC;
            points[6] = points[3].Doubling() as EllipticCurvePointC;
            points[7] = points[1].Addition(points[6]) as EllipticCurvePointC;
            points[8] = points[4].Doubling() as EllipticCurvePointC;
            points[9] = points[1].Addition(points[8]) as EllipticCurvePointC;
            points[10] = points[5].Doubling() as EllipticCurvePointC;
            points[11] = points[1].Addition(points[10]) as EllipticCurvePointC;
            points[12] = points[6].Doubling() as EllipticCurvePointC;
            points[13] = points[1].Addition(points[12]) as EllipticCurvePointC;
            points[14] = points[7].Doubling() as EllipticCurvePointC;
            points[15] = points[1].Addition(points[14]) as EllipticCurvePointC;
            // First index 
            int index = BigHelper.MaxNonZeroBitIndex(value2.m_Value);
            int howManyDouble = 0;
            int howMuchAdd = 0;

            //if (index < 0)
            //    break;
            index = GetWindow(value2, index, out howManyDouble, out howMuchAdd);
            tempPoint = points[howMuchAdd];

            while (true)
            {
                if (index < 0)
                    break;
                index = GetWindow(value2, index, out howManyDouble, out howMuchAdd);
                if (howManyDouble > 0)
                    for (int t = 0; t < howManyDouble; ++t)
                        tempPoint = tempPoint.Doubling() as EllipticCurvePointC;
                if (howMuchAdd > 0)
                    tempPoint = tempPoint.Addition(points[howMuchAdd]) as EllipticCurvePointC;
            }
            return tempPoint;
        }
        /// <summary>
        /// Invert this value at elliptic curve
        /// </summary>
        /// <returns></returns>
        public IEllipticCurvePoint Invert()
        {
            if (m_Y.Zero)
                return GetInfinity();
            uint[] items = new uint[m_Modulo.m_Value.Length];
            ModuloOperations.Addition(m_X.m_Value, m_Y.m_Value, m_Modulo.m_Value, items);
            return new EllipticCurvePointC(m_X, new IntBig(items), m_Z, this);
        }
        /// <summary>
        /// Get the infinity point
        /// </summary>
        /// <returns>Infinity point</returns>
        public static EllipticCurvePointC GetInfinity(EllipticCurvePointC other)
        {
            return new EllipticCurvePointC(1, 0, 0, other);
        }
        /// <summary>
        /// Doubling the point in elliptic curve
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static EllipticCurvePointC Doubling(EllipticCurvePointC value)
        {
            return value.Doubling() as EllipticCurvePointC;
        }
        /// <summary>
        /// Adds the value with another value in elliptic curve
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static EllipticCurvePointC Addition(EllipticCurvePointC value1, EllipticCurvePointC value2)
        {
            return value1.Addition(value2) as EllipticCurvePointC;
        }
        /// <summary>
        /// Multiplies the value at IntBig value
        /// </summary>
        /// <param name="value1">Elliptic curve point</param>
        /// <param name="value2">IntBig multiplier</param>
        /// <returns>Result</returns>
        public static EllipticCurvePointC Multiply(EllipticCurvePointC value1, IntBig value2)
        {
            return value1.Multiply(value2) as EllipticCurvePointC;
        }
        /// <summary>
        /// Invert value at elliptic curve
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static EllipticCurvePointC Invert(EllipticCurvePointC value)
        {
            return value.Invert() as EllipticCurvePointC;
        }
        #endregion Public methods
        #region Private methods
        private static bool Eguals(uint[] value1, uint[] value2)
        {
            for (int i = 0; i < value1.Length; i++)
                if (value1[i] != value2[i])
                    return false;
            return true;
        }
        /// <summary>
        /// Get "float window" and parametrs
        /// </summary>
        /// <param name="value">Mul value</param>
        /// <param name="lastIndex">Last index in mul value</param>
        /// <param name="mulValue">How many doubling</param>
        /// <param name="addValue">How much add after</param>
        /// <returns>New index</returns>
        private static int GetWindow(IntBig value, int lastIndex, out int mulValue, out int addValue)
        {
            mulValue = 0;
            addValue = 0;
            if (lastIndex < 0)
                return lastIndex;
            while(true)
            {
                mulValue++;
                addValue *= 2;
                if (value.GetBit(lastIndex))
                    addValue += 1;
                lastIndex--;
                if (addValue >= 8)
                    break;
                if (lastIndex < 0)
                    break;
            }
            return lastIndex;
        }
        #endregion Private methods
        #region Events, overrides
        #region Other
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            EllipticCurvePointC obj1 = obj as EllipticCurvePointC;
            if (obj1 == null)
                return false;
            return Equals(obj1);
        }
        public bool Equals(IEllipticCurvePoint obj)
        {
            if (obj as object == null)
                return false;
            if (obj as object == this)
                return true;
            EllipticCurvePointC obj1 = obj as EllipticCurvePointC;
            if (obj1 as object == null)
                return false;
            if (m_X == obj1.m_X)
                if (m_Y == obj1.m_Y)
                    if (m_Z == obj1.m_Z)
                        return true;
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion Other
        #endregion Events, overrides
        #endregion Methods
    }
}
#endregion Working namespace