using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Square.Interfaces
{
    public interface IMagic_Square
    {
        void SetSuccessor(IMagic_Square nextDirection);
        bool ismagicsquare(int[][] square, int sum);
    }
}
