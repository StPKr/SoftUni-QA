using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GardenConsoleAPI.Common;

namespace GardenConsoleAPI.Data.Models
{
    public class Plant
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [RegularExpression(ValidationConstants.CatalogNumberFormat)]
        public string CatalogNumber { get; set; }

        [Required]
        [MaxLength(ValidationConstants.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ValidationConstants.TypeMaxLength)]
        public string PlantType { get; set; }

        [Required]
        [MaxLength(ValidationConstants.TypeMaxLength)]
        public string FoodType { get; set; }

        [Required]
        [Range(ValidationConstants.QuantityMinValue, ValidationConstants.QuantityMaxValue)]
        public int Quantity { get; set; }

        [Required]
        public bool IsEdible { get; set; }
    }
}
