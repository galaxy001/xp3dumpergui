XP3 Dumper GUI(翻訳版)
このプログラムは、Resty製のxp3dumperなどの一連のxp3抽出ツールのGUIパッケージであり、シンプルなGUI呼び出し機能を提供します。これらのツールは、xp3dumperディレクトリにあります。

Ver 0.3 新機能の説明：
	NTLEA サポート：
		使用 NTLEA 支持之前请选定 ntleac.exe 位置并确认其正确性。
	複数のxp3を同時にunpackする機能：
		xp3をカンマで区切ります、例えば "data.xp3,bgm.xp3"（引用符は必要なし）。
	
amemiya
2011-1-31

使用説明：
	1.选择游戏启动exe和执行exe，它们的区别在于前者可能只是一个引导用的破解补丁（如sinsemilla_boot.exe），后者才会是游戏运行时的进程（如sinsemilla.exe）。如果没有这样的引导程序，它们就是同一个exe文件。
	2.选择要解包的xp3文件和保存路径。
	3.如果游戏需要转区才能运行，选择SoraApp可以调用SoraApp（今后版本会支持NTLEA）转区运行游戏，前提是你安装了SoraApp或NTLEA。
	4.点击“提取”，稍等几秒，就会开始提取。如果没有开始提取，请点击取消，再按照5操作。
	5.如果发现没有开始提取，这是因为游戏启动花的时间较长，请将载入插件延时调大一些再尝试。
	
	windows xp上で『黄昏のシンセミア』和『G線上の魔王』のxp3 unpackについてテスト済。
	
clowwindy
2010-9-24

BUGなどの要望はこちら:
http://bbs.sumisora.org/read.php?tid=10975710

History:
	0.3 NTLEAサポートの追加、同時に複数のパケットを抽出するサポート
	0.2 xp3dumper0.12dに基づいて、抽出を判断する機能を実装
	0.1 最初の公開リリース

追記:
build: vscode2017 with windows10で出来た。