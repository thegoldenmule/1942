Instructions
------
* Start high score server: **Server/Server/bin/Debug/Server.exe.**
* Start **Client/Assets/Scenes/Main** in Unity.

Design
------

* Ninject - I recommend using a dependency injection of some sort in a game of any non-trivial size. This removes the need for programming singletons, global event dispatchers can shrink in size (or be removed entirely), and circular dependencies can be caught programmatically. This also allows for unit testing and for easily using using systems at runtime and in editor tools.

* Bootstrap + Director - The Bootstrap script exists to pull the Director away from the Unity API. The Director can be used on client + servers.

* IAsyncToken - This works much like promises. Using these from the get go, you can program asynchronous interfaces early in the game's lifecycle. Streaming, loading, caching, and server requests can all be hidden behind this interface. In addition, it removes some of the pains of using callbacks directly.

* Data Definitions - The Data/ directory stores data objects for each entity. These are separate from actual code-- this is an absolute must for a data driven game.

* FSMs - A root level FSM (GameStateController) controls which major piece of the game we are in. An FSM also controls how we respond to input (InputController).

* Pooling - Programming against a pooling interface is also a great idea to get in early. In demanding games, pooling is an absolute must.

* High Score Server - A very simple REST service for high scores.