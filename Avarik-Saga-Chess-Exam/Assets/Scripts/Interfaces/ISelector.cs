using UnityEngine;

namespace AvarikSaga.Exam
{
    public interface ISelector
    {
        void Check(Ray ray);
        int GetSelectionX();
        int GetSelectionY();
    }
}