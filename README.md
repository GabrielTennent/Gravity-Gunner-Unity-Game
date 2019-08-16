Tennengabr - 300393699

SWEN 325 Assignment 2:

group members:
Gabriel Tennent - Computer Science
Alex - Design




Git lab repo link: 

https://gitlab.ecs.vuw.ac.nz/tennengabr/comp313as2




Demo video of the final game:

https://youtu.be/mWHBWh7JoZ4





Process Documentation:

Coding:
The proccess of devoloping this game was long went through a lot of changes. 
Initially the idea was to have a 2D - player vs player - shooter in which the 
player had to control their movement like you would in cs go and had to come to 
a complete stop before they could shoot their weapon accuratly. After 
implementing this (the movement is displayed in my AS1)
it became clear the game was to difficuilt and boring as the amount of skill
required to shoot each other was unsatisfying and lead to long fights.

After this I began the real Assignment 2 repo and decided that the game needed 
to be more fast passed and have different core mechanic. This is when the idea 
of shooting objects to control the enviroment around you came into place. After
discussing with Alex, we decided that since we were controlling our 
player gravity it would make sense to put them in space and have meteors that
can be shot by the player to add them to their team. What this meant is that 
if a player shot a meteor it would change color to the color of the player and 
would damage the oppisite player if they collided with it.

Initially the player was just in a box that had floating meteors they could 
shoot to control. After seeing how much fun it was to shoot meteors and bounce 
them around the screen we decided to put the players inside of a astreoid field 
in which all aspects of the map could be shot to be controlled by the player 
including the walls and floor.



Controls for players!:

do not use the up key and w is that is not implemented properly yet.

player 1 - a (move left)
         - d (move right)
         - r (change gravity)
         - t (shoot)
         
player 2 - leftArrow (move left)
         - rightArrow (move right)
         - o (change gravity)
         - p (shoot)

Player always shoots the way they are facing, and can shoot meteors to control
them.





Code Architecture:
The core loop of the game is handled inside of the player controller script
attached to the player object, and bullet script attached to the bullet object
that are instantiated objects from the player shooting inside of the player
controller.

The inputs are handled inside of the player controller and are public fields
that are set for each player.

The objective of the game is for the players to fight each other. Each player
starts with 5HP and will lose 1HP if they get hit by a enemy bullet of enemy
controlled meteor.

The most techinically chanlleging thing for me after working out how to use a 
single player controller script for both players was devoloping the
impact of bullets hitting meteors. This is because since I was altering the 
meteor object state I had to use onTrigger events which caused the unity physics 
to stop working. I then had to devolope my own physics for when a bullet hits a
meteor which was rather difficult. On top of that the current collision with 
meteors and the player is still rather buggy and could use more work. If I was 
to have more time I would implement onTriggerEnter function inside of the 
meteors and introduce a new collision outline that is onTrigger 
have that cause damage to the player instead of having two meteor colliders of
the same size with one being an on trigger event that sometimes dosn't get called
as the meteor has already bounced away from the player collider colliding with
non-ontrigger meteor collider. 




