using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Market.API.ViewModels.Request.StreetFair
{
    public class StreetFairRegisterRequestViewModel
    {
        /// <summary>
        ///     Register
        /// </summary>
        [FromRoute(Name = "register")]
        [Required]
        public string Register { get; set; }
    }
}
