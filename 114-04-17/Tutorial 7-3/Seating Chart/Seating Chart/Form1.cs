using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seating_Chart
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void displayPriceButton_Click(object sender, EventArgs e)
        {
            // TODO: 在此處新增顯示票價的邏輯。
            // 此方法會在使用者按下 "顯示票價" 按鈕時觸發。
            const int ROWS = 6;
            const int COLS = 4;
            int row;
            int col;

            decimal[,] prices = { {450m, 450m, 450m, 450m},
                                  {425m, 425m, 425m, 425m},
                                  {400m, 400m, 400m, 400m},
                                  {375m, 375m, 375m, 375m},
                                  {375m, 375m, 375m, 375m},
                                  {350m, 350m, 350m, 350m}
                                };
            // 宣告一個二維陣列，並初始化票價。

            // 修正拼寫錯誤，將 TryPaserse 改為 TryParse，並移除多餘的 int 關鍵字。
            if (int.TryParse(rowTextBox.Text, out row) && int.TryParse(colTextBox.Text, out col))
            {
                // 確保 row 和 col 的值在有效範圍內。
                if (row >= 1 && row <= ROWS && col >= 1 && col <= COLS)
                {
                    // 將使用者輸入的行和列轉換為價格。
                    priceLabel.Text = prices[row - 1, col - 1].ToString("C");
                }
                else
                {
                    // 如果行或列超出範圍，顯示錯誤訊息。
                    MessageBox.Show("請輸入有效的行和列號碼。");
                }
            }
            else
            {
                // 如果輸入的行或列不是有效的數字，顯示錯誤訊息。
                MessageBox.Show("請輸入有效的數字。");
            }
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            // 當使用者按下 "離開" 按鈕時，會執行此方法以關閉應用程式。
            this.Close();
        }
    }
}
