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
        public enum DashboardOption
        {
            User = 1,
            Store = 2,
            Transaction = 3,
            Money = 4
        }
       // 0. await payment, 1. confirm, 2. shipping, 3. receive, 4. cancel
        public enum OrderStatus
        {
            Confirm = 1,
            Shipping = 2,
            Receive = 3,
            Cancel = 4
        }
        public enum Compare
        {
            Increase = 1,
            Decrease = 2,
            NothingChanges=3
        }

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
