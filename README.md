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

### 收获

MVC架构；

以及UI切记在代码中注册并添加点击等事件，在编辑器中拖动时低效且开销大；

A*寻路算法和BFS算法也很实用。

### 感想

整个项目是建立在MVC架构上进行的，方便了后续的很多操作，后面的项目里可以把这个架构搬过去！

即每一个模块有自己的控制器，在控制器里面继承控制器基类后，**注册**自己模块的**View**，以及**注册全局事件**等。

以及A*寻路算法和BFS算法后续希望也能用上。
