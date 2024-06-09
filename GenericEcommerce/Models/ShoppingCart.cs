using GenericEcommerce.Context;
using Microsoft.EntityFrameworkCore;

namespace GenericEcommerce.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext _context;

        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public string? ShoppingCartId { get; set; }
        public IList<ItemShoppingCart>? Items { get; set; }

        #region Métodos
        public static ShoppingCart GetCart(IServiceProvider service)
        {
            //Define uma sessão.
            var session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //Obtem serviço do tipo tipo da minha sessão.
            var context = service.GetService<AppDbContext>();

            //Obtem ou gera o id do carrinho.
            var cartId = session.GetString("ShoppingCartId") ?? Guid.NewGuid().ToString();

            //Atribui o id do carrinho na sessão.
            session.SetString("ShoppingCartId", cartId);

            //Retorna o carrinho com o contexto e o id atribuido ou obtido.
            return new ShoppingCart(context)
            {
                ShoppingCartId = cartId
            };
        }

        public IList<ItemShoppingCart> GetItemsToCart()
        {
            return Items ?? (Items = 
                _context.ItemsShoppingCart
                .Where(x => x.ShoppingCartId == ShoppingCartId)
                .Include(x => x.Game)
                .ToList());
        }


        public void AddItemToCart(Game game)
        {
            var item = _context.ItemsShoppingCart.Where(
                    x => x.Game != null && x.Game.GameId == game.GameId
                    && x.ShoppingCartId == ShoppingCartId
                ).SingleOrDefault();

            if (item == null)
            {
                item = new ItemShoppingCart()
                {
                    ShoppingCartId = ShoppingCartId,
                    Game = game,
                    Quantity = 1
                };

                _context.ItemsShoppingCart.Add(item);
            }
            else
            {
                item.Quantity++;
            }

            _context.SaveChanges();
        }

        public void RemoveItemToCart(Game game)
        {
            var item = _context.ItemsShoppingCart.SingleOrDefault(
                    x => x.Game != null && x.Game.GameId == game.GameId
                    && x.ShoppingCartId == ShoppingCartId
                );

            if (item != null)
            {
                if (item.Quantity > 1)
                {
                    item.Quantity--;
                }
                else
                {
                    _context.ItemsShoppingCart.Remove(item);
                }
            }

            _context.SaveChanges();
        }

        public void CleanCart()
        {
            var items = _context.ItemsShoppingCart.Where(x => x.ShoppingCartId == ShoppingCartId);

            if(items != null)
            {
                _context.ItemsShoppingCart.RemoveRange(items);
                _context.SaveChanges();
            }
        }

        public decimal GetShoppingCartTotal()
        {
            var total =  _context.ItemsShoppingCart
                             .Where(x => x.ShoppingCartId == ShoppingCartId && x.Game != null)
                             .Select(x => x.Game.Price * x.Quantity)
                             .Sum();
            return total;
        }

        public int GetShoppingCartQuantityItemsl()
        {
            var total = _context.ItemsShoppingCart
                             .Where(x => x.ShoppingCartId == ShoppingCartId && x.Game != null)
                             .Select(x => x.Quantity)
                             .Sum();
            return total;
        }
        #endregion
    }

}
