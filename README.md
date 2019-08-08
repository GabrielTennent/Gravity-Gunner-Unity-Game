# COMP313

## Gabriel Tennent - 300393699

## Assignment 1 - Personal

## Counter Strike movement mechanics

### Mechanic demonstration link:

https://youtu.be/KLuZFbT_qAE

No aduio - Text explanation - read technology description first:

1 - Shows normal player movement without accounting for deacceleration

2 - Shows player movement with account for deacceleration - using counter strafe
method

3 - Shows shooting standing still

4 - Shows (in my case) you can't shoot without low enough velocity

5 - Shows the difference in time to get first shot off, between shooting with
movement control and without

6 - Shows 2D example of counter strafing (A -> D -> A -> D) and shooting at 
exact moment when player velocity is 0

7 - Takes a few attempts but shows player able to shoot when changing gravity
(could be at the top of a jump) because there is also a point where velocity
is 0 at the peak of a vertical movement transition

## Technology description:

The technology I am covering in this assignment is the demonstration of one of
the movement mechanic's used in Counter Strike GO. The movement mechanic I am 
focusing on is Valve (counter stikes devolopers) implementation of what
I call ice movement. What this means is when the player stops holding down a 
movement key they still continue moving for a period after that, exactly
like taking your foot off the accelerator in the car. 

Though this mechanic is so simple and exists in many games, counter strike have
made movement control the most important mechanic in the game to learn. Movement
control meaning being able to counter the ice effect of moving by moving your 
character in the oppisite direction ever so slightly after letting go of the 
original direction to counter act the left over momentum and prevent sliding 
(aka counter strafing).

This prevention of sliding is very important because well sliding or moving
at all in the game the accuracy of your gun accuracy is very poor (in my case 
you cant shoot). You only become accurate in counterstrike (shoot in my demo)
well standing still and will never become accurate if the first shot is made
well moving. So players that have proper movement control will have accurate 
shots faster than those who dont. This makes counter strike a very unique FPS
because even though aim is such a huge part of the game it dosn't matter if you
can't control your character properly as the movement and shooting have a 
relationship.

For my demonstration of this technology I have made a 2D example of the movement
mechanic in a exaggerated form. In my case the players continues sliding for 
a lot longer but this is for demonstration purposes. Well the player has a
decent amount of velocity the player is red, indicating that they are moving.
When the player comes to a dead stand still they turn green indicating they have
no velocity and can use their weapon. This movement mechanic could be integrated
with any mechanic in a game, meaning that for the given mechanic to work 
properly the player must first control their character to a dead stand still. 
This increases the required player input to progress through the game quickly 
and if implemented correctly can make the game a lot more satisfying to learn.

Another variation of an interesting movement mechanic is seen in Apex legends,
where they integrate the three primary movement types for fastest possible 
movement. Making the fastest way to move in the game cycling through running, 
crouch -> sliding, and then jumping out. Though this is very different to the 
movement mechanic I have demonstrate, it is similar in the sense they are 
inegrating complex player inputs into a basic core player movement - 
in turn increasing the skill cap of the game.

## Sources:

The first half of this video talks about how the movement mechanics that I am 
covering work in CS Go.

https://www.youtube.com/watch?v=AGcgQEzCCrI


