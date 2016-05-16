<h3>BattleShips</h3>
<img src = "https://github.com/jeff1978/BattleShips/blob/master/BattleShips/BattleshipGameImage.jpg" align = right>
This is my unique take on the popular board game. It uses a single console, has two game modes and it is multiplayer.
<br>The development of this project is driven by unit testing (tests and mockups are included in this repo)

<h4>Instructions:</h4>
Follow the on screen instructions to build a custom grid and start a new game. There can be two or more players. In simple mode each player has just two ships; a Scout and a Destroyer. In custom mode, the ship types and quantities can instead be chosen. Players take turns to fire at their opponents' ships. The last surviving player is the winner. For convenience the file can be downloaded from: <a href = "https://github.com/jeff1978/BattleShips/blob/master/BattleShips/bin/Debug/BattleShips.exe?raw=true">\BattleShips\bin\Debug\BattleShips.exe</a>
<br><h4>Valid Commands:</h4>
Place Ship Input: 2,4,h - places a ship at position 2,4 horizontally (or v for vertically)
<br>Fire Input: 3,5 - fires a missile to position 3,5
<br>Note: <br>Ship positions will not be allowed to overlap or lie outside the boundary of the sea.
<br>The sea dimensions are zero based. eg. a 5 x 5 sea size will have coordinates ranging from 0,0 to 4,4
<h4>Installing and Running</h4>
The application runs in a single executable file found here: <a href = "https://github.com/jeff1978/BattleShips/blob/master/BattleShips/bin/Debug/BattleShips.exe?raw=true">\BattleShips\bin\Debug\BattleShips.exe</a><br>The file can be opened by double clicking it. The user can follow instructions on the console and also use it to type their input.
<h4>Unit Testing and Mockups</h4>
C# Test files and mockups are found here: <a href = "https://github.com/jeff1978/BattleShips/tree/master/BattleShipsTests">\BattleShipsTests</a>
<br>Tests were run using the nuget packages: NUnit 2.6.4 and NUnit Test Adapter 2.0.0
<h4>Development Status</h4>
The application works and development is still ongoing. Areas of development include:
<br><br> - Refactoring of code using lambdas and at least one generic method (required for the console parser classes)
<br> - Creation of language classes to support user options for both English and Maori.
<h4>Notes and Acknowledgements</h4>
A full list of information sources can be found here: <a href = "https://github.com/jeff1978/BattleShips/blob/master/BattleShips/Acknowledgements.txt">\BattleShips\BattleShips\Acknowledgements.txt.</a>
<h4>Supported operating systems and Issues</h4>
BattleShips should run on any Windows operating system. It has been tested on Windows 10 Home Edition 32-bit. Existing issues can be logged on the <a href = "https://github.com/jeff1978/BattleShips/issues">Issues page.</a>
<h4>Licence</h4>
BattleShips is licensed under the GNU Lesser General Public License v.3.0<br>
The GPL is specifically designed to reduce the usefulness of GPL-licensed code to closed-source, proprietary software. The BSD license (and similar) do not mandate code-sharing if the BSD-licensed code is modified by licensees. The LGPL achieves the best of both worlds: an LGPL-licensed library can be incorporated within closed-source proprietary code, and yet those using an LGPL-licensed library are required to release source code to that library if they change it.
