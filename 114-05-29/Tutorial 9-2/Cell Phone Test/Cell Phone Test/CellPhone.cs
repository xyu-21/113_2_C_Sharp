using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cell_Phone_Test
{
    class CellPhone
    {
        private string _brand; // 用來儲存手機品牌名稱的私有欄位
        private string _model; // 用來儲存手機型號的私有欄位
        private decimal _price; // 用來儲存手機價格的公開欄位（建議改為私有欄位並使用屬性存取）

        public CellPhone()
        {
            // 建構函式，初始化手機品牌、型號與價格為預設值
            _brand = "";
            _model = "";
            _price = 0m;
        }

        public string Brand
        {
            get { return _brand; } // 屬性用來存取手機品牌名稱
            set { _brand = value; } // 屬性用來設定手機品牌名稱
        }

        public string Model
        {
            get { return _model; } // 屬性用來存取手機型號
            set { _model = value; }  // 屬性用來設定手機型號
        }

        public decimal Price
        {
            get { return _price; } // 屬性用來存取手機價格
            set
            {
                // 設定價格時，檢查價格是否為負值，若為負值則拋出例外
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price cannot be negative."); // 價格不可為負值，否則拋出例外
                }
            }
        }
    }
}