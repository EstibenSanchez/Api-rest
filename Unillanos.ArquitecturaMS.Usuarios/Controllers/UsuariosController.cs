using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Unillanos.ArquitecturaMS.Usuarios.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        [HttpGet]
        [Route("LeerPerfil/{id}")]

        public string Get(int id) {
            return id switch
            {
                1=> "Ivan",
                2=> "Brayan",
                _ => throw new NotSupportedException("El id no es valido")
            };
        }

        [HttpGet]
        [Route("Usuarios")]
        public UsuariosDto GetUsers()
        {
            string fileName = "Usuarios.json";
            string json = System.IO.File.ReadAllText(fileName);
            UsuariosDto users = JsonSerializer.Deserialize<UsuariosDto>(json);
            return users;

        }

        [HttpPost]
        [Route("insertarusuario")]

        public string Post(UsuariosDto usuarios)
        {
            string fileName = "Usuarios.json";
            string jsonString = JsonSerializer.Serialize(usuarios);
            System.IO.File.WriteAllText(fileName, jsonString);
            

            // Console.WriteLine(File.ReadAllText(fileName));
            return usuarios.nombre;
        }

     


        public class UsuariosDto { 
            public string nombre { get; set; }
            public string apellido { get; set; }
            public string sexo { get; set; }
            public string correo { get; set; }
            public int telefono { get; set; }
            public int edad { get; set; }

        }
    }
}
