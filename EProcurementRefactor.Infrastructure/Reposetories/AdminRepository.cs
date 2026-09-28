using EProcurementRefactor.Application.DTOs;
using EProcurementRefactor.Application.Interfaces;
using EProcurementRefactor.Domain.Entities;
using EProcurementRefactor.Infrastructure.DBContexts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EProcurementRefactor.Infrastructure.Reposetories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly EprocurementDbContext _dbContext;
        private readonly IPasswordService _passwordService;
        public AdminRepository(
            EprocurementDbContext dbContext
            ,IPasswordService passwordService)
        {
            _dbContext = dbContext;
            _passwordService = passwordService;
        }
        public async Task<SiacAdmin> Login(AdminLoginDto adminLoginDto, CancellationToken cancellationToken)
        {
            var admin = await _dbContext.SiacAdmins.FirstOrDefaultAsync(a => a.Username == adminLoginDto.name);
            
            if(admin is null)
            {
                throw new KeyNotFoundException("admin not found.");
            }
            bool verifyPassword = _passwordService.VerifyPassword(adminLoginDto.password, admin.Password);

            if(!verifyPassword)
            {
                throw new ValidationException("Invalid Password.");
            }
            return admin;
        }
    }
}