using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AvarikSaga.Exam
{
    public class LevelManager : Singleton<LevelManager>
    {
        public List<ChessFigureSpawnModel> chessFiguresSpawnList;
        public float offsetMultiplier;
        public BoardManager boardManager;
        public SelectionManager selectionManager;

        private void Start()
        {
            SpawnAllChessFigures();
        }

        private void Update()
        {
            DrawChessBoard();
            DrawSelection();
        }

        public void SpawnAllChessFigures()
        {
            Debug.Log("SPAWN!");

            for (int i = 0; i < chessFiguresSpawnList.Count; i++)
            {
                GameObject figure = chessFiguresSpawnList[i].chessFigure;
                int x = chessFiguresSpawnList[i].x;
                int y = chessFiguresSpawnList[i].y;

                SpawnChessFigure(figure, x, y);
            }
        }

        private void SpawnChessFigure(GameObject figure, int x, int y)
        {
            figure.transform.position = boardManager.Board.GetTileCenter(x, y);
            figure.transform.SetParent(transform);

            boardManager.AddActiveFigures(figure);
            boardManager.SetChessFigurePosition(figure, x, y);

            figure.SetActive(true);
        }

        private void DrawChessBoard()
        {
            Vector3 widthLine = Vector3.right * offsetMultiplier * 8;
            Vector3 heightLine = Vector3.forward * offsetMultiplier * 8;

            // Draw Chessboard
            for (int i = 0; i <= 8; i++)
            {
                Vector3 start = Vector3.forward * offsetMultiplier * i;

                Debug.DrawLine(start, start + widthLine);

                for (int j = 0; j <= 8; j++)
                {
                    start = Vector3.right * offsetMultiplier * j;
                    Debug.DrawLine(start, start + heightLine);
                }
            }
        }

        private void DrawSelection()
        {
            // Draw Selection
            if (selectionManager.SelectionX >= 0 && selectionManager.SelectionY >= 0)
            {
                Vector3 start1 = Vector3.forward * selectionManager.SelectionY + Vector3.right * selectionManager.SelectionX;
                Vector3 end1 = Vector3.forward * (selectionManager.SelectionY + 1) + Vector3.right * (selectionManager.SelectionX + 1);

                Vector3 start2 = Vector3.forward * selectionManager.SelectionY + Vector3.right * (selectionManager.SelectionX + 1);
                Vector3 end2 = Vector3.forward * (selectionManager.SelectionY + 1) + Vector3.right * selectionManager.SelectionX;

                Debug.DrawLine(start1, end1);
                Debug.DrawLine(start2, end2);
            }
        }
    }
}
