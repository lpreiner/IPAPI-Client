using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace IPAPIClient
{
	static class FieldExtensions
	{
		public static string Map(this Field field)
		{
			return MapEnum<Field>.ByAttribute<EnumMemberAttribute>.ToAttributeValue(field, x => x.Value);
		}

		static class MapEnum<TEnum> where TEnum : Enum
		{
			public static class ByAttribute<TAttr> where TAttr : Attribute
			{
				public static TResult ToAttributeValue<TResult>(TEnum e, Func<TAttr, TResult> valueSelector)
				{
					var f = e.GetType().GetField(e.ToString());
					var a = f.GetCustomAttributes(typeof(TAttr), true).FirstOrDefault() as TAttr;
					if (a is null)
						throw new Exception("Oops");

					return valueSelector(a);
				}
			}
		}
	}
}
