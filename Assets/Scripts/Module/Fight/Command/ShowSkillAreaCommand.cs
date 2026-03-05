/*
* ┌──────────────────────────────────┐
* │  描    述:                       
* │  类    名: ShowSkillAreaCommand.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using Module.Fight.FightMgr;
using Module.Fight.Skill;
using UnityEngine;

namespace Module.Fight.Command
{
    public class ShowSkillAreaCommand : BaseCommand
    {
        private ISkill skill;
        
        public ShowSkillAreaCommand(ModelBase model) : base(model)
        {
            skill = model as ISkill;
        }

        public override void Do()
        {
            base.Do();
            skill.ShowSkillArea();
        }

        public override bool Update(float dt)
        {
            if (Input.GetMouseButtonDown(0))
            {
                skill.HideSkillArea();
                Debug.Log("使用技能");

                return true;
            }

            return false;
        }
    }
}