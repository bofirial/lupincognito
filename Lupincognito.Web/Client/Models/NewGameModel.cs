using System.ComponentModel.DataAnnotations;

namespace Lupincognito.Web.Client.Models
{
    public class NewGameModel
    {
        [Required]
        [StringLength(25, ErrorMessage = "Name must be less than 25 characters.")]
        public string Name { get; set; }
    }
}
