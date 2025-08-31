

# Rebirth Of Purity

允许玩家通过睡觉或死亡以消除腐化状态。

[English](./README.md), [中文](./README.CN.md)

## 功能特性

- **睡眠净化**：玩家在休息时会逐渐清除腐化。  
- **死亡净化**：玩家死亡后会立即清除全部腐化。  
- **全局配置**：可通过 Outward Config Manager 完全自定义（默认热键：**F5**）。  

## 配置

建议安装[Outward Config Manager](https://thunderstore.io/c/outward/p/Mefino/Outward_Config_Manager/)以调整配置，热键默认为 **F5**。
* 可以全局切换净化开关
* 可以设置睡觉时单位时间消除的腐化点数。


## 开发&构建

1. 符号链接游戏的Managed目录到本目录
2. 安装dotnet sdk
3. 执行以下命令
```sh
dotnet nuget add source https://nuget.bepinex.dev/v3/index.json -n BepInEx
dotnet build -c Release
```

输出位于 `bin\Release\net472\RebirthOfPurity.dll`


## 许可证

[MIT LICENSE](./LICENSE)