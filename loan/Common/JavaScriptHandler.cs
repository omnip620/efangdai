using System;
using System.Collections.Generic;
using System.Text;


namespace loan.Common
{
    public class JavaScriptHandler
    {


        public static string AlertAndRedirect(string msg, string url)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<script>alert('");
            sb.Append(msg);
            sb.Append("'); window.location='");
            sb.Append(url);
            sb.Append("'</script>");

            return sb.ToString();
        }
        public static string AlertAndBack(string msg)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<script>alert('");
            sb.Append(msg);
            sb.Append("'); window.history.back()");
           sb.Append("</script>");

            return sb.ToString();
        }

    }
}