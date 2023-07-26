﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThreeBook.Models;

namespace ThreeBook.Controllers
{
    public class HomeController : Controller
    {
        // Модель.
        DataBooksEntities2 context = new DataBooksEntities2();

        /// <summary>
        /// Список категорий
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            string sessionId = HttpContext.Session.SessionID;
            
            System.Diagnostics.Debug.WriteLine("session = "+ sessionId);
            //Person tom = new Person("Tom", 35);
            //Person bob = new Person("Bob", 16);

            var ListReg = (from a in context.TypesBook select a).ToList();
            ModelMain modelMain = new ModelMain();

            return View(ListReg);
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

            var card = (from a in context.TypesBook where a.Id == id select a).First();
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

            var cardReglament = (from a in context.TypesBook where a.Id == id select a).First();
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
        public ActionResult ListBooks(int id)
        {
            var ListReg = (from a in context.TitleBook where a.uid==id select a).ToList();
            ViewBag.uid = ListReg.FirstOrDefault().uid;
            return View(ListReg);
        }
        
        /// <summary>
        /// Создание книги.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult ListBooksCreate(int id)
        {


            var titleBoook = new TitleBook();
            titleBoook.uid = id;
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
            var ListReg = (from a in context.Table where a.uid == id select a).ToList();
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