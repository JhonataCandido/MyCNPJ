namespace MyCNPJ.Utils
{
    public static class Extensions
    {
        public static string ParseCnpj(this string cnpj) => cnpj.Replace("/", "").Replace("-", "").Replace(".", "").Trim();
        public static string ValidField(this string value) => string.IsNullOrEmpty(value) ? "Não informada" : value;
    }
}
