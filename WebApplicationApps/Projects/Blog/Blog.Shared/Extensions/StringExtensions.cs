using System.Text.RegularExpressions;

namespace Blog.Shared.Extensions
{
    public static class StringExtensions
    {
        // <summary>
        /// Remove invalid chars , white space and replace white space with _ underscore
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string RemoveInvalidChars(this string txt)
        {
            return Regex.Replace(txt, @"[^a-zA-Z0-9_]", "").Replace(" ", "_");
        }


        /// <summary>
        ///  Remove html tags from a string
        ///  ("<[^>]*>")
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string RemoveHtmlTags(this string html)
        {
            return Regex.Replace(html, "<.*?>", string.Empty);
        }
    }
}