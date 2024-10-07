using Assignmenttasks.Exceptions;
using Assignmenttasks.Model;
using Assignmenttasks.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmenttasks.MainModule
{
public class MainMenu
    {
      
        private InventoryRepository inventoryRepo;
        private ProductRepository productRepo;
        private OrderRepository orderRepo;
        private CustomerRepository customerRepo;
        private OrderDetialRepository orderDetialRepo;

        public MainMenu()
        {
            
            inventoryRepo = new InventoryRepository();
          productRepo = new ProductRepository();
           orderRepo = new OrderRepository();
            customerRepo = new CustomerRepository();
            orderDetialRepo = new OrderDetialRepository();
        }
        private const string AuthPassword = "44556";
        public void ShowMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Orders");
                Console.WriteLine("2. Order Details");
                Console.WriteLine("3. Customers");
                Console.WriteLine("4. Products");
                Console.WriteLine("5. Inventory");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowOrdersMenu();
                        break;
                    case "2":
                        ShowOrderDetailsMenu();
                        break;
                    case "3":
                        ShowCustomersMenu();
                        break;
                    case "4":
                        ShowProductsMenu();
                        break;
                    case "5":
                        ShowInventoryMenu();
                        break;
                    case "0":
                        return; // Exit the application
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void ShowOrdersMenu()
        {
            // methods related to order operations
            Console.Clear();
            Console.WriteLine("Orders Menu");
            Console.WriteLine("1. Get Order Details");
            Console.WriteLine("2. Calculatr amount");
            Console.WriteLine("3. Update Order Status");
            Console.WriteLine("4. Cancel Order");
            Console.WriteLine("0. Back to Main Menu");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    GetOrderDetails();
                    break;
                case "2":
                    CalculateTotalAmount();
                    break;
                case "3":
                    UpdateOrderStatus();
                    break;
                case "4":
                    CancelOrder();
                    break;
                case "0":
                    return; // Go back to main menu
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

     
        private void ShowOrderDetailsMenu()
        {
            //  methods related to order detail operations
            Console.Clear();
            Console.WriteLine("Order Details Menu");
            Console.WriteLine("1. Calculate sub total");
            Console.WriteLine("2. Get order details ");
            Console.WriteLine("3. Update Order Quantiy");
            Console.WriteLine("3. Add discount");
            Console.WriteLine("0. Back to Main Menu");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CalculateSubtotal();
                    break;
                case "2":
                    GetOrderDetailInfo();
                    break;
                    case "3":
                    UpdateQuantity();
                    break;
                    case "4":
                    AddDiscount();
                    break;
                case "0":
                    return; // Go back to main menu
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

      
        private void ShowCustomersMenu()
        {
            //  methods related to customer operations
            Console.Clear();
            Console.WriteLine("Customers Menu");
            Console.WriteLine("1.Get Customer Details");
            Console.WriteLine("2. Update Customer Info");
            Console.WriteLine("3. Get Total Orders");
            Console.WriteLine("0. Back to Main Menu");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    GetCustomerDetails();
                    break;
                case "2":
                    UpdateCustomerInfo();
                    break;
                case "3":
                    CalculateTotalOrders();
                    break;
                case "0":
                    return; // Go back to main menu
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

      

        private void ShowProductsMenu()
        {
            //  methods related to product operations
            Console.Clear();
            Console.WriteLine("Products Menu");
            Console.WriteLine("1. Get Product Details");
            Console.WriteLine("2. Update Product Info");
            Console.WriteLine("3. Check Availibiliy");
            Console.WriteLine("0. Back to Main Menu");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    GetProductDetails();
                    break;
                case "2":
                    UpdateProductInfo();
                    break;
                case "3":
                    IsProductInStock();
                    break;
                case "0":
                    return; // Go back to main menu
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }


        private void ShowInventoryMenu()
        {
            // methods related to inventory operations
            Console.Clear();
            Console.WriteLine("Inventory Menu");
            Console.WriteLine("1. Get Product");
            Console.WriteLine("2. Get Quantity In Stock");
            Console.WriteLine("3. Add To Inventory");
            Console.WriteLine("4. Remove From Inventory");
            Console.WriteLine("5. Update Stock Quantity");
            Console.WriteLine("6. Check Product Availability");
            Console.WriteLine("7. Get Inventory Value");
            Console.WriteLine("8. List Low Stock Products");
            Console.WriteLine("9. List Out of Stock Products");
            Console.WriteLine("0. Back to Main Menu");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    GetProduct();
                    break;
                case "2":
                    GetQuantityInStock();
                    break;
                case "3":
                    AddToInventory();
                    break;
                case "4":
                    RemoveFromInventory();
                    break;
                case "5":
                    UpdateStockQuantity();
                    break;
                case "6":
                    CheckProductAvailability();
                    break;
                case "7":
                    GetInventoryValue();
                    break;
                case "8":
                    ListLowStockProducts();
                    break;
                case "9":
                    ListOutOfStockProducts();
                    break;
                case "0":
                    return; // Go back to main menu
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        private void GetProduct()
        {
            try
            {
                Console.Write("Enter Product ID: ");
                int productId = int.Parse(Console.ReadLine());

               
                var product = inventoryRepo.GetProduct(productId);

                if (product == null)
                {
                    throw new DatabaseAccessException("Product not found in the database.");
                }

                Console.WriteLine($"Product: {product.ProductName}, Price: {product.Price}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for the Product ID.");
            }
            catch (DatabaseAccessException ex)
            {
                Console.WriteLine($"Database access error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }


        private void GetQuantityInStock()
        {
           
            Console.Write("Enter Product ID: ");
            int productId = int.Parse(Console.ReadLine());
            int quantity = inventoryRepo.GetQuantityInStock(productId);
            Console.WriteLine($"Quantity in Stock: {quantity}");
        }

        private void AddToInventory()
        {
            Console.Write("Enter Product ID: ");
            int productId = int.Parse(Console.ReadLine());
            Console.Write("Enter Quantity to Add: ");
            int quantityToAdd = int.Parse(Console.ReadLine());
            inventoryRepo.AddToInventory(productId, quantityToAdd);
            Console.WriteLine("Inventory updated successfully.");
        }

        private void RemoveFromInventory()
        {
            Console.Write("Enter Product ID: ");
            int productId = int.Parse(Console.ReadLine());
            Console.Write("Enter Quantity to Remove: ");
            int quantityToRemove = int.Parse(Console.ReadLine());
            inventoryRepo.RemoveFromInventory(productId, quantityToRemove);
            Console.WriteLine("Inventory updated successfully.");
        }

        private void UpdateStockQuantity()
        {
            Console.Write("Enter Product ID: ");
            int productId = int.Parse(Console.ReadLine());
            Console.Write("Enter New Quantity: ");
            int newQuantity = int.Parse(Console.ReadLine());
            inventoryRepo.UpdateStockQuantity(productId, newQuantity);
            Console.WriteLine("Stock quantity updated successfully.");
        }

        private void CheckProductAvailability()
        {
            // Implement Check Product Availability functionality
            Console.Write("Enter Product ID: ");
            int productId = int.Parse(Console.ReadLine());
            Console.Write("Enter Quantity to Check: ");
            int quantityToCheck = int.Parse(Console.ReadLine());
            bool isAvailable = inventoryRepo.IsProductAvailable(productId, quantityToCheck);
            Console.WriteLine(isAvailable ? "Product is available." : "Insufficient stock.");
        
    }

        private void GetInventoryValue()
        {
            // Implement Get Inventory Value functionality
            Console.WriteLine("Enter Inventory ID");
            int id=int.Parse(Console.ReadLine());
            decimal totalValue = inventoryRepo.GetInventoryValue(id);
            Console.WriteLine($"Total Inventory Value: {totalValue}");
        }

        private void ListLowStockProducts()
        {
            // Implement List Low Stock Products functionality
            Console.Write("Enter Low Stock Threshold: ");
            int threshold = int.Parse(Console.ReadLine());
            var lowStockProducts = inventoryRepo.ListLowStockProducts(threshold);
            foreach (var product in lowStockProducts)
            {
                Console.WriteLine($"Product ID: {product.ProductID}, Name: {product.ProductName}, Quantity: {product.StockQuantity}");
            }
        }

        private void ListOutOfStockProducts()
        {
            // Implement List Out of Stock Products functionality
            var outOfStockProducts = inventoryRepo.ListOutOfStockProducts();
            foreach (var product in outOfStockProducts)
            {
                Console.WriteLine($"Product ID: {product.ProductID}, Name: {product.ProductName} is out of stock.");
            }
        }
        private void CancelOrder()
        {
            Console.Write("Enter Order ID to Cancel: ");
            int orderId = int.Parse(Console.ReadLine());
            orderRepo.CancelOrder(orderId);
            Console.WriteLine("Order cancelled successfully.");
        }

       
        private void UpdateOrderStatus()
        {
            try
            {
                Console.Write("Enter Order ID: ");
                int orderId = int.Parse(Console.ReadLine());

                Console.Write("Enter New Status (Processing, Shipped, Delivered): ");
                string status = Console.ReadLine();

                // Validate status
                if (string.IsNullOrWhiteSpace(status) ||
                    (status != "Processing" && status != "Shipped" && status != "Delivered"))
                {
                    throw new IncompleteOrderException("Invalid status provided. Please enter a valid order status.");
                }

                // Attempt to update order status
                orderRepo.UpdateOrderStatus(orderId, status);
                Console.WriteLine("Order status updated successfully.");
            }
            catch (IncompleteOrderException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid Order ID.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }


        private void CalculateTotalAmount()
        {
            Console.Write("Enter Order ID: ");
            int orderId = int.Parse(Console.ReadLine());
            decimal totalAmount = orderRepo.CalculateTotalAmount(orderId);
            Console.WriteLine($"Total Amount: {totalAmount}");
        }

        private void GetOrderDetails()
        {
            Console.Write("Enter Order ID: ");
            int orderId = int.Parse(Console.ReadLine());
            (Order order, List<Product> products) = orderRepo.GetOrderDetails(orderId);

           
            Console.WriteLine($"Order ID: {order.OrderID}, Customer: {order.Customer}");

            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.ProductID}, Name: {product.ProductName}, Price: {product.Price},Product Description:{product.Description}");
            }

        }
        private void AddDiscount()
        {
            Console.Write("Enter Order Detail ID: ");
            int orderDetailId = int.Parse(Console.ReadLine());
            Console.Write("Enter Discount Amount: ");
            decimal discount = decimal.Parse(Console.ReadLine());
            orderDetialRepo.AddDiscount(orderDetailId, discount);
            Console.WriteLine("Discount added successfully.");
        }

        private void UpdateQuantity()
        {
            Console.Write("Enter Order Detail ID: ");
            int orderDetailId = int.Parse(Console.ReadLine());
            Console.Write("Enter New Quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            orderDetialRepo.UpdateQuantity(orderDetailId, quantity);
            Console.WriteLine("Quantity updated successfully.");
        }

        private void GetOrderDetailInfo()
        {
            Console.Write("Enter Order Detail ID: ");
            int orderDetailId = int.Parse(Console.ReadLine());
            var detail = orderDetialRepo.GetOrderDetailInfo(orderDetailId);
            Console.WriteLine(detail);
        }

        private void CalculateSubtotal()
        {
            Console.Write("Enter Order Detail ID: ");
            int orderDetailId = int.Parse(Console.ReadLine());
            decimal subtotal = orderDetialRepo.CalculateSubtotal(orderDetailId);
            Console.WriteLine($"Subtotal: {subtotal}");
        }

        private void CalculateTotalOrders()
        {
            int totalOrders = customerRepo.CalculateTotalOrders();
            Console.WriteLine($"Total Orders: {totalOrders}");
        }

    
        private void UpdateCustomerInfo()
        {
            try
            {
                Console.Write("Enter Authentication Password: ");
                string enteredPassword = Console.ReadLine();

                // Check if the entered password matches the defined password
                if (enteredPassword != AuthPassword)
                {
                    throw new AuthenticationException("Authentication failed: Invalid password.");
                }

                // Proceed with updating customer information
                Console.Write("Enter Customer ID: ");
                int customerId = int.Parse(Console.ReadLine());

                Console.Write("Enter New Email: ");
                string email = Console.ReadLine();

                // Validate email format
                if (!email.Contains("@"))
                {
                    throw new InvalidEmailException("Invalid email format. Please enter a valid email address.");
                }

                Console.Write("Enter New Phone: ");
                string phone = Console.ReadLine();

                Console.Write("Enter New Address: ");
                string address = Console.ReadLine();

                // Call the update method
                customerRepo.UpdateCustomerInfo(customerId, email, phone, address);
                Console.WriteLine("Details updated");
            }
            catch (AuthenticationException ex)
            {
                Console.WriteLine($"Authentication Error: {ex.Message}");
            }
            catch (InvalidEmailException ex)
            {
                Console.WriteLine($"Email Validation Error: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Input Format Error: Please ensure you enter valid data. {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }


        private void GetCustomerDetails()
        {
            Console.WriteLine("Customer List:");

            // Call the method to get a list of customer details
            List<Customer> customers = customerRepo.GetCustomerDetails();

            if (customers != null && customers.Count > 0)
            {
                foreach (Customer customer in customers)
                {
                    Console.WriteLine($"Customer ID: {customer.CustomerID}");
                    Console.WriteLine($"Name: {customer.FirstName}");
                    Console.WriteLine($"Email: {customer.Email}");
                    Console.WriteLine($"Phone: {customer.Phone}");
                    Console.WriteLine($"Address: {customer.Address}");
                    Console.WriteLine("---------------");
                }
            }
            else
            {
                Console.WriteLine("No customers found.");
            }

            Console.WriteLine("Press Enter to return to the main menu...");
            Console.ReadLine();
        }


        private void IsProductInStock()
        {
            try
            {
                Console.Write("Enter Product ID: ");
                int productId = int.Parse(Console.ReadLine());

                // Check product stock availability
                bool isAvailable = productRepo.IsProductInStock(productId);

                // If the product is not available, throw InsufficientStockException
                if (!isAvailable)
                {
                    throw new InsufficientStockException("Insufficient stock for the requested product.");
                }

                Console.WriteLine("Product is in stock.");
            }
            catch (InsufficientStockException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid Product ID.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }


        private void UpdateProductInfo()
        {
            Console.Write("Enter Product ID: ");
            int productId = int.Parse(Console.ReadLine());
            Console.Write("Enter New Price: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Enter New Description: ");
            string description = Console.ReadLine();

            // Call the update method
            bool success =productRepo.UpdateProductInfo(productId, price, description);
            Console.WriteLine(success ? "Product updated successfully." : "Product update failed.");
            Console.ReadLine();
        }

        private void GetProductDetails()
        {
            
            Console.WriteLine("Enter Product ID to view details:");
            int productId = int.Parse(Console.ReadLine());

           
            Product product = productRepo.GetProductDetails(productId);

            if (product != null)
            {
                Console.WriteLine("Product Details:");
                Console.WriteLine($"ID: {product.ProductID}");
                Console.WriteLine($"Name: {product.ProductName}");
                Console.WriteLine($"Description: {product.Description}");
                Console.WriteLine($"Price: {product.Price}");
                Console.WriteLine($"Stock Quantity: {product.StockQuantity}");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }


    }

}

