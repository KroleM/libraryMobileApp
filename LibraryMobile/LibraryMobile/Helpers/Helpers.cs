﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMobile.Helpers
{
	public static class Helpers
	{
		public async static Task<bool> HandleRequest(this Task serviceMethod)
		{
			try
			{
				await serviceMethod;
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
		}
	}
}
