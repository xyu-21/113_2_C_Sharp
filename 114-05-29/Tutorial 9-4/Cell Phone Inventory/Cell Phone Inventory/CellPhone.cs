using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cell_Phone_Inventory
{
    class CellPhone
    {
        // 欄位：儲存手機品牌名稱
        private string _brand;

        // 欄位：儲存手機型號名稱
        private string _model;

        // 欄位：儲存手機的零售價格（以十進位表示，適合金額運算）
        private decimal _price;

        // 建構函式：初始化手機物件，品牌與型號設為空字串，價格設為 0
        public CellPhone()
        {
            _brand = "";
            _model = "";
            _price = 0m;
        }

        // 屬性：取得或設定手機品牌
        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        // 屬性：取得或設定手機型號
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        // 屬性：取得或設定手機價格
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
    }
}
