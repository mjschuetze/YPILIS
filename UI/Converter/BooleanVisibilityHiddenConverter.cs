﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace YellowstonePathology.UI.Converter
{
	public class BooleanVisibilityHiddenConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
            string result = "Hidden";
            if (System.Convert.ToBoolean(value) == true) result = "Visible";
            return result;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{            
            return DependencyProperty.UnsetValue;
		}
	}	
}
