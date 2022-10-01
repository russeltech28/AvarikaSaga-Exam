using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AvarikSaga.Exam
{
    public class SkillsManager : Singleton<SkillsManager>
    {
        private ISkill[] skills;
        private List<ChessFigure> aiChessFigures = new List<ChessFigure>();

        private void Awake()
        {
            skills = GetComponents<ISkill>();
        }

        private void Start()
        {
            GetAllAiFigures();
        }

        private void OnEnable()
        {
            BoardManager.Instance.NewTurn += OnNewTurnEvent;
        }

        private void OnDisable()
        {
            BoardManager.Instance.NewTurn -= OnNewTurnEvent;
        }

        public void OnExecute(string skillName)
        {
            foreach (ISkill skill in skills)
            {
                if (skill.GetSkillName().Equals(skillName))
                {
                    skill.Execute(aiChessFigures);
                }
            }
        }

        private void GetAllAiFigures()
        {
            foreach(ChessFigureSpawnModel spawnModel in LevelManager.Instance.chessFiguresSpawnList)
            {
                ChessFigure chessFigure = spawnModel.chessFigure.GetComponent<ChessFigure>();

                if(!chessFigure.isWhite)
                    aiChessFigures.Add(chessFigure);
            }
        }

        private void CheckCoolDown()
        {
            foreach (ISkill skill in skills)
            {
                skill.CoolDown();
            }
        }

        private void OnNewTurnEvent()
        {
            Debug.Log("New Turn Event Invoke!");
            CheckCoolDown();
        }
    }
}
