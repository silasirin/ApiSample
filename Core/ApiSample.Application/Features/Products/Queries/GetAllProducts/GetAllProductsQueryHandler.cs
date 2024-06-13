using ApiSample.Application.Interfaces.UnitOfWorks;
using ApiSample.Domain.Entities;
using MediatR;
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
        public GetAllProductsQueryHandler(IUnitOfWork unitOfWork)
        {
                this.unitOfWork = unitOfWork;
        }
        public async Task<IList<GetAllProductsQueryResponse>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await unitOfWork.GetReadRepository<Product>().GetAllAsync();

            //IList new'lenemez bu nedenle List türünden oluşturuyoruz. --> Interface'ler new'lenemez!
            List<GetAllProductsQueryResponse> response = new();

            foreach (var product in products)
            {
                response.Add(new GetAllProductsQueryResponse
                {
                    Title = product.Title,
                    Description = product.Description,
                    Discount = product.Discount,
                    Price = product.Price = (product.Price * product.Discount / 100)
                });
            }

            return response;
        }
    }
}
