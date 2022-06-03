#Routed states

Routed states allows developers to easily stack and switch between states. There are no restrictions on how many states can be stacked and every new state is unique.

##Glossary

- *State* is any arbitrary functionality that can be inserted to the game. State can be a UI view but can also be, for example, an input state where the state listens for certain type of input.
- *Stacked state* means that states are stacked on top of each other. Each state in stack is active and can hook into game events. State is destroyed when it is popped from the stack.
- *Routed state* is an abstraction of the stack. States can be written down in url format ("route") so they can be parsed into the stack and can receive parameters. This is especially useful for deeplinking.

## Goals

This state prototype aims to demonstrate ease of use and good maintainability of the entire codebase that uses this system.

## StateManager

StateManager handles the state stack and changing of the states. StateManager offers an asynchronous interface for switching between states.

When switching from one route to another, StateManager preserves the common route of the old route and of the new route.

## IState

IState is the interface all states must implement. IState allows states to do asynchronous (with Unity coroutines) OnEnter and OnExit methods to allow for more complex tasks, such as web requests and loading and unloading of assets.

## TODO

- More unit tests
- Better documentation - more images
- Samples