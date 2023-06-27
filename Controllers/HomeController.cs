using Microsoft.AspNetCore.Mvc;

using TPLOCAL1.Models;

//Subject is find at the root of the project and the logo in the wwwroot/ressources folders of the solution
//--------------------------------------------------------------------------------------
//Careful, the MVC model is a so-called convention model instead of configuration,
//The controller must imperatively be name with "Controller" at the end !!!
namespace TPLOCAL1.Controllers
{
    public class HomeController : Controller
    {
        //method "naturally" call by router
        public ActionResult Index(string id)
        {
            Opinion opinion = new Opinion();
            if (string.IsNullOrWhiteSpace(id))
                //return to the Index view (see routing in Program.cs)
                return View(opinion);
            else
            {
                //Call different pages, according to the id pass as parameter
                switch (id)
                {
                    case "OpinionList":
                        //TODO : code reading of the xml files provide
                        return View(id);
                    case "Form":
                        //TODO : call the Form view with data model empty
                        return View(id);
                    default:
                        //return to the Index view (see routing in Program.cs)
                        return View();
                }
            }
        }


        //methode to send datas from form to validation page
        [HttpPost]

        public ActionResult ValidationFormulaire(Opinion opinion)
        {
            if (ModelState.IsValid)
            {
                // TempData["ValidationSuccess"] = true;
                // TempData["SuccessMessage"] = "All right!";

                // opinion.NameIsReadOnly = true;
                // opinion.ForenameIsReadOnly = true;
                return RedirectToAction("FormCheck", opinion);
            }
            else
            {
                // TempData["ErrorMessage"] = "Please fill in all the fields correctly.";
                return View("Form", opinion); 
            }
        }

        public ActionResult Result(Opinion opinion)
        {
            return View(opinion);
        }

        


    }
}