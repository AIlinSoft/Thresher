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
    [Serializable, StructLayout(LayoutKind.Sequential), ComVisible(true)]
    public class EllipticCurvePoint : IEquatable<EllipticCurvePoint>
    {
        #region Classes, structures, enumerators
        #endregion Classes, structures, enumerators
        #region Constructors
        /// <summary>
        /// Закрыть конструктор по умолчанию
        /// </summary>
        private EllipticCurvePoint()
        {
        }
        /// <summary>
        /// Parse the curve and points parameters
        /// </summary>
        /// <param name="x">The X value in affine coordinate</param>
        /// <param name="y">The Y value in affine coordinate</param>
        /// <param name="a1">The a1 elliptic curve parameter in the Weierstrass equation</param>
        /// <param name="a2">The a2 elliptic curve parameter in the Weierstrass equation</param>
        /// <param name="a3">The a3 elliptic curve parameter in the Weierstrass equation</param>
        /// <param name="a4">The a4 elliptic curve parameter in the Weierstrass equation</param>
        /// <param name="a6">The a6 elliptic curve parameter in the Weierstrass equation</param>
        /// <param name="modulo">The modulo for finite field operations</param>
        internal EllipticCurvePoint(IntBig x, IntBig y, IntBig a1, IntBig a2, IntBig a3, IntBig a4, IntBig a6, IntBig modulo)
        {
            // Set resolver for different types of elliptic curve
            if (a1 == null && a2 == null && a3 == null && a4 != null && a6 != null)
                m_Resolver = new EllipticCurvePointB(x, y, a4, a6, modulo);
            else
                throw new Exception("Unknown type of elliptic curve.");
        }
        internal EllipticCurvePoint(IEllipticCurvePoint resolver)
        {
            m_Resolver = resolver;
        }
        internal EllipticCurvePoint(IntBig x, IntBig y, IEllipticCurvePoint resolver)
        {
            m_Resolver = new EllipticCurvePointB(x, y, resolver as EllipticCurvePointB);
        }
        internal EllipticCurvePoint(uint[] x, uint[] y, uint[] z, IEllipticCurvePoint resolver)
        {
            m_Resolver = new EllipticCurvePointB(x, y, z, resolver as EllipticCurvePointB);
        }
        internal EllipticCurvePoint(IntBig x, IntBig y, IntBig z, IEllipticCurvePoint resolver)
        {
            m_Resolver = new EllipticCurvePointB(x, y, z, resolver as EllipticCurvePointB);
        }
        internal EllipticCurvePoint(uint x, uint y, uint z, IEllipticCurvePoint resolver)
        {
            m_Resolver = new EllipticCurvePointB(x, y, z, resolver as EllipticCurvePointB);
        }
        #endregion Constructors
        #region Variables
        /// <summary>
        /// Афинные и Якобиановы координаты точки
        /// </summary>
        internal IEllipticCurvePoint m_Resolver;
        #endregion Variables
        #region Fields
        /// <summary>
        /// Точка в бесконечности для якобиановых координат
        /// </summary>
        public bool Infinity
        {
            get
            {
                return m_Resolver.Infinity;
            }
        }
        
        /// <summary>
        /// The X value in affine coordinate
        /// </summary>
        public IntBig x
        {
            get
            {
                return m_Resolver.x;
            }
        }
        /// <summary>
        /// The Y value in affine coordinate
        /// </summary>
        public IntBig y
        {
            get
            {
                return m_Resolver.y;
            }
        }
        #endregion Fields
        #region Methods
        #region Public methods
        /// <summary>
        /// Parse the curve and points parameters
        /// </summary>
        /// <param name="x">The X value in affine coordinate</param>
        /// <param name="y">The Y value in affine coordinate</param>
        /// <param name="a1">The a1 elliptic curve parameter in the Weierstrass equation</param>
        /// <param name="a2">The a2 elliptic curve parameter in the Weierstrass equation</param>
        /// <param name="a3">The a3 elliptic curve parameter in the Weierstrass equation</param>
        /// <param name="a4">The a4 elliptic curve parameter in the Weierstrass equation</param>
        /// <param name="a6">The a6 elliptic curve parameter in the Weierstrass equation</param>
        /// <param name="modulo">The modulo for finite field operations</param>
        public static EllipticCurvePoint Parse(IntBig x, IntBig y, IntBig a1, IntBig a2, IntBig a3, IntBig a4, IntBig a6, IntBig modulo)
        {
            return new EllipticCurvePoint(x, y, a1, a2, a3, a4, a6, modulo);
        }
        /// <summary>
        /// Parse the curve from another point and new points parameters x,y
        /// </summary>
        /// <param name="x">The X value in affine coordinate</param>
        /// <param name="y">The Y value in affine coordinate</param>
        /// <param name="point">Another point</param>
        public static EllipticCurvePoint Parse(IntBig x, IntBig y, EllipticCurvePoint point)
        {
            return new EllipticCurvePoint(x, y, point.m_Resolver);
        }
        /// <summary>
        /// Удвоить точку на кривой
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static EllipticCurvePoint Doubling(EllipticCurvePoint value)
        {
            return new EllipticCurvePoint(value.m_Resolver.Doubling()); 
        }
        /// <summary>
        /// Сложить две точки на кривой
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static EllipticCurvePoint Addition(EllipticCurvePoint value1, EllipticCurvePoint value2)
        {
            return new EllipticCurvePoint(value1.m_Resolver.Addition(value2.m_Resolver));
        }

        /// <summary>
        /// Умножить точку на число на эллиптической кривой
        /// </summary>
        /// <param name="value1">Точка на эллиптической кривой</param>
        /// <param name="value2">Множитель к точке</param>
        /// <returns></returns>
        public static EllipticCurvePoint Multiply(EllipticCurvePoint value1, IntBig value2)
        {
            return new EllipticCurvePoint(value1.m_Resolver.Multiply(value2));
        }
        public static EllipticCurvePoint Invert(EllipticCurvePoint value)
        {
            return new EllipticCurvePoint(value.m_Resolver.Invert());
        }
        #endregion Public methods
        #region Private methods
        #endregion Private methods
        #region Events, overrides
        #region Arithmetic
        /// <summary>
        /// Сложить две точки на эллиптической кривой
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static EllipticCurvePoint operator +(EllipticCurvePoint value1, EllipticCurvePoint value2)
        {
            return Addition(value1, value2);
        }
        /// <summary>
        /// Сложить первую точку с инвертированной второй
        /// </summary>
        /// <param name="value1">Первая точка</param>
        /// <param name="value2">Вторая точка</param>
        /// <returns></returns>
        public static EllipticCurvePoint operator -(EllipticCurvePoint value1, EllipticCurvePoint value2)
        {
            return Addition(value1, Invert(value2));
        }
        /// <summary>
        /// Инвертировать значение точки на кривой
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static EllipticCurvePoint operator -(EllipticCurvePoint value)
        {
            return Invert(value);
        }
        /// <summary>
        /// Умножить точку эллиптической кривой на число
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static EllipticCurvePoint operator *(EllipticCurvePoint value1, IntBig value2)
        {
            // TODO: *2 as doubling
            return Multiply(value1, value2);
        }
        #endregion Arithmetic
        #region Other
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            EllipticCurvePoint obj1 = obj as EllipticCurvePoint;
            if (obj1 == null)
                return false;
            return Equals(obj1);
        }
        public bool Equals(EllipticCurvePoint obj)
        {
            if (obj as object == null)
                return false;
            if (obj as object == this)
                return true;
            return m_Resolver.Equals(obj.m_Resolver);
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