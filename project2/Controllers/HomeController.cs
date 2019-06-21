using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project2.Models;


namespace project2.Controllers
{
    public class HomeController : Controller
    {

        UserLoginEntities db = new UserLoginEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UploadFile()
        {
            return View();
        }

        public ActionResult Echarts()
        {
            return View();
        }

        //會員登入///////////////////////////////////////
        public ActionResult IndexLogin()
        {

            return View();
        }

        [HttpPost]
        public ActionResult IndexLogin(string JobNumber, string password)
        {


            // ModelState.IsValid，通過表單驗證（Server-side validation）需搭配 Model底下類別檔的 [驗證]
            if ((JobNumber == null) && (!ModelState.IsValid))
            {
                return View();

            }

            var ListOne = from m in db.db_user
                          where m.JobNumber == JobNumber && m.UserPassword == password
                          select m;

            db_user result = ListOne.FirstOrDefault();  // 執行上面的查詢句，得到結果。
            if (result == null)
            {   // 失敗。找不到這一筆記錄
                //return HttpNotFound();
                //return Content("<h3>登入失敗！！</h3>");
                //return Content("no");
                return RedirectToAction("IndexLogin");
            }
            else
            {
                if (JobNumber == "admin" && password == "admin")
                {
                    Session["Login"] = JobNumber;
                    //return Content("BOSS");

                    // return RedirectToAction("IndexAdmin");
                    return RedirectToAction("Dashboard1");
                }


                else
                {
                    // 成功。
                    Session["Login"] = JobNumber;
                    // return Content("OK");
                    return RedirectToAction("Dashboard1");
                    //return RedirectToAction("IndexDashboard");

                }
            }





        }

        //後台管理頁面
        public ActionResult IndexAdmin()
        {
            if (Session["Login"].ToString() != "admin")
            {
                return RedirectToAction("IndexLogin");
            }
            return RedirectToAction("MemberTable1");

        }

        public ActionResult dashboard()
        {

            return View();
        }

        public ActionResult Dashboard()
        {

            return View();
        }


        public ActionResult MemberTable()
        {
            var query = from o in db.db_user
                            //where o.abArea == "taipei"
                            //orderby o.abNo descending
                            //where o.abDate == "2000-01-01"
                        select o;

            return View(query.ToList());
        }

        //登出
        public ActionResult signOut()
        {
            Session["who"] = "";
            Session["team"] = "";
            Session["member"] = "";
            return Redirect("~/Home/index");
        }


        public ActionResult Card()
        {
            return View();
        }


        public ActionResult TestUpload()
        {
            return View();
        }



        //修改
        //public ActionResult Edit()
        //{

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Edit(int id)
        //{
        //    //db.Entry(p).State = System.Data.Entity.EntityState.Modified;
        //    var query = from o in db.db_user
        //                where o.ID == id
        //                select o;
        //    Models.db_user edit = query.FirstOrDefault();
        //    return View(edit);
        //    //Server
        //    //ServerLYmd = j.Ymd;
        //    //ServerLogin.UserId = log_In.UserId;
        //    edit.UserName = id.UserName;
        //    ServerLogin.UserPassword = log_In.UserPassword;
        //    ServerLogin.UserPhone = log_In.UserPhone;
        //    ServerLogin.UserEmail = log_In.UserEmail;

        //    DB.SaveChanges();
        //    return Redirect("/Flower/List");
        //    // return RedirectToAction("List");
        //    //return Content("OK");
        //}

        //    //修改名單
        //    public ActionResult amendForm()
        //    {
        //        if (Session["who"] == "")
        //        {
        //            return Redirect("~/Home/signIn");
        //        }
        //        //return Content(Session["team"].ToString());
        //        string team = Session["team"].ToString();
        //        var query = from o in db.playerForms
        //                    where o.formTeam == team
        //                    select o;
        //        return View(query.ToList());
        //        //return Content(query.FirstOrDefault().formCoach);  test OK
        //    }
        //    [HttpPost]
        //    public ActionResult amendForm(playerForm amend)
        //    {
        //        string team = Session["team"].ToString();
        //        var query = (from o in db.playerForms
        //                     where o.formContest == amend.formContest && o.formTeam == team
        //                     select o).FirstOrDefault();

        //        query.formCoach = amend.formCoach;
        //        query.formEmail = amend.formEmail;
        //        query.formPhone = amend.formPhone;
        //        query.formPlay_1 = amend.formPlay_1;
        //        query.formPlay_2 = amend.formPlay_2;
        //        query.formPlay_3 = amend.formPlay_3;
        //        query.formPlay_4 = amend.formPlay_4;
        //        query.formPlay_5 = amend.formPlay_5;
        //        query.formPlay_6 = amend.formPlay_6;
        //        query.formPlay_7 = amend.formPlay_7;
        //        query.formPlay_8 = amend.formPlay_8;
        //        query.formPlay_9 = amend.formPlay_9;
        //        query.formPlay_10 = amend.formPlay_10;
        //        query.formPlay_11 = amend.formPlay_11;
        //        query.formPlay_12 = amend.formPlay_12;
        //        query.formPlay_13 = amend.formPlay_13;
        //        query.formPlay_14 = amend.formPlay_14;
        //        query.formPlay_15 = amend.formPlay_15;
        //        query.formPlay_16 = amend.formPlay_16;
        //        query.formPlay_17 = amend.formPlay_17;
        //        query.formPlay_18 = amend.formPlay_18;
        //        query.formPlay_19 = amend.formPlay_19;
        //        query.formPlay_20 = amend.formPlay_20;

        //        db.SaveChanges();
        //        return Redirect("~/Home/amendForm#pForm");
        //    }



        //}

        public ActionResult Dashboard1()
        {
            return View();
        }



        public ActionResult MemberTable1()
        {
            var query = from o in db.db_user
                            //where o.abArea == "taipei"
                            //orderby o.abNo descending
                            //where o.abDate == "2000-01-01"
                        select o;

            return View(query.ToList());

        }

        public ActionResult Camera()
        {
            return View();
        }

        public ActionResult SupplierA()
        {
            return View();
        }

        public ActionResult SupplierB()
        {
            return View();
        }

        public ActionResult SupplierC()
        {
            return View();
        }



    }
}