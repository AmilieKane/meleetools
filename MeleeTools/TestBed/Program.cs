﻿using System;
using MeleeLib;
using MeleeLib.DatHandler;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = new File(@"X:\Brawl Hacking\Melee\Backup\Super Smash Bros. Melee - Character Files\1.00\1 - Moveset\Marth\PlMs.dat");
            AttributesIndex attributes = file.Header.FTHeader.Attributes;
            for (var i = 0; i < attributes.Count; i++ )
            {
                Console.WriteLine(String.Format("0x{0:X4} {1} = {2}", i * 4, attributes[i].Name, attributes[i].Value));
            }
            Console.ReadLine();
        }
    }
}