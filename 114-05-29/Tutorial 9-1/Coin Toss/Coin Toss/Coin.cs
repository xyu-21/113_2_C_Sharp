using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin_Toss
{
    internal class Coin
    {
        private string sideUp; // 硬幣正面朝上
        Random rand = new Random(); // 隨機數生成器
        public Coin()
        {
           sideUp = "正面"; // 預設為正面朝上
        }
        public void Toss()
        {           
            // 擲硬幣，隨機選擇正面或反面
            if (rand.Next(2) == 0)
            {
                sideUp = "正面"; // 正面朝上
            }
            else
            {
                sideUp = "反面"; // 反面朝上
            }
        }
        public string GetSideUp()
        {
            // 返回目前硬幣的朝向
            return sideUp;
        }
    }
}
