using Core.Entidades;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.Data.Sqlite;

namespace Infrastructure.DB
{
    public class Repository
    {
        public IEnumerable<Estudiante> GetEstudiantes()
        {
            
            var RandomNombres = new string[] { "Juan", "Maria", "Rodrigo", "Jose", "Marco", "Osvaldo", "Juana", "Rocio", "Lucia", "Mariel", "Tito", "Andres", "Roxana", "Leticia", "Ruth", "Mario", "Miriam", "Ruben", "Daniel", "Omar", "Carlos" };
            var RandomApellidos = new string[] { "Carvajal", "Lopez", "Conde", "Roque", "Rocha", "Martinez", "Lucana", "Arce", "Quintana", "Rodriguez", "Alvarez", "Quispe", "Mamani", "Rojas", "Vaca", "Barba", "Soria", "Gonzales", "Palacios", "Reyes" };
            List<Estudiante> e = new List<Estudiante>();
            for (int i = 0; i < 10; i++)
            {
                var ranNombre = new Random().Next(0, RandomNombres.Count());
                var ranApellido = new Random().Next(0, RandomApellidos.Count());
                var es = new Estudiante()
                {
                    ID_ESTUDIANTE = i + 1,
                    NOMBRES = RandomNombres[ranNombre],
                    APELLIDOS = RandomApellidos[ranApellido],
                    CI = new Random().Next(0000000, 9999999).ToString(),
                    FECHA_NACIMIENTO = new DateTime(new Random().Next(1984, 2000), new Random().Next(1, 12), new Random().Next(1, 31))
                };
                e.Add(es);
                var nom = new List<string>(RandomNombres);
                var ape = new List<string>(RandomApellidos);
                nom.RemoveAt(ranNombre);
                RandomNombres = nom.ToArray();
                ape.RemoveAt(ranApellido);
                RandomApellidos = ape.ToArray();
            }

            return e;
        }

        public IEnumerable<Materia> GetMaterias()
        {
            var connection = new SqliteConnectionStringBuilder();
            connection.DataSource = "Project.sqlite";
            List<Materia> e = new List<Materia>();

            using (var connections = new SqliteConnection(connection.ConnectionString))
            {
                connections.Open();
                var query = connections.CreateCommand();
                query.CommandText = "SELECT * FROM MATERIA";
                using (var reader = query.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        e.Add(new Materia()
                        {
                            ID_MATERIA = Int32.Parse(reader.GetString(0)),
                            SIGLA = reader.GetString(1),
                            NOMBRE = reader.GetString(2)
                        });
                    }
                }
                connections.Close();
            }
                return e;
        }
    }
}
