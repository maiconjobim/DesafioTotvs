namespace DesafioTotvs.Application.Models
{
    public class Failure
    {
        public string PropertyName { get; set; }

        public string ErrorMessage { get; set; }

        public Failure(string name, string errorMessage)
        {
            PropertyName = name;
            ErrorMessage = errorMessage;
        }

        public Failure()
        {
            
        }
    }
}