using System.Text;

namespace LatinToCyrilicConverterRUS
{
    public class LatinToCyrilicConverter
    {
        public LatinToCyrilicConverter() 
        {
        }
        public Dictionary<char, char> Dictionary = new Dictionary<char, char>()
            {
                {'a', 'А'},
                {'b', 'Б'},
                {'w', 'В'},
                {'g', 'Г'},
                {'d', 'Д'},
                {'e', 'Е'},
                {'v', 'Ж'},
                {'z', 'З'},
                {'i', 'И'},
                {'j', 'Й'},
                {'k', 'К'},
                {'l', 'Л'},
                {'m', 'М'},
                {'n', 'Н'},
                {'o', 'О'},
                {'p', 'П'},
                {'r', 'Р'},
                {'s', 'С'},
                {'t', 'Т'},
                {'u', 'У'},
                {'f', 'Ф'},
                {'h', 'Х'},
                {'c', 'Ц'},
                {'~', 'Ч'},
                {'{', 'Ш'},
                {'}', 'Щ'},
                {'y', 'Ы'},
                {'x', 'Ь'},
                {'`', 'Ю'},
                {'q', 'Я'}
            };

        public string Translate(string latin) 
        {
            var sb = new StringBuilder(latin);
            foreach (var replacePair in Dictionary)
            {
                sb.Replace(replacePair.Key, replacePair.Value);
            }
            return sb.ToString();
        }
    }
}