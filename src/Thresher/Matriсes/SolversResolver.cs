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
    public static class SolversResolver
    {
        #region Classes, structures, enumerators
        #endregion Classes, structures, enumerators
        #region Constructors
        static SolversResolver()
        {
            RegisterGenericSolver<double>(new DoubleSolver());
            RegisterGenericSolver<Complex>(new ComplexSolver());
            RegisterGenericSolver<Block2x2>(new Block2x2Solver());
            RegisterGenericSolver<int>(new Int32Solver());
            RegisterGenericSolver<float>(new SingleSolver());
            RegisterGenericSolver<long>(new Int64Solver());
            
            RegisterArraySolver<double>(new DoubleArraySolver());
            RegisterArraySolver<Complex>(new ComplexArraySolver());
            RegisterArraySolver<Block2x2>(new Block2x2ArraySolver());

            RegisterMatrixSolver<double>(new DoubleMatrixSolver());
            RegisterMatrixSolver<Complex>(new ComplexMatrixSolver());
            RegisterMatrixSolver<Block2x2>(new Block2x2MatrixSolver());
        }
        #endregion Constructors
        #region Variables
        internal static Dictionary<Type, object> m_MatrixSolvers = new Dictionary<Type, object>();
        internal static Dictionary<Type, object> m_ArraySolvers = new Dictionary<Type, object>();
        internal static Dictionary<Type, object> m_GenericSolvers = new Dictionary<Type, object>();
        #endregion Variables
        #region Fields
        #endregion Fields
        #region Methods
        #region Public methods
        public static void RegisterGenericSolver<T>(Solver<T> solver)
        {
            Type valueType = typeof(T);
            if (solver == null)
                throw new ArgumentNullException("solver");
            m_GenericSolvers[valueType] = solver;
        }
        public static void RegisterArraySolver<T>(ArraySolver<T> solver)
        {
            Type valueType = typeof(T);
            if (solver == null)
                throw new ArgumentNullException("solver");
            m_ArraySolvers[valueType] = solver;
        }
        public static void RegisterMatrixSolver<T>(MatrixSolver<T> solver)
        {
            Type valueType = typeof(T);
            if (solver == null)
                throw new ArgumentNullException("solver");
            m_MatrixSolvers[valueType] = solver;
        }
        public static Solver<T> GetGenericSolver<T>()
        {
            Type valueType = typeof(T);
            object solver;
            while (valueType != null)
            {
                if (m_GenericSolvers.TryGetValue(valueType, out solver))
                    return solver as Solver<T>;
                valueType = valueType.BaseType;
            }
            throw new NotImplementedException("Type is not implemented!");
        }
        public static ArraySolver<T> GetArraySolver<T>()
        {
            Type valueType = typeof(T);
            object solver;
            while (valueType != null)
            {
                if (m_MatrixSolvers.TryGetValue(valueType, out solver))
                    return solver as ArraySolver<T>;
                valueType = valueType.BaseType;
            }
            throw new NotImplementedException("Type is not implemented!");
        }
        public static MatrixSolver<T> GetMatrixSolver<T>()
        {
            Type valueType = typeof(T);
            object solver;
            while (valueType != null)
            {
                if (m_MatrixSolvers.TryGetValue(valueType, out solver))
                    return solver as MatrixSolver<T>;
                valueType = valueType.BaseType;
            }
            throw new NotImplementedException("Type is not implemented!");
        }
        #endregion Public methods
        #region Internal methods
        #endregion Internal methods
        #region Private methods
        #endregion Private methods
        #region Events, overrides
        #endregion Events, overrides
        #endregion Methods
    }
}
#endregion Working namespace