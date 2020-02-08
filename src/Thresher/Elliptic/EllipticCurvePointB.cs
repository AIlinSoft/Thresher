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
    /// The elliptic curve y^2 = x^3 + a4*x + a6
    /// </summary>
    [Serializable, StructLayout(LayoutKind.Sequential), ComVisible(true)]
    public class EllipticCurvePointB : IEllipticCurvePoint
    {
        #region Classes, structures, enums
        #endregion Classes, structures, enums
        #region Constructors
        /// <summary>
        /// Hide the default constructor
        /// </summary>
        private EllipticCurvePointB()
        {
        }
        public EllipticCurvePointB(IntBig x, IntBig y, EllipticCurvePointB point)
        {
            m_x = x;
            m_y = y;
            m_Modulo = point.m_Modulo;
            m_a4 = point.m_a4;
            m_a6 = point.m_a6;
            if (!IsValid(m_x, m_y, m_a4, m_a6, m_Modulo))
                throw new Exception("Point is not from elliptic curve");
            m_X = new IntBig(x.m_Value) % m_Modulo;
            m_Y = new IntBig(y.m_Value) % m_Modulo;
            m_Z = new IntBig(1);
        }
        public EllipticCurvePointB(IntBig x, IntBig y, IntBig a4, IntBig a6, IntBig modulo)
        {
            m_x = x;
            m_y = y;
            m_Modulo = modulo;
            m_a4 = a4;
            m_a6 = a6;
            if (!IsValid(m_x, m_y, m_a4, m_a6, m_Modulo))
                throw new Exception("Point is not from elliptic curve");
            m_X = new IntBig(x.m_Value) % m_Modulo;
            m_Y = new IntBig(y.m_Value) % m_Modulo;
            m_Z = new IntBig(1);
        }
        internal EllipticCurvePointB(uint[] x, uint[] y, uint[] z, EllipticCurvePointB point)
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
        internal EllipticCurvePointB(IntBig x, IntBig y, IntBig z, EllipticCurvePointB point)
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
        internal EllipticCurvePointB(uint x, uint y, uint z, EllipticCurvePointB point)
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
                return m_Z.Zero;
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
                    uint[] temp = new uint[m_Modulo.m_Value.Length];
                    uint[] result = new uint[m_Modulo.m_Value.Length];
                    uint[] tempMultiply = new uint[m_Modulo.m_Value.Length * 2];
                    ModuloOperations.Multiply(m_Z.m_Value, m_Z.m_Value, m_Modulo.m_Value, temp, tempMultiply);

                    ModuloOperations.Divide(m_X.m_Value, temp, m_Modulo.m_Value, result);
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
                    ModuloOperations.Multiply(m_Z.m_Value, temp, m_Modulo.m_Value, temp, tempMultiply);

                    ModuloOperations.Divide(m_Y.m_Value, temp, m_Modulo.m_Value, result);
                    m_y = new IntBig(result);
                }
                return m_y;
            }
        }
        #endregion Fields
        #region Methods
        #region Public methods
        public static bool IsValid(IntBig x, IntBig y, IntBig a4, IntBig a6, IntBig modulo)
        {
            MIntBig my = new MIntBig(y, modulo);
            MIntBig mx = new MIntBig(x, modulo);
            MIntBig ma4 = new MIntBig(a4, modulo);
            MIntBig ma6 = new MIntBig(a6, modulo);

            MIntBig my2 = my * my;
            MIntBig mx2 = mx * mx * mx + ma4 * mx + ma6;
            return my2 == mx2;
        }
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
            return new EllipticCurvePointB(1, 1, 0, this);
        }
        /// <summary>
        /// Удвоить точку на кривой
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IEllipticCurvePoint Doubling()
        {
            if (m_Y.Zero)
                return GetInfinity();
            // Исходные координаты
            uint[] a = m_a4.m_Value;
            uint[] x = m_X.m_Value;
            uint[] y = m_Y.m_Value;
            uint[] z = m_Z.m_Value;
            uint[] modulo = m_Modulo.m_Value;
            int maxModuloBitIndex = BigHelper.MaxNonZeroBitIndex(modulo);
            int length = modulo.Length;
            // Выделим кэш операций умножения
            uint[] cache = new uint[length * 2];
            uint[] s = new uint[length];
            uint[] m = new uint[length];

            uint[] x1 = new uint[length];
            uint[] y1 = new uint[length];
            uint[] z1 = new uint[length];

            // Расчитаем m
            // Первое слагаемое a*Z1^4
            ModuloOperations.Multiply(z, z, modulo, z1, cache);
            ModuloOperations.Multiply(z1, z1, modulo, z1, cache);
            ModuloOperations.Multiply(z1, a, modulo, z1, cache);
            // Второе слагаемое 3*X1^2
            ModuloOperations.Multiply(x, x, modulo, m, cache);
            ModuloOperations.Multiply(m, 3, modulo, m, cache);
            // Результат m = 3*X1^2 + a*Z1^4
            ModuloOperations.Addition(m, z1, modulo);

            // Расчитаем s = 4*X1*Y1^2
            ModuloOperations.Multiply(y, y, modulo, z1, cache);

            ModuloOperations.Multiply(z1, x, modulo, s, cache);
            ModuloOperations.Multiply(s, 4, modulo, s, cache);

            // Расчитаем X3 = m^2 - 2*s
            ModuloOperations.Multiply(m, m, modulo, x1, cache);
            ModuloOperations.Multiply(s, 2, modulo, y1, cache);
            ModuloOperations.Substraction(x1, y1, modulo);

            // Расчитаем Y3 = m*(s - X3) - 8*Y1^4
            ModuloOperations.Multiply(z1, z1, modulo, z1, cache);
            ModuloOperations.Multiply(z1, 8, modulo, z1, cache);

            ModuloOperations.Substraction(s, x1, modulo, y1);
            ModuloOperations.Multiply(y1, m, modulo, y1, cache);
            ModuloOperations.Substraction(y1, z1, modulo);

            // Расчитаем Z3 = 2*Y1*Z1
            ModuloOperations.Multiply(y, z, modulo, z1, cache);
            ModuloOperations.Multiply(z1, 2, modulo, z1, cache);

            return new EllipticCurvePointB(x1, y1, z1, this);
        }
        /// <summary>
        /// Сложить две точки на кривой
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public IEllipticCurvePoint Addition(IEllipticCurvePoint value)
        {
            EllipticCurvePointB value2 = value as EllipticCurvePointB;
            if (value2 as object == null)
                throw new Exception("Incorrect point type!");
            if (m_a4 != value2.m_a4 || m_a6 != value2.m_a6 || m_Modulo != value2.m_Modulo)
                throw new Exception("Incorrect value elliptic curve parameters!");

            if (Equals(value2))
                return Doubling();
            // Исходные координаты
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
            // Выделим кэш операций умножения
            uint[] cache = new uint[length * 2];
            // Временные переменные
            uint[] u1 = new uint[length];
            uint[] u2 = new uint[length];
            uint[] s1 = new uint[length];
            uint[] s2 = new uint[length];

            uint[] xr = new uint[length];
            uint[] yr = new uint[length];
            uint[] zr = new uint[length];
            // Вычислить U1, U2, S1, S2
            ModuloOperations.Multiply(z2, z2, modulo, u1, cache);
            ModuloOperations.Multiply(z1, z1, modulo, u2, cache);

            ModuloOperations.Multiply(u1, z2, modulo, s1, cache);
            ModuloOperations.Multiply(u2, z1, modulo, s2, cache);

            ModuloOperations.Multiply(u1, x1, modulo, u1, cache);
            ModuloOperations.Multiply(u2, x2, modulo, u2, cache);

            ModuloOperations.Multiply(s1, y1, modulo, s1, cache);
            ModuloOperations.Multiply(s2, y2, modulo, s2, cache);
            // Проверим, может расчет
            if (Eguals(u1, u2))
            {
                if (Eguals(s1, s2))
                    return Doubling();
                else
                    return GetInfinity();
            }
            ModuloOperations.Substraction(u2, u1, modulo);
            ModuloOperations.Substraction(s2, s1, modulo);
            //H^2
            ModuloOperations.Multiply(u2, u2, modulo, yr, cache);
            //H^3
            ModuloOperations.Multiply(yr, u2, modulo, zr, cache);
            //R^2
            ModuloOperations.Multiply(s2, s2, modulo, xr, cache);
            //R^2 - H^3
            ModuloOperations.Substraction(xr, zr, modulo);
            //U1*H^2
            ModuloOperations.Multiply(u1, yr, modulo, yr, cache);
            //2*U1*H^2
            ModuloOperations.Multiply(yr, 2, modulo, u1, cache);
            
            //X3 = R^2 - H^3 - 2*U1*H^2
            ModuloOperations.Substraction(xr, u1, modulo);

            //U1*H^2 - X3
            ModuloOperations.Substraction(yr, xr, modulo);
            //R*(U1*H^2 - X3)
            ModuloOperations.Multiply(yr, s2, modulo, yr, cache);
            //S1*H^3
            ModuloOperations.Multiply(s1, zr, modulo, zr, cache);
            //R*(U1*H^2 - X3) - S1*H^3
            ModuloOperations.Substraction(yr, zr, modulo);

            //Z1*Z2
            ModuloOperations.Multiply(z1, z2, modulo, zr, cache);
            //Z3 = H*Z1*Z2
            ModuloOperations.Multiply(zr, u2, modulo, zr, cache);

            return new EllipticCurvePointB(xr, yr, zr, this);
        }

        /// <summary>
        /// Умножить точку на число на эллиптической кривой
        /// </summary>
        /// <param name="value1">Точка на эллиптической кривой</param>
        /// <param name="value2">Множитель к точке</param>
        /// <returns></returns>
        public IEllipticCurvePoint Multiply(IntBig value2)
        {
            EllipticCurvePointB tempPoint = null;
            // Массив значений для этапа "предвычислений"
            // !!!!!!!!!!!!!!Занимательная задачка: надо подумать над графом вычислений, ибо почти стопроцентная уверенность, что не все значения массива понадобятся... Налицо оптимизация
            EllipticCurvePointB[] points = new EllipticCurvePointB[16];
            points[0] = GetInfinity() as EllipticCurvePointB;
            points[1] = this;
            points[2] = points[1].Doubling() as EllipticCurvePointB;
            points[3] = points[1].Addition(points[2]) as EllipticCurvePointB;
            points[4] = points[2].Doubling() as EllipticCurvePointB;
            points[5] = points[1].Addition(points[4]) as EllipticCurvePointB;
            points[6] = points[3].Doubling() as EllipticCurvePointB;
            points[7] = points[1].Addition(points[6]) as EllipticCurvePointB;
            points[8] = points[4].Doubling() as EllipticCurvePointB;
            points[9] = points[1].Addition(points[8]) as EllipticCurvePointB;
            points[10] = points[5].Doubling() as EllipticCurvePointB;
            points[11] = points[1].Addition(points[10]) as EllipticCurvePointB;
            points[12] = points[6].Doubling() as EllipticCurvePointB;
            points[13] = points[1].Addition(points[12]) as EllipticCurvePointB;
            points[14] = points[7].Doubling() as EllipticCurvePointB;
            points[15] = points[1].Addition(points[14]) as EllipticCurvePointB;
            // Начальный индекс множителя, от него начинается движение по двоичному представлению большого числа
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
                        tempPoint = tempPoint.Doubling() as EllipticCurvePointB;
                if (howMuchAdd > 0)
                    tempPoint = tempPoint.Addition(points[howMuchAdd]) as EllipticCurvePointB;
            }
            return tempPoint;
        }
        public IEllipticCurvePoint Invert()
        {
            if (m_Y.Zero)
                return GetInfinity();
            uint[] items = new uint[m_Modulo.m_Value.Length];
            ModuloOperations.ChangeSign(m_Y.m_Value, m_Modulo.m_Value, items);
            return new EllipticCurvePointB(m_X, new IntBig(items), m_Z, this);
        }
        public static EllipticCurvePointB GetInfinity(EllipticCurvePointB other)
        {
            return new EllipticCurvePointB(1, 1, 0, other);
        }
        /// <summary>
        /// Удвоить точку на кривой
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static EllipticCurvePointB Doubling(EllipticCurvePointB value)
        {
            return value.Doubling() as EllipticCurvePointB;
        }
        /// <summary>
        /// Сложить две точки на кривой
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static EllipticCurvePointB Addition(EllipticCurvePointB value1, EllipticCurvePointB value2)
        {
            return value1.Addition(value2) as EllipticCurvePointB;
        }
        /// <summary>
        /// Умножить точку на число на эллиптической кривой
        /// </summary>
        /// <param name="value1">Точка на эллиптической кривой</param>
        /// <param name="value2">Множитель к точке</param>
        /// <returns></returns>
        public static EllipticCurvePointB Multiply(EllipticCurvePointB value1, IntBig value2)
        {
            return value1.Multiply(value2) as EllipticCurvePointB;
        }
        public static EllipticCurvePointB Invert(EllipticCurvePointB value)
        {
            return value.Invert() as EllipticCurvePointB;
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
            EllipticCurvePointB obj1 = obj as EllipticCurvePointB;
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
            EllipticCurvePointB obj1 = obj as EllipticCurvePointB;
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
        /*  /// <summary>
        /// Умножить точку на число на эллиптической кривой (сдается мне, что этот метод не нужен)
        /// </summary>
        /// <param name="value1">Точка на эллиптической кривой</param>
        /// <param name="value2">Множитель к точке</param>
        /// <returns></returns>
        public static EllipticCurvePoint Multiply(EllipticCurvePoint value1, BigModuloInteger value2)
        {
            //      EllipticCurvePoint returnValue = new EllipticCurvePoint();
            EllipticCurvePoint tempPoint = value1;
            //  int index = value2.m_MaxModuloBitIndex;
            // Массив значений для этапа "предвычислений"
            // !!!!!!!!!!!!!!Занимательная задачка: надо подумать над графом вычислений, ибо почти стопроцентная уверенность, что не все значения массива понадобятся... Налицо оптимизация
            EllipticCurvePoint[] points = new EllipticCurvePoint[16];
            points[1] = value1;
            points[2] = Twice(points[1]);
            points[3] = points[1] + points[2];
            points[4] = Twice(points[2]);
            points[5] = points[1] + points[4];
            points[6] = Twice(points[3]);
            points[7] = points[1] + points[6];
            points[8] = Twice(points[4]);
            points[9] = points[1] + points[8];
            points[10] = Twice(points[5]);
            points[11] = points[1] + points[10];
            points[12] = Twice(points[6]);
            points[13] = points[1] + points[12];
            points[14] = Twice(points[7]);
            points[15] = points[1] + points[14];
            // Начальный индекс множителя, от него начинается движение по двоичному представлению большого числа
            int index = BigModuloInteger.MaxBitIndex(value2.m_Items);

            while (true)
            {
                int[] temp = GetBlockValueAndShift(value2, index);
                if (temp[1] < 0)
                {
                    for (int t = 0; t < index; t++)
                        tempPoint = Twice(tempPoint);
                    return tempPoint;
                }
                else
                    if (temp[1] <= index)
                    {
                        for (int t = 0; t < temp[1]; t++)
                            tempPoint = Twice(tempPoint);
                        if (temp[0] != 0)
                            tempPoint = tempPoint + points[temp[0]];
                        index -= temp[1];
                    }
                    else
                    {
                        for (int t = 0; t < temp[1]; t++)
                            tempPoint = Twice(tempPoint);
                        if (temp[0] != 0)
                            tempPoint = tempPoint + points[temp[0]];
                        return tempPoint;
                    }
            }



            /*  for (int i = value2.m_Items.Length - 1; i >= 0; i--)
              {
                  uint stepValue = value2.m_Items[i];
                  for (int t = 1; t <= 8; t++)
                  {
                      tempPoint = Twice(tempPoint);
                      tempPoint = Twice(tempPoint);
                      tempPoint = Twice(tempPoint);
                      tempPoint = Twice(tempPoint);
                      uint block = (stepValue >> (32 - t*4)) & 0xF;
                      // Считалка-парсер массива
                      switch (block)
                      {
                          case 15:
                              if (points[15] == null)
                              {
                                  if ()
                                  if (points[2] == null)
                                      points[2] = Twice(value1);
                                  if (points[4] == null)
                                      points[4] = Twice(points[2]);
                                  if (points[8] == null)
                                      points[8] = Twice(points[4]);
                                  points[15] = points[8] + points[4] + points[2] + points[1];
                              }
                              break;
                          case 14:
                              if (points[15] == null)
                              {
                                  if (points[2] == null)
                                      points[2] = Twice(value1);
                                  if (points[4] == null)
                                      points[4] = Twice(points[2]);
                                  if (points[8] == null)
                                      points[8] = Twice(points[4]);
                                  points[14] = points[8] + points[4] + points[2] + points[1];
                              }
                              break;



                      }
                      if (block == 15)
                      {
                      }

                  }


                  uint block2 = (stepValue >> 24)&0xF;
                  uint block3 = (stepValue >> 20)&0xF;
                  uint block4 = (stepValue >> 16)&0xF;
                  uint block5 = (stepValue >> 12)&0xF;
                  uint block6 = (stepValue >> 8)&0xF;
                  uint block7 = (stepValue >> 4)&0xF;
                  uint block8 = stepValue&0xF;
            // }

        }*/
    }
}
#endregion Working namespace