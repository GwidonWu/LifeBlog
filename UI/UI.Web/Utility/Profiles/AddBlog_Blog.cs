using AutoMapper;
using DAL.Entity.Entities;
using UI.Web.Areas.Admin.Models;

namespace UI.Web.Utility.Profiles
{
    public class AddBlog_Blog : Profile
    {
        protected override void Configure()
        {
            var map = Mapper.CreateMap<BlogViewModel, Blog>();
            map.ConstructUsing(s => new Blog
            {
                Content = s.Content
            });
        }
    }
}