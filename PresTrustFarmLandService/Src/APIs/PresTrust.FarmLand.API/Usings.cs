//---------------------------------------------- Package Namespaces ----------------------------------------------//
global using Microsoft.AspNetCore.Mvc;
global using System.Reflection;
global using MediatR;
global using Microsoft.AspNetCore.Mvc.Filters;
global using System.Net;


global using PresTrust.FarmLand.API.Contracts;
global using PresTrust.FarmLand.API.DependencyInjection;
global using PresTrust.FarmLand.API.Extensions;
global using PresTrust.FarmLand.Application.Queries;
global using PresTrust.FarmLand.Infrastructure.SqlServerDb;
global using PresTrust.FarmLand.Application.ApiExceptions;
global using PresTrust.FarmLand.Domain.Entities;
global using PresTrust.FarmLand.API.Infrastructure.Filters;
global using Polly.Extensions.Http;
global using PresTrust.FarmLand.Application.Services.EmailApi;
global using PresTrust.FarmLand.Application.Services.IdentityApi;
global using PresTrust.FarmLand.Domain.Configurations;
global using PresTrust.FarmLand.Domain.Constants;
global using Polly;
global using System.Net.Http.Headers;
global using static PresTrust.FarmLand.Domain.Constants.FloodMitigationDomainConstants;
global using PresTrust.FarmLand.API.Infrastructure.Behaviours;
global using FluentValidation;
global using FluentValidation.AspNetCore;
global using FluentValidation.Results;






