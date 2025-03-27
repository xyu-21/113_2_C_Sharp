namespace NumbeFrequency
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ���s�I���ƥ�B�z�禡
        private void button1_Click(object sender, EventArgs e)
        {
            const int SIZE = 1000; // �}�C�j�p
            int num; // �Τ��J���Ʀr
            double frequency; // �Ʀr�X�{���W�v
            Random random = new Random(); // �H���ƥͦ���
            int[] numbers = new int[SIZE]; // �s���H���ƪ��}�C

            // �ͦ��H���ƨö�R�}�C
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 1001); // �ͦ� 1 �� 1000 �������H����
            }

            // ���ոѪR�Τ��J���Ʀr
            if (int.TryParse(numberTextBox.Text, out num))
            {
                // �p��Ʀr�X�{���W�v
                int count = frequencyOfNumber(numbers, num);
                frequency = (double)count / SIZE;
                // ��ܵ��G
                MessageBox.Show("�Ʀr " + num + " �X�{�����v�� " + frequency.ToString("P"));
            }
            else
            {
                // ��ܿ��~�T��
                MessageBox.Show("���A���~�A�п�J���!");
            }
        }

        // �p��Ʀr�b�}�C���X�{������
        private int frequencyOfNumber(int[] numbers, int num)
        {
            int count = 0; // �p�ƾ�
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == num)
                {
                    count++; // �p�G�Ʀr�ǰt�A�p�ƾ��[�@
                }
            }
            return count; // �^�ǭp�Ƶ��G
        }
    }
}
