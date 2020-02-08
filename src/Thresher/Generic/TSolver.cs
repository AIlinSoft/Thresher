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
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion Using namespaces
#region Working namespace
namespace AIlins.Thresher
{
    public abstract class Solver<T>
    {
        #region Classes, structures, enums
        #endregion Classes, structures, enums
        #region Constructors
        #endregion Constructors
        #region Variables
        #endregion Variables
        #region Fields
        #endregion Fields
        #region Methods
        #region Public methods
        /// <summary>
        /// Adds two numbers and returns the result
        /// </summary>
        /// <param name="value1">The first number to add</param>
        /// <param name="value2">The second number to add</param>
        /// <returns>The sum of <paramref name="value1"/> and <paramref name="value2"/></returns>
        public abstract T Addition(T value1, T value2);
        /// <summary>
        /// Subtracts one number from another and returns the result
        /// </summary>
        /// <param name="value1">The value to subtract from (the minuend)</param>
        /// <param name="value2">The value to subtract (the subtrahend)</param>
        /// <returns>The result of subtracting <paramref name="value2"/> from <paramref name="value1"/></returns>
        public abstract T Substraction(T value1, T value2);
        /// <summary>
        /// Returns the additive inverse of the number
        /// </summary>
        /// <param name="value">A number to negate</param>
        /// <returns>The result of the negating of the <paramref name="value"/></returns>
        public abstract T Negation(T value);
        /// <summary>
        /// Returns the product of two numbers
        /// </summary>
        /// <param name="value1">The first number to multiply</param>
        /// <param name="value2">The second number to multiply</param>
        /// <returns>The product of the <paramref name="value1"/> and <paramref name="value2"/> parameters</returns>
        public abstract T Multiply(T value1, T value2);
        /// <summary>
        /// Divides one number by another and returns the result
        /// </summary>
        /// <param name="value1">The number to be divided</param>
        /// <param name="value2">The number to divide by</param>
        /// <returns>The quotient of the division</returns>
        public abstract T Division(T value1, T value2);
        /// <summary>
        /// Returns the multiplicative inverse of the number
        /// </summary>
        /// <param name="value">A number to inverse</param>
        /// <returns>The result of the invert of the <paramref name="value"/></returns>
        public abstract T Inversion(T value);
        /// <summary>
        /// Returns a value that indicates whether two numbers are equal
        /// </summary>
        /// <param name="value1">The first number to compare</param>
        /// <param name="value2">The second number to compare</param>
        /// <returns>true if the parameters have the same value; otherwise, false</returns>
        public abstract bool Equality(T value1, T value2);
        /// <summary>
        /// Returns a value that indicates whether two numbers are not equal
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns>true if the parameters are not equal; otherwise, false</returns>
        public abstract bool Inequality(T value1, T value2);
        /// <summary>
        /// Converts the string representation of a number to its <typeparamref name="T"/> equivalent. A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="value">The number string representation</param>
        /// <param name="provider">An object that supplies culture-specific formatting information</param>
        /// <param name="result">Result of conversion</param>
        /// <returns>true if conversion successed; otherwise, false</returns>
        public abstract bool TryParse(string value, IFormatProvider provider, out T result);
        /// <summary>
        /// Converts bytes array to <typeparamref name="T"/> value. A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="value">The number in byte array</param>
        /// <param name="valueIndex">The number beginning</param>
        /// <param name="result">Result of conversion</param>
        /// <returns>true if conversion successed; otherwise, false</returns>
        public abstract bool TryConvert(byte[] value, int valueIndex, out T result);
        /// <summary>
        /// Convert value from another value with type <typeparamref name="K"/>
        /// </summary>
        /// <typeparam name="K">Type of value to convert</typeparam>
        /// <param name="value">Value to convert</param>
        /// <returns>Converted value</returns>
        public abstract T From<K>(K value);
        #endregion Public methods
        #region Internal methods
        #endregion Internal methods
        #region Private methods
        #endregion Private methods
        #region  Events, overrides
        #endregion Events, overrides
        #endregion Methods
    }
}
#endregion Working namespace