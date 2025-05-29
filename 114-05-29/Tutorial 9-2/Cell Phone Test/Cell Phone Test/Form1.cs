using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_Phone_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void GetPhoneData(CellPhone phone)
        {
            decimal price; // 宣告一個 decimal 型別的變數 price，用來儲存價格

            phone.Brand = brandTextBox.Text; // 從品牌輸入框取得品牌名稱，並指派給 phone 物件的 Brand 屬性
            phone.Model = modelTextBox.Text; // 從型號輸入框取得型號，並指派給 phone 物件的 Model 屬性

            if (!decimal.TryParse(priceTextBox.Text, out price)) // 嘗試將價格輸入框的文字轉換為 decimal 型別
            {
                phone.Price = price; // 如果轉換成功，將價格指派給 phone 物件的 Price 屬性
            }
            else 
            {
                MessageBox.Show("價格輸入錯誤，請輸入有效的數字。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error); // 如果轉換成功，將價格指派給 phone 物件的 Price 屬性
                priceTextBox.Clear(); // 清除價格輸入框的內容
            }

        }
        private void createObjectButton_Click(object sender, EventArgs e)
        {
            CellPhone myPhone = new CellPhone(); // 建立 CellPhone 類別的物件 myPhone

            GetPhoneData(myPhone); // 將表單資料指派給 myPhone 物件

            brandLabel.Text = myPhone.Brand; // 將 myPhone 物件的品牌顯示在label上。
            modelLabel.Text = myPhone.Model; // 將 myPhone 物件的型號顯示在label上。
            priceLabel.Text = myPhone.Price.ToString("C"); // 將 myPhone 物件的價格顯示在label上，格式化為貨幣格式。
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}
