using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hanoi
{
    class Sets
    {
        public int[] Current;
        public int H;        
        public Sets(int[] current, int h)
        {
            Current = current;
            H = h;            
        }
    }
}
