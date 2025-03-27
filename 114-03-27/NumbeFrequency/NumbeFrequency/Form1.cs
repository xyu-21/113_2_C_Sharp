namespace NumbeFrequency
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 按鈕點擊事件處理函式
        private void button1_Click(object sender, EventArgs e)
        {
            const int SIZE = 1000; // 陣列大小
            int num; // 用戶輸入的數字
            double frequency; // 數字出現的頻率
            Random random = new Random(); // 隨機數生成器
            int[] numbers = new int[SIZE]; // 存放隨機數的陣列

            // 生成隨機數並填充陣列
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 1001); // 生成 1 到 1000 之間的隨機數
            }

            // 嘗試解析用戶輸入的數字
            if (int.TryParse(numberTextBox.Text, out num))
            {
                // 計算數字出現的頻率
                int count = frequencyOfNumber(numbers, num);
                frequency = (double)count / SIZE;
                // 顯示結果
                MessageBox.Show("數字 " + num + " 出現的機率為 " + frequency.ToString("P"));
            }
            else
            {
                // 顯示錯誤訊息
                MessageBox.Show("型態錯誤，請輸入整數!");
            }
        }

        // 計算數字在陣列中出現的次數
        private int frequencyOfNumber(int[] numbers, int num)
        {
            int count = 0; // 計數器
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == num)
                {
                    count++; // 如果數字匹配，計數器加一
                }
            }
            return count; // 回傳計數結果
        }
    }
}
