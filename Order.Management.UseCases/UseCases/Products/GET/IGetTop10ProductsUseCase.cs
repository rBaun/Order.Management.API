﻿using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Domain.Models;
using OrderManagement.Domain.Wrappers.Common;

namespace OrderManagement.Application.UseCases.Products.GET
{
    public interface IGetTop10ProductsUseCase
    {
        Task<Response<List<Product>>> Execute();
    }
}