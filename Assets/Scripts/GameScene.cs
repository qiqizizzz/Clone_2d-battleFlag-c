/*
* ┌─────────────────────────────────────────────────────────────┐
* │  描    述: 继承mono的脚本，需要挂载游戏物体，跳转场景后当前脚本物体不删除
* │  类    名: GameScene.cs       
* │  创    建: By qiqizizzz
* └─────────────────────────────────────────────────────────────┘
*/

using System;
using Module.Game;
using Module.GameUI;
using Module.Loading;
using MVC;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    public Texture2D mouseTxt;
    private float dt;
    private static bool isLoaded = false; 
    
    private void Awake()
    {
        if (isLoaded) Destroy(gameObject);
        else
        {
            isLoaded = true;
            DontDestroyOnLoad(gameObject);
            GameApp.Instance.Init();
        }
    }

    private void Start()
    {
        Cursor.SetCursor(mouseTxt, Vector2.zero, CursorMode.Auto);//Auto->自动选择渲染模式
        GameApp.SoundManager.PlayBGM("login");
        
        RegisterModule();//注册游戏中的控制器
        InitModule();
    }

    private void Update()
    {
        dt = Time.deltaTime;
        GameApp.Instance.Update(dt);
    }
    
    //注册控制器
    private void RegisterModule()
    {
        GameApp.ControllerManager.Register(ControllerType.GameUI, new GameUIController());
        GameApp.ControllerManager.Register(ControllerType.Game, new GameController());
        GameApp.ControllerManager.Register(ControllerType.Loading, new LoadingController());
    }

    //执行所有控制器初始化
    private void InitModule()
    {
        GameApp.ControllerManager.InitAllModules();
    }
}