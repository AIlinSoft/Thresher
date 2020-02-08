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
using System.Runtime.InteropServices;
#endregion Using namespaces
#region Working namespace
namespace AIlins.Thresher
{
    /// <summary>
    /// Represents a big modulo integer.
    /// </summary>
    [Serializable, StructLayout(LayoutKind.Sequential), ComVisible(true)]
    public class MIntBig : IComparable, IFormattable, IComparable<MIntBig>, IEquatable<MIntBig>, IComparable<IntBig>, IEquatable<IntBig>
    {
        #region Classes, structures, enums
        #endregion Classes, structures, enums
        #region Constructors
        /// <summary>
        /// Static constructor
        /// </summary>
        static MIntBig()
        {
            m_Modules = new Dictionary<IntBig, IntBig>();
        }
        /// <summary>
        /// Initializes a new instance of the value using the values in a uint arrays
        /// </summary>
        /// <param name="value">An array of uint values in little-endian order</param>
        /// <param name="modulo">An array of uint values in little-endian order</param>
        internal MIntBig(uint[] value, uint[] modulo)
        {
            int length = (value.Length > modulo.Length) ? value.Length : modulo.Length;
            length *= 32;
            m_Value = new IntBig(value);
            IntBig moduloTemp = new IntBig(modulo);
            IntBig temp;
            if (m_Modules.TryGetValue(moduloTemp, out temp))
                m_Modulo = temp;
            else
            {
                m_Modules.Add(moduloTemp, moduloTemp);
                m_Modulo = moduloTemp;
            }
            m_MaxModuloBitIndex = m_Modulo.Length - 1;
        }
        /// <summary>
        /// Initializes a new instance of the value using the IntBig values
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="modulo">The modulo</param>
        internal MIntBig(IntBig value, IntBig modulo)
        {
            if (value < modulo)
                m_Value = value;
            else
                m_Value = value % modulo;
            IntBig temp;
            if (m_Modules.TryGetValue(modulo, out temp))
                m_Modulo = temp;
            else
            {
                m_Modules.Add(modulo, modulo);
                m_Modulo = modulo;
            }
            m_MaxModuloBitIndex = m_Modulo.Length - 1;
            
        }
        /// <summary>
        /// Initializes a new instance of the value using the ulong value and the modulo in a uint array
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="modulo">An array of uint values in little-endian order</param>
        internal MIntBig(ulong value, uint[] modulo)
        {
            m_Value = new IntBig(value);
            IntBig moduloTemp = new IntBig(modulo);
            IntBig temp;
            if (m_Modules.TryGetValue(moduloTemp, out temp))
                m_Modulo = temp;
            else
            {
                m_Modules.Add(moduloTemp, moduloTemp);
                m_Modulo = moduloTemp;
            }
            m_MaxModuloBitIndex = m_Modulo.Length - 1;
        }
        #endregion Constructors
        #region Variables
        /// <summary>
        /// Modulo of big integer
        /// </summary>
        internal IntBig m_Modulo;
        /// <summary>
        /// Value of big integer
        /// </summary>
        internal IntBig m_Value;
        internal uint[] m_BurrettConstant;
        /// <summary>
        /// Max not zero bit index in modulo number
        /// </summary>
        internal int m_MaxModuloBitIndex;
        /// <summary>
        /// Cache of modulo values
        /// </summary>
        private static Dictionary<IntBig, IntBig> m_Modules;
        #endregion Variables
        #region Fields
        /// <summary>
        /// If zero
        /// </summary>
        /// <returns></returns>
        public bool Zero
        {
            get
            {
                return m_Value.Zero;
            }
        }
        /// <summary>
        /// Value
        /// </summary>
        /// <returns></returns>
        public IntBig Value
        {
            get
            {
                return m_Value;
            }
        }
        /// <summary>
        /// Modulo
        /// </summary>
        /// <returns></returns>
        public IntBig Modulo
        {
            get
            {
                return m_Modulo;
            }
        }        
        #endregion Fields
        #region Methods
        #region Public methods
        #region New
        /// <summary>
        /// Initializes a new instance of the MIntBig value using string representation
        /// </summary>
        /// <param name="value">Value in x mod y view</param>
        /// <param name="littleEndian">true if value represents as little-Endian</param>
        public static MIntBig Parse(string value, bool littleEndian)
        {
            string[] items = value.Split(new string[] { "mod", "MOD" }, StringSplitOptions.RemoveEmptyEntries);
            if (items == null || items.Length < 2)
                throw new Exception("Unknown format. Please change format to x mod y view.");
            return new MIntBig(IntBig.Parse(items[0], littleEndian), IntBig.Parse(items[1], littleEndian));
        }
        /// <summary>
        /// Initializes a new instance of the MIntBig value using value and modulo strings
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="modulo">Modulo</param>
        /// <param name="littleEndian">true if value represents as little-Endian</param>
        public static MIntBig Parse(string value, string modulo, bool littleEndian)
        {
            return new MIntBig(IntBig.Parse(value, littleEndian), IntBig.Parse(modulo, littleEndian));
        }
        /// <summary>
        /// Initializes a new instance of the MIntBig value using IntBig value
        /// </summary>
        /// <param name="value">IntBig value</param>
        /// <param name="modulo">Modulo of value</param>
        public static MIntBig Parse(IntBig value, IntBig modulo)
        {
            return new MIntBig(value, modulo);
        }
        /// <summary>
        /// Initializes a new instance of the MIntBig value using ulong value
        /// </summary>
        /// <param name="value">ulong value</param>
        /// <param name="modulo">Modulo of value</param>
        public static MIntBig Parse(ulong value, IntBig modulo)
        {
            return new MIntBig(value, modulo.m_Value);
        }
        /// <summary>
        /// Parse the byte array
        /// </summary>
        /// <param name="value">Value array</param>
        /// <param name="modulo">Modulo value</param>
        public static MIntBig Parse(byte[] value, IntBig modulo)
        {
            IntBig value1 = IntBig.Parse(value, true);
            return new MIntBig(value1, modulo);
        }
        #endregion New
        #region Other
        /// <summary>
        /// Converts the value to its equivalent string representation by using the specified format
        /// </summary>
        /// <param name="value"></param>
        /// <param name="format">A standard or custom numeric format string</param>
        /// <param name="littleEndian">true if value must be represents as little-Endian</param>
        /// <returns></returns>
        public static string ToString(MIntBig value, string format, bool littleEndian)
        {
            return BigHelper.ToString(value.m_Value.m_Value, format, littleEndian) + " mod " + BigHelper.ToString(value.m_Modulo.m_Value, format, littleEndian);
        }
        #endregion Other
        #region Pow
        /// <summary>
        /// Raises value to the power of a specified value
        /// </summary>
        /// <param name="value">The number to raise to the exponent power</param>
        /// <param name="degree">The exponent to raise value by</param>
        /// <returns>The result of raising value to the exponent power</returns>
        public static MIntBig Pow(MIntBig value, int degree)
        {
            if (value as object == null)
                throw new ArgumentNullException("value");
            if (value.Zero)
                return new MIntBig(value.m_Value, value.m_Modulo);
            return new MIntBig(new IntBig(ModuloOperations.Pow(value.m_Value.m_Value, value.m_Modulo.m_Value, degree)), value.m_Modulo);
        }
        #endregion Pow
        #endregion Public methods
        #region Internal methods
        #endregion Internal methods
        #region Private methods
        #endregion Private methods
        #region  Events, overrides
        #region Arithmetic
        #region Subtract
        /// <summary>
        /// Subtracts a value from another value
        /// </summary>
        /// <param name="value1">The value to subtract from</param>
        /// <param name="value2">The value to subtract</param>
        /// <returns>The result of subtracting</returns>
        public static MIntBig operator -(MIntBig value1, MIntBig value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            if (value2 as object == null)
                throw new ArgumentNullException("value2");
            if (value1.m_Modulo != value2.m_Modulo)
                throw new Exception("Modules not equal!");
            uint[] items = new uint[value1.m_Modulo.m_Value.Length];
            ModuloOperations.Substraction(value1.m_Value.m_Value, value2.m_Value.m_Value, value1.m_Modulo.m_Value, items);
            return new MIntBig(new IntBig(items), value1.m_Modulo);
        }
        /// <summary>
        /// Decrements value
        /// </summary>
        /// <param name="value1">The value to decrement</param>
        /// <returns>Decremented value</returns>
        public static MIntBig operator --(MIntBig value)
        {
            if (value as object == null)
                throw new ArgumentNullException("value");
            uint[] items = new uint[value.m_Modulo.m_Value.Length];
            ModuloOperations.Substraction(value.m_Value.m_Value, 1, value.m_Modulo.m_Value, items);
            return new MIntBig(new IntBig(items), value.m_Modulo);
        }
        /// <summary>
        /// Negates a specified value
        /// </summary>
        /// <remarks>
        /// Substracting the value from the modulo
        /// </remarks>
        /// <param name="value">The value to negate</param>
        /// <returns>The result of the negate operation</returns>
        public static MIntBig operator -(MIntBig value)
        {
            if (value as object == null)
                throw new ArgumentNullException("value");
            uint[] items = new uint[value.m_Modulo.m_Value.Length];
            ModuloOperations.ChangeSign(value.m_Value.m_Value, value.m_Modulo.m_Value, items);
            return new MIntBig(new IntBig(items), value.m_Modulo);
        }
        #endregion Subtract
        #region Addition
        /// <summary>
        /// Adds the values
        /// </summary>
        /// <param name="value1">The first value to add</param>
        /// <param name="value2">The second value to add</param>
        /// <returns>The sum of values</returns>
        public static MIntBig operator +(MIntBig value1, MIntBig value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            if (value2 as object == null)
                throw new ArgumentNullException("value2");
            if (value1.m_Modulo != value2.m_Modulo)
                throw new Exception("Modules not equal!");
            uint[] items = new uint[value1.m_Modulo.m_Value.Length];
            ModuloOperations.Addition(value1.m_Value.m_Value, value2.m_Value.m_Value, value1.m_Modulo.m_Value, items);
            return new MIntBig(new IntBig(items), value1.m_Modulo);
        }
        /// <summary>
        ///  Increments the value
        /// </summary>
        /// <param name="value">The value to increment</param>
        /// <returns>Incremented value</returns>
        public static MIntBig operator ++(MIntBig value)
        {
            if (value as object == null)
                throw new ArgumentNullException("value");
            uint[] items = new uint[value.m_Modulo.m_Value.Length];
            ModuloOperations.Addition(value.m_Value.m_Value, 1, value.m_Modulo.m_Value, items);
            return new MIntBig(new IntBig(items), value.m_Modulo);
        }
        #endregion Addition
        #region Multiply
        /// <summary>
        /// Multiplies two values
        /// </summary>
        /// <param name="value1">First multiplier</param>
        /// <param name="value2">Second multiplier</param>
        /// <returns>Result value</returns>
        public static MIntBig operator *(MIntBig value1, MIntBig value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            if (value2 as object == null)
                throw new ArgumentNullException("value2");
            if (value1.m_Modulo != value2.m_Modulo)
                throw new Exception("Modules not equal!");
            uint[] items = new uint[value1.m_Modulo.m_Value.Length];
            ModuloOperations.Multiply(value1.m_Value.m_Value, value2.m_Value.m_Value, value1.m_Modulo.m_Value, items);
            return new MIntBig(new IntBig(items), value1.m_Modulo);
        }
        #endregion Multiply
        #region Devide
        /// <summary>
        /// Divides the value by another value
        /// </summary>
        /// <param name="value1">The value to be divided</param>
        /// <param name="value2">The value to divide by</param>
        /// <returns>The integral result of the division</returns>
        public static MIntBig operator /(MIntBig value1, MIntBig value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            if (value2 as object == null)
                throw new ArgumentNullException("value2");
            if (value1.m_Modulo != value2.m_Modulo)
                throw new Exception("Modules not equal!");
            if (value2.Zero)
                throw new DivideByZeroException("value2");
            uint[] items = new uint[value1.m_Modulo.m_Value.Length];
            ModuloOperations.Divide(value1.m_Value.m_Value, value2.m_Value.m_Value, value1.m_Modulo.m_Value, items);
            return new MIntBig(new IntBig(items), value1.m_Modulo);
        }
        /// <summary>
        /// Returns the remainder that results from division with two values
        /// </summary>
        /// <param name="value1">The value to be divided</param>
        /// <param name="value2">The value to divide by</param>
        /// <returns>The remainder that results from the division</returns>
        public static MIntBig operator %(MIntBig value1, MIntBig value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            if (value2 as object == null)
                throw new ArgumentNullException("value2");
            if (value1.m_Modulo != value2.m_Modulo)
                throw new Exception("Modules not equal!");
            if (value2.Zero)
                throw new DivideByZeroException("value2");
            return new MIntBig(value1.m_Value % value2.m_Value, value1.m_Modulo);
        }
        /// <summary>
        /// Invert
        /// </summary>
        /// <remarks>
        /// value^(-1)
        /// </remarks>
        /// <param name="value">The value to invert</param>
        /// <returns>The result of the invert</returns>
        public static MIntBig operator ~(MIntBig value)
        {
            if (value as object == null)
                throw new ArgumentNullException("value");
            if (value.Zero)
                throw new DivideByZeroException("value");
            uint[] items = new uint[value.m_Modulo.m_Value.Length];
            ModuloOperations.Invert(value.m_Value.m_Value, value.m_Modulo.m_Value, items);
            return new MIntBig(new IntBig(items), value.m_Modulo);
        }
        #endregion Devide
        #region Shifts
        /// <summary>
        /// Shifts the value to the left
        /// </summary>
        /// <param name="value">The value whose bits are to be shifted</param>
        /// <param name="shift">The number of bits to shift value to the left</param>
        /// <returns>A value that has been shifted to the left</returns>
        public static MIntBig operator <<(MIntBig value, int shift)
        {
            if (value as object == null)
                throw new ArgumentNullException("value");
            shift %= value.m_Value.Length;
            if (shift < 0)
                shift += value.m_Value.Length;
            if (!value.Zero && shift != 0)
            {
                uint[] items = new uint[value.m_Value.m_Value.Length];
                uint[] cache = new uint[value.m_Value.m_Value.Length*2];
                ModuloOperations.LeftShift(value.m_Value.m_Value, items, value.m_Modulo.m_Value, cache, shift);
                return new MIntBig(new IntBig(items), value.m_Modulo);
            }
            else
                return new MIntBig(value.m_Value, value.m_Modulo);
        }
        /// <summary>
        /// Shifts the value a to the right
        /// </summary>
        /// <param name="value">The value whose bits are to be shifted</param>
        /// <param name="shift">The number of bits to shift value to the right</param>
        /// <returns>A value that has been shifted to the right by the specified number of bits</returns>
        public static MIntBig operator >>(MIntBig value, int shift)
        {
            if (value as object == null)
                throw new ArgumentNullException("value");
            shift %= value.m_Value.Length;
            if (shift < 0)
                shift += value.m_Value.Length;
            if (!value.Zero && shift != 0)
            {
                uint[] items = new uint[value.m_Value.m_Value.Length];
                uint[] cache = new uint[value.m_Value.m_Value.Length*2];
                ModuloOperations.RightShift(value.m_Value.m_Value, items, value.m_Modulo.m_Value, cache, shift);
                return new MIntBig(new IntBig(items), value.m_Modulo);
            }
            else
                return new MIntBig(value.m_Value, value.m_Modulo);
        }
        #endregion Shifts
        #region Less
        /// <summary>
        /// Returns a value that indicates whether a MIntBig value is less than another value
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left is less than right; otherwise, false</returns>
        public static bool operator <(MIntBig value1, MIntBig value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            return value1.CompareTo(value2) < 0;
        }
        #endregion Less
        #region Less or equal
        /// <summary>
        /// Indicates that first value is less than or equal to another value
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left is less than or equal to right; otherwise, false</returns>
        public static bool operator <=(MIntBig value1, MIntBig value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            return value1.CompareTo(value2) <= 0;
        }
        #endregion Less or equal
        #region Greater
        /// <summary>
        /// Returns a value that indicates whether a MIntBig value is greater than another value
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left is greater than right; otherwise, false</returns>
        public static bool operator >(MIntBig value1, MIntBig value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            return value1.CompareTo(value2) > 0;
        }
        #endregion Greater
        #region Greater or equal
        /// <summary>
        /// Indicates that first value is greater than or equal to another value
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left is greater than or equal to right; otherwise, false</returns>
        public static bool operator >=(MIntBig value1, MIntBig value2)
        {
            if (value1 as object == null)
                throw new ArgumentNullException("value1");
            return value1.CompareTo(value2) >= 0;
        }
        #endregion Greater or equal
        #region Equal
        /// <summary>
        /// Indicates that the values are equal
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if the left and right parameters have the same value; otherwise, false</returns>
        public static bool operator ==(MIntBig value1, MIntBig value2)
        {
            // For zero reference object
            if (value1 as object == null)
            {
                //object.ReferenceEquals
                if (value2 as object == null)
                    return true;
                else
                    return false;
            }
            if (value2 as object == null)
                return false;

            if (!value1.m_Modulo.Equals(value2.m_Modulo))
                return false;
            return value1.m_Value.Equals(value2.m_Value);
        }
        #endregion Equal
        #region Not equal
        /// <summary>
        /// Indicates that two values not equal
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if left and right are not equal; otherwise, false</returns>
        public static bool operator !=(MIntBig value1, MIntBig value2)
        {
            return !(value1 == value2);
        }
        #endregion Not equal
        #endregion Arithmetic
        #region Explicit
        public static explicit operator MIntBig(IntBig[] value)
        {
            if (value.Length != 2)
                throw new Exception("Value length is not 2!");
            return Parse(value[0], value[1]);
        }
        public static explicit operator IntBig(MIntBig value)
        {
            return value.m_Value;
        }
        #endregion Explicit
        #region Other
        /// <summary>
        /// Indicates whether the current value is equal to another object
        /// </summary>
        /// <param name="obj">An object to compare with this value</param>
        /// <returns>true if the current value is equal to the other value; otherwise, false</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            MIntBig obj1 = obj as MIntBig;
            if (obj1 == null)
                return false;
            return Equals(obj1);
        }
        /// <summary>
        /// Indicates whether the current value is equal to another value
        /// </summary>
        /// <param name="other">A value to compare with this value</param>
        /// <returns>true if the current value is equal to the other value; otherwise, false</returns>
        public bool Equals(MIntBig obj)
        {
            if (obj as object == null)
                return false;
            if (obj as object == this as object)
                return true;
            if (!m_Modulo.Equals(obj.m_Modulo))
                return false;
            return m_Value.Equals(obj.m_Value);
        }
        /// <summary>
        /// Indicates whether the current value is equal to another IntBig value
        /// </summary>
        /// <param name="other">A value to compare with this value</param>
        /// <returns>true if the current value is equal to the other value; otherwise, false</returns>
        public bool Equals(IntBig obj)
        {
            if (obj as object == null)
                return false;
            if (obj as object == m_Value as object)
                return true;
            IntBig temp = obj % m_Modulo;
            return m_Value.Equals(temp);
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
            return CompareTo(obj1);
        }
        /// <summary>
        /// Compares the current value with another value
        /// </summary>
        /// <param name="obj">An object to compare with this value</param>
        /// <returns>
        /// Zero if this value is equal to other value.
        /// 1 if value is greater than other value.
        /// -1 if the value is less than the other value/
        /// </returns>
        public int CompareTo(MIntBig other)
        {
            if (other as object == null)
                throw new ArgumentNullException("other");
            if (other as object == this as object)
                return 0;
            if (m_Modulo != other.m_Modulo)
                throw new Exception("Modules not equal!");
            return m_Value.CompareTo(other.m_Value);
        }
        /// <summary>
        /// Compares the current value with another IntBig value
        /// </summary>
        /// <param name="obj">An object to compare with this value</param>
        /// <returns>
        /// Zero if this value is equal to other value.
        /// 1 if value is greater than other value.
        /// -1 if the value is less than the other value/
        /// </returns>
        public int CompareTo(IntBig other)
        {
            if (other as object == null)
                throw new ArgumentNullException("other");
            if (other as object == m_Value as object)
                return 0;
            IntBig temp = other % m_Modulo;
            return m_Value.CompareTo(temp);
        }       
        /// <summary>
        /// Returns the hash code for the current MIntBig value
        /// </summary>
        /// <returns>A hash code for the current MIntBig value</returns>
        public override int GetHashCode()
        {
            return m_Value.GetHashCode() + m_Modulo.GetHashCode();
        }
        /// <summary>
        /// Returns a System.String that represents the current value
        /// </summary>
        /// <returns>A System.String that represents the current value</returns>
        public override string ToString()
        {
            return ToString(this, "X", true);
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
            return ToString(this, format, true);
        }
        #endregion Other
        #endregion Events, overrides
        #endregion Methods
    }
}
#endregion Working namespace