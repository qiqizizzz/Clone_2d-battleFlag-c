/*
* ┌──────────────────────────────────┐
* │  描    述: 技能接口类                      
* │  类    名: ISkill.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

namespace Module.Fight.Skill
{
    public interface ISkill
    {
        SkillProperty skillPro { get; set; }

        void ShowSkillArea();
        
        void HideSkillArea();
    }
}