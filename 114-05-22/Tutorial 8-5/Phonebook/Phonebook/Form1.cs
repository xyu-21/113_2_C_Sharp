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
    // 結構：用於記錄電話簿中的單一聯絡人資訊，包括姓名與電話
    struct PhoneBookEntry
    {
        public string name;   // 聯絡人姓名
        public string phone;  // 聯絡人電話
    }

    public partial class Form1 : Form
    {
        // 欄位：儲存所有聯絡人資料的集合
        private List<PhoneBookEntry> phoneList = new List<PhoneBookEntry>();

        public Form1()
        {
            InitializeComponent();
        }

        // ReadFile 方法：
        // 讀取 PhoneList.txt 檔案的內容，將每筆聯絡人資料解析為 PhoneBookEntry 結構，
        // 並存入 phoneList 集合。
        // 若檔案不存在或資料格式不正確，會跳出錯誤提示。
        private void ReadFile()
        {
            StreamReader inputFile; // 用於讀取檔案的 StreamReader 物件
            if (openFile.ShowDialog() == DialogResult.OK) // 開啟檔案選擇視窗
            {
                try // 嘗試讀取檔案
                {
                    inputFile = File.OpenText(openFile.FileName);  // 開啟指定檔案
                    string line;
                    while (!inputFile.EndOfStream)  // 持續讀取直到檔案結束
                    {
                        // 取得一行資料並移除多餘空白
                        line = inputFile.ReadLine().Trim();
                        // 以逗號分割資料，檢查是否正確分為兩部分
                        string[] parts = line.Split(',');
                        if (parts.Length == 2) // 格式正確
                        {
                            PhoneBookEntry entry; // 建立一個 PhoneBookEntry 結構
                            entry.name = parts[0].Trim(); // 設定姓名
                            entry.phone = parts[1].Trim(); // 設定電話
                            phoneList.Add(entry); // 加入集合
                        }
                        else // 格式不符
                        {
                            MessageBox.Show("檔案內容格式有誤");
                        }
                    }
                    inputFile.Close();
                }
                catch (Exception ex)  // 讀取過程發生例外
                {
                    MessageBox.Show("檔案讀取失敗：" + ex.Message);
                }
            }

        }

        // DisplayNames 方法：
        // 將 phoneList 集合中的所有聯絡人姓名
        // 加入 nameListBox 控制項，方便使用者選擇查詢。
        private void DisplayNames()
        {
            foreach (PhoneBookEntry entry in phoneList) // 逐一處理每筆聯絡人資料
            {
                nameListBox.Items.Add(entry.name); // 將姓名顯示於 nameListBox
            }
        }

        // Form1_Load 事件處理函式：
        // 表單載入時自動執行，
        // 會先呼叫 ReadFile 取得聯絡人資料，
        // 再呼叫 DisplayNames 將姓名顯示於清單。
        private void Form1_Load(object sender, EventArgs e)
        {
            ReadFile(); // 載入聯絡人資料

            DisplayNames(); // 將姓名顯示於 nameListBox
        }

        // nameListBox_SelectedIndexChanged 事件處理函式：
        // 當使用者在 nameListBox 選取不同聯絡人時，
        // 會將對應的電話號碼顯示在 phoneLabel 上。
        private void nameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = nameListBox.SelectedIndex; // 取得目前選取的索引
            if (index != -1)
            {
                // 將對應聯絡人的電話號碼顯示於 phoneLabel
                phoneLabel.Text = phoneList[index].phone;
            }
            else
            {
                // 若未選取任何聯絡人，則 phoneLabel 顯示「無資料」
                phoneLabel.Text = "無資料";
            }
        }

        // exitButton_Click 事件處理函式：
        // 當使用者點擊「離開」按鈕時，會結束應用程式並關閉視窗。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉視窗
            this.Close();
        }
    }
}
