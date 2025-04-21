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

        // Average 方法接收一個 List<int> 參數
        // 並回傳該清單中所有數值的平均值。
        private double Average(List<int> scores)
        {
            int total = 0;
            // 將清單中的每個分數加總
            foreach (int score in scores)
            {
                total += score;
            }
            // 回傳總和除以分數數量後的平均值
            return (double)total / scores.Count;
        }

        // Highest 方法接收一個 List<int> 參數
        // 並回傳該清單中的最大值。
        private int Highest(List<int> scores)
        {
            int highest = scores[0];
            // 遍歷清單中的每個分數，找出最大的分數
            for (int i = 1; i < scores.Count; i++)
            {
                if (scores[i] > highest)
                {
                    highest = scores[i];
                }
            }
            // 回傳最大的分數
            return highest;
        }

        // Lowest 方法接收一個 List<int> 參數
        // 並回傳該清單中的最小值。
        private int Lowest(List<int> scores)
        {
            int lowest = scores[0];
            // 遍歷清單中的每個分數，找出最小的分數
            foreach (int score in scores)
            {
                if (score < lowest)
                {
                    lowest = score;
                }
            }
            // 回傳最小的分數
            return lowest;
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            List<int> testScores = new List<int>();
            int highestScore = 0;
            int lowestScore = 0;
            double averageScore = 0.0;
            StreamReader inputFile;
            try
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    // 開啟檔案。
                    inputFile = File.OpenText(openFile.FileName);
                    // 清空 ListBox。
                    testScoresListBox.Items.Clear();
                    // 從檔案中讀取測試分數。
                    while (!inputFile.EndOfStream)
                    {
                        int score = int.Parse(inputFile.ReadLine());
                        testScores.Add(score);
                        // 將分數加入 ListBox。
                        testScoresListBox.Items.Add(score);
                    }
                    inputFile.Close();  // 關閉檔案。
                                        // 計算平均分數、最高分數和最低分數。
                    averageScore = Average(testScores);
                    highestScore = Highest(testScores);
                    lowestScore = Lowest(testScores);
                    // 顯示結果。
                    averageScoreLabel.Text = averageScore.ToString("n1");
                    highScoreLabel.Text = highestScore.ToString();
                    lowScoreLabel.Text = lowestScore.ToString();
                }
            }
            catch (Exception ex)
            {
                // 顯示錯誤訊息。
                MessageBox.Show(ex.Message, "錯誤");
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉視窗。
            this.Close();
        }
    }
}
