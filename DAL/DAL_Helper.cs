namespace OnlineMobileShopping.DAL
{
    public class DAL_Helper
    {
        public static string ConnectionStr = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("myConnectionString");

    }
}
