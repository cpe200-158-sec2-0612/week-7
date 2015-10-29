using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twozerofoureight
{
    class TwoZeroFourEightModel : Model
    {
        protected int boardSize; // default is 4
        protected int[,] board;
        protected Random rand;
        protected int score = 0;

        public TwoZeroFourEightModel() : this(4)
        {
            // default board size is 4 
           
        }

        public int getScore() //constructure ของ score
        {
            return score;
        }

        public int[,] GetBoard()
        {
            return board;
        }

        public TwoZeroFourEightModel(int size) 
        {
            boardSize = size;  //กำหนดขนาดบอร์ด
            board = new int[boardSize, boardSize]; 
            var range = Enumerable.Range(0, boardSize);
            foreach(int i in range) {
                foreach(int j in range) {
                    board[i,j] = 0;
                }
            }
            rand = new Random(); 
            board = Random(board);
            NotifyAll();
        }

        private int[,] Random(int[,] input) //สุ่มตำแหน่งให้เลขค่าใหม่ขึ้นมาโดยจะเชคว่าตำแหน่งนั้นเป็นศูนย์รึป่าว ถ้าเป็นก็จะสุ่มสองขึ้นมา
        {
            while (true)
            {
                int x = rand.Next(boardSize);
                int y = rand.Next(boardSize);
                if (board[x, y] == 0)
                {
                    board[x, y] = 2;
                    score += 2;
                    break;
                }
                if (CBoard())
                {
                    break;
                }
            }
            return input;
        }

        public void PerformDown()
        {
            
            int[] buffer;
            int pos;
            int[] rangeX = Enumerable.Range(0, boardSize).ToArray();
            int[] rangeY = Enumerable.Range(0, boardSize).ToArray();
            Array.Reverse(rangeY);
            foreach (int i in rangeX)
            {
                pos = 0;
                buffer = new int[4];
                foreach (int k in rangeX)
                {
                    buffer[k] = 0;
                }
                //shift left
                foreach (int j in rangeY)
                {
                    if (board[j, i] != 0)
                    {
                        buffer[pos] = board[j, i];
                        pos++;
                    }
                }
                // check duplicate
                foreach (int j in rangeX)
                {
                    if (j > 0 && buffer[j] != 0 && buffer[j] == buffer[j - 1])
                    {
                        buffer[j - 1] *= 2;
                        buffer[j] = 0;
                    }
                }
                // shift left again
                pos = 3;
                foreach (int j in rangeX)
                {
                    if (buffer[j] != 0)
                    {
                        board[pos, i] = buffer[j];
                        pos--;
                    }
                }
                // copy back
                for (int k = pos; k != -1; k--)
                {
                    board[k, i] = 0;
                }
            }
            board = Random(board);
            NotifyAll();
        }

        public void PerformUp()
        {
            
            int[] buffer;
            int pos;

            int[] range = Enumerable.Range(0, boardSize).ToArray();
            foreach (int i in range)
            {
                pos = 0;
                buffer = new int[4];
                foreach (int k in range)
                {
                    buffer[k] = 0;
                }
                //shift left
                foreach (int j in range)
                {
                    if (board[j, i] != 0)
                    {
                        buffer[pos] = board[j, i];
                        pos++;
                    }
                }
                // check duplicate
                foreach (int j in range)
                {
                    if (j > 0 && buffer[j] != 0 && buffer[j] == buffer[j - 1])
                    {
                        buffer[j - 1] *= 2;
                        buffer[j] = 0;
                    }
                }
                // shift left again
                pos = 0;
                foreach (int j in range)
                {
                    if (buffer[j] != 0)
                    {
                        board[pos, i] = buffer[j];
                        pos++;
                    }
                }
                // copy back
                for (int k = pos; k != boardSize; k++)
                {
                    board[k, i] = 0;
                }
            }
            board = Random(board);
            NotifyAll();
        }

        public void PerformRight()
        {
            
            int[] buffer;
            int pos;

            int[] rangeX = Enumerable.Range(0, boardSize).ToArray();
            int[] rangeY = Enumerable.Range(0, boardSize).ToArray();
            Array.Reverse(rangeX);
            foreach (int i in rangeY)
            {
                pos = 0;
                buffer = new int[4];
                foreach (int k in rangeY)
                {
                    buffer[k] = 0;
                }
                //shift left
                foreach (int j in rangeX)
                {
                    if (board[i, j] != 0)
                    {
                        buffer[pos] = board[i, j];
                        pos++;
                    }
                }
                // check duplicate
                foreach (int j in rangeY)
                {
                    if (j > 0 && buffer[j] != 0 && buffer[j] == buffer[j - 1])
                    {
                        buffer[j - 1] *= 2;
                        buffer[j] = 0;
                    }
                }
                // shift left again
                pos = 3;
                foreach (int j in rangeY)
                {
                    if (buffer[j] != 0)
                    {
                        board[i, pos] = buffer[j];
                        pos--;
                    }
                }
                // copy back
                for (int k = pos; k != -1; k--)
                {
                    board[i, k] = 0;
                }
            }
            board = Random(board);
            NotifyAll();
        }

        public void PerformLeft()
        {
            
            int[] buffer;
            int pos;
            int[] range = Enumerable.Range(0, boardSize).ToArray();
            foreach (int i in range)
            {
                pos = 0;
                buffer = new int[boardSize];
                foreach (int k in range)
                {
                    buffer[k] = 0;
                }
                //shift left
                foreach (int j in range)
                {
                    if (board[i, j] != 0)
                    {
                        buffer[pos] = board[i, j];
                        pos++;
                    }
                }
                // check duplicate
                foreach (int j in range)
                {
                    if (j > 0 && buffer[j] != 0 && buffer[j] == buffer[j - 1])
                    {
                        buffer[j - 1] *= 2;
                        buffer[j] = 0;
                    }
                }
                // shift left again
                pos = 0;
                foreach (int j in range)
                {
                    if (buffer[j] != 0)
                    {
                        board[i, pos] = buffer[j];
                        pos++;
                    }
                }
                for (int k = pos; k != boardSize; k++)
                {
                    board[i, k] = 0;
                }
            }
            board = Random(board);
            NotifyAll();
        }

        // check board ว่าเต็มรึป่าว
        public bool CBoard()
        {
            bool Full = true;
            for(int i = 0; i < boardSize; i++)
            {
                for(int j=0; j<boardSize; j++)
                {
                    if (board[i, j] == 0)
                    {
                        Full = false;
                        break;
                    }
                    else {
                        Full = true;
                    }
                }
                if (!Full)
                {
                    break;
                }
            }
            return Full;
        }

        //check ending
        public bool GameEnd()
        {
            bool Ending = false;
            if (CBoard() == true)
            {
                for(int j=0; j< boardSize; j++)
                {
                    for(int i=0; i< boardSize - 1; i++)
                    {
                        if (board[i,j] != board[i + 1, j])
                        {
                            Ending = true;
                        }
                        else if (board[i,j] == board[i + 1, j])
                        {
                            Ending = false;
                            break;
                        }
                    }
                    if (!Ending)
                    {
                        break;
                    }
                }
                for(int i=0; i< boardSize; i++)
                {
                    if (!Ending)
                    {
                        break;
                    }
                    for(int j = 0; j < boardSize - 1; j++)
                    {
                        if(board[i,j] != board[i, j + 1])
                        {
                            Ending = true;
                        }
                        else if(board[i,j]== board[i, j + 1])
                        {
                            Ending = false;
                            break;
                        }
                    }
                }
            }
            else
            {
                Ending = false;
            }

            return Ending;
        }

    }
}
