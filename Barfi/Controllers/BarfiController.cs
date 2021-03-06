﻿using Barfi.Models;
using Barfi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Barfi.Controllers
{
    public class BarfiController : Controller
    {
        private readonly IBarData db;
        public BarfiController(IBarData db)
        {
            this.db = db;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var model = db.getAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
         public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model); ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bar bar)
        {
            if(ModelState.IsValid)
            {
                db.Update(bar);
                return RedirectToAction("Details", new { id = bar.ID });
            }
            return View(bar);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bar bar)
        {
            if(ModelState.IsValid)
            {
                db.Add(bar);
                return RedirectToAction("Details", new { id = bar.ID });
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}