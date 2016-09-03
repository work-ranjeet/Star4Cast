using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Star4Cast.Controllers
{
    [Authorize]
    public class ProfileEditController : Controller
    {
        public async Task<IActionResult> TalentProfileViewAs()
        {
            return await Task.Run(() => View());
        }

        public async Task<IActionResult> PhysicalAppearance()
        {
            return await Task.Run(() => View());
        }
        public async Task<IActionResult> ExperianceEdit()
        {
            return await Task.Run(() => View());
        }

        public async Task<IActionResult> ActingEdit()
        {
            return await Task.Run(() => View());
        }
        public async Task<IActionResult> ModelingEdit()
        {
            return await Task.Run(() => View());
        }
        public async Task<IActionResult> MusicEdit()
        {
            return await Task.Run(() => View());
        }
        public async Task<IActionResult> TvRealityEdit()
        {
            return await Task.Run(() => View());
        }
        public async Task<IActionResult> DancingEdit()
        {
            return await Task.Run(() => View());
        }
        public async Task<IActionResult> FilmScrewEdit()
        {
            return await Task.Run(() => View());
        }
        public async Task<IActionResult> MagazineEdit()
        {
            return await Task.Run(() => View());
        }
        public async Task<IActionResult> PhotographyEdit()
        {
            return await Task.Run(() => View());
        }
        public async Task<IActionResult> StylistEdit()
        {
            return await Task.Run(() => View());
        }
    }
}
