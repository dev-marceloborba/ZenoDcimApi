namespace ZenoDcimManager.Shared.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveAccents(this string str)
        {
            byte[] bytes = System.Text.Encoding.GetEncoding("iso-8859-8").GetBytes(str);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }
    }

}