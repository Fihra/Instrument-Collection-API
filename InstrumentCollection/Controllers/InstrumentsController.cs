using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InstrumentCollection.Models.Repository;

using MongoDB.Bson;
using MongoDB.Driver;

using InstrumentCollection.Models;
using System.Web.Mvc;
using HttpPostAttribute = System.Web.Mvc.HttpPostAttribute;

namespace InstrumentCollection.Controllers
{
    public class InstrumentsController : Controller
    {
        private InstrumentCollect _instruments = new InstrumentCollect();

        public ActionResult Index()
        {
            return View(_instruments.SelectAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Instrument instrument)
        {
            _instruments.InsertInstrument(instrument);
            return RedirectToAction("Index", _instruments.SelectAll());
        }
    }
}
