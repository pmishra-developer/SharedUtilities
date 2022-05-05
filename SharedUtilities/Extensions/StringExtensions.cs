namespace SharedUtilities.Extensions
{
    public static class StringExtensions
    {
        public static int GetWordCount(this string inputstring)
        {
            if (!string.IsNullOrEmpty(inputstring))
            {
                string[] strArray = inputstring.Split(' ');
                return strArray.Count();
            }

            return 0;
        }

        public static int GetCharacterCount(this string inputstring, char character)
        {
            if (!string.IsNullOrEmpty(inputstring))
            {
                return inputstring.Split(character).Length - 1;
            }

            return 0;
        }
    }
}
