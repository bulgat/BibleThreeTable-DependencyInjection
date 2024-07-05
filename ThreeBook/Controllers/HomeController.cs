using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ThreeBook.ActionFilter;
using ThreeBook.Models;
using ThreeBook.ViewModel;

namespace ThreeBook.Controllers
{
    [LogActionFilter]
    public class HomeController : Controller
    {
        // Модель.
        DataBooksEntities2 context = new DataBooksEntities2();

        /// <summary>
        /// Список категорий
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 10)]
        //[ValidateAntiForgeryToken]
        public ActionResult Index()
        {
            string sessionId = HttpContext.Session.SessionID;
            
            System.Diagnostics.Debug.WriteLine("session = "+ sessionId);
            //Person tom = new Person("Tom", 35);
            //Person bob = new Person("Bob", 16);

            List<TypesBook> ListReg = (from a in context.TypesBook select a).ToList();
            ModelMain modelMain = new ModelMain();

            //select * from [dbo].[Table],[dbo].[TitleBook]  where [dbo].[Table].Id=17 order by [dbo].[Table].Id desc offset 10 rows
            //List<Table> t = ("select * from [dbo].[Table]").ToList();
            //select top 3  * from [dbo].[Table],[dbo].[TitleBook]  where [dbo].[Table].Id=17
            //select max(cost) from [dbo].[Table] 
            //select max(cost) as superCost from[dbo].[Table]
            //select max(dd.rating) from (select * from [dbo].[TitleBook] a union all select * from [dbo].[Table] b) as dd
            //var ttt = context.Table.SqlQuery("select [dbo].[Table].Id from [dbo].[Table],[dbo].[TitleBook]  where [dbo].[Table].Id=1").ToList<Table>();
            //select * from (select max(dd.rating) as fff from (select b.Id,a.rating,a.title,b.cost from [dbo].[TitleBook] a LEFT JOIN [dbo].[Table] b on a.Id=b.uid) dd) cc
            //select * from (select b.Id,a.rating,a.title,b.cost from [dbo].[TitleBook] a LEFT JOIN [dbo].[Table] b on a.Id=b.uid) dd where dd.rating=(select max(gg.rating) from [dbo].[TitleBook] gg)

            var tt = ("select Id,uid,title from [dbo].[Table] where Id=1").ToList();

            ViewBag.DateTime = DateTime.Now.ToString("T");

            AppMappingProfile conf = new AppMappingProfile();
            var mapper = new Mapper(AppMappingProfile.config);
            
            //mapper.Map<TypesBook>()

            var viewTypeBook = mapper.Map<TypesBook, ViewTypeBook>(ListReg.First());
            ViewBag.title = viewTypeBook.title;
            //;

            //var person = context.TitleBook.Where(a=>a.Id>0).ProjectTo<TitleBook>(mapper.ConfigurationProvider).ToList();
            var person = context.TitleBook.ProjectTo<ViewTitleBook>(mapper.ConfigurationProvider).ToList();

            int? krik = 456;
            System.Diagnostics.Debug.WriteLine("001;;;;;;;;;;;;;;;=0006 " + krik.HasValue);
            krik = null;
            System.Diagnostics.Debug.WriteLine("002;;;;;;;;;;;;;;;=0006 " + krik.HasValue);

            string kol = "stop";
            string kol0 = "C";
            System.Diagnostics.Debug.WriteLine("004;;;;;;;;;;;;;=0006 " +kol.Equals("stop",StringComparison.InvariantCultureIgnoreCase));
            System.Diagnostics.Debug.WriteLine("005;;;;;;;;;;;;;=0006 " + kol.Equals("Stop", StringComparison.OrdinalIgnoreCase));
            System.Diagnostics.Debug.WriteLine("006;;;;;;;;;;;;;=0006 " + kol0.Equals("С", StringComparison.OrdinalIgnoreCase));
            return View(ListReg);
        }


        public ActionResult ListBookMore()
        {
            List<Table> tableList = context.Table.SqlQuery("Select * from [dbo].[Table]").ToList<Table>();
            return View(tableList);
        }
        /// <summary>
        /// Создать новую категорию.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            //TypesBook createBook = new TypesBook();
            return View(new TypesBook());
        }

        /// <summary>
        /// Сохранить новую категорию.
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(TypesBook card)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.TypesBook.Add(card);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
            }
            return RedirectToAction("");
  
        }

        /// <summary>
        /// Удалить категорию.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            Session["DeleteName"] = Request.Form["DeleteName"];
            var filePath = Request.FilePath;
            var cook = Request.Cookies;
            var cookDelete = Request.Cookies["deletename"];
            var stop0 = Session["DeleteName"];
            
            var card = (from a in context.TypesBook where a.Id == id select a).First();
            return View(card);
        }

        /// <summary>
        /// Удалить категорию, окончательное решение.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            var card = (from a in context.TypesBook where a.Id == id select a).First();
            try
            {
                context.TypesBook.Remove(card);

                context.SaveChanges();
                return RedirectToAction("");

            }
            catch
            {
                return View(card);
            }

        }
        /// <summary>
        /// Посмотреть детали категорий.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var card = (from a in context.TypesBook where a.Id == id select a).First();
            return View(card);
        }
        /// <summary>
        /// Редактировать категорию.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {

            TypesBook card = (from a in context.TypesBook where a.Id == id select a).First();
      
            return View(card);
        }
        /// <summary>
        /// Принять изменения при редактирование категории.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {

            TypesBook cardReglament = (from a in context.TypesBook where a.Id == id select a).First();
            cardReglament.Description = "Stop";

            var isAgeModified = context.Entry(cardReglament).Property("Description").IsModified;
            //EntityTypeBuilder < Company >
            try
            {

                UpdateModel(cardReglament);
                context.SaveChanges();
                return RedirectToAction("");

            }
            catch
            {
                return View(cardReglament);
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Список книг по категориям.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ListBooks(int? id)
        {
            int Id = Convert.ToInt32(id);
            var ListReg = (from a in context.TitleBook where a.uid== Id select a).ToList();
            ViewBag.uid = ListReg.FirstOrDefault().uid;
            return View(ListReg);
        }
        
        /// <summary>
        /// Создание книги.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ListBooksCreate(int? id)
        {
            int Id = Convert.ToInt32(id);

            var titleBoook = new TitleBook();
            titleBoook.uid = Id;
            return View(titleBoook);
        }
        /// <summary>
        /// Потвердить создание книги.
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ListBooksCreate(TitleBook card)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.TitleBook.Add(card);
                    context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex);
            }
            return RedirectToAction("");
        }


        /// <summary>
        /// Страница книги.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ContentBook(int id)
        {
            List<Table> ListReg = (from a in context.Table where a.uid == id select a).ToList();

            return View(ListReg);
        }

        [HttpGet]
        public JsonResult FirstBook()
        {
            string name = "FirstBookAuthor";
            return Json(name, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult LastBook()
        {
            string name = "LastBookAuthor";
            return Json(name, JsonRequestBehavior.AllowGet);
        }
    }
    /*
    public class AgeValidationAttribute : Attribute
    {
        public int Age { get; }
        public AgeValidationAttribute() { }
        public AgeValidationAttribute(int age) => Age = age;
    }
    */
    /*
    [AgeValidation(18)]
    public class Person
    {
        public string Name { get; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    */
}