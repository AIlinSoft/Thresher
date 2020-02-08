#region Using namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion Using namespaces
#region Working namespace
namespace AIlins.Thresher
{
    public class SolvingContext
    {
        #region Classes, structures, enumerators
        #endregion Classes, structures, enumerators
        #region Constructors
        static SolvingContext()
        {
        }
        public SolvingContext(int count)
        {
            m_Count = count;
        }
        #endregion Constructors
        #region Variables
        internal int m_Count;
        internal int[][] vv;
        #endregion Variables
        #region Fields
        public int Count
        {
            get
            {
                return m_Count;
            }
        }
        #endregion Fields
        #region Methods
        #region Public methods
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