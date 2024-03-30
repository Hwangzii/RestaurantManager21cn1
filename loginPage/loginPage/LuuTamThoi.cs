using System.Collections.Generic;

namespace loginPage
{
    // Hùng: Tạo class object để lưu hóa đơn
    public class LuuHoaDon
    {
        public string Ban { get; set; }

        public List<FoodItem> Danhsach = new List<FoodItem>();
    }
}
