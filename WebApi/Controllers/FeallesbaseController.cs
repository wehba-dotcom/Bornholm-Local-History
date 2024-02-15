
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApi.SharedModels;
using WebApi.Service.IService;
using WebApi.Models;


namespace WebApi.Controllers
{



    public class FeallesbaseController : Controller
    {


        //    private readonly IHttpClientFactory _httpClientFactory;
        //    public FeallesbaseController(IHttpClientFactory httpClientFactory)
        //    {
        //        _httpClientFactory = httpClientFactory;
        //    }



        //    public async Task<IActionResult> Index(string? Fornavne, DateTime? DoedDato, int pg)
        //    {
        //        var client = _httpClientFactory.CreateClient("MyClient");


        //        var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7128/Feallesbase");

        //        var response = await client.SendAsync(request);

        //        var result = await response.Content.ReadAsStringAsync();

        //        if (!response.IsSuccessStatusCode)
        //        {
        //            ViewBag.Alert = $"Noget er galt! Grunden: {response.ReasonPhrase}";
        //            return View();
        //        }

        //        // var feallesbaseobj = JsonConvert.DeserializeObject<Feallesbase>(result);
        //        List<Feallesbase>? convert = JsonConvert.DeserializeObject<List<Feallesbase>>(result) as List<Feallesbase>;

        //        //var convertlist = convert.ToList();
        //        if (!String.IsNullOrEmpty(Fornavne) && DoedDato != null)
        //        {
        //            convert = (List<Feallesbase>)convert.Where(b => b.Fornavne.Contains(Fornavne) && b.Doedsdato == DoedDato);

        //        }
        //        else if (String.IsNullOrEmpty(Fornavne) && DoedDato != null)
        //        {
        //            convert = (List<Feallesbase>)convert.Where(b => b.Doedsdato == DoedDato);
        //        }
        //        else if (!String.IsNullOrEmpty(Fornavne) && DoedDato == null)
        //        {
        //            convert = (List<Feallesbase>)convert.Where(b => b.Fornavne.Contains(Fornavne));
        //        }

        //        const int pageSize = 10;
        //        if (pg < 1)
        //        {
        //            pg = 1;
        //        }
        //        int recsCount = convert.Count();
        //        var pager = new WebApi.Models.Pager(recsCount, pg, pageSize);
        //        int resSkip = (pg - 1) * pageSize;
        //        var data = convert.Skip(resSkip).Take(pager.PageSize).ToList();

        //        //var data = objLists.ToList();
        //        this.ViewBag.Pager = pager;

        //        return View(data);

        //    }

        //    public IActionResult Create()
        //    {
        //        return View();
        //    }


        //    [HttpPost]
        //    public async Task<IActionResult> Create(Feallesbase feallesbase)
        //    {
        //        try
        //        {
        //            using (var client = _httpClientFactory.CreateClient("MyClient"))
        //            {
        //                // Serialize the Feallesbase object and send it in the request body
        //                var content = new StringContent(JsonConvert.SerializeObject(feallesbase), Encoding.UTF8, "application/json");

        //                // Use Uri.EscapeUriString to ensure proper URL encoding
        //                var request = new HttpRequestMessage(HttpMethod.Post, $"https://localhost:7128/Feallesbase")
        //                {
        //                    Content = content
        //                };

        //                var response = await client.SendAsync(request);

        //                response.EnsureSuccessStatusCode(); // Ensure a successful response (status code 2xx)

        //                TempData["success"] = "En annonccer tilføjet successfully";
        //                return RedirectToAction("Index");
        //            }
        //        }
        //        catch (HttpRequestException ex)
        //        {
        //            // Log the exception or handle it appropriately
        //            ViewBag.Alert = $"Noget er galt! Grunden: {ex.Message}";
        //            return View();
        //        }
        //    }


        //    [HttpGet]
        //    public async Task<IActionResult> Update(Feallesbase feallesbase)
        //    {
        //        try
        //        {
        //            using (var client = _httpClientFactory.CreateClient("MyClient"))
        //            {
        //                // Serialize the Feallesbase object and send it in the request body
        //                var content = new StringContent(JsonConvert.SerializeObject(feallesbase), Encoding.UTF8, "application/json");

        //                // Use Uri.EscapeUriString to ensure proper URL encoding
        //                var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7128/Feallesbase/{feallesbase.ID}")
        //                {
        //                    Content = content
        //                };

        //                var response = await client.SendAsync(request);


        //                if (response.IsSuccessStatusCode)
        //                {
        //                    var result = await response.Content.ReadAsStringAsync();
        //                    var feallesbaseobj = JsonConvert.DeserializeObject<Feallesbase>(result);

