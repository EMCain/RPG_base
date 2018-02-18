# project notes

## 16-02-2016:
Partially completed this:
https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/writing-player-script?playlist=17150

I left out some things and added some things. 

Biggest frustrations:

* forgot to set gravity to 0 on the rigid body 2d, so it "fell" as soon as the game started
* forgot to call base.Start on the Player class's start method, so it didn't assign variables properly

## 04-02-2018:

I completed the tutorial section here, [Moving Object Script](https://unity3d.com/learn/tutorials/projects/2d-roguelike-tutorial/moving-object-script?playlist=17150), from [2D Roguelike tutorial](https://unity3d.com/learn/tutorials/s/2d-roguelike-tutorial).

I realized I did this somewhat out of order, though I don't want to recreate the entire Roguelike project, so I plan on going back and creating earlier parts as needed.

Concepts I had to look up:

[`StartCoroutine` + `yield return`](https://stackoverflow.com/questions/12932306/how-does-startcoroutine-yield-return-pattern-really-work-in-unity)

[IEnumerator](https://msdn.microsoft.com/en-us/library/system.collections.ienumerator)

generic types are something I want to learn more about.
