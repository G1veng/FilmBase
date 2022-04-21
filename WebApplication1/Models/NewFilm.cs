using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
  public class NewFilm
  {
    public int id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public IFormFile icon { get;
      set; }
    public IFormFile trailer { get; set; }
    public DateTime year { get; set; }
  }
}