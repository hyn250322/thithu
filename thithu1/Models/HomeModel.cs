using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using thithu1.Context;

namespace thithu1.Models
{
    public class HomeModel
    {
        public List<Sanpham> ListProduct { get; set; }
        public List<PhanLoaiSanPham> ListCategory { get; set; }
    }
}