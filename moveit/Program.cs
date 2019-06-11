using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Threading.Timer;
using System.Runtime.InteropServices;
using System.Threading;

namespace moveit
{
	class Program
	{
		[DllImport("User32.Dll")]
		public static extern long SetCursorPos(int x, int y);

		[DllImport("user32.dll")]
		public static extern bool GetCursorPos(out POINT lpPoint);

		static void Main(string[] args)
		{
			var timer = new System.Timers.Timer();
			timer.Elapsed += OnTimedEvent;
			timer.Interval = 10000;
			timer.Start();
			//timer.Enabled = true;
			Console.ReadLine();
		}

		private static void OnTimedEvent(object sender, ElapsedEventArgs e)
		{
			const int movement = 50;
			const int scale = 1;

			POINT pos = new POINT();
			var success = GetCursorPos(out pos);
			var x = pos.X * scale;
			var y = pos.Y * scale;

			Console.WriteLine("X: {0}, Y: {1}", x, y);

			SetCursorPos(x + movement, y + movement);
			Thread.Sleep(100);
			SetCursorPos(x, y);
		}

	}

	[StructLayout(LayoutKind.Sequential)]
	public struct POINT
	{
		public int X;
		public int Y;

		//public static implicit operator Point(POINT point)
		//{
		//	return new Point(point.X, point.Y);
		//}
	}
}
