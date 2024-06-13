﻿namespace Contracts.DataTransferObjects;
public class Product : Entity
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
};
