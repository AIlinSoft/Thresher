﻿#region License
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
using Th = AIlins.Thresher.ThrowHelper<AIlins.Thresher.Block2x2>;
#endregion Using namespaces
#region Working namespace
namespace AIlins.Thresher
{
    /// <summary>
    /// Array group operations optimized helper
    /// </summary>
    public class Block2x2ArraySolver : ArraySolver<Block2x2>
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
        unsafe public virtual void Addition(double* value1, double value2, double* result, int length, int value1Index = 0, int resultIndex = 0)
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
        unsafe public virtual void Addition(double* value1, double value2, double value3, double* result, int length, int value1Index = 0, int resultIndex = 0)
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
        unsafe public virtual void Addition(double* value1, double value2, double value3, double value4, double value5, double* result, int length, int value1Index = 0, int resultIndex = 0)
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
        unsafe public virtual double Summary(double* value, int length, int valueIndex = 0)
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
        unsafe public virtual Complex Summary(Complex* value, int length, int valueIndex = 0)
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
        unsafe public virtual Block2x2 Summary(Block2x2* value, int length, int valueIndex = 0)
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
        /// <summary>
        /// Addition two matrix of real values
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        unsafe public virtual void Addition(double* value1, double* value2, double* result, int length, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
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
        unsafe public virtual void Substraction(double* value1, double* value2, double* result, int length, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
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
        unsafe public virtual void Negate(double* value, double* result, int length, int valueStart = 0, int resultStart = 0)
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
        unsafe public virtual void CycleAddition(double* value1, double* value2, double* result, int length, int size2, int value1Start = 0, int value2Start = 0, int resultStart = 0)
        {
            double f0 = *value2;
            double f1;
            double f2;
            double f3;
            if (length == 1)
            {
                f1 = *value2;
                f2 = *value2;
                f3 = *value2;
            }
            else
                if (length == 2)
                {
                    f1 = value2[1];
                    f2 = *value2;
                    f3 = value2[1];
                }
                else
                    if (length == 4)
                    {
                        f1 = value2[1];
                        f2 = value2[2];
                        f3 = value2[3];
                    }
                    else
                        return;
            double* ptrValue1 = value1 + value1Start;
            double* ptrResult = result + resultStart;
            double* ptrEnd = ptrResult + length - 31;
            // Main loop, pointers for row values
            while (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + f0;
                ptrResult[1] = ptrValue1[1] + f1;
                ptrResult[2] = ptrValue1[2] + f2;
                ptrResult[3] = ptrValue1[3] + f3;
                ptrResult[4] = ptrValue1[4] + f0;
                ptrResult[5] = ptrValue1[5] + f1;
                ptrResult[6] = ptrValue1[6] + f2;
                ptrResult[7] = ptrValue1[7] + f3;
                ptrResult[8] = ptrValue1[8] + f0;
                ptrResult[9] = ptrValue1[9] + f1;
                ptrResult[10] = ptrValue1[10] + f2;
                ptrResult[11] = ptrValue1[11] + f3;
                ptrResult[12] = ptrValue1[12] + f0;
                ptrResult[13] = ptrValue1[13] + f1;
                ptrResult[14] = ptrValue1[14] + f2;
                ptrResult[15] = ptrValue1[15] + f3;
                ptrResult[16] = ptrValue1[16] + f0;
                ptrResult[17] = ptrValue1[17] + f1;
                ptrResult[18] = ptrValue1[18] + f2;
                ptrResult[19] = ptrValue1[19] + f3;
                ptrResult[20] = ptrValue1[20] + f0;
                ptrResult[21] = ptrValue1[21] + f1;
                ptrResult[22] = ptrValue1[22] + f2;
                ptrResult[23] = ptrValue1[23] + f3;
                ptrResult[24] = ptrValue1[24] + f0;
                ptrResult[25] = ptrValue1[25] + f1;
                ptrResult[26] = ptrValue1[26] + f2;
                ptrResult[27] = ptrValue1[27] + f3;
                ptrResult[28] = ptrValue1[28] + f0;
                ptrResult[29] = ptrValue1[29] + f1;
                ptrResult[30] = ptrValue1[30] + f2;
                ptrResult[31] = ptrValue1[31] + f3;
                ptrResult += 32;
                ptrValue1 += 32;
            }
            ptrEnd += 16;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + f0;
                ptrResult[1] = ptrValue1[1] + f1;
                ptrResult[2] = ptrValue1[2] + f2;
                ptrResult[3] = ptrValue1[3] + f3;
                ptrResult[4] = ptrValue1[4] + f0;
                ptrResult[5] = ptrValue1[5] + f1;
                ptrResult[6] = ptrValue1[6] + f2;
                ptrResult[7] = ptrValue1[7] + f3;
                ptrResult[8] = ptrValue1[8] + f0;
                ptrResult[9] = ptrValue1[9] + f1;
                ptrResult[10] = ptrValue1[10] + f2;
                ptrResult[11] = ptrValue1[11] + f3;
                ptrResult[12] = ptrValue1[12] + f0;
                ptrResult[13] = ptrValue1[13] + f1;
                ptrResult[14] = ptrValue1[14] + f2;
                ptrResult[15] = ptrValue1[15] + f3;
                ptrResult += 16;
                ptrValue1 += 16;
            }
            ptrEnd += 8;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + f0;
                ptrResult[1] = ptrValue1[1] + f1;
                ptrResult[2] = ptrValue1[2] + f2;
                ptrResult[3] = ptrValue1[3] + f3;
                ptrResult[4] = ptrValue1[4] + f0;
                ptrResult[5] = ptrValue1[5] + f1;
                ptrResult[6] = ptrValue1[6] + f2;
                ptrResult[7] = ptrValue1[7] + f3;
                ptrResult += 8;
                ptrValue1 += 8;
            }
            ptrEnd += 4;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + f0;
                ptrResult[1] = ptrValue1[1] + f1;
                ptrResult[2] = ptrValue1[2] + f2;
                ptrResult[3] = ptrValue1[3] + f3;
                ptrResult += 4;
                ptrValue1 += 4;
            }
            ptrEnd += 2;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + f0;
                ptrResult[1] = ptrValue1[1] + f1;
                ptrResult += 2;
                ptrValue1 += 2;
            }
            if (ptrResult == ptrEnd)
                *ptrResult = *ptrValue1 + f0;
        }
        unsafe public virtual double DotMultiply(double* value1, double* value2, int length, int value1Start = 0, int value2Start = 0)
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
        unsafe public virtual void Multiply(double* value1, double* value2, double* result, int length, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
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
        unsafe public virtual void Multiply(Complex* value1, Complex* value2, Complex* result, int length, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
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
        unsafe public virtual void Multiply(Block2x2* value1, Block2x2* value2, Block2x2* result, int length, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
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
        unsafe public virtual void Multiply(double* value1, double value2, double* result, int length, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
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
        unsafe public virtual void Multiply(Complex* value1, Complex value2, Complex* result, int length, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
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
        unsafe public virtual void Multiply(Block2x2* value1, Block2x2 value2, Block2x2* result, int length, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
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
        unsafe public virtual void Division(double* value1, double* value2, double* result, int length, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
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
        unsafe public virtual void Division(Complex* value1, Complex* value2, Complex* result, int length, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
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
        unsafe public virtual void Division(Block2x2* value1, Block2x2* value2, Block2x2* result, int length, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
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
        unsafe public virtual void Conjugate(Complex* value, Complex* result, int length, int valueIndex = 0, int resultIndex = 0)
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
        unsafe public virtual void Inverse(double* value, double* result, int length, int valueIndex = 0, int resultIndex = 0)
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
        unsafe public virtual void Inverse(Complex* value, Complex* result, int length, int valueIndex = 0, int resultIndex = 0)
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
        unsafe public virtual void Inverse(Block2x2* value, Block2x2* result, int length, int valueIndex = 0, int resultIndex = 0)
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
        unsafe public virtual bool Equal(int size, double* value1, double* value2)
        {
            for (int i = 0; i < size; ++i)
            {
                if (value1[i] != value2[i])
                    return false;
            }
            return true;
        }
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
        unsafe public override void Addition(Block2x2[] value1, Block2x2[] value2, Block2x2[] result = null, int length = int.MaxValue, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            Th.ThrowIfTwoValuesWithNullableResult(value1, value2, ref result, ref length, value1Index, value2Index, resultIndex);
            fixed (Block2x2* value1Ptr = value1, value2Ptr = value2, resultPtr = result)
                Addition((double*)value1Ptr, (double*)value2Ptr, (double*)resultPtr, length * 4, value1Index * 4, value2Index * 4, resultIndex * 4);
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
        unsafe public override void Addition(Block2x2[] value1, Block2x2 value2, Block2x2[] result = null, int length = int.MaxValue, int value1Index = 0, int resultIndex = 0)
        {
            Th.ThrowOneValueWithNullableResult(value1, ref result, ref length, value1Index, resultIndex);
            fixed (Block2x2* value1Ptr = value1, resultPtr = result)
                Addition((double*)value1Ptr, value2.f00, value2.f01, value2.f10, value2.f11, (double*)resultPtr, length * 4, value1Index * 4, resultIndex * 4);
        }
        /// <summary>
        /// Summarizes the elements of the array <paramref name="value"/>
        /// </summary>
        /// <param name="value">The array to summariez</param>
        /// <param name="length">A 32-bit integer that represents the number of elements to summariez</param>
        /// <param name="valueIndex">A 32-bit integer that represents the index in the <paramref name="value"/> array at which summariez begins</param>
        /// <returns>Result of the elements summariez</returns>
        unsafe public override Block2x2 Summary(Block2x2[] value, int length = int.MaxValue, int valueIndex = 0)
        {
            Th.ThrowIfOneValue(value, ref length, valueIndex);
            Block2x2 returnValue = 0;
            fixed (Block2x2* valuePtr = value)
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
        unsafe public override void Substraction(Block2x2[] value1, Block2x2[] value2, Block2x2[] result = null, int length = int.MaxValue, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            Th.ThrowIfTwoValuesWithNullableResult(value1, value2, ref result, ref length, value1Index, value2Index, resultIndex);
            fixed (Block2x2* value1Ptr = value1, value2Ptr = value2, resultPtr = result)
                Substraction((double*)value1Ptr, (double*)value2Ptr, (double*)resultPtr, length * 4, value1Index * 4, value2Index * 4, resultIndex * 4);
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
        unsafe public override void Negation(Block2x2[] value, Block2x2[] result = null, int length = int.MaxValue, int valueIndex = 0, int resultIndex = 0)
        {
            Th.ThrowOneValueWithNullableResult(value, ref result, ref length, valueIndex, resultIndex);
            fixed (Block2x2* valuePtr = value, resultPtr = result)
                Negate((double*)valuePtr, (double*)resultPtr, length * 4, valueIndex * 4, resultIndex * 4);
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
        unsafe public override void Multiply(Block2x2[] value1, Block2x2[] value2, Block2x2[] result = null, int length = int.MaxValue, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            Th.ThrowIfTwoValuesWithNullableResult(value1, value2, ref result, ref length, value1Index, value2Index, resultIndex);
            fixed (Block2x2* value1Ptr = value1, value2Ptr = value2, resultPtr = result)
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
        unsafe public override void Multiply(Block2x2[] value1, Block2x2 value2, Block2x2[] result = null, int length = int.MaxValue, int value1Index = 0, int resultIndex = 0)
        {
            Th.ThrowOneValueWithNullableResult(value1, ref result, ref length, value1Index, resultIndex);
            fixed (Block2x2* value1Ptr = value1, resultPtr = result)
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
        unsafe public override void Division(Block2x2[] value1, Block2x2[] value2, Block2x2[] result = null, int length = int.MaxValue, int value1Index = 0, int value2Index = 0, int resultIndex = 0)
        {
            Th.ThrowIfTwoValuesWithNullableResult(value1, value2, ref result, ref length, value1Index, value2Index, resultIndex);
            fixed (Block2x2* value1Ptr = value1, value2Ptr = value2, resultPtr = result)
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
        unsafe public override void Inversion(Block2x2[] value, Block2x2[] result = null, int length = int.MaxValue, int valueIndex = 0, int resultIndex = 0)
        {
            Th.ThrowOneValueWithNullableResult(value, ref result, ref length, valueIndex, resultIndex);
            fixed (Block2x2* valuePtr = value, resultPtr = result)
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
        unsafe public override void From<K>(K[] value, Block2x2[] result, int length = int.MaxValue, int valueIndex = 0, int resultIndex = 0)
        {
            Th.ThrowOneValueWithoutNullableResult<K>(value, result, ref length, valueIndex, resultIndex);
            if (typeof(K) == typeof(double))
            {
                double[] doubleValue = value as double[];
                fixed (double* valuePtr = doubleValue)
                fixed (Block2x2* resultPtr = result)
                {
                    double* valuePtr1 = valuePtr + valueIndex;
                    double* resultPtr1 = (double*)(resultPtr + resultIndex);
                    length *= 4;
                    for (int i = 0, j = 0; i < length; i += 4, ++j)
                    {
                        resultPtr1[i] = resultPtr1[i + 3] = valuePtr1[j];
                        resultPtr1[i + 1] = resultPtr1[i + 2] = 0;
                    }
                }
            }
            else
                if (typeof(K) == typeof(Complex))
                {
                    Complex[] complexValue = value as Complex[];
                    fixed (Complex* valuePtr = complexValue)
                    fixed (Block2x2* resultPtr = result)
                    {
                        double* valuePtr1 = (double*)(valuePtr + valueIndex);
                        double* resultPtr1 = (double*)(resultPtr + resultIndex);
                        length *= 4;
                        double temp;
                        for (int i = 0, j = 0; i < length; i += 4, j += 2)
                        {
                            resultPtr1[i + 3] = resultPtr1[i] = valuePtr1[j];
                            temp = valuePtr1[j + 1];
                            resultPtr1[i + 1] = -temp;
                            resultPtr1[i + 2] = temp;
                        }
                    }
                }
                else
                    if (typeof(K) == typeof(Block2x2))
                    {
                        Block2x2[] block2x2Value = value as Block2x2[];
                        fixed (Block2x2* valuePtr = block2x2Value)
                        fixed (Block2x2* resultPtr = result)
                        {
                            double* valuePtr1 = (double*)(valuePtr + valueIndex);
                            double* resultPtr1 = (double*)(resultPtr + resultIndex);
                            length *= 4;
                            for (int i = 0; i < length; i += 4)
                            {
                                resultPtr1[i] = valuePtr1[i];
                                resultPtr1[i + 1] = valuePtr1[i + 1];
                                resultPtr1[i + 2] = valuePtr1[i + 2];
                                resultPtr1[i + 3] = valuePtr1[i + 3];
                            }
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
        unsafe public override void Set(Block2x2[] value1, Block2x2 value2 = default(Block2x2), int length = int.MaxValue, int value1Index = 0)
        {
            Th.ThrowIfOneValue(value1, ref length, value1Index);
            int end = value1Index + length;
            fixed (Block2x2* valuePtr = value1)
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
        unsafe public override bool Equality(Block2x2[] value1, Block2x2[] value2, int length = int.MaxValue, int value1Index = 0, int value2Index = 0)
        {
            Th.ThrowIfTwoValues(value1, value2, ref length, value1Index, value2Index);
            bool returnValue;
            fixed (Block2x2* value1Ptr = value1, value2Ptr = value2)
                returnValue = Equal((double*)value1Ptr, (double*)value2Ptr, length * 4, value1Index * 4, value2Index * 4);
            return returnValue;
        }
        #endregion Events, overrides
        #endregion Methods
    }
}
#endregion Working namespace