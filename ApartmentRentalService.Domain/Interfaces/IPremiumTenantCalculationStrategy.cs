﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentRentalService.Domain.Interfaces
{
    public interface IPremiumTenantCalculationStrategy
    {
        bool IsPremium(int tenantId);
    }
}
