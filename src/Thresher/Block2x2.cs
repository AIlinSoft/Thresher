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
    /// <summary>
    /// Real matrix 2x2
    /// https://en.wikipedia.org/wiki/2_×_2_real_matrices
    /// </summary>
    public struct Block2x2: IFormattable
    {
        #region Classes, structures, enums
        #endregion Classes, structures, enums
        #region Constructors
        static Block2x2()
        {
            Unit = new Block2x2(1, 0, 0, 1);
        }
        public Block2x2(double a00, double a01, double a10, double a11)
        {
            f00 = a00;
            f01 = a01;
            f10 = a10;
            f11 = a11;
        }
        #endregion Constructors
        #region Variables
        public double f00;
        public double f01;
        public double f10;
        public double f11;
        #endregion Variables
        #region Fields
        public static Block2x2 Unit { get; private set; }
        public double Determinant
        {
            get
            {
                return f00 * f11 - f01 * f10;
            }
        }
        public Block2x2 Inverse
        {
            get
            {
                double temp = 1 / (f00 * f11 - f01 * f10);
                return new Block2x2(f11 * temp, -f01 * temp, -f10 * temp, f00 * temp);
            }
        }
        #endregion Fields
        #region Methods
        #region Public methods
        public double ConditionNumber()
        {
            double norm = Norm();
            double inverseNorm = Inverse.Norm();
            return norm * inverseNorm;
        }
        public double Norm()
        {
            double res = Math.Abs(f00) + Math.Abs(f10);
            if (res < Math.Abs(f11) + Math.Abs(f01))
                res = Math.Abs(f11) + Math.Abs(f01);
            return res;
        }
        #endregion Public methods
        #region Internal methods
        #endregion Internal methods
        #region Private methods
        #endregion Private methods
        #region  Events, overrides
        /// <summary>
        /// Unary addition
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Block2x2 operator +(Block2x2 value)
        {
            return value;
        }
        /// <summary>
        /// Negate
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Block2x2 operator -(Block2x2 value)
        {
            return new Block2x2(-value.f00, -value.f01, -value.f10, -value.f11);
        }

        /// <summary>
        /// Addition
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static Block2x2 operator +(Block2x2 value1, Block2x2 value2)
        {
            return new Block2x2(value1.f00 + value2.f00, value1.f01 + value2.f01, value1.f10 + value2.f10, value1.f11 + value2.f11);
        }
        /// <summary>
        /// Substraction
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static Block2x2 operator -(Block2x2 value1, Block2x2 value2)
        {
            return new Block2x2(value1.f00 - value2.f00, value1.f01 - value2.f01, value1.f10 - value2.f10, value1.f11 - value2.f11);
        }
        /// <summary>
        /// Multiply
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        public static Block2x2 operator *(Block2x2 value1, Block2x2 value2)
        {
            return new Block2x2(value1.f00 * value2.f00 + value1.f01 * value2.f10, value1.f00 * value2.f01 + value1.f01 * value2.f11, value1.f10 * value2.f00 + value1.f11 * value2.f10, value1.f10 * value2.f01 + value1.f11 * value2.f11);
        }
        public static Block2x2 operator /(Block2x2 value1, Block2x2 value2)
        {
            return value1 * value2.Inverse;
        }
        public static bool operator ==(Block2x2 value1, Block2x2 value2)
        {
            if (value2.f00 == value1.f00 && value2.f01 == value1.f01 && value2.f10 == value1.f10 && value2.f11 == value1.f11)
                return true;
            else
                return false;
        }
        public static bool operator !=(Block2x2 value1, Block2x2 value2)
        {
            if (value2.f00 == value1.f00 && value2.f01 == value1.f01 && value2.f10 == value1.f10 && value2.f11 == value1.f11)
                return false;
            else
                return true;
        }
        public override bool Equals(object obj)
        {
            return obj is Block2x2 && this == (Block2x2)obj;
        }
        public override int GetHashCode()
        {
            return f00.GetHashCode() + f01.GetHashCode() + f10.GetHashCode() + f11.GetHashCode();
        }
        public override string ToString()
        {
            return string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0};{1};{2};{3}", f00, f01, f10, f11);
        }
        /// <summary>Converts the value of the current Block2x2 number to its equivalent string representation by using the specified culture-specific formatting information.</summary>
        /// <returns>The string representation of the current instance, as specified by <paramref name="provider" />.</returns>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        public string ToString(string format, IFormatProvider provider)
        {
            return string.Format(provider, "{0};{1};{2};{3}", f00.ToString(format, provider), f01.ToString(format, provider), f10.ToString(format, provider), f11.ToString(format, provider));
	    }
        public static implicit operator Block2x2(double value)
        {
            return new Block2x2(value, 0, 0, value);
        }
        public static implicit operator Block2x2(System.Numerics.Complex value)
        {
            return new Block2x2(value.Real, -value.Imaginary, value.Imaginary, value.Real);
        }
        public static implicit operator System.Numerics.Complex(Block2x2 value)
        {
            return new System.Numerics.Complex(value.f00, value.f10);
        }
        #endregion Events, overrides
        #endregion Methods
    }
}
#endregion Working namespace