using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SnackHouse.Models
{
    public class Order
    {
        //Propriedade id não vai ser vinculada no formulário
        //[BindNever]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [Display(Name = "Nome")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Informe o sobrenome")]
        [Display(Name = "Sobrenome")]
        [StringLength(50)]
        public string CustomerSurname { get; set; }

        [Required(ErrorMessage = "Informe o endereço")]
        [Display(Name = "Endereço")]
        [StringLength(100)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Informe o complemento do endereço")]
        [Display(Name = "Complemento")]
        [StringLength(100)]
        public string AddressComplement { get; set; }

        [Required(ErrorMessage = "Informe o seu CEP")]
        [Display(Name = "CEP")]
        [StringLength(10, MinimumLength = 8)]
        public string CEP { get; set; }

        [StringLength(10)]
        public string State { get; set; }

        [StringLength(50)]
        public string City { get; set; }
        
        [Required(ErrorMessage = "Informe o seu telefone")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Informe o e-mail")]
        [StringLength(80)]
        [EmailAddress(ErrorMessage = "E-mail no formato inválido")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)] //Indica que esse campo não vai ser visível na View
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalOrder { get; set; }

        //[BindNever]
        //[ScaffoldColumn(false)] //Indica que esse campo não vai ser visível na View
        [Display(Name = "Data/Hora de envio do Pedido")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime SendDate { get; set; }


        [Display(Name = "Data/Hora da entrega do Pedido")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime? DeliveryDate { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
