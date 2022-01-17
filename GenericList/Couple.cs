using System;
using System.Collections.Generic;
using System.Text;

namespace StacksAndLists
{
    class Couple
    {
        private int num;
        private int appears;

        public Couple(int num, int appears)
        {
            this.num = num;
            this.appears = appears;

        }
        public int GetNum()
        {
            return this.num;
        }
        public int GetAppears()
        {
            return this.appears;
        }

        public void SetNum(int num)
        {
            this.num = num;
        }

        public void SetAppears(int appears)
        {
            this.appears = appears;
        }

    }
}
