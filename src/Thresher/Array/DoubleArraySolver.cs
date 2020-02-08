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
using System.Linq;
using System.Text;
using System.Numerics;
using Th = AIlins.Thresher.ThrowHelper<double>;
#endregion Using namespaces
#region Working namespace
namespace AIlins.Thresher
{
    /// <summary>
    /// Array group operations optimized helper
    /// </summary>
    public class DoubleArraySolver : ArraySolver<double>
    {
        #region Classes, structures, enumerators
        #endregion Classes, structures, enumerators
        #region Constructors
        #endregion Constructors
        #region Variables
        #endregion Variables
        #region Fields
        #endregion Fields
        #region Methods
        #region Public methods
        #endregion Public methods
        #region Internal methods
        #endregion Internal methods
        #region Private methods
        unsafe private static void ComplexDivision(double* ptrValue1, double* ptrValue2, double* ptrResult)
        {
            double real1 = *ptrValue1;
            double imaginary1 = *(ptrValue1 + 1);
            double real2 = *ptrValue2;
            double imaginary2 = *(ptrValue2 + 1);
            double temp1, temp2;
            if (Math.Abs(imaginary2) < Math.Abs(real2))
            {
                temp1 = imaginary2 / real2;
                temp2 = real2 + imaginary2 * temp1;
                *ptrResult = (real1 + imaginary1 * temp1) / temp2;
                *(ptrResult + 1) = (imaginary1 - real1 * temp1) / temp2;
                return;
            }
            temp1 = real2 / imaginary2;
            temp2 = imaginary2 + real2 * temp1;
            *ptrResult = (imaginary1 + real1 * temp1) / temp2;
            *(ptrResult + 1) = (-real1 + imaginary1 * temp1) / temp2;
        }
        unsafe private static void ComplexInverse(double* ptrValue, double* ptrResult)
        {
            double real = *ptrValue;
            double imaginary = *(ptrValue + 1);
            double div = real * real + imaginary * imaginary;
            *ptrResult = real / div;
            *(ptrResult + 1) = -imaginary / div;
        }
        unsafe private static void Block2x2Inverse(double* ptrValue, double* ptrResult)
        {
            double f00 = *ptrValue;
            double f01 = *(ptrValue + 1);
            double f10 = *(ptrValue + 2);
            double f11 = *(ptrValue + 3);
            double div = 1/(f00 * f11 - f01 * f10);
            *ptrResult = f11 * div;
            *(ptrResult + 1) = -f01 * div;
            *(ptrResult + 2) = -f10 * div;
            *(ptrResult + 3) = f00 * div;
        }
        unsafe private static void Block2x2Division(double* ptrValue1, double* ptrValue2, double* ptrResult)
        {
            double f00 = *ptrValue2;
            double f01 = *(ptrValue2 + 1);
            double temp = *(ptrValue2 + 2) / f00;
            double diag = 1 / (*(ptrValue2 + 3) - f01 * temp);
            double r10 = (*(ptrValue1 + 2) - *ptrValue1 * temp) * diag;
            double r11 = (*(ptrValue1 + 3) - *(ptrValue1 + 1) * temp) * diag;
            *ptrResult = (*ptrValue1 - r10 * f01) / f00;
            *(ptrResult + 1) = (*(ptrValue1 + 1) - r11 * f01) / f00;
            *(ptrResult + 2) = r10;
            *(ptrResult + 3) = r11;
        }
        #endregion Private methods
        #region Events, overrides
        /// <summary>
        /// Addition of two arrays
        /// </summary>
        /// <param name="value1">The first array to addition</param>
        /// <param name="value2">The second value to addition</param>
        /// <param name="result">The result of arrays addition</param>
        /// <param name="length">A 32-bit integer that represents the number of elements to addition</param>
        /// <param name="value1Index">A 32-bit integer that represents the index in the <paramref name="value1"/> array at which addition begins</param>
        /// <param name="value2Index">A 32-bit integer that represents the index in the <paramref name="value2"/> array at which addition begins</param>
        /// <param name="resultIndex">A 32-bit integer that represents the index in the <paramref name="result"/> array at which copying result begins</param>
        /// <remarks>If the <paramref name="result"/> array is null, operation result copying to the <paramref name="value1"/></remarks>
        unsafe public override void Addition(double[] value1, double[] value2, double[] result = null, int length = int.MaxValue, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            Th.ThrowIfTwoValuesWithNullableResult(value1, value2, ref result, ref length, value1Index, value2Index, resultIndex);
            fixed (double* value1Ptr = value1, value2Ptr = value2, resultPtr = result)
                Addition((double*)value1Ptr, (double*)value2Ptr, (double*)resultPtr, length, value1Index, value2Index, resultIndex);
        }
        /// <summary>
        /// Adds the number <paramref name="value2"/> and the elements of array <paramref name="value1"/>
        /// </summary>
        /// <param name="value1">The array to addition</param>
        /// <param name="value2">The number, which will be addition with <paramref name="value1"/> array</param>
        /// <param name="result">The result of addition</param>
        /// <param name="length">A 32-bit integer that represents the number of elements to addition</param>
        /// <param name="value1Index">A 32-bit integer that represents the index in the <paramref name="value1"/> array at which addition begins</param>
        /// <param name="value2Index">A 32-bit integer that represents the index in the <paramref name="value2"/> array at which addition begins</param>
        /// <param name="resultIndex">A 32-bit integer that represents the index in the <paramref name="result"/> array at which copying result begins</param>
        /// <remarks>If the <paramref name="result"/> array is null, operation result copying to the <paramref name="value1"/></remarks>
        unsafe public override void Addition(double[] value1, double value2, double[] result = null, int length = int.MaxValue, int value1Index = 0, int resultIndex = 0)
        {
            Th.ThrowOneValueWithNullableResult(value1, ref result, ref length, value1Index, resultIndex);
            fixed (double* value1Ptr = value1, resultPtr = result)
                Addition((double*)value1Ptr, value2, (double*)resultPtr, length, value1Index, resultIndex);
        }
        /// <summary>
        /// Summarizes the elements of the array <paramref name="value"/>
        /// </summary>
        /// <param name="value">The array to summariez</param>
        /// <param name="length">A 32-bit integer that represents the number of elements to summariez</param>
        /// <param name="valueIndex">A 32-bit integer that represents the index in the <paramref name="value"/> array at which summariez begins</param>
        /// <returns>Result of the elements summariez</returns>
        unsafe public override double Summary(double[] value, int length = int.MaxValue, int valueIndex = 0)
        {
            Th.ThrowIfOneValue(value, ref length, valueIndex);
            double returnValue = 0;
            fixed (double* valuePtr = value)
                returnValue = Summary(valuePtr, length, valueIndex);
            return returnValue;
        }
        /// <summary>
        /// Substraction second array from first
        /// </summary>
        /// <param name="value1">The minuend array</param>
        /// <param name="value2">The subtrahend array</param>
        /// <param name="result">The difference of arrays substraction</param>
        /// <param name="length">A 32-bit integer that represents the number of elements to substraction</param>
        /// <param name="value1Index">A 32-bit integer that represents the index in the <paramref name="value1"/> array at which substraction begins</param>
        /// <param name="value2Index">A 32-bit integer that represents the index in the <paramref name="value2"/> array at which substraction begins</param>
        /// <param name="resultIndex">A 32-bit integer that represents the index in the <paramref name="result"/> array at which copying result begins</param>
        /// <remarks>If the <paramref name="result"/> array is null, operation result copying to the <paramref name="value1"/></remarks>
        unsafe public override void Substraction(double[] value1, double[] value2, double[] result = null, int length = int.MaxValue, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            Th.ThrowIfTwoValuesWithNullableResult(value1, value2, ref result, ref length, value1Index, value2Index, resultIndex);
            fixed (double* value1Ptr = value1, value2Ptr = value2, resultPtr = result)
                Substraction((double*)value1Ptr, (double*)value2Ptr, (double*)resultPtr, length, value1Index, value2Index, resultIndex);
        }
        /// <summary>
        /// Negates the elements of the array <paramref name="value"/>
        /// </summary>
        /// <param name="value">The array to negates</param>
        /// <param name="result">The result of negates</param>
        /// <param name="length">A 32-bit integer that represents the number of elements to negates</param>
        /// <param name="valueIndex">A 32-bit integer that represents the index in the <paramref name="value"/> array at which negates begins</param>
        /// <param name="resultIndex">A 32-bit integer that represents the index in the <paramref name="result"/> array at which copying result begins</param>
        /// <remarks>If the <paramref name="result"/> array is null, operation result copying to the <paramref name="value1"/></remarks>
        unsafe public override void Negation(double[] value, double[] result = null, int length = int.MaxValue, int valueIndex = 0, int resultIndex = 0)
        {
            Th.ThrowOneValueWithNullableResult(value, ref result, ref length, valueIndex, resultIndex);
            fixed (double* valuePtr = value, resultPtr = result)
                Negate(valuePtr, resultPtr, length, valueIndex, resultIndex);
        }
        /// <summary>
        /// Multiplies elements of two arrays
        /// </summary>
        /// <param name="value1">The first array to multiply</param>
        /// <param name="value2">The second value to multiply</param>
        /// <param name="result">The result of arrays multiply</param>
        /// <param name="length">A 32-bit integer that represents the number of elements to multiply</param>
        /// <param name="value1Index">A 32-bit integer that represents the index in the <paramref name="value1"/> array at which multiply begins</param>
        /// <param name="value2Index">A 32-bit integer that represents the index in the <paramref name="value2"/> array at which multiply begins</param>
        /// <param name="resultIndex">A 32-bit integer that represents the index in the <paramref name="result"/> array at which copying result begins</param>
        /// <remarks>If the <paramref name="result"/> array is null, operation result copying to the <paramref name="value1"/></remarks>
        unsafe public override void Multiply(double[] value1, double[] value2, double[] result = null, int length = int.MaxValue, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            Th.ThrowIfTwoValuesWithNullableResult(value1, value2, ref result, ref length, value1Index, value2Index, resultIndex);
            fixed (double* value1Ptr = value1, value2Ptr = value2, resultPtr = result)
                Multiply(value1Ptr, value2Ptr, resultPtr, length, value1Index, value2Index, resultIndex);
        }
        /// <summary>
        /// Multiplies the elements of array <paramref name="value1"/> to the <paramref name="value2"/>
        /// </summary>
        /// <param name="value1">The array to multiply</param>
        /// <param name="value2">The number, which will be multiply to the <paramref name="value1"/> array</param>
        /// <param name="result">The result of multiply</param>
        /// <param name="length">A 32-bit integer that represents the number of elements to multiply</param>
        /// <param name="value1Index">A 32-bit integer that represents the index in the <paramref name="value1"/> array at which multiply begins</param>
        /// <param name="resultIndex">A 32-bit integer that represents the index in the <paramref name="result"/> array at which copying result begins</param>
        /// <remarks>If the <paramref name="result"/> array is null, operation result copying to the <paramref name="value1"/></remarks>
        unsafe public override void Multiply(double[] value1, double value2, double[] result = null, int length = int.MaxValue, int value1Index = 0, int resultIndex = 0)
        {
            Th.ThrowOneValueWithNullableResult(value1, ref result, ref length, value1Index, resultIndex);
            fixed (double* value1Ptr = value1, resultPtr = result)
                Multiply(value1Ptr, value2, resultPtr, length, value1Index, resultIndex);
        }
        /// <summary>
        /// Division the elements of array <paramref name="value1"/> by elements of the array <paramref name="value2"/>
        /// </summary>
        /// <param name="value1">The dividend array</param>
        /// <param name="value2">The divisor array</param>
        /// <param name="result">The result of division</param>
        /// <param name="length">A 32-bit integer that represents the number of elements to division</param>
        /// <param name="value1Index">A 32-bit integer that represents the index in the <paramref name="value1"/> array at which division begins</param>
        /// <param name="value2Index">A 32-bit integer that represents the index in the <paramref name="value2"/> array at which division begins</param>
        /// <param name="resultIndex">A 32-bit integer that represents the index in the <paramref name="result"/> array at which copying result begins</param>
        /// <remarks>If the <paramref name="result"/> array is null, operation result copying to the <paramref name="value1"/></remarks>
        unsafe public override void Division(double[] value1, double[] value2, double[] result = null, int length = int.MaxValue, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            Th.ThrowIfTwoValuesWithNullableResult(value1, value2, ref result, ref length, value1Index, value2Index, resultIndex);
            fixed (double* value1Ptr = value1, value2Ptr = value2, resultPtr = result)
                Division(value1Ptr, value2Ptr, resultPtr, length, value1Index, value2Index, resultIndex);
        }
        /// <summary>
        /// Invert the elements of array <paramref name="value"/>/>
        /// </summary>
        /// <param name="value">The array will be invert</param>
        /// <param name="result">The result of inverting</param>
        /// <param name="length">A 32-bit integer that represents the number of elements to invert</param>
        /// <param name="valueIndex">A 32-bit integer that represents the index in the <paramref name="value"/> array at which inverting begins</param>
        /// <param name="resultIndex">A 32-bit integer that represents the index in the <paramref name="result"/> array at which copying result begins</param>
        /// <remarks>If the <paramref name="result"/> array is null, operation result copying to the <paramref name="value1"/></remarks>
        unsafe public override void Inversion(double[] value, double[] result = null, int length = int.MaxValue, int valueIndex = 0, int resultIndex = 0)
        {
            Th.ThrowOneValueWithNullableResult(value, ref result, ref length, valueIndex, resultIndex);
            fixed (double* valuePtr = value, resultPtr = result)
                Inverse(valuePtr, resultPtr, length, valueIndex, resultIndex);
        }
        /// <summary>
        /// Convert from <typeparamref name="K"/> array to <typeparamref name="T"/>
        /// </summary>
        /// <param name="value">The value will be convert</param>
        /// <param name="result">The result of arrays conversion</param>
        /// <param name="length">A 32-bit integer that represents the number of elements to conversion</param>
        /// <param name="valueIndex">A 32-bit integer that represents the index in the <paramref name="value"/> array at which conversion begins</param>
        /// <param name="resultIndex">A 32-bit integer that represents the index in the <paramref name="result"/> array at which conversion begins</param>
        unsafe public override void From<K>(K[] value, double[] result, int length = int.MaxValue, int valueIndex = 0, int resultIndex = 0)
        {
            Th.ThrowOneValueWithoutNullableResult<K>(value, result, ref length, valueIndex, resultIndex);
            if (typeof(K) == typeof(double))
            {
                double[] doubleValue = value as double[];
                fixed (double* valuePtr = doubleValue)
                fixed (double* resultPtr = result)
                {
                    double* valuePtr1 = valuePtr + valueIndex;
                    double* resultPtr1 = resultPtr + resultIndex;
                    for (int i = 0; i < length; ++i)
                        resultPtr1[i] = valuePtr1[i];
                }
            }
            else
                if (typeof(K) == typeof(Complex))
                {
                    Complex[] complexValue = value as Complex[];
                    fixed (Complex* valuePtr = complexValue)
                    fixed (double* resultPtr = result)
                    {
                        double* valuePtr1 = (double*)(valuePtr + valueIndex);
                        double* resultPtr1 = (double*)(resultPtr + resultIndex);
                        for (int i = 0, j = 0; i < length; ++i, j += 2)
                            resultPtr1[i] = valuePtr1[j];
                    }
                }
                else
                    if (typeof(K) == typeof(Block2x2))
                    {
                        Block2x2[] block2x2Value = value as Block2x2[];
                        fixed (Block2x2* valuePtr = block2x2Value)
                        fixed (double* resultPtr = result)
                        {
                            double* valuePtr1 = (double*)(valuePtr + valueIndex);
                            double* resultPtr1 = (double*)(resultPtr + resultIndex);
                            for (int i = 0, j = 0; i < length; ++i, j += 4)
                                resultPtr1[i] = valuePtr1[j];
                        }
                    }
                    else
                        base.From<K>(value, result, length, valueIndex, resultIndex);
        }
        /// <summary>
        /// Write the <paramref name="value2"/> to the elements of array <paramref name="value"/>/>
        /// </summary>
        /// <param name="value1">The array in which value will be written</param>
        /// <param name="value2">The value which will be written</param>
        /// <param name="length">A 32-bit integer that represents the number of elements to write</param>
        /// <param name="value1Index">A 32-bit integer that represents the index in the <paramref name="value"/> array at which writing begins</param>
        unsafe public override void Set(double[] value1, double value2 = default(double), int length = int.MaxValue, int value1Index = 0)
        {
            Th.ThrowIfOneValue(value1, ref length, value1Index);
            int end = value1Index + length;
            fixed (double* valuePtr = value1)
                for (; value1Index < end; ++value1Index)
                    valuePtr[value1Index] = value2;
        }
        /// <summary>
        /// Comparison of two arrays
        /// </summary>
        /// <param name="value1">The first array to comparison</param>
        /// <param name="value2">The second array to comparison</param>
        /// <param name="length">A 32-bit integer that represents the number of elements to comparison</param>
        /// <param name="value1Index">A 32-bit integer that represents the index in the <paramref name="value1"/> array at which comparison begins</param>
        /// <param name="value2Index">A 32-bit integer that represents the index in the <paramref name="value2"/> array at which comparison begins</param>
        unsafe public override bool Equality(double[] value1, double[] value2, int length = int.MaxValue, int value1Index = 0, int value2Index = 0)
        {
            Th.ThrowIfTwoValues(value1, value2, ref length, value1Index, value2Index);
            bool returnValue;
            fixed (double* value1Ptr = value1, value2Ptr = value2)
                returnValue = Equal(value1Ptr, value2Ptr, length, value1Index, value2Index);
            return returnValue;
        }
        #endregion Events, overrides
        #endregion Methods
    }
}
#endregion Working namespace