using chef.API.Data;
using chef.API.DTOs.Chef;
using chef.API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace chef.API.Services.ChefService;

public class ChefService: IChefService
{
    private readonly ApplicationDbContext _context;

    public ChefService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ChefOutDto>> GetAllAsync()
    {
        var list = await _context.Chefs.ToListAsync();
        return list.Select(chef => new ChefOutDto
        {
            Id = chef.Id,
            FullName = chef.FullName,
            Specialty = chef.Specialty,
            Bio = chef.Bio,
            ProfileImageUrl = chef.ProfileImageUrl
        });
    }

    public async Task<ChefOutDto?> GetByIdAsync(int id)
    {
        return (await _context.Chefs.FindAsync(id)) is Chef chef ? new ChefOutDto
        {
            Id = chef.Id,
            FullName = chef.FullName,
            Specialty = chef.Specialty,
            Bio = chef.Bio,
            ProfileImageUrl = chef.ProfileImageUrl
        } : null;
    }

    public async Task<bool> CreateAsync(ChefInDto chef)
    {

        _context.Chefs.Add(new Chef
        {
            FullName = chef.FullName,
            Specialty = chef.Specialty,
            Bio = chef.Bio,
            ProfileImageUrl = chef.ProfileImageUrl
        });
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateAsync(int id, ChefInDto updatedChef)
    {
        var chef = await _context.Chefs.FindAsync(id);
        if (chef == null) return false;

        chef.FullName = updatedChef.FullName;
        chef.Specialty = updatedChef.Specialty;
        chef.Bio = updatedChef.Bio;
        chef.ProfileImageUrl = updatedChef.ProfileImageUrl;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var chef = await _context.Chefs.FindAsync(id);
        if (chef == null) return false;

        _context.Chefs.Remove(chef);
        await _context.SaveChangesAsync();
        return true;
    }
}
