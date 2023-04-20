namespace BlogApiEF.ViewModels
{
    public class ResultViewModel<T>
    {
        public ResultViewModel(T data, List<string> erros)
        {
            Data = data;
            Errors = erros;
        }
        public ResultViewModel(T data) // Se der Certo
        {
            Data = data;
        }
        public ResultViewModel(List<string> errors) // Se der Errado
        {
            Errors = errors;
        }
        public ResultViewModel(string error) // Se der Errado e só tiver um erro
        {
            Errors.Add(error);
        }

        public T Data { get; private set; }
        public List<string> Errors { get; private set; } = new();//Criando = inicializando também
    }
}
