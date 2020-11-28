using AutoMapper;
using Nuclear.Dtos.Account;
using Nuclear.Dtos.Category;
using Nuclear.Dtos.Group;
using Nuclear.Dtos.Post;
using Nuclear.Dtos.Topic;
using Nuclear.EntityFramework.Models;

namespace Nuclear
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<Account, AccountDto>()
                .ReverseMap()
                .ForMember(a => a.Password, opt => opt.Ignore());

            CreateMap<Account, AnonymousAccountDto>()
                .ReverseMap()
                .ForMember(a => a.Password, opt => opt.Ignore())
                .ForMember(a => a.Groups, opt => opt.Ignore())
                .ForMember(a => a.Posts, opt => opt.Ignore())
                .ForMember(a => a.Email, opt => opt.Ignore())
                .ForMember(a => a.IsAdministrator, opt => opt.Ignore())
                .ForMember(a => a.IsEmailVerified, opt => opt.Ignore());

            CreateMap<Category, CategoryDto>()
                .ReverseMap();

            CreateMap<Group, GroupDto>()
                .ReverseMap();

            CreateMap<Post, PostDto>()
                .ReverseMap()
                .ForMember(p => p.Topic, opt => opt.Ignore());

            CreateMap<Topic, TopicDto>()
                .ReverseMap()
                .ForMember(t => t.Category, opt => opt.Ignore());
        }
    }
}
