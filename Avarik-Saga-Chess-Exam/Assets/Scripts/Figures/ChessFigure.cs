using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AvarikSaga.Exam
{
    public abstract class ChessFigure : MonoBehaviour
    {
        public bool isWhite;

        #region PROPERTIES
        public int CurrentX { get; set; }
        public int CurrentY { get; set; }
        #endregion

        public void SetPosition(int x, int y)
        {
            CurrentX = x;
            CurrentY = y;
        }

        public void SetActive(bool state)
        {
            gameObject.SetActive(state);
        }

        public virtual bool[,] PossibleMove()
        {
            return new bool[8, 8];
        }
    }
}