/*
* ┌────────────────────────────────────────────┐
* │  描    述: 统一定义游戏中的管理器，在此类进行初始化
* │  类    名: GameApp.cs       
* │  创    建: By qiqizizzz
* └────────────────────────────────────────────┘
*/

using Common;
using Config;
using Module.Fight.FightMgr;
using MVC;
using Sound;
using Timer;

public class GameApp : Singleton<GameApp>
{
    public static SoundManager SoundManager;//音频管理器
    public static ControllerManager ControllerManager;//控制器管理器
    public static ViewManager ViewManager;//视图管理器
    public static ConfigManager ConfigManager;//配置表
    public static CameraManager CameraManager;//摄像机
    public static MessageCenter MsgCenter;//消息监听
    public static TimerManager TimerManager;//时间计时器
    public static FightWorldManager FightManager;//战斗管理器
    public static MapManager MapManager;//地图管理器
    public static GameDataManager GameDataManager;//游戏数据管理器
    public static UserInputManager UserInputManager;//用户输入管理器
    
    public override void Init()
    {
        SoundManager = new SoundManager();
        ControllerManager = new ControllerManager();
        ViewManager = new ViewManager();
        ConfigManager = new ConfigManager();
        CameraManager = new CameraManager();
        MsgCenter = new MessageCenter();
        TimerManager = new TimerManager();
        FightManager = new FightWorldManager();
        MapManager = new MapManager();
        GameDataManager = new GameDataManager();
        UserInputManager = new UserInputManager();
    }

    public override void Update(float dt)
    {
        UserInputManager.Update();
        TimerManager.OnUpdate(dt);
        FightManager.Update(dt);
    }
}