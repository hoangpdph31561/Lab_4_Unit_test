﻿namespace Code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            ItemManager itemManager = new();
            itemManager.UpdateItem(4444, null);
        }
    }
}
