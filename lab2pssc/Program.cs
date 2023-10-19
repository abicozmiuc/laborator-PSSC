using  lab2pssc.Domain;
using static lab2pssc.Domain.ShoppingCartChoice;

namespace lab2pssc
{
    class Program
    {
        private static string? ReadValue(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        private static List<Nevalidat> ReadListOfProducts()
        {
            List<Nevalidat> listOfProducts = new();
            string response;
            do
            {
            
                var productCode = ReadValue("Cod produs: ");
                if (string.IsNullOrEmpty(productCode))
                {
                    break;
                }

                var productQuantity = ReadValue("Cantitate: ");
                if (string.IsNullOrEmpty(productQuantity))
                {
                    break;
                }

                listOfProducts.Add(new(productCode, productQuantity));

                response = ReadValue("Doresti sa continui? (da/nu): ");

            } while (response == "da");

            return listOfProducts;
        }

        private static IShoppingCart ValidateShoppingCart(UnvalidatedShoppingCart unvalidatedShopping)
        {
            Console.WriteLine("Se valideaza!");
            return new ValidatedShoppingCart(unvalidatedShopping);

        }

        private static IShoppingCart PayShoppingCart(ValidatedShoppingCart validShoppingCart)
        {
            Console.WriteLine(" Se proceseaza. Multumim!");
            return new PaidShoppingCart(validShoppingCart, DateTime.Now);
        }
        static void Main(string[] args)
        {
            Client client = new Client()
            {
                name= "Bogdan",
                address="Emil Isac,6"
            };

            ShoppingCartModel shoppingCart = new ShoppingCartModel()
            {
                client = client,
                products=new List<Model>()
            };

            var listOfProducts = ReadListOfProducts().ToArray();
            UnvalidatedShoppingCart unvalidatedShoppingCart = new UnvalidatedShoppingCart(shoppingCart);
            IShoppingCart result = ValidateShoppingCart(unvalidatedShoppingCart);
            result.Match(
                whenEmptyShoppingCart: emptyResult => emptyResult,
                whenUnvalidatedShoppingCart: unvalidatedResult => unvalidatedShoppingCart,
                whenPaidShoppingCart: paidResult => paidResult,
                whenValidatedShoppingCart: validatedResult => PayShoppingCart(validatedResult)
                );

        }
    }
}
