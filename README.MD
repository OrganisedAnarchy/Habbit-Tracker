# Habit Tracker

A small command-line habit tracker written in C# and targeting .NET 10.

## Features

- Add, view, modify, complete, and delete habits.
- Record a weekly target and an optional deadline for each habit.
- Save habits as JSON in the current working directory when you exit.

## Run

Install the .NET 10 SDK, then run the application from the repository root:

```sh
dotnet run
```

Follow the numbered menu to manage habits. The application stores its data in `habits.json` in the working directory.
