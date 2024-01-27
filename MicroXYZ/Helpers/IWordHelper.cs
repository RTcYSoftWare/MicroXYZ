namespace MicroXYZ.Helpers
{
    public interface IWordHelper
    {
        public string HashToText(string text, string key);
        public string CreateSixDigitCode();        
    }
}
