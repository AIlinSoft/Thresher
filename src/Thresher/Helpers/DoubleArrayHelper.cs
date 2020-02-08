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
    /// Double operations optimized helper
    /// </summary>
    class DoubleArrayHelper
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
        unsafe internal static void Addition(double* value1, double value2, double* result, int length, int value1Index = 0, int resultIndex = 0)
        {
            double* ptrValue1 = value1 + value1Index;
            double* ptrResult = result + resultIndex;
            double* ptrEnd = (ptrResult + length) - 31;
            // Main loop, pointers for row values
            while (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + value2;
                *(ptrResult + 1) = *(ptrValue1 + 1) + value2;
                *(ptrResult + 2) = *(ptrValue1 + 2) + value2;
                *(ptrResult + 3) = *(ptrValue1 + 3) + value2;
                *(ptrResult + 4) = *(ptrValue1 + 4) + value2;
                *(ptrResult + 5) = *(ptrValue1 + 5) + value2;
                *(ptrResult + 6) = *(ptrValue1 + 6) + value2;
                *(ptrResult + 7) = *(ptrValue1 + 7) + value2;
                *(ptrResult + 8) = *(ptrValue1 + 8) + value2;
                *(ptrResult + 9) = *(ptrValue1 + 9) + value2;
                *(ptrResult + 10) = *(ptrValue1 + 10) + value2;
                *(ptrResult + 11) = *(ptrValue1 + 11) + value2;
                *(ptrResult + 12) = *(ptrValue1 + 12) + value2;
                *(ptrResult + 13) = *(ptrValue1 + 13) + value2;
                *(ptrResult + 14) = *(ptrValue1 + 14) + value2;
                *(ptrResult + 15) = *(ptrValue1 + 15) + value2;
                *(ptrResult + 16) = *(ptrValue1 + 16) + value2;
                *(ptrResult + 17) = *(ptrValue1 + 17) + value2;
                *(ptrResult + 18) = *(ptrValue1 + 18) + value2;
                *(ptrResult + 19) = *(ptrValue1 + 19) + value2;
                *(ptrResult + 20) = *(ptrValue1 + 20) + value2;
                *(ptrResult + 21) = *(ptrValue1 + 21) + value2;
                *(ptrResult + 22) = *(ptrValue1 + 22) + value2;
                *(ptrResult + 23) = *(ptrValue1 + 23) + value2;
                *(ptrResult + 24) = *(ptrValue1 + 24) + value2;
                *(ptrResult + 25) = *(ptrValue1 + 25) + value2;
                *(ptrResult + 26) = *(ptrValue1 + 26) + value2;
                *(ptrResult + 27) = *(ptrValue1 + 27) + value2;
                *(ptrResult + 28) = *(ptrValue1 + 28) + value2;
                *(ptrResult + 29) = *(ptrValue1 + 29) + value2;
                *(ptrResult + 30) = *(ptrValue1 + 30) + value2;
                *(ptrResult + 31) = *(ptrValue1 + 31) + value2;
                ptrResult += 32;
                ptrValue1 += 32;
            }
            ptrEnd += 16;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + value2;
                *(ptrResult + 1) = *(ptrValue1 + 1) + value2;
                *(ptrResult + 2) = *(ptrValue1 + 2) + value2;
                *(ptrResult + 3) = *(ptrValue1 + 3) + value2;
                *(ptrResult + 4) = *(ptrValue1 + 4) + value2;
                *(ptrResult + 5) = *(ptrValue1 + 5) + value2;
                *(ptrResult + 6) = *(ptrValue1 + 6) + value2;
                *(ptrResult + 7) = *(ptrValue1 + 7) + value2;
                *(ptrResult + 8) = *(ptrValue1 + 8) + value2;
                *(ptrResult + 9) = *(ptrValue1 + 9) + value2;
                *(ptrResult + 10) = *(ptrValue1 + 10) + value2;
                *(ptrResult + 11) = *(ptrValue1 + 11) + value2;
                *(ptrResult + 12) = *(ptrValue1 + 12) + value2;
                *(ptrResult + 13) = *(ptrValue1 + 13) + value2;
                *(ptrResult + 14) = *(ptrValue1 + 14) + value2;
                *(ptrResult + 15) = *(ptrValue1 + 15) + value2;
                ptrResult += 16;
                ptrValue1 += 16;
            }
            ptrEnd += 8;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + value2;
                *(ptrResult + 1) = *(ptrValue1 + 1) + value2;
                *(ptrResult + 2) = *(ptrValue1 + 2) + value2;
                *(ptrResult + 3) = *(ptrValue1 + 3) + value2;
                *(ptrResult + 4) = *(ptrValue1 + 4) + value2;
                *(ptrResult + 5) = *(ptrValue1 + 5) + value2;
                *(ptrResult + 6) = *(ptrValue1 + 6) + value2;
                *(ptrResult + 7) = *(ptrValue1 + 7) + value2;
                ptrResult += 8;
                ptrValue1 += 8;
            }
            ptrEnd += 4;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + value2;
                *(ptrResult + 1) = *(ptrValue1 + 1) + value2;
                *(ptrResult + 2) = *(ptrValue1 + 2) + value2;
                *(ptrResult + 3) = *(ptrValue1 + 3) + value2;
                ptrResult += 4;
                ptrValue1 += 4;
            }
            ptrEnd += 2;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + value2;
                *(ptrResult + 1) = *(ptrValue1 + 1) + value2;
                ptrResult += 2;
                ptrValue1 += 2;
            }
            if (ptrResult == ptrEnd)
                *ptrResult = *ptrValue1 + value2;
        }
        unsafe internal static void Addition(double* value1, double value2, double value3, double* result, int length, int value1Index = 0, int resultIndex = 0)
        {
            double* ptrValue1 = value1 + value1Index;
            double* ptrResult = result + resultIndex;
            double* ptrEnd = (ptrResult + length) - 31;
            // Main loop, pointers for row values
            while (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + value2;
                *(ptrResult + 1) = *(ptrValue1 + 1) + value3;
                *(ptrResult + 2) = *(ptrValue1 + 2) + value2;
                *(ptrResult + 3) = *(ptrValue1 + 3) + value3;
                *(ptrResult + 4) = *(ptrValue1 + 4) + value2;
                *(ptrResult + 5) = *(ptrValue1 + 5) + value3;
                *(ptrResult + 6) = *(ptrValue1 + 6) + value2;
                *(ptrResult + 7) = *(ptrValue1 + 7) + value3;
                *(ptrResult + 8) = *(ptrValue1 + 8) + value2;
                *(ptrResult + 9) = *(ptrValue1 + 9) + value3;
                *(ptrResult + 10) = *(ptrValue1 + 10) + value2;
                *(ptrResult + 11) = *(ptrValue1 + 11) + value3;
                *(ptrResult + 12) = *(ptrValue1 + 12) + value2;
                *(ptrResult + 13) = *(ptrValue1 + 13) + value3;
                *(ptrResult + 14) = *(ptrValue1 + 14) + value2;
                *(ptrResult + 15) = *(ptrValue1 + 15) + value3;
                *(ptrResult + 16) = *(ptrValue1 + 16) + value2;
                *(ptrResult + 17) = *(ptrValue1 + 17) + value3;
                *(ptrResult + 18) = *(ptrValue1 + 18) + value2;
                *(ptrResult + 19) = *(ptrValue1 + 19) + value3;
                *(ptrResult + 20) = *(ptrValue1 + 20) + value2;
                *(ptrResult + 21) = *(ptrValue1 + 21) + value3;
                *(ptrResult + 22) = *(ptrValue1 + 22) + value2;
                *(ptrResult + 23) = *(ptrValue1 + 23) + value3;
                *(ptrResult + 24) = *(ptrValue1 + 24) + value2;
                *(ptrResult + 25) = *(ptrValue1 + 25) + value3;
                *(ptrResult + 26) = *(ptrValue1 + 26) + value2;
                *(ptrResult + 27) = *(ptrValue1 + 27) + value3;
                *(ptrResult + 28) = *(ptrValue1 + 28) + value2;
                *(ptrResult + 29) = *(ptrValue1 + 29) + value3;
                *(ptrResult + 30) = *(ptrValue1 + 30) + value2;
                *(ptrResult + 31) = *(ptrValue1 + 31) + value3;
                ptrResult += 32;
                ptrValue1 += 32;
            }
            ptrEnd += 16;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + value2;
                *(ptrResult + 1) = *(ptrValue1 + 1) + value3;
                *(ptrResult + 2) = *(ptrValue1 + 2) + value2;
                *(ptrResult + 3) = *(ptrValue1 + 3) + value3;
                *(ptrResult + 4) = *(ptrValue1 + 4) + value2;
                *(ptrResult + 5) = *(ptrValue1 + 5) + value3;
                *(ptrResult + 6) = *(ptrValue1 + 6) + value2;
                *(ptrResult + 7) = *(ptrValue1 + 7) + value3;
                *(ptrResult + 8) = *(ptrValue1 + 8) + value2;
                *(ptrResult + 9) = *(ptrValue1 + 9) + value3;
                *(ptrResult + 10) = *(ptrValue1 + 10) + value2;
                *(ptrResult + 11) = *(ptrValue1 + 11) + value3;
                *(ptrResult + 12) = *(ptrValue1 + 12) + value2;
                *(ptrResult + 13) = *(ptrValue1 + 13) + value3;
                *(ptrResult + 14) = *(ptrValue1 + 14) + value2;
                *(ptrResult + 15) = *(ptrValue1 + 15) + value3;
                ptrResult += 16;
                ptrValue1 += 16;
            }
            ptrEnd += 8;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + value2;
                *(ptrResult + 1) = *(ptrValue1 + 1) + value3;
                *(ptrResult + 2) = *(ptrValue1 + 2) + value2;
                *(ptrResult + 3) = *(ptrValue1 + 3) + value3;
                *(ptrResult + 4) = *(ptrValue1 + 4) + value2;
                *(ptrResult + 5) = *(ptrValue1 + 5) + value3;
                *(ptrResult + 6) = *(ptrValue1 + 6) + value2;
                *(ptrResult + 7) = *(ptrValue1 + 7) + value3;
                ptrResult += 8;
                ptrValue1 += 8;
            }
            ptrEnd += 4;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + value2;
                *(ptrResult + 1) = *(ptrValue1 + 1) + value3;
                *(ptrResult + 2) = *(ptrValue1 + 2) + value2;
                *(ptrResult + 3) = *(ptrValue1 + 3) + value3;
                ptrResult += 4;
                ptrValue1 += 4;
            }
            ptrEnd += 2;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + value2;
                *(ptrResult + 1) = *(ptrValue1 + 1) + value3;
                ptrResult += 2;
                ptrValue1 += 2;
            }
        }
        unsafe internal static void Addition(double* value1, double value2, double value3, double value4, double value5, double* result, int length, int value1Index = 0, int resultIndex = 0)
        {
            double* ptrValue1 = value1 + value1Index;
            double* ptrResult = result + resultIndex;
            double* ptrEnd = (ptrResult + length) - 31;
            // Main loop, pointers for row values
            while (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + value2;
                *(ptrResult + 1) = *(ptrValue1 + 1) + value3;
                *(ptrResult + 2) = *(ptrValue1 + 2) + value4;
                *(ptrResult + 3) = *(ptrValue1 + 3) + value5;
                *(ptrResult + 4) = *(ptrValue1 + 4) + value2;
                *(ptrResult + 5) = *(ptrValue1 + 5) + value3;
                *(ptrResult + 6) = *(ptrValue1 + 6) + value4;
                *(ptrResult + 7) = *(ptrValue1 + 7) + value5;
                *(ptrResult + 8) = *(ptrValue1 + 8) + value2;
                *(ptrResult + 9) = *(ptrValue1 + 9) + value3;
                *(ptrResult + 10) = *(ptrValue1 + 10) + value4;
                *(ptrResult + 11) = *(ptrValue1 + 11) + value5;
                *(ptrResult + 12) = *(ptrValue1 + 12) + value2;
                *(ptrResult + 13) = *(ptrValue1 + 13) + value3;
                *(ptrResult + 14) = *(ptrValue1 + 14) + value4;
                *(ptrResult + 15) = *(ptrValue1 + 15) + value5;
                *(ptrResult + 16) = *(ptrValue1 + 16) + value2;
                *(ptrResult + 17) = *(ptrValue1 + 17) + value3;
                *(ptrResult + 18) = *(ptrValue1 + 18) + value4;
                *(ptrResult + 19) = *(ptrValue1 + 19) + value5;
                *(ptrResult + 20) = *(ptrValue1 + 20) + value2;
                *(ptrResult + 21) = *(ptrValue1 + 21) + value3;
                *(ptrResult + 22) = *(ptrValue1 + 22) + value4;
                *(ptrResult + 23) = *(ptrValue1 + 23) + value5;
                *(ptrResult + 24) = *(ptrValue1 + 24) + value2;
                *(ptrResult + 25) = *(ptrValue1 + 25) + value3;
                *(ptrResult + 26) = *(ptrValue1 + 26) + value4;
                *(ptrResult + 27) = *(ptrValue1 + 27) + value5;
                *(ptrResult + 28) = *(ptrValue1 + 28) + value2;
                *(ptrResult + 29) = *(ptrValue1 + 29) + value3;
                *(ptrResult + 30) = *(ptrValue1 + 30) + value4;
                *(ptrResult + 31) = *(ptrValue1 + 31) + value5;
                ptrResult += 32;
                ptrValue1 += 32;
            }
            ptrEnd += 16;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + value2;
                *(ptrResult + 1) = *(ptrValue1 + 1) + value3;
                *(ptrResult + 2) = *(ptrValue1 + 2) + value4;
                *(ptrResult + 3) = *(ptrValue1 + 3) + value5;
                *(ptrResult + 4) = *(ptrValue1 + 4) + value2;
                *(ptrResult + 5) = *(ptrValue1 + 5) + value3;
                *(ptrResult + 6) = *(ptrValue1 + 6) + value4;
                *(ptrResult + 7) = *(ptrValue1 + 7) + value5;
                *(ptrResult + 8) = *(ptrValue1 + 8) + value2;
                *(ptrResult + 9) = *(ptrValue1 + 9) + value3;
                *(ptrResult + 10) = *(ptrValue1 + 10) + value4;
                *(ptrResult + 11) = *(ptrValue1 + 11) + value5;
                *(ptrResult + 12) = *(ptrValue1 + 12) + value2;
                *(ptrResult + 13) = *(ptrValue1 + 13) + value3;
                *(ptrResult + 14) = *(ptrValue1 + 14) + value4;
                *(ptrResult + 15) = *(ptrValue1 + 15) + value5;
                ptrResult += 16;
                ptrValue1 += 16;
            }
            ptrEnd += 8;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + value2;
                *(ptrResult + 1) = *(ptrValue1 + 1) + value3;
                *(ptrResult + 2) = *(ptrValue1 + 2) + value4;
                *(ptrResult + 3) = *(ptrValue1 + 3) + value5;
                *(ptrResult + 4) = *(ptrValue1 + 4) + value2;
                *(ptrResult + 5) = *(ptrValue1 + 5) + value3;
                *(ptrResult + 6) = *(ptrValue1 + 6) + value4;
                *(ptrResult + 7) = *(ptrValue1 + 7) + value5;
                ptrResult += 8;
                ptrValue1 += 8;
            }
            ptrEnd += 4;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + value2;
                *(ptrResult + 1) = *(ptrValue1 + 1) + value3;
                *(ptrResult + 2) = *(ptrValue1 + 2) + value4;
                *(ptrResult + 3) = *(ptrValue1 + 3) + value5;
                ptrResult += 4;
                ptrValue1 += 4;
            }
        }
        unsafe internal static double Summary(double* value, int length, int valueIndex = 0)
        {
            double returnValue = 0;
            double* ptrValue1 = value + valueIndex;
            double* ptrEnd = ptrValue1 + length - 31;
            // Main loop, pointers for row values
            while (ptrValue1 < ptrEnd)
            {
                returnValue += *ptrValue1;
                returnValue += ptrValue1[1];
                returnValue += ptrValue1[2];
                returnValue += ptrValue1[3];
                returnValue += ptrValue1[4];
                returnValue += ptrValue1[5];
                returnValue += ptrValue1[6];
                returnValue += ptrValue1[7];
                returnValue += ptrValue1[8];
                returnValue += ptrValue1[9];
                returnValue += ptrValue1[10];
                returnValue += ptrValue1[11];
                returnValue += ptrValue1[12];
                returnValue += ptrValue1[13];
                returnValue += ptrValue1[14];
                returnValue += ptrValue1[15];
                returnValue += ptrValue1[16];
                returnValue += ptrValue1[17];
                returnValue += ptrValue1[18];
                returnValue += ptrValue1[19];
                returnValue += ptrValue1[20];
                returnValue += ptrValue1[21];
                returnValue += ptrValue1[22];
                returnValue += ptrValue1[23];
                returnValue += ptrValue1[24];
                returnValue += ptrValue1[25];
                returnValue += ptrValue1[26];
                returnValue += ptrValue1[27];
                returnValue += ptrValue1[28];
                returnValue += ptrValue1[29];
                returnValue += ptrValue1[30];
                returnValue += ptrValue1[31];
                ptrValue1 += 32;
            }
            ptrEnd += 16;
            if (ptrValue1 < ptrEnd)
            {
                returnValue += *ptrValue1;
                returnValue += ptrValue1[1];
                returnValue += ptrValue1[2];
                returnValue += ptrValue1[3];
                returnValue += ptrValue1[4];
                returnValue += ptrValue1[5];
                returnValue += ptrValue1[6];
                returnValue += ptrValue1[7];
                returnValue += ptrValue1[8];
                returnValue += ptrValue1[9];
                returnValue += ptrValue1[10];
                returnValue += ptrValue1[11];
                returnValue += ptrValue1[12];
                returnValue += ptrValue1[13];
                returnValue += ptrValue1[14];
                returnValue += ptrValue1[15];
                ptrValue1 += 16;
            }
            ptrEnd += 8;
            if (ptrValue1 < ptrEnd)
            {
                returnValue += *ptrValue1;
                returnValue += ptrValue1[1];
                returnValue += ptrValue1[2];
                returnValue += ptrValue1[3];
                returnValue += ptrValue1[4];
                returnValue += ptrValue1[5];
                returnValue += ptrValue1[6];
                returnValue += ptrValue1[7];
                ptrValue1 += 8;
            }
            ptrEnd += 4;
            if (ptrValue1 < ptrEnd)
            {
                returnValue += *ptrValue1;
                returnValue += ptrValue1[1];
                returnValue += ptrValue1[2];
                returnValue += ptrValue1[3];
                ptrValue1 += 4;
            }
            ptrEnd += 2;
            if (ptrValue1 < ptrEnd)
            {
                returnValue += *ptrValue1;
                returnValue += ptrValue1[1];
                ptrValue1 += 2;
            }
            if (ptrValue1 == ptrEnd)
                returnValue += *ptrValue1;
            return returnValue;
        }
        /// <summary>
        /// Addition two arrays of real values
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        unsafe internal static void Addition(double* value1, double* value2, double* result, int length, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            double* ptrValue1 = value1 + value1Index;
            double* ptrValue2 = value2 + value2Index;
            double* ptrResult = result + resultIndex;
            double* ptrEnd = ptrResult + length - 31;
            // Main loop, pointers for row values
            while (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + *ptrValue2;
                ptrResult[1] = ptrValue1[1] + ptrValue2[1];
                ptrResult[2] = ptrValue1[2] + ptrValue2[2];
                ptrResult[3] = ptrValue1[3] + ptrValue2[3];
                ptrResult[4] = ptrValue1[4] + ptrValue2[4];
                ptrResult[5] = ptrValue1[5] + ptrValue2[5];
                ptrResult[6] = ptrValue1[6] + ptrValue2[6];
                ptrResult[7] = ptrValue1[7] + ptrValue2[7];
                ptrResult[8] = ptrValue1[8] + ptrValue2[8];
                ptrResult[9] = ptrValue1[9] + ptrValue2[9];
                ptrResult[10] = ptrValue1[10] + ptrValue2[10];
                ptrResult[11] = ptrValue1[11] + ptrValue2[11];
                ptrResult[12] = ptrValue1[12] + ptrValue2[12];
                ptrResult[13] = ptrValue1[13] + ptrValue2[13];
                ptrResult[14] = ptrValue1[14] + ptrValue2[14];
                ptrResult[15] = ptrValue1[15] + ptrValue2[15];
                ptrResult[16] = ptrValue1[16] + ptrValue2[16];
                ptrResult[17] = ptrValue1[17] + ptrValue2[17];
                ptrResult[18] = ptrValue1[18] + ptrValue2[18];
                ptrResult[19] = ptrValue1[19] + ptrValue2[19];
                ptrResult[20] = ptrValue1[20] + ptrValue2[20];
                ptrResult[21] = ptrValue1[21] + ptrValue2[21];
                ptrResult[22] = ptrValue1[22] + ptrValue2[22];
                ptrResult[23] = ptrValue1[23] + ptrValue2[23];
                ptrResult[24] = ptrValue1[24] + ptrValue2[24];
                ptrResult[25] = ptrValue1[25] + ptrValue2[25];
                ptrResult[26] = ptrValue1[26] + ptrValue2[26];
                ptrResult[27] = ptrValue1[27] + ptrValue2[27];
                ptrResult[28] = ptrValue1[28] + ptrValue2[28];
                ptrResult[29] = ptrValue1[29] + ptrValue2[29];
                ptrResult[30] = ptrValue1[30] + ptrValue2[30];
                ptrResult[31] = ptrValue1[31] + ptrValue2[31];
                ptrResult += 32;
                ptrValue1 += 32;
                ptrValue2 += 32;
            }
            ptrEnd += 16;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + *ptrValue2;
                ptrResult[1] = ptrValue1[1] + ptrValue2[1];
                ptrResult[2] = ptrValue1[2] + ptrValue2[2];
                ptrResult[3] = ptrValue1[3] + ptrValue2[3];
                ptrResult[4] = ptrValue1[4] + ptrValue2[4];
                ptrResult[5] = ptrValue1[5] + ptrValue2[5];
                ptrResult[6] = ptrValue1[6] + ptrValue2[6];
                ptrResult[7] = ptrValue1[7] + ptrValue2[7];
                ptrResult[8] = ptrValue1[8] + ptrValue2[8];
                ptrResult[9] = ptrValue1[9] + ptrValue2[9];
                ptrResult[10] = ptrValue1[10] + ptrValue2[10];
                ptrResult[11] = ptrValue1[11] + ptrValue2[11];
                ptrResult[12] = ptrValue1[12] + ptrValue2[12];
                ptrResult[13] = ptrValue1[13] + ptrValue2[13];
                ptrResult[14] = ptrValue1[14] + ptrValue2[14];
                ptrResult[15] = ptrValue1[15] + ptrValue2[15];
                ptrResult += 16;
                ptrValue1 += 16;
                ptrValue2 += 16;
            }
            ptrEnd += 8;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + *ptrValue2;
                ptrResult[1] = ptrValue1[1] + ptrValue2[1];
                ptrResult[2] = ptrValue1[2] + ptrValue2[2];
                ptrResult[3] = ptrValue1[3] + ptrValue2[3];
                ptrResult[4] = ptrValue1[4] + ptrValue2[4];
                ptrResult[5] = ptrValue1[5] + ptrValue2[5];
                ptrResult[6] = ptrValue1[6] + ptrValue2[6];
                ptrResult[7] = ptrValue1[7] + ptrValue2[7];
                ptrResult += 8;
                ptrValue1 += 8;
                ptrValue2 += 8;
            }
            ptrEnd += 4;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + *ptrValue2;
                ptrResult[1] = ptrValue1[1] + ptrValue2[1];
                ptrResult[2] = ptrValue1[2] + ptrValue2[2];
                ptrResult[3] = ptrValue1[3] + ptrValue2[3];
                ptrResult += 4;
                ptrValue1 += 4;
                ptrValue2 += 4;
            }
            ptrEnd += 2;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + *ptrValue2;
                ptrResult[1] = ptrValue1[1] + ptrValue2[1];
                ptrResult += 2;
                ptrValue1 += 2;
                ptrValue2 += 2;
            }
            if (ptrResult == ptrEnd)
                *ptrResult = *ptrValue1 + *ptrValue2;
        }
        unsafe internal static void Substraction(double* value1, double* value2, double* result, int length, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            double* ptrValue1 = value1 + value1Index;
            double* ptrValue2 = value2 + value2Index;
            double* ptrResult = result + resultIndex;
            double* ptrEnd = ptrResult + length - 31;
            // Main loop, pointers for row values
            while (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 - *ptrValue2;
                ptrResult[1] = ptrValue1[1] - ptrValue2[1];
                ptrResult[2] = ptrValue1[2] - ptrValue2[2];
                ptrResult[3] = ptrValue1[3] - ptrValue2[3];
                ptrResult[4] = ptrValue1[4] - ptrValue2[4];
                ptrResult[5] = ptrValue1[5] - ptrValue2[5];
                ptrResult[6] = ptrValue1[6] - ptrValue2[6];
                ptrResult[7] = ptrValue1[7] - ptrValue2[7];
                ptrResult[8] = ptrValue1[8] - ptrValue2[8];
                ptrResult[9] = ptrValue1[9] - ptrValue2[9];
                ptrResult[10] = ptrValue1[10] - ptrValue2[10];
                ptrResult[11] = ptrValue1[11] - ptrValue2[11];
                ptrResult[12] = ptrValue1[12] - ptrValue2[12];
                ptrResult[13] = ptrValue1[13] - ptrValue2[13];
                ptrResult[14] = ptrValue1[14] - ptrValue2[14];
                ptrResult[15] = ptrValue1[15] - ptrValue2[15];
                ptrResult[16] = ptrValue1[16] - ptrValue2[16];
                ptrResult[17] = ptrValue1[17] - ptrValue2[17];
                ptrResult[18] = ptrValue1[18] - ptrValue2[18];
                ptrResult[19] = ptrValue1[19] - ptrValue2[19];
                ptrResult[20] = ptrValue1[20] - ptrValue2[20];
                ptrResult[21] = ptrValue1[21] - ptrValue2[21];
                ptrResult[22] = ptrValue1[22] - ptrValue2[22];
                ptrResult[23] = ptrValue1[23] - ptrValue2[23];
                ptrResult[24] = ptrValue1[24] - ptrValue2[24];
                ptrResult[25] = ptrValue1[25] - ptrValue2[25];
                ptrResult[26] = ptrValue1[26] - ptrValue2[26];
                ptrResult[27] = ptrValue1[27] - ptrValue2[27];
                ptrResult[28] = ptrValue1[28] - ptrValue2[28];
                ptrResult[29] = ptrValue1[29] - ptrValue2[29];
                ptrResult[30] = ptrValue1[30] - ptrValue2[30];
                ptrResult[31] = ptrValue1[31] - ptrValue2[31];
                ptrResult += 32;
                ptrValue1 += 32;
                ptrValue2 += 32;
            }
            ptrEnd += 16;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 - *ptrValue2;
                ptrResult[1] = ptrValue1[1] - ptrValue2[1];
                ptrResult[2] = ptrValue1[2] - ptrValue2[2];
                ptrResult[3] = ptrValue1[3] - ptrValue2[3];
                ptrResult[4] = ptrValue1[4] - ptrValue2[4];
                ptrResult[5] = ptrValue1[5] - ptrValue2[5];
                ptrResult[6] = ptrValue1[6] - ptrValue2[6];
                ptrResult[7] = ptrValue1[7] - ptrValue2[7];
                ptrResult[8] = ptrValue1[8] - ptrValue2[8];
                ptrResult[9] = ptrValue1[9] - ptrValue2[9];
                ptrResult[10] = ptrValue1[10] - ptrValue2[10];
                ptrResult[11] = ptrValue1[11] - ptrValue2[11];
                ptrResult[12] = ptrValue1[12] - ptrValue2[12];
                ptrResult[13] = ptrValue1[13] - ptrValue2[13];
                ptrResult[14] = ptrValue1[14] - ptrValue2[14];
                ptrResult[15] = ptrValue1[15] - ptrValue2[15];
                ptrResult += 16;
                ptrValue1 += 16;
                ptrValue2 += 16;
            }
            ptrEnd += 8;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 - *ptrValue2;
                ptrResult[1] = ptrValue1[1] - ptrValue2[1];
                ptrResult[2] = ptrValue1[2] - ptrValue2[2];
                ptrResult[3] = ptrValue1[3] - ptrValue2[3];
                ptrResult[4] = ptrValue1[4] - ptrValue2[4];
                ptrResult[5] = ptrValue1[5] - ptrValue2[5];
                ptrResult[6] = ptrValue1[6] - ptrValue2[6];
                ptrResult[7] = ptrValue1[7] - ptrValue2[7];
                ptrResult += 8;
                ptrValue1 += 8;
                ptrValue2 += 8;
            }
            ptrEnd += 4;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 - *ptrValue2;
                ptrResult[1] = ptrValue1[1] - ptrValue2[1];
                ptrResult[2] = ptrValue1[2] - ptrValue2[2];
                ptrResult[3] = ptrValue1[3] - ptrValue2[3];
                ptrResult += 4;
                ptrValue1 += 4;
                ptrValue2 += 4;
            }
            ptrEnd += 2;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 - *ptrValue2;
                ptrResult[1] = ptrValue1[1] - ptrValue2[1];
                ptrResult += 2;
                ptrValue1 += 2;
                ptrValue2 += 2;
            }
            if (ptrResult == ptrEnd)
                *ptrResult = *ptrValue1 - *ptrValue2;
        }
        unsafe internal static void Negate(double* value, double* result, int length, int valueStart = 0, int resultStart = 0)
        {
            double* ptrValue = value + valueStart;
            double* ptrResult = result + resultStart;
            double* ptrEnd = ptrResult + length - 31;
            // Main loop, pointers for row values
            while (ptrResult < ptrEnd)
            {
                *ptrResult = -*ptrValue;
                ptrResult[1] = -ptrValue[1];
                ptrResult[2] = -ptrValue[2];
                ptrResult[3] = -ptrValue[3];
                ptrResult[4] = -ptrValue[4];
                ptrResult[5] = -ptrValue[5];
                ptrResult[6] = -ptrValue[6];
                ptrResult[7] = -ptrValue[7];
                ptrResult[8] = -ptrValue[8];
                ptrResult[9] = -ptrValue[9];
                ptrResult[10] = -ptrValue[10];
                ptrResult[11] = -ptrValue[11];
                ptrResult[12] = -ptrValue[12];
                ptrResult[13] = -ptrValue[13];
                ptrResult[14] = -ptrValue[14];
                ptrResult[15] = -ptrValue[15];
                ptrResult[16] = -ptrValue[16];
                ptrResult[17] = -ptrValue[17];
                ptrResult[18] = -ptrValue[18];
                ptrResult[19] = -ptrValue[19];
                ptrResult[20] = -ptrValue[20];
                ptrResult[21] = -ptrValue[21];
                ptrResult[22] = -ptrValue[22];
                ptrResult[23] = -ptrValue[23];
                ptrResult[24] = -ptrValue[24];
                ptrResult[25] = -ptrValue[25];
                ptrResult[26] = -ptrValue[26];
                ptrResult[27] = -ptrValue[27];
                ptrResult[28] = -ptrValue[28];
                ptrResult[29] = -ptrValue[29];
                ptrResult[30] = -ptrValue[30];
                ptrResult[31] = -ptrValue[31];
                ptrResult += 32;
                ptrValue += 32;
            }
            ptrEnd += 16;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = -*ptrValue;
                ptrResult[1] = -ptrValue[1];
                ptrResult[2] = -ptrValue[2];
                ptrResult[3] = -ptrValue[3];
                ptrResult[4] = -ptrValue[4];
                ptrResult[5] = -ptrValue[5];
                ptrResult[6] = -ptrValue[6];
                ptrResult[7] = -ptrValue[7];
                ptrResult[8] = -ptrValue[8];
                ptrResult[9] = -ptrValue[9];
                ptrResult[10] = -ptrValue[10];
                ptrResult[11] = -ptrValue[11];
                ptrResult[12] = -ptrValue[12];
                ptrResult[13] = -ptrValue[13];
                ptrResult[14] = -ptrValue[14];
                ptrResult[15] = -ptrValue[15];
                ptrResult += 16;
                ptrValue += 16;
            }
            ptrEnd += 8;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = -*ptrValue;
                ptrResult[1] = -ptrValue[1];
                ptrResult[2] = -ptrValue[2];
                ptrResult[3] = -ptrValue[3];
                ptrResult[4] = -ptrValue[4];
                ptrResult[5] = -ptrValue[5];
                ptrResult[6] = -ptrValue[6];
                ptrResult[7] = -ptrValue[7];
                ptrResult += 8;
                ptrValue += 8;
            }
            ptrEnd += 4;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = -*ptrValue;
                ptrResult[1] = -ptrValue[1];
                ptrResult[2] = -ptrValue[2];
                ptrResult[3] = -ptrValue[3];
                ptrResult += 4;
                ptrValue += 4;
            }
            ptrEnd += 2;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = -*ptrValue;
                ptrResult[1] = -ptrValue[1];
                ptrResult += 2;
                ptrValue += 2;
            }
            if (ptrResult == ptrEnd)
                *ptrResult = -*ptrValue;
        }
        unsafe internal static double DotMultiply(double* value1, double* value2, int length, int value1Start = 0, int value2Start = 0)
        {
            double* ptrValue1 = value1 + value1Start;
            double* ptrValue2 = value2 + value2Start;
            double result = 0;
            double* ptrEnd = ptrValue1 + length - 31;
            // Main loop, pointers for row values
            while (ptrValue1 < ptrEnd)
            {
                result += *ptrValue1 * *ptrValue2
                + *(ptrValue1 + 1) * *(ptrValue2 + 1)
                + *(ptrValue1 + 2) * *(ptrValue2 + 2)
                + *(ptrValue1 + 3) * *(ptrValue2 + 3);
                result += *(ptrValue1 + 4) * *(ptrValue2 + 4)
                + *(ptrValue1 + 5) * *(ptrValue2 + 5)
                + *(ptrValue1 + 6) * *(ptrValue2 + 6)
                + *(ptrValue1 + 7) * *(ptrValue2 + 7);
                result += *(ptrValue1 + 8) * *(ptrValue2 + 8)
                + *(ptrValue1 + 9) * *(ptrValue2 + 9)
                + *(ptrValue1 + 10) * *(ptrValue2 + 10)
                + *(ptrValue1 + 11) * *(ptrValue2 + 11);
                result += *(ptrValue1 + 12) * *(ptrValue2 + 12)
                + *(ptrValue1 + 13) * *(ptrValue2 + 13)
                + *(ptrValue1 + 14) * *(ptrValue2 + 14)
                + *(ptrValue1 + 15) * *(ptrValue2 + 15);
                result += *(ptrValue1 + 16) * *(ptrValue2 + 16)
                + *(ptrValue1 + 17) * *(ptrValue2 + 17)
                + *(ptrValue1 + 18) * *(ptrValue2 + 18)
                + *(ptrValue1 + 19) * *(ptrValue2 + 19);
                result += *(ptrValue1 + 20) * *(ptrValue2 + 20)
                + *(ptrValue1 + 21) * *(ptrValue2 + 21)
                + *(ptrValue1 + 22) * *(ptrValue2 + 22)
                + *(ptrValue1 + 23) * *(ptrValue2 + 23);
                result += *(ptrValue1 + 24) * *(ptrValue2 + 24)
                + *(ptrValue1 + 25) * *(ptrValue2 + 25)
                + *(ptrValue1 + 26) * *(ptrValue2 + 26)
                + *(ptrValue1 + 27) * *(ptrValue2 + 27);
                result += *(ptrValue1 + 28) * *(ptrValue2 + 28)
                + *(ptrValue1 + 29) * *(ptrValue2 + 29)
                + *(ptrValue1 + 30) * *(ptrValue2 + 30)
                + *(ptrValue1 + 31) * *(ptrValue2 + 31);
                ptrValue1 += 32;
                ptrValue2 += 32;
            }
            ptrEnd += 16;
            if (ptrValue1 < ptrEnd)
            {
                result += *ptrValue1 * *ptrValue2
                + *(ptrValue1 + 1) * *(ptrValue2 + 1)
                + *(ptrValue1 + 2) * *(ptrValue2 + 2)
                + *(ptrValue1 + 3) * *(ptrValue2 + 3);
                result += *(ptrValue1 + 4) * *(ptrValue2 + 4)
                + *(ptrValue1 + 5) * *(ptrValue2 + 5)
                + *(ptrValue1 + 6) * *(ptrValue2 + 6)
                + *(ptrValue1 + 7) * *(ptrValue2 + 7);
                result += *(ptrValue1 + 8) * *(ptrValue2 + 8)
                + *(ptrValue1 + 9) * *(ptrValue2 + 9)
                + *(ptrValue1 + 10) * *(ptrValue2 + 10)
                + *(ptrValue1 + 11) * *(ptrValue2 + 11);
                result += *(ptrValue1 + 12) * *(ptrValue2 + 12)
                + *(ptrValue1 + 13) * *(ptrValue2 + 13)
                + *(ptrValue1 + 14) * *(ptrValue2 + 14)
                + *(ptrValue1 + 15) * *(ptrValue2 + 15);
                ptrValue1 += 16;
                ptrValue2 += 16;
            }
            ptrEnd += 8;
            if (ptrValue1 < ptrEnd)
            {
                result += *ptrValue1 * *ptrValue2
                + *(ptrValue1 + 1) * *(ptrValue2 + 1)
                + *(ptrValue1 + 2) * *(ptrValue2 + 2)
                + *(ptrValue1 + 3) * *(ptrValue2 + 3);
                result += *(ptrValue1 + 4) * *(ptrValue2 + 4)
                + *(ptrValue1 + 5) * *(ptrValue2 + 5)
                + *(ptrValue1 + 6) * *(ptrValue2 + 6)
                + *(ptrValue1 + 7) * *(ptrValue2 + 7);
                ptrValue1 += 8;
                ptrValue2 += 8;
            }
            ptrEnd += 4;
            if (ptrValue1 < ptrEnd)
            {
                result += *ptrValue1 * *ptrValue2
                + *(ptrValue1 + 1) * *(ptrValue2 + 1)
                + *(ptrValue1 + 2) * *(ptrValue2 + 2)
                + *(ptrValue1 + 3) * *(ptrValue2 + 3);
                ptrValue1 += 4;
                ptrValue2 += 4;
            }
            ptrEnd += 2;
            if (ptrValue1 < ptrEnd)
            {
                result += *ptrValue1 * *ptrValue2
                + *(ptrValue1 + 1) * *(ptrValue2 + 1);
                ptrValue1 += 2;
                ptrValue2 += 2;
            }
            if (ptrValue1 == ptrEnd)
                result += *ptrValue1 * *ptrValue2;
            return result;
        }
        unsafe internal static void Multiply(double* value1, double* value2, double* result, int length, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            double* ptrValue1 = value1 + value1Index;
            double* ptrValue2 = value2 + value2Index;
            double* ptrResult = result + resultIndex;
            double* ptrEnd = ptrResult + length - 31;
            // Main loop, pointers for row values
            while (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * *ptrValue2;
                *(ptrResult + 1) = *(ptrValue1 + 1) * *(ptrValue2 + 1);
                *(ptrResult + 2) = *(ptrValue1 + 2) * *(ptrValue2 + 2);
                *(ptrResult + 3) = *(ptrValue1 + 3) * *(ptrValue2 + 3);
                *(ptrResult + 4) = *(ptrValue1 + 4) * *(ptrValue2 + 4);
                *(ptrResult + 5) = *(ptrValue1 + 5) * *(ptrValue2 + 5);
                *(ptrResult + 6) = *(ptrValue1 + 6) * *(ptrValue2 + 6);
                *(ptrResult + 7) = *(ptrValue1 + 7) * *(ptrValue2 + 7);
                *(ptrResult + 8) = *(ptrValue1 + 8) * *(ptrValue2 + 8);
                *(ptrResult + 9) = *(ptrValue1 + 9) * *(ptrValue2 + 9);
                *(ptrResult + 10) = *(ptrValue1 + 10) * *(ptrValue2 + 10);
                *(ptrResult + 11) = *(ptrValue1 + 11) * *(ptrValue2 + 11);
                *(ptrResult + 12) = *(ptrValue1 + 12) * *(ptrValue2 + 12);
                *(ptrResult + 13) = *(ptrValue1 + 13) * *(ptrValue2 + 13);
                *(ptrResult + 14) = *(ptrValue1 + 14) * *(ptrValue2 + 14);
                *(ptrResult + 15) = *(ptrValue1 + 15) * *(ptrValue2 + 15);
                *(ptrResult + 16) = *(ptrValue1 + 16) * *(ptrValue2 + 16);
                *(ptrResult + 17) = *(ptrValue1 + 17) * *(ptrValue2 + 17);
                *(ptrResult + 18) = *(ptrValue1 + 18) * *(ptrValue2 + 18);
                *(ptrResult + 19) = *(ptrValue1 + 19) * *(ptrValue2 + 19);
                *(ptrResult + 20) = *(ptrValue1 + 20) * *(ptrValue2 + 20);
                *(ptrResult + 21) = *(ptrValue1 + 21) * *(ptrValue2 + 21);
                *(ptrResult + 22) = *(ptrValue1 + 22) * *(ptrValue2 + 22);
                *(ptrResult + 23) = *(ptrValue1 + 23) * *(ptrValue2 + 23);
                *(ptrResult + 24) = *(ptrValue1 + 24) * *(ptrValue2 + 24);
                *(ptrResult + 25) = *(ptrValue1 + 25) * *(ptrValue2 + 25);
                *(ptrResult + 26) = *(ptrValue1 + 26) * *(ptrValue2 + 26);
                *(ptrResult + 27) = *(ptrValue1 + 27) * *(ptrValue2 + 27);
                *(ptrResult + 28) = *(ptrValue1 + 28) * *(ptrValue2 + 28);
                *(ptrResult + 29) = *(ptrValue1 + 29) * *(ptrValue2 + 29);
                *(ptrResult + 30) = *(ptrValue1 + 30) * *(ptrValue2 + 30);
                *(ptrResult + 31) = *(ptrValue1 + 31) * *(ptrValue2 + 31);
                ptrResult += 32;
                ptrValue1 += 32;
                ptrValue2 += 32;
            }
            ptrEnd += 16;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * *ptrValue2;
                *(ptrResult + 1) = *(ptrValue1 + 1) * *(ptrValue2 + 1);
                *(ptrResult + 2) = *(ptrValue1 + 2) * *(ptrValue2 + 2);
                *(ptrResult + 3) = *(ptrValue1 + 3) * *(ptrValue2 + 3);
                *(ptrResult + 4) = *(ptrValue1 + 4) * *(ptrValue2 + 4);
                *(ptrResult + 5) = *(ptrValue1 + 5) * *(ptrValue2 + 5);
                *(ptrResult + 6) = *(ptrValue1 + 6) * *(ptrValue2 + 6);
                *(ptrResult + 7) = *(ptrValue1 + 7) * *(ptrValue2 + 7);
                *(ptrResult + 8) = *(ptrValue1 + 8) * *(ptrValue2 + 8);
                *(ptrResult + 9) = *(ptrValue1 + 9) * *(ptrValue2 + 9);
                *(ptrResult + 10) = *(ptrValue1 + 10) * *(ptrValue2 + 10);
                *(ptrResult + 11) = *(ptrValue1 + 11) * *(ptrValue2 + 11);
                *(ptrResult + 12) = *(ptrValue1 + 12) * *(ptrValue2 + 12);
                *(ptrResult + 13) = *(ptrValue1 + 13) * *(ptrValue2 + 13);
                *(ptrResult + 14) = *(ptrValue1 + 14) * *(ptrValue2 + 14);
                *(ptrResult + 15) = *(ptrValue1 + 15) * *(ptrValue2 + 15);
                ptrResult += 16;
                ptrValue1 += 16;
                ptrValue2 += 16;
            }
            ptrEnd += 8;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * *ptrValue2;
                *(ptrResult + 1) = *(ptrValue1 + 1) * *(ptrValue2 + 1);
                *(ptrResult + 2) = *(ptrValue1 + 2) * *(ptrValue2 + 2);
                *(ptrResult + 3) = *(ptrValue1 + 3) * *(ptrValue2 + 3);
                *(ptrResult + 4) = *(ptrValue1 + 4) * *(ptrValue2 + 4);
                *(ptrResult + 5) = *(ptrValue1 + 5) * *(ptrValue2 + 5);
                *(ptrResult + 6) = *(ptrValue1 + 6) * *(ptrValue2 + 6);
                *(ptrResult + 7) = *(ptrValue1 + 7) * *(ptrValue2 + 7);
                ptrResult += 8;
                ptrValue1 += 8;
                ptrValue2 += 8;
            }
            ptrEnd += 4;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * *ptrValue2;
                *(ptrResult + 1) = *(ptrValue1 + 1) * *(ptrValue2 + 1);
                *(ptrResult + 2) = *(ptrValue1 + 2) * *(ptrValue2 + 2);
                *(ptrResult + 3) = *(ptrValue1 + 3) * *(ptrValue2 + 3);
                ptrResult += 4;
                ptrValue1 += 4;
                ptrValue2 += 4;
            }
            ptrEnd += 2;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * *ptrValue2;
                *(ptrResult + 1) = *(ptrValue1 + 1) * *(ptrValue2 + 1);
                ptrResult += 2;
                ptrValue1 += 2;
                ptrValue2 += 2;
            }
            if (ptrResult == ptrEnd)
                *ptrResult = *ptrValue1 * *ptrValue2;
        }
        unsafe internal static void Multiply(double* value1, double value2, double* result, int length, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            double* ptrValue1 = value1 + value1Index;
            double* ptrResult = result + resultIndex;
            double* ptrEnd = result + length - 31;
            // Main loop, pointers for row values
            while (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * value2;
                *(ptrResult + 1) = *(ptrValue1 + 1) * value2;
                *(ptrResult + 2) = *(ptrValue1 + 2) * value2;
                *(ptrResult + 3) = *(ptrValue1 + 3) * value2;
                *(ptrResult + 4) = *(ptrValue1 + 4) * value2;
                *(ptrResult + 5) = *(ptrValue1 + 5) * value2;
                *(ptrResult + 6) = *(ptrValue1 + 6) * value2;
                *(ptrResult + 7) = *(ptrValue1 + 7) * value2;
                *(ptrResult + 8) = *(ptrValue1 + 8) * value2;
                *(ptrResult + 9) = *(ptrValue1 + 9) * value2;
                *(ptrResult + 10) = *(ptrValue1 + 10) * value2;
                *(ptrResult + 11) = *(ptrValue1 + 11) * value2;
                *(ptrResult + 12) = *(ptrValue1 + 12) * value2;
                *(ptrResult + 13) = *(ptrValue1 + 13) * value2;
                *(ptrResult + 14) = *(ptrValue1 + 14) * value2;
                *(ptrResult + 15) = *(ptrValue1 + 15) * value2;
                *(ptrResult + 16) = *(ptrValue1 + 16) * value2;
                *(ptrResult + 17) = *(ptrValue1 + 17) * value2;
                *(ptrResult + 18) = *(ptrValue1 + 18) * value2;
                *(ptrResult + 19) = *(ptrValue1 + 19) * value2;
                *(ptrResult + 20) = *(ptrValue1 + 20) * value2;
                *(ptrResult + 21) = *(ptrValue1 + 21) * value2;
                *(ptrResult + 22) = *(ptrValue1 + 22) * value2;
                *(ptrResult + 23) = *(ptrValue1 + 23) * value2;
                *(ptrResult + 24) = *(ptrValue1 + 24) * value2;
                *(ptrResult + 25) = *(ptrValue1 + 25) * value2;
                *(ptrResult + 26) = *(ptrValue1 + 26) * value2;
                *(ptrResult + 27) = *(ptrValue1 + 27) * value2;
                *(ptrResult + 28) = *(ptrValue1 + 28) * value2;
                *(ptrResult + 29) = *(ptrValue1 + 29) * value2;
                *(ptrResult + 30) = *(ptrValue1 + 30) * value2;
                *(ptrResult + 31) = *(ptrValue1 + 31) * value2;
                ptrResult += 32;
                ptrValue1 += 32;
            }
            ptrEnd += 16;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * value2;
                *(ptrResult + 1) = *(ptrValue1 + 1) * value2;
                *(ptrResult + 2) = *(ptrValue1 + 2) * value2;
                *(ptrResult + 3) = *(ptrValue1 + 3) * value2;
                *(ptrResult + 4) = *(ptrValue1 + 4) * value2;
                *(ptrResult + 5) = *(ptrValue1 + 5) * value2;
                *(ptrResult + 6) = *(ptrValue1 + 6) * value2;
                *(ptrResult + 7) = *(ptrValue1 + 7) * value2;
                *(ptrResult + 8) = *(ptrValue1 + 8) * value2;
                *(ptrResult + 9) = *(ptrValue1 + 9) * value2;
                *(ptrResult + 10) = *(ptrValue1 + 10) * value2;
                *(ptrResult + 11) = *(ptrValue1 + 11) * value2;
                *(ptrResult + 12) = *(ptrValue1 + 12) * value2;
                *(ptrResult + 13) = *(ptrValue1 + 13) * value2;
                *(ptrResult + 14) = *(ptrValue1 + 14) * value2;
                *(ptrResult + 15) = *(ptrValue1 + 15) * value2;
                ptrResult += 16;
                ptrValue1 += 16;
            }
            ptrEnd += 8;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * value2;
                *(ptrResult + 1) = *(ptrValue1 + 1) * value2;
                *(ptrResult + 2) = *(ptrValue1 + 2) * value2;
                *(ptrResult + 3) = *(ptrValue1 + 3) * value2;
                *(ptrResult + 4) = *(ptrValue1 + 4) * value2;
                *(ptrResult + 5) = *(ptrValue1 + 5) * value2;
                *(ptrResult + 6) = *(ptrValue1 + 6) * value2;
                *(ptrResult + 7) = *(ptrValue1 + 7) * value2;
                ptrResult += 8;
                ptrValue1 += 8;
            }
            ptrEnd += 4;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * value2;
                *(ptrResult + 1) = *(ptrValue1 + 1) * value2;
                *(ptrResult + 2) = *(ptrValue1 + 2) * value2;
                *(ptrResult + 3) = *(ptrValue1 + 3) * value2;
                ptrResult += 4;
                ptrValue1 += 4;
            }
            ptrEnd += 2;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 * value2;
                *(ptrResult + 1) = *(ptrValue1 + 1) * value2;
                ptrResult += 2;
                ptrValue1 += 2;
            }
            if (ptrResult == ptrEnd)
                *ptrResult = *ptrValue1 * value2;
        }
        unsafe internal static void Division(double* value1, double* value2, double* result, int length, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            double* ptrValue1 = value1 + value1Index;
            double* ptrValue2 = value2 + value2Index;
            double* ptrResult = result + resultIndex;
            double* ptrEnd = ptrResult + length - 31;
            // Main loop, pointers for row values
            while (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 / *ptrValue2;
                *(ptrResult + 1) = *(ptrValue1 + 1) / *(ptrValue2 + 1);
                *(ptrResult + 2) = *(ptrValue1 + 2) / *(ptrValue2 + 2);
                *(ptrResult + 3) = *(ptrValue1 + 3) / *(ptrValue2 + 3);
                *(ptrResult + 4) = *(ptrValue1 + 4) / *(ptrValue2 + 4);
                *(ptrResult + 5) = *(ptrValue1 + 5) / *(ptrValue2 + 5);
                *(ptrResult + 6) = *(ptrValue1 + 6) / *(ptrValue2 + 6);
                *(ptrResult + 7) = *(ptrValue1 + 7) / *(ptrValue2 + 7);
                *(ptrResult + 8) = *(ptrValue1 + 8) / *(ptrValue2 + 8);
                *(ptrResult + 9) = *(ptrValue1 + 9) / *(ptrValue2 + 9);
                *(ptrResult + 10) = *(ptrValue1 + 10) / *(ptrValue2 + 10);
                *(ptrResult + 11) = *(ptrValue1 + 11) / *(ptrValue2 + 11);
                *(ptrResult + 12) = *(ptrValue1 + 12) / *(ptrValue2 + 12);
                *(ptrResult + 13) = *(ptrValue1 + 13) / *(ptrValue2 + 13);
                *(ptrResult + 14) = *(ptrValue1 + 14) / *(ptrValue2 + 14);
                *(ptrResult + 15) = *(ptrValue1 + 15) / *(ptrValue2 + 15);
                *(ptrResult + 16) = *(ptrValue1 + 16) / *(ptrValue2 + 16);
                *(ptrResult + 17) = *(ptrValue1 + 17) / *(ptrValue2 + 17);
                *(ptrResult + 18) = *(ptrValue1 + 18) / *(ptrValue2 + 18);
                *(ptrResult + 19) = *(ptrValue1 + 19) / *(ptrValue2 + 19);
                *(ptrResult + 20) = *(ptrValue1 + 20) / *(ptrValue2 + 20);
                *(ptrResult + 21) = *(ptrValue1 + 21) / *(ptrValue2 + 21);
                *(ptrResult + 22) = *(ptrValue1 + 22) / *(ptrValue2 + 22);
                *(ptrResult + 23) = *(ptrValue1 + 23) / *(ptrValue2 + 23);
                *(ptrResult + 24) = *(ptrValue1 + 24) / *(ptrValue2 + 24);
                *(ptrResult + 25) = *(ptrValue1 + 25) / *(ptrValue2 + 25);
                *(ptrResult + 26) = *(ptrValue1 + 26) / *(ptrValue2 + 26);
                *(ptrResult + 27) = *(ptrValue1 + 27) / *(ptrValue2 + 27);
                *(ptrResult + 28) = *(ptrValue1 + 28) / *(ptrValue2 + 28);
                *(ptrResult + 29) = *(ptrValue1 + 29) / *(ptrValue2 + 29);
                *(ptrResult + 30) = *(ptrValue1 + 30) / *(ptrValue2 + 30);
                *(ptrResult + 31) = *(ptrValue1 + 31) / *(ptrValue2 + 31);
                ptrResult += 32;
                ptrValue1 += 32;
                ptrValue2 += 32;
            }
            ptrEnd += 16;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 / *ptrValue2;
                *(ptrResult + 1) = *(ptrValue1 + 1) / *(ptrValue2 + 1);
                *(ptrResult + 2) = *(ptrValue1 + 2) / *(ptrValue2 + 2);
                *(ptrResult + 3) = *(ptrValue1 + 3) / *(ptrValue2 + 3);
                *(ptrResult + 4) = *(ptrValue1 + 4) / *(ptrValue2 + 4);
                *(ptrResult + 5) = *(ptrValue1 + 5) / *(ptrValue2 + 5);
                *(ptrResult + 6) = *(ptrValue1 + 6) / *(ptrValue2 + 6);
                *(ptrResult + 7) = *(ptrValue1 + 7) / *(ptrValue2 + 7);
                *(ptrResult + 8) = *(ptrValue1 + 8) / *(ptrValue2 + 8);
                *(ptrResult + 9) = *(ptrValue1 + 9) / *(ptrValue2 + 9);
                *(ptrResult + 10) = *(ptrValue1 + 10) / *(ptrValue2 + 10);
                *(ptrResult + 11) = *(ptrValue1 + 11) / *(ptrValue2 + 11);
                *(ptrResult + 12) = *(ptrValue1 + 12) / *(ptrValue2 + 12);
                *(ptrResult + 13) = *(ptrValue1 + 13) / *(ptrValue2 + 13);
                *(ptrResult + 14) = *(ptrValue1 + 14) / *(ptrValue2 + 14);
                *(ptrResult + 15) = *(ptrValue1 + 15) / *(ptrValue2 + 15);
                ptrResult += 16;
                ptrValue1 += 16;
                ptrValue2 += 16;
            }
            ptrEnd += 8;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 / *ptrValue2;
                *(ptrResult + 1) = *(ptrValue1 + 1) / *(ptrValue2 + 1);
                *(ptrResult + 2) = *(ptrValue1 + 2) / *(ptrValue2 + 2);
                *(ptrResult + 3) = *(ptrValue1 + 3) / *(ptrValue2 + 3);
                *(ptrResult + 4) = *(ptrValue1 + 4) / *(ptrValue2 + 4);
                *(ptrResult + 5) = *(ptrValue1 + 5) / *(ptrValue2 + 5);
                *(ptrResult + 6) = *(ptrValue1 + 6) / *(ptrValue2 + 6);
                *(ptrResult + 7) = *(ptrValue1 + 7) / *(ptrValue2 + 7);
                ptrResult += 8;
                ptrValue1 += 8;
                ptrValue2 += 8;
            }
            ptrEnd += 4;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 / *ptrValue2;
                *(ptrResult + 1) = *(ptrValue1 + 1) / *(ptrValue2 + 1);
                *(ptrResult + 2) = *(ptrValue1 + 2) / *(ptrValue2 + 2);
                *(ptrResult + 3) = *(ptrValue1 + 3) / *(ptrValue2 + 3);
                ptrResult += 4;
                ptrValue1 += 4;
                ptrValue2 += 4;
            }
            ptrEnd += 2;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 / *ptrValue2;
                *(ptrResult + 1) = *(ptrValue1 + 1) / *(ptrValue2 + 1);
                ptrResult += 2;
                ptrValue1 += 2;
                ptrValue2 += 2;
            }
            if (ptrResult == ptrEnd)
                *ptrResult = *ptrValue1 / *ptrValue2;
        }
        unsafe internal static void Inverse(double* value, double* result, int length, int valueIndex = 0, int resultIndex = 0)
        {
            double* ptrValue = value + valueIndex;
            double* ptrResult = result + resultIndex;
            double* ptrEnd = result + length - 31;
            // Main loop, pointers for row values
            while (ptrResult < ptrEnd)
            {
                *ptrResult = 1 / *ptrValue;
                *(ptrResult + 1) = 1 / *(ptrValue + 1);
                *(ptrResult + 2) = 1 / *(ptrValue + 2);
                *(ptrResult + 3) = 1 / *(ptrValue + 3);
                *(ptrResult + 4) = 1 / *(ptrValue + 4);
                *(ptrResult + 5) = 1 / *(ptrValue + 5);
                *(ptrResult + 6) = 1 / *(ptrValue + 6);
                *(ptrResult + 7) = 1 / *(ptrValue + 7);
                *(ptrResult + 8) = 1 / *(ptrValue + 8);
                *(ptrResult + 9) = 1 / *(ptrValue + 9);
                *(ptrResult + 10) = 1 / *(ptrValue + 10);
                *(ptrResult + 11) = 1 / *(ptrValue + 11);
                *(ptrResult + 12) = 1 / *(ptrValue + 12);
                *(ptrResult + 13) = 1 / *(ptrValue + 13);
                *(ptrResult + 14) = 1 / *(ptrValue + 14);
                *(ptrResult + 15) = 1 / *(ptrValue + 15);
                *(ptrResult + 16) = 1 / *(ptrValue + 16);
                *(ptrResult + 17) = 1 / *(ptrValue + 17);
                *(ptrResult + 18) = 1 / *(ptrValue + 18);
                *(ptrResult + 19) = 1 / *(ptrValue + 19);
                *(ptrResult + 20) = 1 / *(ptrValue + 20);
                *(ptrResult + 21) = 1 / *(ptrValue + 21);
                *(ptrResult + 22) = 1 / *(ptrValue + 22);
                *(ptrResult + 23) = 1 / *(ptrValue + 23);
                *(ptrResult + 24) = 1 / *(ptrValue + 24);
                *(ptrResult + 25) = 1 / *(ptrValue + 25);
                *(ptrResult + 26) = 1 / *(ptrValue + 26);
                *(ptrResult + 27) = 1 / *(ptrValue + 27);
                *(ptrResult + 28) = 1 / *(ptrValue + 28);
                *(ptrResult + 29) = 1 / *(ptrValue + 29);
                *(ptrResult + 30) = 1 / *(ptrValue + 30);
                *(ptrResult + 31) = 1 / *(ptrValue + 31);
                ptrResult += 32;
                ptrValue += 32;
            }
            ptrEnd += 16;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = 1 / *ptrValue;
                *(ptrResult + 1) = 1 / *(ptrValue + 1);
                *(ptrResult + 2) = 1 / *(ptrValue + 2);
                *(ptrResult + 3) = 1 / *(ptrValue + 3);
                *(ptrResult + 4) = 1 / *(ptrValue + 4);
                *(ptrResult + 5) = 1 / *(ptrValue + 5);
                *(ptrResult + 6) = 1 / *(ptrValue + 6);
                *(ptrResult + 7) = 1 / *(ptrValue + 7);
                *(ptrResult + 8) = 1 / *(ptrValue + 8);
                *(ptrResult + 9) = 1 / *(ptrValue + 9);
                *(ptrResult + 10) = 1 / *(ptrValue + 10);
                *(ptrResult + 11) = 1 / *(ptrValue + 11);
                *(ptrResult + 12) = 1 / *(ptrValue + 12);
                *(ptrResult + 13) = 1 / *(ptrValue + 13);
                *(ptrResult + 14) = 1 / *(ptrValue + 14);
                *(ptrResult + 15) = 1 / *(ptrValue + 15);
                ptrResult += 16;
                ptrValue += 16;
            }
            ptrEnd += 8;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = 1 / *ptrValue;
                *(ptrResult + 1) = 1 / *(ptrValue + 1);
                *(ptrResult + 2) = 1 / *(ptrValue + 2);
                *(ptrResult + 3) = 1 / *(ptrValue + 3);
                *(ptrResult + 4) = 1 / *(ptrValue + 4);
                *(ptrResult + 5) = 1 / *(ptrValue + 5);
                *(ptrResult + 6) = 1 / *(ptrValue + 6);
                *(ptrResult + 7) = 1 / *(ptrValue + 7);
                ptrResult += 8;
                ptrValue += 8;
            }
            ptrEnd += 4;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = 1 / *ptrValue;
                *(ptrResult + 1) = 1 / *(ptrValue + 1);
                *(ptrResult + 2) = 1 / *(ptrValue + 2);
                *(ptrResult + 3) = 1 / *(ptrValue + 3);
                ptrResult += 4;
                ptrValue += 4;
            }
            ptrEnd += 2;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = 1 / *ptrValue;
                *(ptrResult + 1) = 1 / *(ptrValue + 1);
                ptrResult += 2;
                ptrValue += 2;
            }
            if (ptrResult == ptrEnd)
                *ptrResult = 1 / *ptrValue;
        }
        unsafe internal static bool Equal(double* value1, double* value2, int length, int value1Index = 0, int value2Index = 0)
        {
            double* ptrValue1 = value1 + value1Index;
            double* ptrValue2 = value2 + value2Index;
            double* ptrEnd = ptrValue1 + length - 31;
            bool result = true;
            // Main loop, pointers for row values
            while (ptrValue1 < ptrEnd)
            {
                result &= *ptrValue1 == *ptrValue2;
                result &= ptrValue1[1] == ptrValue2[1];
                result &= ptrValue1[2] == ptrValue2[2];
                result &= ptrValue1[3] == ptrValue2[3];
                result &= ptrValue1[4] == ptrValue2[4];
                result &= ptrValue1[5] == ptrValue2[5];
                result &= ptrValue1[6] == ptrValue2[6];
                result &= ptrValue1[7] == ptrValue2[7];
                if (!result)
                    return false;
                result &= ptrValue1[8] == ptrValue2[8];
                result &= ptrValue1[9] == ptrValue2[9];
                result &= ptrValue1[10] == ptrValue2[10];
                result &= ptrValue1[11] == ptrValue2[11];
                result &= ptrValue1[12] == ptrValue2[12];
                result &= ptrValue1[13] == ptrValue2[13];
                result &= ptrValue1[14] == ptrValue2[14];
                result &= ptrValue1[15] == ptrValue2[15];
                if (!result)
                    return false;
                result &= ptrValue1[16] == ptrValue2[16];
                result &= ptrValue1[17] == ptrValue2[17];
                result &= ptrValue1[18] == ptrValue2[18];
                result &= ptrValue1[19] == ptrValue2[19];
                result &= ptrValue1[20] == ptrValue2[20];
                result &= ptrValue1[21] == ptrValue2[21];
                result &= ptrValue1[22] == ptrValue2[22];
                result &= ptrValue1[23] == ptrValue2[23];
                if (!result)
                    return false;
                result &= ptrValue1[24] == ptrValue2[24];
                result &= ptrValue1[25] == ptrValue2[25];
                result &= ptrValue1[26] == ptrValue2[26];
                result &= ptrValue1[27] == ptrValue2[27];
                result &= ptrValue1[28] == ptrValue2[28];
                result &= ptrValue1[29] == ptrValue2[29];
                result &= ptrValue1[30] == ptrValue2[30];
                result &= ptrValue1[31] == ptrValue2[31];
                if (!result)
                    return false;
                ptrValue1 += 32;
                ptrValue2 += 32;
            }
            ptrEnd += 16;
            if (ptrValue1 < ptrEnd)
            {
                result &= *ptrValue1 == *ptrValue2;
                result &= ptrValue1[1] == ptrValue2[1];
                result &= ptrValue1[2] == ptrValue2[2];
                result &= ptrValue1[3] == ptrValue2[3];
                result &= ptrValue1[4] == ptrValue2[4];
                result &= ptrValue1[5] == ptrValue2[5];
                result &= ptrValue1[6] == ptrValue2[6];
                result &= ptrValue1[7] == ptrValue2[7];
                if (!result)
                    return false;
                result &= ptrValue1[8] == ptrValue2[8];
                result &= ptrValue1[9] == ptrValue2[9];
                result &= ptrValue1[10] == ptrValue2[10];
                result &= ptrValue1[11] == ptrValue2[11];
                result &= ptrValue1[12] == ptrValue2[12];
                result &= ptrValue1[13] == ptrValue2[13];
                result &= ptrValue1[14] == ptrValue2[14];
                result &= ptrValue1[15] == ptrValue2[15];
                ptrValue1 += 16;
                ptrValue2 += 16;
            }
            if (!result)
                return false;
            ptrEnd += 8;
            if (ptrValue1 < ptrEnd)
            {
                result &= *ptrValue1 == *ptrValue2;
                result &= ptrValue1[1] == ptrValue2[1];
                result &= ptrValue1[2] == ptrValue2[2];
                result &= ptrValue1[3] == ptrValue2[3];
                result &= ptrValue1[4] == ptrValue2[4];
                result &= ptrValue1[5] == ptrValue2[5];
                result &= ptrValue1[6] == ptrValue2[6];
                result &= ptrValue1[7] == ptrValue2[7];
                ptrValue1 += 8;
                ptrValue2 += 8;
            }
            if (!result)
                return false;
            ptrEnd += 4;
            if (ptrValue1 < ptrEnd)
            {
                result &= *ptrValue1 == *ptrValue2;
                result &= ptrValue1[1] == ptrValue2[1];
                result &= ptrValue1[2] == ptrValue2[2];
                result &= ptrValue1[3] == ptrValue2[3];
                ptrValue1 += 4;
                ptrValue2 += 4;
            }
            ptrEnd += 2;
            if (ptrValue1 < ptrEnd)
            {
                result &= *ptrValue1 == *ptrValue2;
                result &= ptrValue1[1] == ptrValue2[1];
                ptrValue1 += 2;
                ptrValue2 += 2;
            }
            if (ptrValue1 == ptrEnd)
                result &= *ptrValue1 == *ptrValue2;
            return result;
        }
        #endregion Internal methods
        #region Private methods
        #endregion Private methods
        #region Events, overrides
        #endregion Events, overrides
        #endregion Methods
    }
}
#endregion Working namespace