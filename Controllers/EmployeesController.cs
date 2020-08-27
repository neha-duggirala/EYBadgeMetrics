using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EYBadges.Models;
using EYBadges.Dto;
using Newtonsoft.Json;

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
            response.EmployeeId = id;
            response.EmployeeName = employee.EmployeeName;
            response.TeamName = teamDetails.TeamName;

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
                // find all list of dates with same employee ID
                var developerKpi = _context.DeveloperKpi.FromSql("Select * from DeveloperKpi where EmployeeId = {0}",id).ToList();

                var devDto = new DeveloperKpiDto();
                var devDtoList = new List<DeveloperKpiDto>();

                foreach (var developer in developerKpi)
                {
                    devDto.Date = developer.Date;
                    devDto.TestCoverage = developer.TestCoverage;
                    devDto.CodeQualityPercent = developer.CodeQualityPercent;
                    devDto.CodeSmellPercent = developer.CodeSmellPercent;
                    devDto.Kloc = developer.Kloc;
                    devDto.Throughput = developer.Throughput; 
                    devDtoList.Add(devDto);
                }

                response.DeveloperKpiDto = devDtoList;

            }
            //TODO: if employee is Tester

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(response);
        }


    }
}