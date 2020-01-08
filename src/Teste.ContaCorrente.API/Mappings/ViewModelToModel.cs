using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Teste.ContaCorrente.API.ViewModels;
using Teste.ContaCorrente.Domain.DTO;

namespace Teste.ContaCorrente.API.Mappings
{
    public class ViewModelToModel: Profile
    {
        public ViewModelToModel()
        {
            CreateMap<TransferenciaViewModel, TransferenciaDTO>();
        }
    }
}
