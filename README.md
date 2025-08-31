# Rebirth Of Purity

Allows players to cleanse **Corruption** by sleeping or upon death.

[English](./README.md), [中文](./README.CN.md)

## Features

- **Cleanse on Sleep**: Corruption is gradually removed while resting.  
- **Cleanse on Death**: All corruption is purged when the player dies.  
- **Configurable**: Fully adjustable through Outward Config Manager (default hotkey: **F5**).  

## Configuration

It is recommended to install [Outward Config Manager](https://thunderstore.io/c/outward/p/Mefino/Outward_Config_Manager/) to adjust settings.  
* Toggle purification on or off globally.  
* Configure the amount of corruption removed per unit of sleep time.  

## Development & Build

1. Create a symbolic link from the game’s `Managed` directory to this project directory.  
2. Install the .NET SDK.  
3. Run the following commands:  
   ```sh
   dotnet nuget add source https://nuget.bepinex.dev/v3/index.json -n BepInEx
   dotnet build -c Release
   ```

4. The build output will be located at:
   `bin\Release\net472\RebirthOfPurity.dll`

## License

[MIT LICENSE](./LICENSE)


