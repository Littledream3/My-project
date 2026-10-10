# Unity 2D RPG

一个使用 **Unity 6 + C#** 开发的 2D 像素风 RPG 项目，正在持续迭代中。

## 已实现功能

- 角色八方向移动与朝向切换
- 近战攻击、弓箭射击与武器切换
- 伤害、击退、硬直及生命值系统
- 敌人 Idle / Chasing / Attacking / Knockback 状态机
- 经验、升级、属性成长与技能树
- ScriptableObject 驱动的技能和物品数据
- 战利品掉落与拾取
- Tilemap 地图及高低层切换
- Animator、Animation Event 与 Cinemachine 集成

## 技术栈

- Unity `6000.6.4f1`
- C# / Rigidbody2D / Physics2D
- Tilemap / Animator / Cinemachine
- TextMesh Pro / Unity UI
- ScriptableObject / Unity Test Framework

## 运行方式

1. 安装 Unity Hub。
2. 安装 Unity `6000.6.4f1` 或兼容版本。
3. 克隆仓库：

   ```bash
   git clone https://github.com/Littledream3/My-project.git
   ```

4. 在 Unity Hub 中选择 **Add project from disk**，打开仓库根目录。
5. 打开 `Assets/Scenes/SampleScene.unity` 并运行。

## 项目结构

```text
Assets/
├─ Scenes/                 # 游戏场景
├─ Scripts/
│  ├─ PlayerScripts/       # 移动、战斗、属性、经验等
│  ├─ SkillTree/           # 技能树系统
│  ├─ Inventory&Shop/      # 物品与掉落
│  └─ Tilemap Scripts/     # 地图层级切换
├─ Prefabs/                # 游戏预制体
└─ Sprites/                # 精灵、动画与 Tile 资源
```

## 后续计划

- 完善背包与商店系统
- 增加更多敌人、技能和关卡
- 补充 EditMode / PlayMode 自动化测试
- 接入 GitHub Actions 持续集成
- 优化战斗反馈与性能

## 说明

本项目用于 Unity 游戏开发学习与作品展示。仓库中的第三方字体、示例资源及美术素材，其权利归各自作者所有；使用或再分发前请确认对应授权。

欢迎提交 Issue、建议和改进。如果这个项目对你有帮助，欢迎点一个 Star。
