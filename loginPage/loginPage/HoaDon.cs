using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace loginPage
{
    internal class HoaDon
    {
        public int ID {  get; set; }
        public int? MaKH { get; set; }
        public int MaBan { get; set; }
        public string? TenKH { get; set; }
        public string? SDTKH { get; set; }
        public int SoLuongMon { get; set; }
        public string TongTien { get; set; }
        public DateTime NgayAn { get; set; }
    }
}
