//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tabel_nilai
    {
        public int id_nilai { get; set; }
        public int id_mahasiswa { get; set; }
        public int id_matakuliah { get; set; }
        public int nilai { get; set; }
    
        public virtual tabel_mahasiswa tabel_mahasiswa { get; set; }
        public virtual tabel_matakuliah tabel_matakuliah { get; set; }
    }
}