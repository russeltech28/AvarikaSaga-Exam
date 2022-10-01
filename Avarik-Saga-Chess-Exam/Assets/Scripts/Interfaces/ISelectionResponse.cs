using UnityEngine;

namespace AvarikSaga.Exam
{
    internal interface ISelectionResponse
    {
        void OnSelect(int x, int y);
        void OnDeselect();
    }
}
