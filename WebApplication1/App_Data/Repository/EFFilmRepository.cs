using FilmBase.App_Data.IRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace FilmDataAccess
{
  public class EFFilmRepository : IEFFilmREpository
  {
    public EFFilmRepository() { }
    public List<FilmTable> Get() 
    {
      var toReturn = new List<FilmTable>();
      string connectionString = "Server=DESKTOP-CT758V4\\SQLEXPRESS;Database=FilmDB;Trusted_Connection=True;";
      string sqlExpression = "SELECT  [id] ,[title] ,[description] ,[icon] ,[trailer] ,[year] FROM[FilmDB].[dbo].[FilmTable]";
      SqlConnection connection = new SqlConnection(connectionString);
      connection.Open();
      SqlCommand command = new SqlCommand(sqlExpression, connection);
      using (SqlDataReader reader = command.ExecuteReader())
      {
        if (!reader.HasRows) return toReturn;
        while (reader.Read())
        {
          toReturn.Add(new FilmTable()
          {
            id = Convert.ToInt32(reader.GetValue(0)),
            title = (string)reader.GetValue(1),
            description = (string)reader.GetValue(2),
            icon = (string)reader.GetValue(3),
            trailer = (string)reader.GetValue(4),
            year = Convert.ToDateTime(reader.GetValue(5)),
          });
        }
      }
      if (connection.State == ConnectionState.Open)
      {
        connection.Close();
      }
      return toReturn;
    }
    public FilmTable Get(int id) 
    {
      FilmTable toReturn = null;
      string connectionString = "Server=DESKTOP-CT758V4\\SQLEXPRESS;Database=FilmDB;Trusted_Connection=True;";
      string sqlExpression = "SELECT  [id] ,[title] ,[description] ,[icon] ,[trailer] ,[year] FROM[FilmDB].[dbo].[FilmTable] where [id] = @id";
      SqlConnection connection = new SqlConnection(connectionString);
      connection.Open();
      SqlCommand command = new SqlCommand(sqlExpression, connection);
      command.Parameters.Add(new SqlParameter("@id", id));
      using (SqlDataReader reader = command.ExecuteReader())
      {
        if (!reader.HasRows) return toReturn;
        while (reader.Read())
        {
          toReturn = new FilmTable()
          {
            id = Convert.ToInt32(reader.GetValue(0)),
            title = (string)reader.GetValue(1),
            description = (string)reader.GetValue(2),
            icon = (string)reader.GetValue(3),
            trailer = (string)reader.GetValue(4),
            year = Convert.ToDateTime(reader.GetValue(5)),
          };
        }
      }
      if (connection.State == ConnectionState.Open)
      {
        connection.Close();
      }
      return toReturn;
    }

    public void Create(FilmTable item) 
    {
      string connectionString = "Server=DESKTOP-CT758V4\\SQLEXPRESS;Database=FilmDB;Trusted_Connection=True;";
      string sqlExpression = "insert into [FilmDB].[dbo].[FilmTable] ([title], [description], [icon], [trailer], [year]) values (@title, @description, @icon, @trailer, @year)";
      SqlConnection connection = new SqlConnection(connectionString);
      connection.Open();
      SqlCommand command = new SqlCommand(sqlExpression, connection);
      command.Parameters.Add(new SqlParameter("@title", item.title));
      command.Parameters.Add(new SqlParameter("@description", item.description));
      command.Parameters.Add(new SqlParameter("@icon", item.icon));
      command.Parameters.Add(new SqlParameter("@trailer", item.trailer));
      command.Parameters.Add(new SqlParameter("@year", item.year));
      command.ExecuteNonQuery();
      if (connection.State == ConnectionState.Open)
      {
        connection.Close();
      }
    }
    public void Update(FilmTable item) 
    {
      string connectionString = "Server=DESKTOP-CT758V4\\SQLEXPRESS;Database=FilmDB;Trusted_Connection=True;";
      string sqlExpression = "  update [FilmDB].[dbo].[FilmTable] set [title] = @title, [description] = @description,[icon] = @icon,[trailer] = @trailer,[year] = @year where [id] = @id";
      SqlConnection connection = new SqlConnection(connectionString);
      connection.Open();
      SqlCommand command = new SqlCommand(sqlExpression, connection);
      command.Parameters.Add(new SqlParameter("@id", item.id));
      command.Parameters.Add(new SqlParameter("@title", item.title));
      command.Parameters.Add(new SqlParameter("@description", item.description));
      command.Parameters.Add(new SqlParameter("@icon", item.icon));
      command.Parameters.Add(new SqlParameter("@trailer", item.trailer));
      command.Parameters.Add(new SqlParameter("@year", item.year));
      command.ExecuteNonQuery();
      if (connection.State == ConnectionState.Open)
      {
        connection.Close();
      }
    }
    public void Delete(int id) 
    {
      string connectionString = "Server=DESKTOP-CT758V4\\SQLEXPRESS;Database=FilmDB;Trusted_Connection=True;";
      string sqlExpression = "delete from [FilmDB].[dbo].[FilmTable]  where [id] = @id";
      SqlConnection connection = new SqlConnection(connectionString);
      connection.Open();
      SqlCommand command = new SqlCommand(sqlExpression, connection);
      command.Parameters.Add(new SqlParameter("@id", id));
      command.ExecuteNonQuery();
      if (connection.State == ConnectionState.Open)
      {
        connection.Close();
      }
    }
  }
}
