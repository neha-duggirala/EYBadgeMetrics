using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EYBadges.Models;
using EYBadges.Dto;

namespace EYBadges.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EYBadgeMetricsContext _context;

        public EmployeesController(EYBadgeMetricsContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public IEnumerable<Employee> GetEmployee()
        {
            return _context.Employee;
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = await _context.Employee.FindAsync(id);
            var teamId = employee.TeamId;
            var teamDetails = await _context.TeamDetails.FindAsync(teamId);
            EmployeeDto response = new EmployeeDto();
            //find all list of dates with same employee ID
            var outOfTheBox =  _context.OutOfTheBox.FromSql("select * from OutOfTheBox where EmployeeId = {0}", id).ToList();
            
            var outOfBoxDtoList = new List<OutOfBoxDto>();
            foreach (var item in outOfTheBox)
            {
                OutOfBoxDto outOfTheBoxDto = new OutOfBoxDto();
                outOfTheBoxDto.Date= item.Date;
                outOfTheBoxDto .IdeasToEnhanceTheCompany= item.IdeasToEnhanceTheCompany;
                outOfTheBoxDto.IdeasToEnhanceTheProject= item.IdeasToEnhanceTheProject;
                outOfBoxDtoList.Add(outOfTheBoxDto);

            }

            response.OutOfBoxDto = outOfBoxDtoList;


            // if employee is Dev
            if (employee.EmployeeType == 1)
            {
                //TODO: find all list of dates with same employee ID
                //var developerKpi = await _context.DeveloperKpi.FindAsync(id);
                var developerKpi =  _context.DeveloperKpi.FromSql("select * from DeveloperKpi where EmployeeId = {0}",id).ToList();
                Console.WriteLine(developerKpi);
                DeveloperKpiDto devDto = new DeveloperKpiDto();

                //devDto.Date = developerKpi.Date;
                //devDto.TestCoverage = developerKpi.TestCoverage;
                //devDto.CodeQualityPercent = developerKpi.CodeQualityPercent;
                //devDto.CodeSmellPercent = developerKpi.CodeSmellPercent;
                //devDto.Kloc = developerKpi.Kloc;
                //devDto.Throughput = developerKpi.Throughput; 
                //response.DeveloperKpiDto = devDto;
            }

            //TODO: if employee is Tester

            
            
            response.EmployeeId = id;
            response.EmployeeName = employee.EmployeeName;
            response.TeamName = teamDetails.TeamName;
            //response.DeveloperKpiDto.Date = developerKpi.Date;
            




            if (employee == null)
            {
                return NotFound();
            }

            return Ok(response);
        }


    }
}