﻿using System;

namespace Calculator.ConsoleApp
{
	public static class Program
	{
		private static readonly Calculator Calculator = new Calculator();

		public static void Main()
		{
			while (true)
			{
				Console.Write("Введите выражение: ");

				string expression = Console.ReadLine();
				if (string.IsNullOrWhiteSpace(expression))
					continue;
				if (expression == "exit")
					break;

				try
				{
					decimal result = Calculator.Calculate(expression);
					Console.WriteLine("Результат: {0}", result);
				}
				catch (ParseException ex)
				{
					Console.WriteLine(ex.Message);
				}
				
			}
		}
	}
}
