using System;
using System.Collections.Generic;
using System.Text;

namespace Task3.Interfaces
{
    /// <summary>
    /// Contains basic material properties.
    /// </summary>
    public interface IMaterial
    {
        /// <summary>
        /// Contains true if the material can be painted, 
        /// false otherwise.
        /// </summary>
        public bool CanBePainted { get; }
    }
}
