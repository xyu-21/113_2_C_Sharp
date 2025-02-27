namespace Tutorial_4_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            double distance, gas, average;//宣告區域變數
            if (double.TryParse(distanceTextBox.Text, out distance)) //將distanceTextBox的文字轉成數字
            {
                if (double.TryParse(gasTextBox.Text, out gas)) //將gasTextBox的文字轉成數字
                {
                    average = distance / gas; //計算平均值
                    averageLabel.Text = average.ToString("f2") + "公里/公升"; //顯示平均值
                    logListBox.Items.Add(average.ToString("f2") + "公里/公升"); //新增平均值到logListBox
                }
                else
                {
                    MessageBox.Show("油耗請輸入數字");
                    gasTextBox.Focus(); //將游標移至gasTextBox
                    gasTextBox.Text = ""; //清空gasTextBox
                    return;//結束此方法(可寫可不寫)
                }
            }
            else
            {
                MessageBox.Show("里程請輸入數字");
                distanceTextBox.Focus(); //將游標移至distanceTextBox
                distanceTextBox.Text = ""; //清空distanceTextBox
                return;//結束此方法(可寫可不寫)
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            logListBox.Items.Clear(); //清空logListBox
            logListBox.Items.Add("平均油耗紀錄:");//新增文字到logListBox
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double sum = 0; //宣告區域變數
            if (logListBox.Items.Count > 1) //如果logListBox的項目數大於1
            {
                
                for (int i = 1; i < logListBox.Items.Count; i++) //從1開始是因為第0個是平均油耗紀錄
                {
                    sum += double.Parse(logListBox.Items[i].ToString().Replace("公里/公升", "")); // 將其拿掉換成空格
                }
                logListBox.Items.Add("平均油耗:" + (sum / (logListBox.Items.Count - 1)).ToString("f2") + "公里/公升"); //顯示平均油耗
            }
            else
            {
                MessageBox.Show("沒有紀錄");
            }
        }
    }
}
