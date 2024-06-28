using System.ComponentModel.DataAnnotations;

namespace IMS.WebApp.ViewModels
{
    public class ProduceViewModel
    {
        [Required]
        public string ProductionNumber { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "You have to select an Product.")]
        public int ProductId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity has to be greater or equal to 1.")]
        public int QuantityToProduce { get; set; }
    }
}
