# project notes

## 02-07-2018:

I added a sprite for the dialog background. 

when I code the dialog I want to make the sprite hidden.

## 27-03-2018: 

I tested that components were attached to the GameObjects. 

I also found out that asserting Is.Not.Null gets a false positive when the object was not found. I'm not sure why this is, or if C# has different `null` types, or what. I fixed it by asserting that `object == null` is False. 



## 25-03-2018: 

I got a basic test to work.

Next I want to try testing actual functionality, for example, what happens on collision with various objects under various circumstances. 

I'm having trouble finding reference materials. This may help: https://blogs.unity3d.com/2014/07/28/unit-testing-at-the-speed-of-light-with-unity-test-tools/

I would also like to separate out generic setup functions into a "setup" method so I don't have to repeat things. 

## 17-03-2018: 

I fixed the bugs from last time. 

Existing functionality:

* coins persist across levels 
* StatsCanvas and Player objects are only assigned programatically. (It might make sense to make them Private on the game manager class because of this.)

things I'd like to add next:

* unit and integration tests 
    - https://docs.unity3d.com/Manual/testing-editortestsrunner.html
    - I'd probably follow the steps in that project to generate a basic test. I'd make a `testing` branch, I think, until I got it running reasonably well. 

* following that, setting up a CI build on Github 
    - instructions for running from the command line here https://docs.unity3d.com/Manual/CommandLineArguments.html
    - I would also have to figure out how to get Github to run it...
    - https://gist.github.com/eppz/ad4fb8d64bdcb0c50a6abea57716823e

* multiple level, menu screens 
* improve UI for StatsCanvas 
* modularize things? Create assets? IDK 
    https://docs.unity3d.com/Manual/HOWTO-exportpackage.html I think I should get a more fleshed out version running first 

## 25-02-2018:

keep getting 
```
MissingReferenceException: The variable canvas of GameManager doesn't exist anymore.
You probably need to reassign the canvas variable of the 'GameManager' script in the inspector.
UnityEngine.GameObject.GetComponent[CanvasManager] () (at /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/GameObjectBindings.gen.cs:38)
GameManager.UpdatePlayerStats[Int32] (System.String name, Int32 value) (at Assets/Scripts/GameManager.cs:84)
Player.SetHealth (Int32 newHealth) (at Assets/Scripts/Player.cs:28)
GameManager.Awake () (at Assets/Scripts/GameManager.cs:73)
``` 
on second time loading the "sample" scene.

It doesn't seem to be a problem for the Player object. 

Maybe that UI should be a singleton? 

## 25-02-2018:
Started moving way further from the tutorial. 

Made an enemy that moves around and deals damage. Right now it deals way too much damage. 

Some silly mistakes I keep making:
* not checking that a script is attached to the object I expect it is
* passing in strings as flags and spelling them inconsistently 

I did a lot though!

## 16-02-2018:
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
