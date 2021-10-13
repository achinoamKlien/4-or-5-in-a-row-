using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FourInRow
{
    class FourInARowLogic
    {
        private int _h;
        private int _w;
        private int _sequance;
        private int winMatIndex;
        private Point[][] _winCordMat;
        private int[] locateArr;

        public FourInARowLogic(int w, int h, int sequance)
        {
            _h = h;
            _w = w;
            _sequance = sequance;
            _winCordMat = new Point[250][];
            winMatIndex = 0;
            LocateLines();
            Console.WriteLine("coulmns");
            LocateCoulomns();
            Console.WriteLine("diagonals");
            LocateDiagonals();
            Console.WriteLine("num of sit {0}", winMatIndex);

            locateArr = new int[]{8,8,8,8,8,8,8,8,8,8};

        }
        public void Print()
        {
            for (int i = 0; i < winMatIndex; i++)
            {
                for (int j = 0; j < _sequance; j++)
                {
                    Console.Write("{0},{1}:", _winCordMat[i][j].Y, _winCordMat[i][j].X);
                }
                Console.WriteLine();
                
            }
        }
        private void LocateLines()
        {
            int i;
            int j;
            for ( i = 0 ;  i < _h*(_w-_sequance+1); i++)
            {
                int offsetX = i % (_w - _sequance + 1);
                int offsetY = i / (_w - _sequance + 1);
                _winCordMat[winMatIndex] = new Point[_sequance];
                for (j = 0; j < _sequance; j++)
                {
                    _winCordMat[winMatIndex][j] = new Point(offsetX + j, offsetY);
                }
                winMatIndex++;
            }
            Print();
        }

        private void LocateCoulomns()
        {
            int i = 0;
            int j;
            for (i = 0; i < (_h- _sequance + 1) * _w ; i++)
            {
                int offsetX = i % _w;
                int offsetY = i / _w;
                _winCordMat[winMatIndex] = new Point[_sequance];
                for (j = 0; j < _sequance; j++)
                {
                    _winCordMat[winMatIndex][j] = new Point(offsetX, offsetY+j);
                }
                winMatIndex++;
            }
            Print();
        }

        private void LocateDiagonals()
        {
            int i = 0;
            int j;
            for (i = 0; i < (_h - _sequance + 1) * (_w - _sequance + 1); i++)
            {
                int offsetX = i % (_w - _sequance + 1);
                int offsetY = i / (_w - _sequance + 1);
                _winCordMat[winMatIndex] = new Point[_sequance];
                _winCordMat[winMatIndex+1] = new Point[_sequance];
                for (j = 0; j < _sequance; j++)
                {
                    _winCordMat[winMatIndex][j] = new Point(offsetX+j, offsetY + j);
                    _winCordMat[winMatIndex+1][j] = new Point(offsetX + _sequance-1-j, offsetY + j);
                }
                winMatIndex+=2;
            }
            Print();
        }

        public int LocateBall(int col)
        {
            int line = -1;
            if (col > -1 && col < 10)
            {
                if (locateArr[col] > -1)
                {
                    line = locateArr[col];
                    locateArr[col]--;
                }
            }
            return line;
        }


    }
}
