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
            // 0 > 1 > 2 > 3 > (4 > 2) > 5 
            // !(0 > 6), (2 > 6)
            Confirm = 1, // shop click      
            Shipping = 2,// shipper click
            Receive = 3,// shop click  
           // Washing =4,  // shop click
          //  Successful=5,// shipper click
            Cancel = 4   // user, shop, shippe click
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
