namespace ShoeShineAPI.Enum
{
    public static class EnumClass
    {
        public enum RoleEnum
        {
            Admin = 1,
            Seller = 2,
            Customer = 3,

        }
        public enum RatingEnum
        {
            One_Star = 1,
            Two_Star = 2,
            Three_Star = 3,
            Four_Star=4,
            Five_Star=5
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

        public enum GenderEnum
        {
            Man = 1,
            Woman = 2 ,
            Other = 3 
        }
    }
}
