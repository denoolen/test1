using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApp2.ViewModels
{
	class BindingGroupTest : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{

			//var p = ((BindingGroup)value).Items[0] as Person;

			if (value.ToString().Length >= 4)
				return new ValidationResult(true, Color.FromRgb(2, 2, 2));
			else return new ValidationResult(false, Color.FromRgb(2, 2, 2));
		}

	

	}
}
