﻿namespace CH21Tests
{
    internal record Person
    {
        public string Name { get; init; }
        public int Age { get; set; }

        // public override string ToString()
        // {
        //     return $"[ Name:={Name}, Age={Age} ],";
        // }
    }
}
