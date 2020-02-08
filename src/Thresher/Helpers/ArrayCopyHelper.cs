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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIlins.Thresher
{
    public class ArrayCopyHelper
    {
        /// <summary>
        /// Fast copies a range of elements from an uint array starting at the first element and pastes them into another uint array starting at the first element.
        /// </summary>
        /// <remarks>
        /// Faster than System.Array.Copy and System.Buffer.BlockCopy methods in small arrays (length less than 100).
        /// </remarks>
        /// <param name="source">The uint array that contains the data to copy</param>
        /// <param name="dest">The uint array that receives the data</param>
        /// <param name="length">A 32-bit integer that represents the number of uint elements to copy</param>
        unsafe public static void Copy(uint[] source, uint[] dest, int length)
        {
            if (length <= 0)
                return;
            fixed (uint* sourcePointer = source, destPointer = dest)
            {
                ulong* sourcePtr = (ulong*)(void*)sourcePointer;
                ulong* sourcePtrEnd = (ulong*)(void*)sourcePointer + (length >> 1) - 31;
                ulong* destPtr = (ulong*)(void*)destPointer;

                while (sourcePtr < sourcePtrEnd)
                {
                    *destPtr = *sourcePtr;
                    *(destPtr + 1) = *(sourcePtr + 1);
                    *(destPtr + 2) = *(sourcePtr + 2);
                    *(destPtr + 3) = *(sourcePtr + 3);
                    *(destPtr + 4) = *(sourcePtr + 4);
                    *(destPtr + 5) = *(sourcePtr + 5);
                    *(destPtr + 6) = *(sourcePtr + 6);
                    *(destPtr + 7) = *(sourcePtr + 7);
                    *(destPtr + 8) = *(sourcePtr + 8);
                    *(destPtr + 9) = *(sourcePtr + 9);
                    *(destPtr + 10) = *(sourcePtr + 10);
                    *(destPtr + 11) = *(sourcePtr + 11);
                    *(destPtr + 12) = *(sourcePtr + 12);
                    *(destPtr + 13) = *(sourcePtr + 13);
                    *(destPtr + 14) = *(sourcePtr + 14);
                    *(destPtr + 15) = *(sourcePtr + 15);
                    *(destPtr + 16) = *(sourcePtr + 16);
                    *(destPtr + 17) = *(sourcePtr + 17);
                    *(destPtr + 18) = *(sourcePtr + 18);
                    *(destPtr + 19) = *(sourcePtr + 19);
                    *(destPtr + 20) = *(sourcePtr + 20);
                    *(destPtr + 21) = *(sourcePtr + 21);
                    *(destPtr + 22) = *(sourcePtr + 22);
                    *(destPtr + 23) = *(sourcePtr + 23);
                    *(destPtr + 24) = *(sourcePtr + 24);
                    *(destPtr + 25) = *(sourcePtr + 25);
                    *(destPtr + 26) = *(sourcePtr + 26);
                    *(destPtr + 27) = *(sourcePtr + 27);
                    *(destPtr + 28) = *(sourcePtr + 28);
                    *(destPtr + 29) = *(sourcePtr + 29);
                    *(destPtr + 30) = *(sourcePtr + 30);
                    *(destPtr + 31) = *(sourcePtr + 31);
                    sourcePtr += 32;
                    destPtr += 32;
                }
                sourcePtrEnd += 16;
                if (sourcePtr < sourcePtrEnd)
                {
                    *destPtr = *sourcePtr;
                    *(destPtr + 1) = *(sourcePtr + 1);
                    *(destPtr + 2) = *(sourcePtr + 2);
                    *(destPtr + 3) = *(sourcePtr + 3);
                    *(destPtr + 4) = *(sourcePtr + 4);
                    *(destPtr + 5) = *(sourcePtr + 5);
                    *(destPtr + 6) = *(sourcePtr + 6);
                    *(destPtr + 7) = *(sourcePtr + 7);
                    *(destPtr + 8) = *(sourcePtr + 8);
                    *(destPtr + 9) = *(sourcePtr + 9);
                    *(destPtr + 10) = *(sourcePtr + 10);
                    *(destPtr + 11) = *(sourcePtr + 11);
                    *(destPtr + 12) = *(sourcePtr + 12);
                    *(destPtr + 13) = *(sourcePtr + 13);
                    *(destPtr + 14) = *(sourcePtr + 14);
                    *(destPtr + 15) = *(sourcePtr + 15);
                    sourcePtr += 16;
                    destPtr += 16;
                }
                sourcePtrEnd += 8;
                if (sourcePtr < sourcePtrEnd)
                {
                    *destPtr = *sourcePtr;
                    *(destPtr + 1) = *(sourcePtr + 1);
                    *(destPtr + 2) = *(sourcePtr + 2);
                    *(destPtr + 3) = *(sourcePtr + 3);
                    *(destPtr + 4) = *(sourcePtr + 4);
                    *(destPtr + 5) = *(sourcePtr + 5);
                    *(destPtr + 6) = *(sourcePtr + 6);
                    *(destPtr + 7) = *(sourcePtr + 7);
                    sourcePtr += 8;
                    destPtr += 8;
                }
                sourcePtrEnd += 4;
                if (sourcePtr < sourcePtrEnd)
                {
                    *destPtr = *sourcePtr;
                    *(destPtr + 1) = *(sourcePtr + 1);
                    *(destPtr + 2) = *(sourcePtr + 2);
                    *(destPtr + 3) = *(sourcePtr + 3);
                    sourcePtr += 4;
                    destPtr += 4;
                }
                sourcePtrEnd += 2;
                if (sourcePtr < sourcePtrEnd)
                {
                    *destPtr = *sourcePtr;
                    *(destPtr + 1) = *(sourcePtr + 1);
                    sourcePtr += 2;
                    destPtr += 2;
                }
                sourcePtrEnd += 1;
                if (sourcePtr < sourcePtrEnd)
                    *(destPtr++) = *(sourcePtr++);
                if ((length & 1) == 1)
                    *((uint*)(void*)destPtr) = *((uint*)(void*)sourcePtr);
            }
        }

        unsafe public static void Copy(uint* source, uint* dest, int length)
        {
            ulong* sourcePtr = (ulong*)(void*)source;
            ulong* sourcePtrEnd = (ulong*)(void*)source + (length >> 1) - 31;
            ulong* destPtr = (ulong*)(void*)dest;

            while (sourcePtr < sourcePtrEnd)
            {
                *destPtr = *sourcePtr;
                *(destPtr + 1) = *(sourcePtr + 1);
                *(destPtr + 2) = *(sourcePtr + 2);
                *(destPtr + 3) = *(sourcePtr + 3);
                *(destPtr + 4) = *(sourcePtr + 4);
                *(destPtr + 5) = *(sourcePtr + 5);
                *(destPtr + 6) = *(sourcePtr + 6);
                *(destPtr + 7) = *(sourcePtr + 7);
                *(destPtr + 8) = *(sourcePtr + 8);
                *(destPtr + 9) = *(sourcePtr + 9);
                *(destPtr + 10) = *(sourcePtr + 10);
                *(destPtr + 11) = *(sourcePtr + 11);
                *(destPtr + 12) = *(sourcePtr + 12);
                *(destPtr + 13) = *(sourcePtr + 13);
                *(destPtr + 14) = *(sourcePtr + 14);
                *(destPtr + 15) = *(sourcePtr + 15);
                *(destPtr + 16) = *(sourcePtr + 16);
                *(destPtr + 17) = *(sourcePtr + 17);
                *(destPtr + 18) = *(sourcePtr + 18);
                *(destPtr + 19) = *(sourcePtr + 19);
                *(destPtr + 20) = *(sourcePtr + 20);
                *(destPtr + 21) = *(sourcePtr + 21);
                *(destPtr + 22) = *(sourcePtr + 22);
                *(destPtr + 23) = *(sourcePtr + 23);
                *(destPtr + 24) = *(sourcePtr + 24);
                *(destPtr + 25) = *(sourcePtr + 25);
                *(destPtr + 26) = *(sourcePtr + 26);
                *(destPtr + 27) = *(sourcePtr + 27);
                *(destPtr + 28) = *(sourcePtr + 28);
                *(destPtr + 29) = *(sourcePtr + 29);
                *(destPtr + 30) = *(sourcePtr + 30);
                *(destPtr + 31) = *(sourcePtr + 31);
                sourcePtr += 32;
                destPtr += 32;
            }
            sourcePtrEnd += 16;
            if (sourcePtr < sourcePtrEnd)
            {
                *destPtr = *sourcePtr;
                *(destPtr + 1) = *(sourcePtr + 1);
                *(destPtr + 2) = *(sourcePtr + 2);
                *(destPtr + 3) = *(sourcePtr + 3);
                *(destPtr + 4) = *(sourcePtr + 4);
                *(destPtr + 5) = *(sourcePtr + 5);
                *(destPtr + 6) = *(sourcePtr + 6);
                *(destPtr + 7) = *(sourcePtr + 7);
                *(destPtr + 8) = *(sourcePtr + 8);
                *(destPtr + 9) = *(sourcePtr + 9);
                *(destPtr + 10) = *(sourcePtr + 10);
                *(destPtr + 11) = *(sourcePtr + 11);
                *(destPtr + 12) = *(sourcePtr + 12);
                *(destPtr + 13) = *(sourcePtr + 13);
                *(destPtr + 14) = *(sourcePtr + 14);
                *(destPtr + 15) = *(sourcePtr + 15);
                sourcePtr += 16;
                destPtr += 16;
            }
            sourcePtrEnd += 8;
            if (sourcePtr < sourcePtrEnd)
            {
                *destPtr = *sourcePtr;
                *(destPtr + 1) = *(sourcePtr + 1);
                *(destPtr + 2) = *(sourcePtr + 2);
                *(destPtr + 3) = *(sourcePtr + 3);
                *(destPtr + 4) = *(sourcePtr + 4);
                *(destPtr + 5) = *(sourcePtr + 5);
                *(destPtr + 6) = *(sourcePtr + 6);
                *(destPtr + 7) = *(sourcePtr + 7);
                sourcePtr += 8;
                destPtr += 8;
            }
            sourcePtrEnd += 4;
            if (sourcePtr < sourcePtrEnd)
            {
                *destPtr = *sourcePtr;
                *(destPtr + 1) = *(sourcePtr + 1);
                *(destPtr + 2) = *(sourcePtr + 2);
                *(destPtr + 3) = *(sourcePtr + 3);
                sourcePtr += 4;
                destPtr += 4;
            }
            sourcePtrEnd += 2;
            if (sourcePtr < sourcePtrEnd)
            {
                *destPtr = *sourcePtr;
                *(destPtr + 1) = *(sourcePtr + 1);
                sourcePtr += 2;
                destPtr += 2;
            }
            sourcePtrEnd += 1;
            if (sourcePtr < sourcePtrEnd)
                *(destPtr++) = *(sourcePtr++);
            if ((length & 1) == 1)
                *((uint*)(void*)destPtr) = *((uint*)(void*)sourcePtr);
            
        }
        /// <summary>
        /// Fast copies a range of elements from an uint array starting at the first element and pastes them into another uint array starting at the first element.
        /// </summary>
        /// <remarks>
        /// Faster than System.Array.Copy and System.Buffer.BlockCopy methods.
        /// </remarks>
        /// <param name="source">The uint array that contains the data to copy</param>
        /// <param name="dest">The uint array that receives the data</param>
        /// <param name="length">A 32-bit integer that represents the number of uint elements to copy</param>
        unsafe public static void Copy(int[] source, int[] dest, int length)
        {
            fixed (int* sourcePointer = source, destPointer = dest)
            {
                ulong* sourcePtr = (ulong*)(void*)sourcePointer;
                ulong* sourcePtrEnd = (ulong*)(void*)sourcePointer + (length >> 1) - 31;
                ulong* destPtr = (ulong*)(void*)destPointer;

                while (sourcePtr < sourcePtrEnd)
                {
                    *destPtr = *sourcePtr;
                    *(destPtr + 1) = *(sourcePtr + 1);
                    *(destPtr + 2) = *(sourcePtr + 2);
                    *(destPtr + 3) = *(sourcePtr + 3);
                    *(destPtr + 4) = *(sourcePtr + 4);
                    *(destPtr + 5) = *(sourcePtr + 5);
                    *(destPtr + 6) = *(sourcePtr + 6);
                    *(destPtr + 7) = *(sourcePtr + 7);
                    *(destPtr + 8) = *(sourcePtr + 8);
                    *(destPtr + 9) = *(sourcePtr + 9);
                    *(destPtr + 10) = *(sourcePtr + 10);
                    *(destPtr + 11) = *(sourcePtr + 11);
                    *(destPtr + 12) = *(sourcePtr + 12);
                    *(destPtr + 13) = *(sourcePtr + 13);
                    *(destPtr + 14) = *(sourcePtr + 14);
                    *(destPtr + 15) = *(sourcePtr + 15);
                    *(destPtr + 16) = *(sourcePtr + 16);
                    *(destPtr + 17) = *(sourcePtr + 17);
                    *(destPtr + 18) = *(sourcePtr + 18);
                    *(destPtr + 19) = *(sourcePtr + 19);
                    *(destPtr + 20) = *(sourcePtr + 20);
                    *(destPtr + 21) = *(sourcePtr + 21);
                    *(destPtr + 22) = *(sourcePtr + 22);
                    *(destPtr + 23) = *(sourcePtr + 23);
                    *(destPtr + 24) = *(sourcePtr + 24);
                    *(destPtr + 25) = *(sourcePtr + 25);
                    *(destPtr + 26) = *(sourcePtr + 26);
                    *(destPtr + 27) = *(sourcePtr + 27);
                    *(destPtr + 28) = *(sourcePtr + 28);
                    *(destPtr + 29) = *(sourcePtr + 29);
                    *(destPtr + 30) = *(sourcePtr + 30);
                    *(destPtr + 31) = *(sourcePtr + 31);
                    sourcePtr += 32;
                    destPtr += 32;
                }
                sourcePtrEnd += 16;
                if (sourcePtr < sourcePtrEnd)
                {
                    *destPtr = *sourcePtr;
                    *(destPtr + 1) = *(sourcePtr + 1);
                    *(destPtr + 2) = *(sourcePtr + 2);
                    *(destPtr + 3) = *(sourcePtr + 3);
                    *(destPtr + 4) = *(sourcePtr + 4);
                    *(destPtr + 5) = *(sourcePtr + 5);
                    *(destPtr + 6) = *(sourcePtr + 6);
                    *(destPtr + 7) = *(sourcePtr + 7);
                    *(destPtr + 8) = *(sourcePtr + 8);
                    *(destPtr + 9) = *(sourcePtr + 9);
                    *(destPtr + 10) = *(sourcePtr + 10);
                    *(destPtr + 11) = *(sourcePtr + 11);
                    *(destPtr + 12) = *(sourcePtr + 12);
                    *(destPtr + 13) = *(sourcePtr + 13);
                    *(destPtr + 14) = *(sourcePtr + 14);
                    *(destPtr + 15) = *(sourcePtr + 15);
                    sourcePtr += 16;
                    destPtr += 16;
                }
                sourcePtrEnd += 8;
                if (sourcePtr < sourcePtrEnd)
                {
                    *destPtr = *sourcePtr;
                    *(destPtr + 1) = *(sourcePtr + 1);
                    *(destPtr + 2) = *(sourcePtr + 2);
                    *(destPtr + 3) = *(sourcePtr + 3);
                    *(destPtr + 4) = *(sourcePtr + 4);
                    *(destPtr + 5) = *(sourcePtr + 5);
                    *(destPtr + 6) = *(sourcePtr + 6);
                    *(destPtr + 7) = *(sourcePtr + 7);
                    sourcePtr += 8;
                    destPtr += 8;
                }
                sourcePtrEnd += 4;
                if (sourcePtr < sourcePtrEnd)
                {
                    *destPtr = *sourcePtr;
                    *(destPtr + 1) = *(sourcePtr + 1);
                    *(destPtr + 2) = *(sourcePtr + 2);
                    *(destPtr + 3) = *(sourcePtr + 3);
                    sourcePtr += 4;
                    destPtr += 4;
                }
                sourcePtrEnd += 2;
                if (sourcePtr < sourcePtrEnd)
                {
                    *destPtr = *sourcePtr;
                    *(destPtr + 1) = *(sourcePtr + 1);
                    sourcePtr += 2;
                    destPtr += 2;
                }
                sourcePtrEnd += 1;
                if (sourcePtr < sourcePtrEnd)
                    *(destPtr++) = *(sourcePtr++);
                if ((length & 1) == 1)
                    *((uint*)(void*)destPtr) = *((uint*)(void*)sourcePtr);
            }
        }
        /// <summary>
        /// Fast copies a range of elements from an double array starting at the first element and pastes them into another double array starting at the first element.
        /// </summary>
        /// <remarks>
        /// Faster than System.Array.Copy and System.Buffer.BlockCopy methods.
        /// </remarks>
        /// <param name="source">The double array that contains the data to copy</param>
        /// <param name="dest">The double array that receives the data</param>
        /// <param name="length">A 32-bit integer that represents the number of uint elements to copy</param>
        unsafe public static void Copy(double[] source, double[] dest, int length)
        {
            fixed (double* sourcePointer = source, destPointer = dest)
            {
                double* sourcePtr = sourcePointer;
                double* sourcePtrEnd = sourcePointer + length - 31;
                double* destPtr = destPointer;

                while (sourcePtr < sourcePtrEnd)
                {
                    *destPtr = *sourcePtr;
                    *(destPtr + 1) = *(sourcePtr + 1);
                    *(destPtr + 2) = *(sourcePtr + 2);
                    *(destPtr + 3) = *(sourcePtr + 3);
                    *(destPtr + 4) = *(sourcePtr + 4);
                    *(destPtr + 5) = *(sourcePtr + 5);
                    *(destPtr + 6) = *(sourcePtr + 6);
                    *(destPtr + 7) = *(sourcePtr + 7);
                    *(destPtr + 8) = *(sourcePtr + 8);
                    *(destPtr + 9) = *(sourcePtr + 9);
                    *(destPtr + 10) = *(sourcePtr + 10);
                    *(destPtr + 11) = *(sourcePtr + 11);
                    *(destPtr + 12) = *(sourcePtr + 12);
                    *(destPtr + 13) = *(sourcePtr + 13);
                    *(destPtr + 14) = *(sourcePtr + 14);
                    *(destPtr + 15) = *(sourcePtr + 15);
                    *(destPtr + 16) = *(sourcePtr + 16);
                    *(destPtr + 17) = *(sourcePtr + 17);
                    *(destPtr + 18) = *(sourcePtr + 18);
                    *(destPtr + 19) = *(sourcePtr + 19);
                    *(destPtr + 20) = *(sourcePtr + 20);
                    *(destPtr + 21) = *(sourcePtr + 21);
                    *(destPtr + 22) = *(sourcePtr + 22);
                    *(destPtr + 23) = *(sourcePtr + 23);
                    *(destPtr + 24) = *(sourcePtr + 24);
                    *(destPtr + 25) = *(sourcePtr + 25);
                    *(destPtr + 26) = *(sourcePtr + 26);
                    *(destPtr + 27) = *(sourcePtr + 27);
                    *(destPtr + 28) = *(sourcePtr + 28);
                    *(destPtr + 29) = *(sourcePtr + 29);
                    *(destPtr + 30) = *(sourcePtr + 30);
                    *(destPtr + 31) = *(sourcePtr + 31);
                    sourcePtr += 32;
                    destPtr += 32;
                }
                sourcePtrEnd += 16;
                if (sourcePtr < sourcePtrEnd)
                {
                    *destPtr = *sourcePtr;
                    *(destPtr + 1) = *(sourcePtr + 1);
                    *(destPtr + 2) = *(sourcePtr + 2);
                    *(destPtr + 3) = *(sourcePtr + 3);
                    *(destPtr + 4) = *(sourcePtr + 4);
                    *(destPtr + 5) = *(sourcePtr + 5);
                    *(destPtr + 6) = *(sourcePtr + 6);
                    *(destPtr + 7) = *(sourcePtr + 7);
                    *(destPtr + 8) = *(sourcePtr + 8);
                    *(destPtr + 9) = *(sourcePtr + 9);
                    *(destPtr + 10) = *(sourcePtr + 10);
                    *(destPtr + 11) = *(sourcePtr + 11);
                    *(destPtr + 12) = *(sourcePtr + 12);
                    *(destPtr + 13) = *(sourcePtr + 13);
                    *(destPtr + 14) = *(sourcePtr + 14);
                    *(destPtr + 15) = *(sourcePtr + 15);
                    sourcePtr += 16;
                    destPtr += 16;
                }
                sourcePtrEnd += 8;
                if (sourcePtr < sourcePtrEnd)
                {
                    *destPtr = *sourcePtr;
                    *(destPtr + 1) = *(sourcePtr + 1);
                    *(destPtr + 2) = *(sourcePtr + 2);
                    *(destPtr + 3) = *(sourcePtr + 3);
                    *(destPtr + 4) = *(sourcePtr + 4);
                    *(destPtr + 5) = *(sourcePtr + 5);
                    *(destPtr + 6) = *(sourcePtr + 6);
                    *(destPtr + 7) = *(sourcePtr + 7);
                    sourcePtr += 8;
                    destPtr += 8;
                }
                sourcePtrEnd += 4;
                if (sourcePtr < sourcePtrEnd)
                {
                    *destPtr = *sourcePtr;
                    *(destPtr + 1) = *(sourcePtr + 1);
                    *(destPtr + 2) = *(sourcePtr + 2);
                    *(destPtr + 3) = *(sourcePtr + 3);
                    sourcePtr += 4;
                    destPtr += 4;
                }
                sourcePtrEnd += 2;
                if (sourcePtr < sourcePtrEnd)
                {
                    *destPtr = *sourcePtr;
                    *(destPtr + 1) = *(sourcePtr + 1);
                    sourcePtr += 2;
                    destPtr += 2;
                }
                sourcePtrEnd += 1;
                if (sourcePtr < sourcePtrEnd)
                    *(destPtr++) = *(sourcePtr++);
            }
        }
    }
}
