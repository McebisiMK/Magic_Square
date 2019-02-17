﻿using Magic_Square.Interfaces;
using System.Linq;

namespace Magic_Square.Services
{
    public class Verticals : IMagic_Square
    {
        private IMagic_Square _nextDirection;
        public void SetSuccessor(IMagic_Square nextDirection)
        {
            _nextDirection = nextDirection;
        }

        public bool IsMagicSquare(int[][] square, int sum)
        {
            var verticals = GetVerticals(square);
            var validVerticals = IsValid(verticals, sum);

            if (validVerticals && HasNextDirectiom())
            {
                _nextDirection.IsMagicSquare(square, sum);
            }
            return validVerticals;
        }

        private int[][] GetVerticals(int[][] square)
        {
            var verticals = Enumerable.Range(0, square.Length)
                                .Select(outerIndex => Enumerable.Range(0, square.Length)
                                                        .Select(innerIndex => square[innerIndex][outerIndex])
                                                        .ToArray()
                                 ).ToArray();

            return verticals;
        }

        private bool IsValid(int[][] verticals, int sum)
        {
            return verticals.All(line => line.Sum() == sum);
        }

        private bool HasNextDirectiom()
        {
            return _nextDirection != null;
        }

    }
}