namespace AvarikSaga.Exam
{
    public class King : ChessFigure
    {
        public override bool[,] PossibleMove()
        {
            bool[,] possibleMoves = new bool[8, 8];

            possibleMoves = Top(possibleMoves, CurrentX - 1, CurrentY + 1);
            possibleMoves = Bottom(possibleMoves, CurrentX - 1, CurrentY - 1);
            possibleMoves = Left(possibleMoves);
            possibleMoves = Right(possibleMoves);

            /*
            ChessFigure figure;
            int x;
            int y;

            // Top
            x = CurrentX - 1;
            y = CurrentY + 1;

            if (CurrentY < 7)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (x >= 0 && x < 8)
                    {
                        figure = BoardManager.Instance.ChessFigurePositions[x, y];
                        if (figure == null) possibleMoves[x, y] = true;
                        else if (figure.isWhite != isWhite) possibleMoves[x, y] = true;
                    }
                    x++;
                }
            }

            // Bottom
            x = CurrentX - 1;
            y = CurrentY - 1;
            if (CurrentY > 0)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (x >= 0 && x < 8)
                    {
                        figure = BoardManager.Instance.ChessFigurePositions[x, y];
                        if (figure == null) possibleMoves[x, y] = true;
                        else if (figure.isWhite != isWhite) possibleMoves[x, y] = true;
                    }
                    x++;
                }
            }

            // Left
            if (CurrentX > 0)
            {
                figure = BoardManager.Instance.ChessFigurePositions[CurrentX - 1, CurrentY];
                if (figure == null) possibleMoves[CurrentX - 1, CurrentY] = true;
                else if (figure.isWhite != isWhite) possibleMoves[CurrentX - 1, CurrentY] = true;
            }

            // Right
            if (CurrentX < 7)
            {
                figure = BoardManager.Instance.ChessFigurePositions[CurrentX + 1, CurrentY];
                if (figure == null) possibleMoves[CurrentX + 1, CurrentY] = true;
                else if (figure.isWhite != isWhite) possibleMoves[CurrentX + 1, CurrentY] = true;
            }
            */

            return possibleMoves;
        }

        private bool[,] Top(bool[,] possibleMoves, int x, int y)
        {
            if (CurrentY < 7)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (x >= 0 && x < 8)
                    {
                        ChessFigure figure = BoardManager.Instance.ChessFigurePositions[x, y];

                        if (figure == null) 
                            possibleMoves[x, y] = true;

                        else if (figure.isWhite != isWhite) 
                            possibleMoves[x, y] = true;
                    }

                    x++;
                }
            }

            return possibleMoves;
        }

        private bool[,] Bottom(bool[,] possibleMoves, int x, int y)
        {
            if (CurrentY > 0)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (x >= 0 && x < 8)
                    {
                        ChessFigure figure = BoardManager.Instance.ChessFigurePositions[x, y];

                        if (figure == null) 
                            possibleMoves[x, y] = true;

                        else if (figure.isWhite != isWhite) 
                            possibleMoves[x, y] = true;
                    }

                    x++;
                }
            }

            return possibleMoves;
        }

        private bool[,] Left(bool[,] possibleMoves)
        {
            if (CurrentX > 0)
            {
                ChessFigure figure = BoardManager.Instance.ChessFigurePositions[CurrentX - 1, CurrentY];

                if (figure == null) 
                    possibleMoves[CurrentX - 1, CurrentY] = true;

                else if (figure.isWhite != isWhite) 
                    possibleMoves[CurrentX - 1, CurrentY] = true;
            }

            return possibleMoves;
        }

        private bool[,] Right(bool[,] possibleMoves)
        {
            if (CurrentX < 7)
            {
                ChessFigure figure = BoardManager.Instance.ChessFigurePositions[CurrentX + 1, CurrentY];

                if (figure == null) 
                    possibleMoves[CurrentX + 1, CurrentY] = true;

                else if (figure.isWhite != isWhite) 
                    possibleMoves[CurrentX + 1, CurrentY] = true;
            }

            return possibleMoves;
        }
    }
}