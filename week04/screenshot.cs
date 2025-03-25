namespace OnlineOrdering
{
    public class Order
    {
        private Customer _customer;
        private List<Product> _products;

        public Order(Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        } 

    
        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public double CalculateTotal()
        {
            double totalCost = 0;

            foreach (var product in _products)
            {
                 totalCost += product.GetTotalCost();
            }

            double shippingCost = _customer.InHaiti() ? 5 : 35;
            totalCost += shippingCost;

            return totalCost;
         }
         public string GetPackingLabel()
         {
             List<string> labels = new List<string>();
             foreach (var product in _products)
             {
                 labels.Add($" {product.GetProductId()}          {product.GetName()}   ${product.GetTotalCost():0.00}");
             }

             return string.Join("\n", labels);
         }

        public string GetShippingLabel()
         {
            var address = _customer.GetAddress();
            return $"{_customer.GetName()}\n{address.GetFullAddress()}";
         }

    } 
}
