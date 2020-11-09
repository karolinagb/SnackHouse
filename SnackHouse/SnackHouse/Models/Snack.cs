namespace SnackHouse.Models
{
    public class Snack
    {
        //EF Core entende que nome da classe mais Id é chave primária ou só Id
        public int Id { get; set; }
        public string Name { get; set; }
        public string SmallDescription { get; set; }
        public string LongDescription { get; set; }
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
        public string ImgThumbnailUrl { get; set; }
        public bool IsPreferSnack { get; set; }
        public bool InStock { get; set; }
        //Para EF saber que há o relacionamento entre classes, tem que haver o nome da classe mais Id
        public int CategoryId { get; set; }
        //Essa propriedade virtual define a propriedade de navegação (ele tem que saber que existe um relacionamento)
        public virtual Category Category { get; set; }
    }
}
