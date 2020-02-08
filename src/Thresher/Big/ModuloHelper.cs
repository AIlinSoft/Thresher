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
using System.Runtime.InteropServices;
#endregion Using namespaces
#region Working namespace
namespace AIlins.Thresher
{
    /// <summary>
    /// Big modulo integer fast math container
    /// </summary>
    public class ModuloOperations
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
        /// Сложение по модулю с результатом в первое слагаемое
        /// </summary>
        /// <remarks>
        /// Все массивы должны иметь одинаковую размерность, слагаемые представлены по модулю
        /// </remarks>
        /// <param name="value1">Первый массив и результат</param>
        /// <param name="value2">Второй массив</param>
        /// <param name="modulo">Модуль</param>
        unsafe public static void Addition(uint[] value1, uint[] value2, uint[] modulo)
        {
            Addition(value1, value2, modulo, value1);
        }
        /// <summary>
        /// Сложение по модулю с результатом в отдельный массив
        /// </summary>
        /// <remarks>
        /// Все массивы должны иметь одинаковую размерность, слагаемые представлены по модулю
        /// </remarks>
        /// <param name="value1">Первый массив</param>
        /// <param name="value2">Второй массив</param>
        /// <param name="modulo">Модуль</param>
        /// <param name="result">Итоговый массив, можно не чистить; может совпадать с value1 или value2</param>
        unsafe public static void Addition(uint[] value1, uint[] value2, uint[] modulo, uint[] result)
        {
            fixed (uint* value1Pointer = value1, value2Pointer = value2, moduloPointer = modulo, resultPointer = result)
            {
                ulong temp = 0;
                int length = modulo.Length;
                // Указатели на аргументы цикла
                uint* ptrCounter, ptrTemp, ptrResult;
                // Указатель на конец цикла
                uint* counterEndPointer = value1Pointer + length;
                // Флаг, показывающий, что после сложения из результата нужно вычесть модуль
                bool mod = true;
                // Первоначально сложить оба числа
                for (ptrCounter = value1Pointer, ptrTemp = value2Pointer, ptrResult = resultPointer; ptrCounter < counterEndPointer; ++ptrCounter, ++ptrTemp, ++ptrResult)
                {
                    temp += (ulong)*ptrCounter + (ulong)*ptrTemp;
                    *ptrResult = (uint)temp;
                    temp >>= 32;
                }
                if (temp == 0)
                {
                    // Проверить, что больше: модуль или результат
                    // Цикл почти всегда короткий, так как модуль

                    for (ptrCounter = moduloPointer + length - 1, ptrTemp = resultPointer + length - 1; ptrCounter >= moduloPointer; --ptrCounter, --ptrTemp)
                    {
                        // Если модуль хоть в одном месте больше результата, то уменьшать по модулю не будем
                        if (*ptrCounter > *ptrTemp)
                        {
                            mod = false;
                            break;
                        }
                        // Если модуль меньше -- выходим и вычитаем модуль из результата
                        if (*ptrCounter < *ptrTemp)
                            break;
                    }
                }
                // Вычитаем модуль, если нужно
                temp = 0;
                if (mod)
                {
                    counterEndPointer = resultPointer + length;
                    for (ptrCounter = resultPointer, ptrTemp = moduloPointer; ptrCounter < counterEndPointer; ++ptrCounter, ++ptrTemp)
                    {
                        temp = (ulong)*ptrCounter - (ulong)*ptrTemp - (ulong)temp;
                        *ptrCounter = (uint)temp;
                        temp >>= 63;
                    }
                }
            }
        }
        /// <summary>
        /// Сложение по модулю с результатом в первое слагаемое
        /// </summary>
        /// <remarks>
        /// Все массивы должны иметь одинаковую размерность, слагаемые представлены по модулю
        /// </remarks>
        /// <param name="value1">Первый массив и результат</param>
        /// <param name="value2">Второй массив</param>
        /// <param name="modulo">Модуль</param>
        unsafe public static void Addition(uint[] value1, uint value2, uint[] modulo)
        {
            Addition(value1, value2, modulo, value1);
        }
        /// <summary>
        /// Сложение по модулю с результатом в отдельный массив
        /// </summary>
        /// <remarks>
        /// Все массивы должны иметь одинаковую размерность, слагаемые представлены по модулю
        /// </remarks>
        /// <param name="value1">Первый массив</param>
        /// <param name="value2">Второй массив</param>
        /// <param name="modulo">Модуль</param>
        /// <param name="result">Итоговый массив, можно не чистить; может совпадать с value1 или value2</param>
        unsafe public static void Addition(uint[] value1, uint value2, uint[] modulo, uint[] result)
        {
            fixed (uint* value1Pointer = value1, moduloPointer = modulo, resultPointer = result)
            {
                ulong temp = value2;
                int length = modulo.Length;
                // Указатели на аргументы цикла
                uint* ptrCounter, ptrTemp, ptrResult;
                // Указатель на конец цикла
                uint* counterEndPointer = value1Pointer + length;
                // Флаг, показывающий, что после сложения из результата нужно вычесть модуль
                bool mod = true;
                // Первоначально сложить оба числа
                for (ptrCounter = value1Pointer, ptrResult = resultPointer; ptrCounter < counterEndPointer; ++ptrCounter, ++ptrResult)
                {
                    temp += (ulong)*ptrCounter;
                    *ptrResult = (uint)temp;
                    temp >>= 32;
                }
                if (temp == 0)
                {
                    // Проверить, что больше: модуль или результат
                    // Цикл почти всегда короткий, так как модуль

                    for (ptrCounter = moduloPointer + length - 1, ptrTemp = resultPointer + length - 1; ptrCounter >= moduloPointer; --ptrCounter, --ptrTemp)
                    {
                        // Если модуль хоть в одном месте больше результата, то уменьшать по модулю не будем
                        if (*ptrCounter > *ptrTemp)
                        {
                            mod = false;
                            break;
                        }
                        // Если модуль меньше -- выходим и вычитаем модуль из результата
                        if (*ptrCounter < *ptrTemp)
                            break;
                    }
                }
                // Вычитаем модуль, если нужно
                temp = 0;
                if (mod)
                {
                    counterEndPointer = resultPointer + length;
                    for (ptrCounter = resultPointer, ptrTemp = moduloPointer; ptrCounter < counterEndPointer; ++ptrCounter, ++ptrTemp)
                    {
                        temp = (ulong)*ptrCounter - (ulong)*ptrTemp - (ulong)temp;
                        *ptrCounter = (uint)temp;
                        temp >>= 63;
                    }
                }
            }
        }
        #endregion Addition
        #region Substraction
        /// <summary>
        /// Вычитание по модулю с результатом в первое слагаемое
        /// </summary>
        /// <remarks>
        /// Все массивы должны иметь одинаковую размерность, исходные числа представлены по модулю
        /// </remarks>
        /// <param name="value1">Первый массив и результат</param>
        /// <param name="value2">Второй массив</param>
        /// <param name="modulo">Модуль</param>
        unsafe public static void Substraction(uint[] value1, uint[] value2, uint[] modulo)
        {
            Substraction(value1, value2, modulo, value1);
        }
        /// <summary>
        /// Вычитание по модулю с результатом в отдельный массив
        /// </summary>
        /// <remarks>
        /// Все массивы должны иметь одинаковую размерность, исходные числа представлены по модулю
        /// </remarks>
        /// <param name="value1">Первый массив</param>
        /// <param name="value2">Второй массив</param>
        /// <param name="modulo">Модуль</param>
        /// <param name="result">Итоговый массив, можно не чистить; может совпадать с value1 или value2</param>
        unsafe public static void Substraction(uint[] value1, uint[] value2, uint[] modulo, uint[] result)
        {
            fixed (uint* value1Pointer = value1, value2Pointer = value2, moduloPointer = modulo, resultPointer = result)
            {
                ulong temp = 0;
                int length = modulo.Length;
                // Указатели на аргументы цикла
                uint* ptrCounter, ptrTemp, ptrResult;
                // Указатель на конец цикла
                uint* counterEndPointer = value1Pointer + length;

                for (ptrCounter = value1Pointer, ptrTemp = value2Pointer, ptrResult = resultPointer; ptrCounter < counterEndPointer; ++ptrCounter, ++ptrTemp, ++ptrResult)
                {
                    temp = (ulong)*ptrCounter - (ulong)*ptrTemp - temp;
                    *ptrResult = (uint)temp;
                    temp >>= 63;
                }
                // Если получилось отрицательное число, прибавим к результату модуль
                if (temp != 0)
                {
                    temp = 0;
                    // Указатель на конец цикла
                    counterEndPointer = resultPointer + length;
                    for (ptrCounter = resultPointer, ptrTemp = moduloPointer; ptrCounter < counterEndPointer; ++ptrCounter, ++ptrTemp)
                    {
                        temp += (ulong)*ptrCounter + (ulong)*ptrTemp;
                        *ptrCounter = (uint)temp;
                        temp >>= 32;
                    }
                }
            }
        }
        /// <summary>
        /// Вычитание по модулю с результатом в первое слагаемое
        /// </summary>
        /// <remarks>
        /// Все массивы должны иметь одинаковую размерность, исходные числа представлены по модулю
        /// </remarks>
        /// <param name="value1">Первый массив и результат</param>
        /// <param name="value2">Второй массив</param>
        /// <param name="modulo">Модуль</param>
        unsafe public static void Substraction(uint[] value1, uint value2, uint[] modulo)
        {
            Substraction(value1, value2, modulo, value1);
        }
        /// <summary>
        /// Вычитание по модулю с результатом в отдельный массив
        /// </summary>
        /// <remarks>
        /// Все массивы должны иметь одинаковую размерность, исходные числа представлены по модулю
        /// </remarks>
        /// <param name="value1">Первый массив</param>
        /// <param name="value2">Второй массив</param>
        /// <param name="modulo">Модуль</param>
        /// <param name="result">Итоговый массив, можно не чистить; может совпадать с value1 или value2</param>
        unsafe public static void Substraction(uint[] value1, uint value2, uint[] modulo, uint[] result)
        {
            fixed (uint* value1Pointer = value1, moduloPointer = modulo, resultPointer = result)
            {
                ulong temp = value2;
                int length = modulo.Length;
                // Указатели на аргументы цикла
                uint* ptrCounter, ptrTemp, ptrResult;
                // Указатель на конец цикла
                uint* counterEndPointer = value1Pointer + length;

                for (ptrCounter = value1Pointer, ptrResult = resultPointer; ptrCounter < counterEndPointer; ++ptrCounter, ++ptrResult)
                {
                    temp = (ulong)*ptrCounter - temp;
                    *ptrResult = (uint)temp;
                    temp >>= 63;
                }
                // Если получилось отрицательное число, прибавим к результату модуль
                if (temp != 0)
                {
                    temp = 0;
                    // Указатель на конец цикла
                    counterEndPointer = resultPointer + length;
                    for (ptrCounter = resultPointer, ptrTemp = moduloPointer; ptrCounter < counterEndPointer; ++ptrCounter, ++ptrTemp)
                    {
                        temp += (ulong)*ptrCounter + (ulong)*ptrTemp;
                        *ptrResult = (uint)temp;
                        temp >>= 32;
                    }
                }
            }
        }
        #endregion Substraction
        #region Multiply
        /// <summary>
        /// Умножение по модулю с результатом в первый множитель
        /// </summary>
        /// <remarks>
        /// Все массивы должны иметь одинаковую размерность
        /// </remarks>
        /// <param name="value1">Первый массив</param>
        /// <param name="value2">Второй массив</param>
        /// <param name="modulo">Модуль</param>
        unsafe public static void Multiply(uint[] value1, uint[] value2, uint[] modulo)
        {
            Multiply(value1, value2, modulo, value1, new uint[modulo.Length * 2]);
        }
        /// <summary>
        /// Умножение по модулю с результатом в отдельный массив
        /// </summary>
        /// <remarks>
        /// Все массивы должны иметь одинаковую размерность
        /// </remarks>
        /// <param name="value1">Первый массив</param>
        /// <param name="value2">Второй массив</param>
        /// <param name="modulo">Модуль</param>
        /// <param name="result">Итоговый массив, можно не чистить; может совпадать с value1 или value2</param>
        unsafe public static void Multiply(uint[] value1, uint[] value2, uint[] modulo, uint[] result)
        {
            uint[] tempMultiply = new uint[modulo.Length * 2];
            Multiply(value1, value2, modulo, result, tempMultiply);
        }

