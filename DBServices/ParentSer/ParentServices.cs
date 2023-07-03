using Microsoft.AspNetCore.Mvc;
using SchoolApp.DBServices.ParentSer;
using SchoolApp.DTO;
using SchoolApp.Entities;
using SchoolApp.Models;
using SchoolApp.Repositories.ParentRepository;
using SchoolApp.Services;

namespace SchoolApp.DBServices.ParentService
{
    public class ParentServices : IParentServices
    {
        private readonly IUserService _currentService;
        private readonly IParentRepository _parentRepository;
        public ParentServices(IParentRepository parentRepository, IUserService currentService)
        {
            _parentRepository = parentRepository;
            _currentService = currentService;
        }
        public int CreateParent(AddUserDTO userDTO)
        {
            Parent parent = new();
            parent.Name = userDTO.PName;
            parent.FatherName = userDTO.PFatherName;
            parent.Gender = userDTO.PGender;
            parent.Relation = userDTO.PRelation;
            parent.Religion = userDTO.Religion;
            parent.Cnic = userDTO.PCnic;
            parent.PhoneNo = userDTO.PPhone;
            parent.Email = userDTO.PEmail;
            parent.IsAlive = userDTO.AliveStatus;
            parent.CreatedOn = DateTime.Now;
            return (_parentRepository.AddParents(parent));
        }
        public int UpdateParent(UpdateStudentDTO userDTO)
        {
            Parent parent = _parentRepository.ParentbyId(userDTO.Pid);
            parent.Name = userDTO.PName;
            parent.FatherName =userDTO.PFatherName;
            parent.Email = userDTO.PEmail;
            parent.Cnic=userDTO.PCnic;
            parent.PhoneNo = userDTO.PPhone;
            parent.Gender=userDTO.PGender;
            parent.Relation = userDTO.PRelation;
            parent.Religion = userDTO.PReligion;
            parent.ModifiedOn = DateTime.Now;
            parent.CreatedOn = parent.CreatedOn;
            parent.ModifiedBy = _currentService.GetUserId();
            parent.IsAlive = userDTO.AliveStatus;
            parent.Id = userDTO.Pid;
            return _parentRepository.UpdateParent(parent);
        }
    }
}
