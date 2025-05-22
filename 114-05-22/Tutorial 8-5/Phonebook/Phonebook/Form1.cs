using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Phonebook
{
    struct PhoneBookEntry
    {
        public string name;
        public string phone;
    }

    public partial class Form1 : Form
    {
        // 用於儲存 PhoneBookEntry 物件的清單。
        // 每個 PhoneBookEntry 物件包含一個聯絡人的姓名和電話號碼。
        private List<PhoneBookEntry> phoneList =
            new List<PhoneBookEntry>();

        public Form1()
        {
            InitializeComponent();
        }

        // ReadFile 方法負責讀取 PhoneList.txt 檔案的內容。
        // 檔案中的每一行應包含一個聯絡人的姓名和電話號碼。
        // 讀取的資料會被轉換為 PhoneBookEntry 物件，並加入到 phoneList 清單中。
        private void ReadFile()
        {

        }

        // DisplayNames 方法負責將 phoneList 清單中的所有聯絡人姓名
        // 顯示在 namesListBox 控制項中，供使用者選擇。
        private void DisplayNames()
        {

        }

        // Form1_Load 方法在表單載入時執行。
        // 通常用於初始化表單的狀態，例如讀取檔案或設定控制項的初始值。
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // nameListBox_SelectedIndexChanged 方法在使用者選擇
        // namesListBox 中的某個項目時執行。
        // 通常用於顯示選定聯絡人的詳細資訊，例如電話號碼。
        private void nameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // exitButton_Click 方法在使用者按下離開按鈕時執行。
        // 此方法會關閉表單並結束應用程式。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}
