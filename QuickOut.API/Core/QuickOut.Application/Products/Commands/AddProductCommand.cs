using System.Windows.Input;
using QuickOut.Application.Common;
using QuickOut.Domain.Products;
using QuickOut.Library;
using QuickOut.Domain.Products;
using QuickOut.Domain.Products.ValueObjects;

namespace QuickOut.Application.Products.Commands;

public class AddProductCommand : ICommand<Guid>
{
    public long BarCode { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public double Weight { get; set; }
    public string Marca { get; set; }
    public int Quantity { get; set; }
    
    public AddProductCommand(long barCode, string name, string description, double price, double weight, string marca, int quantity)
    {
        BarCode = barCode;
        Name = name;
        Description = description;
        Price = price;
        Weight = weight;
        Marca = marca;
        Quantity = quantity;
    }
}

public class AddProductCommandHandler : ICommandHandler<AddProductCommand, Guid>
{
    private readonly IProductRepository repository;
    
    public AddProductCommandHandler(IProductRepository repository)
    {
        this.repository = repository;
    }
    
    public Task<Result<Guid>> Handle(AddProductCommand request)
    {

        Result<Category> category = Category.New("Geral");
        
        
        Result<Product> createResult = Product.New(
            request.BarCode, request.Name, request.Description, request.Price, request.Quantity, category.Data);

        if (!createResult.Succeeded)
        {
            return Result<Guid>.Fail(createResult.Messages).AsTask();
        }
        
        repository.Add(createResult.Data);

        return Result<Guid>.Success(createResult.Data.Id).AsTask();
    }


}