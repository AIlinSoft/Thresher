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
#region Working namespace
namespace AIlins.Thresher
{
    /// <summary>
    /// Represents the interface for standartization different elliptic curve maths
    /// </summary>
    public interface IEllipticCurvePoint
    {
        /// <summary>
        /// Doubling the point in elliptic curve
        /// </summary>
        /// <returns></returns>
        IEllipticCurvePoint Doubling();
        /// <summary>
        /// Adds the this value with another value in elliptic curve
        /// </summary>
        /// <param name="value">The value to add with this value</param>
        /// <returns>The sum of values</returns>
        IEllipticCurvePoint Addition(IEllipticCurvePoint value);
        /// <summary>
        /// Multiplies the this value at IntBig value
        /// </summary>
        /// <param name="value">IntBig multiplier</param>
        /// <returns>Result of operation</returns>
        IEllipticCurvePoint Multiply(IntBig value);
        /// <summary>
        /// Invert this value at elliptic curve
        /// </summary>
        /// <returns></returns>
        IEllipticCurvePoint Invert();
        /// <summary>
        /// Get the infinity point
        /// </summary>
        /// <returns>Infinity point</returns>
        IEllipticCurvePoint GetInfinity();
        /// <summary>
        /// Equal this value with another value in elliptic curve
        /// </summary>
        /// <param name="obj">The value to equal with this value</param>
        /// <returns>The resalt of operation</returns>
        bool Equals(IEllipticCurvePoint obj);
        /// <summary>
        /// Is infinity
        /// </summary>
        bool Infinity { get; }
        /// <summary>
        /// X affine coordinate of point
        /// </summary>
        IntBig x { get; }
        /// <summary>
        /// Y affine coordinate of point
        /// </summary>
        IntBig y { get; }
    }
}
#endregion Working namespace
