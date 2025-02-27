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
            double distance, gas, average;//�ŧi�ϰ��ܼ�
            if (double.TryParse(distanceTextBox.Text, out distance)) //�NdistanceTextBox����r�ন�Ʀr
            {
                if (double.TryParse(gasTextBox.Text, out gas)) //�NgasTextBox����r�ন�Ʀr
                {
                    average = distance / gas; //�p�⥭����
                    averageLabel.Text = average.ToString("f2") + "����/����"; //��ܥ�����
                    logListBox.Items.Add(average.ToString("f2") + "����/����"); //�s�W�����Ȩ�logListBox
                }
                else
                {
                    MessageBox.Show("�o�ӽп�J�Ʀr");
                    gasTextBox.Focus(); //�N��в���gasTextBox
                    gasTextBox.Text = ""; //�M��gasTextBox
                    return;//��������k(�i�g�i���g)
                }
            }
            else
            {
                MessageBox.Show("���{�п�J�Ʀr");
                distanceTextBox.Focus(); //�N��в���distanceTextBox
                distanceTextBox.Text = ""; //�M��distanceTextBox
                return;//��������k(�i�g�i���g)
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            logListBox.Items.Clear(); //�M��logListBox
            logListBox.Items.Add("�����o�Ӭ���:");//�s�W��r��logListBox
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double sum = 0; //�ŧi�ϰ��ܼ�
            if (logListBox.Items.Count > 1) //�p�GlogListBox�����ؼƤj��1
            {
                
                for (int i = 1; i < logListBox.Items.Count; i++) //�q1�}�l�O�]����0�ӬO�����o�Ӭ���
                {
                    sum += double.Parse(logListBox.Items[i].ToString().Replace("����/����", "")); // �N�䮳�������Ů�
                }
                logListBox.Items.Add("�����o��:" + (sum / (logListBox.Items.Count - 1)).ToString("f2") + "����/����"); //��ܥ����o��
            }
            else
            {
                MessageBox.Show("�S������");
            }
        }
    }
}
