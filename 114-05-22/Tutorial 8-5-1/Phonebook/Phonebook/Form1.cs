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
    // 結構：用於記錄電話簿中的單一聯絡人資料，包含姓名與電話
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
        // 讀取 PhoneList.txt 檔案的內容，將每筆資料解析為 PhoneBookEntry 結構，
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
                        // 取得一行資料並去除多餘空白
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
                        else // 格式不正確
                        {
                            MessageBox.Show("檔案格式不正確");
                        }
                    }
                    inputFile.Close();
                }
                catch (Exception ex)  // 讀取檔案時發生例外
                {
                    MessageBox.Show("讀取檔案時發生錯誤：" + ex.Message);
                }
            }

        }

        // DisplayNames 方法：
        // 將 phoneList 集合中的所有聯絡人姓名顯示於 nameListBox 控制項，
        // 方便使用者選取查詢。
        private void DisplayNames()
        {
            foreach (PhoneBookEntry entry in phoneList) // 逐一處理每筆聯絡人資料
            {
                nameListBox.Items.Add(entry.name); // 將姓名加入 nameListBox 控制項
            }
        }

        // Form1_Load 事件處理函式：
        // 表單載入時自動執行，
        // 會呼叫 ReadFile 以載入電話簿資料，
        // 並呼叫 DisplayNames 來顯示所有聯絡人姓名。
        private void Form1_Load(object sender, EventArgs e)
        {
            ReadFile(); // 載入電話簿資料

            DisplayNames(); // 將姓名顯示於 nameListBox
        }

        // nameListBox_SelectedIndexChanged 事件處理函式：
        // 當使用者於 nameListBox 選取不同姓名時，
        // 會在 phoneLabel 控制項顯示對應聯絡人的電話號碼。
        private void nameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = nameListBox.SelectedIndex; // 取得目前選取的索引值
            if (index != -1)
            {
                // 在 phoneLabel 顯示對應聯絡人的電話
                phoneLabel.Text = phoneList[index].phone;
            }
            else
            {
                // 若未選取任何姓名，則清除 phoneLabel 內容
                phoneLabel.Text = "無資料";
            }
        }

        // exitButton_Click 事件處理函式：
        // 當使用者點擊「離開」按鈕時，會將 phoneList 集合內容寫回原始檔案，然後關閉表單。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 檢查是否有正確開啟檔案
            if (!string.IsNullOrEmpty(openFile.FileName) && File.Exists(openFile.FileName))
            {
                StreamWriter writer = null;
                try
                {
                    // 以覆寫方式開啟檔案進行寫入
                    writer = File.CreateText(openFile.FileName);
                    foreach (PhoneBookEntry entry in phoneList)
                    {
                        writer.WriteLine($"{entry.name},{entry.phone}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("儲存檔案時發生錯誤：" + ex.Message);
                }
                finally
                {
                    if (writer != null)
                        writer.Close();
                }
            }
            else
            {
                MessageBox.Show("找不到原始檔案，無法儲存資料。");
            }
            // 關閉表單
            this.Close();
        }

        // 讀取 textBoxName 與 textBoxPhone 的輸入內容，新增至 phoneList 集合
        // 並更新 nameListBox 顯示的聯絡人清單
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            PhoneBookEntry entry; // 建立一個 PhoneBookEntry 結構
            entry.name = textBoxName.Text.Trim(); // 取得姓名
            entry.phone = textBoxPhone.Text.Trim(); // 取得電話
                                                    // 檢查姓名與電話是否皆有輸入
            if (string.IsNullOrEmpty(entry.name) || string.IsNullOrEmpty(entry.phone))
            {
                MessageBox.Show("姓名或電話號碼不能為空");
                return;
            }
            // 檢查是否已有相同姓名的聯絡人
            foreach (PhoneBookEntry existingEntry in phoneList)
            {
                if (existingEntry.name.Equals(entry.name, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("姓名已存在");
                    return;
                }
            }
            // 新增聯絡人資料至集合
            phoneList.Add(entry); // 加入集合
            nameListBox.Items.Add(entry.name); // 將姓名顯示於 nameListBox
                                               // 清除輸入框內容
            textBoxName.Clear();
            textBoxPhone.Clear();
            // 清除電話顯示欄位
            phoneLabel.Text = "";
        }
    }
}