using ShoeShineAPI.Gateway.IConfig;

namespace ShoeShineAPI.Gateway.Config
{
    public class MomoConfig : IMomoConfig
    {
        public static string ConfigName => "Momo";
        public string PartnerCode => _section[nameof(PartnerCode)];
        public  string ReturnUrl => _section[nameof(ReturnUrl)];
        public  string IpnUrl => _section[nameof(IpnUrl)];
        public  string AccessKey => _section[nameof(AccessKey)];
        public  string SecretKey => _section[nameof(SecretKey)];
        public  string PaymentUrl => _section[nameof(PaymentUrl)];

        private readonly IConfigurationSection _section;

        public MomoConfig(IConfiguration configuration)
        {
            _section = configuration.GetSection(ConfigName);
        }
    }
}
