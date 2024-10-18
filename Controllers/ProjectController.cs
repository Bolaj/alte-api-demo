using System;
using alte_app.Migrations;
using alte_app.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public ProjectController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult AllProjects()
        {
            return Ok(dbContext.Projects.ToList());

        }

        [HttpGet("{id}")]
         public IActionResult ProjectId(Guid id)
        {
           var project = dbContext.Projects.Find(id);
           if(project is null)
           {
            return NotFound();
             
           }
           return Ok(project);

        }

        [HttpPost]
         public IActionResult AddProject(AddProjectDto addProjectDto)
        {
            var projectEntity = new ProjectCard()
            {
                Title = addProjectDto.Title,
                Description = addProjectDto.Description,
                Skills = addProjectDto.Skills,
                Duration = addProjectDto.Duration,
                SalaryRange = addProjectDto.SalaryRange,
                PostedDate = addProjectDto.PostedDate,
                IsBookmarked = addProjectDto.IsBookmarked
            };
            dbContext.Projects.Add(projectEntity);
            dbContext.SaveChanges();
            return Ok(projectEntity);

        }

        [HttpPut("{id}")]
           public IActionResult EditProject(Guid id, AddProjectDto editProjectDto)
        {
            var project = dbContext.Projects.Find(id);
            if(project is null)
            {
                return NotFound();
            }
            project.Title = editProjectDto.Title;
            project.Description = editProjectDto.Description;
            project.Skills = editProjectDto.Skills;
            project.Duration = editProjectDto.Duration; 
            project.SalaryRange = editProjectDto.SalaryRange;
            project.PostedDate = editProjectDto.PostedDate;
            project.IsBookmarked = editProjectDto.IsBookmarked;

            dbContext.SaveChanges();
            return Ok(project);

        }

        [HttpDelete("{id}")]
        
        public IActionResult DeleteProject(Guid id)
        {
            var project = dbContext.Projects.Find(id);
            if(project is null)
            {
                return NotFound();
            }
            dbContext.Projects.Remove(project);
            dbContext.SaveChanges();
            return Ok();

        }
    }
}