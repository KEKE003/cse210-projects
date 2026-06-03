using System.Text;

namespace OnlineOrdering
{
    public class Order
    {
        private List<Product> _products;
        private Customer _customer;

        public Order (Customer customer)
        {
            _customer = customer;
            _products = new List<Product>();
        }

        public void AddProduct (Product product)
        {
            _products.Add(product);
        }

        public double CalculateTotalOrderCost()
        {
            double total = 0;
        
            foreach (Product product in _products)
            {
                total += product.CalculateTotalCost();
            }

            double ShippingCost = _customer.LivesInUsa() ? 5.00 : 35.00;
            total += ShippingCost;
            return total;
        }

            public string GetPackingLabel()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("--- PACKING LABEL ---");

                foreach (Product product in _products)
                {
                    sb.AppendLine($"Product : {product.GetName()} (ID : {product.GetProductId()})");
                }

                return sb.ToString();
            }

            public string GetShippingLabel()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("--- SHIPPING LABEL ---");

                sb.AppendLine(_customer.GetName());
                sb.AppendLine(_customer.GetFullAddressString());
                return sb.ToString();
            }
        }
    }

