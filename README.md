# Text Adventure Kata

The rules of this kata were simple:

1. Build a dungeon crawler style text adventure game
2. The game must have a minimum of 5 different rooms
3. There must be a key in one of the rooms for you to obtain
4. You must exit the dungeon using the key in order to win the game

A couple of things I wanted to do...

- Improve my C# skills
- These days, a text-only console game is like depriving the senses. What if the player were blind? How would I write the game content?

## Projects

The `Engine` project contains the core of the game engine. You can use the classes in Engine to build and execute the game environment. Actions (commands the user can type) are extensible. Room behaviours are extensible.

The `EngineTests` project contains a reasonable test suite for the Engine. It covers core behaviours at a few different levels of abstraction and integration. Care was taken to remove pointless tests, and try and keep the highest value tests as the project evolved.

The `Game` project contains the console executable for the game, and a class that uses the Engine to construct a hand-crafted 5 room dungeon.

All in all, I spent about 4 hours on this through January 2020. It runs on any platform that supports DotNet Core 3.
