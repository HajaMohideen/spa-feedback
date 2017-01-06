using AutoMapper;
using Feedback.Entities;
using Feedback.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Feedback.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Users, UsersViewModel>();
        }
    }
}