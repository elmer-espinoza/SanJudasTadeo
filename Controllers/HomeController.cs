using Microsoft.AspNetCore.Mvc;
using RegistroPacientes.Models;
using System.Diagnostics;
using System.Drawing;

namespace RegistroPacientes.Controllers 
{
    public class HomeController : Controller
    {

        private readonly PacienteContext _dbContext;
        public HomeController(PacienteContext dbcontext) { _dbContext = dbcontext; }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Listar()
        {
            return View(_dbContext.Pacientes.OrderBy(e => e.app_pate));
        }
        public IActionResult Crear()
        {
            return View(new Paciente() { } );
        }

        [HttpPost]
        public IActionResult Crear(Paciente paciente)
        {
            _dbContext.Pacientes.Add(paciente);
            _dbContext.SaveChanges();
            return RedirectToAction("Listar");
        }
        public IActionResult Eliminar(int id)
        {
            return View(_dbContext.Pacientes.FirstOrDefault(e => e.cod_pac == id ));
        }

        [HttpPost]
        public IActionResult Eliminar(Paciente paciente)
        {
            _dbContext.Pacientes.Remove(paciente);
            _dbContext.SaveChanges();
            return RedirectToAction("Listar");
        }

        public IActionResult Editar(int id)
        {
            return View(_dbContext.Pacientes.FirstOrDefault(e => e.cod_pac == id));
        }

        [HttpPost]
        public IActionResult Editar(Paciente paciente)
        {
            _dbContext.Pacientes.Update(paciente);
            _dbContext.SaveChanges();
            return RedirectToAction("Listar");
        }

        public IActionResult Detalles(int id)
        {
            return View(_dbContext.Pacientes.FirstOrDefault(e => e.cod_pac == id));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}