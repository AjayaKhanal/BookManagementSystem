using BookManagementSystem.Debugging;

namespace BookManagementSystem
{
    public class BookManagementSystemConsts
    {
        public const string LocalizationSourceName = "BookManagementSystem";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "daa2c30ef490426fa87ff353a3aa48e8";
    }
}
