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
#endregion Using namespaces
#region Working namespace
namespace AIlins.Thresher
{
    /// <summary>
    /// Complex operations optimized helper
    /// </summary>
    class ComplexArrayHelper
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
        unsafe internal static Complex Summary(Complex* value, int length, int valueIndex = 0)
        {
            double returnRealValue = 0;
            double returnImaginaryValue = 0;
            double* ptrValue1 = (double*)(value + valueIndex);
            double* ptrEnd = ((double*)(value + length)) - 31;
            // Main loop, pointers for row values
            while (ptrValue1 < ptrEnd)
            {
                returnRealValue += *ptrValue1;
                returnImaginaryValue += ptrValue1[1];
                returnRealValue += ptrValue1[2];
                returnImaginaryValue += ptrValue1[3];
                returnRealValue += ptrValue1[4];
                returnImaginaryValue += ptrValue1[5];
                returnRealValue += ptrValue1[6];
                returnImaginaryValue += ptrValue1[7];
                returnRealValue += ptrValue1[8];
                returnImaginaryValue += ptrValue1[9];
                returnRealValue += ptrValue1[10];
                returnImaginaryValue += ptrValue1[11];
                returnRealValue += ptrValue1[12];
                returnImaginaryValue += ptrValue1[13];
                returnRealValue += ptrValue1[14];
                returnImaginaryValue += ptrValue1[15];
                returnRealValue += ptrValue1[16];
                returnImaginaryValue += ptrValue1[17];
                returnRealValue += ptrValue1[18];
                returnImaginaryValue += ptrValue1[19];
                returnRealValue += ptrValue1[20];
                returnImaginaryValue += ptrValue1[21];
                returnRealValue += ptrValue1[22];
                returnImaginaryValue += ptrValue1[23];
                returnRealValue += ptrValue1[24];
                returnImaginaryValue += ptrValue1[25];
                returnRealValue += ptrValue1[26];
                returnImaginaryValue += ptrValue1[27];
                returnRealValue += ptrValue1[28];
                returnImaginaryValue += ptrValue1[29];
                returnRealValue += ptrValue1[30];
                returnImaginaryValue += ptrValue1[31];
                ptrValue1 += 32;
            }
            ptrEnd += 16;
            if (ptrValue1 < ptrEnd)
            {
                returnRealValue += *ptrValue1;
                returnImaginaryValue += ptrValue1[1];
                returnRealValue += ptrValue1[2];
                returnImaginaryValue += ptrValue1[3];
                returnRealValue += ptrValue1[4];
                returnImaginaryValue += ptrValue1[5];
                returnRealValue += ptrValue1[6];
                returnImaginaryValue += ptrValue1[7];
                returnRealValue += ptrValue1[8];
                returnImaginaryValue += ptrValue1[9];
                returnRealValue += ptrValue1[10];
                returnImaginaryValue += ptrValue1[11];
                returnRealValue += ptrValue1[12];
                returnImaginaryValue += ptrValue1[13];
                returnRealValue += ptrValue1[14];
                returnImaginaryValue += ptrValue1[15];
                ptrValue1 += 16;
            }
            ptrEnd += 8;
            if (ptrValue1 < ptrEnd)
            {
                returnRealValue += *ptrValue1;
                returnImaginaryValue += ptrValue1[1];
                returnRealValue += ptrValue1[2];
                returnImaginaryValue += ptrValue1[3];
                returnRealValue += ptrValue1[4];
                returnImaginaryValue += ptrValue1[5];
                returnRealValue += ptrValue1[6];
                returnImaginaryValue += ptrValue1[7];
                ptrValue1 += 8;
            }
            ptrEnd += 4;
            if (ptrValue1 < ptrEnd)
            {
                returnRealValue += *ptrValue1;
                returnImaginaryValue += ptrValue1[1];
                returnRealValue += ptrValue1[2];
                returnImaginaryValue += ptrValue1[3];
                ptrValue1 += 4;
            }
            ptrEnd += 2;
            if (ptrValue1 < ptrEnd)
            {
                returnRealValue += *ptrValue1;
                returnImaginaryValue += ptrValue1[1];
                ptrValue1 += 2;
            }
            if (ptrValue1 == ptrEnd)
                returnRealValue += *ptrValue1;
            return new Complex(returnRealValue, returnImaginaryValue);
        }
        unsafe internal static void Multiply(Complex* value1, Complex* value2, Complex* result, int length, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            double* ptrValue1 = (double*)(value1 + value1Index);
            double* ptrValue2 = (double*)(value2 + value2Index);
            double* ptrResult = (double*)(result + resultIndex);
            double* ptrEnd = ((double*)(result + length)) - 31;
            // Main loop, pointers for row values
            while (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * *ptrValue2 - ptrValue1[1] * ptrValue2[1];
                ptrResult[1] = *ptrValue1 * ptrValue2[1] + ptrValue1[1] * *ptrValue2;
                ptrResult[2] = ptrValue1[2] * ptrValue2[2] - ptrValue1[3] * ptrValue2[3];
                ptrResult[3] = ptrValue1[2] * ptrValue2[3] + ptrValue1[3] * ptrValue2[2];
                ptrResult[4] = ptrValue1[4] * ptrValue2[4] - ptrValue1[5] * ptrValue2[5];
                ptrResult[5] = ptrValue1[4] * ptrValue2[5] + ptrValue1[5] * ptrValue2[4];
                ptrResult[6] = ptrValue1[6] * ptrValue2[6] - ptrValue1[7] * ptrValue2[7];
                ptrResult[7] = ptrValue1[6] * ptrValue2[7] + ptrValue1[7] * ptrValue2[6];
                ptrResult[8] = ptrValue1[8] * ptrValue2[8] - ptrValue1[9] * ptrValue2[9];
                ptrResult[9] = ptrValue1[8] * ptrValue2[9] + ptrValue1[9] * ptrValue2[8];
                ptrResult[10] = ptrValue1[10] * ptrValue2[10] - ptrValue1[11] * ptrValue2[11];
                ptrResult[11] = ptrValue1[10] * ptrValue2[11] + ptrValue1[11] * ptrValue2[10];
                ptrResult[12] = ptrValue1[12] * ptrValue2[12] - ptrValue1[13] * ptrValue2[13];
                ptrResult[13] = ptrValue1[12] * ptrValue2[13] + ptrValue1[13] * ptrValue2[12];
                ptrResult[14] = ptrValue1[14] * ptrValue2[14] - ptrValue1[15] * ptrValue2[15];
                ptrResult[15] = ptrValue1[14] * ptrValue2[15] + ptrValue1[15] * ptrValue2[14];
                ptrResult[16] = ptrValue1[16] * ptrValue2[16] - ptrValue1[17] * ptrValue2[17];
                ptrResult[17] = ptrValue1[16] * ptrValue2[17] + ptrValue1[17] * ptrValue2[16];
                ptrResult[18] = ptrValue1[18] * ptrValue2[18] - ptrValue1[19] * ptrValue2[19];
                ptrResult[19] = ptrValue1[18] * ptrValue2[19] + ptrValue1[19] * ptrValue2[18];
                ptrResult[20] = ptrValue1[20] * ptrValue2[20] - ptrValue1[21] * ptrValue2[21];
                ptrResult[21] = ptrValue1[20] * ptrValue2[21] + ptrValue1[21] * ptrValue2[20];
                ptrResult[22] = ptrValue1[22] * ptrValue2[22] - ptrValue1[23] * ptrValue2[23];
                ptrResult[23] = ptrValue1[22] * ptrValue2[23] + ptrValue1[23] * ptrValue2[22];
                ptrResult[24] = ptrValue1[24] * ptrValue2[24] - ptrValue1[25] * ptrValue2[25];
                ptrResult[25] = ptrValue1[24] * ptrValue2[25] + ptrValue1[25] * ptrValue2[24];
                ptrResult[26] = ptrValue1[26] * ptrValue2[26] - ptrValue1[27] * ptrValue2[27];
                ptrResult[27] = ptrValue1[26] * ptrValue2[27] + ptrValue1[27] * ptrValue2[26];
                ptrResult[28] = ptrValue1[28] * ptrValue2[28] - ptrValue1[29] * ptrValue2[29];
                ptrResult[29] = ptrValue1[28] * ptrValue2[29] + ptrValue1[29] * ptrValue2[28];
                ptrResult[30] = ptrValue1[30] * ptrValue2[30] - ptrValue1[31] * ptrValue2[31];
                ptrResult[31] = ptrValue1[30] * ptrValue2[31] + ptrValue1[31] * ptrValue2[30];
                ptrResult += 32;
                ptrValue1 += 32;
                ptrValue2 += 32;
            }
            ptrEnd += 16;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * *ptrValue2 - ptrValue1[1] * ptrValue2[1];
                ptrResult[1] = *ptrValue1 * ptrValue2[1] + ptrValue1[1] * *ptrValue2;
                ptrResult[2] = ptrValue1[2] * ptrValue2[2] - ptrValue1[3] * ptrValue2[3];
                ptrResult[3] = ptrValue1[2] * ptrValue2[3] + ptrValue1[3] * ptrValue2[2];
                ptrResult[4] = ptrValue1[4] * ptrValue2[4] - ptrValue1[5] * ptrValue2[5];
                ptrResult[5] = ptrValue1[4] * ptrValue2[5] + ptrValue1[5] * ptrValue2[4];
                ptrResult[6] = ptrValue1[6] * ptrValue2[6] - ptrValue1[7] * ptrValue2[7];
                ptrResult[7] = ptrValue1[6] * ptrValue2[7] + ptrValue1[7] * ptrValue2[6];
                ptrResult[8] = ptrValue1[8] * ptrValue2[8] - ptrValue1[9] * ptrValue2[9];
                ptrResult[9] = ptrValue1[8] * ptrValue2[9] + ptrValue1[9] * ptrValue2[8];
                ptrResult[10] = ptrValue1[10] * ptrValue2[10] - ptrValue1[11] * ptrValue2[11];
                ptrResult[11] = ptrValue1[10] * ptrValue2[11] + ptrValue1[11] * ptrValue2[10];
                ptrResult[12] = ptrValue1[12] * ptrValue2[12] - ptrValue1[13] * ptrValue2[13];
                ptrResult[13] = ptrValue1[12] * ptrValue2[13] + ptrValue1[13] * ptrValue2[12];
                ptrResult[14] = ptrValue1[14] * ptrValue2[14] - ptrValue1[15] * ptrValue2[15];
                ptrResult[15] = ptrValue1[14] * ptrValue2[15] + ptrValue1[15] * ptrValue2[14];
                ptrResult += 16;
                ptrValue1 += 16;
                ptrValue2 += 16;
            }
            ptrEnd += 8;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * *ptrValue2 - ptrValue1[1] * ptrValue2[1];
                ptrResult[1] = *ptrValue1 * ptrValue2[1] + ptrValue1[1] * *ptrValue2;
                ptrResult[2] = ptrValue1[2] * ptrValue2[2] - ptrValue1[3] * ptrValue2[3];
                ptrResult[3] = ptrValue1[2] * ptrValue2[3] + ptrValue1[3] * ptrValue2[2];
                ptrResult[4] = ptrValue1[4] * ptrValue2[4] - ptrValue1[5] * ptrValue2[5];
                ptrResult[5] = ptrValue1[4] * ptrValue2[5] + ptrValue1[5] * ptrValue2[4];
                ptrResult[6] = ptrValue1[6] * ptrValue2[6] - ptrValue1[7] * ptrValue2[7];
                ptrResult[7] = ptrValue1[6] * ptrValue2[7] + ptrValue1[7] * ptrValue2[6];
                ptrResult += 8;
                ptrValue1 += 8;
                ptrValue2 += 8;
            }
            ptrEnd += 4;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * *ptrValue2 - ptrValue1[1] * ptrValue2[1];
                ptrResult[1] = *ptrValue1 * ptrValue2[1] + ptrValue1[1] * *ptrValue2;
                ptrResult[2] = ptrValue1[2] * ptrValue2[2] - ptrValue1[3] * ptrValue2[3];
                ptrResult[3] = ptrValue1[2] * ptrValue2[3] + ptrValue1[3] * ptrValue2[2];
                ptrResult += 4;
                ptrValue1 += 4;
                ptrValue2 += 4;
            }
            ptrEnd += 2;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * *ptrValue2 - ptrValue1[1] * ptrValue2[1];
                ptrResult[1] = *ptrValue1 * ptrValue2[1] + ptrValue1[1] * *ptrValue2;
                ptrResult += 2;
                ptrValue1 += 2;
                ptrValue2 += 2;
            }
        }
        unsafe internal static void Multiply(Complex* value1, Complex value2, Complex* result, int length, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            double real = value2.Real;
            double imaginary = value2.Imaginary;
            double* ptrValue1 = (double*)(value1 + value1Index);
            double* ptrResult = (double*)(result + resultIndex);
            double* ptrEnd = (double*)(result + length) - 31;
            // Main loop, pointers for row values
            while (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * real - ptrValue1[1] * imaginary;
                ptrResult[1] = *ptrValue1 * imaginary + ptrValue1[1] * real;
                ptrResult[2] = ptrValue1[2] * real - ptrValue1[3] * imaginary;
                ptrResult[3] = ptrValue1[2] * imaginary + ptrValue1[3] * real;
                ptrResult[4] = ptrValue1[4] * real - ptrValue1[5] * imaginary;
                ptrResult[5] = ptrValue1[4] * imaginary + ptrValue1[5] * real;
                ptrResult[6] = ptrValue1[6] * real - ptrValue1[7] * imaginary;
                ptrResult[7] = ptrValue1[6] * imaginary + ptrValue1[7] * real;
                ptrResult[8] = ptrValue1[8] * real - ptrValue1[9] * imaginary;
                ptrResult[9] = ptrValue1[8] * imaginary + ptrValue1[9] * real;
                ptrResult[10] = ptrValue1[10] * real - ptrValue1[11] * imaginary;
                ptrResult[11] = ptrValue1[10] * imaginary + ptrValue1[11] * real;
                ptrResult[12] = ptrValue1[12] * real - ptrValue1[13] * imaginary;
                ptrResult[13] = ptrValue1[12] * imaginary + ptrValue1[13] * real;
                ptrResult[14] = ptrValue1[14] * real - ptrValue1[15] * imaginary;
                ptrResult[15] = ptrValue1[14] * imaginary + ptrValue1[15] * real;
                ptrResult[16] = ptrValue1[16] * real - ptrValue1[17] * imaginary;
                ptrResult[17] = ptrValue1[16] * imaginary + ptrValue1[17] * real;
                ptrResult[18] = ptrValue1[18] * real - ptrValue1[19] * imaginary;
                ptrResult[19] = ptrValue1[18] * imaginary + ptrValue1[19] * real;
                ptrResult[20] = ptrValue1[20] * real - ptrValue1[21] * imaginary;
                ptrResult[21] = ptrValue1[20] * imaginary + ptrValue1[21] * real;
                ptrResult[22] = ptrValue1[22] * real - ptrValue1[23] * imaginary;
                ptrResult[23] = ptrValue1[22] * imaginary + ptrValue1[23] * real;
                ptrResult[24] = ptrValue1[24] * real - ptrValue1[25] * imaginary;
                ptrResult[25] = ptrValue1[24] * imaginary + ptrValue1[25] * real;
                ptrResult[26] = ptrValue1[26] * real - ptrValue1[27] * imaginary;
                ptrResult[27] = ptrValue1[26] * imaginary + ptrValue1[27] * real;
                ptrResult[28] = ptrValue1[28] * real - ptrValue1[29] * imaginary;
                ptrResult[29] = ptrValue1[28] * imaginary + ptrValue1[29] * real;
                ptrResult[30] = ptrValue1[30] * real - ptrValue1[31] * imaginary;
                ptrResult[31] = ptrValue1[30] * imaginary + ptrValue1[31] * real;
                ptrResult += 32;
                ptrValue1 += 32;
            }
            ptrEnd += 16;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * real - ptrValue1[1] * imaginary;
                ptrResult[1] = *ptrValue1 * imaginary + ptrValue1[1] * real;
                ptrResult[2] = ptrValue1[2] * real - ptrValue1[3] * imaginary;
                ptrResult[3] = ptrValue1[2] * imaginary + ptrValue1[3] * real;
                ptrResult[4] = ptrValue1[4] * real - ptrValue1[5] * imaginary;
                ptrResult[5] = ptrValue1[4] * imaginary + ptrValue1[5] * real;
                ptrResult[6] = ptrValue1[6] * real - ptrValue1[7] * imaginary;
                ptrResult[7] = ptrValue1[6] * imaginary + ptrValue1[7] * real;
                ptrResult[8] = ptrValue1[8] * real - ptrValue1[9] * imaginary;
                ptrResult[9] = ptrValue1[8] * imaginary + ptrValue1[9] * real;
                ptrResult[10] = ptrValue1[10] * real - ptrValue1[11] * imaginary;
                ptrResult[11] = ptrValue1[10] * imaginary + ptrValue1[11] * real;
                ptrResult[12] = ptrValue1[12] * real - ptrValue1[13] * imaginary;
                ptrResult[13] = ptrValue1[12] * imaginary + ptrValue1[13] * real;
                ptrResult[14] = ptrValue1[14] * real - ptrValue1[15] * imaginary;
                ptrResult[15] = ptrValue1[14] * imaginary + ptrValue1[15] * real;
                ptrResult += 16;
                ptrValue1 += 16;
            }
            ptrEnd += 8;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * real - ptrValue1[1] * imaginary;
                ptrResult[1] = *ptrValue1 * imaginary + ptrValue1[1] * real;
                ptrResult[2] = ptrValue1[2] * real - ptrValue1[3] * imaginary;
                ptrResult[3] = ptrValue1[2] * imaginary + ptrValue1[3] * real;
                ptrResult[4] = ptrValue1[4] * real - ptrValue1[5] * imaginary;
                ptrResult[5] = ptrValue1[4] * imaginary + ptrValue1[5] * real;
                ptrResult[6] = ptrValue1[6] * real - ptrValue1[7] * imaginary;
                ptrResult[7] = ptrValue1[6] * imaginary + ptrValue1[7] * real;
                ptrResult += 8;
                ptrValue1 += 8;
            }
            ptrEnd += 4;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * real - ptrValue1[1] * imaginary;
                ptrResult[1] = *ptrValue1 * imaginary + ptrValue1[1] * real;
                ptrResult[2] = ptrValue1[2] * real - ptrValue1[3] * imaginary;
                ptrResult[3] = ptrValue1[2] * imaginary + ptrValue1[3] * real;
                ptrResult += 4;
                ptrValue1 += 4;
            }
            ptrEnd += 2;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * real - ptrValue1[1] * imaginary;
                ptrResult[1] = *ptrValue1 * imaginary + ptrValue1[1] * real;
                ptrResult += 2;
                ptrValue1 += 2;
            }
        }
        unsafe internal static void Division(Complex* value1, Complex* value2, Complex* result, int length, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            double* ptrValue1 = (double*)(value1 + value1Index);
            double* ptrValue2 = (double*)(value2 + value2Index);
            double* ptrResult = (double*)(result + resultIndex);
            double* ptrEnd = ptrResult + length * 2 - 31;
            // Main loop, pointers for row values
            while (ptrResult < ptrEnd)
            {
                ComplexDivision(ptrValue1, ptrValue2, ptrResult);
                ComplexDivision(ptrValue1 + 2, ptrValue2 + 2, ptrResult + 2);
                ComplexDivision(ptrValue1 + 4, ptrValue2 + 4, ptrResult + 4);
                ComplexDivision(ptrValue1 + 6, ptrValue2 + 6, ptrResult + 6);
                ComplexDivision(ptrValue1 + 8, ptrValue2 + 8, ptrResult + 8);
                ComplexDivision(ptrValue1 + 10, ptrValue2 + 10, ptrResult + 10);
                ComplexDivision(ptrValue1 + 12, ptrValue2 + 12, ptrResult + 12);
                ComplexDivision(ptrValue1 + 14, ptrValue2 + 14, ptrResult + 14);
                ComplexDivision(ptrValue1 + 16, ptrValue2 + 16, ptrResult + 16);
                ComplexDivision(ptrValue1 + 18, ptrValue2 + 18, ptrResult + 18);
                ComplexDivision(ptrValue1 + 20, ptrValue2 + 20, ptrResult + 20);
                ComplexDivision(ptrValue1 + 22, ptrValue2 + 22, ptrResult + 22);
                ComplexDivision(ptrValue1 + 24, ptrValue2 + 24, ptrResult + 24);
                ComplexDivision(ptrValue1 + 26, ptrValue2 + 26, ptrResult + 26);
                ComplexDivision(ptrValue1 + 28, ptrValue2 + 28, ptrResult + 28);
                ComplexDivision(ptrValue1 + 30, ptrValue2 + 30, ptrResult + 30);
                ptrResult += 32;
                ptrValue1 += 32;
                ptrValue2 += 32;
            }
            ptrEnd += 16;
            if (ptrResult < ptrEnd)
            {
                ComplexDivision(ptrValue1, ptrValue2, ptrResult);
                ComplexDivision(ptrValue1 + 2, ptrValue2 + 2, ptrResult + 2);
                ComplexDivision(ptrValue1 + 4, ptrValue2 + 4, ptrResult + 4);
                ComplexDivision(ptrValue1 + 6, ptrValue2 + 6, ptrResult + 6);
                ComplexDivision(ptrValue1 + 8, ptrValue2 + 8, ptrResult + 8);
                ComplexDivision(ptrValue1 + 10, ptrValue2 + 10, ptrResult + 10);
                ComplexDivision(ptrValue1 + 12, ptrValue2 + 12, ptrResult + 12);
                ComplexDivision(ptrValue1 + 14, ptrValue2 + 14, ptrResult + 14);
                ptrResult += 16;
                ptrValue1 += 16;
                ptrValue2 += 16;
            }
            ptrEnd += 8;
            if (ptrResult < ptrEnd)
            {
                ComplexDivision(ptrValue1, ptrValue2, ptrResult);
                ComplexDivision(ptrValue1 + 2, ptrValue2 + 2, ptrResult + 2);
                ComplexDivision(ptrValue1 + 4, ptrValue2 + 4, ptrResult + 4);
                ComplexDivision(ptrValue1 + 6, ptrValue2 + 6, ptrResult + 6);
                ptrResult += 8;
                ptrValue1 += 8;
                ptrValue2 += 8;
            }
            ptrEnd += 4;
            if (ptrResult < ptrEnd)
            {
                ComplexDivision(ptrValue1, ptrValue2, ptrResult);
                ComplexDivision(ptrValue1 + 2, ptrValue2 + 2, ptrResult + 2);
                ptrResult += 4;
                ptrValue1 += 4;
                ptrValue2 += 4;
            }
            ptrEnd += 2;
            if (ptrResult < ptrEnd)
            {
                ComplexDivision(ptrValue1, ptrValue2, ptrResult);
                ptrResult += 2;
                ptrValue1 += 2;
                ptrValue2 += 2;
            }
        }
        unsafe internal static void Conjugate(Complex* value, Complex* result, int length, int valueIndex = 0, int resultIndex = 0)
        {
            double* ptrValue = (double*)(value + valueIndex);
            double* ptrResult = (double*)(result + resultIndex);
            double* ptrEnd = ptrResult + length * 2 - 31;
            // Main loop, pointers for row values
            while (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue;
                *(ptrResult + 1) = -*(ptrValue + 1);
                *(ptrResult + 2) = *(ptrValue + 2);
                *(ptrResult + 3) = -*(ptrValue + 3);
                *(ptrResult + 4) = *(ptrValue + 4);
                *(ptrResult + 5) = -*(ptrValue + 5);
                *(ptrResult + 6) = *(ptrValue + 6);
                *(ptrResult + 7) = -*(ptrValue + 7);
                *(ptrResult + 8) = *(ptrValue + 8);
                *(ptrResult + 9) = -*(ptrValue + 9);
                *(ptrResult + 10) = *(ptrValue + 10);
                *(ptrResult + 11) = -*(ptrValue + 11);
                *(ptrResult + 12) = *(ptrValue + 12);
                *(ptrResult + 13) = -*(ptrValue + 13);
                *(ptrResult + 14) = *(ptrValue + 14);
                *(ptrResult + 15) = -*(ptrValue + 15);
                *(ptrResult + 16) = *(ptrValue + 16);
                *(ptrResult + 17) = -*(ptrValue + 17);
                *(ptrResult + 18) = *(ptrValue + 18);
                *(ptrResult + 19) = -*(ptrValue + 19);
                *(ptrResult + 20) = *(ptrValue + 20);
                *(ptrResult + 21) = -*(ptrValue + 21);
                *(ptrResult + 22) = *(ptrValue + 22);
                *(ptrResult + 23) = -*(ptrValue + 23);
                *(ptrResult + 24) = *(ptrValue + 24);
                *(ptrResult + 25) = -*(ptrValue + 25);
                *(ptrResult + 26) = *(ptrValue + 26);
                *(ptrResult + 27) = -*(ptrValue + 27);
                *(ptrResult + 28) = *(ptrValue + 28);
                *(ptrResult + 29) = -*(ptrValue + 29);
                *(ptrResult + 30) = *(ptrValue + 30);
                *(ptrResult + 31) = -*(ptrValue + 31);
                ptrResult += 32;
                ptrValue += 32;
            }
            ptrEnd += 16;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue;
                *(ptrResult + 1) = -*(ptrValue + 1);
                *(ptrResult + 2) = *(ptrValue + 2);
                *(ptrResult + 3) = -*(ptrValue + 3);
                *(ptrResult + 4) = *(ptrValue + 4);
                *(ptrResult + 5) = -*(ptrValue + 5);
                *(ptrResult + 6) = *(ptrValue + 6);
                *(ptrResult + 7) = -*(ptrValue + 7);
                *(ptrResult + 8) = *(ptrValue + 8);
                *(ptrResult + 9) = -*(ptrValue + 9);
                *(ptrResult + 10) = *(ptrValue + 10);
                *(ptrResult + 11) = -*(ptrValue + 11);
                *(ptrResult + 12) = *(ptrValue + 12);
                *(ptrResult + 13) = -*(ptrValue + 13);
                *(ptrResult + 14) = *(ptrValue + 14);
                *(ptrResult + 15) = -*(ptrValue + 15);
                ptrResult += 16;
                ptrValue += 16;
            }
            ptrEnd += 8;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue;
                *(ptrResult + 1) = -*(ptrValue + 1);
                *(ptrResult + 2) = *(ptrValue + 2);
                *(ptrResult + 3) = -*(ptrValue + 3);
                *(ptrResult + 4) = *(ptrValue + 4);
                *(ptrResult + 5) = -*(ptrValue + 5);
                *(ptrResult + 6) = *(ptrValue + 6);
                *(ptrResult + 7) = -*(ptrValue + 7);
                ptrResult += 8;
                ptrValue += 8;
            }
            ptrEnd += 4;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue;
                *(ptrResult + 1) = -*(ptrValue + 1);
                *(ptrResult + 2) = *(ptrValue + 2);
                *(ptrResult + 3) = -*(ptrValue + 3);
                ptrResult += 4;
                ptrValue += 4;
            }
            ptrEnd += 2;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue;
                *(ptrResult + 1) = -*(ptrValue + 1);
                ptrResult += 2;
                ptrValue += 2;
            }
        }
        unsafe internal static void Inverse(Complex* value, Complex* result, int length, int valueIndex = 0, int resultIndex = 0)
        {
            double* ptrValue = (double*)(value + valueIndex);
            double* ptrResult = (double*)(result + resultIndex);
            double* ptrEnd = ptrResult + length * 2 - 31;
            // Main loop, pointers for row values
            while (ptrResult < ptrEnd)
            {
                ComplexInverse(ptrValue, ptrResult);
                ComplexInverse(ptrValue + 2, ptrResult + 2);
                ComplexInverse(ptrValue + 4, ptrResult + 4);
                ComplexInverse(ptrValue + 6, ptrResult + 6);
                ComplexInverse(ptrValue + 8, ptrResult + 8);
                ComplexInverse(ptrValue + 10, ptrResult + 10);
                ComplexInverse(ptrValue + 12, ptrResult + 12);
                ComplexInverse(ptrValue + 14, ptrResult + 14);
                ComplexInverse(ptrValue + 16, ptrResult + 16);
                ComplexInverse(ptrValue + 18, ptrResult + 18);
                ComplexInverse(ptrValue + 20, ptrResult + 20);
                ComplexInverse(ptrValue + 22, ptrResult + 22);
                ComplexInverse(ptrValue + 24, ptrResult + 24);
                ComplexInverse(ptrValue + 26, ptrResult + 26);
                ComplexInverse(ptrValue + 28, ptrResult + 28);
                ComplexInverse(ptrValue + 30, ptrResult + 30);
                ptrResult += 32;
                ptrValue += 32;
            }
            ptrEnd += 16;
            if (ptrResult < ptrEnd)
            {
                ComplexInverse(ptrValue, ptrResult);
                ComplexInverse(ptrValue + 2, ptrResult + 2);
                ComplexInverse(ptrValue + 4, ptrResult + 4);
                ComplexInverse(ptrValue + 6, ptrResult + 6);
                ComplexInverse(ptrValue + 8, ptrResult + 8);
                ComplexInverse(ptrValue + 10, ptrResult + 10);
                ComplexInverse(ptrValue + 12, ptrResult + 12);
                ComplexInverse(ptrValue + 14, ptrResult + 14);
                ptrResult += 16;
                ptrValue += 16;
            }
            ptrEnd += 8;
            if (ptrResult < ptrEnd)
            {
                ComplexInverse(ptrValue, ptrResult);
                ComplexInverse(ptrValue + 2, ptrResult + 2);
                ComplexInverse(ptrValue + 4, ptrResult + 4);
                ComplexInverse(ptrValue + 6, ptrResult + 6);
                ptrResult += 8;
                ptrValue += 8;
            }
            ptrEnd += 4;
            if (ptrResult < ptrEnd)
            {
                ComplexInverse(ptrValue, ptrResult);
                ComplexInverse(ptrValue + 2, ptrResult + 2);
                ptrResult += 4;
                ptrValue += 4;
            }
            ptrEnd += 2;
            if (ptrResult < ptrEnd)
            {
                ComplexInverse(ptrValue, ptrResult);
                ptrResult += 2;
                ptrValue += 2;
            }
        }
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
        #endregion Private methods
        #region Events, overrides
        #endregion Events, overrides
        #endregion Methods
    }
}
#endregion Working namespace