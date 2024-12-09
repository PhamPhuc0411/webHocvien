﻿using System;
using System.Collections.Generic;

namespace WebApplication_hocvien.Models
{
    public partial class Lylich
    {
        public Lylich()
        {
            Diemthis = new HashSet<Diemthi>();
        }

        public string Mshv { get; set; } = null!;
        public string? Tenhv { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public bool? Phai { get; set; }
        public string? Malop { get; set; }

        public virtual Lop? MalopNavigation { get; set; }
        public virtual ICollection<Diemthi> Diemthis { get; set; }
    }
}
