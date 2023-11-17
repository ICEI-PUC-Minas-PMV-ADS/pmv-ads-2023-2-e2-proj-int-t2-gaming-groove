using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GamingGroove.Controllers
{
	[Authorize]
	public class BaseController : Controller
	{
	}
}


