using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AvarikSaga.Exam
{
    public class SharpShooter : MonoBehaviour, ISkill
    {
        public string skillName;
        public GameObject effectPrefab;
        public float maxCoolDown;
        public int maxTarget;

        private float coolDown;

        public void Execute(List<ChessFigure> aiChessFigures)
        {
            Debug.Log($"Execute skill: {skillName}");

            if (coolDown <= 0)
            {
                coolDown = maxCoolDown;
                List<ChessFigure> targetFigures = new List<ChessFigure>(aiChessFigures);

                for (int i = 0; i < maxTarget; i++)
                {
                    ChessFigure figure = targetFigures[Random.Range(0, targetFigures.Count)];

                    BoardManager.Instance.RemoveActiveFigures(figure.gameObject);
                    BoardManager.Instance.ChessFigurePositions[figure.CurrentX, figure.CurrentY] = null;

                    figure.SetActive(false);
                }

                BoardManager.Instance.Board.IsWhiteTurn = false;
            }
        }

        public void CoolDown()
        {
            if (coolDown <= 0) return;

            coolDown--;
        }

        public string GetSkillName()
        {
            return skillName;
        }
    }
}
