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
    /// Block2x2 operations optimized helper
    /// </summary>
    class Block2x2ArrayHelper
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
        unsafe internal static Block2x2 Summary(Block2x2* value, int length, int valueIndex = 0)
        {
            double f00 = 0, f01 = 0, f10 = 0, f11 = 0;
            double* ptrValue1 = (double*)(value + valueIndex);
            double* ptrEnd = ((double*)(value + length)) - 31;
            // Main loop, pointers for row values
            while (ptrValue1 < ptrEnd)
            {
                f00 += *ptrValue1;
                f01 += ptrValue1[1];
                f10 += ptrValue1[2];
                f11 += ptrValue1[3];
                f00 += ptrValue1[4];
                f01 += ptrValue1[5];
                f10 += ptrValue1[6];
                f11 += ptrValue1[7];
                f00 += ptrValue1[8];
                f01 += ptrValue1[9];
                f10 += ptrValue1[10];
                f11 += ptrValue1[11];
                f00 += ptrValue1[12];
                f01 += ptrValue1[13];
                f10 += ptrValue1[14];
                f11 += ptrValue1[15];
                f00 += ptrValue1[16];
                f01 += ptrValue1[17];
                f10 += ptrValue1[18];
                f11 += ptrValue1[19];
                f00 += ptrValue1[20];
                f01 += ptrValue1[21];
                f10 += ptrValue1[22];
                f11 += ptrValue1[23];
                f00 += ptrValue1[24];
                f01 += ptrValue1[25];
                f10 += ptrValue1[26];
                f11 += ptrValue1[27];
                f00 += ptrValue1[28];
                f01 += ptrValue1[29];
                f10 += ptrValue1[30];
                f11 += ptrValue1[31];
                ptrValue1 += 32;
            }
            ptrEnd += 16;
            if (ptrValue1 < ptrEnd)
            {
                f00 += *ptrValue1;
                f01 += ptrValue1[1];
                f10 += ptrValue1[2];
                f11 += ptrValue1[3];
                f00 += ptrValue1[4];
                f01 += ptrValue1[5];
                f10 += ptrValue1[6];
                f11 += ptrValue1[7];
                f00 += ptrValue1[8];
                f01 += ptrValue1[9];
                f10 += ptrValue1[10];
                f11 += ptrValue1[11];
                f00 += ptrValue1[12];
                f01 += ptrValue1[13];
                f10 += ptrValue1[14];
                f11 += ptrValue1[15];
                ptrValue1 += 16;
            }
            ptrEnd += 8;
            if (ptrValue1 < ptrEnd)
            {
                f00 += *ptrValue1;
                f01 += ptrValue1[1];
                f10 += ptrValue1[2];
                f11 += ptrValue1[3];
                f00 += ptrValue1[4];
                f01 += ptrValue1[5];
                f10 += ptrValue1[6];
                f11 += ptrValue1[7];
                ptrValue1 += 8;
            }
            ptrEnd += 4;
            if (ptrValue1 < ptrEnd)
            {
                f00 += *ptrValue1;
                f01 += ptrValue1[1];
                f10 += ptrValue1[2];
                f11 += ptrValue1[3];
                ptrValue1 += 4;
            }
            ptrEnd += 2;
            if (ptrValue1 < ptrEnd)
            {
                f00 += *ptrValue1;
                f01 += ptrValue1[1];
                ptrValue1 += 2;
            }
            if (ptrValue1 == ptrEnd)
                f00 += *ptrValue1;
            return new Block2x2(f00, f01, f10, f11);
        }
        unsafe internal static void Multiply(Block2x2* value1, Block2x2* value2, Block2x2* result, int length, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            double* ptrValue1 = (double*)(value1 + value1Index);
            double* ptrValue2 = (double*)(value2 + value2Index);
            double* ptrResult = (double*)(result + resultIndex);
            double* ptrEnd = ((double*)(result + length)) - 31;
            // Main loop, pointers for row values
            while (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * *ptrValue2 + ptrValue1[1] * ptrValue2[2];
                ptrResult[1] = *ptrValue1 * ptrValue2[1] + ptrValue1[1] * ptrValue2[3];
                ptrResult[2] = ptrValue1[2] * *ptrValue2 + ptrValue1[3] * ptrValue2[2];
                ptrResult[3] = ptrValue1[2] * ptrValue2[1] + ptrValue1[3] * ptrValue2[3];
                ptrResult[4] = ptrValue1[4] * ptrValue2[4] + ptrValue1[5] * ptrValue2[6];
                ptrResult[5] = ptrValue1[4] * ptrValue2[5] + ptrValue1[5] * ptrValue2[7];
                ptrResult[6] = ptrValue1[6] * ptrValue2[4] + ptrValue1[7] * ptrValue2[6];
                ptrResult[7] = ptrValue1[6] * ptrValue2[5] + ptrValue1[7] * ptrValue2[7];
                ptrResult[8] = ptrValue1[8] * ptrValue2[8] + ptrValue1[9] * ptrValue2[10];
                ptrResult[9] = ptrValue1[8] * ptrValue2[9] + ptrValue1[9] * ptrValue2[11];
                ptrResult[10] = ptrValue1[10] * ptrValue2[8] + ptrValue1[11] * ptrValue2[10];
                ptrResult[11] = ptrValue1[10] * ptrValue2[9] + ptrValue1[11] * ptrValue2[11];
                ptrResult[12] = ptrValue1[12] * ptrValue2[12] + ptrValue1[13] * ptrValue2[14];
                ptrResult[13] = ptrValue1[12] * ptrValue2[13] + ptrValue1[13] * ptrValue2[15];
                ptrResult[14] = ptrValue1[14] * ptrValue2[12] + ptrValue1[15] * ptrValue2[14];
                ptrResult[15] = ptrValue1[14] * ptrValue2[13] + ptrValue1[15] * ptrValue2[15];
                ptrResult[16] = ptrValue1[16] * ptrValue2[16] + ptrValue1[17] * ptrValue2[18];
                ptrResult[17] = ptrValue1[16] * ptrValue2[17] + ptrValue1[17] * ptrValue2[19];
                ptrResult[18] = ptrValue1[18] * ptrValue2[16] + ptrValue1[19] * ptrValue2[18];
                ptrResult[19] = ptrValue1[18] * ptrValue2[17] + ptrValue1[19] * ptrValue2[19];
                ptrResult[20] = ptrValue1[20] * ptrValue2[20] + ptrValue1[21] * ptrValue2[22];
                ptrResult[21] = ptrValue1[20] * ptrValue2[21] + ptrValue1[21] * ptrValue2[23];
                ptrResult[22] = ptrValue1[22] * ptrValue2[20] + ptrValue1[23] * ptrValue2[22];
                ptrResult[23] = ptrValue1[22] * ptrValue2[21] + ptrValue1[23] * ptrValue2[23];
                ptrResult[24] = ptrValue1[24] * ptrValue2[24] + ptrValue1[25] * ptrValue2[26];
                ptrResult[25] = ptrValue1[24] * ptrValue2[25] + ptrValue1[25] * ptrValue2[27];
                ptrResult[26] = ptrValue1[26] * ptrValue2[24] + ptrValue1[27] * ptrValue2[26];
                ptrResult[27] = ptrValue1[26] * ptrValue2[25] + ptrValue1[27] * ptrValue2[27];
                ptrResult[28] = ptrValue1[28] * ptrValue2[28] + ptrValue1[29] * ptrValue2[30];
                ptrResult[29] = ptrValue1[28] * ptrValue2[29] + ptrValue1[29] * ptrValue2[31];
                ptrResult[30] = ptrValue1[30] * ptrValue2[28] + ptrValue1[31] * ptrValue2[30];
                ptrResult[31] = ptrValue1[30] * ptrValue2[29] + ptrValue1[31] * ptrValue2[31];
                ptrResult += 32;
                ptrValue1 += 32;
                ptrValue2 += 32;
            }
            ptrEnd += 16;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * *ptrValue2 + ptrValue1[1] * ptrValue2[2];
                ptrResult[1] = *ptrValue1 * ptrValue2[1] + ptrValue1[1] * ptrValue2[3];
                ptrResult[2] = ptrValue1[2] * *ptrValue2 + ptrValue1[3] * ptrValue2[2];
                ptrResult[3] = ptrValue1[2] * ptrValue2[1] + ptrValue1[3] * ptrValue2[3];
                ptrResult[4] = ptrValue1[4] * ptrValue2[4] + ptrValue1[5] * ptrValue2[6];
                ptrResult[5] = ptrValue1[4] * ptrValue2[5] + ptrValue1[5] * ptrValue2[7];
                ptrResult[6] = ptrValue1[6] * ptrValue2[4] + ptrValue1[7] * ptrValue2[6];
                ptrResult[7] = ptrValue1[6] * ptrValue2[5] + ptrValue1[7] * ptrValue2[7];
                ptrResult[8] = ptrValue1[8] * ptrValue2[8] + ptrValue1[9] * ptrValue2[10];
                ptrResult[9] = ptrValue1[8] * ptrValue2[9] + ptrValue1[9] * ptrValue2[11];
                ptrResult[10] = ptrValue1[10] * ptrValue2[8] + ptrValue1[11] * ptrValue2[10];
                ptrResult[11] = ptrValue1[10] * ptrValue2[9] + ptrValue1[11] * ptrValue2[11];
                ptrResult[12] = ptrValue1[12] * ptrValue2[12] + ptrValue1[13] * ptrValue2[14];
                ptrResult[13] = ptrValue1[12] * ptrValue2[13] + ptrValue1[13] * ptrValue2[15];
                ptrResult[14] = ptrValue1[14] * ptrValue2[12] + ptrValue1[15] * ptrValue2[14];
                ptrResult[15] = ptrValue1[14] * ptrValue2[13] + ptrValue1[15] * ptrValue2[15];
                ptrResult += 16;
                ptrValue1 += 16;
                ptrValue2 += 16;
            }
            ptrEnd += 8;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * *ptrValue2 + ptrValue1[1] * ptrValue2[2];
                ptrResult[1] = *ptrValue1 * ptrValue2[1] + ptrValue1[1] * ptrValue2[3];
                ptrResult[2] = ptrValue1[2] * *ptrValue2 + ptrValue1[3] * ptrValue2[2];
                ptrResult[3] = ptrValue1[2] * ptrValue2[1] + ptrValue1[3] * ptrValue2[3];
                ptrResult[4] = ptrValue1[4] * ptrValue2[4] + ptrValue1[5] * ptrValue2[6];
                ptrResult[5] = ptrValue1[4] * ptrValue2[5] + ptrValue1[5] * ptrValue2[7];
                ptrResult[6] = ptrValue1[6] * ptrValue2[4] + ptrValue1[7] * ptrValue2[6];
                ptrResult[7] = ptrValue1[6] * ptrValue2[5] + ptrValue1[7] * ptrValue2[7];
                ptrResult += 8;
                ptrValue1 += 8;
                ptrValue2 += 8;
            }
            ptrEnd += 4;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * *ptrValue2 + ptrValue1[1] * ptrValue2[2];
                ptrResult[1] = *ptrValue1 * ptrValue2[1] + ptrValue1[1] * ptrValue2[3];
                ptrResult[2] = ptrValue1[2] * *ptrValue2 + ptrValue1[3] * ptrValue2[2];
                ptrResult[3] = ptrValue1[2] * ptrValue2[1] + ptrValue1[3] * ptrValue2[3];
                ptrResult += 4;
                ptrValue1 += 4;
                ptrValue2 += 4;
            }
        }
        unsafe internal static void Multiply(Block2x2* value1, Block2x2 value2, Block2x2* result, int length, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            double f00 = value2.f00;
            double f01 = value2.f01;
            double f10 = value2.f10;
            double f11 = value2.f11;
            double* ptrValue1 = (double*)(value1 + value1Index);
            double* ptrResult = (double*)(result + resultIndex);
            double* ptrEnd = (double*)(result + length) - 31;
            // Main loop, pointers for row values
            while (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * f00 + ptrValue1[1] * f10;
                ptrResult[1] = *ptrValue1 * f01 + ptrValue1[1] * f11;
                ptrResult[2] = ptrValue1[2] * f00 + ptrValue1[3] * f10;
                ptrResult[3] = ptrValue1[2] * f01 + ptrValue1[3] * f11;
                ptrResult[4] = ptrValue1[4] * f00 + ptrValue1[5] * f10;
                ptrResult[5] = ptrValue1[4] * f01 + ptrValue1[5] * f11;
                ptrResult[6] = ptrValue1[6] * f00 + ptrValue1[7] * f10;
                ptrResult[7] = ptrValue1[6] * f01 + ptrValue1[7] * f11;
                ptrResult[8] = ptrValue1[8] * f00 + ptrValue1[9] * f10;
                ptrResult[9] = ptrValue1[8] * f01 + ptrValue1[9] * f11;
                ptrResult[10] = ptrValue1[10] * f00 + ptrValue1[11] * f10;
                ptrResult[11] = ptrValue1[10] * f01 + ptrValue1[11] * f11;
                ptrResult[12] = ptrValue1[12] * f00 + ptrValue1[13] * f10;
                ptrResult[13] = ptrValue1[12] * f01 + ptrValue1[13] * f11;
                ptrResult[14] = ptrValue1[14] * f00 + ptrValue1[15] * f10;
                ptrResult[15] = ptrValue1[14] * f01 + ptrValue1[15] * f11;
                ptrResult[16] = ptrValue1[16] * f00 + ptrValue1[17] * f10;
                ptrResult[17] = ptrValue1[16] * f01 + ptrValue1[17] * f11;
                ptrResult[18] = ptrValue1[18] * f00 + ptrValue1[19] * f10;
                ptrResult[19] = ptrValue1[18] * f01 + ptrValue1[19] * f11;
                ptrResult[20] = ptrValue1[20] * f00 + ptrValue1[21] * f10;
                ptrResult[21] = ptrValue1[20] * f01 + ptrValue1[21] * f11;
                ptrResult[22] = ptrValue1[22] * f00 + ptrValue1[23] * f10;
                ptrResult[23] = ptrValue1[22] * f01 + ptrValue1[23] * f11;
                ptrResult[24] = ptrValue1[24] * f00 + ptrValue1[25] * f10;
                ptrResult[25] = ptrValue1[24] * f01 + ptrValue1[25] * f11;
                ptrResult[26] = ptrValue1[26] * f00 + ptrValue1[27] * f10;
                ptrResult[27] = ptrValue1[26] * f01 + ptrValue1[27] * f11;
                ptrResult[28] = ptrValue1[28] * f00 + ptrValue1[29] * f10;
                ptrResult[29] = ptrValue1[28] * f01 + ptrValue1[29] * f11;
                ptrResult[30] = ptrValue1[30] * f00 + ptrValue1[31] * f10;
                ptrResult[31] = ptrValue1[30] * f01 + ptrValue1[31] * f11;
                ptrResult += 32;
                ptrValue1 += 32;
            }
            ptrEnd += 16;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * f00 + ptrValue1[1] * f10;
                ptrResult[1] = *ptrValue1 * f01 + ptrValue1[1] * f11;
                ptrResult[2] = ptrValue1[2] * f00 + ptrValue1[3] * f10;
                ptrResult[3] = ptrValue1[2] * f01 + ptrValue1[3] * f11;
                ptrResult[4] = ptrValue1[4] * f00 + ptrValue1[5] * f10;
                ptrResult[5] = ptrValue1[4] * f01 + ptrValue1[5] * f11;
                ptrResult[6] = ptrValue1[6] * f00 + ptrValue1[7] * f10;
                ptrResult[7] = ptrValue1[6] * f01 + ptrValue1[7] * f11;
                ptrResult[8] = ptrValue1[8] * f00 + ptrValue1[9] * f10;
                ptrResult[9] = ptrValue1[8] * f01 + ptrValue1[9] * f11;
                ptrResult[10] = ptrValue1[10] * f00 + ptrValue1[11] * f10;
                ptrResult[11] = ptrValue1[10] * f01 + ptrValue1[11] * f11;
                ptrResult[12] = ptrValue1[12] * f00 + ptrValue1[13] * f10;
                ptrResult[13] = ptrValue1[12] * f01 + ptrValue1[13] * f11;
                ptrResult[14] = ptrValue1[14] * f00 + ptrValue1[15] * f10;
                ptrResult[15] = ptrValue1[14] * f01 + ptrValue1[15] * f11;
                ptrResult += 16;
                ptrValue1 += 16;
            }
            ptrEnd += 8;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * f00 + ptrValue1[1] * f10;
                ptrResult[1] = *ptrValue1 * f01 + ptrValue1[1] * f11;
                ptrResult[2] = ptrValue1[2] * f00 + ptrValue1[3] * f10;
                ptrResult[3] = ptrValue1[2] * f01 + ptrValue1[3] * f11;
                ptrResult[4] = ptrValue1[4] * f00 + ptrValue1[5] * f10;
                ptrResult[5] = ptrValue1[4] * f01 + ptrValue1[5] * f11;
                ptrResult[6] = ptrValue1[6] * f00 + ptrValue1[7] * f10;
                ptrResult[7] = ptrValue1[6] * f01 + ptrValue1[7] * f11;
                ptrResult += 8;
                ptrValue1 += 8;
            }
            ptrEnd += 4;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * f00 + ptrValue1[1] * f10;
                ptrResult[1] = *ptrValue1 * f01 + ptrValue1[1] * f11;
                ptrResult[2] = ptrValue1[2] * f00 + ptrValue1[3] * f10;
                ptrResult[3] = ptrValue1[2] * f01 + ptrValue1[3] * f11;
                ptrResult += 4;
                ptrValue1 += 4;
            }
        }
        unsafe internal static void Division(Block2x2* value1, Block2x2* value2, Block2x2* result, int length, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            double* ptrValue1 = (double*)(value1 + value1Index);
            double* ptrValue2 = (double*)(value2 + value2Index);
            double* ptrResult = (double*)(result + resultIndex);
            double* ptrEnd = (double*)(result + length) - 31;
            // Main loop, pointers for row values
            while (ptrResult < ptrEnd)
            {
                Block2x2Division(ptrValue1, ptrValue2, ptrResult);
                Block2x2Division(ptrValue1 + 4, ptrValue2 + 4, ptrResult + 4);
                Block2x2Division(ptrValue1 + 8, ptrValue2 + 8, ptrResult + 8);
                Block2x2Division(ptrValue1 + 12, ptrValue2 + 12, ptrResult + 12);
                Block2x2Division(ptrValue1 + 16, ptrValue2 + 16, ptrResult + 16);
                Block2x2Division(ptrValue1 + 20, ptrValue2 + 20, ptrResult + 20);
                Block2x2Division(ptrValue1 + 24, ptrValue2 + 24, ptrResult + 24);
                Block2x2Division(ptrValue1 + 28, ptrValue2 + 28, ptrResult + 28);
                ptrResult += 32;
                ptrValue1 += 32;
            }
            ptrEnd += 16;
            if (ptrResult < ptrEnd)
            {
                Block2x2Division(ptrValue1, ptrValue2, ptrResult);
                Block2x2Division(ptrValue1 + 4, ptrValue2 + 4, ptrResult + 4);
                Block2x2Division(ptrValue1 + 8, ptrValue2 + 8, ptrResult + 8);
                Block2x2Division(ptrValue1 + 12, ptrValue2 + 12, ptrResult + 12);
                ptrResult += 16;
                ptrValue1 += 16;
            }
            ptrEnd += 8;
            if (ptrResult < ptrEnd)
            {
                Block2x2Division(ptrValue1, ptrValue2, ptrResult);
                Block2x2Division(ptrValue1 + 4, ptrValue2 + 4, ptrResult + 4);
                ptrResult += 8;
                ptrValue1 += 8;
            }
            ptrEnd += 4;
            if (ptrResult < ptrEnd)
            {
                Block2x2Division(ptrValue1, ptrValue2, ptrResult);
                ptrResult += 4;
                ptrValue1 += 4;
            }
        }
        unsafe internal static void Inverse(Block2x2* value, Block2x2* result, int length, int valueIndex = 0, int resultIndex = 0)
        {
            double* ptrValue = (double*)(value + valueIndex);
            double* ptrResult = (double*)(result + resultIndex);
            double* ptrEnd = ptrResult + length * 4 - 31;
            // Main loop, pointers for row values
            while (ptrResult < ptrEnd)
            {
                Block2x2Inverse(ptrValue, ptrResult);
                Block2x2Inverse(ptrValue + 4, ptrResult + 4);
                Block2x2Inverse(ptrValue + 8, ptrResult + 8);
                Block2x2Inverse(ptrValue + 12, ptrResult + 12);
                Block2x2Inverse(ptrValue + 16, ptrResult + 16);
                Block2x2Inverse(ptrValue + 20, ptrResult + 20);
                Block2x2Inverse(ptrValue + 24, ptrResult + 24);
                Block2x2Inverse(ptrValue + 28, ptrResult + 28);
                ptrResult += 32;
                ptrValue += 32;
            }
            ptrEnd += 16;
            if (ptrResult < ptrEnd)
            {
                Block2x2Inverse(ptrValue, ptrResult);
                Block2x2Inverse(ptrValue + 4, ptrResult + 4);
                Block2x2Inverse(ptrValue + 8, ptrResult + 8);
                Block2x2Inverse(ptrValue + 12, ptrResult + 12);
                ptrResult += 16;
                ptrValue += 16;
            }
            ptrEnd += 8;
            if (ptrResult < ptrEnd)
            {
                Block2x2Inverse(ptrValue, ptrResult);
                Block2x2Inverse(ptrValue + 4, ptrResult + 4);
                ptrResult += 8;
                ptrValue += 8;
            }
            ptrEnd += 4;
            if (ptrResult < ptrEnd)
            {
                Block2x2Inverse(ptrValue, ptrResult);
                ptrResult += 4;
                ptrValue += 4;
            }
        }
        #endregion Internal methods
        #region Private methods
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
        #endregion Events, overrides
        #endregion Methods
    }
}
#endregion Working namespace