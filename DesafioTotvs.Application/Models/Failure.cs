namespace DesafioTotvs.Application.Models
{
    public class Failure
    {
        public string Name { get; set; }

        public string ErrorMessage { get; set; }

        public Failure(string name, string errorMessage)
        {
            Name = name;
            ErrorMessage = errorMessage;
        }

        public Failure()
        {
            
        }
    }
}