        //                    TempData["success"] = "Annoncen er taked successfully";
        //                    return View(feallesbaseobj);
        //                }
        //                else if (response.StatusCode == HttpStatusCode.NotFound)
        //                {
        //                    // Handle not found case
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    // Handle other error cases
        //                    ViewBag.Alert = $"Noget er galt! Status Code: {response.StatusCode}";
        //                    return View("Index");
        //                }
        //            }
        //        }
        //        catch (HttpRequestException ex)
        //        {
        //            // Log the exception or handle it appropriately
        //            ViewBag.Alert = $"Noget er galt! Grunden: {ex.Message}";
        //            return View("Index");
        //        }
        //    }


        //    [HttpPost]
        //    public async Task<IActionResult> Index1(Feallesbase feallesbase)
        //    {
        //        try
        //        {

        //            using (var client = _httpClientFactory.CreateClient("MyClient"))
        //            {
        //                // Serialize the Feallesbase object and send it in the request body
        //                var content = new StringContent(JsonConvert.SerializeObject(feallesbase), Encoding.UTF8, "application/json");

        //                // Use Uri.EscapeUriString to ensure proper URL encoding
        //                var request = new HttpRequestMessage(HttpMethod.Put, $"https://localhost:7128/Feallesbase/{feallesbase.ID}")
        //                {
        //                    Content = content
        //                };

        //                var response = await client.SendAsync(request);
        //                if (response.IsSuccessStatusCode)
        //                {
        //                    //var result = await response.Content.ReadAsStringAsync();
        //                    //var feallesbaseobj = JsonConvert.DeserializeObject<Feallesbase>(result);
        //                    response.EnsureSuccessStatusCode();
        //                    TempData["success"] = "Annoncen er opdateret successfully";
        //                    return RedirectToAction("Index");
        //                }
        //                else if (response.StatusCode == HttpStatusCode.NotFound)
        //                {
        //                    // Handle not found case
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    // Handle other error cases
        //                    ViewBag.Alert = $"Noget er galt! Status Code: {response.StatusCode}";
        //                    return View("Index");
        //                }
        //            }
        //        }
        //        catch (HttpRequestException ex)
        //        {
        //            // Log the exception or handle it appropriately
        //            ViewBag.Alert = $"Noget er galt! Grunden: {ex.Message}";
        //            return View("Index");
        //        }
        //    }


        //    [HttpGet]
        //    public async Task<IActionResult> Delete(Feallesbase feallesbase)
        //    {
        //        try
        //        {
        //            using (var client = _httpClientFactory.CreateClient("MyClient"))
        //            {
        //                // Serialize the Feallesbase object and send it in the request body
        //                var content = new StringContent(JsonConvert.SerializeObject(feallesbase), Encoding.UTF8, "application/json");

        //                // Use Uri.EscapeUriString to ensure proper URL encoding
        //                var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:7128/Feallesbase/{feallesbase.ID}")
        //                {
        //                    Content = content
        //                };

        //                var response = await client.SendAsync(request);


        //                if (response.IsSuccessStatusCode)
        //                {
        //                    var result = await response.Content.ReadAsStringAsync();
        //                    var feallesbaseobj = JsonConvert.DeserializeObject<Feallesbase>(result);

        //                    TempData["success"] = "Annoncen er taked successfully";
        //                    return View(feallesbaseobj);
        //                }
        //                else if (response.StatusCode == HttpStatusCode.NotFound)
        //                {
        //                    // Handle not found case
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    // Handle other error cases
        //                    ViewBag.Alert = $"Noget er galt! Status Code: {response.StatusCode}";
        //                    return View("Index");
        //                }
        //            }
        //        }
        //        catch (HttpRequestException ex)
        //        {
        //            // Log the exception or handle it appropriately
        //            ViewBag.Alert = $"Noget er galt! Grunden: {ex.Message}";
        //            return View("Index");
        //        }
        //    }




        //    [HttpPost]
        //    public async Task<IActionResult> Index2(Feallesbase feallesbase)
        //    {

        //        try
        //        {

        //            using (var client = _httpClientFactory.CreateClient("MyClient"))
        //            {
        //                // Serialize the Feallesbase object and send it in the request body
        //                var content = new StringContent(JsonConvert.SerializeObject(feallesbase), Encoding.UTF8, "application/json");

        //                // Use Uri.EscapeUriString to ensure proper URL encoding
        //                var request = new HttpRequestMessage(HttpMethod.Delete, $"https://localhost:7128/Feallesbase/{feallesbase.ID}")
        //                {
        //                    Content = content
        //                };

