using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product) => _products.Add(product);

    public double CalculateTotalCost()
    {
        double total = 0;
        foreach (var product in _products)
            total += product.GetTotalCost();
        
        return total + (_customer.IsInUSA() ? 5 : 35);
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in _products)
            label += $"- {product.GetPackingInfo()}\n";
        return label;
    }

    public string GetShippingLabel() => $"Shipping Label:\n{_customer.GetShippingLabel()}";
}