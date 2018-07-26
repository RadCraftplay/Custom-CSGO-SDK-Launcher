# Custom SDK Launcher

Free and open source SDK launcher for Counter-Strike: Global Offensive and other source engine games

### Why should I move to Custom SDK Launcher?

- **It's open source:** You can see full code of an application and know exactly what it does
- **All in one:** Support for many Source Engine based games
- **Custom profiles:** Create profiles for many games and switch between them easily
- **New to mapmaking? No problem:** List of specially selected tutorials will help you to get started creating content for various games
- **No more annoying bugs:** We have fixed issues existing in default SDK launcher

### GameBanana integration

Custom SDK Launcher can be used as GameBanana mod installer. Currently, it can only install or update mods, but can't uninstall. To add support for your modification, you need to pack it inside ZIP archive, and add "meta" file inside "meta" directory (path "meta/meta"). First line should contain path to directory inside archive of which files should be extracted. Second line should contain path to directory under game dir (for csgo game directory would be named "Counter-Strike: Global Offensive\csgo") to which files would be extracted.

Example meta files:

```
Distroir
materials/Distroir
```

```
materials
materials
```

```
Bills Mod/Example textures/Example modification
models
```