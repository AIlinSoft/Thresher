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
using System.Text;
using System.Linq;
#endregion Using namespaces
#region Working namespace
namespace AIlins.Thresher
{
    /// <summary>
    /// Container for quick big math operations. 
    /// </summary>
    public class BigHelper
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
        #region Addition
        /// <summary>
        /// Addition two arrays with result at first array
        /// </summary>
        /// <remarks>
        /// Arrays length not in control
        /// </remarks>
        /// <param name="value1">First array and result, value1.length >= value2.length</param>
        /// <param name="value2">Second array</param>
        /// <returns>Overflow value</returns>
        unsafe public static uint Addition(uint[] value1, uint[] value2)
        {
            return Addition(value1, value2, value1);
        }
        /// <summary>
        /// Addition two arrays
        /// </summary>
        /// <remarks>
        /// Arrays length not in control
        /// </remarks>
        /// <param name="value1">First array</param>
        /// <param name="value2">Second array</param>
        /// <param name="result">Addition result array, result.length >= value1.length and result.length >= value2.length</param>
        /// <returns>Overflow value</returns>
        unsafe public static uint Addition(uint[] value1, uint[] value2, uint[] result)
        {
            ulong temp = 0;
            if (value1.Length < value2.Length)
            {
                uint[] valueTemp = value1;
                value1 = value2;
                value2 = valueTemp;
            }
            //TODO: if result.length < value1.Length ? 
            fixed (uint* value1Pointer = value1, value2Pointer = value2, resultPointer = result)
            {
                uint* ptrCounter = value1Pointer;
                uint* ptrValue2 = value2Pointer;
                uint* ptrResult = resultPointer;
                uint* ptrEnd = value1Pointer + value2.Length;
                // Первоначально сложить
                for (; ptrCounter < ptrEnd; ++ptrCounter, ++ptrValue2, ++ptrResult)
                {
                    temp += (ulong)*ptrCounter + *ptrValue2;
                    *ptrResult = (uint)temp;
                    temp >>= 32;
                }
                ptrEnd = value1Pointer + value1.Length;
                for (; ptrCounter < ptrEnd; ++ptrCounter, ++ptrResult)
                {
                    temp += (ulong)*ptrCounter;
                    *ptrResult = (uint)temp;
                    temp >>= 32;
                }
                if (result.Length > value1.Length)
                {
                    *ptrResult = (uint)temp;
                    temp = 0;
                }
            }
            return (uint)temp;
        }
        /// <summary>
        /// Addition array and uint value
        /// </summary>
        /// <remarks>
        /// Arrays length not in control
        /// </remarks>
        /// <param name="value1">First value</param>
        /// <param name="value2">Second value</param>
        /// <param name="result">Addition result array, result.length >= value1.length</param>
        /// <returns>Overflow value</returns>
        unsafe public static uint Addition(uint[] value1, uint value2, uint[] result)
        {
            ulong temp = 0;
            fixed (uint* value1Pointer = value1, resultPointer = result)
            {
                temp = (ulong)*value1Pointer + value2;
                *resultPointer = (uint)temp;
                temp >>= 32;
                if (temp > 0)
                {
                    if (value1.Length > 1)
                    {
                        uint* ptrCounter = value1Pointer + 1;
                        uint* ptrResult = resultPointer + 1;
                        uint* ptrValue1End = value1Pointer + value1.Length;
                        // Первоначально сложить
                        for (; ptrCounter < ptrValue1End; ++ptrCounter, ++ptrResult)
                        {
                            temp += (ulong)*ptrCounter;
                            *ptrResult = (uint)temp;
                            temp >>= 32;
                        }
                        if (result.Length > value1.Length)
                        {
                            *ptrResult = (uint)temp;
                            temp = 0;
                        }
                    }
                }
            }
            return (uint)temp;
        }
        /// <summary>
        /// Add value with shift of another value
        /// </summary>
        /// <remarks>
        /// Expected that value1.Length>=value2.Length
        /// </remarks>
        /// <param name="value1">First value array and result</param>
        /// <param name="value2">Second value array</param>
        /// <param name="shift">Right/left shift value</param>
        /// <returns>Addition overflow flag and expected overflow value</returns>
        unsafe public static ulong Addition(uint[] value1, uint[] value2, int shift)
        {
            // Cut shift period for right/left shift
            if (shift >= 0)
                shift %= value1.Length * 32;
            else
                shift %= value2.Length * 32;
            // How many indexes shifts
            int arrayShift = Math.Abs(shift) / 32;
            // Offset in uint value
            int valueShift = Math.Abs(shift) % 32;
            int value1Length = value1.Length;
            int value2Length = value2.Length;

            ulong temp = 0;
            fixed (uint* valuePointer = value1, value2Pointer = value2)
            {
                if (valueShift == 0)
                {
                    // If need only array shift
                    // Указатели на аргументы цикла
                    uint* ptrCounter;
                    uint* ptrTemp;
                    int firstStep;
                    // Указатель на конец цикла
                    uint* counterEndPointer;
                    // Right/left shift
                    if (shift >= 0)
                    {
                        ptrCounter = value2Pointer;
                        ptrTemp = valuePointer + arrayShift;
                        firstStep = value1Length - arrayShift;
                        if (firstStep > value2Length)
                            firstStep = value2Length;
                        counterEndPointer = value2Pointer + firstStep;
                    }
                    else
                    {
                        ptrCounter = value2Pointer + arrayShift;
                        ptrTemp = valuePointer;
                        firstStep = value2Length - arrayShift;
                        if (firstStep > value1Length)
                            firstStep = value1Length;
                        counterEndPointer = value2Pointer + firstStep;
                    }

                    // Numbers crusher
                    for (; ptrCounter < counterEndPointer; ++ptrCounter, ++ptrTemp)
                    {
                        temp += (ulong)*ptrCounter + (ulong)*ptrTemp;
                        *ptrTemp = (uint)temp;
                        temp >>= 32;
                    }

                    // Если нужно, сложить дальше по циклу
                    if (temp != 0)
                    {
                        counterEndPointer = valuePointer + value1Length;

                        for (; ptrTemp < counterEndPointer; ++ptrTemp)
                        {
                            temp += (ulong)*ptrTemp;
                            *ptrTemp = (uint)temp;
                            temp >>= 32;
                        }
                    }
                }
                else
                {
                    // Иначе сдвигаем с параллельным переносом
                    int valueResidual = 32 - valueShift;


                    // Указатели на аргументы цикла
                    uint* ptrCounter;
                    uint* ptrCounterPlus;
                    uint* ptrTemp;
                    int firstStep;
                    // Указатель на конец цикла
                    uint* counterEndPointer;

                    // Right/left shift
                    if (shift >= 0)
                    {
                        ptrCounter = value2Pointer;
                        ptrCounterPlus = value2Pointer + 1;
                        ptrTemp = valuePointer + arrayShift;
                        firstStep = value1Length - arrayShift;
                        if (firstStep > value2Length)
                            firstStep = value2Length;
                        counterEndPointer = value2Pointer + firstStep;

                        temp = (ulong)(*ptrCounter << valueShift) + (ulong)*ptrTemp;
                        *ptrTemp = (uint)temp;
                        temp >>= 32;
                        ptrTemp++;
                    }
                    else
                    {
                        ptrCounter = value2Pointer + arrayShift;
                        ptrCounterPlus = ptrCounter + 1;
                        ptrTemp = valuePointer;
                        firstStep = value2Length - arrayShift;
                        if (firstStep > value1Length)
                            firstStep = value1Length;
                        counterEndPointer = value2Pointer + firstStep;

                        // Change the shifting parametrs
                        firstStep = valueResidual;
                        valueResidual = valueShift;
                        valueShift = firstStep;

                    }

                    // Numbers crusher
                    for (; ptrCounterPlus < counterEndPointer; ++ptrCounter, ++ptrCounterPlus, ++ptrTemp)
                    {
                        temp += (ulong)((*ptrCounter >> valueResidual) | (*ptrCounterPlus << valueShift)) + (ulong)*ptrTemp;
                        *ptrTemp = (uint)temp;
                        temp >>= 32;
                    }
                    temp += (ulong)(*ptrCounter >> valueResidual) + (ulong)*ptrTemp;
                    *ptrTemp = (uint)temp;
                    temp >>= 32;
                    ptrTemp++;

                    // Если нужно, сложить дальше по циклу
                    if (temp != 0)
                    {
                        counterEndPointer = valuePointer + value1Length;

                        for (; ptrTemp < counterEndPointer; ++ptrTemp)
                        {
                            temp += (ulong)*ptrTemp;
                            *ptrTemp = (uint)temp;
                            temp >>= 32;
                        }
                    }
                }
            }
            return temp;
        }
        #endregion Addition
        #region Substraction
        /// <summary>
        /// Substraction
        /// </summary>
        /// <remarks>
        /// Arrays length not in control
        /// </remarks>
        /// <param name="value1">First array</param>
        /// <param name="value2">Second array</param>
        /// <param name="result">Substraction result array</param>
        /// <returns>true if substractiom overflow</returns>
        unsafe public static bool Substraction(uint[] value1, uint[] value2)
        {
            return Substraction(value1, value2, value1);
        }
        /// <summary>
        /// Substraction
        /// </summary>
        /// <remarks>
        /// Arrays length not in control
        /// </remarks>
        /// <param name="value1">First array</param>
        /// <param name="value2">Second array</param>
        /// <param name="result">Substraction result array</param>
        /// <returns>True if substractiom overflow</returns>
        unsafe public static bool Substraction(uint[] value1, uint[] value2, uint[] result)
        {
            bool flag = false;
            int first, second;
            if (value1.Length < value2.Length)
            {
                flag = true;
                first = value1.Length;
                second = value2.Length;
            }
            else
            {
                first = value2.Length;
                second = value1.Length;
            }
            fixed (uint* value1Pointer = value1, value2Pointer = value2, resultPointer = result)
            {
                ulong temp = 0;
                // Указатели на аргументы цикла
                uint* ptrCounter = value1Pointer, ptrTemp = value2Pointer, ptrResult = resultPointer;
                // Указатель на конец цикла
                uint* counterEndPointer = value1Pointer + first;

                for (; ptrCounter < counterEndPointer; ++ptrCounter, ++ptrTemp, ++ptrResult)
                {
                    temp = (ulong)*ptrCounter - *ptrTemp - temp;
                    *ptrResult = (uint)temp;
                    temp >>= 63;
                }

                if (flag)
                {
                    counterEndPointer = value2Pointer + second;
                    for (; ptrTemp < counterEndPointer; ++ptrTemp, ++ptrResult)
                    {
                        temp = 0 - (ulong)*ptrTemp - temp;
                        *ptrResult = (uint)temp;
                        temp >>= 63;
                    }
                }
                else
                {
                    counterEndPointer = value1Pointer + second;
                    for (; ptrCounter < counterEndPointer; ++ptrCounter, ++ptrTemp, ++ptrResult)
                    {
                        temp = (ulong)*ptrCounter - temp;
                        *ptrResult = (uint)temp;
                        temp >>= 63;
                    }
                }
              // Если число отрицательное, нужно его привести к отрицательному виду
                if (temp != 0)
                    flag = true;
                else
                    flag = false;
            }
            return flag;
        }
        /// <summary>
        /// Substraction
        /// </summary>
        /// <remarks>
        /// Arrays length not in control
        /// </remarks>
        /// <param name="value1">First value</param>
        /// <param name="value2">Second value</param>
        /// <param name="result">Substraction result array</param>
        /// <returns>True if substractiom overflow</returns>
        unsafe public static bool Substraction(uint[] value1, ulong value2, uint[] result)
        {
            bool invFlag = false;
            fixed (uint* value1Pointer = value1, resultPointer = result)
            {
                ulong temp = 0;

                temp = (ulong)*value1Pointer - (uint)value2;
                *resultPointer = (uint)temp;
                temp >>= 63;
                value2 >>= 32;
                if (value1.Length == 1)
                {
                    temp = 0 - (uint)value2 - temp;
                    if (temp == 0)
                        return false;
                    else
                        return true;
                }
                // Указатели на аргументы цикла
                uint* ptrCounter = value1Pointer + 1, ptrResult = resultPointer + 1;
                temp = (ulong)*ptrCounter - (uint)value2;
                *resultPointer = (uint)temp;
                temp >>= 63;
                ptrCounter++;
                ptrResult++;
                if (temp != 0)
                {
                    // Указатель на конец цикла
                    uint* counterEndPointer = value1Pointer + value1.Length;

                    for (; ptrCounter < counterEndPointer; ++ptrCounter, ++ptrResult)
                    {
                        temp = (ulong)*ptrCounter - temp;
                        *ptrResult = (uint)temp;
                        temp >>= 63;
                    }

                    // Если число отрицательное, нужно его привести к отрицательному виду
                    if (temp > 0)
                        invFlag = true;
                }
            }
            return invFlag;
        }
        /// <summary>
        /// Sub value with shift of another value
        /// </summary>
        /// <remarks>
        /// Result is not invert to op code. Expected that value1.Length>=value2.Length
        /// </remarks>
        /// <param name="value1">First value array and result</param>
        /// <param name="value2">Second value array</param>
        /// <param name="shift">Right/left shift value</param>
        /// <returns>Substraction overflow flag i.e. result is negative</returns>
        unsafe public static ulong Substraction(uint[] value1, uint[] value2, int shift)
        {
            // Cut shift period for right/left shift
            if (shift >= 0)
                shift %= value1.Length * 32;
            else
                shift %= value2.Length * 32;
            // How many indexes shifts
            int arrayShift = Math.Abs(shift) / 32;
            // Offset in uint value
            int valueShift = Math.Abs(shift) % 32;
            int value1Length = value1.Length;
            int value2Length = value2.Length;
            ulong temp = 0;
            fixed (uint* valuePointer = value1, value2Pointer = value2)
            {
                if (valueShift == 0)
                {
                    // If need only array shift
                    // Указатели на аргументы цикла
                    uint* ptrCounter;
                    uint* ptrTemp;
                    int firstStep;
                    // Указатель на конец цикла
                    uint* counterEndPointer;
                    // Right/left shift
                    if (shift >= 0)
                    {
                        ptrCounter = value2Pointer;
                        ptrTemp = valuePointer + arrayShift;
                        firstStep = value1Length - arrayShift;
                        if (firstStep > value2Length)
                            firstStep = value2Length;
                        counterEndPointer = value2Pointer + firstStep;
                    }
                    else
                    {
                        ptrCounter = value2Pointer + arrayShift;
                        ptrTemp = valuePointer;
                        firstStep = value2Length - arrayShift;
                        if (firstStep > value1Length)
                            firstStep = value1Length;
                        counterEndPointer = value2Pointer + firstStep;
                    }

                    // Если сдвинули на целое число, то просто сложим в цикле
                    for (; ptrCounter < counterEndPointer; ++ptrCounter, ++ptrTemp)
                    {
                        temp = (ulong)*ptrTemp - (ulong)*ptrCounter - temp;
                        *ptrTemp = (uint)temp;
                        temp >>= 63;
                    }

                    // Если нужно, отнять дальше по циклу
                    if (temp != 0)
                    {
                        counterEndPointer = valuePointer + value1Length;

                        for (; ptrTemp < counterEndPointer; ++ptrTemp)
                        {
                            temp = (ulong)*ptrTemp - temp;
                            *ptrTemp = (uint)temp;
                            temp >>= 63;
                        }
                    }
                }
                else
                {
                    // Иначе сдвигаем с параллельным переносом
                    int valueResidual = 32 - valueShift;

                    // Указатели на аргументы цикла
                    uint* ptrCounter;
                    uint* ptrCounterPlus;
                    uint* ptrTemp;
                    int firstStep;
                    // Указатель на конец цикла
                    uint* counterEndPointer;

                    // Right/left shift
                    if (shift >= 0)
                    {
                        ptrCounter = value2Pointer;
                        ptrCounterPlus = value2Pointer + 1;
                        ptrTemp = valuePointer + arrayShift;
                        firstStep = value1Length - arrayShift;
                        if (firstStep > value2Length)
                            firstStep = value2Length;
                        counterEndPointer = value2Pointer + firstStep;

                        temp = (ulong)*ptrTemp - (ulong)(*ptrCounter << valueShift);
                        *ptrTemp = (uint)temp;
                        temp >>= 63;
                        ptrTemp++;
                    }
                    else
                    {
                        ptrCounter = value2Pointer + arrayShift;
                        ptrCounterPlus = ptrCounter + 1;
                        ptrTemp = valuePointer;
                        firstStep = value2Length - arrayShift;
                        if (firstStep > value1Length)
                            firstStep = value1Length;
                        counterEndPointer = value2Pointer + firstStep;

                        // Change the shifting parametrs
                        firstStep = valueResidual;
                        valueResidual = valueShift;
                        valueShift = firstStep;
                    }

                    // Если сдвинули на целое число, то просто сложим в цикле
                    for (; ptrCounterPlus < counterEndPointer; ++ptrCounter, ++ptrCounterPlus, ++ptrTemp)
                    {
                        temp = (ulong)*ptrTemp - (ulong)((*ptrCounter >> valueResidual) | (*ptrCounterPlus << valueShift)) - temp;
                        *ptrTemp = (uint)temp;
                        temp >>= 63;
                    }
                    temp = (ulong)*ptrTemp - (ulong)(*ptrCounter >> valueResidual) - temp;
                    *ptrTemp = (uint)temp;
                    temp >>= 63;
                    ptrTemp++;

                    // Если нужно, сложить дальше по циклу
                    if (temp != 0)
                    {
                        counterEndPointer = valuePointer + value1Length;

                        for (; ptrTemp < counterEndPointer; ++ptrTemp)
                        {
                            temp = (ulong)*ptrTemp - temp;
                            *ptrTemp = (uint)temp;
                            temp >>= 63;
                        }
                    }

                }
            }
            return temp;
        }
        #endregion Substraction
        #region Multiply
        unsafe public static bool Multiply(uint[] value1, uint[] value2)
        {
            uint[] result = new uint[value1.Length + value2.Length];
            Multiply(value1, value2, result);
            ArrayCopyHelper.Copy(result, value1, value1.Length);
            fixed (uint* resultPointer = result)
            {
                uint* ptrResultEnd = resultPointer + result.Length;
                for (uint* ptrCounter = resultPointer + value1.Length; ptrCounter < ptrResultEnd; ++ptrCounter)
                {
                    if (*ptrCounter != 0)
                        return true;
                }
            }
            return false;
            
        }
        /// <summary>
        /// Bid numbers multiplier
        /// </summary>
        /// <remarks>
        /// Result length should be equal or greater than sum of values lengths
        /// If array with greater length is disperse we have some economy!
        /// </remarks>
        /// <param name="value1">First array</param>
        /// <param name="value2">Second array</param>
        /// <param name="result">Result array</param>
        unsafe public static void Multiply(uint[] value1, uint[] value2, uint[] result)
        {
            // Внешний цикл для скорости должен иметь меньший размер
            if (value1.Length < value2.Length)
            {
                uint[] tempValue = value1;
                value1 = value2;
                value2 = tempValue;
            }
            fixed (uint* value2Pointer = value2, value1Pointer = value1, resultPointer = result)
            {

                ulong temp;
                // Границы массивов
                uint* ptrValue1End = value2Pointer + value1.Length;
                uint* ptrValue2End = value1Pointer + value2.Length;
                //uint* ptrResultEnd = resultPointer + result.Length;

                // Переменные указатели
                uint* ptrCounter1, ptrCounter2, ptrTemp, ptrResult;
                for (ptrCounter2 = value1Pointer, ptrTemp = resultPointer; ptrCounter2 < ptrValue2End; ++ptrCounter2, ++ptrTemp)
                {
                    // Небольшая экономия при умножении на ноль
                    if (*ptrCounter2 == 0)
                        continue;
                    // 
                    temp = 0;
                    for (ptrCounter1 = value2Pointer, ptrResult = ptrTemp; ptrCounter1 < ptrValue1End; ++ptrCounter1, ++ptrResult)
                    {
                        temp += (ulong)*ptrCounter2 * *ptrCounter1 + (ulong)*ptrResult;
                        *ptrResult = (uint)temp;
                        temp >>= 32;
                    }
                    *ptrResult = (uint)temp;
                }
            }
        }
        public static void Multiply(uint[] value1, uint value2, uint[] result)
        {
            Multiply(value1, new uint[] {value2}, result);
        }
        #endregion Multiply
        #region Devide
        /// <summary>
        /// Divides the value by another value
        /// </summary>
        /// <param name="value1">The value to be divided and quotient value in result</param>
        /// <param name="value2">The value to divide by and remainder value in result</param>
        public static void Divide(uint[] value1, uint[] value2)
        {
            uint[] cache = new uint[value1.Length];
            Divide(value1, value2, cache);
        }
        /// <summary>
        /// Divides the value by another value
        /// </summary>
        /// <param name="value1">The value to be divided</param>
        /// <param name="value2">The value to divide by</param>
        /// <param name="result1">Quotient value, length = value1.length</param>
        /// <param name="result2">Remainder value, length = value2.length</param>
        unsafe public static void DivideOld(uint[] value1, uint[] value2, uint[] result1, uint[] result2)
        {
            Array.Copy(value1, result2, value1.Length);
            Array.Clear(result1, 0, result1.Length);
            ///TODO: change result!
            fixed (uint* result2Pointer = result2, result1Pointer = result1, value2Pointer = value2)
            {
                ulong temp;
                int index;
                int value1Length = value1.Length;
                int value2Length = value2.Length;
                int moduloMaxBitIndex = MaxNonZeroBitIndex(value2);
                // Этап вычисления модуля
                while (true)
                {
                    // Получаем индекс максимального бита полученного числа
                    index = MaxNonZeroBitIndex(result2);
                    // Если число меньше модуля
                    if (index < moduloMaxBitIndex)
                        break;
                    // Если число равно модулю по битовой длине
                    if (index == moduloMaxBitIndex)
                    {
                        // Нужно выявить, равно ли число полностью, или больше/меньше
                        uint* ptrValue = result2Pointer + value2Length - 1;
                        uint* ptrValueEnd = result2Pointer;
                        uint* ptrModulo = value2Pointer + value2Length - 1;

                        for (; ptrValue >= ptrValueEnd; --ptrValue, --ptrModulo)
                        {
                            if (*ptrModulo == *ptrValue)
                            {
                                if (ptrValue != ptrValueEnd)
                                    continue;
                                Array.Clear(result2, 0, value2Length);
                                Addition(result1, (uint)1, result1);
                                break;
                            }
                            if (*ptrModulo > *ptrValue)
                                break;
                            if (*ptrModulo < *ptrValue)
                            {
                                temp = 0;
                                // Отнять с модулем
                                ptrValue = result2Pointer;
                                ptrValueEnd = result2Pointer + value2Length;
                                ptrModulo = value2Pointer;
                                for (; ptrValue < ptrValueEnd; ++ptrValue, ++ptrModulo)
                                {
                                    temp = (ulong)*ptrValue - *ptrModulo - temp;
                                    *ptrValue = (uint)temp;
                                    temp >>= 63;
                                }
                                // Завершить отнимание
                                ptrValueEnd = result2Pointer + value1Length;
                                for (; ptrValue < ptrValueEnd; ++ptrValue)
                                {
                                    temp = (ulong)*ptrValue - temp;
                                    *ptrValue = (uint)temp;
                                    temp >>= 63;
                                }
                                Addition(result1, (uint)1, result1);
                                break;
                            }
                        }
                        break;
                    }
                    // Количество позиций для сдвига модуля
                    int shifting = index - moduloMaxBitIndex - 1;
                    temp = Substraction(result2, value2, shifting);
                    Addition(result1, new uint[] { (uint)1 }, shifting);
                    // Если перескочили в отрицательную область, то прибавим положенное число для возврата
                    if (temp != 0)
                    {
                        index = MaxZeroBitIndex(result2);
                        temp = 0;
                        // Если мы в отрицательной части на меньшую модуля величину - сложим с модулем
                        if (index < moduloMaxBitIndex)
                        {
                            // Сложить с модулем
                            uint* ptrValue = result2Pointer;
                            uint* ptrValueEnd = result2Pointer + value2Length;
                            uint* ptrModulo = value2Pointer;
                            for (; ptrValue < ptrValueEnd; ++ptrValue, ++ptrModulo)
                            {
                                temp += (ulong)*ptrValue + *ptrModulo;
                                *ptrValue = (uint)temp;
                                temp >>= 32;
                            }
                            // Завершить сложение
                            ptrValueEnd = result2Pointer + value1Length;
                            for (; ptrValue < ptrValueEnd; ++ptrValue)
                            {
                                temp += (ulong)*ptrValue;
                                *ptrValue = (uint)temp;
                                temp >>= 32;
                            }
                            break;
                        }
                        // Если величина больше -- делаем сдвиг
                        Addition(result2, value2, index - moduloMaxBitIndex);
                    }
                }
            }
        }
 