        /// <summary>
        /// Умножение по модулю с результатом в отдельный массив
        /// </summary>
        /// <param name="value1">Первый массив</param>
        /// <param name="value2">Второй массив</param>
        /// <param name="modulo">Модуль</param>
        /// <param name="result">Итоговый массив, можно не чистить</param>
        /// <param name="cache">Кэш, в два раза больше длины вектора величин, в него копируются промежуточные результаты умножений</param>
        unsafe public static void Multiply(uint[] value1, uint[] value2, uint[] modulo, uint[] result, uint[] cache)
        {
            // Внешний цикл для скорости должен иметь меньший размер
            fixed (uint* value1Pointer = value1, value2Pointer = value2, moduloPointer = modulo, cachePointer = cache)
            {
                // Этап умножения
                ulong temp;
                int length = modulo.Length;
                // Границы массивов
                uint* value1EndPointer = value1Pointer + length;
                uint* value2EndPointer = value2Pointer + length;
                uint* tempValueEndPointer = cachePointer + cache.Length;

                // Переменные указатели
                uint* ptrCounter1, ptrCounter2, ptrTemp, ptrResult;
                // Почистить кэш умножения
                for (ptrCounter1 = cachePointer; ptrCounter1 < tempValueEndPointer; ++ptrCounter1)
                    *ptrCounter1 = 0;
                // Внешний цикл
                for (ptrCounter2 = value2Pointer, ptrTemp = cachePointer; ptrCounter2 < value2EndPointer; ++ptrCounter2, ++ptrTemp)
                {
                    // Небольшая экономия при умножении на ноль
                    if (*ptrCounter2 == 0)
                        continue;
                    // 
                    temp = 0;
                    // Внутренний цикл
                    for (ptrCounter1 = value1Pointer, ptrResult = ptrTemp; ptrCounter1 < value1EndPointer; ++ptrCounter1, ++ptrResult)
                    {
                        // Нужно загрузить очередь блоков умножения современных процессоров (ориентировочно, латентность 3 такта, однако загрузка возможна каждый такт)
                        temp += (ulong)*ptrCounter2 * *ptrCounter1 + (ulong)*ptrResult;
                        *ptrResult = (uint)temp;
                        temp >>= 32;
                    }
                    *ptrResult = (uint)temp;
                }
                BigHelper.Modulo(cache, modulo);
                CommonOperations.FastCopy(cache, result, length);
            }
        }
        /// <summary>
        /// Умножение по модулю с результатом в отдельный массив
        /// </summary>
        /// <param name="value1">Первый массив</param>
        /// <param name="value2">Второй массив</param>
        /// <param name="modulo">Модуль</param>
        /// <param name="result">Итоговый массив, можно не чистить</param>
        /// <param name="cache">Кэш, в два раза больше длины вектора величин, в него копируются промежуточные результаты умножений</param>
        unsafe public static void Multiply(uint[] value1, uint value2, uint[] modulo, uint[] result, uint[] cache)
        {
            // Внешний цикл для скорости должен иметь меньший размер
            fixed (uint* value1Pointer = value1, moduloPointer = modulo, cachePointer = cache)
            {
                // Этап умножения
                ulong temp = 0;
                int length = modulo.Length;
                // Границы массивов
                uint* value1EndPointer = value1Pointer + length;
                uint* tempValueEndPointer = cachePointer + cache.Length;

                // Переменные указатели
                uint* ptrCounter1, ptrResult;
                // Почистить кэш умножения
                for (ptrCounter1 = cachePointer; ptrCounter1 < tempValueEndPointer; ++ptrCounter1)
                    *ptrCounter1 = 0;
                // Внутренний цикл
                for (ptrCounter1 = value1Pointer, ptrResult = cachePointer; ptrCounter1 < value1EndPointer; ++ptrCounter1, ++ptrResult)
                {
                    // Нужно загрузить очередь блоков умножения современных процессоров (ориентировочно, латентность 3 такта, однако загрузка возможна каждый такт)
                    temp += (ulong)value2 * *ptrCounter1 + (ulong)*ptrResult;
                    *ptrResult = (uint)temp;
                    temp >>= 32;
                }
                *ptrResult = (uint)temp;
                BigHelper.Modulo(cache, modulo);
                CommonOperations.FastCopy(cache, result, length);
            }
        }
        #endregion Multiply
        #region Divide
        /// <summary>
        /// Деление по модулю с результатом в отдельный массив
        /// </summary>
        /// <param name="value1">Делимое</param>
        /// <param name="value2">Делитель</param>
        /// <param name="modulo">Модуль</param>
        /// <param name="result">Результат</param>
        unsafe public static void Divide(uint[] value1, uint[] value2, uint[] modulo, uint[] result)
        {
            // Get inverce of devider
            int length = value2.Length;
            uint[] cache1 = new uint[length];
            uint[] cache2 = new uint[length];
            uint[] cache3 = new uint[length];
            uint[] cache4 = new uint[length];
            uint[] cache5 = new uint[length];
            uint[] cache6 = new uint[length];
            Invert(value2, modulo, result, cache1, cache2, cache3, cache4, cache5, cache6);
            // Multiply first value and inverce value
            uint[] tempMultiply = new uint[modulo.Length * 2];
            Multiply(result, value1, modulo, result, tempMultiply);
        }
        #endregion Divide
        #region Inverse
        /// <summary>
        /// Получение обратного числа по модулю от текущего 
        /// Используется расширенный алгоритм Евклида
        /// </summary>
        /// <param name="value">Первое число и результат</param>
        /// <param name="modulo">Второй число</param>
        unsafe public static void Invert(uint[] value, uint[] modulo)
        {
            int length = value.Length;
            uint[] cache1 = new uint[length];
            uint[] cache2 = new uint[length];
            uint[] cache3 = new uint[length];
            uint[] cache4 = new uint[length];
            uint[] cache5 = new uint[length];
            uint[] cache6 = new uint[length];
            Invert(value, modulo, value, cache1, cache2, cache3, cache4, cache5, cache6);
        }
        /// <summary>
        /// Получение обратного числа по модулю от текущего 
        /// Используется расширенный алгоритм Евклида
        /// </summary>
        /// <param name="value">Первое число</param>
        /// <param name="modulo">Второй число</param>
        /// <param name="result">Результат</param>
        unsafe public static void Invert(uint[] value, uint[] modulo, uint[] result)
        {
            int length = value.Length;
            uint[] cache1 = new uint[length];
            uint[] cache2 = new uint[length];
            uint[] cache3 = new uint[length];
            uint[] cache4 = new uint[length];
            uint[] cache5 = new uint[length];
            uint[] cache6 = new uint[length];
            Invert(value, modulo, result, cache1, cache2, cache3, cache4, cache5, cache6);
        }
        /// <summary>
        /// Получение обратного числа по модулю от текущего 
        /// Используется расширенный алгоритм Евклида
        /// </summary>
        /// <param name="value">Первое число</param>
        /// <param name="modulo">Второй число</param>
        /// <param name="result">Результат</param>
        unsafe public static void Invert(uint[] value, uint[] modulo, uint[] result, uint[] cache1, uint[] cache2, uint[] cache3, uint[] cache4, uint[] cache5, uint[] cache6)
        {
            uint[] a = cache1;
            uint[] b = cache2;

            uint[] q = cache3;
            uint[] r = cache4;
            uint[] v2 = cache5;
            uint[] v1 = cache6;
            int length = value.Length;
            CommonOperations.FastCopy(modulo, a, length);
            CommonOperations.FastCopy(value, b, length);
            v2[0] = 1;
            uint[] temp;
            // Пока целевое число не обнулилось
            while (!BigHelper.IfZero(b))
            {
                //TODO: Собственно бег по результату надо написать
                // Получить первый результат деления
                BigHelper.Divide(a, b, q, r);
                temp = a;
                a = b;
                b = r;
                r = temp;
                
                Multiply(q, v2, modulo, q);
                Substraction(v1, q, modulo, v1);
                temp = v1;
                v1 = v2;
                v2 = temp;
            }
            CommonOperations.FastCopy(v1, result, length);
        }
        #endregion Inverse
        /// <summary>
        /// Сдвиг массива влево в новый более длинный массив 
        /// </summary>
        /// <param name="value">Исходный вектор</param>
        /// <param name="returnValue">Итоговый вектор, длина не проверяется, должна быть совпадающей с модульной и исходной</param>
        /// <param name="modulo">Вектор модуля, длина не проверяется, должна быть совпадающей с исходной</param>
        /// <param name="cache">Временный буфер 1 для промежуточных результатов, двойной длины</param>
        /// <param name="shiftValue">Длина сдвига по вектору в битах</param>
        unsafe public static void LeftShift(uint[] value, uint[] result, uint[] modulo, uint[] cache, int shiftValue)
        {
            Array.Clear(cache, 0, cache.Length);
            // Количество сдвигов по индексам
            int indexShift = shiftValue / 32;
            // Количество внутренних сдвигов
            int valueShift = shiftValue % 32;
            // Заменить на указатели
            if (valueShift == 0)
                Array.Copy(value, 0, cache, indexShift, value.Length);
            else
            {
                
                int t1 = value.Length + indexShift;
                int t2 = 32 - valueShift;
                // Заполнить старший байт выходного вектора
                cache[t1] = (value[value.Length - 1] >> t2);
                t1--;
                // Заполнить серединку выходного массива
                for (int i = t1, i1 = value.Length - 1, i2 = value.Length - 2; i > indexShift; i--, i1--, i2--)
                    cache[i] = (value[i1] << valueShift) + (value[i2] >> t2);
                // Заполнить "младший" байт массива
                cache[indexShift] = (value[0] << valueShift);
            }
            BigHelper.Modulo(cache, modulo);
            CommonOperations.FastCopy(cache, result, value.Length);
        }
        unsafe public static void RightShift(uint[] value, uint[] result, uint[] modulo, uint[] cache, int shiftValue)
        {
            Array.Clear(cache, 0, cache.Length);
            // Количество сдвигов по индексам
            int indexShift = shiftValue / 32;
            // Количество внутренних сдвигов
            int valueShift = shiftValue % 32;
            // Заменить на указатели
            if (valueShift == 0)
                Array.Copy(value, 0, cache, indexShift, value.Length);
            else
            {
                
                int t1 = value.Length + indexShift;
                int t2 = 32 - valueShift;
                // Заполнить старший байт выходного вектора
                cache[t1] = (value[value.Length - 1] >> t2);
                t1--;
                // Заполнить серединку выходного массива
                for (int i = t1, i1 = value.Length - 1, i2 = value.Length - 2; i > indexShift; i--, i1--, i2--)
                    cache[i] = (value[i1] << valueShift) + (value[i2] >> t2);
                // Заполнить "младший" байт массива
                cache[indexShift] = (value[0] << valueShift);
            }
            BigHelper.Modulo(cache, modulo);
            CommonOperations.FastCopy(cache, result, value.Length);
        }
        /// <summary>
        /// Изменить знак числа по модулю
        /// </summary>
        /// <param name="value">Число, уже в модульном представлении</param>
        /// <param name="modulo">Модуль</param>
        /// <param name="result">Итоговый массив</param>
        unsafe public static bool ChangeSign(uint[] value, uint[] modulo, uint[] result)
        {
            bool invFlag = false;
            fixed (uint* value1Pointer = modulo, value2Pointer = value, resultPointer = result)
            {
                ulong temp = 0;
                // Указатели на аргументы цикла
                uint* ptrCounter = value1Pointer, ptrTemp = value2Pointer, ptrResult = resultPointer;
                // Указатель на конец цикла
                uint* counterEndPointer = value1Pointer + value.Length;

                for (; ptrCounter < counterEndPointer; ++ptrCounter, ++ptrTemp, ++ptrResult)
                {
                    temp = (ulong)*ptrCounter - *ptrTemp - temp;
                    *ptrResult = (uint)temp;
                    temp >>= 63;
                }

                // Если число отрицательное, нужно его привести к отрицательному виду
                if (temp > 0)
                    invFlag = true;
            }
            return invFlag;

        }
        #region Pow
        unsafe public static uint[] Pow(uint[] value1, uint[] modulo, int value2)
        {
            if (value2 == 0)
                return new uint[] { 1 };
            uint[] returnValue = new uint[value1.Length];
            CommonOperations.FastCopy(value1, returnValue, value1.Length);
            if (value2 < 0)
                Invert(returnValue, modulo);
            value2 = Math.Abs(value2);
            int nonZeroLength = BigHelper.MaxNonZeroBitIndex((uint)value2) + 1;
            if (nonZeroLength == 0)
                return null;
            for (int i = nonZeroLength - 2; i >= 0; --i)
            {
                Multiply(returnValue, returnValue, modulo);
                if (((value2 >> i) & 1) == 1)
                    Multiply(returnValue, value1, modulo);
            }
            return returnValue;
        }
        #endregion Pow
        #endregion Public methods
        #region Internal methods
        #endregion Internal methods
        #region Private methods
        #endregion Private methods
        #region  Events, overrides
        #endregion Events, overrides
        #endregion Methods
    }
}
#endregion Working namespace