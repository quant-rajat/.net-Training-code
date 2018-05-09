using Library.Contracts.Services;
using Library.Library.Attributes;
using Library.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Library.Controllers
{
    
    [LibraryAuthorize("Admin")]
    public class UserController : Controller
    {
        IUserServices userService;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public UserController(IUserServices UserService)
        {
            this.userService = UserService;
        }

        public UserController()
        {
        }


        // GET: User
        [HttpGet]
        //[Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        //[Authorize]
       
        public ActionResult GetIssueHistory(string id)
        {
            return PartialView(userService.UserHistory(id));
        }

        [HttpPost]
        //[Authorize]
        
        async public Task<ActionResult> GetAllUsers(int pagenumber, int rowcount)
        {
            if (!ModelState.IsValid)
            {
               // return BadRequest(ModelState);
            }
            // UserService's method  -> GetAllUsers will returns row_count (2 as default in this case) number of existing users in server 
          //  log.Info("HEllo world in logger");
            PagedResults<User> result = await userService.GetAllUserAsync(pagenumber, rowcount);

            return Json(result);
           // return View(UserService.GetAllUser());
        }




        /*---------------dummy function for testing -----------------*/
        public ActionResult GetResult(int a)
        {
            return Json(a);
        }
    }
}