using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Color_Spectrum
{
    // 定義 Spectrum 列舉，代表彩虹的七種顏色
    enum Spectrum
    {
        Red,    // 紅色
        Orange, // 橙色
        Yellow, // 黃色
        Green,  // 綠色
        Blue,   // 藍色
        Indigo, // 靛色
        Violet  // 紫色
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // DisplayColor 方法會將傳入的 Spectrum 列舉值轉為字串，
        // 並顯示於 colorLabel 控制項上，讓使用者知道目前選擇的顏色名稱。
        private void DisplayColor(Spectrum color)
        {
            switch (color)
            {
                case Spectrum.Red:
                    colorLabel.Text = "紅色";
                    break;
                case Spectrum.Orange:
                    colorLabel.Text = "橙色";
                    break;
                case Spectrum.Yellow:
                    colorLabel.Text = "黃色";
                    break;
                case Spectrum.Green:
                    colorLabel.Text = "綠色";
                    break;
                case Spectrum.Blue:
                    colorLabel.Text = "藍色";
                    break;
                case Spectrum.Indigo:
                    colorLabel.Text = "靛色";
                    break;
                case Spectrum.Violet:
                    colorLabel.Text = "紫色";
                    break;
                default:
                    colorLabel.Text = "未知";
                    break;
            }
        }

        // 當使用者點擊紅色標籤時，呼叫 DisplayColor 方法顯示紅色名稱
        private void redLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Red);
        }

        // 當使用者點擊橙色標籤時，呼叫 DisplayColor 方法顯示橙色名稱
        private void orangeLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Orange);
        }

        // 當使用者點擊黃色標籤時，呼叫 DisplayColor 方法顯示黃色名稱
        private void yellowLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Yellow);
        }

        // 當使用者點擊綠色標籤時，呼叫 DisplayColor 方法顯示綠色名稱
        private void greenLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Green);
        }

        // 當使用者點擊藍色標籤時，呼叫 DisplayColor 方法顯示藍色名稱
        private void blueLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Blue);
        }

        // 當使用者點擊靛色標籤時，呼叫 DisplayColor 方法顯示靛色名稱
        private void indigoLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Indigo);
        }

        // 當使用者點擊紫色標籤時，呼叫 DisplayColor 方法顯示紫色名稱
        private void violetLabel_Click(object sender, EventArgs e)
        {
            DisplayColor(Spectrum.Violet);
        }
    }
}
