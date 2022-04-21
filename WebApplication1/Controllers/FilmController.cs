using Newtonsoft.Json;
using System.Web.Mvc;
using FilmBase.App_Data.IRepository;
using FilmDataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using System.Net.Http;
using WebApplication1.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
//httpclient
namespace WebApplication1.Controllers
{
  public class FilmController : Controller
  {
    IEFFilmREpository EFFilmREpository;
    public FilmController() { EFFilmREpository = new EFFilmRepository(); }
    public FilmController(IEFFilmREpository eFFilmREpository) => EFFilmREpository = eFFilmREpository;
    [System.Web.Mvc.HttpGet]
    public string GetAll()
    {
      var films = EFFilmREpository.Get();
      string JSON = "[";
      foreach (var film in films)
      {
        var json = JsonConvert.SerializeObject(new
        {
          id = film.id,
          title = film.title,
          description = film.description,
          icon = film.icon,
          trailer = film.trailer,
          year = film.year
        });
        JSON += json;
        JSON += ", ";
      }
      JSON += "]";
      return JSON;
    }

    [System.Web.Mvc.HttpGet]
    public string Get(int id)
    {
      FilmTable film = EFFilmREpository.Get(id);
      if(film == null)
        return "We have not these film";
      return JsonConvert.SerializeObject(new
      {
        id = film.id,
        title = film.title,
        description = film.description,
        icon = film.icon,
        trailer = film.trailer,
        year = film.year
      });
    }

    [System.Web.Mvc.HttpPost]
    [Consumes("application/x-www-form-urlencoded")]
    public string Create(FilmTable film) {
      EFFilmREpository.Create(film);
      return "Done";
    }

    [System.Web.Mvc.HttpPut]
    [Consumes("application/x-www-form-urlencoded")]
    public string Update(int id, FilmTable film)
    {
      if(film == null || film.id != id) return "Empty film";
      var isfilm = EFFilmREpository.Get(id);
      if(isfilm == null) return "There is no such film";
      EFFilmREpository.Update(film);
      return "Done";
    }

    [System.Web.Mvc.HttpDelete]
    public string Delete(int id)
    {
      if(EFFilmREpository.Get(id) == null) return "There is no such film";
      EFFilmREpository.Delete(id);
      return "Done";
    }
  }
}
