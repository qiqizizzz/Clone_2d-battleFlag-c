/*
* ┌───────────────────────────────────────┐
* │  描    述: 继承mono的脚本，需要挂载游戏物体
* │  类    名: GameScene.cs       
* │  创    建: By qiqizizzz
* └───────────────────────────────────────┘
*/

using System;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    public Texture2D mouseTxt;
    private float dt;
    
    private void Awake()
    {
        GameApp.Instance.Init();
    }

    private void Start()
    {
        Cursor.SetCursor(mouseTxt, Vector2.zero, CursorMode.Auto);//Auto->自动选择渲染模式
        GameApp.SoundManager.PlayBGM("login");
    }

    private void Update()
    {
        dt = Time.deltaTime;
        GameApp.Instance.Update(dt);
    }
}