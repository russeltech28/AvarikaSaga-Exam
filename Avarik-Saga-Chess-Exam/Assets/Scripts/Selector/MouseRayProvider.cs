using UnityEngine;

namespace AvarikSaga.Exam
{
    public class MouseRayProvider : MonoBehaviour, IRayProvider
    {
        public Ray CreateRay()
        {
            return Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
        }
    }
}
