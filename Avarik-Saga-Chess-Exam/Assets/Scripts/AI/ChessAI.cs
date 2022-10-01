using System.Collections.Generic;
using UnityEngine;

namespace AvarikSaga.Exam
{
    public class ChessAI : Chess
    {
        public BoardManager boardManager;

        private System.Random randomizer;

        public Vector2 GetMove(ChessFigure figure)
        {
            randomizer = new System.Random();

            Vector2 movement;

            bool[,] possibleMoves = figure.PossibleMove();

            List<Vector2> possibleMovements = new List<Vector2>();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (possibleMoves[i, j])
                        possibleMovements.Add(new Vector2(i, j));
                }
            }

            if (possibleMovements.Count > 0)
                movement = possibleMovements[randomizer.Next(possibleMovements.Count)];
            else
                movement = new Vector2(-1, -1);

            return movement;
        }

        public ChessFigure GetChessFigure()
        {
            randomizer = new System.Random();

            List<GameObject> activeFigures = new List<GameObject>(BoardManager.Instance.GetAllActiveFigures());

            ChessFigure figure;

            while (true)
            {
                figure = activeFigures[randomizer.Next(activeFigures.Count)].GetComponent<ChessFigure>();

                if (!figure.isWhite) break;

                activeFigures.Remove(figure.gameObject);
            }

            Debug.Log($"AI selected is not white : {figure.isWhite} {figure.name}");

            return figure;
        }

        public override void SetSelectedFigure(ChessFigure chessFigure, int x, int y)
        {
            if (chessFigure == null) return;

            AllowedMoves = chessFigure.PossibleMove();
        }

        public override void Move(ChessFigure chessFigure, int x, int y)
        {
            if (chessFigure != null && chessFigure.isWhite != boardManager.IsWhiteTurn())
            {
                Debug.Log("Attack!");

                boardManager.RemoveActiveFigures(chessFigure.gameObject);

                chessFigure.SetActive(false);

                if (chessFigure.GetType() == typeof(King))
                {
                    GameManager.Instance.EndGame();
                    return;
                }
            }

            boardManager.SelectedChessFigurePosition = null;

            boardManager.SelectedFigure.transform.position = GetTileCenter(x, y);

            boardManager.SelectedFigure.SetPosition(x, y);

            boardManager.ChessFigurePositions[x, y] = boardManager.SelectedFigure;

            boardManager.Board.IsWhiteTurn = true;
        }

        public override Vector3 GetTileCenter(int x, int y)
        {
            Vector3 origin = Vector3.zero;

            origin.x += (TILE_SIZE * x) + TILE_OFFSET;
            origin.z += (TILE_SIZE * y) + TILE_OFFSET;

            return origin;
        }
    }
}
