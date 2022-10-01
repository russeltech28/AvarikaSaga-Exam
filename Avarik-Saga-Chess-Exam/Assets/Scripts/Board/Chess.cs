using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AvarikSaga.Exam
{
    public abstract class Chess : MonoBehaviour
    {
        private bool[,] m_allowedMoves;
        private bool m_isWhiteTurn = true;

        #region CONST
        public const float TILE_SIZE = 1.0f;
        public const float TILE_OFFSET = 0.5f;
        #endregion

        #region PROPERTIES
        public bool[,] AllowedMoves { get => m_allowedMoves; set => m_allowedMoves = value; }
        public bool IsWhiteTurn { get => m_isWhiteTurn; set => m_isWhiteTurn = value; }
        #endregion

        public abstract void SetSelectedFigure(ChessFigure chessFigure, int x, int y);
        public abstract void Move(ChessFigure chessFigure, int x, int y);
        public abstract Vector3 GetTileCenter(int x, int y);
    }
}
