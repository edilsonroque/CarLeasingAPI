using CarLeasing.DataContext;
using CarLeasing.Models;
using Microsoft.EntityFrameworkCore;

namespace CarLeasing.Services.CarService
{
    public class CarService : ICarInterface
    {
        private readonly ApplicationDbContext _context;
        public CarService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<CarModel>>> CreateCar(CarModel newCar)
        {
            ServiceResponse<List<CarModel>> serviceResponse = new ServiceResponse<List<CarModel>>();

            try
            {
                if (newCar == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Message = "Informar dados";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }

                _context.Add(newCar);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Cars.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CarModel>>> DeleteCar(int id)
        {
            ServiceResponse<List<CarModel>> serviceResponse = new ServiceResponse<List<CarModel>>();

            try
            {
                CarModel car = _context.Cars.FirstOrDefault(x => x.Id == id);

                if (car == null)
                {
                    serviceResponse.Message = "Carro não existe na bd";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<CarModel>> GetCarByID(int id)
        {
            ServiceResponse<CarModel> serviceResponse = new ServiceResponse<CarModel>();

            try
            {
                serviceResponse.Dados = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
                if (serviceResponse.Dados == null) 
                {
                    serviceResponse.Message = "Car nao cadastrado na BD";
                    serviceResponse.Success = false;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CarModel>>> GetCars()
        {
            ServiceResponse<List<CarModel>> serviceResponse = new ServiceResponse<List<CarModel>>();

            try 
            {
                serviceResponse.Dados = _context.Cars.ToList();
                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Message = "Sem dados";
                }

            } catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }


            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CarModel>>> InactiveCar(int id)
        {
            ServiceResponse<List<CarModel>> serviceResponse = new ServiceResponse<List<CarModel>>();

            try
            {
                CarModel car = _context.Cars.FirstOrDefault(x => x.Id == id);

                if (car == null)
                {
                    serviceResponse.Message = "Carro nao existe na BD";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                else if (car.Active == false)
                {
                    serviceResponse.Message = "Carro ja se encontra inativo";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                car.Active = false;

                _context.Cars.Update(car);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Cars.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<CarModel>>> UpdateCar(CarModel editedCar)
        {
            ServiceResponse<List<CarModel>> serviceResponse = new ServiceResponse<List<CarModel>>();

            try
            {
                CarModel car = _context.Cars.AsNoTracking().FirstOrDefault(x => x.Id == editedCar.Id);

                if (car == null)
                {
                    serviceResponse.Message = "Carro não existe na BD";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                _context.Cars.Update(editedCar);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Cars.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }
    }
}
