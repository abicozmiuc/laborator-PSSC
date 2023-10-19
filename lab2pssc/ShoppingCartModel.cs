namespace lab2pssc.Domain
{
    public class ShoppingCartModel
    {
        public Client client { get; set; }
        public List<Model> products { get; set; }

        public ShoppingCartModel() { }
    }
}