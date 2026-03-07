/*
* ┌──────────────────────────────────┐
* │  描    述: 广度优先搜索算法                      
* │  类    名: _BFS.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using System.Collections.Generic;
using System.Linq;
using Module.Fight.FightMgr;
using UnityEngine;

namespace Common
{
    public class _BFS
    {
        //搜索点
        public class Point
        {
            public int RowIndex;//行下标
            public int ColIndex;//列下标
            public Point Father;//父节点 用来查找路径用

            public Point(int row, int col)
            {
                this.RowIndex = row;
                this.ColIndex = col;
            }

            public Point(int row, int col, Point father)
            {
                this.RowIndex = row;
                this.ColIndex = col;
                this.Father = father;
            }
        }

        public int RowCount;//行数
        public int ColCount;//列数

        public Dictionary<string, Point> finds;//存储查找到的点的字典(key: 点的行列拼接的字符串 如2_6 value: 搜索点)

        public _BFS(int row, int col)
        {
            finds = new Dictionary<string, Point>();
            this.RowCount = row;
            this.ColCount = col;
        }
        
        /// <summary>
        /// 搜索行走区域
        /// </summary>
        /// <param name="row">开始点的行坐标</param>
        /// <param name="col">开始点的列坐标</param>
        /// <param name="step">步数</param>
        /// <returns></returns>
        public List<Point> Search(int row, int col, int step)
        {
            //定义搜索集合
            List<Point> searchs = new List<Point>();
            //开始点
            Point startPoint = new Point(row, col);
            //将开始点存储到搜索集合
            searchs.Add(startPoint);
            //开始点默认开始已经找到 存储到已经找到的字典
            finds.Add($"{row}_{col}", startPoint);
            
            //遍历步数
            for (int i = 0; i < step; i++)
            {
                //定义一个临时的集合 用于存储目前找到满足条件的点
                List<Point> temps = new List<Point>();
                //遍历搜索集合
                for (int j = 0; j < searchs.Count; j++)
                {
                    Point current = searchs[j];
                    //查找当前点四周围的点
                    FindAroundPoints(current, temps);
                }

                if (temps.Count == 0)
                {
                    //临时集合一个点都找不到 相当于死路了,没必要继续搜索了
                    break;
                }
                
                //清空搜索集合
                searchs.Clear();
                //将临时集合赋值给搜索集合
                searchs.AddRange(temps);
            }
            
            //返回已经找到的点的集合
            return finds.Values.ToList();
        }

        //查找当前点四周围的点 上下左右(可以扩展查找斜方向的点)
        public void FindAroundPoints(Point current, List<Point> temps)
        {
            //因为索引是从0开始的 所以行列的范围是0~RowCount-1 0~ColCount-1
            //即分别判断current点上下左右点是否在地图内
            
            //上
            if (current.RowIndex - 1 >= 0)
            {
                AddFinds(current.RowIndex - 1, current.ColIndex, current, temps);
            }
            //下
            if (current.RowIndex + 1 < RowCount)
            {
                AddFinds(current.RowIndex + 1, current.ColIndex, current, temps);
            }
            //左
            if (current.ColIndex - 1 >= 0)
            {
                AddFinds(current.RowIndex, current.ColIndex - 1, current, temps);
            }
            //右
            if (current.ColIndex + 1 < ColCount)
            {
                AddFinds(current.RowIndex, current.ColIndex + 1, current, temps);
            }
        }

        //添加到查找到的字典
        public void AddFinds(int row, int col, Point father, List<Point> temp)
        {
            //不在字典中 且 对应地图格子的类型不是障碍物,才能加入到查找的字典中
            if (finds.ContainsKey($"{row}_{col}") == false &&
                GameApp.MapManager.GetBlockType(row, col) != BlockType.Obstacle)
            {
                Point p = new Point(row, col, father);
                //添加到查找到的字典中
                finds.Add($"{row}_{col}", p);
                //添加到临时集合中 用于下次继续查找
                temp.Add(p);
            }
        }

        //寻找可移动的点 离终点最近的点的路径集合
        public List<Point> FindMinPath(ModelBase model, int step, int endRowIndex, int endColIndex)
        {
            List<Point> results = Search(model.RowIndex, model.ColIndex, step);//获得能移动的点的集合
            if (results.Count == 0) return null;
            else
            {
                Point minPoint = results[0];//默认第一个点离终点最近
                int minDis = Mathf.Abs(minPoint.RowIndex - endRowIndex) + Mathf.Abs(minPoint.ColIndex - endColIndex);
                for (int i = 0; i < results.Count; i++)
                {
                    int temp_dis = Mathf.Abs(results[i].ColIndex - endColIndex) + Mathf.Abs(results[i].RowIndex - endRowIndex);
                    if (temp_dis < minDis)
                    {
                        minDis = temp_dis;
                        minPoint = results[i];
                    }
                }

                //从离终点最近的点开始往回找父节点 直到找到开始点为止 就是路径了
                List<Point> paths = new List<Point>();
                Point current = minPoint.Father;
                paths.Add(minPoint);
                while (current != null)
                {
                    paths.Add(current);
                    current = current.Father;
                }

                paths.Reverse();//反置
                return paths;
            }
        }
    }
}