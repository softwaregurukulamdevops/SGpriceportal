using Microsoft.AspNetCore.Mvc;
using PricePortel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PricePortel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : Controller
    {
        public readonly TrainingDBContext trainingDBContext;
        public PriceController(TrainingDBContext _trainingDBContext)
        {
            trainingDBContext = _trainingDBContext;
        }
        [HttpGet("GetPriceDetails")]
        public List<Price> GetPriceDetails()
        {
            List<Price> lstPrice = new List<Price>();
            try
            {
                lstPrice = trainingDBContext.Price.ToList();
                return lstPrice;
            }
            catch (Exception ex)
            {
                lstPrice = new List<Price>();
                return lstPrice;
            }
        }
        [HttpPost("AddPrice")]
        public string AddPrice(Price price)
        {
            string message = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(price.PriceName))
                {
                    trainingDBContext.Add(price);
                    trainingDBContext.SaveChanges();
                    message = "Price added successfully";
                }
                else
                    message = "Price Name required.";

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return message;
        }
    }
}
