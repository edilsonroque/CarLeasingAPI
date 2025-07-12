using CarLeasing.Models;

namespace CarLeasing.Services.CarService
{
    public interface ICarInterface
    {
        Task<ServiceResponse<List<CarModel>>> GetCars();
        Task<ServiceResponse<List<CarModel>>> CreateCar(CarModel newCar);
        Task<ServiceResponse<CarModel>> GetCarByID(int id);
        Task<ServiceResponse<List<CarModel>>> UpdateCar(CarModel carModel);
        Task<ServiceResponse<List<CarModel>>> DeleteCar(int id);
        Task<ServiceResponse<List<CarModel>>> InactiveCar(int id);
    }
}
