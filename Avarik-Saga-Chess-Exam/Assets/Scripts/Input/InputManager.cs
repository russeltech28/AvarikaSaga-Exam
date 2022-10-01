using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AvarikSaga.Exam
{
    public class InputManager : MonoBehaviour
    {
        public BoardManager boardManager;

        private IInput m_input;

        private void Awake()
        {
            m_input = GetComponent<IInput>();
        }

        private void Update()
        {
            UpdateInput();
        }

        private void UpdateInput()
        {
            if (m_input.OnMouseButtonDown(0) && boardManager.IsWhiteTurn())
            {
                int selectionX = boardManager.SelectionX;
                int selectionY = boardManager.SelectionY;

                if (selectionX >= 0 && selectionX >= 0)
                {
                    if (boardManager.SelectedFigure == null)
                        boardManager.SelectChessFigure(selectionX, selectionY);

                    else
                        boardManager.MoveChessFigure(selectionX, selectionY);
                }
            }
        }
    }
}
