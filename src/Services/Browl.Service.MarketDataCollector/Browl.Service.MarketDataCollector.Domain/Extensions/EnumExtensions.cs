using System.ComponentModel;

namespace Browl.Service.MarketDataCollector.Domain.Extensions
{
	public static class EnumExtensions
	{
		public static string ToDescriptionString<TEnum>(this TEnum? value) where TEnum : Enum
		{
			if (value == null)
			{
				throw new ArgumentNullException(nameof(value));
			}

			string valueAsString = value.ToString();
			Type valueType = value.GetType();
			System.Reflection.FieldInfo fieldInfo = valueType.GetField(valueAsString)!;
			DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

			return attributes?[0].Description ?? valueAsString;
		}
	}
}