using EProcurementRefactor.Application.DTOs;
using EProcurementRefactor.Application.Exceptions;
using EProcurementRefactor.Application.Interfaces;
using EProcurementRefactor.Domain.Entities;
using EProcurementRefactor.Infrastructure.DBContexts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EProcurementRefactor.Infrastructure.Reposetories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IGenericRepository<SiacAdmin> _adminRepository;
        private readonly IPasswordService _passwordService;
        public AdminRepository(

            IGenericRepository<SiacAdmin> adminRepository
            ,IPasswordService passwordService)
        {
            _adminRepository = adminRepository;
            _passwordService = passwordService;
        }
        public async Task<SiacAdmin> Login(AdminLoginDto adminLoginDto, CancellationToken cancellationToken)
        {
            var admin = await _adminRepository.FindByFirstOrDefault(a => a.Username == adminLoginDto.name,cancellationToken);
            
            if(admin is null)
            {
                throw new KeyNotFoundException("admin not found.");
            }
            bool verifyPassword = _passwordService.VerifyPassword(adminLoginDto.password, admin.Password);

            if(!verifyPassword)
            {
                throw new UnAuthenticatedException("Invalid Password.");
            }
            return admin;
        }
    }
}