        /// <summary>
        /// Divides the value by another value (the values must be not zero or null)
        /// </summary>
        /// <param name="value1">The value to be divided</param>
        /// <param name="value2">The value to divide by</param>
        /// <param name="result1">Quotient value, length >= value1.length</param>
        /// <param name="result2">Remainder value, length >= value2.length</param>
        public static void Divide(uint[] value1, uint[] value2, uint[] result1, uint[] result2)
        {
            uint[] cache = new uint[value1.Length];
            ArrayCopyHelper.Copy(value1, result1, value1.Length);
            if (result1.Length > value1.Length)
                Array.Clear(result1, value1.Length, result1.Length - value1.Length);
            ArrayCopyHelper.Copy(value2, result2, value2.Length);
            if (result2.Length > value2.Length)
                Array.Clear(result2, value2.Length, result2.Length - value2.Length);
            Divide(result1, result2, cache);
        }
        /// <summary>
        /// Divides the value by another value (the values must be not zero or null)
        /// </summary>
        /// <param name="value1">The value to be divided</param>
        /// <param name="value2">The value to divide by</param>
        /// <param name="result1">Quotient value, length >= value1.length</param>
        /// <param name="result2">Remainder value, length >= value2.length</param>
        /// <param name="cache">Y cache, length = value1.length, must be clear</param>
        unsafe public static void Divide(uint[] value1, uint[] value2, uint[] result1, uint[] result2, uint[] cache)
        {
            ArrayCopyHelper.Copy(value1, result1, value1.Length);
            if (result1.Length > value1.Length)
                Array.Clear(result1, value1.Length, result1.Length - value1.Length);
            ArrayCopyHelper.Copy(value2, result2, value2.Length);
            if (result2.Length > value2.Length)
                Array.Clear(result2, value2.Length, result2.Length - value2.Length);
            Divide(result1, result2, cache);
        }
        /// <summary>
        /// Divides the value by another value (the values must be not zero or null)
        /// </summary>
        /// <param name="value1">The value to be divided and quotient value</param>
        /// <param name="value2">The value to divide by and remainder value</param>
        /// <param name="cache">Y cache, length >= value1.length, must be clear</param>
        unsafe public static void Divide(uint[] value1, uint[] value2, uint[] cache)
        {
            fixed (uint* xPointer = value1, yPointer = value2, qPointer = cache)
            {
                int yLength = value2.Length;
                int xLength = value1.Length;
                // Last array indexes
                uint* xLast = xPointer + xLength - 1;
                uint* yLast = yPointer + yLength - 1;

                // Check if real indexes if arrays are terrible for algorithm
                for (; xLast >= xPointer; --xLast)
                    if (*xLast != 0)
                        break;
                xLength = (int)(xLast - xPointer) + 1;
                for (; yLast >= yPointer; --yLast)
                    if (*yLast != 0)
                        break;
                yLength = (int)(yLast - yPointer) + 1;

                if (xLength < yLength)
                {
                    ArrayCopyHelper.Copy(value1, value2, xLength);
                    Array.Clear(value2, xLength, yLength - xLength);
                    Array.Clear(value1, 0, xLength);
                    return;
                }
                if (xLength == yLength)
                {
                    if (*xLast < *yLast)
                    {
                        ArrayCopyHelper.Copy(value1, value2, xLength);
                        Array.Clear(value1, 0, xLength);
                        return;
                    }
                }
                if (yLength == 1)
                {
                    value2[0] = Divide(value1, value2[0], value1, cache);
                    return;
                }
                // Normalization length
                int notZeroLength = MaxNonZeroBitIndex(*yLast) + 1;
                int stepsToNormalize = 32 - notZeroLength;

                uint* xPtr = xLast;
                uint* qPtr = qPointer + (xLength - yLength);
                uint* xPtr_1 = xLast - 1;
                uint yMax = *yLast;
                uint ySubMax = *(yLast - 1);
                if (stepsToNormalize > 0)
                {
                    yMax = (yMax << stepsToNormalize) | (ySubMax >> notZeroLength);
                    ySubMax = ySubMax << stepsToNormalize;
                    // if our array greater than 2, get the third element for speed
                    if (yLength > 2)
                        ySubMax |= *(yLast - 2) >> notZeroLength;
                }
                for (; xPtr >= xPointer + yLength - 1; --xPtr, --xPtr_1, --qPtr)
                {
                    ulong xMax = 0;
                    if (xPtr < xLast)
                        xMax = ((ulong)*(xPtr + 1)) << 32;
                    xMax += (ulong)*xPtr;
                    uint xSubMax = *(xPtr_1);
                    if (stepsToNormalize > 0)
                    {
                        xMax = (xMax << stepsToNormalize) | (xSubMax >> notZeroLength);
                        xSubMax = xSubMax << stepsToNormalize;
                        if (xLength > 2)
                            xSubMax |= *(xPtr - 2) >> notZeroLength;
                    }


                    ulong tempResult = xMax / (ulong)yMax;
                    ulong tempOstat = xMax % (ulong)yMax;
                    
                    
                    // If result is ulong, then set result as max uint
                    if (tempResult > 0xFFFFFFFF)
                    {
                        tempOstat += yMax * (tempResult - 0xFFFFFFFF);
                        tempResult = 0xFFFFFFFF;
                    }
                    while (true)
                    {
                        if (tempOstat > 0xFFFFFFFF)
                            break;
                        ulong temp1 = tempResult * ySubMax;
                        ulong temp2 = (tempOstat << 32) | (ulong)xSubMax;
                        if (temp1 <= temp2)
                            break;
                        tempResult -= (ulong)1;
                        tempOstat += yMax;
                    }

                    if (tempResult > 0)
                    {
                        ulong temp = 0;
                        uint* yPtr = yPointer, counter = xPtr - yLength + 1;
                        for (; yPtr <= yLast; ++yPtr, ++counter)
                        {
                            temp += (ulong)*yPtr * tempResult;
                            uint tempSub = (uint)temp;
                            
                            temp >>= 32;
                            if (*counter < tempSub)
                                temp += 1;
                            *counter -= tempSub;
                        }
                        if (counter <= xLast)
                        {
                            if (temp > *counter)
                            {
                                *counter -= (uint)temp;
                                yPtr = yPointer;
                                counter = xPtr - yLength + 1;
                                temp = 0;
                                for (; yPtr <= yLast; ++yPtr, ++counter)
                                {
                                    temp += (ulong)*counter + (ulong)*yPtr;
                                    *counter = (uint)temp;
                                    temp >>= 32;
                                }
                                tempResult -= 1;
                            }
                            else
                                *counter -= (uint)temp;
                        }
                    }
                    *qPtr = (uint)tempResult;
                }
                ArrayCopyHelper.Copy(value1, value2, yLength);
                ArrayCopyHelper.Copy(cache, value1, value1.Length);
            }
        }
        unsafe public static uint Divide(uint[] value1, uint value2, uint[] result1, uint[] cache)
        {
            ArrayCopyHelper.Copy(value1, result1, value1.Length);
            if (result1.Length > value1.Length)
                Array.Clear(result1, value1.Length, result1.Length - value1.Length);
            return Divide(result1, value2, cache);
        }
        /// <summary>
        /// Divides the array value by uint value (the values must be not zero or null)
        /// </summary>
        /// <param name="value1">The value to be divided</param>
        /// <param name="value2">The value to divide by</param>
        /// <param name="result1">Quotient value, length >= value1.length</param>
        /// <param name="cache">X cache, length = value1.length, must be clear</param>
        /// <returns>Remainder value</returns>
        unsafe public static uint Divide(uint[] value1, uint value2, uint[] cache)
        {

            fixed (uint* xPointer = value1, qPointer = cache)
            {
                int xLength = value1.Length;
                // Last array indexes
                uint* xLast = xPointer + xLength - 1;
                
                // Check if real indexes if arrays are terrible for algorithm
                for (; xLast >= xPointer; --xLast)
                    if (*xLast != 0)
                        break;
                xLength = (int)(xLast - xPointer) + 1;
                
                if (xLength < 1)
                    return 0;
                if (xLength == 1)
                {
                    if (*xLast < value2)
                        return *xLast;
                }
                // Normalization length
                int notZeroLength = MaxNonZeroBitIndex(value2) + 1;
                int stepsToNormalize = 32 - notZeroLength;

                uint* xPtr = xLast;
                uint* qPtr = qPointer + (xLength - 1);
                uint* xPtr_1 = xLast - 1;
                uint yMax = value2;
                if (stepsToNormalize > 0)
                    yMax = yMax << stepsToNormalize;
                
                for (; xPtr >= xPointer; --xPtr, --xPtr_1, --qPtr)
                {
                    ulong xMax = 0;
                    if (xPtr < xLast)
                        xMax = ((ulong)*(xPtr + 1)) << 32;
                    xMax += (ulong)*xPtr;
                    uint xSubMax = *(xPtr_1);
                    if (stepsToNormalize > 0)
                    {
                        xMax = (xMax << stepsToNormalize) | (xSubMax >> notZeroLength);
                        xSubMax = xSubMax << stepsToNormalize;
                        if (xLength > 2)
                            xSubMax |= *(xPtr - 2) >> notZeroLength;
                    }


                    ulong tempResult = xMax / (ulong)yMax;
                    ulong tempOstat = xMax % (ulong)yMax;


                    // If result is ulong, then set result as max uint
                    if (tempResult > 0xFFFFFFFF)
                    {
                        tempOstat += value2 * (tempResult - 0xFFFFFFFF);
                        tempResult = 0xFFFFFFFF;
                    }
                    
                    if (tempResult > 0)
                    {
                        uint* counter = xPtr;
                        ulong temp = (ulong)value2 * tempResult;
                        uint tempSub = (uint)temp;

                        temp >>= 32;
                        if (*counter < tempSub)
                            temp += 1;
                        *counter -= tempSub;
                        counter++;


                        if (counter <= xLast)
                        {
                            if (temp > *counter)
                            {
                                *counter -= (uint)temp;
                                counter = xPtr;
                                temp = (ulong)*counter + (ulong)value2;
                                *counter = (uint)temp;
                                temp >>= 32;
                                counter++;
                                *counter += (uint)temp;
                            }
                            else
                                *counter -= (uint)temp;
                        }
                    }
                    *qPtr = (uint)tempResult;
                }
            }
            value2 = value1[0];
            ArrayCopyHelper.Copy(cache, value1, value1.Length);
            return value2;
        }
        /// <summary>
        /// Returns the remainder that results from division with two values
        /// </summary>
        /// <param name="value">The value to be divided</param>
        /// <param name="modulo">The value to divide by</param>
        /// <param name="result">The remainder that results from the division</param>
        unsafe public static void Modulo(uint[] value, uint[] modulo, uint[] result)
        {
            ArrayCopyHelper.Copy(value, result, value.Length);
            if (result.Length > value.Length)
                Array.Clear(result, value.Length, result.Length - value.Length);
            Modulo(result, modulo);
        }
        /// <summary>
        /// Returns the remainder that results from division with two values
        /// </summary>
        /// <param name="value">The value to be divided and result from the division</param>
        /// <param name="modulo">The value to divide by</param>
        unsafe public static void Modulo(uint[] value, uint[] modulo)
        {
            fixed (uint* xPointer = value, yPointer = modulo)
            {
                // Last array indexes
                uint* xLast = xPointer + value.Length - 1;
                uint* yLast = yPointer + modulo.Length - 1;

                // Check if real indexes if arrays are terrible for algorithm
                for (; xLast >= xPointer; --xLast)
                    if (*xLast != 0)
                        break;
                int xLength = (int)(xLast - xPointer) + 1;
                
                for (; yLast >= yPointer; --yLast)
                    if (*yLast != 0)
                        break;
                int yLength = (int)(yLast - yPointer) + 1;

                if (xLength < yLength)
                    return;
                if (xLength == yLength)
                {
                    if (*xLast < *yLast)
                        return;
                }
                if (yLength == 1)
                {
                    uint[] cache = new uint[value.Length];
                    value[0] = Divide(value, modulo[0], cache);
                    Array.Clear(value, 1, xLength - 1);
                    return;
                }
                // Normalization length
                int notZeroLength = MaxNonZeroBitIndex(*yLast) + 1;
                int stepsToNormalize = 32 - notZeroLength;

                uint* xPtr = xLast;
                uint* xPtr_1 = xLast - 1;

                uint yMax = *yLast;
                uint ySubMax = *(yLast - 1);
                if (stepsToNormalize > 0)
                {
                    yMax = (yMax << stepsToNormalize) | (ySubMax >> notZeroLength);
                    ySubMax = ySubMax << stepsToNormalize;
                    // if our array greater than 2, get the third element for speed
                    if (yLength > 2)
                        ySubMax |= *(yLast - 2) >> notZeroLength;
                }
                for (; xPtr != xPointer + yLength - 2; --xPtr)
                {
                    ulong xMax = (ulong)*xPtr;
                    if (xPtr < xLast)
                        xMax |= ((ulong)*(xPtr + 1)) << 32;
                    uint xSubMax = *(xPtr_1);
                    xPtr_1--;
                    if (stepsToNormalize > 0)
                    {
                        xMax = (xMax << stepsToNormalize) | (xSubMax >> notZeroLength);
                        xSubMax = xSubMax << stepsToNormalize;
                        if (xLength > 2)
                            xSubMax |= *xPtr_1 >> notZeroLength;
                    }


                    ulong tempResult = xMax / (ulong)yMax;
                    ulong tempOstat = xMax % (ulong)yMax;


                    // If result is ulong, then set result as max uint
                    if (tempResult > 0xFFFFFFFF)
                    {
                        tempOstat += yMax * (tempResult - 0xFFFFFFFF);
                        tempResult = 0xFFFFFFFF;
                    }
                    while (true)
                    {
                        if (tempOstat > 0xFFFFFFFF)
                            break;
                        ulong temp1 = tempResult * ySubMax;
                        ulong temp2 = (tempOstat << 32) | (ulong)xSubMax;
                        if (temp1 <= temp2)
                            break;
                        tempResult -= (ulong)1;
                        tempOstat += yMax;
                    }

                    if (tempResult != 0)
                    {
                        ulong temp = 0;
                        uint* yPtr = yPointer, counter = xPtr - yLength + 1;
                        for (; yPtr <= yLast; ++yPtr, ++counter)
                        {
                            temp += (ulong)*yPtr * tempResult;
                            uint tempSub = (uint)temp;

                            temp >>= 32;
                            if (*counter < tempSub)
                                temp += 1;
                            *counter -= tempSub;
                        }
                        if (counter <= xLast)
                        {
                            if (temp > *counter)
                            {
                                *counter -= (uint)temp;
                                yPtr = yPointer;
                                counter = xPtr - yLength + 1;
                                temp = 0;
                                for (; yPtr <= yLast; ++yPtr, ++counter)
                                {
                                    temp += (ulong)*counter + (ulong)*yPtr;
                                    *counter = (uint)temp;
                                    temp >>= 32;
                                }
                                tempResult -= 1;
                            }
                            else
                                *counter -= (uint)temp;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Returns the remainder that results from division with two values
        /// </summary>
        /// <param name="value">The value to be divided and result from the division</param>
        /// <param name="modulo">The value to divide by</param>
        /// <param name="moduloMaxBitIndex">Maximum bit index in modulo array</param>
        unsafe public static void ModuloOld(uint[] value, uint[] modulo, int moduloMaxBitIndex)
        {
            int moduloLength = modulo.Length;
            int valueLength = value.Length;
            //if (moduloLength > valueLength)
            //    throw new Exception("value.Length < modulo.Length");
            fixed (uint* valuePointer = value, moduloPointer = modulo)
            {
                ulong temp;
                int index;
                // Этап вычисления модуля
                while (true)
                {
                    // Получаем индекс максимального бита полученного числа
                    index = MaxNonZeroBitIndex(value);
                    // Если число меньше модуля
                    if (index < moduloMaxBitIndex)
                        break;
                    // Если число равно модулю по битовой длине
                    if (index == moduloMaxBitIndex)
                    {
                        // Нужно выявить, равно ли число полностью, или больше/меньше

                        uint* ptrValue = valuePointer + moduloLength - 1;
                        uint* ptrValueEnd = valuePointer;
                        uint* ptrModulo = moduloPointer + moduloLength - 1;

                        for (; ptrValue >= ptrValueEnd; --ptrValue, --ptrModulo)
                        {
                            if (*ptrModulo == *ptrValue)
                            {
                                if (ptrValue != ptrValueEnd)
                                    continue;
                                Array.Clear(value, 0, valueLength);
                                break;
                            }
                            if (*ptrModulo > *ptrValue)
                                break;
                            if (*ptrModulo < *ptrValue)
                            {
                                temp = 0;
                                // Отнять с модулем
                                ptrValue = valuePointer;
                                ptrValueEnd = valuePointer + moduloLength;
                                ptrModulo = moduloPointer;
                                for (; ptrValue < ptrValueEnd; ++ptrValue, ++ptrModulo)
                                {
                                    temp = (ulong)*ptrValue - (ulong)*ptrModulo - temp;
                                    *ptrValue = (uint)temp;
                                    temp >>= 63;
                                }
                                // Завершить отнимание
                                ptrValueEnd = valuePointer + valueLength;
                                for (; ptrValue < ptrValueEnd; ++ptrValue)
                                {
                                    temp = (ulong)*ptrValue - temp;
                                    *ptrValue = (uint)temp;
                                    temp >>= 63;
                                }
                                break;
                            }
                        }
                        break;
                    }
                    // Количество позиций для сдвига модуля
                    int shifting = index - moduloMaxBitIndex - 1;
                    temp = Substraction(value, modulo, shifting);
                   /* // Если перескочили в отрицательную область, то прибавим положенное число для возврата
                    if (temp != 0)
                    {
                        index = MaxZeroBitIndex(value);
                        temp = 0;
                        // Если мы в отрицательной части на меньшую модуля величину - сложим с модулем
                        if (index < moduloMaxBitIndex)
                        {
                            // Сложить с модулем
                            uint* ptrValue = valuePointer;
                            uint* ptrValueEnd = valuePointer + moduloLength;
                            uint* ptrModulo = moduloPointer;
                            for (; ptrValue < ptrValueEnd; ++ptrValue, ++ptrModulo)
                            {
                                temp += (ulong)*ptrValue + (ulong)*ptrModulo;
                                *ptrValue = (uint)temp;
                                temp >>= 32;
                            }
                            // Завершить сложение
                            ptrValueEnd = valuePointer + valueLength;
                            for (; ptrValue < ptrValueEnd; ++ptrValue)
                            {
                                temp += (ulong)*ptrValue;
                                *ptrValue = (uint)temp;
                                temp >>= 32;
                            }
                            break;
                        }
                        // Если величина больше -- делаем сдвиг
                        Addition(value, modulo, index - moduloMaxBitIndex + 1);
                    }*/
                }
            }
        }

        /// <summary>
        /// Burrett reduction
        /// </summary>
        /// <param name="value">The value to be divided</param>
        /// <param name="modulo">The value to divide by</param>
        /// <param name="burrettConstant">Constant that gets with GetBurrettConstant method</param>
        /// <param name="result">Result from the division</param>
        /// <param name="cache1">Clear cache Length = value.Length</param>
        /// <param name="cache2">Clear cache Length = value.Length</param>
        unsafe public static void Modulo(uint[] value, uint[] modulo, uint[] burrettConstant, uint[] result, uint[] cache1, uint[] cache2)
        {
            int k = modulo.Length,  //TODO: k = log b m + 1
                kpp = k + 1,
                kmm = k - 1;

            uint[] q = new uint[2 * kpp];
          
            // q = x / b^(k-1)
            fixed (uint* muPointer = burrettConstant, xPointer = value, q2Pointer = q, q3Pointer = result, moduloPointer = modulo)
            {

                ulong temp;
                // Границы массивов
                uint* ptrMuEnd = muPointer + burrettConstant.Length;
                uint* ptrQ1End = xPointer + value.Length;
                
                // Переменные указатели
                uint* ptrMu, ptrQ1, q2PtrTemp, ptrQ2, ptrR2;
                for (ptrQ1 = xPointer + kmm, q2PtrTemp = q2Pointer; ptrQ1 < ptrQ1End; ++ptrQ1, ++q2PtrTemp)
                {
                    // Small performance plus
                    if (*ptrQ1 == 0)
                        continue;
                    // 
                    temp = 0;
                    for (ptrMu = muPointer, ptrQ2 = q2PtrTemp; ptrMu < ptrMuEnd; ++ptrMu, ++ptrQ2)
                    {
                        temp += (ulong)*ptrQ1 * *ptrMu + (ulong)*ptrQ2;
                        *ptrQ2 = (uint)temp;
                        temp >>= 32;
                    }
                    *ptrQ2 = (uint)temp;
                }
                // r2 = (q3 * n) mod b^(k+1)
                uint* ptrQ2End = q2Pointer + q.Length, ptrR2Temp;
                for (ptrQ2 = q2Pointer + kpp, ptrR2 = q2Pointer; ptrQ2 < q2Pointer + 2 * kpp; ++ptrQ2, ++ptrR2)
                {
                    // Small performance plus
                    if (*ptrQ2 == 0)
                        continue;
                    // 
                    temp = 0;
                    for (ptrMu = muPointer, ptrR2Temp = ptrR2; (ptrMu < ptrMuEnd) && (ptrR2Temp < q2Pointer + kpp); ++ptrMu, ++ptrR2Temp)
                    {
                        temp += (ulong)*ptrQ2 * *ptrMu + (ulong)*ptrR2Temp;
                        *ptrR2Temp = (uint)temp;
                        temp >>= 32;
                    }
                    if (ptrR2Temp < q2Pointer + kpp)
                        *ptrR2Temp = (uint)temp;
                }
                // r1 = x mod b^(k+1)
                // r = r1 - r2
                temp = 0;
                for (ptrQ1 = xPointer, ptrR2 = q2Pointer; ptrR2 < q2Pointer + kpp; ++ptrQ1, ++ptrR2)
                {
                    temp = (ulong)*ptrQ1 - *ptrR2 - temp;
                    *ptrR2 = (uint)temp;
                    temp >>= 63;
                }
                if (temp != 0)
                {
                    temp = 0;
                    for (ptrR2 = q2Pointer; ptrR2 < q2Pointer + kpp; ++ptrR2)
                    {
                        temp = ((ulong)0) - *ptrR2 - temp;
                        *ptrR2 = (uint)temp;
                        temp >>= 63;
                    }
                }

                // Classic reduction
                //...
            }
            ArrayCopyHelper.Copy(q, result, result.Length);
        }
        /// <summary>
        /// Get the Burrett constant value for reduction operations
        /// </summary>
        /// <param name="modulo"></param>
        /// <param name="result">result.length == 2*modulo.length</param>
        public static void GetBurrettConstant(uint[] modulo, uint[] result)
        {
            int k = modulo.Length * 2;
            uint[] temp = new uint[k + 1];
            temp[k] = 1;
            uint[] modulo1 = new uint[modulo.Length];
            ArrayCopyHelper.Copy(modulo, modulo1, modulo.Length);
            uint[] cache = new uint[k + 1];
            Divide(temp, modulo1, cache);
            ArrayCopyHelper.Copy(temp, result, result.Length);
        }
        #endregion Devide
        #region Negate
        /// <summary>
        /// Заменить все биты числа противоположными
        /// </summary>
        /// <param name="value">Число и результат</param>
        public static void Negate(uint[] value)
        {
            Negate(value, value);
        }
        /// <summary>
        /// Заменить все биты числа противоположными
        /// </summary>
        /// <param name="value">Число</param>
        /// <param name="result">Результат</param>
        unsafe public static void Negate(uint[] value, uint[] result)
        {
            fixed (uint* valuePointer = value, destPointer = result)
            {
                uint* ptrCounter = valuePointer;
                uint* ptrValueEnd = valuePointer + value.Length;
                uint* ptrTemp = destPointer;
                for (; ptrCounter < ptrValueEnd; ++ptrCounter, ++ptrTemp)
                    *ptrTemp = ~*ptrCounter;
            }
        }
        /// <summary>
        /// Заменить все биты числа противоположными
        /// </summary>
        /// <param name="value">Число и результат</param>
        public static void ToOPCode(uint[] value)
        {
            ToOPCode(value, value);
        }
        /// <summary>
        /// Заменить все биты числа противоположными
        /// </summary>
        /// <param name="value">Число</param>
        /// <param name="result">Результат</param>
        unsafe public static void ToOPCode(uint[] value, uint[] result)
        {
            fixed (uint* valuePointer = value, destPointer = result)
            {
                uint* ptrCounter = valuePointer;
                uint* ptrValueEnd = valuePointer + value.Length;
                uint* ptrTemp = destPointer;
                ulong temp = 1;
                for (; ptrCounter < ptrValueEnd; ++ptrCounter, ++ptrTemp)
                {
                    temp += (ulong)~*ptrCounter;
                    * ptrTemp = (uint)temp;
                    temp >>= 32;
                }
            }
        }
        #endregion Negate
        #region Shift
        /// <summary>
        /// Сдвиг массива влево (в сторону увеличения)
        /// </summary>
        /// <param name="value">Исходный вектор и результат</param>
        /// <param name="shift">Длина сдвига по вектору в битах</param>
        public static void LeftShift(uint[] value, int shift)
        {
            LeftShift(value, value, shift);
        }
        /// <summary>
        /// Сдвиг массива влево (в сторону увеличения)
        /// </summary>
        /// <param name="value">Исходный вектор</param>
        /// <param name="result">Итоговый вектор, длина не проверяется, должна быть равна или больше исходной</param>
        /// <param name="shift">Длина сдвига по вектору в битах</param>
        public static void LeftShift(uint[] value, uint[] result, int shift)
        {
            // Количество сдвигов по индексам и адрес первого элемента результата
            int indexShift = shift / 32;
            // Количество внутренних сдвигов
            int valueShift = shift % 32;
            // Заменить на указатели
            if (valueShift == 0)
            {
                // Длина сдвигаемой части
                int temp;
                if (result.Length > value.Length)
                {
                    temp = result.Length - indexShift;
                    if (temp > value.Length)
                        temp = value.Length;
                }
                else
                    temp = value.Length - indexShift;
                // Скопировать сдвигаемую часть в результат
                Array.Copy(value, 0, result, indexShift, temp);
                // Почистить начало вектора
                Array.Clear(result, 0, indexShift);
                // TODO: почистить верхушку результата, которая превышает удвоенную длину исходника
            }
            else
            {
                int t1 = value.Length + indexShift;
                int t2 = 32 - valueShift;
                // Заполнить старший байт выходного вектора
                result[t1] = (value[value.Length - 1] >> t2);
                t1--;
                // Заполнить серединку выходного массива
                for (int i = t1, i1 = value.Length - 1, i2 = value.Length - 2; i > indexShift; i--, i1--, i2--)
                    result[i] = (value[i1] << valueShift) + (value[i2] >> t2);
                // Заполнить "младший" байт массива
                result[indexShift] = (value[0] << valueShift);
            }
        }
        /// <summary>
        /// Сдвиг массива вправо (в сторону уменьшения)
        /// </summary>
        /// <param name="value">Исходный вектор и результат</param>
        /// <param name="shift">Длина сдвига по вектору в битах</param>
        public static void RightShift(uint[] value, int shift)
        {
            RightShift(value, value, shift);
        }
        /// <summary>
        /// Сдвиг массива вправо (в сторону уменьшения)
        /// </summary>
        /// <param name="value">Исходный вектор</param>
        /// <param name="result">Итоговый вектор, длина не проверяется, должна быть равна или больше исходной</param>
        /// <param name="shift">Длина сдвига по вектору в битах</param>
        public static void RightShift(uint[] value, uint[] result, int shift)
        {
            // Количество сдвигов по индексам и адрес первого элемента результата
            int indexShift = shift / 32;
            // Количество внутренних сдвигов
            int valueShift = shift % 32;
            // Заменить на указатели
            if (valueShift == 0)
            {
                // Длина сдвигаемой части
                int temp = value.Length - indexShift;
                // Скопировать сдвигаемую часть в результат
                Array.Copy(value, indexShift, result, 0, temp);
                // Почистить начало вектора
                Array.Clear(result, temp, indexShift);
                // TODO: почистить верхушку результата, которая превышает длину исходника
            }
            else
            {
                int t1 = value.Length + indexShift;
                int t2 = 32 - valueShift;
                // Заполнить старший байт выходного вектора
                result[t1] = (value[value.Length - 1] >> t2);
                t1--;
                // Заполнить серединку выходного массива
                for (int i = t1, i1 = value.Length - 1, i2 = value.Length - 2; i > indexShift; i--, i1--, i2--)
                    result[i] = (value[i1] << valueShift) + (value[i2] >> t2);
                // Заполнить "младший" байт массива
                result[indexShift] = (value[0] << valueShift);
            }
        }
        #endregion Shift
        #region Log
        public static double Log(uint[] value, double basis)
        {
            int length = RealArrayLength(value);
            if (length == 0)
                throw new Exception(); //TODO: something
            if (basis == 1.0 || basis == -1.0)
            {
                if (IfOne(value))
                    return double.NaN;
                else
                    throw new Exception(); //TODO: something
            }
            if (basis == double.PositiveInfinity || basis == double.NegativeInfinity)
            {
                if (IfOne(value))
                    return 0.0;
                else
                    throw new Exception(); //TODO: something
            }
            if (basis == 0.0)
            {
                if (IfZero(value))
                    return double.NaN;
                else
                    throw new Exception(); //TODO: something
            }
            if (length == 1)
                return Math.Log((double)value[0], basis);
            throw new NotImplementedException("Log for big numbers not implemented yet!");
        }
        #endregion Log
        #region Pow
        /// <summary>
        /// Raises value array to the power of a specified value
        /// </summary>
        /// <param name="value">The number to raise to the exponent power</param>
        /// <param name="degree">The exponent to raise value by</param>
        /// <returns>The result of raising value to the exponent power</returns>
        public static uint[] Pow(uint[] value, int degree)
        {
            degree = Math.Abs(degree);
            int nonZeroLength = MaxNonZeroBitIndex((uint)degree) + 1;
            if (nonZeroLength == 0)
                return null;
            int count1 = degree * value.Length;

            uint[] returnValue = new uint[count1];
            ArrayCopyHelper.Copy(value, returnValue, value.Length);
            for(int i = nonZeroLength - 2; i >= 0; --i)
            {
                Multiply(returnValue, returnValue);
                if (((degree >> i) & 1) == 1)
                    Multiply(returnValue, value);
            }
            return returnValue;
        }
        /// <summary>
        /// Raises ulong value to the power of a specified value
        /// </summary>
        /// <param name="value">The ulong number to raise to the exponent power</param>
        /// <param name="degree">The exponent to raise value by</param>
        /// <returns>The result array of raising ulong value to the exponent power</returns>
        public static uint[] Pow(ulong value, int degree)
        {
            degree = Math.Abs(degree);
            int nonZeroLength = MaxNonZeroBitIndex((uint)degree) + 1;
            if (nonZeroLength == 0)
                return null;
            uint[] value1Temp;
            if (value > uint.MaxValue)
            {
                value1Temp = new uint[2];
                value1Temp[0] = (uint)value;
                value1Temp[1] = (uint)(value>>32);
            }
            else
            {
                value1Temp = new uint[1];
                value1Temp[0] = (uint)value;
            }
            int count1 = degree * value1Temp.Length;
            
            uint[] returnValue = new uint[count1];
            ArrayCopyHelper.Copy(value1Temp, returnValue, value1Temp.Length);
            for (int i = nonZeroLength - 2; i >= 0; --i)
            {
                Multiply(returnValue, returnValue);
                if (((degree >> i) & 1) == 1)
                    Multiply(returnValue, value1Temp);
            }
            return returnValue;
        }
        #endregion Pow
        #region Maximum not zero (or zero) bit index
        public static int MaxZeroIndex(uint[] value)
        {
            for (int i = value.Length - 1; i >= 0; --i)
                if (value[i] != 0)
                    return i;
            return -1;
        }
        public static int MaxNonZeroIndex(uint[] value)
        {
            for (int i = value.Length - 1; i >= 0; --i)
                if (value[i] != 0)
                    return i;
            return -1;
        }
        /// <summary>
        /// Get the maximum non zero bit of uint array value
        /// </summary>
        /// <param name="value">Value fot getting</param>
        /// <returns>Non xero bit index</returns>
        public static int MaxNonZeroBitIndex(uint[] value)
        {
            for (int i = value.Length - 1; i >= 0; --i)
                if (value[i] != 0)
                    return MaxNonZeroBitIndex(value[i]) + i * 32;
            return -1;
        }
        /// <summary>
        /// Get the maximum non zero bit of uint value
        /// </summary>
        /// <param name="value">Value fot getting</param>
        /// <returns>Non xero bit index</returns>
        public static int MaxNonZeroBitIndexOld(uint value)
        {
            if (value == 0)
                return -1;
            if ((value & 2147483648) == 2147483648)
                return 31;
            if ((value & 1073741824) == 1073741824)
                return 30;
            if ((value & 536870912) == 536870912)
                return 29;
            if ((value & 268435456) == 268435456)
                return 28;
            if ((value & 134217728) == 134217728)
                return 27;
            if ((value & 67108864) == 67108864)
                return 26;
            if ((value & 33554432) == 33554432)
                return 25;
            if ((value & 16777216) == 16777216)
                return 24;
            if ((value & 8388608) == 8388608)
                return 23;
            if ((value & 4194304) == 4194304)
                return 22;
            if ((value & 2097152) == 2097152)
                return 21;
            if ((value & 1048576) == 1048576)
                return 20;
            if ((value & 524288) == 524288)
                return 19;
            if ((value & 262144) == 262144)
                return 18;
            if ((value & 131072) == 131072)
                return 17;
            if ((value & 65536) == 65536)
                return 16;
            if ((value & 32768) == 32768)
                return 15;
            if ((value & 16384) == 16384)
                return 14;
            if ((value & 8192) == 8192)
                return 13;
            if ((value & 4096) == 4096)
                return 12;
            if ((value & 2048) == 2048)
                return 11;
            if ((value & 1024) == 1024)
                return 10;
            if ((value & 512) == 512)
                return 9;
            if ((value & 256) == 256)
                return 8;
            if ((value & 128) == 128)
                return 7;
            if ((value & 64) == 64)
                return 6;
            if ((value & 32) == 32)
                return 5;
            if ((value & 16) == 16)
                return 4;
            if ((value & 8) == 8)
                return 3;
            if ((value & 4) == 4)
                return 2;
            if ((value & 2) == 2)
                return 1;
            return 0;
        }
        /// <summary>
        /// Get the maximum non zero bit of uint value
        /// </summary>
        /// <param name="value">Value fot getting</param>
        /// <returns>Non xero bit index</returns>
        public static int MaxNonZeroBitIndex(uint value)
        {
            if (value < 65536)
            {
                if (value < 256)
                {
                    if (value < 16)
                    {
                        if (value < 4)
                        {
                            if (value < 2)
                            {
                                if (value == 0)
                                    return -1;
                                return 0;
                            }
                            else
                                return 1;
                        }
                        else
                        {
                            if (value < 8)
                                return 2;
                            else
                                return 3;
                        }
                    }
                    else
                    {
                        if (value < 64)
                        {
                            if (value < 32)
                                return 4;
                            else
                                return 5;
                        }
                        else
                        {
                            if (value < 128)
                                return 6;
                            else
                                return 7;
                        }
                    }
                }
                else
                {
                    if (value < 4096)
                    {
                        if (value < 1024)
                        {
                            if (value < 512)
                                return 8;
                            else
                                return 9;
                        }
                        else
                        {
                            if (value < 2048)
                                return 10;
                            else
                                return 11;
                        }
                    }
                    else
                    {
                        if (value < 16384)
                        {
                            if (value < 8192)
                                return 12;
                            else
                                return 13;
                        }
                        else
                        {
                            if (value < 32768)
                                return 14;
                            else
                                return 15;
                        }
                    }
                }
            }
            else
            {
                if (value < 16777216)
                {
                    if (value < 1048576)
                    {
                        if (value < 262144)
                        {
                            if (value < 131072)
                                return 16;
                            else
                                return 17;
                        }
                        else
                        {
                            if (value < 524288)
                                return 18;
                            else
                                return 19;
                        }
                    }
                    else
                    {
                        if (value < 4194304)
                        {
                            if (value < 2097152)
                                return 20;
                            else
                                return 21;
                        }
                        else
                        {
                            if (value < 8388608)
                                return 22;
                            else
                                return 23;
                        }
                    }
                }
                else
                {
                    if (value < 268435456)
                    {
                        if (value < 67108864)
                        {
                            if (value < 33554432)
                                return 24;
                            else
                                return 25;
                        }
                        else
                        {
                            if (value < 134217728)
                                return 26;
                            else
                                return 27;
                        }
                    }
                    else
                    {
                        if (value < 1073741824)
                        {
                            if (value < 536870912)
                                return 28;
                            else
                                return 29;
                        }
                        else
                        {
                            if (value < 2147483648)
                                return 30;
                            else
                                return 31;
                        }
                    }
                }
            }
        }
        public static int MaxZeroBitIndex(uint value)
        {
            if (value == 0)
                return 31;
            if ((value & 2147483648) == 0)
                return 31;
            if ((value & 1073741824) == 0)
                return 30;
            if ((value & 536870912) == 0)
                return 29;
            if ((value & 268435456) == 0)
                return 28;
            if ((value & 134217728) == 0)
                return 27;
            if ((value & 67108864) == 0)
                return 26;
            if ((value & 33554432) == 0)
                return 25;
            if ((value & 16777216) == 0)
                return 24;
            if ((value & 8388608) == 0)
                return 23;
            if ((value & 4194304) == 0)
                return 22;
            if ((value & 2097152) == 0)
                return 21;
            if ((value & 1048576) == 0)
                return 20;
            if ((value & 524288) == 0)
                return 19;
            if ((value & 262144) == 0)
                return 18;
            if ((value & 131072) == 0)
                return 17;
            if ((value & 65536) == 0)
                return 16;
            if ((value & 32768) == 0)
                return 15;
            if ((value & 16384) == 0)
                return 14;
            if ((value & 8192) == 0)
                return 13;
            if ((value & 4096) == 0)
                return 12;
            if ((value & 2048) == 0)
                return 11;
            if ((value & 1024) == 0)
                return 10;
            if ((value & 512) == 0)
                return 9;
            if ((value & 256) == 0)
                return 8;
            if ((value & 128) == 0)
                return 7;
            if ((value & 64) == 0)
                return 6;
            if ((value & 32) == 0)
                return 5;
            if ((value & 16) == 0)
                return 4;
            if ((value & 8) == 0)
                return 3;
            if ((value & 4) == 0)
                return 2;
            if ((value & 2) == 0)
                return 1;
            return 0;
        }
        /// <summary>
        /// Узнать старший бит длинного числа
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Индекс бита в массиве</returns>
        public static int MaxZeroBitIndex(uint[] value)
        {
            for (int i = value.Length - 1; i >= 0; i--)
                if (value[i] != 0xFFFFFFFF)
                    return MaxZeroBitIndex(value[i]) + i * 32;
            return 0;
        }
        #endregion Maximum not zero (or zero) bit index
        #region String
        /// <summary>
        /// Parse string value with modifier (if modifier not use, the velue is decimal)
        /// </summary>
        /// <remarks>
        /// If modifier not use or for 0d-, 0D-, -d, -D, the value is decimal
        /// 0x-, 0X-, -h, -H  modifier for hex representation
        /// 0b-, 0B-, -b, -B  modifier for binary representation
        /// </remarks>
        /// <param name="value">Value string representation</param>
        /// <param name="littleEndian">true if value represents as little-Endian</param>
        public static uint[] Parse(string value, bool littleEndian)
        {
            if (value.StartsWith("-"))
                value = value.Substring(1, value.Length - 1);
            if (value.StartsWith("0x") || value.StartsWith("0X") || value.EndsWith("H") || value.EndsWith("h"))
                return ParseHex(value, littleEndian);
            if (value.EndsWith("0b") || value.StartsWith("0B") || value.EndsWith("B") || value.EndsWith("b"))
                return ParseBoolean(value, littleEndian);
            return ParseDecimal(value, littleEndian);
        }
        public static uint[] ParseHex(string value, bool littleEndian)
        {
            // Delete modifiers
            if (value.StartsWith("-"))
                value = value.Substring(1);
            if (value.StartsWith("0x") || value.StartsWith("0X"))
                value = value.Substring(2);
            if (value.EndsWith("H") || value.EndsWith("h"))
            value = value.Substring(0, value.Length - 1);

            int lengthSimbols = value.Length;
            int length = lengthSimbols / 8;
            if (lengthSimbols % 8 != 0)
                length++;

            uint[] items = new uint[length];
            int t = 0;
            int stepInReturn = 0;
            int startPosition = 0;
            int endPosition = value.Length;
            int step = 1;
            if (littleEndian)
            {
                startPosition = value.Length - 1;
                endPosition = -1;
                step = -1;
            }
            for (int i = startPosition; i != endPosition; i += step)
            {
                switch (value[i])
                {
                    case 'A':
                    case 'a':
                        items[stepInReturn] += (uint)(10 << t);
                        break;
                    case 'B':
                    case 'b':
                        items[stepInReturn] += (uint)(11 << t);
                        break;
                    case 'C':
                    case 'c':
                        items[stepInReturn] += (uint)(12 << t);
                        break;
                    case 'D':
                    case 'd':
                        items[stepInReturn] += (uint)(13 << t);
                        break;
                    case 'E':
                    case 'e':
                        items[stepInReturn] += (uint)(14 << t);
                        break;
                    case 'F':
                    case 'f':
                        items[stepInReturn] += (uint)(15 << t);
                        break;
                    default:
                        try
                        {
                            uint temp = Convert.ToUInt32(value.Substring(i, 1));
                            items[stepInReturn] += (uint)(temp << t);
                        }
                        catch { throw new Exception("Unknown simbol, position " + i); }
                        break;
                }
                t += 4;
                if (t >= 32)
                {
                    t = 0;
                    stepInReturn++;
                    if (stepInReturn >= items.Length)
                        break;
                }
            }
            return items;
        }
        public static uint[] ParseDecimal(string value, bool littleEndian)
        {
            // Delete modifiers
            if (value.StartsWith("-"))
                value = value.Substring(1, value.Length - 1);
            if (value.StartsWith("0d") || value.StartsWith("0D"))
                value = value.Substring(2);
            if (value.EndsWith("D") || value.EndsWith("d"))
                value = value.Substring(0, value.Length - 1);

            uint temp = 1;
            int length = value.Length / 9 + 1;
            uint[] items = new uint[length];

            int startPosition = 0;
            int endPosition = value.Length;
            int step = 1;
            if (!littleEndian)
            {
                startPosition = value.Length - 1;
                endPosition = -1;
                step = -1;
            }
            for (int i = startPosition; i != endPosition; i += step)
            {
                try
                {
                    temp = Convert.ToUInt32(value.Substring(i, 1));
                    Multiply(items, 10, items);
                    Addition(items, temp, items);
                }
                catch { throw new Exception("Unknown simbol, position " + i); }
            }
            return GetNonZeroItemsArray(items);
        }
        public static uint[] ParseBoolean(string value, bool littleEndian)
        {
            // Delete modifiers
            if (value.StartsWith("0b") || value.StartsWith("0B"))
                value = value.Substring(2);
            if (value.StartsWith("-0b") || value.StartsWith("-0B"))
                value = value.Substring(3);
            if (value.EndsWith("B") || value.EndsWith("b"))
                value = value.Substring(0, value.Length - 1);
            uint temp = 1;
            int length = value.Length / 32 + 1;
            uint[] items = new uint[length];

            int startPosition = 0;
            int endPosition = value.Length;
            int step = 1;
            if (!littleEndian)
            {
                startPosition = value.Length - 1;
                endPosition = -1;
                step = -1;
            }
            for (int i = startPosition; i != endPosition; i += step)
            {
                try
                {
                    temp = Convert.ToUInt32(value.Substring(i, 1));
                    if (temp < 0 || temp > 1)
                        throw new Exception();
                    Multiply(items, 2, items);
                    Addition(items, temp, items);
                }
                catch { throw new Exception("Unknown simbol, position " + i); }
            }
            return GetNonZeroItemsArray(items);
        }
        public static string ToString(uint[] value, string format, bool littleEndian)
        {
            string returnValue = string.Empty;
            bool big;
            char simbol = 'D';
            ParseFormat(format, ref simbol, out big);
            switch (simbol)
            {
                case 'x':
                case 'X':
                    returnValue = ToHexString(value, format, littleEndian);
                    break;
                case 'b':
                case 'B':
                    returnValue = ToBooleanString(value, format, littleEndian);
                    break;
                case 'e':
                case 'E':
                    returnValue = ToExponentialString(value, format, littleEndian);
                    break;
                case 'G':
                case 'g':
                case 'd':
                case 'D':
                case 'n':
                case 'N':
                case '#':
                default:
                    returnValue = ToDecimalString(value, format, littleEndian);
                    break;
            }
            return returnValue;
        }
        public static string ToHexString(uint[] value, string format, bool littleEndian)
        {
            //TODO: length miss
            bool big;
            char simbol = 'X';
            int length = ParseFormat(format, ref simbol, out big);
            if (simbol != 'X')
                return string.Empty;
            StringBuilder returnValue = new StringBuilder();
            for (int i = value.Length - 1; i >= 0; --i)
            {
                uint temp = value[i];
                for (int j = 28; j >= 0; j -= 4)
                {
                    byte k = (byte)((temp >> j) & 0xF);
                    switch (k)
                    {
                        case 10:
                            if (big)
                                returnValue.Append('A');
                            else
                                returnValue.Append('a');
                            break;
                        case 11:
                            if (big)
                                returnValue.Append('B');
                            else
                                returnValue.Append('b');
                            break;
                        case 12:
                            if (big)
                                returnValue.Append('C');
                            else
                                returnValue.Append('c');
                            break;
                        case 13:
                            if (big)
                                returnValue.Append('D');
                            else
                                returnValue.Append('d');
                            break;
                        case 14:
                            if (big)
                                returnValue.Append('E');
                            else
                                returnValue.Append('e');
                            break;
                        case 15:
                            if (big)
                                returnValue.Append('F');
                            else
                                returnValue.Append('f');
                            break;
                        default:
                            returnValue.Append(k);
                            break;
                    }

                }
            }

            int removeCount = 0;
            while (true)
            {
                if (returnValue[removeCount] == '0')
                    removeCount++;
                else
                    break;
            }
            returnValue.Remove(0, removeCount);

            string returnValueStr = string.Empty;
            if (!littleEndian)
            {
                StringBuilder valueTemp = new StringBuilder();
                for (int i = returnValue.Length - 1; i >= 0; --i)
                    valueTemp.Append(returnValue[i]);
                if (returnValue.Length < length)
                    for (int i = 0; i < (length - returnValue.Length); ++i)
                        valueTemp.Append("0");
                returnValueStr = valueTemp.ToString();
            }
            else
            {
                returnValueStr = returnValue.ToString();
                returnValue = new StringBuilder();
                if (returnValue.Length < length)
                    for (int i = 0; i < (length - returnValue.Length); ++i)
                        returnValue.Append("0");
                returnValueStr = returnValue.ToString() + returnValueStr;
            }
            return returnValueStr;
        }
        public static string ToBooleanString(uint[] value, string format, bool littleEndian)
        {
            bool big;
            char simbol = 'B';
            int length = ParseFormat(format, ref simbol, out big);

            if (simbol != 'B')
                return string.Empty;

            int maxIndex = MaxNonZeroBitIndex(value);
            StringBuilder returnValue = new StringBuilder();
            for (;maxIndex >= 0;--maxIndex)
                returnValue.Append(GetBit(value, maxIndex)?"1":"0");
            string returnValueStr = returnValue.ToString();
            if (returnValue.Length < length)
            {
                returnValue = new StringBuilder();
                for (int i = 0; i < (length - returnValue.Length); ++i)
                    returnValue.Append("0");
                returnValueStr = returnValue.ToString() + returnValueStr;
            }
            return returnValueStr;
        }
        public static string ToDecimalString(uint[] value, string format, bool littleEndian)
        {
            bool big;
            char simbol = 'D';
            int length = ParseFormat(format, ref simbol, out big);

            if (simbol != 'D' && simbol != 'N' && simbol != 'G')
                return string.Empty;
            uint[] value1 = new uint[value.Length];
            ArrayCopyHelper.Copy(value, value1, value.Length);
            StringBuilder returnValue = new StringBuilder();
            while (!IfZero(value1))
            {
                uint[] cache = new uint[value1.Length];
                uint tempVal = Divide(value1, 10, value1, cache);
                returnValue.Append(tempVal);
            }
            string returnValueStr = string.Empty;
            if (littleEndian)
            {
                StringBuilder valueTemp = new StringBuilder();
                if (returnValue.Length < length)
                    for (int i = 0; i < (length - returnValue.Length); ++i)
                        valueTemp.Append("0");
                for (int i = returnValue.Length-1; i >= 0; --i)
                    valueTemp.Append(returnValue[i]);
                returnValueStr = valueTemp.ToString();
            }
            else
            {
                if (returnValue.Length < length)
                    for (int i = 0; i < (length - returnValue.Length); ++i)
                        returnValue.Append("0");
                returnValueStr = returnValue.ToString();
            }
            if (simbol == 'G')
            {
                string maybeReturn = ToExponentialString(value, format, littleEndian);
                returnValueStr = maybeReturn.Length < returnValueStr.Length ? maybeReturn : returnValueStr;
            }
            return returnValueStr;
        }
        public static string ToExponentialString(uint[] value, string format, bool littleEndian)
        {
            bool big;
            char simbol = 'E';
            int length = ParseFormat(format, ref simbol, out big);

            if (simbol != 'E' && simbol != 'G')
                return string.Empty;
            uint[] value1 = new uint[value.Length];
            ArrayCopyHelper.Copy(value, value1, value.Length);
            StringBuilder returnValue = new StringBuilder();
            while (!IfZero(value1))
            {
                uint[] cache = new uint[value1.Length];
                uint tempVal = Divide(value1, 10, value1, cache);
                returnValue.Append(tempVal);
            }
            if (returnValue.Length == 0)
                return string.Empty;
            if (returnValue.Length == 1)
                 return returnValue[0].ToString();

            StringBuilder valueTemp = new StringBuilder();
            valueTemp.Append(returnValue[returnValue.Length - 1]);
            valueTemp.Append('.');

           
            int endIndex = 0;
            if (length != -1)
            {
                if (length < (returnValue.Length - 1))
                    endIndex = returnValue.Length - length - 1;
            }

            for (int i = returnValue.Length - 2; i >= endIndex; --i)
                valueTemp.Append(returnValue[i]);
            valueTemp.Append("E+" + (returnValue.Length - 1));

            return valueTemp.ToString();
        }
        #endregion String
        #region Other
        /// <summary>
        /// Bitwise And
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        unsafe public static void And(uint[] value1, uint[] value2, uint[] result)
        {
            int length = value2.Length;
            if (value1.Length < length)
                length = value1.Length;
            if (result.Length < length)
                length = result.Length;
            fixed (uint* value1Pointer = value1, value2Pointer = value2, resultPointer = result)
            {
                uint* ptrCounter = value1Pointer;
                uint* ptrValue2 = value2Pointer;
                uint* ptrResult = resultPointer;
                uint* ptrEnd = value1Pointer + length;
                for (; ptrCounter < ptrEnd; ++ptrCounter, ++ptrValue2, ++ptrResult)
                    *ptrResult = *ptrCounter & *ptrValue2;
                if (result.Length > length)
                {
                    //TODO
                }
            }
        }
        /// <summary>
        /// Bitwise Or
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        unsafe public static void Or(uint[] value1, uint[] value2, uint[] result)
        {
            int length = value2.Length;
            if (value1.Length < length)
                length = value1.Length;
            if (result.Length < length)
                length = result.Length;
            fixed (uint* value1Pointer = value1, value2Pointer = value2, resultPointer = result)
            {
                uint* ptrCounter = value1Pointer;
                uint* ptrValue2 = value2Pointer;
                uint* ptrResult = resultPointer;
                uint* ptrEnd = value1Pointer + length;
                for (; ptrCounter < ptrEnd; ++ptrCounter, ++ptrValue2, ++ptrResult)
                    *ptrResult = *ptrCounter | *ptrValue2;
                if (result.Length > length)
                {
                    //TODO

                }
            }
        }
        /// <summary>
        /// Exclusive Or
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="result"></param>
        unsafe public static void ExclusiveOr(uint[] value1, uint[] value2, uint[] result)
        {
            int length = value2.Length;
            if (value1.Length < length)
                length = value1.Length;
            if (result.Length < length)
                length = result.Length;
            fixed (uint* value1Pointer = value1, value2Pointer = value2, resultPointer = result)
            {
                uint* ptrCounter = value1Pointer;
                uint* ptrValue2 = value2Pointer;
                uint* ptrResult = resultPointer;
                uint* ptrEnd = value1Pointer + length;
                for (; ptrCounter < ptrEnd; ++ptrCounter, ++ptrValue2, ++ptrResult)
                    *ptrResult = *ptrCounter ^ *ptrValue2;
                if (result.Length > length)
                {
                    //TODO

                }
            }
        }
        public static int RealArrayLength(uint[] value)
        {
            if (value == null)
                return 0;
            for (int i = value.Length - 1; i < -1; --i)
                if (value[i] != 0)
                    return i;
            return 0;
        }
        public static bool IfOne(uint[] value)
        {
            if (value[0] != 1)
                return false;
            for (int i = 1; i < value.Length; ++i)
                if (value[i] != 0)
                    return false;
            return true;
        }
        /// <summary>
        /// Get Hash for array
        /// </summary>
        /// <param name="value">Input value array</param>
        /// <returns>Hash</returns>
        public static int GetHashValue(uint[] value)
        {
            uint result = 0;
            // TODO: CRC
            for (int i = 0; i != value.Length; ++i)
                result += value[i];
            return (int)result;
        }
        public static bool IfZero(uint[] value)
        {
            for (int i = 0; i < value.Length; ++i)
                if (value[i] != 0)
                    return false;
            return true;
        }
        /// <summary>
        /// Converts value to a byte array
        /// </summary>
        /// <param name="value">Value array in little endian representation</param>
        /// <param name="littleEndian">Return the byte array in little endian representation</param>
        /// <returns>Result byte array</returns>
        public static byte[] ToByteArray(uint[] value, bool littleEndian)
        {
            // Gets the input array count and bytes count in max item array
            int bigCount = value.Length - 1;
            int miniCount = 4;
            for (; bigCount >= 0; --bigCount)
                if (value[bigCount] != 0)
                {
                    if ((value[bigCount] >> 24) == 0)
                    {
                        miniCount--;
                        if ((value[bigCount] >> 16) == 0)
                        {
                            miniCount--;
                            if ((value[bigCount] >> 8) == 0)
                                miniCount--;
                        }
                    }
                    break;
                }
            if ((bigCount == 0 && miniCount == 0) || bigCount < 0)
                return null;
            byte[] returnValue = new byte[bigCount * 4 + miniCount];
            // Set output
            Buffer.BlockCopy(value, 0, returnValue, 0, returnValue.Length);
            // Check for little endian output
            if (littleEndian)
            {
                byte[] temp = new byte[returnValue.Length];
                for (int i = 0, j = temp.Length - 1; i < returnValue.Length; ++i, --j)
                    temp[j] = returnValue[i];
                returnValue = temp;
            }

            //int counter = 0;
            //int step = 1;
            //// Check for little endian output
            //if (littleEndian)
            //{
            //    counter = returnValue.Length - 1;
            //    step = -1;
            //}
            //// Set output
            //int i = 0;
            //for (; i < bigCount; i++)
            //{
            //    uint item = value[i];
            //    returnValue[counter] = (byte)(item & 0xFF);
            //    counter += step;
            //    returnValue[counter] = (byte)((item >> 8) & 0xFF);
            //    counter += step;
            //    returnValue[counter] = (byte)((item >> 16) & 0xFF);
            //    counter += step;
            //    returnValue[counter] = (byte)((item >> 24) & 0xFF);
            //    counter += step;
            //}
            //// Set the tail
            //uint item1 = value[i];
            //returnValue[counter] = (byte)(item1 & 0xFF);
            //counter += step;
            //if (miniCount > 1)
            //{
            //    returnValue[counter] = (byte)((item1 >> 8) & 0xFF);
            //    counter += step;
            //    if (miniCount > 2)
            //    {
            //        returnValue[counter] = (byte)((item1 >> 16) & 0xFF);
            //        counter += step;
            //        if (miniCount > 3)
            //            returnValue[counter] = (byte)((item1 >> 24) & 0xFF);
            //    }
            //}

            return returnValue;
        }
        /// <summary>
        /// Converts value to a uint array
        /// </summary>
        /// <param name="value">Value array in little endian representation</param>
        /// <param name="littleEndian">Return the uint array in little endian representation</param>
        /// <returns>Result uint array</returns>
        public static uint[] ToUintArray(uint[] value, bool littleEndian)
        {
            // Gets the input array count and bytes count in max item array
            int index = value.Length - 1;
            for (; index >= 0; --index)
                if (value[index] != 0)
                    break;
            if (index < 0)
                return null;
            uint[] returnValue = new uint[index + 1];
            // Set output
            ArrayCopyHelper.Copy(value, returnValue, returnValue.Length);
            // Check for little endian output
            if (littleEndian)
            {
                uint[] temp = new uint[returnValue.Length];
                for (int i = 0, j = temp.Length - 1; i < returnValue.Length; ++i, --j)
                    temp[j] = returnValue[i];
                returnValue = temp;
            }
            return returnValue;
        }
        /// <summary>
        /// Parse the byte array
        /// </summary>
        /// <param name="value">Value array</param>
        /// <param name="index">First byte index</param>
        /// <param name="length">Byte length</param>
        /// <param name="littleEndian">Little endian representation in value array</param>
        /// <returns>Result uint array</returns>
        public static uint[] Parse(byte[] value, int index, int length, bool littleEndian)
        {
            if (index < 0 || index >= value.Length)
                throw new IndexOutOfRangeException("index");
            if (length <= 0 || (index + length < value.Length))
                throw new IndexOutOfRangeException("length");
            int len = length / 4;
            if (length % 4 > 0)
                len++;
            // Check for little endian output
            uint[] returnValue = new uint[len];
            if (littleEndian)
            {
                byte[] value1 = new byte[length];
                for (int i = index, j = value1.Length - 1; j >= 0; ++i, --j)
                    value1[j] = value[i];
                Buffer.BlockCopy(value1, 0, returnValue, 0, length);
            }
            else
                Buffer.BlockCopy(value, index, returnValue, 0, length);
            return returnValue;

            /* int arrayLength = length / 4;
            if (length % 4 != 0)
                arrayLength++;
            uint[] items = new uint[length];
            // Объявим параметры для цикла
            int startPosition = index;
            int endPosition = index + length;
            int step = 1;
            if (littleEndian)
            {
                startPosition = endPosition - 1;
                endPosition = index - 1;
                step = -1;
            }
            for (int i = startPosition, iInInteger = 0, iInIntegerPiese = 0; i != endPosition; i += step)
            {
                //TODO: добавить отслеживание последних старших бит, которые могут не совпадать по размерности с длиной числа
                items[iInInteger] |= (((uint)value[i]) & 0xff) << iInIntegerPiese;
                iInIntegerPiese += 8;
                if (iInIntegerPiese >= 32)
                {
                    iInIntegerPiese = 0;
                    iInInteger += 1;
                    if (iInInteger >= items.Length)
                        break;
                }
            }
            return items;*/
        }
        #endregion Other
        #endregion Public methods
        #region Internal methods
        internal static uint[] GetNonZeroItemsArray(uint[] value)
        {
            if (value[value.Length - 1] != 0)
                return value;
            for (int i = value.Length - 2; i >= 0; --i)
                if (value[i] != 0)
                {
                    uint[] returnValue = new uint[i + 1];
                    ArrayCopyHelper.Copy(value, returnValue, returnValue.Length);
                    return returnValue;
                }
            return null;
        }
        /// <summary>
        /// Bit value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="shiftValue"></param>
        /// <returns></returns>
        internal static bool GetBit(uint[] items, int index)
        {
            int indexShift = index / 32;
            if (indexShift >= items.Length)
                throw new Exception();
            uint valueForGet = items[indexShift];
            int countShift = index - indexShift;
            return (((valueForGet >> countShift) & 0x1) == 0x1) ? true : false;
        }

        #endregion Internal methods
        #region Private methods
        private static int ParseFormat(string format, ref char simbol, out bool bigFlag)
        {
            int returnValue = -1;
            bigFlag = true;
            if (!string.IsNullOrEmpty(format))
            {
                int index = format.LastIndexOfAny(new char[]{'D', 'd', 'E', 'e', 'G', 'g', 'N', 'n', 'X', 'x', });
                if (index == -1)
                {
                    try
                    {
                        returnValue = Convert.ToInt32(format);
                        return returnValue;
                    }
                    catch
                    {
                        return returnValue;
                    }
                }
                format = format.Substring(index);
                simbol = format[0];
                if (simbol == 'd')
                    simbol = 'D';
                if (simbol == 'e')
                    simbol = 'E';
                if (simbol == 'n')
                    simbol = 'N';
                if (simbol == 'g')
                    simbol = 'G';
                if (simbol == 'x')
                    simbol = 'X';
                if (format.Length > 1)
                {
                    format = format.Substring(1);
                    string format1 = string.Empty;
                    foreach(char item in format)
                    {
                        if ("123456789".Contains(item))
                            format1 += item;
                        else
                            break;
                    }
                    if (!string.IsNullOrEmpty(format1))
                    {
                        try
                        {
                            returnValue = Convert.ToInt32(format);
                        }
                        catch{}
                    }

                }
            }
            return returnValue;
        }
        #endregion Private methods
        #region Events, overrides
        #endregion Events, overrides
        #endregion Methods
    }
}
#endregion Working namespace