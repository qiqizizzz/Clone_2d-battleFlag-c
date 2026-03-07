/*
* ┌──────────────────────────────────┐
* │  描    述: 敌人编辑器                      
* │  类    名: EnemyEditor.cs       
* │  创    建: By qiqizizzz
* └──────────────────────────────────┘
*/

using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
using System.Collections.Generic;
using Module.Fight.FightMgr;

namespace Editor
{
    [CanEditMultipleObjects, CustomEditor(typeof(Enemy))]
    public class EnemyEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("设置位置"))
            {
                Tilemap tilemap = GameObject.Find("Grid/ground").GetComponent<Tilemap>();

                var allPos = tilemap.cellBounds.allPositionsWithin;

                int min_x = 0;
                int min_y = 0;

                if (allPos.MoveNext())
                {
                    Vector3Int current = allPos.Current;
                    min_x = current.x;
                    min_y = current.y;
                }

                Enemy enemy = target as Enemy;

                // 1. 注册撤销操作，并告诉 Unity 对象将要改变
                Undo.RecordObject(enemy, "Set Enemy Grid Pos");
                Undo.RecordObject(enemy.transform, "Set Enemy World Pos");
                
                Vector3Int cellPos = tilemap.WorldToCell(enemy.transform.position);
                enemy.RowIndex = Mathf.Abs(min_y - cellPos.y);
                enemy.ColIndex = Mathf.Abs(min_x - cellPos.x);

                enemy.transform.position = tilemap.CellToWorld(cellPos) + new Vector3(0.5f, 0.5f, -1);
                
                // 2. 强制标记为已修改
                EditorUtility.SetDirty(enemy);
            }
        }
    }
}