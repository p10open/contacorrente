using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Teste.ContaCorrente.Domain.Events;
using Teste.ContaCorrente.Domain.Interfaces.Events;
using Teste.ContaCorrente.Domain.Interfaces.Repositories;
using Teste.ContaCorrente.Domain.Interfaces.Services;
using Teste.ContaCorrente.Domain.Interfaces.UoW;
using Teste.ContaCorrente.Domain.Services;
using Teste.ContaCorrente.Infra.Data.Context;
using Teste.ContaCorrente.Infra.Data.Repositories;
using Teste.ContaCorrente.Infra.Data.UoW;

namespace Teste.ContaCorrente.Infra.CrossCutting.IoC
{
    public static class Bootstrapper
    {
        public static void Injetar(this IServiceCollection services)
        {
            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddScoped<IContaService, ContaService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<INotificacaoEvent, NotificacaoEvent>();
        }
    }
}
