﻿using System;
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

            //TODO: find all list of dates with same employee ID
            var outOfTheBox = await _context.OutOfTheBox.FindAsync(id);

            EmployeeDto response = new EmployeeDto();

            // if employee is Dev
            if (employee.EmployeeType == 1)
            {
                //TODO: find all list of dates with same employee ID
                var developerKpi = await _context.DeveloperKpi.FindAsync(id);

                DeveloperKpiDto devDto = new DeveloperKpiDto();

                devDto.Date = developerKpi.Date;
                devDto.TestCoverage = developerKpi.TestCoverage;
                devDto.CodeQualityPercent = developerKpi.CodeQualityPercent;
                devDto.CodeSmellPercent = developerKpi.CodeSmellPercent;
                devDto.Kloc = developerKpi.Kloc;
                devDto.Throughput = developerKpi.Throughput; 
                response.DeveloperKpiDto = devDto;
            }

            //TODO: if employee is Tester

            OutOfBoxDto outOfTheBoxDto = new OutOfBoxDto();
            outOfTheBox.Date = outOfTheBox.Date;
            outOfTheBox.IdeasToEnhanceTheCompany = outOfTheBox.IdeasToEnhanceTheCompany;
            outOfTheBox.IdeasToEnhanceTheProject = outOfTheBox.IdeasToEnhanceTheProject;

            
            response.EmployeeId = id;
            response.EmployeeName = employee.EmployeeName;
            response.TeamName = teamDetails.TeamName;
            //response.DeveloperKpiDto.Date = developerKpi.Date;
            
            response.OutOfBoxDto = outOfTheBoxDto;



            if (employee == null)
            {
                return NotFound();
            }

            return Ok(response);
        }


    }
}