using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AvarikSaga.Exam
{
    public class SelectionManager : MonoBehaviour
    {
        private IRayProvider _rayProvider;
        private ISelector _selector;
        private ISelectionResponse _selectionResponse;
        
        private int m_selectionX = -1;
        private int m_selectionY = -1;

        #region PROPERTIES
        public int SelectionX { get => m_selectionX; set => m_selectionX = value; }
        public int SelectionY { get => m_selectionY; set => m_selectionY = value; }
        #endregion

        private void Awake()
        {
            _rayProvider = GetComponent<IRayProvider>();
            _selector = GetComponent<ISelector>();
            _selectionResponse = GetComponent<ISelectionResponse>();
        }

        private void Update()
        {
            UpdateSelection();
        }

        private void UpdateSelection()
        {
            if (!Camera.main) _selectionResponse.OnDeselect();

            _selector.Check(_rayProvider.CreateRay());

            m_selectionX = _selector.GetSelectionX();
            m_selectionY = _selector.GetSelectionY();

            _selectionResponse.OnSelect(m_selectionX, m_selectionY);
        }
    }
}
