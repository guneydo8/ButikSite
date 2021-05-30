using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ButikSite.Models;

namespace ButikSite.Models
{
    public class Class1
    {
        public IEnumerable<TblÜrünler> ürn { get; set; }
        public IEnumerable<TblMarkalar> mrk { get; set; }
        public IEnumerable<TblKategoriler> ktg { get; set; }
        public IEnumerable<TblYorumlar> yrm { get; set; }
        public IEnumerable<TblSepetim> spt { get; set; }
        public IEnumerable<TblDuyurular> dyr { get; set; }
        public IEnumerable<TblFavoriler> fvr { get; set; }


    }
}