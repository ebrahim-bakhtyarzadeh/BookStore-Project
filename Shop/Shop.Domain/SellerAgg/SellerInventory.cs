﻿using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.SellerAgg;

public class SellerInventory : BaseEntity
{
    public long SellerId { get; internal set; }
    public long ProductId { get; private set; }
    public int Count { get; private set; }
    public int Price { get; private set; }

    public SellerInventory(long sellerId, long productId, int count, int price)
    {
        if (price < 1 || count < 0)
            throw new InvalidDomainDataException("In Seller Inventory ctor , price or count is not valid !");

        SellerId = sellerId;
        ProductId = productId;
        Count = count;
        Price = price;
    }
}