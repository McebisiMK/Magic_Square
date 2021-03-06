﻿using Magic_Square.Interfaces;
using System.Linq;

namespace Magic_Square.Services
{
    public class Diagonals : IMagic_Square
    {
        private IMagic_Square _nextDirection;
        public void SetSide(IMagic_Square nextDirection)
        {
            _nextDirection = nextDirection;
        }

        public bool IsMagicSquare(int[][] square, int sum)
        {
            var diagonals = GetDiagonals(square);
            var DiagonalsState = IsValid(diagonals, sum);

            if (NotLastDirection(DiagonalsState))
            {
                _nextDirection.IsMagicSquare(square, sum);
            }
            return DiagonalsState;
        }

        private int[][] GetDiagonals(int[][] square)
        {
            var length = square.Length;
            var topLeftToBottomRight = Enumerable.Range(0, length)
                                            .Select(index => square[index][index]).ToArray();

            var bottomLeftToTopRight = Enumerable.Range(0, length)
                                            .Select(index => square[length - index - 1][index]).ToArray();

            var diagonals = new[] { topLeftToBottomRight, bottomLeftToTopRight };

            return diagonals;
        }

        private bool IsValid(int[][] diagonals, int sum)
        {
            return diagonals.All(line => line.Sum() == sum);
        }

        private bool HasNextDirection()
        {
            return _nextDirection != null;
        }

        private bool NotLastDirection(bool validDiagonals)
        {
            return validDiagonals && HasNextDirection();
        }
    }
}