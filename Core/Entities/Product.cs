namespace Core.Entities
{
    public class Product : BaseEntity
    {
        // public int Id { get; set; } -> removed due to deriving class Product from class BaseEntity 
        public string Name{ get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public int ProductBrandId { get; set; }
    }
}