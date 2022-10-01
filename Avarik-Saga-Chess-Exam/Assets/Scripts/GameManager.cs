using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AvarikSaga.Exam
{
    public class GameManager : Singleton<GameManager>
    {
        public BoardManager boardManager;
        public LevelManager levelManager;

        #region DELEGATES
        public delegate void OnGameOverEvent(bool isWhite);
        public OnGameOverEvent GameOverEvent;
        #endregion

        public void EndGame()
        {
            Debug.Log("White turn: " + boardManager.IsWhiteTurn());

            boardManager.Reset();
            GameOverEvent.Invoke(boardManager.IsWhiteTurn());
        }
    }
}
