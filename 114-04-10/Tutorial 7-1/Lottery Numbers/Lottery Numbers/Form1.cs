using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottery_Numbers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 5; // 陣列的大小
            int[] lotteryNumbers = new int[SIZE]; // 用來儲存樂透號碼的陣列
            Random rand = new Random(); // 用來產生亂數的物件

            for (int i = 0; i < lotteryNumbers.Length; i++) // 產生樂透號碼
            {
                // 產生一個介於 1 到 42 之間的亂數，並確保不重複
                int number;
                do 
                {
                    number = rand.Next(1, 43); // 產生一個介於 1 到 42 之間的亂數
                }
                while (lotteryNumbers.Contains(number)); // 確保不重複
                lotteryNumbers[i] = number;// 產生一個介於 1 到 42 之間的亂數
            }

            //將lotteryNumbers 陣列中的數字由小到大排序
            Array.Sort(lotteryNumbers); //使用 Array.Sort() 方法來排序陣列

            //firstLabel.Text = lotteryNumbers[0].ToString(); // 顯示第一個樂透號碼
            //secondLabel.Text = lotteryNumbers[1].ToString(); // 顯示第二個樂透號碼
            //thirdLabel.Text = lotteryNumbers[2].ToString(); // 顯示第三個樂透號碼
            //fourthLabel.Text = lotteryNumbers[3].ToString(); // 顯示第四個樂透號碼
            //fifthLabel.Text = lotteryNumbers[4].ToString(); // 顯示第五個樂透號碼

            //使用迴圈來顯示樂透號碼
            Label[] showLabels = { firstLabel, secondLabel, thirdLabel, fourthLabel, fifthLabel };
            for (int i = 0; i < showLabels.Length; i++)
            {
                showLabels[i].Text = lotteryNumbers[i].ToString();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
