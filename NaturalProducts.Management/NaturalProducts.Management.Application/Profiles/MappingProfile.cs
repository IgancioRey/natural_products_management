﻿using AutoMapper;
using NaturalProducts.Management.Application.Features.Products.Commands.CreateProduct;
using NaturalProducts.Management.Application.Features.Products.Commands.DeleteProduct;
using NaturalProducts.Management.Application.Features.Products.Commands.UpdateProduct;
using NaturalProducts.Management.Application.Features.Products.Queries.GetProductsList;
using NaturalProducts.Management.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductListVm>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<Product, DeleteProductCommand>().ReverseMap();

        }
    }
}