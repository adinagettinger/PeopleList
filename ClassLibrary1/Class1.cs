using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace ClassLibrary1
{
    public class Person
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
    }
    public class DataBaseManager
    {
        private string _connection;

        public DataBaseManager(string connection)
        {
            _connection = connection;
        }

        public IEnumerable<Person> GetAllPeople()
        {
            SqlConnection connection = new SqlConnection(_connection);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * from people";
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Person> people = new List<Person>();
            while (reader.Read())
            {
                Person p = new Person();
                p.firstName = (string)reader["firstName"];
                p.lastName = (string)reader["lastName"];
                p.age = (int)reader["age"];

                people.Add(p);
            }

            return people;
        }




        public void AddPeople(List<Person> people)
        {
            
            foreach (Person p in people)
            {
                SqlConnection connection = new SqlConnection(_connection);
                SqlCommand command = connection.CreateCommand();

                command.CommandText = "INSERT into people (firstName, lastName, age) values (@firstName, @lastName, @age)";
                command.Parameters.AddWithValue("@firstName", p.firstName);
                command.Parameters.AddWithValue("@lastName", p.lastName);
                command.Parameters.AddWithValue("@age", p.age);


                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                connection.Dispose();
            }
            
           

        }

    }
}
