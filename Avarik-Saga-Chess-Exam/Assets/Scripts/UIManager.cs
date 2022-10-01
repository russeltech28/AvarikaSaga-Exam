using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AvarikSaga.Exam
{
    public class UIManager : MonoBehaviour
    {
        public GameObject gameOverPanel;
        public Text winnerStatusTxt;

        private void OnEnable()
        {
            GameManager.Instance.GameOverEvent += OnGameOverEvent;
        }

        private void OnDisable()
        {
            GameManager.Instance.GameOverEvent -= OnGameOverEvent;
        }

        public void OnGameOverEvent(bool isWhite)
        {
            gameOverPanel.SetActive(true);

            string status = isWhite ? "You Won!" : "You Lose!";

            winnerStatusTxt.text = status;
        }

        public void OnRetry()
        {
            LevelManager.Instance.SpawnAllChessFigures();
        }
    }
}
