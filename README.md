# TankWars

A turn-based artillery game for the terminal, written in C# (.NET 8). Two tanks face off on a generated landscape: move your tank, set an angle and power, and try to hit your opponent before they hit you.

Built as the final project in the course Object-Oriented Programming 2 (OOP2), autumn 2026. The in-game text is in Swedish.

## Features

- **Three game modes:** Human vs Computer, Human vs Human, and Computer vs Computer
- **Three computer difficulty levels:** Easy fires random shots, while Hard simulates possible shots and picks the best one
- **Three maps:** Training ground, Earth and Moon, each with its own terrain and decorations
- **Build your own weapon:**
  - Ammunition: Normal (small blast area, 50 damage) or Explosive (large blast area, 25 damage)
  - Flight style: Standard (regular arc) or Guided (press SPACE mid-air to dive straight down)
- **Power-ups on the map:** Heal (+25 HP), Shield and Boost (stronger next shot)
- **Rematch** with the same settings after each game

## Controls

| Key | Action |
| --- | --- |
| Left / Right arrow | Move the tank |
| Space | Fire, then enter angle (0-90) and power (1-100) |
| Space (in the air) | Dive straight down (Guided flight style) |
| Esc | Quit the current game |

## Getting started

Requires the [.NET 8 SDK](https://dotnet.microsoft.com/download).

```bash
git clone https://github.com/admlarsson/TankWars.git
cd TankWars
dotnet run
```

Use a terminal that supports UTF-8, since the game draws with Unicode symbols.

## Project structure

| Folder | Contents |
| --- | --- |
| `Core/` | Turn handling and the generic `EntityManager<T>` |
| `Game/` | Game loop, menus and game modes |
| `Map/` | Maps, terrain generators and decorations |
| `Tanks/` | Tanks, bullets, flight behaviours and bot strategies |
| `Items/` | Power-ups |
| `Factories/` | Factories for maps, tanks, weapons and power-ups |

## Design patterns

The project's focus was applying object-oriented design. Each use is documented in comments in the code (marked `FALL #1` to `FALL #10`):

- **Factory Method:** creating maps, tanks, weapons and power-ups
- **Strategy:** game modes, bot difficulty and bullet flight behaviour
- **Bridge:** separating maps from their terrain generation
- **Generics:** `EntityManager<T>` handles both tanks and power-ups

## Authors

Filip Sundberg, David Palmér and Adam Larsson
