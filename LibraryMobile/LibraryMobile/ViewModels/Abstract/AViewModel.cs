﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace LibraryMobile.ViewModels.Abstract
{
	public class AViewModel<T> where T : class
	{
		public T DataStore => DependencyService.Get<T>();
	}
}
