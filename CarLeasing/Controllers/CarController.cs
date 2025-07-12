using CarLeasing.Models;
using CarLeasing.Services.CarService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarLeasing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarInterface _carInterface;
        public CarController(ICarInterface carInterface)
        {
            _carInterface = carInterface;
        }

        [HttpGet("list")]
        public async Task<ActionResult<ServiceResponse<List<CarModel>>>> GetCars()
        {
            return Ok(await _carInterface.GetCars());
        }

        [HttpPost("create")]
        public async Task<ActionResult<ServiceResponse<List<CarModel>>>> CreateCar(CarModel carModel)
        {
            return Ok(await _carInterface.CreateCar(carModel));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<CarModel>>> GetCarById(int id)
        {
            return Ok(await _carInterface.GetCarByID(id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<CarModel>>> DeleteCar(int id)
        {
            ServiceResponse<List<CarModel>> serviceResponse = await _carInterface.DeleteCar(id);
            return Ok(serviceResponse);
        }

        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<CarModel>>> UpdateCar(CarModel editedCar)
        {
            ServiceResponse<List<CarModel>> serviceResponse = await _carInterface.UpdateCar(editedCar);
            return Ok(serviceResponse);
        }

        [HttpPut("Inactivate")]
        public async Task<ActionResult<ServiceResponse<CarModel>>> InactivateCar(int id)
        {
            ServiceResponse<List<CarModel>> serviceResponse = await _carInterface.InactiveCar(id);
            return Ok(serviceResponse);
        }

    }
}
