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
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
#endregion Using namespaces
#region Working namespace
namespace AIlins.Thresher
{
    /// <summary>
    /// Represents a big signed integer.
    /// </summary>
    [Serializable, StructLayout(LayoutKind.Sequential), ComVisible(true)]
    public class IntBig : IComparable, IFormattable, IComparable<IntBig>, IEquatable<IntBig>
    {
        #region Classes, structures, enums
        #endregion Classes, structures, enums
        #region Constructors
        /// <summary>
        /// Zero value construct
        /// </summary>
        internal IntBig()
        {
            m_Value = null;
        }
        /// <summary>
        /// Initializes a new instance of the IntBig value using long value
        /// </summary>
        /// <param name="value">A long value</param>
        internal IntBig(long value)
        {
            if (value < 0)
            {
                m_Sign = -1;
                value = -value;
            }
            if (value == 0)
            {
                m_Value = null;
                return;
            }

            if (value > uint.MaxValue)
            {
                m_Value = new uint[2];
                m_Value[0] = (uint)value;
                m_Value[1] = (uint)(value >> 32);
                m_Value = BigHelper.GetNonZeroItemsArray(m_Value);
                m_Length = BigHelper.MaxNonZeroBitIndex(m_Value) + 1;
                return;
            }
            m_Value = new uint[1];
            m_Value[0] = (uint)value;
            m_Value = BigHelper.GetNonZeroItemsArray(m_Value);
            m_Length = BigHelper.MaxNonZeroBitIndex((uint)value) + 1;
        }
        /// <summary>
        /// Initializes a new instance of the IntBig value using ulong value
        /// </summary>
        /// <param name="value">A ulong value</param>
        internal IntBig(ulong value)
        {
            if (value == 0)
            {
                m_Value = null;
                return;
            }
            if (value > uint.MaxValue)
            {
                m_Value = new uint[2];
                m_Value[0] = (uint)value;
                m_Value[1] = (uint)(value>>32);
                m_Value = BigHelper.GetNonZeroItemsArray(m_Value);
                if (m_Value != null)
                    m_Length = BigHelper.MaxNonZeroBitIndex(m_Value) + 1;
                return;
            }
            m_Value = new uint[1];
            m_Value[0] = (uint)value;
            m_Value = BigHelper.GetNonZeroItemsArray(m_Value);
            if (m_Value != null)
                m_Length = BigHelper.MaxNonZeroBitIndex((uint)value) + 1;
        }
        internal IntBig(ulong value, bool negative) :
            this(value)
        {
            if (value < 0)
                m_Sign = -1;
        }
        /// <summary>
        /// Initializes a new instance of the value using the values in a uint array
        /// </summary>
        /// <param name="value">An array of uint values in little-endian order</param>
        internal IntBig(uint[] value)
        {
            m_Value = BigHelper.GetNonZeroItemsArray(value);
            if (m_Value != null)
                m_Length = BigHelper.MaxNonZeroBitIndex(m_Value) + 1;
        }
        /// <summary>
        /// Initializes a new instance of the value using the values in a uint array and sign of value
        /// </summary>
        /// <param name="value">An array of uint values in little-endian order</param>
        /// <param name="negative">Sign of value</param>
        internal IntBig(uint[] value, bool negative)
        {
            m_Value = BigHelper.GetNonZeroItemsArray(value);
            if (m_Value != null)
            {
                m_Length = BigHelper.MaxNonZeroBitIndex(m_Value) + 1;
                if (negative)
                    m_Sign = -1;
                else
                    m_Sign = 1;
            }
        }
        /// <summary>
        /// Copy construct (Clone() analog)
        /// </summary>
        /// <param name="value">Value for copy</param>
        internal IntBig(IntBig value)
        {
            m_Value = value.m_Value;
            m_Length = value.m_Length;
            m_Sign = value.m_Sign;
            m_Hash = value.m_Hash;
            m_HashCalculated = value.m_HashCalculated;
            m_InternalLength = value.m_InternalLength;
        }
        #endregion Constructors
        #region Variables
        /// <summary>
        /// Not for user possibly length of integer
        /// </summary>
        /// <remarks>
        /// Always multiple 64 -- the long length (for short length optimiation, in future)
        /// </remarks>
        internal int m_InternalLength;
        /// <summary>
        /// Public users length, increase max bit index of value
        /// </summary>
        internal int m_Length;
        /// <summary>
        /// Value array
        /// </summary>
        /// <remarks>
        /// Big-endian representation 
        /// The value is unchangeable
        /// </remarks>
        internal uint[] m_Value;
        /// <summary>
        /// Hash value
        /// </summary>
        private int m_Hash;
        /// <summary>
        /// Hash calculated flag
        /// </summary>
        private bool m_HashCalculated;
        /// <summary>
        /// Negative sign flag
        /// </summary>
        internal int m_Sign;
        #endregion Variables
        #region Fields
        /// <summary>
        /// Bits length
        /// </summary>
        public int Length
        {
            get
            {
                return m_Length;
            }
        }
        /// <summary>
        /// If zero
        /// </summary>
        /// <returns>True if zero</returns>
        public bool Zero
        {
            get
            {
                return m_Value == null;
            }
        }
        /// <summary>
        /// Negative sign flag
        /// </summary>
        /// <returns>true if less than zero</returns>
        public bool Negative
        {
            get
            {
                return m_Sign < 0;
            }
        }
        /// <summary>
        /// Positive sign flag
        /// </summary>
        /// <returns>True if zero or more</returns>
        public bool Positive
        {
            get
            {
                return m_Sign >= 0;
            }
        } 
        #endregion Fields
        #region Methods
        #region Public methods
        #region New
        /// <summary>
        /// Parse uint vector (with copy)
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="littleEndian">true if value represents as little-Endian</param>
        /// <returns></returns>
        public static IntBig Parse(uint[] value, bool littleEndian)
        {
            uint[] value1 = new uint[value.Length];
            CommonOperations.FastCopy(value, value1, value.Length);
            return new IntBig(value1);
        }
        /// <summary>
        /// Almost Clone() but without as
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IntBig Parse(IntBig value)
        {
            return new IntBig(value);
        }
        /// <summary>
        /// Initializes a new instance of the value using the values in a byte array
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="littleEndian">true if value represents as little-Endian</param>
        public static IntBig Parse(byte[] value, bool littleEndian)
        {
            return Parse(value, 0, value.Length, littleEndian);
        }
        /// <summary>
        /// Gets the zero number
        /// </summary>
        /// <returns>0 in IntBig representation</returns>
        public static IntBig ParseZero()
        {
            return new IntBig();
        }
        /// <summary>
        /// Initializes a new instance of the IntBig value using ulong value
        /// </summary>
        /// <param name="value">Value</param>
        public static IntBig Parse(ulong value)
        {
            return new IntBig(value);
        }
        /// <summary>
        /// Initializes a new instance of the IntBig value using string value with modifier (if modifier not use, the velue is decimal)
        /// </summary>
        /// <param name="value">Value tring representation</param>
        /// <param name="littleEndian">true if value represents as little-Endian</param>
        public static IntBig Parse(string value, bool littleEndian)
        {
            bool negative = false;
            if (value.StartsWith("-"))
                negative = true;
            uint[] items = BigHelper.Parse(value, littleEndian);
            return new IntBig(items, negative);
        }
        /// <summary>
        /// Parse the byte array
        /// </summary>
        /// <param name="value">Value array</param>
        /// <param name="index">First byte index</param>
        /// <param name="length">Byte length</param>
        /// <param name="littleEndian">Little endian representation in value array</param>
        public static IntBig Parse(byte[] value, int index, int length, bool littleEndian)
        {
            uint[] value1 = BigHelper.Parse(value, index, length, littleEndian);
            return new IntBig(value1);
        }
        #endregion New
        #region Other
        /// <summary>
        /// Return the absolute value of 
        /// </summary>
        /// <param name="value">Value</param>
        /// <returns>The absolute value</returns>
        public static IntBig Abs(IntBig value)
        {
            return new IntBig(value.m_Value);
        }
        /// <summary>
        /// Converts value to a byte array
        /// </summary>
        /// <param name="littleEndian">Return the byte array in little endian representation</param>
        /// <returns></returns>
        public byte[] ToByteArray(bool littleEndian)
        {
            return BigHelper.ToByteArray(m_Value, littleEndian);
        }
        /// <summary>
        /// Converts value to a uint array
        /// </summary>
        /// <param name="littleEndian">Return the uint array in little endian representation</param>
        /// <returns></returns>
        public uint[] ToUintArray(bool littleEndian)
        {
            return BigHelper.ToUintArray(m_Value, littleEndian);
        }
        public string ToString(string format)
        {
            return BigHelper.ToString(m_Value, format, true);
        }
        public string ToString(IFormatProvider provider)
        {
            return BigHelper.ToString(m_Value, "X", true);
        }
        #endregion Other
        #region Pow
        /// <summary>
        /// Raises value to the power of a specified value
        /// </summary>
        /// <param name="value">The number to raise to the exponent power</param>
        /// <param name="degree">The exponent to raise value by</param>
        /// <returns>The result of raising value to the exponent power</returns>
        public static IntBig Pow(IntBig value, int degree)
        {
            if (value as object == null)
                throw new ArgumentNullException("value");
            if (degree < 0)
                throw new ArgumentOutOfRangeException("degree");
            if (value.Zero)
                return new IntBig(value.m_Value);
            return new IntBig(BigHelper.Pow(value.m_Value, degree), value.Negative);
        }
        /// <summary>
        /// Raises ulong value to the power of a specified value
        /// </summary>
        /// <param name="value">The ulong number to raise to the exponent power</param>
        /// <param name="degree">The exponent to raise value by</param>
        /// <returns>The result of raising ulong value to the exponent power</returns>
        public static IntBig Pow(ulong value, int degree)
        {
            if (degree < 0)
                throw new ArgumentOutOfRangeException("degree");
            if (value == 0)
                return new IntBig();
            if (value == 1)
                return new IntBig(1);
            return new IntBig(BigHelper.Pow(value, degree), false);
        }
        /// <summary>
        /// Raises long value to the power of a specified value
        /// </summary>
        /// <param name="value">The long number to raise to the exponent power</param>
        /// <param name="degree">The exponent to raise value by</param>
        /// <returns>The result of raising long value to the exponent power</returns>
        public static IntBig Pow(long value, int degree)
        {
            if (degree < 0)
                throw new ArgumentOutOfRangeException("degree");
            bool negative = false;
            if (value < 0)
                if (degree % 2 == 1)
                    negative = true;
            if (value == 0)
                return new IntBig();
            if (value == 1 || value == -1)
                return new IntBig(value);
            return new IntBig(BigHelper.Pow((ulong)Math.Abs(value), degree), negative);
        }
        #endregion Pow
        #region Log
        public static double Log(IntBig value, double basis)
        {
            if (value as object == null)
                throw new ArgumentNullException("value");
            if (basis == 0.0)
                throw new Exception("basis");

            //if (value.Zero)
          //      return new IntBig(value.m_Value);
            return 0;
        }
        #endregion Log
        #endregion Public methods
        #region Internal methods
        /// <summary>
        /// Значение бита
        /// </summary>
        /// <param name="value"></param>
        /// <param name="shiftValue"></param>
        /// <returns></returns>
        internal bool GetBit(int index)
        {
            int indexShift = index / 32;
            if (indexShift >= Length)
                throw new ArgumentOutOfRangeException("index");
            uint valueForGet = m_Value[indexShift];
            int countShift = index % 32;
            return ((valueForGet >> countShift) & 0x1) == 0x1;
        }        
      
