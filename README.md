<h1 align = "center">The test task from <a href = "https://lestagamesacademy.ru/" target="_blank">Lesta Games Academy</a></h1>
<div>
  <h2>Targets</h2>
  <ol>
    <li>It is necessary to write a simple 3D platformer in which the character must move from the starting point. to the finishing line, through a field filled with obstacles.</li>
    <li>The starting point is a 10x10 meter platform on which the player stands. Diverges from the starting point several paths intertwined with each other. At the finish line, all the paths converge into one. The trails consist of 3x3 meter platforms.</li>
    <li>Some of the blocks that make up the trail are traps that interfere in various ways
the player gets to the finish line. For a test task you need to implement at least 3-4 different types traps. Two of them are required:
      <ul>
        <li>When a player steps on a block, it is activated (lights up orange) and after 1 second will damage anyone standing on the block (by blinking red). After dealing damage, trap
"re-infects" for 5 seconds, after which it begins its logic from the very beginning</li>
        <li>A block on which the wind blows, pushing the character with a certain force. The wind acts on character only while he is in the block. The wind direction changes every 2 seconds for random. The wind blows strictly horizontally.</li>
      </ul>
    </li>
    <li>To win you need to cross the finish line. At this moment, a full-screen message “Victory!” is displayed. and a button that restarts the game. The time is indicated on this screen passing the level, which is counted from the moment of crossing the starting line.</li>
    <li>The player loses if he falls off the path into the abyss or runs out of health. Health always should be displayed on the screen. When a player loses, a screen appears saying "Defeat!" and a button that restarts the game.</li>
  </ol>
</div>

<div>
  <h2>Description</h2>
  <ul>
    <li>FSM was implemented in the game. The purpose of using fsm to separeta differents states: ShowLandscape state (using camera's Animator), Playing state, EndGame state (to show the end screen: win or loose). FSM is the entry game point.</li>
    <li>MVC pattern was implemented to separate data from health to allow managers to use only health data. Exmaple: to showw health bar, to change State on EndGame State etc.</li>
  </ul>
</div>
