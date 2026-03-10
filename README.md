# Clone_2d-battleFlag-c
2d战旗项目-Unity2022

### 目录

- [Common公共类](https://github.com/qiqizizzz/Clone_2d-battleFlag-c/tree/main/Assets/Scripts/Common)
- [Config配置类](https://github.com/qiqizizzz/Clone_2d-battleFlag-c/tree/main/Assets/Scripts/Config)
- [MVC](https://github.com/qiqizizzz/Clone_2d-battleFlag-c/tree/main/Assets/Scripts/MVC)
  - [Model模型类](https://github.com/qiqizizzz/Clone_2d-battleFlag-c/tree/main/Assets/Scripts/MVC/Model) - ”数据仓库“：属性、列表、配置、数值。
  - [View视图类](https://github.com/qiqizizzz/Clone_2d-battleFlag-c/tree/main/Assets/Scripts/MVC/View) - 处理UI界面
  - [Controller控制器类](https://github.com/qiqizizzz/Clone_2d-battleFlag-c/tree/main/Assets/Scripts/MVC/Controller) - 负责逻辑与联络

- [Module模块](https://github.com/qiqizizzz/Clone_2d-battleFlag-c/tree/main/Assets/Scripts/Module)
  - [Fight战斗模块](https://github.com/qiqizizzz/Clone_2d-battleFlag-c/tree/main/Assets/Scripts/Module/Fight)
  - [Game游戏控制模块](https://github.com/qiqizizzz/Clone_2d-battleFlag-c/tree/main/Assets/Scripts/Module/Game)
  - [GameUI模块](https://github.com/qiqizizzz/Clone_2d-battleFlag-c/tree/main/Assets/Scripts/Module/GameUI)
  - [Level场景切换模块](https://github.com/qiqizizzz/Clone_2d-battleFlag-c/tree/main/Assets/Scripts/Module/Level)
  - [Loading加载模块](https://github.com/qiqizizzz/Clone_2d-battleFlag-c/tree/main/Assets/Scripts/Module/Loading)

- [Sound声音类](https://github.com/qiqizizzz/Clone_2d-battleFlag-c/tree/main/Assets/Scripts/Sound)

- [Timer时间类](https://github.com/qiqizizzz/Clone_2d-battleFlag-c/tree/main/Assets/Scripts/Timer)

- 其他
  - [GameApp 统一定义管理器的类](https://github.com/qiqizizzz/Clone_2d-battleFlag-c/blob/main/Assets/Scripts/GameApp.cs)
  - [A*算法](https://github.com/qiqizizzz/Clone_2d-battleFlag-c/blob/main/Assets/Scripts/Common/AStar.cs)
  - [BFS算法](https://github.com/qiqizizzz/Clone_2d-battleFlag-c/blob/main/Assets/Scripts/Common/_BFS.cs)
  - [单例](https://github.com/qiqizizzz/Clone_2d-battleFlag-c/blob/main/Assets/Scripts/Common/Singleton.cs)

### 使用方法

### 1. 新建一个 Module
*   **Module**: 继承 `BaseModule`，作为模块的入口和生命周期管理。
*   **View**: 继承 `BaseView`，负责 UI 绑定、点击事件监听及界面刷新逻辑。
*   **Controller**: 继承 `BaseController`，负责业务逻辑处理，它是 View 与 Model 之间的桥梁。

### 2. 前置条件与初始化
*   **GameApp**: 全局单例类（不继承 MonoBehaviour），持有所有的 Manager（如 `ControllerManager`, `ViewManager`）。
*   **GameScene**: 场景中的驱动类（继承 MonoBehaviour），在 `Update` 中调用 `GameApp` 的 `Init` 与 `Update`（解决单例类无法直接使用 Unity 生命周期的局限）。
*   **注册控制器**: 在 `InitModuleEvent()` 中执行：
    ```csharp
    GameApp.ControllerManager.Register(ControllerType.Loading, new LoadingController());
    ```

### 3. 实现与注册
*   **数据存储**: 在对应的 Model 中管理模块所需的数据状态。
*   **UI 逻辑**: 在 View 中通过 `Find<T>` 缓存组件，仅编写与 UI 展示相关的逻辑。
*   **View 注册**: 在 Controller 的构造函数中进行：
    ```csharp
    GameApp.ViewManager.Register(ViewType.GameView, new ViewInfo(){ ... });
    ```

### 4. 事件机制
*   **注册事件**: 在 Controller 的 `InitModuleEvent()` 中注册。
    
    ```csharp
    // Register(事件名, 回调函数)
    Register(Defines.LoadingScene, OnLoadingComplete); 
    ```
*   **触发事件**:
    *   **本控制器内**: View 调用 `ApplyFunc(事件名, 参数)`。
    *   **跨控制器**: View 调用 `ApplyControllerFunc(控制器类型, 事件名, 参数)`。

---



### 收获

MVC架构；

以及UI切记在代码中注册并添加点击等事件，在编辑器中拖动时低效且开销大；

A*寻路算法和BFS算法也很实用。

### 感想

整个项目是建立在MVC架构上进行的，方便了后续的很多操作，后面的项目里可以把这个架构搬过去！

即每一个模块有自己的控制器，在控制器里面继承控制器基类后，**注册**自己模块的**View**，以及**注册全局事件**等。

以及A*寻路算法和BFS算法后续希望也能用上。
