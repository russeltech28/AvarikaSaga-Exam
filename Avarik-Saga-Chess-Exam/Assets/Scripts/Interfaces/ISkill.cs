using UnityEngine;
using System.Collections.Generic;

namespace AvarikSaga.Exam
{
    internal interface ISkill
    {
        void Execute(List<ChessFigure> aiChessFigures);
        void CoolDown();
        string GetSkillName();
    }
}
