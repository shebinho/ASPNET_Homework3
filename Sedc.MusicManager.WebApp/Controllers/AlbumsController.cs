using Sedc.MusicManager.WebApp.Data;
using Sedc.MusicManager.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sedc.MusicManager.WebApp.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly MusicDb _db;

        public AlbumsController()
        {
            _db = new MusicDb();
        }

        public ActionResult Index()
        {
            var albums = _db.Albums.ToList();
            return View(albums);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Album album)
        {
            if (!ModelState.IsValid)
            {
                //return the same page with error messages
                return View(album);
            }
            //save to database
            _db.Albums.Add(album);
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


            var album = _db.Albums.FirstOrDefault(x => x.Id == id);
            if (album == null)
                return RedirectToAction("Index");

            return View(album);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            var album = _db.Albums.FirstOrDefault(s => s.Id == id);

            if (album == null)
                return RedirectToAction("Index");

            return View(album);
        }

        [HttpPost]
        public ActionResult Edit(int? id, Album album)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            if (!ModelState.IsValid)
                return View(album);

            var dbAlbum = _db.Albums.FirstOrDefault(s => s.Id == id);

            if (dbAlbum == null)
                return RedirectToAction("Index");

            dbAlbum.Title = album.Title;
            dbAlbum.Genre = album.Genre;
            dbAlbum.Artist = album.Artist;
            dbAlbum.Songs = album.Songs;


            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {

            var album = _db.Albums.FirstOrDefault(i => i.Id == id);
            return View(album);

        }


        [HttpPost]
        public ActionResult Delete(int id, Album album)
        {

            var dbAlbum = _db.Albums.FirstOrDefault(c => c.Id == id);
            _db.Albums.Remove(dbAlbum);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}