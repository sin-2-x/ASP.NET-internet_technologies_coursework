using baza.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text.Json;
using Web_MVC.Data;

namespace asp2 {
    //[ApiController]
    //[Route("data")]
    /*[Authorize]*/
    public class WasteController : ControllerBase {

        /*private readonly ILogger<dataController> _logger;

        public dataController(ILogger<dataController> logger) {
        _logger = logger;
        }*/

        Web_MVCContext db;
        public WasteController(Web_MVCContext context) {
            db = context;

        }

        public class DayJSON {
            public string Date { get; set; }
            public double Sum { get; set; }
            public DayJSON(DateOnly date, double sum) {
                Date = date.ToString();
                Sum = sum;
            }
        }
        public class WasteJSON {
            public string Category { get; set; }
            public long Id { get; set; }
            public double Value { get; set; }
            public string? Comment { get; set; }

            public WasteJSON(long id, string category, double val, string comm) {

                Category = category;
                Value = val;
                Comment = comm;
                Id = id;
            }
            public WasteJSON(Waste waist) {

                Category = waist.IdCategoryNavigation.NameCategory;
                Value = waist.Value;
                Comment = waist.Comment;
                Id = waist.IdWaste;
            }

        }
        public async Task<IActionResult> Index() {
            return Problem("Entity set 'Web_MVCContext.Category'  is null.");
        }
        //[HttpGet("GetWastesByDays/dateStr")]
        public ActionResult<IEnumerable<double>> GetWastes(int year, int month) {
            string dateStr = "1." + month + "." + year;
            DateOnly.TryParse(dateStr, out DateOnly dateMonth);

            int daysInThisMonth = DateTime.DaysInMonth(dateMonth.Year, dateMonth.Month);
            //int daysInPreviousMonth = DateTime.DaysInMonth(previousMonth.Year, previousMonth.Month);
            //int dayOfTheWeek = Convert.ToInt32(dateMonth.DayOfWeek == 0 ? 7 : dateMonth.DayOfWeek);

            DateOnly lockalDate;
            //List<DayJSON> daysToJSON = new List<DayJSON>();
            List<double> Sums = new List<double>();

            /*//заполнение предыдущего месяца
            for (int i = 1; i < dayOfTheWeek; i++)
            {
                lockalDate = previousMonth.AddDays(daysInPreviousMonth - dayOfTheWeek + i);
                double eValue = db.Wastes.Include(w => w.IdDayNavigation).Where(w => w.IdDayNavigation.DayDate == lockalDate).Sum(p => p.Value);
                daysToJSON.Add(new DayJSON(lockalDate, eValue));
            }
            //заполнение нынешнего месяца
            */
            for (int i = 1; i <= daysInThisMonth; i++) {
                //int dayNumber = i;
                lockalDate = dateMonth.AddDays(i - 1);
                //var eValue = db.Wastes.Where().Where(w => w.DayDate == lockalDate).ToList().Count()/*.Sum(p => p.Value)*/;
                //var eValue = db.Wastes.Where(w=>w.DayDate==lockalDate ).ToList();
                var eValue = db.Wastes.Include(w => w.IdUserNavigation).Include(w => w.IdCategoryNavigation).Where(w => w.IdUser == 1 && w.DayDate == lockalDate).Sum(w => w.Value);

                //daysToJSON.Add(new DayJSON(lockalDate, eValue));
                Sums.Add(Math.Round(eValue, 2));
            }
            /*
            int daysOfNextMonth = 7 - (daysInThisMonth + dayOfTheWeek - 1) % 7;
            //Заполнение предыдущего месяца
            for (int i = 0; i < daysOfNextMonth; i++)
            {
                lockalDate = thisMonth.AddMonths(1).AddDays(i);
                double eValue = db.Wastes.Include(w => w.IdDayNavigation).Where(w => w.IdDayNavigation.DayDate == lockalDate).Sum(p => p.Value);
                daysToJSON.Add(new DayJSON(lockalDate, eValue));
            }*/
            return Sums;
        }
        

