//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Table_satis
    {
        public int satısıd { get; set; }
        public Nullable<int> Urun { get; set; }
        public Nullable<int> Musteri { get; set; }
        public Nullable<byte> Adet { get; set; }
        public Nullable<decimal> Fıyat { get; set; }
    
        public virtual Table_musteri Table_musteri { get; set; }
        public virtual Table_urun Table_urun { get; set; }
    }
}
