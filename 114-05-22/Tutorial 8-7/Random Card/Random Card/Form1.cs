using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Random_Card
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getCardButton_Click(object sender, EventArgs e)
        {
            // 建立一個 Random 物件，用於產生隨機數字
            Random rand = new Random();

            // 取得一個隨機索引值，此索引值介於 0 到 cardImageList.Images 集合的數量減一之間
            int index = rand.Next(cardImageList.Images.Count);

            // 根據隨機產生的索引值，從 cardImageList.Images 集合中選取一張圖片，並顯示在 cardPictureBox 控制項上
            cardPictureBox.Image = cardImageList.Images[index];
        }
    }
}
