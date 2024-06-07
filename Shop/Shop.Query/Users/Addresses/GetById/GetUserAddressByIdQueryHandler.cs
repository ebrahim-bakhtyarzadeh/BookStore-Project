﻿using Common.Query;
using Dapper;
using Shop.Infrastructure.Persistent.Dapper;
using Shop.Query.Users.Addresses.DTOs;

namespace Shop.Query.Users.Addresses.GetById;

public class GetUserAddressByIdQueryHandler : IQueryHandler<GetUserAddressByIdQuery, AddressDto?>
{
    private readonly DapperContext _dapperContext;

    public GetUserAddressByIdQueryHandler(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }
    public async Task<AddressDto?> Handle(GetUserAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var sql = $"SELECT top 1 * from {_dapperContext.UserAddresses} where id=@id";
        using var context = _dapperContext.CreateConnection();
        return await context.QueryFirstOrDefaultAsync<AddressDto>(sql, new { id = request.addressId });


    }
}