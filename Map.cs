using System;
using System.Collections.Generic;

namespace ProceduralTerrain2D
{
    /// <summary>
    /// Represents a 2D procedural terrain map with anchor points and smoothing functionality.
    /// </summary>
    public class Map
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public float[,] DataMap { get; set; }

        public (int x, int y)[] Anchors { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Map"/> class with the specified width and height.
        /// </summary>
        /// <param name="width">The width of the map.</param>
        /// <param name="height">The height of the map.</param>
        public Map(int width, int height)
        {
            Width = width;
            Height = height;
            DataMap = FillMap();
            Anchors = new (int x, int y)[Width / 4];
        }

        /// <summary>
        /// Fills the map with random float values between 0 and 1.
        /// </summary>
        /// <returns>A 2D array representing the filled map.</returns>
        public float[,] FillMap()
        {
            float[,] map = new float[Width, Height];
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    map[x, y] = (float)new Random().NextDouble();
                }
            }
            return map;
        }

        /// <summary>
        /// Sets the specified number of anchor points randomly on the map.
        /// </summary>
        /// <param name="numberOfAnchors">The number of anchor points to set.</param>
        public void SetAnchors(int numberOfAnchors)
        {
            for (int i = 0; i < numberOfAnchors; i++)
            {
                int x = new Random().Next(Width);
                int y = new Random().Next(Height);
                DataMap[x, y] = 1.0f; // Set anchor point to maximum value
                Anchors[i] = (x, y);
            }
        }

        /// <summary>
        /// Calculates the distance from the specified point to the nearest anchor point.
        /// </summary>
        /// <param name="px">The x-coordinate of the point.</param>
        /// <param name="py">The y-coordinate of the point.</param>
        /// <returns>The distance to the nearest anchor point.</returns>
        public float DistanceToNearestAnchor(int px, int py)
        {
            float minDistance = float.MaxValue;
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    foreach (var anchor in Anchors)
                    {
                        float distance = (float)Math.Sqrt(Math.Pow(px - anchor.x, 2) + Math.Pow(py - anchor.y, 2));
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                        }
                    }
                }
            }
            return minDistance;
        }

        /// <summary>
        /// Sets the values of all points on the map based on their distance to the nearest anchor point.
        /// </summary>
        public void SetPointsBasedOnDistance()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (DataMap[x, y] != 1.0f) {
                        DataMap[x, y] = DistanceToNearestAnchor(x, y);
                    } 
                }
            }
        }

        /// <summary>
        /// Smooths the points on the map by averaging each point with its neighbors.
        /// </summary>
        public void SmoothPointsByAverage()
        {
            float[,] newDataMap = new float[Width, Height];
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {

                    float sum = 0f;
                    List<float> points = new List<float>();

                    for (int offsetY = -1; offsetY <= 1; offsetY++)
                    {
                        for (int offsetX = -1; offsetX <= 1; offsetX++)
                        {
                            if (x + offsetX >= 0 && x + offsetX < Width && y + offsetY >= 0 && y + offsetY < Height)
                            {
                                points.Add(DataMap[x + offsetX, y + offsetY]);
                            }
                        }
                    }

                    foreach (var point in points)
                    {
                        sum += point;
                    }
                    newDataMap[x, y] = sum / points.Count;
                }
            }
            DataMap = newDataMap;
        }

        /// <summary>
        /// Prints the raw data map to the console.
        /// </summary>
        public void PrintDataMap()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Console.Write($"{DataMap[x, y]:f2} ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Prints a visual representation of the map to the console using colored blocks.
        /// </summary>
        public void PrintVisualMap()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    switch (DataMap[x, y])
                    {
                        case >= 10f:
                            Console.Write("🟦");
                            break;
                        case >= 9f:
                            Console.Write("🟧");
                            break;
                        case >= 8f:
                            Console.Write("🟨");
                            break;
                        case >= 4f:
                            Console.Write("🟩");
                            break;
                        default:
                            Console.Write("🟫");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}