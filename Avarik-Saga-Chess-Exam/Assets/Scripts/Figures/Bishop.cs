namespace AvarikSaga.Exam
{
    public class Bishop : ChessFigure
    {
        public override bool[,] PossibleMove()
        {
            bool[,] possibleMoves = new bool[8, 8];

            possibleMoves = TopLeftMoves(possibleMoves, CurrentX, CurrentY);
            possibleMoves = TopRightMoves(possibleMoves, CurrentX, CurrentY);
            possibleMoves = BottomLeftMoves(possibleMoves, CurrentX, CurrentY);
            possibleMoves = BottomRightMoves(possibleMoves, CurrentX, CurrentY);

            return possibleMoves;
        }
        
        private bool[,] TopLeftMoves(bool[,] possibleMoves, int x, int y)
        {
            while (true)
            {
                x--;
                y++;

                if (x < 0 || y >= 8) break;

                ChessFigure figure = BoardManager.Instance.ChessFigurePositions[x, y];

                if (figure == null)
                {
                    possibleMoves[x, y] = true;
                }

                else
                {
                    if (figure.isWhite != isWhite)
                    {
                        possibleMoves[x, y] = true;
                    }

                    break;
                }
            }

            return possibleMoves;
        }

        private bool[,] TopRightMoves(bool[,] possibleMoves, int x, int y)
        {
            while (true)
            {
                x++;
                y++;

                if (x >= 8 || y >= 8) break;

                ChessFigure figure = BoardManager.Instance.ChessFigurePositions[x, y];

                if (figure == null)
                {
                    possibleMoves[x, y] = true;
                }
                    
                else
                {
                    if (figure.isWhite != isWhite)
                    {
                        possibleMoves[x, y] = true;
                    }

                    break;
                }
            }

            return possibleMoves;
        }

        private bool[,] BottomRightMoves(bool[,] possibleMoves, int x, int y)
        {
            while (true)
            {
                x++;
                y--;

                if (x >= 8 || y < 0) break;

                ChessFigure figure = BoardManager.Instance.ChessFigurePositions[x, y];

                if (figure == null)  
                { 
                    possibleMoves[x, y] = true; 
                }

                else
                {
                    if (figure.isWhite != isWhite)
                    {
                        possibleMoves[x, y] = true;
                    }

                    break;
                }
            }

            return possibleMoves;
        }

        private bool[,] BottomLeftMoves(bool[,] possibleMoves, int x, int y)
        {
            while (true)
            {
                x--;
                y--;

                if (x < 0 || y < 0) break;

                ChessFigure figure = BoardManager.Instance.ChessFigurePositions[x, y];

                if (figure == null) 
                {
                    possibleMoves[x, y] = true;
                }

                else
                {
                    if (figure.isWhite != isWhite)
                    {
                        possibleMoves[x, y] = true;
                    }

                    break;
                }
            }

            return possibleMoves;
        }
    }
}
