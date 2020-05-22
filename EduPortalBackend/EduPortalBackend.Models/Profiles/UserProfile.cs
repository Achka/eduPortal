using AutoMapper;
using Entities.DTO;
using Entities.Models;

namespace Entities.Profiles
{
	public class UserProfile : Profile
	{
		public UserProfile() {
			CreateMap<User, UserProfileDto>();
			CreateMap<UserProfileDtoForUpdate, User>();
			CreateMap<RegisterDto, User>().ForMember(user => user.UserName, options => options.MapFrom(dto => dto.Email));
		}
	}
}
