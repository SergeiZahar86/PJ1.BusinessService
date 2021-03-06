using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Calabonga.DemoClasses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PJ1_BusinessService.models;

namespace PJ1_BusinessService.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    public class ApiController : ControllerBase
    {
        /// <summary>
        /// Фиктивный метод из Calabonga.DemoClasses
        /// </summary>
        private readonly List<Person> _people = People.GetPeople();
        
        /// <summary>
        /// Контекст базы данных
        /// </summary>
        private ApplicationDbContext dbContext;
        
        /// <summary>
        /// Предоставляет API для управления пользователем в магазине настойчивых.
        /// </summary>
        private readonly UserManager<AppUser> _userManager;


        public ApiController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            dbContext = context;
            _userManager = userManager;
        }

        /// <summary>
        /// Получить весь список работников
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize]
        //[Authorize(Roles = "Administrator")]
        public IActionResult GetAll()
        {
            var nameIdentifier = this.HttpContext.User.Claims;
            return Ok(_people);
        }

        /// <summary>
        /// Получить работника по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("[action]/{id:int}")]
        public IActionResult GetById(int id)
        {
            var item = _people.FirstOrDefault(x => x.Id == id);
            return Ok(item);
        }

        /// <summary>
        /// Добавить работника
        /// </summary>
        /// <param name="empl"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> SetEmplAsync([FromBody] EmplModel empl)
        {

            if (await _userManager.FindByNameAsync(empl.Name) == null)
            {
                var employee = new AppUser
                {
                    UserName = empl.Name
                };
                IdentityResult result = await _userManager.CreateAsync(employee, empl.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(employee, "Employee");
                    return Ok("Работник успешно добавлен");
                }
            }

            return BadRequest("Работник с таким именем уже существует");
        }

        /// <summary>
        /// Добавить работнику время начало
        /// </summary>
        /// <param name="empl"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> SetStartTimeAsync([FromBody] EmplStartTime empl)
        {
            DateTime date = new DateTime();
            var user = await _userManager.FindByIdAsync(empl.IdUser.ToString());
            var time = await dbContext.WorkedTimes
                .FirstOrDefaultAsync(x => x.User == user && x.EndTime == date);

            if (user != null && time == null)
            {
                WorkedTimes workTimes = new WorkedTimes
                {
                    User = user,
                    StartTime = DateTime.Now
                };
                dbContext.WorkedTimes.Add(workTimes);
                dbContext.SaveChanges();
                return Ok("Запись добавлена");
            }
            return BadRequest("Что-то пошло не так");
        }
        
        /// <summary>
        /// Добавить работнику время окончания
        /// </summary>
        /// <param name="empl"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> SetEndTimeAsync([FromBody] EmplEndTime empl)
        {
            DateTime date = new DateTime();
            var user = await _userManager.FindByIdAsync(empl.IdUser.ToString());
            var time = await dbContext.WorkedTimes
                .FirstOrDefaultAsync(x => x.User == user && x.EndTime == date);

            if (user != null && time != null)
            {
                time.EndTime = DateTime.Now;
                dbContext.SaveChanges();
                return Ok("Запись завершена");
            }
            return BadRequest("Что-то пошло не так");
        }
        
        /// <summary>
        /// Получить весь список отработанного времени
        /// </summary>
        /// <param name="empl"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> GetListTimeAsync([FromBody] EmplGetListTime empl)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(empl.UserId.ToString());
                WorkedTimes[] times = await dbContext.WorkedTimes
                    .Where(x => x.User == user).ToArrayAsync();

                if (times != null)
                {
                    return Ok(times);

                }
            }
            catch(Exception aa)
            {
                return Ok(aa);
            }
            return BadRequest("Что-то пошло не так");
        }
    }
}
