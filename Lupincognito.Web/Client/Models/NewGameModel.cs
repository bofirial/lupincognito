using System.ComponentModel.DataAnnotations;

namespace Lupincognito.Web.Client.Models
{
    public class NewGameModel
    {
        [Required]
        [StringLength(25, ErrorMessage = "Game Name must be less than 25 characters.")]
        public string GameName { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Player Name must be less than 25 characters.")]
        public string PlayerName { get; set; }
    }
}
