using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using Pan.BLL;
using loan.Common;
using loan.ActionFilter;
using Pan.DBUtility;
using System.Text;



namespace loan.Controllers
{



    public class AdminController : AdminActionFilter
    {



        Affiliate affiliate = new Affiliate();
        Credit cre = new Credit();
        Investment inves = new Investment();
        Feedback fb = new Feedback();
        News news = new News();
        Questions q = new Questions();
        FooterSEO footerseo = new FooterSEO();
        account account = new account();
        StringBuilder strSql;

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult News()
        {

            return View();
        }

        public ActionResult GetNews()
        {

            strSql = new StringBuilder();
            strSql.Append("select id,title,isTop,isReco,type,time ");
            strSql.Append("from News order by convert(datetime,[time]) desc");

            return GetModelList(null, DbHelperSQL.Query(strSql.ToString()).Tables[0]);

        }

        public ActionResult NewsView(int id)
        {

            return View(news.GetModel(id));
        }

        public ActionResult Addnews()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult EditNews(Pan.Model.News model)
        {
            if (!ModelState.IsValid)
            {
                return Content(JavaScriptHandler.AlertAndBack("数据验证错误,请检查!"));
            }



            if (model.isTop == null)
            {
                model.isTop = "否";
            }
            if (model.isReco == null)
            {
                model.isReco = "否";
            }

            if (string.IsNullOrEmpty(model.id.ToString()) || model.id.ToString() == "0")
            {
                news.Add(model);
            }
            else
            { news.Update(model); }



            return RedirectToAction("News");


        }
        [HttpPost]
        public ActionResult DelNews(string idlist)
        {

            news.DeleteList(idlist);
            return Content("删除成功了~~~");
        }



        public ActionResult SiteSet()
        {

            return View();
        }

        public ActionResult PageSet()
        {

            return View();
        }

        public ActionResult GetPageSet()
        {


            strSql = new StringBuilder();
            strSql.Append("select id,[column]");
            strSql.Append(" FROM PageSet order by id desc");

            return GetModelList(null, DbHelperSQL.Query(strSql.ToString()).Tables[0]);

        }

        public ActionResult PageSetModel(int id)
        {

            Pan.BLL.PageSet ps = new PageSet();

            return View(ps.GetModel(id));
        }

        public ActionResult PageSetEdit(Pan.Model.PageSet model)
        {
            Pan.BLL.PageSet ps = new PageSet();
            ps.Update(model);

            return RedirectToAction("pageset");

        }

        public ActionResult Credit()
        {

            return View();
        }

        public ActionResult GetCredit()
        {
            Pan.DAL.Credit cr = new Pan.DAL.Credit();

            return GetModelList(null, cr.GetList("").Tables[0]);
        }
        [HttpPost]
        public ActionResult DelCredit(string idlist)
        {

            cre.DeleteList(idlist);
            return Content("删除成功了~~~");
        }


        public ActionResult Investment()
        {

            return View();
        }

        public ActionResult GetInves()
        {


            strSql = new StringBuilder();
            strSql.Append("select id,name,sex,mobile_num,i_num,limit_date,time ");
            strSql.Append(" FROM Investment order by id desc ");
            return GetModelList(null, DbHelperSQL.Query(strSql.ToString()).Tables[0]);


        }
        [HttpPost]
        public ActionResult DelInves(string idlist)
        {

            inves.DeleteList(idlist);
            return Content("删除成功了~~~");
        }

        public ActionResult Affiliate()
        {

            return View();
        }

        public ActionResult GetAffList()
        {

            strSql = new StringBuilder();
            strSql.Append("select id,enterprise,enterprise_type,person,person_post,mobile_num,time ");
            strSql.Append(" FROM Affiliate ");

            strSql.Append(" order by id desc ");
            return GetModelList(null, DbHelperSQL.Query(strSql.ToString()).Tables[0]);

        }

        [HttpPost]
        public ActionResult DelAffliate(string idlist)
        {
            affiliate.DeleteList(idlist);
            return Content("删除成功了~~~");
        }

        public ActionResult Feedback()
        {

            return View();
        }

        public ActionResult GetFeedback()
        {


            strSql = new StringBuilder();
            strSql.Append("select id,name,sex,mobile_num,content,time ");
            strSql.Append(" FROM Feedback ");
            strSql.Append(" order by id desc ");
            return GetModelList(null, DbHelperSQL.Query(strSql.ToString()).Tables[0]);

        }
        [HttpPost]
        public ActionResult DelFB(string idlist)
        {

            fb.DeleteList(idlist);
            return Content("删除成功了~~~");
        }


