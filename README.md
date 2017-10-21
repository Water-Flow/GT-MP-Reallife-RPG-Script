Der hier auf Github veröffentlichte Code, ist unter MIT veröffentlicht. Er wird nicht aktiv entwickelt oder supportet.    
Eine mögliche Aktualisierung auf eine veraltete Version des offiziellen Scriptes (unter Closed Source) ist denkbar.    
Mehr Information gibt es hier: https://forum.terratex.eu/index.php?/topic/107-terratex-closed-source-zugriff/&tab=comments#comment-541    

# GTMP-Real--Roleplay-Script
GTMP Real-/Roleplay Script des TerraTex Servers   
   
## Build Status:
- Master: [![Build Status: master](http://build.terratex.eu:8080/buildStatus/icon?job=TerraTex-Community/GT-MP-Reallife-RPG-Script/master)](http://build.terratex.eu:8080/job/TerraTex-Community/GT-MP-Reallife-RPG-Script/master)    
- Develop: [![Build Status: develop](http://build.terratex.eu:8080/buildStatus/icon?job=TerraTex-Community/GT-MP-Reallife-RPG-Script/develop)](http://build.terratex.eu:8080/job/TerraTex-Community/GT-MP-Reallife-RPG-Script/develop)    
   
# LICENSE
Dieses Projekt steht unter der MIT Lizenz.
Erstellt wird dieses Script von TerraTex / TerraTex-Community.
Hauptverantwortlicher ist Geramy92 (Colin Weber)

# Requirements
- Visual Studio 2017
- NodeJs
- MariaDB 10.2.7 (MySql sollte mit Anpassungen auch gehen, ist aber nicht von uns supportet bzw. empfohlen)

# Installation
1. Das Project muss zum starten zunächst compiled werden. 
	0. NodeJs installieren!
	1. Order resources/TerraTex-RL-RPG/ öffnen und ```npm install``` ausführen
    2. Project in Visual Studio öffnen (Projectdatei liegt im Ordner resources bei)  
    3. Im Visual Studio alle Nuget Packete wiederherstellen / Installieren
    4. Compilen
2. Die Resources können anschließend so wie er ist (inklusive Rohdatein und compiled Dateien, wie sie VS ablegt) in den Resources Ordner des Servers kopiert werden
3. im Ordner TerraTex-RL-RPG/configs alle Example Configs umbebennen von \*_example.xml zu *.xml und entsprechend bearbeiten
4. server settings.xml entsprechend bearbeiten
5. SQL Datein aus dem Ordner TerraTex-RL-RPG\Sqls entsprechend in der Datenbank importieren
6. Server starten

# Contribution
- Pullrequests werden nur in der develop Branch akzeptiert. 
- Es müssen alle Änderungen angeben und begründet werden.
- Pullrequests werden nur gemerged wenn sie von allen Pipelines als Grün akzeptiert werden

# Weitere Informationen zu Integrierten Resourcen
Die folgenden Resourcen sind Integriert worden im Ordner _IncludedExternalResources. Sie sind nicht Bestandteil der Lizenz des TerraTex Scriptes.
Sie sind integriert worden um einfacher mit dem Script zu interagieren bzw. modifiziert zu werden.
- cefchat  
- https://github.com/ellisonleao/clumsy-bird

# Additional Scripting Docs
- <a href="resources/TerraTex-RL-RPG/_Docs/CustomEvents.md">Custom Events</a>
