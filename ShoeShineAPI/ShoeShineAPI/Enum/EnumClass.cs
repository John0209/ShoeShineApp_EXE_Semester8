namespace ShoeShineAPI.Enums;
public static class EnumClass
{
	public enum RoleEnum
	{
		Admin = 1,
		Seller = 2,
		Customer = 3,
		
	}
	//public static string ToEnumString(this Enum value)
	//{
	//	return Enum.GetName(value.GetType(), value);
	//}
	public static class RoleNames
	{
		public const string Admin = "Admin";
		public const string Seller = "Seller";
		public const string Customer = "Customer";
	}
}


