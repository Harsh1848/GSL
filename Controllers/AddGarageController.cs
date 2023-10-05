using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using GSL.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;

namespace GSL.Controllers
{
    public class AddGarageController : Controller
    {
        FirebaseAuthProvider auth;
        UserRegistrationModel userModel;

        public AddGarageController() {
            auth = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyBnzcYAd1D8h0d-UdGCj5q4iUA88e2CRnQ"));
        }

        public ActionResult AddGarage() { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGarageAsync(GarageModel model)
        {
            try
            {
                string jsonStr = Request.Cookies["UserModel"];
                userModel = JsonConvert.DeserializeObject<UserRegistrationModel>(jsonStr);

                var firebaseClient = new FirebaseClient("https://gslocator-6b655-default-rtdb.firebaseio.com");
                var garage = firebaseClient.Child("garage");
                
                _ = garage.PostAsync(model);

                return RedirectToAction("ProviderHome", "ProviderHome");
            }
            catch (FirebaseAuthException ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                ViewBag.ErrorMessage = ex.Message;
                return View("Register");
            }
        }
    }
}
