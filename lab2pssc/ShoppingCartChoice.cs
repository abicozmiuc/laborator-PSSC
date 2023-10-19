using CSharp.Choices;
using static lab2pssc.Domain.ShoppingCartChoice;

namespace lab2pssc.Domain
{
	[AsChoice]
	public static partial class ShoppingCartChoice
	{
		public interface IShoppingCart { }
		public record UnvalidatedShoppingCart(ShoppingCartModel shoppingCart) : IShoppingCart;
		public record EmptyShoppingCart(ShoppingCartModel shoppingCartVar) : IShoppingCart;
		public record ValidatedShoppingCart(UnvalidatedShoppingCart unvalidatedShoppingCart) : IShoppingCart;
		public record PaidShoppingCart(ValidatedShoppingCart validatedShoppingCart, DateTime payDate) : IShoppingCart;
	}
}