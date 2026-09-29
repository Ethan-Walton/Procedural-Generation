# ProceduralTerrain2D 🏔️

A lightweight C# console application that generates 2D procedural terrain maps using anchor points, distance-based calculations, and iterative smoothing.

## Features ✨

* **Randomized Generation**: Initializes a 2D data map filled with random values[cite: 1].
* **Anchor Points**: Randomly distributes anchor points across the terrain to act as high-elevation peaks[cite: 1].
* **Distance Mapping**: Computes point values based on their distance to the nearest anchor[cite: 1].
* **Neighbor Smoothing**: Applies an iterative box blur / averaging filter to smooth out terrain contours[cite: 1].
* **Visual Console Output**: Renders the final terrain map directly in the console using emojis (representing different elevation tiers like water, plains, mountains, etc.)[cite: 1].

## Project Structure 📁

* **`Map.cs`**: Contains the core `Map` class responsible for data map initialization, anchor placement, distance calculations, smoothing algorithms, and visual console printing[cite: 1].
* **`Program.cs`**: The main entry point that configures map dimensions, sets up anchors, runs the smoothing passes, and displays the raw data and visual maps[cite: 2].

## Getting Started 🚀

### Prerequisites
* [.NET SDK](https://dotnet.microsoft.com/) installed on your machine.

### Running the Project
1. Clone the repository:
   ```bash
   git clone [https://github.com/Ethan-Walton/Procedural-Generation.git](https://github.com/Ethan-Walton/Procedural-Generation.git)