        //                var response = await client.SendAsync(request);
        //                if (response.IsSuccessStatusCode)
        //                {
        //                    //var result = await response.Content.ReadAsStringAsync();
        //                    //var feallesbaseobj = JsonConvert.DeserializeObject<Feallesbase>(result);
        //                    response.EnsureSuccessStatusCode();
        //                    TempData["success"] = "Annoncen er sletet successfully";
        //                    return RedirectToAction("Index");
        //                }
        //                else if (response.StatusCode == HttpStatusCode.NotFound)
        //                {
        //                    // Handle not found case
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    // Handle other error cases
        //                    ViewBag.Alert = $"Noget er galt! Status Code: {response.StatusCode}";
        //                    return View("Index");
        //                }
        //            }
        //        }
        //        catch (HttpRequestException ex)
        //        {
        //            // Log the exception or handle it appropriately
        //            ViewBag.Alert = $"Noget er galt! Grunden: {ex.Message}";
        //            return View("Index");
        //        }
        //    }
        //}



        private readonly IFeallesService _feallesService;
        public FeallesbaseController(IFeallesService feallesService)
        {
            _feallesService = feallesService;
        }


        public async Task<IActionResult> Index(int pg)
        {
            List<Feallesbase>? list = new();

            ResponseDto? response = await _feallesService.GetAllFeallesesAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<Feallesbase>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

          
            const int pageSize = 10;
            if (pg < 1)
            {
                pg = 1;
            }
            int recsCount = list.Count();
            var pager = new WebApi.Models.Pager(recsCount, pg, pageSize);
            int resSkip = (pg - 1) * pageSize;
            var data = list.Skip(resSkip).Take(pager.PageSize);

            //var data = objLists.ToList();
            this.ViewBag.Pager = pager;

            return View(data);
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }
      
        [HttpPost]
        public async Task<IActionResult> Create(Feallesbase model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _feallesService.CreateFeallesAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Coupon created successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(model);
        }


        public async Task<IActionResult> FeallesEdit(int ID)
        {
            ResponseDto? response = await _feallesService.GetFeallesByIdAsync(ID);

            if (response != null && response.IsSuccess)
            {
                Feallesbase? model = JsonConvert.DeserializeObject<Feallesbase>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> FeallesEdit(Feallesbase feallesbase)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _feallesService.UpdateFeallesAsync(feallesbase);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Product updated successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }
            return View(feallesbase);
        }

        //    public async Task<IActionResult> CouponDelete(int couponId)
        //    {
        //        ResponseDto? response = await _couponService.GetCouponByIdAsync(couponId);

        //        if (response != null && response.IsSuccess)
        //        {
        //            CouponDto? model = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(response.Result));
        //            return View(model);
        //        }
        //        else
        //        {
        //            TempData["error"] = response?.Message;
        //        }
        //        return NotFound();
        //    }

        //    [HttpPost]
        //    public async Task<IActionResult> CouponDelete(CouponDto couponDto)
        //    {
        //        ResponseDto? response = await _couponService.DeleteCouponsAsync(couponDto.CouponId);

        //        if (response != null && response.IsSuccess)
        //        {
        //            TempData["success"] = "Coupon deleted successfully";
        //            return RedirectToAction(nameof(CouponIndex));
        //        }
        //        else
        //        {
        //            TempData["error"] = response?.Message;
        //        }
        //        return View(couponDto);
        //    }


    }

}





//public IActionResult Delete(int? id)
//{
//    if(id==0 || id == null)
//    {
//        return NotFound();

//    }
//    var obj = _db.Feallesbases.Find(id);
//    if(obj==null)
//    {
//        return NotFound();
//    }
//    return View(obj);
//}


//[HttpGet]
//public IActionResult Search(DateTime DeadDate, string Firstname)
//{
//    var objList = from b in _db.Feallesbases select b;
//    if (DeadDate != null && Firstname == "")
//    {
//        objList = objList.Where(s => s.Doedsdato == (DeadDate));
//        return View(objList);
//    }

//    else if (DeadDate == null && Firstname != "")

//    {
//        objList = objList.Where(s => s.Fornavne.Contains(Firstname));
//        return View(objList);
//    }else if(DeadDate !=null && Firstname !="" )
//    {
//        objList = objList.Where(s => s.Fornavne.Contains(Firstname) & s.Doedsdato==DeadDate);
//        return View(objList);
//    }
//    return View("Index");

//}

//[HttpPost]
//public IActionResult DeletePost(int? id)
//{
//    var obj = _db.Feallesbases.Find(id);
//    if ( id==null || id==0)
//    {
//        return NotFound();
//    }

//    _db.Feallesbases.Remove(obj);
//    _db.SaveChanges();
//    TempData["success"] = "En annoncer sletet successfully";
//    return RedirectToAction("Index");
//}

//[HttpGet]
//public IActionResult SearchGet(int? ID)
//{
//    var obj = _db.Feallesbases.Find(ID);
//    if (obj == null)
//    {
//        return NotFound();
//    }

//   if(obj==null)
//    {
//        return NotFound();
//    }
//    return RedirectToAction("Index");
//}








