using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AvarikSaga.Exam
{
    public class Board : Chess
    {
        private BoardManager m_boardManager;

        private void Awake()
        {
            m_boardManager = GetComponent<BoardManager>();
        }

        public override void SetSelectedFigure(ChessFigure chessFigure, int x, int y)
        {
            if (chessFigure == null) return;
            if (chessFigure.isWhite != IsWhiteTurn) return;

            bool hasAtLeastOneMove = false;
            AllowedMoves = chessFigure.PossibleMove();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (AllowedMoves[i, j])
                    {
                        hasAtLeastOneMove = true;
                        i = 7;

                        break;
                    }
                }
            }

            if (!hasAtLeastOneMove) return;

            m_boardManager.SetSelectedFigure(chessFigure);
            BoardHighlighting.Instance.HighlightAllowedMoves(AllowedMoves);
        }

        public override void Move(ChessFigure chessFigure, int x, int y)
        {
            if (chessFigure != null && chessFigure.isWhite != IsWhiteTurn)
            {
                m_boardManager.RemoveActiveFigures(chessFigure.gameObject);

                chessFigure.SetActive(false);

                if (chessFigure.GetType() == typeof(King))
                {
                    GameManager.Instance.EndGame();
                    return;
                }
            }

            m_boardManager.SelectedChessFigurePosition = null;

            m_boardManager.SelectedFigure.transform.position = GetTileCenter(x, y);

            m_boardManager.SelectedFigure.SetPosition(x, y);

            m_boardManager.ChessFigurePositions[x, y] = m_boardManager.SelectedFigure;

            IsWhiteTurn = false;
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
