using Firebase.Database;
using GSL.Models;
using GSL.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GSL.Controllers
{
    public class ProviderHomeController : Controller
    {
        public async Task<IActionResult> ProviderHomeAsync()
        {
            var firebaseClient = new FirebaseClient("https://gslocator-6b655-default-rtdb.firebaseio.com");
            var garages = await firebaseClient.Child("garage").OnceAsync<GarageModel>();
            var garageList = garages.Select(item => new GarageModel
            {
                Id = item.Object.Id,
                Address = item.Object.Address,
                City = item.Object.City,
                State = item.Object.State,
                Country = item.Object.Country,
                PostalCode = item.Object.PostalCode,
                OwnerName = item.Object.OwnerName,
                OwnerPhoneNumber = item.Object.OwnerPhoneNumber,
            }).ToList();

            return View(garageList);
        }
    }
}
