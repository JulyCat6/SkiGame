# SkiGame
This is a 3D game developed in Unity as part of a coursework assignment.
The player controls a skier, navigates through a track with obstacles, competes in a time-based race, and tries to achieve a place in the leaderboard.

# Gameplay

The player controls a skier and must:

1. complete the track
2. avoid obstacles
3. reach the finish line
4. improve their time


The goal of the game is to complete the race in the shortest possible time and reach the top of the leaderboard.
# Features Implemented: 
1. Two Levels Created: 
Two different tracks with obstacles and finish zones were created.
2. Player Control: 
The player is controlled using Unity Input System.
3. Collision System: 
A collision system was implemented using Unity Colliders and physics.
4. Knockback System: 
After hitting obstacles, the player is pushed back.
# Race Logic:


1. race start system
2. penalty zones (flags that must be passed from the correct side)
3. finish line
4. timer system
5. Game Over Screen

After finishing the race, a final screen is displayed showing:
1. completion time
2. buttons: Quit, Restart, Next Level
3. Data Saving & Leaderboard

# Implemented:
1. saving best results
2. storing top results
3. leaderboard system

# Leaderboard Visualization
A leaderboard is displayed on the game over screen:

1. TOP 3 results are shown
2. completion times are displayed
3. current run result is shown
# Additional Features (Bonus)
1. collision sound effects for some obstacles
2. UI fade-in / fade-out effects
3. event-driven architecture system
4. UI animations
5. Singleton GameData system

The game was built for: 
Windows (.exe build)
