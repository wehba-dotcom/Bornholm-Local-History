using AutoMapper;
using ProductApi.Models;
using ProductApi.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Data;


namespace ProductApi.Controllers
{
    [Route("api/product")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;
        private readonly IRepository<Product> _repository;

        public ProductController( IRepository<Product> repository)
        {
            //_db = db;
            //_mapper = mapper;
            _response = new ResponseDto();
            _repository = repository;
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Product> objList = _repository.GetAll();
                _response.Result = objList;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Product obj = _repository.Get(id);
                _response.Result = obj;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

       

        //[HttpPost]
        ////[Authorize(Roles = "ADMIN")]
        //public ResponseDto Post([FromBody] ProductDto couponDto)
        //{
        //    try
        //    {
        //        Product obj = _mapper.Map<Product>(couponDto);
        //        _db.Products.Add(obj);
        //        _db.SaveChanges();
        //        _response.Result = _mapper.Map<ProductDto>(obj);
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsSuccess = false;
        //        _response.Message = ex.Message;
        //    }
        //    return _response;
        //}


        //[HttpPut]
        ////[Authorize(Roles = "ADMIN")]
        //public ResponseDto Put([FromBody] ProductDto fastningbookDto)
        //{
        //    try
        //    {
        //        Product obj = _mapper.Map<Product>(fastningbookDto);
        //        _db.Products.Update(obj);
        //        _db.SaveChanges();

        //        _response.Result = _mapper.Map<ProductDto>(obj);
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsSuccess = false;
        //        _response.Message = ex.Message;
        //    }
        //    return _response;
        //}

        //[HttpDelete]
        //[Route("{id:int}")]
        ////[Authorize(Roles = "ADMIN")]
        //public ResponseDto Delete(int id)
        //{
        //    try
        //    {
        //        Product obj = _db.Products.First(u=>u.ID==id);
        //        _db.Products.Remove(obj);
        //        _db.SaveChanges();


        //        //var service = new Stripe.CouponService();
        //        //service.Delete(obj.CouponCode);


        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsSuccess = false;
        //        _response.Message = ex.Message;
        //    }
        //    return _response;
        //}
    }
}
