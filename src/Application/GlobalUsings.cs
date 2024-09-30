// Global using directives

global using AutoMapper;
global using BeHeroes.CodeOps.Abstractions.Aggregates;
global using BeHeroes.CodeOps.Abstractions.Commands;
global using BeHeroes.CodeOps.Abstractions.Events;
global using BeHeroes.CodeOps.Abstractions.Facade;
global using Domain.Aggregates;
global using Domain.Events.Pod;
global using Domain.Services;
global using Domain.ValueObjects;
global using Application.Commands.Pod;
global using Application.Mapping.Converters;
global using Application.Mapping.Converters.Pod;
global using MediatR;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using System.Diagnostics;
global using System.Diagnostics.Metrics;
global using System.Reflection;
global using System.Text.Json;
global using System.Text.Json.Serialization;