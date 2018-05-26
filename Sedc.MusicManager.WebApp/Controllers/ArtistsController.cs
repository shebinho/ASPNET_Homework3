using Sedc.MusicManager.WebApp.Data;
using Sedc.MusicManager.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sedc.MusicManager.WebApp.Controllers
{
    public class ArtistsController : Controller
    {
        
        private readonly MusicDb _db;

        public ArtistsController()
        {
            _db = new MusicDb();
        }

        // GET: Artists
        public ActionResult Index()
        {
            var artists = _db.Artists.ToList();
            return View(artists);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Artist artist)
        {
            if (!ModelState.IsValid)
            {
                //return the same page with error messages
                return View(artist);
            }
            //save to database
            _db.Artists.Add(artist);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("index");
            }


            var artist = _db.Artists.FirstOrDefault(x => x.Id == id);
            if (artist == null)
                return RedirectToAction("Index");

            return View(artist);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            var artist = _db.Artists.FirstOrDefault(s => s.Id == id);

            if (artist == null)
                return RedirectToAction("Index");

            return View(artist);
        }

        [HttpPost]
        public ActionResult Edit(int? id, Artist artist)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            if (!ModelState.IsValid)
                return View(artist);

            var dbArtist = _db.Artists.FirstOrDefault(s => s.Id == id);

            if (dbArtist == null)
                return RedirectToAction("Index");

            dbArtist.Albums = artist.Albums;
            dbArtist.ArtistType = artist.ArtistType;
            dbArtist.FullName = artist.FullName;
            

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            var artist = _db.Artists.FirstOrDefault(s => s.Id == id);

            if (artist == null)
                return RedirectToAction("Index");

            return View(artist);

        }

        [HttpPost]
        public ActionResult Delete(int? id, Artist artist)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");


            var dbArtist = _db.Artists.FirstOrDefault(s => s.Id == id);

            if (dbArtist == null)
                return RedirectToAction("Index");


            _db.Artists.Remove(dbArtist);
            _db.SaveChanges();

            return RedirectToAction("Index");


        }
    }
}