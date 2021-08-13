using System.Collections.Generic;
using System.Linq;

namespace DesafioTotvs.Application.Models
{
    public class Response
    {
      public object Payload { get; set; }
      public List<Failure> Failures { get; } = new();

      public Response(object payload)
      {
        Payload = payload;
      }
       public Response()
      {

      }
        public bool IsErrorResponse() => Failures.Any();
        public void AddValidationFailures(IEnumerable<Failure> validationFailures) => Failures.AddRange(validationFailures);
        public void AddValidationFailure(Failure validationFailure) => Failures.Add(validationFailure);
        public void ClearValidationErrors() => Failures.Clear();
        public void RemoveValidationFailure(Failure validationFailure) => Failures.Remove(validationFailure);
        

    }
}