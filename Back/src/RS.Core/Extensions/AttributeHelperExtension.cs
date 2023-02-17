﻿using System.ComponentModel;

namespace RS.Core.Extensions;

public static class AttributeHelperExtension
{
	public static string ToDescription(this Enum value)
	{
		var da = (DescriptionAttribute[])value.GetType().GetField(value.ToString())
			.GetCustomAttributes(typeof(DescriptionAttribute), false);
		return da.Length > 0 ? da[0].Description : value.ToString();
	}
}