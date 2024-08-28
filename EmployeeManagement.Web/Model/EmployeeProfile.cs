using AutoMapper;
using EmployeeManagement.Model;

namespace EmployeeManagement.Web.Model
{
    public class EmployeeProfile :Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EditEmployeeModel, Employee>();
            CreateMap<Employee, EditEmployeeModel>()
                .ForMember(dest=>dest.ConfirmEmail,opt=>opt.MapFrom(src=>src.Email));
            ;
        }
    }
}
