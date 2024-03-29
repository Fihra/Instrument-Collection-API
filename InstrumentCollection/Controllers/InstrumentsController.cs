﻿using System;
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
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using System.Xml;
using Newtonsoft.Json;

namespace InstrumentCollection.Controllers
{
    public class InstrumentsController : ApiController
    {
        private InstrumentCollect _instruments = new InstrumentCollect();

        //public ActionResult Index()
        //{
        //    return View(_instruments.SelectAll());
        //}

        //[HttpGet]
        //public IEnumerable<Instrument> All()
        //{
        //    return _instruments.SelectAll();
        //}

        [Route("api/instruments/all")]
        [HttpGet]
        public List<Instrument> All()
        {

            return _instruments.SelectAll();
        }

        [Route("api/instruments/{id}")]
        [HttpGet]
        public Instrument GetInstrument(string id)
        {
            var instrument = _instruments.Get(id);

            if(instrument == null)
            {
                return null;
            }

            return instrument;
        }

        [Route("api/instruments/new")]
        [HttpPost]
        public Instrument Create(Instrument instrument)
        {
           _instruments.InsertInstrument(instrument);
            return instrument;
        }

        [Route("api/instruments/{id}/delete")]
        [HttpPost]
        public void Delete(string id)
        {
            _instruments.DeleteInstrument(id);
        }
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(Instrument instrument)
        //{
        //    _instruments.InsertInstrument(instrument);
        //    return RedirectToAction("Index", _instruments.SelectAll());
        //}
    }
}
