using System.Collections.Generic;
using FilmDataAccess;

namespace FilmBase.App_Data.IRepository
{

  public interface IEFFilmREpository
  {
    List<FilmTable> Get();
    FilmTable Get(int id);
    void Create(FilmTable item);
    void Update(FilmTable item);
    void Delete(int id);
  }
}
