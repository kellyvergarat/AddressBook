using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AddressBookDB.Interface;
using AddressBookDB.Model;

namespace AddressBook.Controllers
{
    public class HomeController : Controller
    {
        readonly IUserRepository _Repo;
        readonly ModelMapping _ModelMapping;

        public HomeController(IUserRepository Repo, ModelMapping ModelMapping)
        {
            _Repo = Repo;
            _ModelMapping = ModelMapping;
        }

        public ActionResult Index()
        {
            SelectLists ddlFilter = new SelectLists
            {
                AddressBookList = new SelectList((from a in _Repo.GetUser()
                                                  where a.category == "student"
                                                  select new
                                                  {
                                                      Value = a.id,
                                                      Text = a.category
                                                  }).Distinct(), "Value", "Text")
            };
            return View(ddlFilter);
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpGet]
        public ActionResult GetUser(int pageIndex, int pageSize, string sortField = "Id", string sortOrder = "desc")
        {
            IEnumerable<AddressBookDB.User> UserList = null;
            IQueryable<AddressBookDB.User> Query = null;
            IEnumerable<AddressBookDB.Model.DataUser> ResultList = null;

            int itemsCount = 0;
            var param = sortField;
            var propertyInfo = typeof(AddressBookDB.User).GetProperty(param);
            int skip = (pageIndex - 1) * pageSize;

            try
            {
                using (_Repo)
                {
                    Query = _Repo.GetUser();
                    itemsCount = Query.Count();

                    switch (sortField)
                    {
                        case "firstName":
                            if (sortOrder == "asc")
                            {
                                UserList = Query.OrderBy(S => S.firstName);
                            }
                            else if (sortOrder == "desc")
                            {
                                UserList = Query.OrderByDescending(S => S.firstName);
                            }
                            break;
                        case "lastName":
                            if (sortOrder == "asc")
                            {
                                UserList = Query.OrderBy(S => S.lastName);
                            }
                            else if (sortOrder == "desc")
                            {
                                UserList = Query.OrderByDescending(S => S.lastName);
                            }
                            break;
                        default:
                            UserList = Query.OrderByDescending(S => S.id);
                            break;
                    }
                    ResultList = UserList.Skip(skip)
                           .Take(pageSize).ToList().ToList()
                           .Select(T => _ModelMapping.LoadUser(T));

                    var res = UserList.GroupBy(x => x.id).Select(y => y.First());
                }
            }
            #pragma warning disable CS0168 // La variable está declarada pero nunca se usa
            catch (Exception ex)
            #pragma warning restore CS0168 // La variable está declarada pero nunca se usa
            {

            }
            var Result = new { data = ResultList, itemsCount = itemsCount };
            if (Result == null)
            {
                //
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetStudent(int pageIndex, int pageSize, string sortField = "Id", string sortOrder = "desc")
        {
            IEnumerable<AddressBookDB.User> UserList = null;
            IQueryable<AddressBookDB.User> Query = null;
            IEnumerable<AddressBookDB.Model.DataUser> ResultList = null;

            int itemsCount = 0;
            var param = sortField;
            var propertyInfo = typeof(AddressBookDB.User).GetProperty(param);
            int skip = (pageIndex - 1) * pageSize;

            try
            {
                using (_Repo)
                {
                    Query = from a in _Repo.GetUser()
                            where a.category == "Student"
                            select a;

                    itemsCount = Query.Count();

                    switch (sortField)
                    {
                        case "firstName":
                            if (sortOrder == "asc")
                            {
                                UserList = Query.OrderBy(S => S.firstName);
                            }
                            else if (sortOrder == "desc")
                            {
                                UserList = Query.OrderByDescending(S => S.firstName);
                            }
                            break;
                        case "lastName":
                            if (sortOrder == "asc")
                            {
                                UserList = Query.OrderBy(S => S.lastName);
                            }
                            else if (sortOrder == "desc")
                            {
                                UserList = Query.OrderByDescending(S => S.lastName);
                            }
                            break;
                        default:
                            UserList = Query.OrderByDescending(S => S.id);
                            break;
                    }
                    ResultList = UserList.Skip(skip)
                           .Take(pageSize).ToList().ToList()
                           .Select(T => _ModelMapping.LoadUser(T));

                    var res = UserList.GroupBy(x => x.id).Select(y => y.First());
                }
            }
#pragma warning disable CS0168 // La variable está declarada pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable está declarada pero nunca se usa
            {

            }
            var Result = new { data = ResultList, itemsCount = itemsCount };
            if (Result == null)
            {
                //
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetTeacher(int pageIndex, int pageSize, string sortField = "Id", string sortOrder = "desc")
        {
            IEnumerable<AddressBookDB.User> UserList = null;
            IQueryable<AddressBookDB.User> Query = null;
            IEnumerable<AddressBookDB.Model.DataUser> ResultList = null;

            int itemsCount = 0;
            var param = sortField;
            var propertyInfo = typeof(AddressBookDB.User).GetProperty(param);
            int skip = (pageIndex - 1) * pageSize;



            try
            {
                using (_Repo)
                {
                    Query = from a in _Repo.GetUser()
                            where a.category == "Teacher"
                            select a;

                    itemsCount = Query.Count();

                    switch (sortField)
                    {
                        case "firstName":
                            if (sortOrder == "asc")
                            {
                                UserList = Query.OrderBy(S => S.firstName);
                            }
                            else if (sortOrder == "desc")
                            {
                                UserList = Query.OrderByDescending(S => S.firstName);
                            }
                            break;
                        case "lastName":
                            if (sortOrder == "asc")
                            {
                                UserList = Query.OrderBy(S => S.lastName);
                            }
                            else if (sortOrder == "desc")
                            {
                                UserList = Query.OrderByDescending(S => S.lastName);
                            }
                            break;
                        default:
                            UserList = Query.OrderByDescending(S => S.id);
                            break;
                    }
                    ResultList = UserList.Skip(skip)
                           .Take(pageSize).ToList().ToList()
                           .Select(T => _ModelMapping.LoadUser(T));

                    var res = UserList.GroupBy(x => x.id).Select(y => y.First());
                }
            }
#pragma warning disable CS0168 // La variable está declarada pero nunca se usa
            catch (Exception ex)
#pragma warning restore CS0168 // La variable está declarada pero nunca se usa
            {

            }
            var Result = new { data = ResultList, itemsCount = itemsCount };
            if (Result == null)
            {
                //
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        /*
        [HttpPost]
        public ActionResult PostUser(User user)
        {
            try
            {
                using (_Repo)
                {
                    //_Repo.AddUser(user);
                }

                return Json(new { success = true, message = "User added successfully." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error adding user: " + ex.Message });
            }
        }*/

    }
}