using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Products.Querries.GetProductDetails;
using Store.Application.Products.Querries.GetProductList;
using Store.Application.Products.Commands.DeleteProductCommand;
using Store.Application.Products.Commands.UpdateProductCommand;
using Store.WebAPI.Models;
using Store.Application.Products.Commands.AddProductCommand;

namespace Store.WebAPI.Controllers;


[Route("[controller]")]
public class ProductController(IMapper mapper) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<ProductsListViewModel>> GetAll(int countSkipProducts, int countTakeProducts)
    {
        var createGroupCommand = new GetProductListQuery
        {
            SkipProductsCount = countSkipProducts,
            TakeProductsCount = countTakeProducts
        };

        var view = await Mediator.Send(createGroupCommand);
        return Ok(view);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductViewModel>> Get(int id)
    {
        var query = new GetProductDetailsQuery
        {
            Id = id
        };

        var view = await Mediator.Send(query);
        return Ok(view);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateProductDTO createNoteDto)
    {
        var command = mapper.Map<AddProductCommand>(createNoteDto);
        var itemId = await Mediator.Send(command);
        return Ok(itemId);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductDTO updateNoteDto)
    {
        var command = mapper.Map<UpdateProductCommand>(updateNoteDto);
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteProductCommand
        {
            Id = id,
        };
        await Mediator.Send(command);
        return NoContent();
    }
}