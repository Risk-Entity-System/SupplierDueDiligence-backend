using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupplierDueDiligence.API.Api.Filters;
using SupplierDueDiligence.API.Config.Exceptions;
using SupplierDueDiligence.API.Data;
using SupplierDueDiligence.API.Domain.Models;
using SupplierDueDiligence.API.Infraestructure.Dtos.Suppliers;
using SupplierDueDiligence.API.Infraestructure.Shared.ApiResponse;
using SupplierDueDiligence.API.Infraestructure.Shared.Pagination;

namespace SupplierDueDiligence.API.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[ValidateModel]
[Authorize]
public class SupplierController(AppDbContext context) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] SupplierQueryParameters query)
    {
        var suppliersQuery = context.Suppliers
            .Include(s => s.Country)
            .AsNoTracking();

        if (!string.IsNullOrWhiteSpace(query.BusinessName))
        {
            suppliersQuery = suppliersQuery
                .Where(s => s.BusinessName.Contains(query.BusinessName));
        }

        if (query.CountryId.HasValue)
        {
            suppliersQuery = suppliersQuery
                .Where(s => s.CountryId == query.CountryId.Value);
        }

        if (!string.IsNullOrWhiteSpace(query.TaxId))
        {
            suppliersQuery = suppliersQuery
                .Where(s => s.TaxId.Contains(query.TaxId));
        }

        if (query.LastUpdatedFrom.HasValue)
        {
            suppliersQuery = suppliersQuery
                .Where(s => s.LastUpdated >= query.LastUpdatedFrom.Value);
        }

        if (query.LastUpdatedTo.HasValue)
        {
            suppliersQuery = suppliersQuery
                .Where(s => s.LastUpdated <= query.LastUpdatedTo.Value);
        }

        suppliersQuery = suppliersQuery
            .OrderByDescending(s => s.LastUpdated);

        var pageSize = query.PageSize;
        var page = query.Page;

        int total = await suppliersQuery.CountAsync();
        List<Supplier> suppliers = await suppliersQuery
            .Skip((page - 1) * query.PageSize)
            .Take(pageSize)
            .ToListAsync();

        var pagination = new PaginatedResult<SupplierDto>(
            data: [.. suppliers.Select(SupplierDto.FromEntity)],
            totalItems: total,
            page: page,
            pageSize: pageSize
        );
        string message = total > 0 ? "Suppliers retrieved successfully." : "No suppliers found.";
        var response = ApiResponse<PaginatedResult<SupplierDto>>.Success(message, pagination);

        return Ok(response);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetSupplierDetails(int id)
    {
        var supplier = await context.Suppliers
            .Include(s => s.Country)
            .FirstOrDefaultAsync(s => s.Id == id) ?? throw new SupplierNotFoundException(id);

        var response = ApiResponse<SupplierDetailDto>.Success("Supplier details retrieved successfully.", SupplierDetailDto.FromEntity(supplier));

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSupplier(int id)
    {
        var supplier = await context.Suppliers.FindAsync(id) ?? throw new SupplierNotFoundException(id);
        context.Suppliers.Remove(supplier);
        await context.SaveChangesAsync();
        var response = ApiResponse<bool>.Success("Supplier deleted successfully.", true);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSupplier([FromBody] SupplierDto dto)
    {
        await ValidateTaxIdUniquenessAsync(dto.TaxId);
        await ValidateCountryExistsAsync(dto.CountryId);

        var response = await SaveSupplierAsync(dto);
        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSupplier(int id, [FromBody] SupplierDto dto)
    {
        await ValidateCountryExistsAsync(dto.CountryId);

        var existing = await context.Suppliers.FindAsync(id) ?? throw new SupplierNotFoundException(id);
        var response = await SaveSupplierAsync(dto, existing);
        return Ok(response);
    }

    private async Task<ApiResponse<SupplierDetailDto>> SaveSupplierAsync(SupplierDto dto, Supplier? existingSupplier = null)
    {
        Supplier supplier;
        bool isCreating = existingSupplier == null;

        if (isCreating)
        {
            supplier = new Supplier
            {
                BusinessName = dto.BusinessName,
                CommercialName = dto.CommercialName,
                TaxId = dto.TaxId,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                Website = dto.Website,
                Address = dto.Address,
                CountryId = dto.CountryId,
                AnnualRevenue = dto.AnnualRevenue,
            };
            context.Suppliers.Add(supplier);
        }
        else
        {
            supplier = existingSupplier!;
            supplier.BusinessName = dto.BusinessName;
            supplier.CommercialName = dto.CommercialName;
            supplier.TaxId = dto.TaxId;
            supplier.PhoneNumber = dto.PhoneNumber;
            supplier.Email = dto.Email;
            supplier.Website = dto.Website;
            supplier.Address = dto.Address;
            supplier.CountryId = dto.CountryId;
            supplier.AnnualRevenue = dto.AnnualRevenue;
            supplier.LastUpdated = DateTime.UtcNow;
        }

        await context.SaveChangesAsync();

        var supplierWithCountry = await context.Suppliers
            .Include(s => s.Country)
            .FirstAsync(s => s.Id == supplier.Id);

        var data = SupplierDetailDto.FromEntity(supplierWithCountry);
        string message = isCreating ? "Supplier created successfully." : "Supplier updated successfully.";

        return ApiResponse<SupplierDetailDto>.Success(message, data);
    }

    private async Task ValidateTaxIdUniquenessAsync(string taxId)
    {
        bool exists = await context.Suppliers.AnyAsync(s => s.TaxId == taxId);
        if (!exists) return;
        throw new SupplierValidationException($"A supplier with TaxId {taxId} already exists.");
    }

    private async Task ValidateCountryExistsAsync(int countryId)
    {
        bool exists = await context.Countries.AnyAsync(c => c.Id == countryId);
        if (exists) return;
        throw new SupplierValidationException("CountryId does not exist.");
    }
}