        [HttpPost]
        public ActionResult GetFBContent(int id)
        {

            return Content(fb.GetModel(id).content);
        }

        public ActionResult ql()
        {


            return View();
        }

        public ActionResult addq()
        {
            return View();
        }

        public ActionResult Getql()
        {
            strSql = new StringBuilder();
            strSql.Append("select id,title ");
            strSql.Append(" FROM Questions ");
            strSql.Append(" order by id desc ");
            return GetModelList(null, DbHelperSQL.Query(strSql.ToString()).Tables[0]);
        }

        public ActionResult QView(int id)
        {

            Pan.Model.Questions model = q.GetModel(id);

            return View(model);


        }
        [ValidateInput(false)]
        public ActionResult Editq(Pan.Model.Questions model)
        {

            if (string.IsNullOrEmpty(model.id.ToString()) || model.id.ToString() == "0")
            {
                q.Add(model);
            }
            else
            { q.Update(model); }


            return RedirectToAction("ql");
        }
        [HttpPost]
        public ActionResult DelQ(string idlist)
        {

            q.DeleteList(idlist);
            return RedirectToAction("ql");
        }


        public ActionResult FooterSEO()
        {
            return View();
        }

        public ActionResult addFooterSEO()
        {
            return View();
        }

        public ActionResult DelFooterSEO(string id)
        {
            if (id == null || id == "")
            {
                return Content("参数错误");
            }
            footerseo.Delete(int.Parse(id));
            return Content("删除成功了~~~");
        }

        public ActionResult GetFootSEOList()
        {
            return null;
        }

        public ActionResult Accounts()
        {

            return View();
        }

        public ActionResult AccountView(int id)
        {

            return View(account.GetModel(id));
        }

        [HttpPost]
        public ActionResult AccountDelete(string idlist)
        {

            account.DeleteList(idlist);
            return Content("铲除成功");
        }

        public ActionResult AccountAdd()
        {

            return View();
        }

        public ActionResult AccountEdit(Pan.Model.account model)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            model.pwd = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(model.pwd)));
            if (string.IsNullOrEmpty(model.id.ToString()) || model.id == 0)
            {
                account.Add(model);

            }
            else
            {
                account.Update(model);
            }

            return RedirectToAction("Accounts");
        }


        public ActionResult GetAccountsList()
        {
            strSql = new StringBuilder();
            strSql.Append("select id,uid ");
            strSql.Append(" FROM account ");

            strSql.Append(" order by id asc ");
            return GetModelList(null, DbHelperSQL.Query(strSql.ToString()).Tables[0]);

        }




        #region 登录
        [NoRedirect]
        public ActionResult Login()
        {
            return View();
        }

        //登录到Index
        [NoRedirect]
        public ActionResult LoginTo()
        {
            string v1 = Request.Form["validatecode"].ToString().ToUpper();
            string v2 = Session["ValidateNum"].ToString();

            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            string pwd = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(Request.Form["password"])));

            if (v1 == v2)
            {
                account account = new account();
                string where = " [uid]='" + Request.Form["username"] + "' and pwd='" + pwd + "'"; ;
                if (account.GetList(where).Tables[0].Rows.Count < 1)
                {
                    return Content(JavaScriptHandler.AlertAndRedirect("账号或密码错误", "/admin/login"));

                }
                else
                {
                    Response.Cookies["userName"].Value = Request.Form["username"];
                    Response.Cookies["userName"].Expires = DateTime.Now.AddDays(1);
                    return RedirectToAction("index");
                }
            }
            else
            {


                return Content(JavaScriptHandler.AlertAndRedirect("验证码错误", "/admin/login"));
            }


        }

        //创建验证码
        [NoRedirect]
        public FileContentResult CreateValidateCode()
        {
            ValidateCode vc = new ValidateCode();
            string validateNum = vc.CreateVerifyCode(4);

            Session["ValidateNum"] = validateNum.ToUpper();
            return File(vc.CreateImageCode(validateNum).GetBuffer(), "image/JPEG");
        }

        #endregion

        #region 返回JSON
        public JsonResult GetModelList(int? secho, System.Data.DataTable dt)
        {

            DataTableTo dtt = new DataTableTo();
            return Json(new
                {
                    sEcho = secho,
                    iTotalRecords = dt.Rows.Count,
                    aaData = dtt.DataTableToList(dt)
                }, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }


}
