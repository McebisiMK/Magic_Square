using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Square.Interfaces
{
    public interface IMagic_Square
    {
        void SetSide(IMagic_Square nextDirection);
        bool IsMagicSquare(int[][] square, int sum);
    }
}
