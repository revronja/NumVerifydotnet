﻿using System;
using System.Threading.Tasks;
//using Gtk;

namespace NumVerfifydotnet
{
	class Program
    {
        /*static void Main(string[] args)
        {s
            Console.WriteLine("Hello World!");
        }*/
        public static void Main(string[] args)
        {
          
			Task t = new Task(Client.DownloadPageAsync);
            t.Start();
            Console.WriteLine("Downloading page...");
            Console.ReadLine();
        }
    }
}
