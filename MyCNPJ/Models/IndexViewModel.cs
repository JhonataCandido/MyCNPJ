namespace MyCNPJ.Models
{
    public class IndexViewModel
    {
        public IndexViewModel() { }
        public IndexViewModel(string messageError, string cnpj)
        {
            MessageError = messageError;
            Cnpj = cnpj;
        }
        public string Cnpj { get; set; }
        public string MessageError { get; set; }
    }
}
