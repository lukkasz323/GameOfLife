# GameOfLife
Conway's Game of Life written in C# / .NET 6. 
It's a console application. 

The main difference between a regular Game of Life is that it is enclosed in a finite area.
Cells outside of that area behave like dead cells, but cannot ever come to life.

# Instructions
Run ```GameOfLife.exe``` to start the console app.

By default the game runs in a 50 x 40 (width x height) window.

This behaviour can be overriden by specifying width and then height in starting parameters like this:
```GameOfLife <width> <height>```

For example:
```GameOfLife 24 36```

# Requirements
- Windows
- .NET 6
