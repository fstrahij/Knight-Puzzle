# Knight-Puzzle
Goal of the puzzle is to collect all coins with knight figure. Knight can only move in "L" shape (like knight piece in chess). Knight can not move on the wall but can jump over them. The board on which the game is played is a rectangle. The layout of the level is defined in a text file that needs to be loaded of the disk. The board file is hot-swappable during gameplay: changing the file changes the board in the game.

# Text file example
  ##..##<br/>
  #C...#<br/>
  ....C#<br/>
  #....#<br/>
  ..K..#<br/>
  #...##<br/>

# Symbol meaning

|Symbol|Name|Description|
|------|----|-----------|
|#|Wall|Knight can’t reach this location.|
|.|Empty|Knight can land here.|
|C|Coin|Collect all to finish the puzzle.|
|K|Knight|Marks the start location of the knight.|

# Screenshoots:
 <p float="left">
  <img src="https://github.com/fstrahij/Knight-Puzzle/blob/master/Knight%20Puzzle/Assets/Screenshoots/kp_1.png" alt="kp 1" width="350" height="250">
  <img src="https://github.com/fstrahij/Knight-Puzzle/blob/master/Knight%20Puzzle/Assets/Screenshoots/kp_2.png" alt="kp 2" width="350" height="250">
  </p>
