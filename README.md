# SEDSS_Client
[SEDSSプロトコル](https://github.com/gpsnmeajp/SimpleEncryptedDataSendSample)を用いて、VRMアバターデータを送信するツールです。  
同じネットワークに接続したスマートフォンなどのアプリへかんたんにアバターを転送することができます。  
現在、waidayoに対応しています。  

It is a tool to send VRM avatar data using [SEDSS protocol](https://github.com/gpsnmeajp/SimpleEncryptedDataSendSample).  
You can easily transfer your avatar to an app such as a smartphone connected to the same network.  
Currently, it supports waidayo.

# 使い方 / How to use
+ Windows: SEDSS_Client.exeを起動します。ファイアーウォールはすべて許可してください。  
Windows: Start SEDSS_Client.exe. Please allow all firewalls.
+ Mac: SEDSS_Client.appを右クリックして開きます。ネットワーク通信は許可してください。  
Mac: Right-click on SEDSS_Client.app to open it. Please allow network communication.
+ Linux: SEDSS_Client.x86_64を起動してください。ファイアーウォールを設定している場合は39500 (UDP)および8000(TCP/HTTP)を開いてください。  
Linux: Please start SEDSS_Client.x86_64. If you have a firewall set up, open 39500 (UDP) and 8000 (TCP / HTTP).

操作 / Operation
+ 画面に従ってVRMファイルを指定してください  
Follow the instructions on the screen to specify the VRM file
+ 自動検出ボタンを押してください(検出できない場合はIPアドレスを指定してください)  
Press the auto-detect button (if not detected, please set the IP address)
+ PINを入力してください(waidayoであれば設定画面のAvatar PIN codeです。タップすると自分で番号を設定できるので、自分で好きな番号を設定することを**強く**おすすめします。)  
Enter your PIN (If it's waidayo, it's the Avatar PIN code on the settings screen. You can set the number yourself by tapping it, so it is strongly recommended to set the number you like.)
+ 送信ボタンを押してください。(うまくいかないときはwaidayoを開き直してみてください)  
Press the submit button. (If that doesn't work, try reopening waidayo)


結果は、最下部のメッセージを確認してください。  
Check the message at the bottom for the results.

# [Boothからダウンロード(安定版) / Download from Booth (stable)](https://sabowl.booth.pm/items/2535168)
# [githubからダウンロード(最新版) / Download from github (latest)](https://github.com/gpsnmeajp/SEDSS_Client/releases)

# スクリーンショット / Screenshots
<img src="https://github.com/gpsnmeajp/SEDSS_Client/blob/main/README-image/screen.png?raw=true" width=80% />

# [お問合せ先(Discordサーバー)](https://discord.gg/nGapSR7)
## twitterでのサポートは行っておりません

# Waidayoは以下
https://github.com/nmchan/waidayo

# Oredayo4Mは以下
https://github.com/gpsnmeajp/Oredayo4M
