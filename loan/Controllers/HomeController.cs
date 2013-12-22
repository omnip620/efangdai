using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pan.BLL;


using System.Text;
using System.Data;


namespace loan.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: 
        News news = new News();

        public ActionResult Index()
        {
            string sql = "select top(6) id,title,summary from news where type='易房动态' order by  isTop desc, CONVERT(datetime,[time]) desc";
            ViewData["yfdt"] = news.GetListByCustom(sql).Tables[0];

            string sql2 = "select top(6) id,title,summary from news where type='行业资讯'  order by isTop desc,CONVERT(datetime,[time]) desc";
            ViewData["hyzx"] = news.GetListByCustom(sql2).Tables[0];

            string sql3 = "select title,keywords,description from PageSet where [column]='首页' order by id desc";
            DataTable dt = news.GetListByCustom(sql3).Tables[0];
            ViewBag.Title = dt.Rows[0][0];
            ViewBag.Keywords = dt.Rows[0][1];
            ViewBag.Description = dt.Rows[0][2];

            string sql4 = "select top(6) id,title from Questions order by id desc";
            ViewData["question"] = news.GetListByCustom(sql4).Tables[0];


            return View();
        }

        public ActionResult error()
        {
            return View();
        }

        public ActionResult Safe()
        {
            string sql3 = "select title,keywords,description from PageSet where [column]='安全保障'";

            ViewBag.Title = news.GetListByCustom(sql3).Tables[0].Rows[0][0];
            ViewBag.Keywords = news.GetListByCustom(sql3).Tables[0].Rows[0][1];
            ViewBag.Description = news.GetListByCustom(sql3).Tables[0].Rows[0][2];
            return View();
        }

        public ActionResult News(int id = 1)
        {
            if (id.ToString() != "1")
            {
                string sql = "select top(5) id,title from news  order by isTop desc,CONVERT(datetime,[time]) desc";
                ViewData["gxq"] = news.GetListByCustom(sql).Tables[0];


                string sql2 = "select top(1) id,title from news where id<'" + id + "'  order by isTop desc,CONVERT(datetime,[time]) desc";
                ViewData["p_newsid"] = news.GetListByCustom(sql2).Tables[0].Rows[0][0].ToString();
                ViewData["p_newst"] = news.GetListByCustom(sql2).Tables[0].Rows[0][1].ToString();


                string sql4 = "select top(1) id,title from news where id>'" + id + "'  order by isTop desc,CONVERT(datetime,[time]) desc";
                ViewData["n_link"] = "<a href=\"javascript:(0)\"  target=\"_self\">没有数据了</a>";

                if (news.GetListByCustom(sql4).Tables[0].Rows.Count > 0)
                {
                    string n_newsid = news.GetListByCustom(sql4).Tables[0].Rows[0][0].ToString();
                    string n_newst = news.GetListByCustom(sql4).Tables[0].Rows[0][1].ToString();
                    ViewData["n_link"] = "<a href=\"/news/" + n_newsid + ".html\"  target=\"_self\">" + n_newst + "</a>";
                }


                return View("NewsDetails", news.GetModel(id));


            }

            //TODO: 置顶,
            /*先查出相应栏目的制定的条目数,
             */
            string sql_hyzx = NewsSql(5, "行业资讯");
            ViewData["hyzx"] = news.GetListByCustom(sql_hyzx).Tables[0];

            string sql_yfzx = NewsSql(5, "易房动态");
            ViewData["yfdt"] = news.GetListByCustom(sql_yfzx).Tables[0];

            string sql_hgjd = NewsSql(5, "宏观经济解读");
            ViewData["hgjd"] = news.GetListByCustom(sql_hgjd).Tables[0];

            string sql_glsy = NewsSql(5, "管理新视野");
            ViewData["glsy"] = news.GetListByCustom(sql_glsy).Tables[0];

            string sql3 = "select title,keywords,description from PageSet where [column]='易房资讯' ";
            DataTable dt = news.GetListByCustom(sql3).Tables[0];
            ViewBag.Title = dt.Rows[0][0];
            ViewBag.Keywords = dt.Rows[0][1];
            ViewBag.Description = dt.Rows[0][2];

            return View();
        }

        public string NewsSql(int top, string type)
        {
            string sql = "select top(" + top + ") id,title from news where type ='" + type + "' order by isTop desc,CONVERT(datetime,[time]) desc";
            return sql;

        }

        public ActionResult GetNewsList()
        {


            return View();
        }

        private void NewsListByType(string type)
        {
            Pan.BLL.PageSet ps = new PageSet();
            System.Data.DataRow dr;

            StringBuilder sql = new StringBuilder();
            sql.Append("select title,keywords,description from PageSet where [column]='");
            sql.Append(type);
            sql.Append("'");
            dr = ps.GetPSByCus(sql.ToString()).Tables[0].Rows[0];
            ViewBag.Title = dr[0];
            ViewBag.Keywords = dr[1];
            ViewBag.Description = dr[2];
            ViewBag.h3 = type;


        }

        public ActionResult News_list(string type, int pageIndex)
        {
            
            
            switch (type)
            {
                case "行业资讯":
                    NewsListByType("行业资讯");
                    break;
                case "易房动态":
                    NewsListByType("易房动态");
                    break;
                case "宏观经济解读":
                    NewsListByType("宏观经济解读");
                    break;
                case "管理新视野":
                    NewsListByType("管理新视野");
                    break;
            }



            ViewData["page"] = pageIndex;
            ViewData["type"] = type;

            int pageSize = 10; //每页几条数据
            int count = news.GetRecordCount(" type='" + type + "'"); //总数据
            int pageTotal = (count / pageSize); //总页数
            if (count % pageSize != 0)
            {
                pageTotal = pageTotal + 1;

            }
            int currentPage = 1;
            int sql_PI = pageIndex - 1;
            StringBuilder sql_select = new StringBuilder();
            sql_select.Append("select id,title,source,time from (");
            sql_select.Append("select id,title,source,time,isTop,Row_number() over(order by isTop desc, CONVERT(datetime,[time]) desc ) as IDRank from (");
            sql_select.Append("select  top 100 percent id,isTop,title,source,time from News ");
            sql_select.Append(" where type='");
            sql_select.Append(type);
            sql_select.Append("' order by  isTop desc, CONVERT(datetime,[time]) desc) as t1) as IDWithRowNumber  where IDRank>");
            sql_select.Append(pageSize * sql_PI);
            sql_select.Append(" and IDRank< ");
            sql_select.Append((pageSize * (sql_PI + 1)) + 1);
            sql_select.Append("  order by  isTop desc, CONVERT(datetime,[time]) desc ");

            ViewData["newslist"] = news.GetListByCustom(sql_select.ToString()).Tables[0];

            StringBuilder link = new StringBuilder();

            currentPage = currentPage < 1 ? 1 : pageIndex;

            if (pageTotal > 1)
            {
                if (currentPage != 1)
                {//处理首页链接
                    link.Append("<a href=\"/news_list/" + type + "_1.html\" target=\"_self\">&lt;&lt;</a>");

                }
                else if (currentPage == 1)
                {
                    link.Append("<a href >&lt;&lt;</a>");

                }


                if (currentPage > 1)
                {
                    link.Append("<a href=\"/news_list/" + type + "_" + (currentPage - 1).ToString() + ".html\"  target=\"_self\">&lt;</a>");
                }
                else
                {
                    link.Append("<a href=\"javascript:;\">&lt;</a>");
                }
                int currint = 5;
                for (int i = 0; i <= 10; i++)
                {
                    if ((currentPage + i - currint) >= 1 && (currentPage + i - currint) <= pageTotal)
                    {
                        if (currint == i)
                        {
                            //当前页处理    
                            link.Append("<a href class=\"on\">" + currentPage.ToString() + "</a>");
                        }
                        else
                        {   //一般页处理
                            link.Append("<a href=\"/news_list/" + type + "_" + (currentPage + i - currint).ToString() + ".html\"");
                            link.Append("class=\"num\"  target=\"_self\">" + (currentPage + i - currint).ToString() + "</a>");
                        }

                    }

                }

                if (currentPage < pageTotal)
                {
                    //处理下一页的链接   
                    link.Append("<a href=\"/news_list/" + type + "_" + (currentPage + 1).ToString() + ".html\"  target=\"_self\">&gt;</a>");
                }
                else
                {
                    link.Append("<a href>&gt;</a>");
                }

                if (currentPage != pageTotal)
                {
                    link.Append("<a href=\"/news_list/" + type + "_" + pageTotal + ".html\"  target=\"_self\">&gt;&gt;</a>");
                }
                if (currentPage == pageTotal)
                {
                    link.Append("<a >&gt;&gt;</a>");
                }

            }

            ViewData["link"] = link.ToString();

            return View();
        }

        public ActionResult NewsDetails()
        {
            return View();
        }

        public ActionResult Partner()
        {
            string sql3 = "select title,keywords,description from PageSet where [column]='机构合作'";

            ViewBag.Title = news.GetListByCustom(sql3).Tables[0].Rows[0][0];
            ViewBag.Keywords = news.GetListByCustom(sql3).Tables[0].Rows[0][1];
            ViewBag.Description = news.GetListByCustom(sql3).Tables[0].Rows[0][2];

            return View();
        }

        public ActionResult AffiliApply()
        {
            Affiliate af = new Affiliate();
            Pan.Model.Affiliate model = new Pan.Model.Affiliate();
            model.mobile_num = Request.Form["shouji"];
            model.enterprise_type = Request.Form["txt_type"];
            model.enterprise = Request.Form["txt_corp"];
            model.time = DateTime.Now.ToString();
            model.person = Request.Form["txt_name"];
            model.person_post = Request.Form["txt_office"];
            af.Add(model);

            loan.Models.common.MailSender ms = new Models.common.MailSender();
            StringBuilder body = new StringBuilder();
            body.Append("<div>企业类型:");
            body.Append(model.enterprise_type);
            body.Append("</div>");
            body.Append("<div>企业名称:");
            body.Append(model.enterprise);
            body.Append("</div>");
            body.Append("<div>联系人:");
            body.Append(model.person);
            body.Append("</div>");
            body.Append("<div>联系人职务:");
            body.Append(model.person_post);
            body.Append("</div>");
            body.Append("<div>手机号码:");
            body.Append(model.mobile_num);
            body.Append("</div>");

            body.Append("<div>申请日期:");
            body.Append(model.time);
            body.Append("</div>");

            ms.send("加盟申请", body.ToString());

            return Content("<script>alert('申请成功,我们的工作人员会尽快跟您联系。');window.location='/Partner.html';</script>");
        }

        public ActionResult AboutUs()
        {
            string sql3 = "select title,keywords,description from PageSet where [column]='关于易房'";

            ViewBag.Title = news.GetListByCustom(sql3).Tables[0].Rows[0][0];
            ViewBag.Keywords = news.GetListByCustom(sql3).Tables[0].Rows[0][1];
            ViewBag.Description = news.GetListByCustom(sql3).Tables[0].Rows[0][2];


            return View();
        }

        public ActionResult About_Media()
        {
            return View();
        }

        public ActionResult About_Notice()
        {
            return View();
        }

        public ActionResult About_Contactus()
        {
            string sql3 = "select title,keywords,description from PageSet where [column]='加入易房'";

            ViewBag.Title = news.GetListByCustom(sql3).Tables[0].Rows[0][0];
            ViewBag.Keywords = news.GetListByCustom(sql3).Tables[0].Rows[0][1];
            ViewBag.Description = news.GetListByCustom(sql3).Tables[0].Rows[0][2];
            return View();
        }

        public ActionResult Helps()
        {
            string sql3 = "select title,keywords,description from PageSet where [column]='帮助中心'";

            ViewBag.Title = news.GetListByCustom(sql3).Tables[0].Rows[0][0];
            ViewBag.Keywords = news.GetListByCustom(sql3).Tables[0].Rows[0][1];
            ViewBag.Description = news.GetListByCustom(sql3).Tables[0].Rows[0][2];


            string sql = "select id,title from Questions";
            ViewData["question"] = news.GetListByCustom(sql).Tables[0];


            return View();
        }

        public ActionResult HelpsList()
        {
            return View();
        }

        public ActionResult Jikedai()
        {
            string sql3 = "select title,keywords,description from PageSet where [column]='我要贷款'";

            DataTable dt = news.GetListByCustom(sql3).Tables[0];
            ViewBag.Title = dt.Rows[0][0];
            ViewBag.Keywords = dt.Rows[0][1];
            ViewBag.Description = dt.Rows[0][2];
            string sql_question = "select top(8) id,title from questions order by id desc";
            ViewData["questions"] = news.GetListByCustom(sql_question).Tables[0];
            return View();
        }

        

        public ActionResult CreditApply()
        {
            Credit c = new Credit();
            Pan.Model.Credit credit = new Pan.Model.Credit();
            credit.mobile_num = Request.Form["shouji"];
            credit.name = Request.Form["chengwei"];
            credit.sex = Request.Form["gender"];
            credit.time = DateTime.Now.ToString();
            credit.limit_date = Request.Form["qixian"];
            credit.collateral = Request.Form["diyawu"];
            credit.i_num = int.Parse(Request.Form["amount"]);
            c.Add(credit);
            loan.Models.common.MailSender ms = new Models.common.MailSender();
            StringBuilder body = new StringBuilder();
            body.Append("<div>姓名:");
            body.Append(Request.Form["chengwei"]);
            body.Append("</div>");
            body.Append("<div>性别:");
            body.Append(Request.Form["gender"]);
            body.Append("</div>");
            body.Append("<div>联系方式:");
            body.Append(Request.Form["shouji"]);
            body.Append("</div>");
            body.Append("<div>抵押物:");
            body.Append(Request.Form["diyawu"]);
            body.Append("</div>");
            body.Append("<div>贷款金额:");
            body.Append(Request.Form["amount"]);
            body.Append("</div>");
            body.Append("<div>贷款期限:");
            body.Append(Request.Form["qixian"]);
            body.Append("</div>");
            body.Append("<div>申请日期:");
            body.Append(credit.time);
            body.Append("</div>");

            ms.send("贷款申请", body.ToString());
            return Content("<script>alert('申请成功,我们的工作人员会尽快跟您联系。');window.location='/Jikedai.html';</script>");

        }

        public ActionResult Zhiyingbao()
        {
            string sql3 = "select title,keywords,description from PageSet where [column]='我要理财'";

            DataTable dt = news.GetListByCustom(sql3).Tables[0];
            ViewBag.Title = dt.Rows[0][0];
            ViewBag.Keywords = dt.Rows[0][1];
            ViewBag.Description = dt.Rows[0][2];
            string sql_question = "select top(2) id,title from questions order by id desc";
            ViewData["questions"] = news.GetListByCustom(sql_question).Tables[0];
            return View();
            
        }
       

        public ActionResult InvesApply()
        {
            Investment i = new Investment();
            Pan.Model.Investment inves = new Pan.Model.Investment();
            inves.mobile_num = Request.Form["shouji"];
            inves.name = Request.Form["chengwei"];
            inves.sex = Request.Form["gender"];
            inves.time = DateTime.Now.ToString();
            inves.limit_date = Request.Form["qixian"];
            inves.i_num = int.Parse(Request.Form["amount"]);
            i.Add(inves);
            loan.Models.common.MailSender ms = new Models.common.MailSender();
            StringBuilder body = new StringBuilder();
            body.Append("<div>姓名:");
            body.Append(Request.Form["chengwei"]);
            body.Append("</div>");
            body.Append("<div>性别:");
            body.Append(Request.Form["gender"]);
            body.Append("</div>");
            body.Append("<div>联系方式:");
            body.Append(Request.Form["shouji"]);
            body.Append("</div>");
            body.Append("<div>贷款金额:");
            body.Append(Request.Form["amount"]);
            body.Append("</div>");
            body.Append("<div>贷款期限:");
            body.Append(Request.Form["qixian"]);
            body.Append("</div>");
            body.Append("<div>申请日期:");
            body.Append(inves.time);
            body.Append("</div>");

            ms.send("理财申请", body.ToString());
            return Content("<script>alert('申请成功,我们的工作人员会尽快跟您联系。');window.location='/Zhiyingbao.html';</script>");


        }

        public ActionResult Jobs()
        {
            string sql3 = "select title,keywords,description from PageSet where [column]='加入易房'";

            ViewBag.Title = news.GetListByCustom(sql3).Tables[0].Rows[0][0];
            ViewBag.Keywords = news.GetListByCustom(sql3).Tables[0].Rows[0][1];
            ViewBag.Description = news.GetListByCustom(sql3).Tables[0].Rows[0][2];

            return View();
        }

        public ActionResult FeedBack()
        {
            string sql3 = "select title,keywords,description from PageSet where [column]='客户留言'";

            ViewBag.Title = news.GetListByCustom(sql3).Tables[0].Rows[0][0];
            ViewBag.Keywords = news.GetListByCustom(sql3).Tables[0].Rows[0][1];
            ViewBag.Description = news.GetListByCustom(sql3).Tables[0].Rows[0][2];
            return View();
        }

        public ActionResult FBApply()
        {
            Feedback fb = new Feedback();
            Pan.Model.Feedback model = new Pan.Model.Feedback();
            model.mobile_num = Request.Form["shouji"];
            model.name = Request.Form["chengwei"];
            model.sex = Request.Form["gender"];
            model.time = DateTime.Now.ToString();
            model.content = Request.Form["liuyan"];
            fb.Add(model);
            loan.Models.common.MailSender ms = new Models.common.MailSender();
            StringBuilder body = new StringBuilder();
            body.Append("<div>姓名:");
            body.Append(model.name);
            body.Append("</div>");
            body.Append("<div>性别:");
            body.Append(model.sex);
            body.Append("</div>");
            body.Append("<div>联系方式:");
            body.Append(model.mobile_num);
            body.Append("</div>");
            body.Append("<div>留言内容:");
            body.Append(model.content);
            body.Append("</div>");

            body.Append("<div>留言日期:");
            body.Append(model.time);
            body.Append("</div>");

            ms.send("留言", body.ToString());



            return Content("<script>alert('留言成功,我们的工作人员会尽快跟您联系。');window.location='/FeedBack.html';</script>");


        }

        public ActionResult Questions()
        {
            string sql3 = "select title,keywords,description from PageSet where [column]='问题列表' order by id desc";

            ViewBag.Title = news.GetListByCustom(sql3).Tables[0].Rows[0][0];
            ViewBag.Keywords = news.GetListByCustom(sql3).Tables[0].Rows[0][1];
            ViewBag.Description = news.GetListByCustom(sql3).Tables[0].Rows[0][2];

            string sql = "select id,title,content from Questions";
            ViewData["question"] = news.GetListByCustom(sql).Tables[0];

            return View();
        }

        public ActionResult siteMap()
        {
            return View();
        }
    }
}
