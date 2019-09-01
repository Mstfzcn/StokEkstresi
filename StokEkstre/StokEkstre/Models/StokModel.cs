using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace StokEkstre.Models
{
    public class StokModel
    {
        public string MalKodu { get; set; }
        public int BaslangicTarihi { get; set; }
        public int BitisTarihi { get; set; }
    }
}