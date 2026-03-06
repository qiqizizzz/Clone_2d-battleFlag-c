/*
* ┌──────────────────────────────────┐
* │  描    述: 技能指令                      
* │  类    名: SkillCommand.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using System.Collections.Generic;
using Module.Fight.FightMgr;
using Module.Fight.Skill;

namespace Module.Fight.Command
{
    public class SkillCommand : BaseCommand
    {
        private ISkill skill;
        
        public SkillCommand(ModelBase model) : base(model)
        {
            skill = model as ISkill;
        }

        public override void Do()
        {
            base.Do();
            List<ModelBase> results = skill.GetTarget();
            if (results.Count > 0)
            {
                //有目标
                GameApp.SkillManager.AddSkill(skill, results);//添加到执行队列中
            }
        }

        public override bool Update(float dt)
        {
            if (!GameApp.SkillManager.IsRunningSkill())
            {
                model.IsStop = true;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}