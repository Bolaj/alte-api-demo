using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using alte_app.Models;
using Microsoft.CodeAnalysis.Differencing;

namespace MyApp.Namespace

{
    [Route("api/[controller]")]
    [ApiController]
    public class EditProfileController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public EditProfileController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]

        public IActionResult GetFreelancers()
        {
            return Ok(dbContext.EditProfiles.ToList());
        }
        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetFreelancerId(Guid id)
        {
           var freelancer = dbContext.EditProfiles.Find(id);
           if(freelancer is null)
           {
            return NotFound();
             
           }
           return Ok(freelancer);

        }
        [HttpPost]
        public IActionResult PostProfile(EditProfileDto editProfile)
        {
            var freelancerEntity = new EditProfile()
            {
                FullName = editProfile.FullName,
                Email = editProfile.Email,
                About = editProfile.About,
                Role = editProfile.Role,
                Rate = editProfile.Rate,
                Language = editProfile.Language,
                Skills = editProfile.Skills,
                Timezone = editProfile.Timezone,
                Availability = editProfile.Availability,
                Portfolio = editProfile.Portfolio,
                LinkedIn = editProfile.LinkedIn
            };
            dbContext.EditProfiles.Add(freelancerEntity);
            dbContext.SaveChanges();
            return Ok(freelancerEntity);

        }
        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult EditPostProfile(Guid id, EditProfileDto updateProfile)
        {
            var freelancer = dbContext.EditProfiles.Find(id);
            if(freelancer is null)
            {
                return NotFound();
            }
            freelancer.FullName = updateProfile.FullName;
            freelancer.Email = updateProfile.Email;
            freelancer.About = updateProfile.About;
            freelancer.Language = updateProfile.Language;
            freelancer.Rate = updateProfile.Rate;
            freelancer.Role = updateProfile.Role;
            freelancer.Skills = updateProfile.Skills;
            freelancer.LinkedIn = updateProfile.LinkedIn;
            freelancer.Portfolio = updateProfile.Portfolio;
            freelancer.Timezone = updateProfile.Timezone;
            freelancer.Availability = updateProfile.Availability;

            dbContext.SaveChanges();
            return Ok(freelancer);

        }
         [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteProfile(Guid id)
        {
            var freelancer = dbContext.EditProfiles.Find(id);
            if(freelancer is null)
            {
                return NotFound();
            }
            dbContext.EditProfiles.Remove(freelancer);
            dbContext.SaveChanges();
            return Ok();

        }




        
    }
}
