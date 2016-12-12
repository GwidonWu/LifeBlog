using AutoMapper;
using DAL.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UI.Web.Areas.Admin.Models;

namespace UI.Web.Utility.Profiles
{
    public class ModifyBlog_Blog : Profile
    {
        protected override void Configure()
        {

            //var map=  Mapper.CreateMap<ModifyBlogViewModel, Blog>().ForMember(blog=>blog.ID,o=>o.Ignore()).ForMember(blog => blog.Content, o => o.MapFrom(_o=>_o.editorValue));
            var map = Mapper.CreateMap<BlogViewModel, Blog>().ForMember(blog => blog.ID, o => o.Ignore()).ForMember(blog => blog.Content, o => o.MapFrom(_o => _o.Content));
            //会覆盖愿对象
            //map.ConstructUsing(s => new Blog
            //{
            //    Content = s.editorValue
            //});

            var map2 = Mapper.CreateMap<Blog, BlogViewModel>();
            map2.ConstructUsing(s => new BlogViewModel
            {
                Content = s.Content
            });
        }
    }
}