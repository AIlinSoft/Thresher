﻿#region License
//Copyright (c) 2009, Alan Spelnikov
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
using System.Runtime.InteropServices;
#endregion Using namespaces
#region Working namespace
namespace AIlins.Thresher
{
    unsafe public class Fixed
    {
        #region Classes, structures, enumerators
        #endregion Classes, structures, enumerators
        #region Constructors
        public Fixed(Array value)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            m_Value = value;
            Fix();
        }
        ~Fixed()
        {
            Free();
            m_Value = null;
        }
        #endregion Constructors
        #region Variables
        private GCHandle m_Fixed;
        private Array m_Value;
        private void* m_Ptr;
        #endregion Variables
        #region Fields
        #endregion Fields
        #region Methods
        #region Public methods
        unsafe public void* Fix()
        {
            if (!m_Fixed.IsAllocated)
            {
                m_Fixed = GCHandle.Alloc(m_Value, GCHandleType.Pinned);
                m_Ptr = (void*)Marshal.UnsafeAddrOfPinnedArrayElement(m_Value, 0);
            }
            return m_Ptr;
        }
        unsafe public void Free()
        {
            if (m_Fixed.IsAllocated)
            {
                m_Fixed.Free();
                m_Ptr = IntPtr.Zero.ToPointer();
            }
        }
        #endregion Public methods
        #region Internal methods
        #endregion Internal methods
        #region Private methods
        #endregion Private methods
        #region Events, overrides
        public static implicit operator Fixed(Array value)
        {
            return new Fixed(value);
        }
        unsafe public static implicit operator void*(Fixed value)
        {
            return value.Fix();
        }
        #endregion Events, overrides
        #endregion Methods
    }
}
#endregion Working namespace