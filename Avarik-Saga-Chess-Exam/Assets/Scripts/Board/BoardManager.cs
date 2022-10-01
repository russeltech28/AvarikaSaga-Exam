using System;
using System.Collections.Generic;
using UnityEngine;

namespace AvarikSaga.Exam
{
    public class BoardManager : Singleton<BoardManager>
    {
        private Chess m_board;
        private List<GameObject> activeFigures = new List<GameObject>();
        private ChessFigure selectedFigure;
        private int m_selectionX = -1;
        private int m_selectionY = -1;

        #region DELEGATES
        public delegate void OnNewTurnDelegate();
        public OnNewTurnDelegate NewTurn;
        #endregion

        #region PROPERTIES
        public ChessFigure[,] ChessFigurePositions { get; set; } = new ChessFigure[8, 8];
        public ChessFigure SelectedChessFigurePosition
        {
            set { ChessFigurePositions[selectedFigure.CurrentX, selectedFigure.CurrentY] = value; }
        }
        public ChessFigure SelectedFigure 
        { 
            get { return selectedFigure; }
            set { selectedFigure = value; }
            
        }
        public int SelectionX { get => m_selectionX; set => m_selectionX = value; }
        public int SelectionY { get => m_selectionY; set => m_selectionY = value; }
        public Chess Board { get => m_board; set => m_board = value; }
        #endregion

        private void Awake()
        {
            m_board = GetComponent<Board>();
        }

        public void SelectChessFigure(int x, int y)
        {
            m_board.SetSelectedFigure(ChessFigurePositions[x, y], x, y);
        }

        public void MoveChessFigure(int x, int y)
        {
            Debug.Log($"Move Chess Figure! Allowed moves is {m_board.AllowedMoves[x, y]}");

            if (m_board.AllowedMoves[x, y])
            {
                m_board.Move(ChessFigurePositions[x, y], x, y);
            }

            BoardHighlighting.Instance.HideHighlights();
            selectedFigure = null;
        }

        public void SetChessFigurePosition(GameObject figure, int x, int y)
        {
            ChessFigurePositions[x, y] = figure.GetComponent<ChessFigure>();
            ChessFigurePositions[x, y].SetPosition(x, y);
        }

        public void AddActiveFigures(GameObject figure)
        {
            activeFigures.Add(figure);
        }

        public void RemoveActiveFigures(GameObject figure)
        {
            activeFigures.Remove(figure);
        }

        public List<GameObject> GetAllActiveFigures()
        {
            return activeFigures;
        }

        public void SetSelectedFigure(ChessFigure figure)
        {
            selectedFigure = figure;
        }

        public bool IsWhiteTurn()
        {
            return m_board.IsWhiteTurn;
        }

        public void Reset()
        {
            ChessFigurePositions = new ChessFigure[8, 8];
            activeFigures = new List<GameObject>();
            m_board.IsWhiteTurn = true;

            foreach (GameObject figure in activeFigures)
            {
                figure.SetActive(false);
            }

            BoardHighlighting.Instance.HideHighlights();
        }
    }
}