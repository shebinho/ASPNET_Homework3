using Sedc.MusicManager.WebApp.Data;
using Sedc.MusicManager.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sedc.MusicManager.WebApp.Controllers
{
    public class SongsController : Controller
    {
        private readonly MusicDb _db;

        public SongsController()
        {
            _db = new MusicDb();
        }


        public ActionResult Index()
        {
            var songs = _db.Songs.ToList();
            return View(songs);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Song song)
        {
            if (!ModelState.IsValid)
            {
                //return the same page with error messages
                return View(song);
            }
            //save to database
            _db.Songs.Add(song);
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


            var song = _db.Songs.FirstOrDefault(x => x.Id == id);
            if (song == null)
                return RedirectToAction("Index");

            return View(song);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            var song = _db.Songs.FirstOrDefault(s => s.Id == id);

            if (song == null)
                return RedirectToAction("Index");

            return View(song);
        }

        [HttpPost]
        public ActionResult Edit(int? id, Song song)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            if (!ModelState.IsValid)
                return View(song);

            var dbSong = _db.Songs.FirstOrDefault(s => s.Id == id);

            if (dbSong == null)
                return RedirectToAction("Index");

            dbSong.Title = song.Title;
            dbSong.Description = song.Description;
            dbSong.Duration = song.Duration;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            var song = _db.Songs.FirstOrDefault(s => s.Id == id);

            if (song == null)
                return RedirectToAction("Index");

            return View(song);
            
        }

        [HttpPost]
        public ActionResult Delete(int? id, Song song)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");


            var dbSong = _db.Songs.FirstOrDefault(s => s.Id == id);

            if (dbSong == null)
                return RedirectToAction("Index");


            _db.Songs.Remove(dbSong);
            _db.SaveChanges();

            return RedirectToAction("Index");

            
        }
    }
}