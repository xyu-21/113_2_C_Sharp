using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Program5_14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader inputFile; //宣告StreamReader物件
            int sum = 0; //宣告變數sum，用來存放總和
            int count = 0; //宣告變數count，用來存放資料筆數
            int temp; //宣告變數temp，用來存放讀取的檔案

            try
            {
                if(openFile.ShowDialog() == DialogResult.OK)//如果使用者按下開啟檔案按鈕 
                {                   
                    inputFile = File.OpenText(openFile.FileName); //開啟檔案
                    while (!inputFile.EndOfStream) //當沒有讀到檔案結尾時(代表檔案中還有資料)
                    {
                        count++; //資料筆數加1
                        temp = int.Parse(inputFile.ReadLine()); //將讀取的檔案轉換為int型態，並加總(+=是加總)
                        sum += temp; //將讀取的檔案轉換為int型態，並加總(+=是加總)
                        listBox1.Items.Add(temp); //將讀取的檔案放入listBox1
                    }
                    listBox1.Items.Add("總共有" + count + "個數字"); //將資料筆數放入listBox1
                    listBox1.Items.Add("總和為" + sum); //將總和放入listBox1
                    inputFile.Close(); //關閉檔案
                }
                else//如果使用者按下取消按鈕
                { 
                    MessageBox.Show("您按下取消按鈕，程式即將結束"); //顯示訊息
                    this.Close(); //關閉程式}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }
    }
}
