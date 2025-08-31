
TARGET=bin/Release/net472/RebirthOfPurity.dll
PREFIX?=dist
DEPS = icon.png manifest.json README.md

$(TARGET): *.cs *.csproj
	dotnet build -c Release

nuget:
	dotnet nuget add source https://nuget.bepinex.dev/v3/index.json -n BepInEx

build: $(TARGET)

.PHONY: nuget build

install: $(TARGET) $(DEPS)
	mkdir -p $(PREFIX)
	cp $^ $(PREFIX)