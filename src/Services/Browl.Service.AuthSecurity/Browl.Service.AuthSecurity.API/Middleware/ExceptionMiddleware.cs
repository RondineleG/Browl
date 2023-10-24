﻿using System.Net;

using Browl.Service.AuthSecurity.API.Models;
using Browl.Service.AuthSecurity.Application.Exceptions;

using Newtonsoft.Json;

namespace Browl.Service.AuthSecurity.API.Middleware;

public class ExceptionMiddleware
{
	private readonly RequestDelegate _next;
	private readonly ILogger<ExceptionMiddleware> _logger;

	public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
	{
		_next = next;
		_logger = logger;
	}

	public async Task InvokeAsync(HttpContext httpContext)
	{
		try
		{
			await _next(httpContext);
		}
		catch (Exception ex)
		{
			await HandleExceptionAsync(httpContext, ex);
		}
	}

	private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
	{
		var statusCode = HttpStatusCode.InternalServerError;
		CustomProblemDetails problem = new();

		switch (ex)
		{
			case BadRequestException badRequestException:
				statusCode = HttpStatusCode.BadRequest;
				problem = new CustomProblemDetails
				{
					Title = badRequestException.Message,
					Status = (int)statusCode,
					Detail = badRequestException.InnerException?.Message,
					Type = nameof(BadRequestException),
					Errors = badRequestException.ValidationErrors
				};
				break;
			case NotFoundException NotFound:
				statusCode = HttpStatusCode.NotFound;
				problem = new CustomProblemDetails
				{
					Title = NotFound.Message,
					Status = (int)statusCode,
					Type = nameof(NotFoundException),
					Detail = NotFound.InnerException?.Message,
				};
				break;
			default:
				problem = new CustomProblemDetails
				{
					Title = ex.Message,
					Status = (int)statusCode,
					Type = nameof(HttpStatusCode.InternalServerError),
					Detail = ex.StackTrace,
				};
				break;
		}

		httpContext.Response.StatusCode = (int)statusCode;
		var logMessage = JsonConvert.SerializeObject(problem);
		_logger.LogError(logMessage);
		await httpContext.Response.WriteAsJsonAsync(problem);

	}
}
