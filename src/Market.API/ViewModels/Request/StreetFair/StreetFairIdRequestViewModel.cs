using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.ViewModels.Request.StreetFair
{
    public class StreetFairIdRequestViewModel
    {
        /// <summary>
        ///     Id
        /// </summary>
        [FromRoute(Name = "id")]
        [Required]
        public int Id { get; set; }
    }
}
