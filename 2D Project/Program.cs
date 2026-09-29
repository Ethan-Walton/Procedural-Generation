using System;
using System.Collections.Generic;

namespace ProceduralTerrain2D
{
    /// <summary>
    /// The main program class for initializing and displaying a procedural 2D terrain map.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main entry point of the program. Initializes and displays the procedural 2D terrain map.
        /// </summary>
        /// <param name="args">The command-line arguments passed to the program.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Procedural Terrain 2D Initialized.");
            
            int size = 50;

            Map map = new Map(size, size);
            int anchors = map.Width / 4;

            map.SetAnchors(anchors);
            map.SetPointsBasedOnDistance();

            for (int i = 0; i < 5; i++)
                map.SmoothPointsByAverage();

            map.PrintDataMap();
            map.PrintVisualMap();
        }
    }
}
