# Unity Design Patterns Demo

A Unity project demonstrating the implementation and interaction of various design patterns in game development. The project features a simple game where a player can move in four directions, collect coins to level up, and includes functionality for undoing/redoing moves and replaying gameplay sequences.

![GamePlay GIF](./Readme_resources/gamePlay.gif)

## Design Patterns Implementation

### Command Pattern
**What is it?**  
A behavioral pattern that encapsulates a request as an object, thereby allowing parameterization of clients with requests, queuing of requests, and logging of the requests. Also supports undoable operations.

**Implementation in this project:**
- `MoveCmd` class encapsulates movement logic and parameters (direction, target transform)
- Each movement command implements both `Execute()` and `Undo()` methods
- `CmdInvoker` manages command execution, undo/redo stacks, and replay functionality

**Benefits:**
- Clean separation between input handling and movement execution
- Built-in support for undo/redo functionality
- Ability to record and replay movement sequences
- Easy to extend with new commands without modifying existing code

### Transaction Pattern
**What is it?**  
A pattern that ensures data modifications are atomic and maintain consistency by encapsulating changes in transaction objects.

**Implementation in this project:**
- `IPlayerData` interface provides read-only access to player data (Level)
- Modifications to player data must go through `ExecuteTransaction()` method
- `LevelUpTransaction` and `ResetLevelTransaction` encapsulate specific data modifications

**Benefits:**
- Controlled access to player data
- Centralized data modification logic
- Easy to add new types of data modifications
- Better maintainability and debugging

### Dependency Injection Pattern
**What is it?**  
A pattern that implements inversion of control for resolving dependencies. Objects receive other objects they depend on instead of constructing them internally.

**Implementation in this project:**
- Uses Wooga's Injector implementation
- Dependencies are marked with `[Inject]` attribute
- `Initializer` class sets up the dependency bindings
- Classes depend on interfaces (e.g., `IEventMng`) rather than concrete implementations

**Benefits:**
- Reduced coupling between components
- Easier unit testing through dependency substitution
- More flexible and maintainable code
- Clearer representation of class dependencies

### Factory Pattern
**What is it?**  
A creational pattern that provides an interface for creating objects but allows subclasses to decide which class to instantiate.

**Implementation in this project:**
- `TransactionFactory` handles creation of transaction objects
- Implements object pooling for transactions
- Automatically handles dependency injection for new transactions

**Benefits:**
- Centralized transaction object creation
- Automatic dependency injection
- Object pooling reduces garbage collection
- Cache system improves performance

## Project Structure

The project is organized into several key components:
- Player movement and input handling
- Level system with coin collection
- Event management system
- Transaction-based data modification
- Command-based movement system with undo/redo

## Getting Started

1. Clone the repository
2. Open the project in Unity
3. Open the demo scene
4. Use UI buttons to move the player
5. Collect coins to increase level
6. Use UI buttons for undo/redo and replay functionality

## Technical Requirements
- Unity 2021.3 or higher
- .NET 4.x Scripting Runtime
