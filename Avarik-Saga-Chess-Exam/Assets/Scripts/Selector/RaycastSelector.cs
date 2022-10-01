using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AvarikSaga.Exam
{
    public class RaycastSelector : MonoBehaviour, ISelector
    {
        public string _layerMaskName;
        public float _raycastDistance;

        private int m_selectionX = -1;
        private int m_selectionY = -1;

        public void Check(Ray ray)
        {
            if (!Camera.main) return;

            if (Physics.Raycast(ray, out var hit, _raycastDistance, LayerMask.GetMask(_layerMaskName)))
            {
                m_selectionX = (int)hit.point.x;
                m_selectionY = (int)hit.point.z;
            }

            else
            {
                m_selectionX = -1;
                m_selectionY = -1;
            }
        }

        public int GetSelectionX()
        {
            return m_selectionX;
        }

        public int GetSelectionY()
        {
            return m_selectionY;
        }
    }
}
