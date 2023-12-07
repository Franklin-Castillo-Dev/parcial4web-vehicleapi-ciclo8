using System;
using System.Collections.Generic;

namespace VehiclesApi.Models;

public partial class Vehicle
{
    public long Id { get; set; }

    public string Manufacturer { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string Year { get; set; } = null!;

    public decimal Price { get; set; }

    public bool Reserved { get; set; }
}
