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
    public class MatrixHelper
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
        unsafe public static void Addition(double* value1, double value2, double* result, int size)
        {
            double* ptrValue1 = value1;
            double* ptrResult = result;
            double* ptrEnd = result + size - 31;
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
        unsafe public static void Addition(Complex* value1, Complex value2, Complex* result, int size)
        {
            double real = value2.Real;
            double imaginary = value2.Imaginary;
            double* ptrValue1 = (double*)value1;
            double* ptrResult = (double*)result;
            double* ptrEnd = (double*)(result + size) - 31;
            // Main loop, pointers for row values
            while (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + real;
                *(ptrResult + 1) = *(ptrValue1 + 1) + imaginary;
                *(ptrResult + 2) = *(ptrValue1 + 2) + real;
                *(ptrResult + 3) = *(ptrValue1 + 3) + imaginary;
                *(ptrResult + 4) = *(ptrValue1 + 4) + real;
                *(ptrResult + 5) = *(ptrValue1 + 5) + imaginary;
                *(ptrResult + 6) = *(ptrValue1 + 6) + real;
                *(ptrResult + 7) = *(ptrValue1 + 7) + imaginary;
                *(ptrResult + 8) = *(ptrValue1 + 8) + real;
                *(ptrResult + 9) = *(ptrValue1 + 9) + imaginary;
                *(ptrResult + 10) = *(ptrValue1 + 10) + real;
                *(ptrResult + 11) = *(ptrValue1 + 11) + imaginary;
                *(ptrResult + 12) = *(ptrValue1 + 12) + real;
                *(ptrResult + 13) = *(ptrValue1 + 13) + imaginary;
                *(ptrResult + 14) = *(ptrValue1 + 14) + real;
                *(ptrResult + 15) = *(ptrValue1 + 15) + imaginary;
                *(ptrResult + 16) = *(ptrValue1 + 16) + real;
                *(ptrResult + 17) = *(ptrValue1 + 17) + imaginary;
                *(ptrResult + 18) = *(ptrValue1 + 18) + real;
                *(ptrResult + 19) = *(ptrValue1 + 19) + imaginary;
                *(ptrResult + 20) = *(ptrValue1 + 20) + real;
                *(ptrResult + 21) = *(ptrValue1 + 21) + imaginary;
                *(ptrResult + 22) = *(ptrValue1 + 22) + real;
                *(ptrResult + 23) = *(ptrValue1 + 23) + imaginary;
                *(ptrResult + 24) = *(ptrValue1 + 24) + real;
                *(ptrResult + 25) = *(ptrValue1 + 25) + imaginary;
                *(ptrResult + 26) = *(ptrValue1 + 26) + real;
                *(ptrResult + 27) = *(ptrValue1 + 27) + imaginary;
                *(ptrResult + 28) = *(ptrValue1 + 28) + real;
                *(ptrResult + 29) = *(ptrValue1 + 29) + imaginary;
                *(ptrResult + 30) = *(ptrValue1 + 30) + real;
                *(ptrResult + 31) = *(ptrValue1 + 31) + imaginary;
                ptrResult += 32;
                ptrValue1 += 32;
            }
            ptrEnd += 16;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + real;
                *(ptrResult + 1) = *(ptrValue1 + 1) + imaginary;
                *(ptrResult + 2) = *(ptrValue1 + 2) + real;
                *(ptrResult + 3) = *(ptrValue1 + 3) + imaginary;
                *(ptrResult + 4) = *(ptrValue1 + 4) + real;
                *(ptrResult + 5) = *(ptrValue1 + 5) + imaginary;
                *(ptrResult + 6) = *(ptrValue1 + 6) + real;
                *(ptrResult + 7) = *(ptrValue1 + 7) + imaginary;
                *(ptrResult + 8) = *(ptrValue1 + 8) + real;
                *(ptrResult + 9) = *(ptrValue1 + 9) + imaginary;
                *(ptrResult + 10) = *(ptrValue1 + 10) + real;
                *(ptrResult + 11) = *(ptrValue1 + 11) + imaginary;
                *(ptrResult + 12) = *(ptrValue1 + 12) + real;
                *(ptrResult + 13) = *(ptrValue1 + 13) + imaginary;
                *(ptrResult + 14) = *(ptrValue1 + 14) + real;
                *(ptrResult + 15) = *(ptrValue1 + 15) + imaginary;
                ptrResult += 16;
                ptrValue1 += 16;
            }
            ptrEnd += 8;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + real;
                *(ptrResult + 1) = *(ptrValue1 + 1) + imaginary;
                *(ptrResult + 2) = *(ptrValue1 + 2) + real;
                *(ptrResult + 3) = *(ptrValue1 + 3) + imaginary;
                *(ptrResult + 4) = *(ptrValue1 + 4) + real;
                *(ptrResult + 5) = *(ptrValue1 + 5) + imaginary;
                *(ptrResult + 6) = *(ptrValue1 + 6) + real;
                *(ptrResult + 7) = *(ptrValue1 + 7) + imaginary;
                ptrResult += 8;
                ptrValue1 += 8;
            }
            ptrEnd += 4;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + real;
                *(ptrResult + 1) = *(ptrValue1 + 1) + imaginary;
                *(ptrResult + 2) = *(ptrValue1 + 2) + real;
                *(ptrResult + 3) = *(ptrValue1 + 3) + imaginary;
                ptrResult += 4;
                ptrValue1 += 4;
            }
            ptrEnd += 2;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + real;
                *(ptrResult + 1) = *(ptrValue1 + 1) + imaginary;
                ptrResult += 2;
                ptrValue1 += 2;
            }
        }
        unsafe public static void Addition(Block2x2* value1, Block2x2 value2, Block2x2* result, int size)
        {
            double f00 = value2.f00;
            double f01 = value2.f01;
            double f10 = value2.f10;
            double f11 = value2.f11;
            double* ptrValue1 = (double*)value1;
            double* ptrResult = (double*)result;
            double* ptrEnd = (double*)(result + size) - 31;
            // Main loop, pointers for row values
            while (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + f00;
                *(ptrResult + 1) = *(ptrValue1 + 1) + f01;
                *(ptrResult + 2) = *(ptrValue1 + 2) + f10;
                *(ptrResult + 3) = *(ptrValue1 + 3) + f11;
                *(ptrResult + 4) = *(ptrValue1 + 4) + f00;
                *(ptrResult + 5) = *(ptrValue1 + 5) + f01;
                *(ptrResult + 6) = *(ptrValue1 + 6) + f10;
                *(ptrResult + 7) = *(ptrValue1 + 7) + f11;
                *(ptrResult + 8) = *(ptrValue1 + 8) + f00;
                *(ptrResult + 9) = *(ptrValue1 + 9) + f01;
                *(ptrResult + 10) = *(ptrValue1 + 10) + f10;
                *(ptrResult + 11) = *(ptrValue1 + 11) + f11;
                *(ptrResult + 12) = *(ptrValue1 + 12) + f00;
                *(ptrResult + 13) = *(ptrValue1 + 13) + f01;
                *(ptrResult + 14) = *(ptrValue1 + 14) + f10;
                *(ptrResult + 15) = *(ptrValue1 + 15) + f11;
                *(ptrResult + 16) = *(ptrValue1 + 16) + f00;
                *(ptrResult + 17) = *(ptrValue1 + 17) + f01;
                *(ptrResult + 18) = *(ptrValue1 + 18) + f10;
                *(ptrResult + 19) = *(ptrValue1 + 19) + f11;
                *(ptrResult + 20) = *(ptrValue1 + 20) + f00;
                *(ptrResult + 21) = *(ptrValue1 + 21) + f01;
                *(ptrResult + 22) = *(ptrValue1 + 22) + f10;
                *(ptrResult + 23) = *(ptrValue1 + 23) + f11;
                *(ptrResult + 24) = *(ptrValue1 + 24) + f00;
                *(ptrResult + 25) = *(ptrValue1 + 25) + f01;
                *(ptrResult + 26) = *(ptrValue1 + 26) + f10;
                *(ptrResult + 27) = *(ptrValue1 + 27) + f11;
                *(ptrResult + 28) = *(ptrValue1 + 28) + f00;
                *(ptrResult + 29) = *(ptrValue1 + 29) + f01;
                *(ptrResult + 30) = *(ptrValue1 + 30) + f10;
                *(ptrResult + 31) = *(ptrValue1 + 31) + f11;
                ptrResult += 32;
                ptrValue1 += 32;
            }
            ptrEnd += 16;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + f00;
                *(ptrResult + 1) = *(ptrValue1 + 1) + f01;
                *(ptrResult + 2) = *(ptrValue1 + 2) + f10;
                *(ptrResult + 3) = *(ptrValue1 + 3) + f11;
                *(ptrResult + 4) = *(ptrValue1 + 4) + f00;
                *(ptrResult + 5) = *(ptrValue1 + 5) + f01;
                *(ptrResult + 6) = *(ptrValue1 + 6) + f10;
                *(ptrResult + 7) = *(ptrValue1 + 7) + f11;
                *(ptrResult + 8) = *(ptrValue1 + 8) + f00;
                *(ptrResult + 9) = *(ptrValue1 + 9) + f01;
                *(ptrResult + 10) = *(ptrValue1 + 10) + f10;
                *(ptrResult + 11) = *(ptrValue1 + 11) + f11;
                *(ptrResult + 12) = *(ptrValue1 + 12) + f00;
                *(ptrResult + 13) = *(ptrValue1 + 13) + f01;
                *(ptrResult + 14) = *(ptrValue1 + 14) + f10;
                *(ptrResult + 15) = *(ptrValue1 + 15) + f11;
                ptrResult += 16;
                ptrValue1 += 16;
            }
            ptrEnd += 8;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + f00;
                *(ptrResult + 1) = *(ptrValue1 + 1) + f01;
                *(ptrResult + 2) = *(ptrValue1 + 2) + f10;
                *(ptrResult + 3) = *(ptrValue1 + 3) + f11;
                *(ptrResult + 4) = *(ptrValue1 + 4) + f00;
                *(ptrResult + 5) = *(ptrValue1 + 5) + f01;
                *(ptrResult + 6) = *(ptrValue1 + 6) + f10;
                *(ptrResult + 7) = *(ptrValue1 + 7) + f11;
                ptrResult += 8;
                ptrValue1 += 8;
            }
            ptrEnd += 4;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = *ptrValue1 + f00;
                *(ptrResult + 1) = *(ptrValue1 + 1) + f01;
                *(ptrResult + 2) = *(ptrValue1 + 2) + f10;
                *(ptrResult + 3) = *(ptrValue1 + 3) + f11;
                ptrResult += 4;
                ptrValue1 += 4;
            }
        }
        /// <summary>
        /// Addition two matrix of real values
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        unsafe internal static void Addition(double* value1, double* value2, double* result, int size, int value1Start = 0, int value2Start = 0, int resultStart = 0)
        {
            double* ptrValue1 = value1 + value1Start;
            double* ptrValue2 = value2 + value2Start;
            double* ptrResult = result + resultStart;
            double* ptrEnd = ptrResult + size - 31;
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
        unsafe internal static void Substraction(double* value1, double* value2, double* result, int size, int value1Start = 0, int value2Start = 0, int resultStart = 0)
        {
            double* ptrValue1 = value1 + value1Start;
            double* ptrValue2 = value2 + value2Start;
            double* ptrResult = result + resultStart;
            double* ptrEnd = ptrResult + size - 31;
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
        unsafe internal static void Negate(double* value, double* result, int size, int valueStart = 0, int resultStart = 0)
        {
            double* ptrValue = value + valueStart;
            double* ptrResult = result + resultStart;
            double* ptrEnd = ptrResult + size - 31;
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
        unsafe internal static void CycleAddition(double* value1, double* value2, double* result, int size, int size2, int value1Start = 0, int value2Start = 0, int resultStart = 0)
        {
            double f0 = *value2;
            double f1;
            double f2;
            double f3;
            if (size == 1)
            {
                f1 = *value2;
                f2 = *value2;
                f3 = *value2;
            }
            else
                if (size == 2)
                {
                    f1 = value2[1];
                    f2 = *value2;
                    f3 = value2[1];
                }
                else
                    if (size == 4)
                    {
                        f1 = value2[1];
                        f2 = value2[2];
                        f3 = value2[3];
                    }
                    else
                        return;
            double* ptrValue1 = value1 + value1Start;
            double* ptrResult = result + resultStart;
            double* ptrEnd = ptrResult + size - 31;
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
        unsafe public static double DotMultiply(double* value1, double* value2, int size, int value1Start = 0, int value2Start = 0)
        {
            double* ptrValue1 = value1 + value1Start;
            double* ptrValue2 = value2 + value2Start;
            double result = 0;
            double* ptrEnd = ptrValue1 + size - 31;
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
        unsafe public static void Multiply(int size, double* value1, double* value2, double* result)
        {
            double* ptrValue1 = value1;
            double* ptrValue2 = value2;
            double* ptrResult = result;
            double* ptrEnd = ptrResult + size - 31;
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
        unsafe public static void Multiply(int size, Complex* value1, Complex* value2, Complex* result)
        {
            double* ptrValue1 = (double*)value1;
            double* ptrValue2 = (double*)value2;
            double* ptrResult = (double*)result;
            double* ptrEnd = (double*)(result + size) - 31;
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
        unsafe public static void Multiply(int size, Block2x2* value1, Block2x2* value2, Block2x2* result)
        {
            double* ptrValue1 = (double*)value1;
            double* ptrValue2 = (double*)value2;
            double* ptrResult = (double*)result;
            double* ptrEnd = (double*)(result + size) - 31;
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
        unsafe public static void Multiply(int size, double* value1, double value2, double* result)
        {
            double* ptrValue1 = value1;
            double* ptrResult = result;
            double* ptrEnd = result + size - 31;
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
        unsafe public static void Multiply(int size, Complex* value1, Complex value2, Complex* result)
        {
            double real = value2.Real;
            double imaginary = value2.Imaginary;
            double* ptrValue1 = (double*)value1;
            double* ptrResult = (double*)result;
            double* ptrEnd = (double*)(result + size) - 31;
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
        unsafe public static void Multiply(int size, Block2x2* value1, Block2x2 value2, Block2x2* result)
        {
            double f00 = value2.f00;
            double f01 = value2.f01;
            double f10 = value2.f10;
            double f11 = value2.f11;
            double* ptrValue1 = (double*)value1;
            double* ptrResult = (double*)result;
            double* ptrEnd = (double*)(result + size) - 31;
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

        unsafe public static void Division(int size, double* value1, double* value2, double* result)
        {
            double* ptrValue1 = value1;
            double* ptrValue2 = value2;
            double* ptrResult = result;
            double* ptrEnd = ptrResult + size - 31;
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
        unsafe public static void Division(int size, Complex* value1, Complex* value2, Complex* result)
        {
            double* ptrValue1 = (double*)value1;
            double* ptrValue2 = (double*)value2;
            double* ptrResult = (double*)result;
            double* ptrEnd = ptrResult + size * 2 - 31;
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
        unsafe public static void Division(int size, Block2x2* value1, Block2x2* value2, Block2x2* result)
        {
            double* ptrValue1 = (double*)value1;
            double* ptrValue2 = (double*)value2;
            double* ptrResult = (double*)result;
            double* ptrEnd = (double*)(result + size) - 31;
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

        unsafe public static void Inverse(int size, double* value, double* result)
        {
            double* ptrValue1 = value;
            double* ptrResult = result;
            double* ptrEnd = result + size - 31;
            // Main loop, pointers for row values
            while (ptrResult < ptrEnd)
            {
                *ptrResult = 1 / *ptrValue1;
                *(ptrResult + 1) = 1 / *(ptrValue1 + 1);
                *(ptrResult + 2) = 1 / *(ptrValue1 + 2);
                *(ptrResult + 3) = 1 / *(ptrValue1 + 3);
                *(ptrResult + 4) = 1 / *(ptrValue1 + 4);
                *(ptrResult + 5) = 1 / *(ptrValue1 + 5);
                *(ptrResult + 6) = 1 / *(ptrValue1 + 6);
                *(ptrResult + 7) = 1 / *(ptrValue1 + 7);
                *(ptrResult + 8) = 1 / *(ptrValue1 + 8);
                *(ptrResult + 9) = 1 / *(ptrValue1 + 9);
                *(ptrResult + 10) = 1 / *(ptrValue1 + 10);
                *(ptrResult + 11) = 1 / *(ptrValue1 + 11);
                *(ptrResult + 12) = 1 / *(ptrValue1 + 12);
                *(ptrResult + 13) = 1 / *(ptrValue1 + 13);
                *(ptrResult + 14) = 1 / *(ptrValue1 + 14);
                *(ptrResult + 15) = 1 / *(ptrValue1 + 15);
                *(ptrResult + 16) = 1 / *(ptrValue1 + 16);
                *(ptrResult + 17) = 1 / *(ptrValue1 + 17);
                *(ptrResult + 18) = 1 / *(ptrValue1 + 18);
                *(ptrResult + 19) = 1 / *(ptrValue1 + 19);
                *(ptrResult + 20) = 1 / *(ptrValue1 + 20);
                *(ptrResult + 21) = 1 / *(ptrValue1 + 21);
                *(ptrResult + 22) = 1 / *(ptrValue1 + 22);
                *(ptrResult + 23) = 1 / *(ptrValue1 + 23);
                *(ptrResult + 24) = 1 / *(ptrValue1 + 24);
                *(ptrResult + 25) = 1 / *(ptrValue1 + 25);
                *(ptrResult + 26) = 1 / *(ptrValue1 + 26);
                *(ptrResult + 27) = 1 / *(ptrValue1 + 27);
                *(ptrResult + 28) = 1 / *(ptrValue1 + 28);
                *(ptrResult + 29) = 1 / *(ptrValue1 + 29);
                *(ptrResult + 30) = 1 / *(ptrValue1 + 30);
                *(ptrResult + 31) = 1 / *(ptrValue1 + 31);
                ptrResult += 32;
                ptrValue1 += 32;
            }
            ptrEnd += 16;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = 1 / *ptrValue1;
                *(ptrResult + 1) = 1 / *(ptrValue1 + 1);
                *(ptrResult + 2) = 1 / *(ptrValue1 + 2);
                *(ptrResult + 3) = 1 / *(ptrValue1 + 3);
                *(ptrResult + 4) = 1 / *(ptrValue1 + 4);
                *(ptrResult + 5) = 1 / *(ptrValue1 + 5);
                *(ptrResult + 6) = 1 / *(ptrValue1 + 6);
                *(ptrResult + 7) = 1 / *(ptrValue1 + 7);
                *(ptrResult + 8) = 1 / *(ptrValue1 + 8);
                *(ptrResult + 9) = 1 / *(ptrValue1 + 9);
                *(ptrResult + 10) = 1 / *(ptrValue1 + 10);
                *(ptrResult + 11) = 1 / *(ptrValue1 + 11);
                *(ptrResult + 12) = 1 / *(ptrValue1 + 12);
                *(ptrResult + 13) = 1 / *(ptrValue1 + 13);
                *(ptrResult + 14) = 1 / *(ptrValue1 + 14);
                *(ptrResult + 15) = 1 / *(ptrValue1 + 15);
                ptrResult += 16;
                ptrValue1 += 16;
            }
            ptrEnd += 8;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = 1 / *ptrValue1;
                *(ptrResult + 1) = 1 / *(ptrValue1 + 1);
                *(ptrResult + 2) = 1 / *(ptrValue1 + 2);
                *(ptrResult + 3) = 1 / *(ptrValue1 + 3);
                *(ptrResult + 4) = 1 / *(ptrValue1 + 4);
                *(ptrResult + 5) = 1 / *(ptrValue1 + 5);
                *(ptrResult + 6) = 1 / *(ptrValue1 + 6);
                *(ptrResult + 7) = 1 / *(ptrValue1 + 7);
                ptrResult += 8;
                ptrValue1 += 8;
            }
            ptrEnd += 4;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = 1 / *ptrValue1;
                *(ptrResult + 1) = 1 / *(ptrValue1 + 1);
                *(ptrResult + 2) = 1 / *(ptrValue1 + 2);
                *(ptrResult + 3) = 1 / *(ptrValue1 + 3);
                ptrResult += 4;
                ptrValue1 += 4;
            }
            ptrEnd += 2;
            if (ptrResult < ptrEnd)
            {
                *ptrResult = 1 / *ptrValue1;
                *(ptrResult + 1) = 1 / *(ptrValue1 + 1);
                ptrResult += 2;
                ptrValue1 += 2;
            }
            if (ptrResult == ptrEnd)
                *ptrResult = 1 / *ptrValue1;
        }
        unsafe public static bool Equal(int size, double* value1, double* value2)
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
        #endregion Private methods
        #region Events, overrides
        #endregion Events, overrides
        #endregion Methods
    }
}
#endregion Working namespace