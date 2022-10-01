using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AvarikSaga.Exam
{
    public class AIManager : MonoBehaviour
    {
        private ChessAI m_ai;
        private ChessFigure m_selectedFigure;

        private void Awake()
        {
            m_ai = GetComponent<ChessAI>();
        }

        private void Start()
        {
            StartCoroutine(TurnRoutine());
        }

        private IEnumerator TurnRoutine()
        {
            yield return new WaitUntil(() => !m_ai.boardManager.IsWhiteTurn());

            Vector2 aiMove;

            do
            {
                m_selectedFigure = m_ai.GetChessFigure();
                m_ai.boardManager.SetSelectedFigure(m_selectedFigure);
                aiMove = m_ai.GetMove(m_selectedFigure);

                Debug.Log($"x:{aiMove.x}, y:{aiMove.y} status: {aiMove.x < 0 && aiMove.y < 0}");
            }

            while (aiMove.x < 0 && aiMove.y < 0);

            m_ai.SetSelectedFigure(m_selectedFigure, m_selectedFigure.CurrentX, m_selectedFigure.CurrentY);

            yield return new WaitForSecondsRealtime(UnityEngine.Random.Range(1, 3));

            MoveChessFigure((int)Math.Round(aiMove.x), (int)Math.Round(aiMove.y));
        }

        private void MoveChessFigure(int x, int y)
        {
            if (m_ai.AllowedMoves[x, y])
            {
                m_ai.Move(m_ai.boardManager.ChessFigurePositions[x, y], x, y);
            }

            StartNewTurnRoutine();
        }

        private void StartNewTurnRoutine()
        {
            StartCoroutine(TurnRoutine());

            BoardHighlighting.Instance.HideHighlights();

            m_ai.boardManager.SelectedFigure = null;

            BoardManager.Instance.NewTurn.Invoke();
        }
    }
}
