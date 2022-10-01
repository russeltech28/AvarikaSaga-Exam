using UnityEngine;

namespace AvarikSaga.Exam
{
    public class Input : MonoBehaviour, IInput
    {
        public bool OnMouseButtonDown(int button)
        {
            return UnityEngine.Input.GetMouseButtonDown(button);
        }
    }
}
