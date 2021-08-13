using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Internal;
using DesafioTotvs.Application.Extentions;
using DesafioTotvs.Application.Models;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Serilog;

namespace DesafioTotvs.Application.Behaviours
{
  public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TResponse : class
  {
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    private readonly IMapper _mapper;

    private readonly ILogger _logger;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators, IMapper mapper, ILogger logger)
    {
      _validators = validators;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
      var requestName = request.GetGenericTypeName();

      _logger.Information("Validation behaviour started '{RequestType}'.", requestName);

      var validationFailures = _validators
          .Select(validator => validator.Validate(request))
          .SelectMany(validationResult => validationResult.Errors)
          .Where(validationFailure => validationFailure is not null)
          .ToList();

      if (validationFailures.Any())
        return CreateErrorResponse(validationFailures);

      var response = await next();

      _logger.Information("Validation behaviour finished '{RequestType}' without any failure.", requestName);

      return response;
    }

    private TResponse CreateErrorResponse(IEnumerable<ValidationFailure> validationFailures)
    {
      _logger.Error("One or more validation has failed. The command of type '{RequestType}' will not be processed.", typeof(TRequest).GetGenericTypeName());

      var response = new Response();

      validationFailures.ForAll(validationFailure => _logger.Error(
          "Validation error occurred for property '{PropertyName}' with error message '{ErrorMessage}' and attempted value '{AttemptedValue}'"
          , validationFailure.PropertyName
          , validationFailure.ErrorMessage
          , validationFailure.AttemptedValue));

      response.AddValidationFailures(_mapper.Map<IEnumerable<Failure>>(validationFailures));

      return response as TResponse;
    }
  }
}
