Unity Porting Labs
====================

Unity Porting Labs demo game and plugins

How to Start:
1. Clone the entire repository to your desktop.
2. Begin by opening: DemoGame/WP8/DemoGame.sln
3. When this Windows Phone 8 Visual Studio solution opens, notice that the Solution contains 4 projects.
4. Assembly-CSharp-vs:  Unity generated solution with Unity based scripts
5. DemoGame: Windows Phone 8 solution, built from Unity's Build Settings option. Set this project as the Startup Project to build out an XAP which can be published to the Windows Store.
6. WindowsPlugin: a Unity plugin that contains the stubbed out version of the functions found in WP8Plugin.
7. WP8Plugin: a Unity plugin that uses Windows Phone 8 API's. 

By creating Unity plugins, you can call the functions in Unity scripts. When the game runs in Unity, it'll use the implementation found in WindowsPlugin. When the game runs on the Windows Phone emulator or devices, it'll use the implementation found in WP8Plugin. Plugins are used to support Windows Phone features and API not available in Unity's scripting mode. Unity uses Mono .NET, which has a subset of APIs not available for Windows Phone .NET.

PLUGIN SUPPORT FOR WINDOWS PHONE 8:

Completed:
- System.IO.File
- System.IO.Directory

In progress:
- WeChat sharing
- In App Purchase

Windows Phone 8 Features:

I have code for Live Tiles scheduling and local notifications, player control, game flow navigation (back button), etc. However, due to time constraints, I'll share it when time permits. 

Visual Studio Code Snippets:
To use the code snippets, add them to your local Visual Studio folder, (the path may look like: D:\Visual Studio 2013\Code Snippets). In Visual Studio, Tools > Code Snippets Manager, select Visual C#, then click Add to select the path where you have your code snippets.

In the code, you can just use the short keys: Ctrl + k, x, to insert a snippet.

System:
Windows 8.1 Enterprise
Visual Studio 2013 Ultimate
Unity 4.3.4


Thanks for your support & patience.
Elissa Tong



