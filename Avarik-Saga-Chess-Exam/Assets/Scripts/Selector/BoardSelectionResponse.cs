using UnityEngine;

namespace AvarikSaga.Exam
{
    public class BoardSelectionResponse : MonoBehaviour, ISelectionResponse
    {
        public BoardManager boardManager;

        public void OnDeselect()
        {
            boardManager.SelectionX = -1;
            boardManager.SelectionY = -1;
        }

        public void OnSelect(int x, int y)
        {
            boardManager.SelectionX = x;
            boardManager.SelectionY = y;
        }
    }
}
