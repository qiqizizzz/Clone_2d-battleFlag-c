/*
* ┌──────────────────────────────────┐
* │  描    述: 敌人移动指令                      
* │  类    名: AiMoveCommand.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using System.Collections.Generic;
using Common;
using Module.Fight.FightMgr;

namespace Module.Fight.Command
{
    public class AiMoveCommand : BaseCommand
    {
        private Enemy enemy;
        private _BFS bfs;
        private List<_BFS.Point> paths;
        private _BFS.Point current;
        private int pathIndex;
        private ModelBase target;//移动到的目标

        public AiMoveCommand(Enemy enemy) : base(enemy)
        {
            this.enemy = enemy;
            bfs = new _BFS(GameApp.MapManager.RowCount, GameApp.MapManager.ColCount);
            paths = new List<_BFS.Point>();
        }

        public override void Do()
        {
            base.Do();

            target = GameApp.FightManager.GetMinDisHero(enemy);//获取距离敌人最近的英雄

            if (target == null) isFinish = true;//没有目标了 直接结束
            else
            {
                paths = bfs.FindMinPath(this.enemy, this.enemy.Step, target.RowIndex, target.ColIndex);

                if (paths == null) isFinish = true;//没有路径了 这里可以随机一个点移动
                else
                {
                    //将当前敌人的位置设置为可移动
                    GameApp.MapManager.ChangeBlockType(this.enemy.RowIndex, this.enemy.ColIndex, BlockType.Null);
                }
            }
        }

        public override bool Update(float dt)
        {
            if (paths.Count == 0) return base.Update(dt);
            else
            {
                current = paths[pathIndex];
                if (model.Move(current.RowIndex, current.ColIndex, dt * 5))
                {
                    pathIndex++;
                    if (pathIndex > paths.Count - 1) //到达目标点
                    {
                        enemy.PlayAni("idle");
                        GameApp.MapManager.ChangeBlockType(enemy.RowIndex, enemy.ColIndex, BlockType.Obstacle);
                        return true;
                    }
                }
            }

            model.PlayAni("move");
            return false;
        }
    }
}