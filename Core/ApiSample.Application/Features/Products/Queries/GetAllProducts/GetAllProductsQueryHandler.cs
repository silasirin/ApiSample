using ApiSample.Application.DTOs;
using ApiSample.Application.Interfaces.AutoMapper;
using ApiSample.Application.Interfaces.UnitOfWorks;
using ApiSample.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, IList<GetAllProductsQueryResponse>>
    {
        private readonly IUnitOfWork unitOfWork;
        //Automapperdan sonra yazılan alan
        private readonly IMapper mapper;

        //Automapperdan önce yapılan alan:
        //public GetAllProductsQueryHandler(IUnitOfWork unitOfWork)
        //{
        //    this.unitOfWork = unitOfWork;
        //}

        //Automapperdan sonra yazılan alan
        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            //Automapperdan önce yapılan alan:
            //var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();

            //Automapperdan sonra yapılan alan:
            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync(include :x => x.Include(b=>b.Brand));

            var brand = mapper.Map<BrandDto, Brand>(new Brand());

            //IList new'lenemez bu nedenle List türünden oluşturuyoruz. --> Interface'ler new'lenemez!
            //Automapperdan önce yapılan alan:
            //List<GetAllProductsQueryResponse> response = new();

            //Automapperdan önce yapılan alan:
            //foreach (var product in products)
            //{
            //    response.Add(new GetAllProductsQueryResponse
            //    {
            //        Title = product.Title,
            //        Description = product.Description,
            //        Discount = product.Discount,
            //        Price = product.Price = (product.Price * product.Discount / 100)
            //    });
            //}

            //Automapperdan sonra yazılan alan
            var map = mapper.Map<GetAllProductsQueryResponse, Product>(products);
            foreach (var item in map)
                item.Price -= (item.Price * item.Discount / 100);
            return map;

            //Automapperdan önce yapılan alan:
            //return response;
        }
    }
}
