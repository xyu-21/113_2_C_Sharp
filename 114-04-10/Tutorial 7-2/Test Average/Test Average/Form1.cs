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

namespace Test_Average
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Average 方法接受一個 int 陣列參數
        // 並返回該陣列中所有值的平均值。
        private int Average(int[] scores)
        {
            int total = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                total += scores[i];
            }
            return total / scores.Length;
        }

        // Highest 方法接受一個 int 陣列參數
        // 並返回該陣列中的最大值。
        private int Highest(int[] scores)
        {
            int highest = scores[0];
            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] > highest)
                {
                    highest = scores[i];
                }
            }
            return highest;
        }

        // Lowest 方法接受一個 int 陣列參數
        // 並返回該陣列中的最小值。
        private int Lowest(int[] scores)
        {
            int lowest = scores[0];
            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] < lowest)
                {
                    lowest = scores[i];
                }
            }
            return lowest;
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 48; // 定義陣列大小
            int[] testScores = new int[SIZE]; // 建立一個大小為 48 的整數陣列
            int index = 0; // 初始化索引
            int highestScore = 0; // 初始化最高分數
            int lowestScore = 0; // 初始化最低分數
            double averageScore = 0.0; // 初始化平均分數
            StreamReader inputFile; // 宣告 StreamReader 物件
            OpenFileDialog openFileDialog = new OpenFileDialog(); // 建立 OpenFileDialog 物件
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; // 設定檔案過濾器
            openFileDialog.Title = "選擇測試分數檔案"; // 設定對話框標題

            if (openFileDialog.ShowDialog() == DialogResult.OK) // 如果使用者選擇了檔案
            {
                try
                {
                    // 開啟檔案。
                    inputFile = File.OpenText(openFileDialog.FileName);
                    // 從檔案中讀取測試分數。
                    while (index < SIZE && !inputFile.EndOfStream)
                    {
                        testScores[index] = Convert.ToInt32(inputFile.ReadLine());
                        index++;
                    }
                    // 關閉檔案。
                    inputFile.Close();
                    // 計算平均分數、最高分數和最低分數。
                    averageScore = Average(testScores);
                    highestScore = Highest(testScores);
                    lowestScore = Lowest(testScores);
                    // 顯示結果。
                    averageScoreLabel.Text = averageScore.ToString("n2");
                    highScoreLabel.Text = highestScore.ToString();
                    lowScoreLabel.Text = lowestScore.ToString();

                    // 將分數寫入 Score.txt 檔案
                    using (StreamWriter outputFile = new StreamWriter("Score.txt"))
                    {
                        for (int i = 0; i < index; i++)
                        {
                            outputFile.WriteLine(testScores[i]);
                        }
                    }

                    // 將分數顯示在 testScoresListBox 中
                    testScoresListBox.Items.Clear();
                    for (int i = 0; i < index; i++)
                    {
                        testScoresListBox.Items.Add(testScores[i]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }

        private void testScoresListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 當選擇的項目改變時觸發的事件處理程式
        }
    }
}