        #endregion Internal methods
        #region Private methods
        #endregion Private methods
        #region Events, overrides
        #region Arithmetic
        #region Subtract
        /// <summary>
        /// Subtracts a value from another value
        /// </summary>
        /// <param name="value1">The value to subtract from</param>
        /// <param name="value2Temp">The value to subtract</param>
        /// <returns>The result of subtracting</returns>
        public static IntBig operator -(IntBig value1, IntBig value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            if (value2 as object == null)
                throw new ArgumentNullException("value2");
            if (value2.Zero)
                return new IntBig(value1.m_Value, value1.Negative);
            if (value1.Zero)
                return -value2;
            int newLength = value1.m_Value.Length;
            if (value2.m_Value.Length > newLength)
                newLength = value2.m_Value.Length;
            uint[] cache = new uint[newLength];
            if (value1.Negative == value2.Negative)
            {
                if (BigHelper.Substraction(value1.m_Value, value2.m_Value, cache))
                {
                    BigHelper.ToOPCode(cache);
                    return new IntBig(cache, !value1.Negative);
                }
                return new IntBig(cache, value1.Negative);
            }
            else
            {
                uint over = BigHelper.Addition(value1.m_Value, value2.m_Value, cache);
                if (over > 0)
                {
                    uint[] temp = new uint[newLength + 1];
                    CommonOperations.FastCopy(cache, temp, newLength);
                    temp[newLength] = over;
                    return new IntBig(temp, value1.Negative);
                }
                return new IntBig(cache, value1.Negative);
            }
        }
        /// <summary>
        /// Subtracts a value from another value
        /// </summary>
        /// <param name="value1">The value to subtract from</param>
        /// <param name="value2">The value to subtract</param>
        /// <returns>The result of subtracting</returns>
        public static IntBig operator -(IntBig value1, ulong value2)
        {
            return value1 - new IntBig(value2);
        }
        /// <summary>
        /// Subtracts a value from another value
        /// </summary>
        /// <param name="value1">The value to subtract from</param>
        /// <param name="value2">The value to subtract</param>
        /// <returns>The result of subtracting</returns>
        public static IntBig operator -(IntBig value1, long value2)
        {
            return value1 - new IntBig(value2);
        }
        /// <summary>
        /// Subtracts a value from another value
        /// </summary>
        /// <param name="value1">The value to subtract from</param>
        /// <param name="value2">The value to subtract</param>
        /// <returns>The result of subtracting</returns>
        public static IntBig operator -(ulong value1, IntBig value2)
        {
            return new IntBig(value1) - value2;
        }
        /// <summary>
        /// Subtracts a value from another value
        /// </summary>
        /// <param name="value1">The value to subtract from</param>
        /// <param name="value2">The value to subtract</param>
        /// <returns>The result of subtracting</returns>
        public static IntBig operator -(long value1, IntBig value2)
        {
            return new IntBig(value1) - value2;
        }
        /// <summary>
        /// Decrements value
        /// </summary>
        /// <param name="value1">The value to decrement</param>
        /// <returns>Decremented value</returns>
        public static IntBig operator --(IntBig value)
        {
            if (value as object == null)
                throw new ArgumentNullException("value");
            if (value.Zero)
                return new IntBig(-1);
            int length = value.Length;
            uint[] cache = new uint[length];
            if (value.Negative)
            {
                uint over = BigHelper.Addition(value.m_Value, 1, cache);
                if (over > 0)
                {
                    uint[] temp = new uint[length + 1];
                    CommonOperations.FastCopy(cache, temp, length);
                    temp[length] = over;
                    return new IntBig(temp, true);
                }
                return new IntBig(cache, true);                
            }
            else
            {
                BigHelper.Substraction(value.m_Value, 1, cache);
                return new IntBig(cache);
            }
        }
        /// <summary>
        /// Negates a specified value
        /// </summary>
        /// <param name="value">The value to negate</param>
        /// <returns>The result of the negate operation</returns>
        public static IntBig operator -(IntBig value)
        {
            if (value as object == null)
                throw new ArgumentNullException("value");
            int length = value.Length;
            if (value.Zero)
                new IntBig((uint[])null);
            return new IntBig(value.m_Value, !value.Negative);
        }
        #endregion Subtract
        #region Addition
        /// <summary>
        /// Adds the values
        /// </summary>
        /// <param name="value1">The first value to add</param>
        /// <param name="value2">The second value to add</param>
        /// <returns>The sum of values</returns>
        public static IntBig operator +(IntBig value1, IntBig value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            if (value2 as object == null)
                throw new ArgumentNullException("value2");
            if (value1.Zero)
                return new IntBig(value2);
            if (value2.Zero)
                return new IntBig(value1);

            int newLength = value1.m_Value.Length;
            if (value2.m_Value.Length > newLength)
                newLength = value2.m_Value.Length;
            uint[] cache = new uint[newLength];
            if (value1.Negative != value2.Negative)
            {
                if (BigHelper.Substraction(value1.m_Value, value2.m_Value, cache))
                {
                    BigHelper.ToOPCode(cache);
                    return new IntBig(cache, !value1.Negative);
                }
                return new IntBig(cache, value1.Negative);
            }
            else
            {
                uint over = BigHelper.Addition(value1.m_Value, value2.m_Value, cache);
                if (over > 0)
                {
                    uint[] temp = new uint[newLength + 1];
                    CommonOperations.FastCopy(cache, temp, newLength);
                    temp[newLength] = over;
                    return new IntBig(temp, value1.Negative);
                }
                return new IntBig(cache, value1.Negative);
            }
        }
        /// <summary>
        /// Adds the values
        /// </summary>
        /// <param name="value1">The first value to add</param>
        /// <param name="value2">The second value to add</param>
        /// <returns>The sum of values</returns>
        public static IntBig operator +(IntBig value1, ulong value2)
        {
            return value1 + new IntBig(value2);
        }
        /// <summary>
        /// Adds the values
        /// </summary>
        /// <param name="value1">The first value to add</param>
        /// <param name="value2">The second value to add</param>
        /// <returns>The sum of values</returns>
        public static IntBig operator +(IntBig value1, long value2)
        {
            return value1 + new IntBig(value2);
        }
        /// <summary>
        /// Adds the values
        /// </summary>
        /// <param name="value1">The first value to add</param>
        /// <param name="value2">The second value to add</param>
        /// <returns>The sum of values</returns>
        public static IntBig operator +(ulong value1, IntBig value2)
        {
            return value2 + new IntBig(value1);
        }
        /// <summary>
        /// Adds the values
        /// </summary>
        /// <param name="value1">The first value to add</param>
        /// <param name="value2">The second value to add</param>
        /// <returns>The sum of values</returns>
        public static IntBig operator +(long value1, IntBig value2)
        {
            return value2 + new IntBig(value1);
        }
        /// <summary>
        ///  Increments the value
        /// </summary>
        /// <param name="value">The value to increment</param>
        /// <returns>Incremented value</returns>
        public static IntBig operator ++(IntBig value)
        {
            if (value as object == null)
                throw new ArgumentNullException("value");
            if (value.Zero)
                return new IntBig(1);
            int length = value.Length;
            uint[] cache = new uint[length];
            if (value.Negative)
            {
                BigHelper.Substraction(value.m_Value, 1, cache);
                return new IntBig(cache, true);               
            }
            else
            {
                uint over = BigHelper.Addition(value.m_Value, 1, cache);
                if (over > 0)
                {
                    uint[] temp = new uint[length + 1];
                    CommonOperations.FastCopy(cache, temp, length);
                    temp[length] = over;
                    return new IntBig(temp);
                }
                return new IntBig(cache);
            }
        }
        #endregion Addition
        #region Multiply
        /// <summary>
        /// Multiplies two values
        /// </summary>
        /// <param name="value1">First multiplier</param>
        /// <param name="value2">Second multiplier</param>
        /// <returns>Result value</returns>
        public static IntBig operator *(IntBig value1, IntBig value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            if (value2 as object == null)
                throw new ArgumentNullException("value2");
            if (value1.Zero)
                return new IntBig(value1.m_Value);
            if (value2.Zero)
                return new IntBig(value2.m_Value);
            int newLength = value1.m_Value.Length + value2.m_Value.Length;
            uint[] cache = new uint[newLength];
            BigHelper.Multiply(value1.m_Value, value2.m_Value, cache);
            return new IntBig(cache, value1.Negative ^ value2.Negative);
        }
        #endregion Multiply
        #region Devide
        /// <summary>
        /// Divides the value by another value
        /// </summary>
        /// <param name="value1">The value to be divided</param>
        /// <param name="value2">The value to divide by</param>
        /// <returns>The integral result of the division.</returns>
        public static IntBig operator /(IntBig value1, IntBig value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            if (value2 as object == null)
                throw new ArgumentNullException("value2");
            if (value2.Zero)
                throw new DivideByZeroException("value2");
            if (value1.Zero)
                return new IntBig(value1.m_Value);
            
            uint[] items = new uint[value1.m_Value.Length];
            uint[] items2 = new uint[value2.m_Value.Length];
            BigHelper.Divide(value1.m_Value, value2.m_Value, items, items2);
            return new IntBig(items, value1.Negative ^ value2.Negative);
        }
        /// <summary>
        /// Returns the remainder that results from division with two values
        /// </summary>
        /// <param name="value1">The value to be divided</param>
        /// <param name="value2">The value to divide by</param>
        /// <returns>The remainder that results from the division</returns>
        public static IntBig operator %(IntBig value1, IntBig value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            if (value2 as object == null)
                throw new ArgumentNullException("value2");
            if (value2.Zero)
                throw new DivideByZeroException("value2"); 
            if (value1.Zero)
                return new IntBig(value1.m_Value);
            uint[] items = new uint[value1.m_Value.Length];
            CommonOperations.FastCopy(value1.m_Value, items, items.Length);
            BigHelper.Modulo(items, value2.m_Value);
            return new IntBig(items, value1.Negative ^ value2.Negative);
        }
        #endregion Devide
        #region Bitwise
        /// <summary>
        /// Returns the bitwise one's complement of the value
        /// </summary>
        /// <param name="value">The value for operation</param>
        /// <returns>The bitwise one's complement of value</returns>
        public static IntBig operator ~(IntBig value)
        {
            if (value as object == null)
                throw new ArgumentNullException("value");
            if (value.Zero)
                throw new ArgumentNullException("value"); 
            uint[] items = new uint[value.m_Value.Length];
                BigHelper.Negate(value.m_Value, items);
            return new IntBig(items, !value.Negative);
        }
        /// <summary>
        /// Performs a bitwise And operation on two values
        /// </summary>
        /// <param name="value1">The first value</param>
        /// <param name="value2">The second value</param>
        /// <returns>Result of bitwise And operation</returns>
        public static IntBig operator &(IntBig value1, IntBig value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            if (value2 as object == null)
                throw new ArgumentNullException("value2");
            if (value1.Zero)
                return new IntBig();
            if (value2.Zero)
                return new IntBig();
            int len = value1.m_Value.Length;
            if (len > value2.m_Value.Length)
                len = value2.m_Value.Length;
            uint[] temp = new uint[len];
            BigHelper.And(value1.m_Value, value2.m_Value, temp);
            return new IntBig(temp);
        }
        /// <summary>
        /// Performs a bitwise Or operation on two values
        /// </summary>
        /// <param name="value1">The first value</param>
        /// <param name="value2">The second value</param>
        /// <returns>Result of bitwise Or operation</returns>
        public static IntBig operator |(IntBig value1, IntBig value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            if (value2 as object == null)
                throw new ArgumentNullException("value2");
            if (value1.Zero)
                return new IntBig();
            if (value2.Zero)
                return new IntBig();
            int len = value1.m_Value.Length;
            if (len > value2.m_Value.Length)
                len = value2.m_Value.Length;
            uint[] temp = new uint[len];
            BigHelper.Or(value1.m_Value, value2.m_Value, temp);
            return new IntBig(temp);
        }
        /// <summary>
        /// Performs a exclusive Or operation on two values
        /// </summary>
        /// <param name="value1">The first value</param>
        /// <param name="value2">The second value</param>
        /// <returns>Result of exclusive Or operation</returns>
        public static IntBig operator ^(IntBig value1, IntBig value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            if (value2 as object == null)
                throw new ArgumentNullException("value2");
            if (value1.Zero)
                return new IntBig();
            if (value2.Zero)
                return new IntBig();
            int len = value1.m_Value.Length;
            if (len > value2.m_Value.Length)
                len = value2.m_Value.Length;
            uint[] temp = new uint[len];
            BigHelper.ExclusiveOr(value1.m_Value, value2.m_Value, temp);
            return new IntBig(temp);
        }
        #endregion Bitwise
        #region Shifts
        /// <summary>
        /// Shifts the value to the left
        /// </summary>
        /// <param name="value">The value whose bits are to be shifted</param>
        /// <param name="shift">The number of bits to shift value to the left</param>
        /// <returns>A value that has been shifted to the left</returns>
        public static IntBig operator <<(IntBig value, int shift)
        {
            if (value as object == null)
                throw new ArgumentNullException("value");
            if (value.Zero)
                return new IntBig();
            int newLength = value.m_Value.Length + shift / 32;
            if (shift % 32 != 0)
                newLength++;
            uint[] items = new uint[newLength];
            BigHelper.LeftShift(value.m_Value, items, shift);
            return new IntBig(items, value.Negative);
        }
        /// <summary>
        /// Shifts the value a to the right
        /// </summary>
        /// <param name="value">The value whose bits are to be shifted</param>
        /// <param name="shift">The number of bits to shift value to the right</param>
        /// <returns>A value that has been shifted to the right by the specified number of bits</returns>
        public static IntBig operator >>(IntBig value, int shift)
        {
            if (value as object == null)
                throw new ArgumentNullException("value");
            int length = value.Length;
            if (value.Zero)
                return new IntBig();
            if (shift >= value.Length)
                return new IntBig();
            uint[] items = new uint[value.m_Value.Length];
            BigHelper.RightShift(value.m_Value, items, shift);
            return new IntBig(items, value.Negative);
        }
        #endregion Shifts
        #region Less
        /// <summary>
        /// Returns a value that indicates whether a IntBig value is less than another value
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left is less than right; otherwise, false</returns>
        public static bool operator <(IntBig value1, IntBig value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            return value1.CompareTo(value2) < 0;
        }
        /// <summary>
        /// Returns a value that indicates whether a IntBig value is less than another value
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left is less than right; otherwise, false</returns>
        public static bool operator <(IntBig value1, ulong value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            return value1.CompareTo(value2) < 0;
        }
        /// <summary>
        /// Returns a value that indicates whether a IntBig value is less than another value
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left is less than right; otherwise, false</returns>
        public static bool operator <(IntBig value1, long value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            return value1.CompareTo(value2) < 0;
        }
        /// <summary>
        /// Returns a value that indicates whether a IntBig value is less than another value
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left is less than right; otherwise, false</returns>
        public static bool operator <(ulong value1, IntBig value2)
        {
            if (value2 as object == null)
                throw new ArgumentNullException("value2");
            return value2.CompareTo(value1) > 0;
        }
        /// <summary>
        /// Returns a value that indicates whether a IntBig value is less than another value
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left is less than right; otherwise, false</returns>
        public static bool operator <(long value1, IntBig value2)
        {
            if (value2 as object == null)
                throw new ArgumentNullException("value2");
            return value2.CompareTo(value1) > 0;
        }
        #endregion Less
        #region Less or equal
        /// <summary>
        /// Indicates that first value is less than or equal to another value
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left is less than or equal to right; otherwise, false</returns>
        public static bool operator <=(IntBig value1, IntBig value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            return value1.CompareTo(value2) <= 0;
        }
        /// <summary>
        /// Indicates that first value is less than or equal to another value
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left is less than or equal to right; otherwise, false</returns>
        public static bool operator <=(IntBig value1, ulong value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            return value1.CompareTo(value2) <= 0;
        }
        /// <summary>
        /// Indicates that first value is less than or equal to another value
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left is less than or equal to right; otherwise, false</returns>
        public static bool operator <=(IntBig value1, long value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            return value1.CompareTo(value2) <= 0;
        }
        /// <summary>
        /// Indicates that first value is less than or equal to another value
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left is less than or equal to right; otherwise, false</returns>
        public static bool operator <=(ulong value1, IntBig value2)
        {
            if (value2 as object == null)
                throw new ArgumentNullException("value2");
            return value2.CompareTo(value1) >= 0;
        }
        /// <summary>
        /// Indicates that first value is less than or equal to another value
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left is less than or equal to right; otherwise, false</returns>
        public static bool operator <=(long value1, IntBig value2)
        {
            if (value2 as object == null)
                throw new ArgumentNullException("value2");
            return value2.CompareTo(value1) >= 0;
        }
        #endregion Less or equal
        #region Greater
        /// <summary>
        /// Returns a value that indicates whether a IntBig value is greater than another value
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left is greater than right; otherwise, false</returns>
        public static bool operator >(IntBig value1, IntBig value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            return value1.CompareTo(value2) > 0;
        }
        /// <summary>
        /// Returns a value that indicates whether a IntBig value is greater than another value
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left is greater than right; otherwise, false</returns>
        public static bool operator >(IntBig value1, ulong value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            return value1.CompareTo(value2) > 0;
        }
        /// <summary>
        /// Returns a value that indicates whether a IntBig value is greater than another value
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left is greater than right; otherwise, false</returns>
        public static bool operator >(IntBig value1, long value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            return value1.CompareTo(value2) > 0;
        }
        /// <summary>
        /// Returns a value that indicates whether a IntBig value is greater than another value
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left is greater than right; otherwise, false</returns>
        public static bool operator >(ulong value1, IntBig value2)
        {
            if (value2 as object == null)
                throw new ArgumentNullException("value2");
            return value2.CompareTo(value1) < 0;
        }
        /// <summary>
        /// Returns a value that indicates whether a IntBig value is greater than another value
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left is greater than right; otherwise, false</returns>
        public static bool operator >(long value1, IntBig value2)
        {
            if (value2 as object == null)
                throw new ArgumentNullException("value2");
            return value2.CompareTo(value1) < 0;
        }
        #endregion Greater
        #region Greater or equal
        /// <summary>
        /// Indicates that first value is greater than or equal to another value
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left is greater than or equal to right; otherwise, false</returns>
        public static bool operator >=(IntBig value1, IntBig value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            return value1.CompareTo(value2) >= 0;
        }
        /// <summary>
        /// Indicates that first value is greater than or equal to another value
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left is greater than or equal to right; otherwise, false</returns>
        public static bool operator >=(IntBig value1, ulong value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            return value1.CompareTo(value2) >= 0;
        }
        /// <summary>
        /// Indicates that first value is greater than or equal to another value
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left is greater than or equal to right; otherwise, false</returns>
        public static bool operator >=(IntBig value1, long value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            return value1.CompareTo(value2) >= 0;
        }
        /// <summary>
        /// Indicates that first value is greater than or equal to another value
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left is greater than or equal to right; otherwise, false</returns>
        public static bool operator >=(ulong value1, IntBig value2)
        {
            if (value2 as object == null)
                throw new ArgumentNullException("value2");
            return value2.CompareTo(value1) <= 0;
        }
        /// <summary>
        /// Indicates that first value is greater than or equal to another value
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left is greater than or equal to right; otherwise, false</returns>
        public static bool operator >=(long value1, IntBig value2)
        {
            if (value2 as object == null)
                throw new ArgumentNullException("value2");
            return value2.CompareTo(value1) <= 0;
        }
        #endregion Greater or equal
        #region Equal
        /// <summary>
        /// Indicates that the values are equal
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if the left and right parameters have the same value; otherwise, false</returns>
        public static bool operator ==(IntBig value1, IntBig value2)
        {
            object val1 = value1 as object;
            object val2 = value2 as object;
            if (val1 == val2)
                return true;
            // For zero reference object
            if (val1 == null)
                return false;
            if (val2 == null)
                return false;
            if (value1.m_Sign != value2.m_Sign)
                return false;
            if (value1.m_Sign == 0)
                return true;
            if (value1.Length != value2.Length)
                return false;
            if (value1.m_Value == value2.m_Value)
                return true;
            for (int i = 0; i < value1.m_Value.Length; ++i)
                if (value1.m_Value[i] != value2.m_Value[i])
                    return false;
            return true;
        }
        /// <summary>
        /// Indicates that the values are equal
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if the left and right parameters have the same value; otherwise, false</returns>
        public static bool operator ==(IntBig value1, ulong value2)
        {
            // For zero reference object
            if (value1 as object == null)
                return false;
            if (value1.m_Sign == 0)
            {
                if (value2 == 0)
                    return true;
                else
                    return false;
            }
            if (value1.m_Sign < 0)
                return false;
            if (value1.m_Value.Length > 2)
                return false;
            ulong tempItem = value1.m_Value[0];
            if (value1.m_Value.Length > 1)
                tempItem |= ((ulong)value1.m_Value[1]) << 32;
            return (tempItem == value2);
        }
        /// <summary>
        /// Indicates that the values are equal
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if the left and right parameters have the same value; otherwise, false</returns>
        public static bool operator ==(IntBig value1, long value2)
        {
            // For zero reference object
            if (value1 as object == null)
                return false;
            if (value1.m_Sign == 0)
            {
                if (value2 == 0)
                    return true;
                else
                    return false;
            }
            if (value1.m_Sign < 0)
                if (value2 > 0)
                    return false;
            if (value1.m_Sign > 0)
                if (value2 < 0)
                    return false;

            ulong tempItem = value1.m_Value[0];
            if (value1.m_Value.Length > 1)
                tempItem |= ((ulong)value1.m_Value[1]) << 32;
            ulong value2Temp = (ulong)Math.Abs(value2);
            return (tempItem == value2Temp);
        }
        /// <summary>
        /// Indicates that the values are equal
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if the left and right parameters have the same value; otherwise, false</returns>
        public static bool operator ==(ulong value1, IntBig value2)
        {
            // For zero reference object
            if (value2 as object == null)
                return false;
            if (value2.m_Sign == 0)
            {
                if (value1 == 0)
                    return true;
                else
                    return false;
            }
            if (value2.m_Sign < 0)
                return false;
            if (value1 == 0)
                return false;
            if (value2.m_Value.Length > 2)
                return false;
            uint temp = (uint)value1 >> 32;
            if (value2.m_Value.Length > 1)
            {
                if (value2.m_Value[1] != temp)
                    return false;
            }
            else
                if (temp != 0)
                    return false;
            temp = (uint)value1;
            if (value2.m_Value[0] == temp)
                return true;
            return false;
        }
        /// <summary>
        /// Indicates that the values are equal
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if the left and right parameters have the same value; otherwise, false</returns>
        public static bool operator ==(long value1, IntBig value2)
        {
            // For zero reference object
            if (value2 as object == null)
                return false;
            if (value2.m_Sign == 0)
            {
                if (value1 == 0)
                    return true;
                else
                    return false;
            }
            if (value2.m_Sign < 0)
                if (value1 > 0)
                    return false;
            if (value2.m_Sign > 0)
                if (value1 < 0)
                    return false;

            ulong tempItem = value2.m_Value[0];
            if (value2.m_Value.Length > 1)
                tempItem |= ((ulong)value2.m_Value[1]) << 32;
            ulong value2Temp = (ulong)Math.Abs(value1);
            return (tempItem == value2Temp);
        }
        #endregion Equal
        #region Not equal
        /// <summary>
        /// Indicates that two values not equal
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left and right are not equal; otherwise, false</returns>
        public static bool operator !=(IntBig value1, IntBig value2)
        {
            return !(value1 == value2);
        }
        /// <summary>
        /// Indicates that two values not equal
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left and right are not equal; otherwise, false</returns>
        public static bool operator !=(IntBig value1, ulong value2)
        {
            return !(value1 == value2);
        }
        /// <summary>
        /// Indicates that two values not equal
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left and right are not equal; otherwise, false</returns>
        public static bool operator !=(IntBig value1, long value2)
        {
            return !(value1 == value2);
        }
        /// <summary>
        /// Indicates that two values not equal
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left and right are not equal; otherwise, false</returns>
        public static bool operator !=(ulong value1, IntBig value2)
        {
            return !(value1 == value2);
        }
        /// <summary>
        /// Indicates that two values not equal
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left and right are not equal; otherwise, false</returns>
        public static bool operator !=(long value1, IntBig value2)
        {
            return !(value1 == value2);
        }
        #endregion Not equal
        #endregion Arithmetic
        #region Explicit
        public static explicit operator IntBig(long value)
        {
            return new IntBig(value);
        }
        public static explicit operator IntBig(int value)
        {
            return new IntBig((long)value);
        }
        public static explicit operator IntBig(short value)
        {
            return new IntBig((long)value);
        }
        public static explicit operator IntBig(sbyte value)
        {
            return new IntBig((long)value);
        }
        public static explicit operator IntBig(ulong value)
        {
            return new IntBig(value);
        }
        public static explicit operator IntBig(uint value)
        {
            return new IntBig((ulong)value);
        }
        public static explicit operator IntBig(ushort value)
        {
            return new IntBig((ulong)value);
        }
        public static explicit operator IntBig(byte value)
        {
            return new IntBig((ulong)value);
        }
        #endregion Explicit
        #region Other
        /// <summary>
        /// Returns a System.String that represents the current value at decimal format
        /// </summary>
        /// <returns>A System.String that represents the current value</returns>
        public override string ToString()
        {
            return BigHelper.ToString(m_Value, "D", true);
        }
        /// <summary>
        /// Formats the value using the specified format
        /// </summary>
        /// <param name="format">The System.String specifying the format to use 
        /// or string.Empty to use the default format X</param>
        /// <param name="formatProvider">The System.IFormatProvider to use to format the value or null by default</param>
        /// <returns>A System.String containing the value in the specified format</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return BigHelper.ToString(m_Value, format, true);
        }
        /// <summary>
        /// Indicates whether the current value is equal to another object
        /// </summary>
        /// <param name="obj">An object to compare with this value</param>
        /// <returns>true if the current value is equal to the other value; otherwise, false</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            IntBig obj1 = obj as IntBig;
            if (obj1 as object == null)
                return false;
            return Equals(obj1);
        }

        /// <summary>
        /// Indicates whether the current value is equal to another value
        /// </summary>
        /// <param name="other">A value to compare with this value</param>
        /// <returns>true if the current value is equal to the other value; otherwise, false</returns>
        public bool Equals(IntBig other)
        {
            // For zero reference object
            if (other as object == null)
                return false;
            if (other as object == this as object)
                return true;
            if (m_Sign != other.m_Sign)
                return false;
            if (m_Sign == 0)
                return true;
            if (Length != other.Length)
                return false;
            if (m_Value == other.m_Value)
                return true;
            for (int i = 0; i < m_Value.Length; ++i)
                if (m_Value[i] != other.m_Value[i])
                    return false;
            return true;
        }
        /// <summary>
        /// Returns the hash code for the current IntBig value
        /// </summary>
        /// <returns>A hash code for the current IntBig value</returns>
        public override int GetHashCode()
        {
            if (m_HashCalculated)
                return m_Hash;
            if (m_Value != null)
                m_Hash = BigHelper.GetHashValue(m_Value);
            m_HashCalculated = true;
            return m_Hash;
        }
        /// <summary>
        /// Compares the current value with another object.
        /// </summary>
        /// <param name="obj">An object to compare with this value</param>
        /// <returns>
        /// Zero if this value is equal to other value.
        /// 1 if value is greater than other value.
        /// -1 if the value is less than the other value/
        /// </returns>
        public int CompareTo(object obj)
        {
            IntBig obj1 = obj as IntBig;
            if (obj1 as object == null)
                throw new ArgumentException("obj is not the IntBig.");
            return CompareTo(obj1);
        }
        /// <summary>
        /// Compares the current value with another IntBig value.
        /// </summary>
        /// <param name="other">An value to compare with this value</param>
        /// <returns>
        /// Zero if this value is equal to other value.
        /// 1 if value is greater than other value.
        /// -1 if the value is less than the other value/
        /// </returns>
        public int CompareTo(IntBig other)
        {
            if (other as object == null)
                throw new ArgumentNullException("other");
            if (other as object == this as object)
                return 0;
            if (m_Sign > other.m_Sign)
                return 1;
            if (m_Sign < other.m_Sign)
                return -1;
            if (m_Sign == 0)
                return 0;
            for (int i = m_Value.Length - 1; i != -1; --i)
                if (m_Value[i] == other.m_Value[i])
                    continue;
                else
                {
                    if (m_Value[i] > other.m_Value[i])
                        return m_Sign;
                    return -1 * m_Sign;
                }
            return 0;
        }
        /// <summary>
        /// Compares the current value with another long value.
        /// </summary>
        /// <param name="other">An value to compare with this value</param>
        /// <returns>
        /// Zero if this value is equal to other value.
        /// 1 if value is greater than other value.
        /// -1 if the value is less than the other value/
        /// </returns>
        public int CompareTo(long other)
        {
            if (m_Sign == 0)
            {
                if (other > 0)
                    return -1;
                if (other < 0)
                    return 1;
                if (other == 0)
                    return 0;
            }
            if (m_Sign > 0)
                if (other <= 0)
                    return 1;
            else
                if (other >= 0)
                    return -1;
            if (m_Value.Length > 2)
            {
                for (int i = m_Value.Length - 1; i != 1; --i)
                    if (m_Value[i] != 0)
                        return m_Sign;
            }
            /*if (m_Value.Length == 2)
            {
                int temp = 
                if (m_Value[1] > other)
                    return m_Sign;
            }*/
            return 0;
        }
        /// <summary>
        /// Compares the current value with another ulong value.
        /// </summary>
        /// <param name="other">An value to compare with this value</param>
        /// <returns>
        /// Zero if this value is equal to other value.
        /// 1 if value is greater than other value.
        /// -1 if the value is less than the other value/
        /// </returns>
        public int CompareTo(ulong other)
        {
            if (m_Sign < 0)
                return -1;
            if (m_Sign == 0)
            {
                if (other > 0)
                    return -1;
                if (other == 0)
                    return 0;
            }
            if (m_Value.Length > 2)
            {
                for (int i = m_Value.Length - 1; i != 1; --i)
                    if (m_Value[i] != 0)
                        return 1;
            }
            uint temp = (uint)(other >> 32);
            if (m_Value.Length > 1)
            {
                if (m_Value[1] > temp)
                    return 1;
                if (m_Value[1] < temp)
                    return -1;
            }
            else
                if (temp != 0)
                    return -1;
            temp = (uint)other;
            if (m_Value[0] == temp)
                return 0;
            if (m_Value[0] < temp)
                return -1;
            return 1;
        }
        #endregion Other
        #endregion Events, overrides
        #endregion Methods
    }
}
#endregion Working namespace
