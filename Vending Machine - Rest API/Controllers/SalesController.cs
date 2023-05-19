using Microsoft.AspNetCore.Mvc;
using VendingMachine_RestAPI_Domain;
using VendingMachine_RestAPI_Logic;
using VendingMachine_RestAPI_Logic.Abstaction;
using VendingMachine_RestAPI_Logic.APIModels.Request;

namespace Vending_Machine___Rest_API.Controllers
{ 
    [ApiController]
    [Route("api/sale")]

    public class SalesController:ControllerBase
    {
       private readonly ISaleService _saleService;
        public SalesController(ISaleService saleService)
        {
            _saleService = saleService??throw new ArgumentNullException(nameof(_saleService));
        }

        [HttpGet]
        public async Task<ActionResult<List<Sale>>> GetAllSales()
        {
            var sales = await _saleService.GetSales();

            return Ok(sales);
        }

        [HttpPost]
        public async Task<IActionResult> AddSale(CreateOrUpdateSaleRequest request)
        {
            await _saleService.Add(request);
            return Ok();
        }


    }
}
