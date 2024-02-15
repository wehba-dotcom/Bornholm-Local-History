using AutoMapper;
using ProductApi.Models;
using ProductApi.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using productApi.Data;


namespace ProductApi.Controllers
{
    [Route("api/fastningbook")]
    [ApiController]
    //[Authorize]
    public class FastningBookController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public FastningBookController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<FastningBook> objList = _db.FastningBooks.ToList();
                _response.Result = _mapper.Map<IEnumerable<FastningBookDto>>(objList);
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
                FastningBook obj = _db.FastningBooks.First(u=>u.ID==id);
                _response.Result = _mapper.Map<FastningBookDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

       

        [HttpPost]
        //[Authorize(Roles = "ADMIN")]
        public ResponseDto Post([FromBody] FastningBookDto couponDto)
        {
            try
            {
                FastningBook obj = _mapper.Map<FastningBook>(couponDto);
                _db.FastningBooks.Add(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<FastningBookDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpPut]
        //[Authorize(Roles = "ADMIN")]
        public ResponseDto Put([FromBody] FastningBookDto fastningbookDto)
        {
            try
            {
                FastningBook obj = _mapper.Map<FastningBook>(fastningbookDto);
                _db.FastningBooks.Update(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<FastningBookDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id:int}")]
        //[Authorize(Roles = "ADMIN")]
        public ResponseDto Delete(int id)
        {
            try
            {
                FastningBook obj = _db.FastningBooks.First(u=>u.ID==id);
                _db.FastningBooks.Remove(obj);
                _db.SaveChanges();


                //var service = new Stripe.CouponService();
                //service.Delete(obj.CouponCode);


            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
