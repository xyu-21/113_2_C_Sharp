using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cell_Phone_Inventory
{
    public partial class Form1 : Form
    {
        // 用來儲存 CellPhone 物件的清單
        List<CellPhone> phoneList = new List<CellPhone>();

        public Form1()
        {
            InitializeComponent();
        }

        // GetPhoneData 方法會接收一個 CellPhone 物件作為參數，
        // 並將使用者輸入的資料指派給該物件的屬性。
        private void GetPhoneData(CellPhone phone)
        {
            // 暫存手機價格的變數
            decimal price;

            // 取得手機品牌，並指派給物件的 Brand 屬性
            phone.Brand = brandTextBox.Text;

            // 取得手機型號，並指派給物件的 Model 屬性
            phone.Model = modelTextBox.Text;

            // 取得手機價格，並指派給物件的 Price 屬性
            if (decimal.TryParse(priceTextBox.Text, out price))
            {
                phone.Price = price;
            }
            else
            {
                // 顯示錯誤訊息，提醒使用者價格輸入無效
                MessageBox.Show("價格格式無效，請輸入正確的數字。");
            }
        }

        // 當使用者點擊「新增手機」按鈕時觸發的事件處理方法
        private void addPhoneButton_Click(object sender, EventArgs e)
        {
            CellPhone myPhone = new CellPhone(); // 建立新的 CellPhone 物件
            GetPhoneData(myPhone); // 呼叫方法取得使用者輸入的資料
            phoneList.Add(myPhone); // 將新的手機物件加入清單
            phoneListBox.Items.Add(myPhone.Brand + " " + myPhone.Model); // 將手機品牌和型號加入清單框中

            brandTextBox.Text = ""; // 清空品牌輸入框
            modelTextBox.Text = ""; // 清空型號輸入框
            priceTextBox.Text = ""; // 清空價格輸入框

            brandTextBox.Focus(); // 將焦點設回品牌輸入框，方便使用者繼續輸入下一個手機資料
        }

        // 當使用者在手機清單中選取不同項目時觸發的事件處理方法
        private void phoneListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = phoneListBox.SelectedIndex; // 取得選取的項目索引
            MessageBox.Show(phoneList[index].Price.ToString("C")); // 顯示選取手機的價格，格式化為貨幣形式
        }

        // 當使用者點擊「離開」按鈕時觸發的事件處理方法
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單，結束程式
            this.Close();
        }
    }
}
