using VendingMachine_RestAPI_Domain;
using VendingMachine_RestAPI_Logic.Abstaction;
using VendingMachine_RestAPI_Logic.APIModels;
using VendingMachine_RestAPI_Logic.APIModels.Request;

namespace VendingMachine_RestAPI_Logic
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository?? throw new ArgumentNullException(nameof(_repository));
        }

        public async Task<int> CreateProduct(CreateOrUpdateProductRequest request)
        {
            var product = Mapper.CreateOrUpdateProductDTOToProductDbModel(request);

            await _repository.Add(product);
            return product.Id;
        }

        public async Task DeleteProduct(int productId)
        {
            await _repository.Delete(productId);
        }

        public async Task<ProductDTO> GetProductById(int productId)
        {
            var resultFromRepo = await _repository.Get(productId);

            var result = Mapper.ProductDbModelToProductDTO(resultFromRepo);

            return result;
        }

        public async Task<List<ProductDTO>> GetProducts()
        {
            var results = new List<ProductDTO>();
            var resultsFromRepo = await _repository.GetAll();

            resultsFromRepo.ForEach(x => results.Add(Mapper.ProductDbModelToProductDTO(x)));

            return results;
        }

        public async Task UpdateProduct(int productId, CreateOrUpdateProductRequest request)
        {
            var product = Mapper.CreateOrUpdateProductDTOToProductDbModel(request);

            await _repository.Update(productId, product);
        }
    }
}