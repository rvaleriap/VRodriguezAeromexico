//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Collections.Generic;
    
    public partial class VueloPasajero
    {
        public int IdVueloPasajero { get; set; }
        public Nullable<int> IdVuelo { get; set; }
        public Nullable<int> IdPasajero { get; set; }
    
        public virtual Pasajero Pasajero { get; set; }
        public virtual Vuelo Vuelo { get; set; }
    }
}