        public ActionResult<IEnumerable<WasteJSON>> GetWastesOfOneDay(int year, int month, int day) {
            string dateStr = day+"." + month + "." + year;
            DateOnly.TryParse(dateStr, out DateOnly dateMonth);

            int daysInThisMonth = DateTime.DaysInMonth(dateMonth.Year, dateMonth.Month);
            //int daysInPreviousMonth = DateTime.DaysInMonth(previousMonth.Year, previousMonth.Month);
            //int dayOfTheWeek = Convert.ToInt32(dateMonth.DayOfWeek == 0 ? 7 : dateMonth.DayOfWeek);

            //DateOnly lockalDate;
            List<WasteJSON> daysToJSON = new();
            //List<double> Sums = new List<double>();

                var waistsFromDb = db.Wastes.Include(w => w.IdUserNavigation).Include(w => w.IdCategoryNavigation).Where(w => w.IdUser == 1 && w.DayDate == dateMonth);
            foreach (var wasteDb in waistsFromDb)
            {
             
                daysToJSON.Add(new WasteJSON(wasteDb));   
            }
            return daysToJSON;
        }
        /*
                [HttpGet("getMonyLimitOfMonth/{dateStr}")]
                public ActionResult<double> GetLimit(string dateStr)
                {
                    DateOnly monthDate = DateOnly.Parse(dateStr);

                    var month = db.Months.Where(m => m.Year == monthDate.Year && monthDate.Month == m.Month1).SingleOrDefaultAsync().Result;

                    if (month == null)
                    {
                        return 0;
                    }

                    return month.MonyLimit;
                }

                [HttpGet("getWastesOfCurrentDay/{dayDateStr}")]

                public ActionResult<IEnumerable<WasteJSON>> GetWaists(string dayDateStr)
                {
                    DateOnly day = DateOnly.Parse(dayDateStr);

                    var a = db.Wastes.Include(w => w.IdCategoryNavigation).Include(w => w.IdDayNavigation).Where(w => w.IdDayNavigation.DayDate == day).ToList();
                    List<WasteJSON> wasteList = new();
                    foreach (var w in a)
                    {
                        wasteList.Add(new WasteJSON(w.IdWaste, w.IdCategoryNavigation.NameCategory, w.Value, w.Comment));
                    }
                    return wasteList;
                }



                [HttpPost("addWaste/{day}&{categ}&{val}&{comment}")]
                [HttpPost("addWaste/{day}&&{val}&{comment}")]
                public async Task<IActionResult> PostWaists(string day, string? categ, string val, string comment)
                {

                    Waste newWaste = new();
                    newWaste.IdUser = int.Parse(User.Identity.Name);
                    Usr usr = db.Usrs.Single(u => u.IdUsr == int.Parse(User.Identity.Name));
                    //НАстройка первичного ключа
                    if (db.Wastes.AnyAsync().Result)
                        newWaste.IdWaste = db.Wastes.Max(c => c.IdWaste) + 1;
                    //Настройка ссылок на день

                    DateOnly CurrentDate = DateOnly.Parse(day);
                    if (db.Days.Any(d => d.DayDate == CurrentDate))
                    {//Присвоить существующий день

                        newWaste.IdDayNavigation = db.Days.Single(d => d.DayDate == CurrentDate);
                        newWaste.IdDay = newWaste.IdDayNavigation.IdDay;
                    }
                    else
                    {//Создать новый день

                        newWaste.IdDayNavigation = new Day() { DayDate = CurrentDate, IdDay = db.Days.Any() ? db.Days.Max(c => c.IdDay) + 1 : 1 };

                    }
                    //Настройка ссылок на категорию
                    if (categ==null || categ == String.Empty)
                    { //Если строка пустая то категория по умолчанию            NOT
                        newWaste.IdCategoryNavigation = db.Categories.First();//db.Categories.First(c=> int.Parse(User.Identity.Name) == c.IdUser);
                    }

                    else if (db.Categories.Any(сa => сa.IdUser == int.Parse(User.Identity.Name) && сa.NameCategory == categ))
                    {//Если категория существует, то присвоить

                        newWaste.IdCategoryNavigation = db.Categories.First(сa => сa.IdUser == int.Parse(User.Identity.Name) && сa.NameCategory == categ);

                    }
                    else
                    {
                        newWaste.IdCategoryNavigation = new Category() { NameCategory = categ, IdCategory = db.Categories.Max(c => c.IdCategory) + 1 , UsedCountCategory =1, IdUser =int.Parse(User.Identity.Name)};
                    }
                    newWaste.IdCategory = newWaste.IdCategoryNavigation.IdCategory;

                    newWaste.Value = double.Parse(val);
                    newWaste.Comment = comment;
                    db.Wastes.Add(newWaste);
                    await db.SaveChangesAsync();

                    return CreatedAtAction(nameof(PostWaists), null );

                }

                [HttpDelete("deleteWaste/{idWaste}")]
                public async Task<HttpStatusCode> PeleteWaists(long idWaste)
                {

                    db.Wastes.Remove(db.Wastes.Single(w=>w.IdWaste== idWaste));
                    await db.SaveChangesAsync();

                    return HttpStatusCode.NoContent;

                }
        */
    }
}
