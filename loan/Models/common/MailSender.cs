using System.Net;
using System.Net.Mail;
using System.Text;

namespace loan.Models.common
{
    public class MailSender
    {
        public void send(string subject, string body)
        {
            SmtpClient smtp = new SmtpClient(); //实例化一个SmtpClient
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network; //将smtp的出站方式设为 Network
            smtp.EnableSsl = false;//smtp服务器是否启用SSL加密
            smtp.Host = "smtp.qq.com"; //指定 smtp 服务器地址
            smtp.Port = 25;             //指定 smtp 服务器的端口，默认是25，如果采用默认端口，可省去
            //如果你的SMTP服务器不需要身份认证，则使用下面的方式，不过，目前基本没有不需要认证的了
            //smtp.UseDefaultCredentials = true;
            //如果需要认证，则用下面的方式
            smtp.Credentials = new NetworkCredential("412726700@qq.com", "panzhichao001");
            MailMessage mm = new MailMessage(); //实例化一个邮件类
            mm.Priority = MailPriority.High; //邮件的优先级，分为 Low, Normal, High，通常用 Normal即可
            mm.From = new MailAddress("412726700@qq.com", "网站后台", Encoding.GetEncoding(936));
            //收件方看到的邮件来源；
            //第一个参数是发信人邮件地址
            //第二参数是发信人显示的名称
            //第三个参数是 第二个参数所使用的编码，如果指定不正确，则对方收到后显示乱码
            //936是简体中文的codepage值

            //mm.ReplyTo = new MailAddress("test_box@gmail.com", "我的接收邮箱", Encoding.GetEncoding(936));
            //ReplyTo 表示对方回复邮件时默认的接收地址，即：你用一个邮箱发信，但却用另一个来收信
            //上面后两个参数的意义， 同 From 的意义
            //mm.CC.Add("a@163.com,b@163.com,c@163.com");
            ////邮件的抄送者，支持群发，多个邮件地址之间用 半角逗号 分开

            ////当然也可以用全地址，如下：
            //mm.CC.Add(new MailAddress("a@163.com", "抄送者A", Encoding.GetEncoding(936)));
            //mm.CC.Add(new MailAddress("b@163.com", "抄送者B", Encoding.GetEncoding(936)));
            //mm.CC.Add(new MailAddress("c@163.com", "抄送者C", Encoding.GetEncoding(936)));

            //mm.Bcc.Add("d@163.com,e@163.com");
            ////邮件的密送者，支持群发，多个邮件地址之间用 半角逗号 分开

            ////当然也可以用全地址，如下：
            //mm.CC.Add(new MailAddress("d@163.com", "密送者D", Encoding.GetEncoding(936)));
            //mm.CC.Add(new MailAddress("e@163.com", "密送者E", Encoding.GetEncoding(936)));
            //mm.Sender = new MailAddress("xxx@xxx.com", "邮件发送者", Encoding.GetEncoding(936));
            ////可以任意设置，此信息包含在邮件头中，但并不会验证有效性，也不会显示给收件人
            ////说实话，我不知道有啥实际作用，大家可不理会，也可不写此项
            mm.To.Add("185724575@qq.com");
            //邮件的接收者，支持群发，多个地址之间用 半角逗号 分开

            //当然也可以用全地址添加

            //mm.To.Add(new MailAddress("g@163.com", "接收者g", Encoding.GetEncoding(936)));
            //mm.To.Add(new MailAddress("h@163.com", "接收者h", Encoding.GetEncoding(936)));
            mm.Subject = subject; //邮件标题
            mm.SubjectEncoding = Encoding.GetEncoding(936);
            // 这里非常重要，如果你的邮件标题包含中文，这里一定要指定，否则对方收到的极有可能是乱码。
            // 936是简体中文的pagecode，如果是英文标题，这句可以忽略不用
            mm.IsBodyHtml = true; //邮件正文是否是HTML格式

            mm.BodyEncoding = Encoding.GetEncoding(936);
            //邮件正文的编码， 设置不正确， 接收者会收到乱码

            mm.Body = body;
            ////邮件正文
            //mm.Attachments.Add( new Attachment( @"d:a.doc", System.Net.Mime.MediaTypeNames.Application.Rtf ) );
            ////添加附件，第二个参数，表示附件的文件类型，可以不用指定
            ////可以添加多个附件
            //mm.Attachments.Add( new Attachment( @"d:b.doc") );
            smtp.Send(mm); //发送邮件，如果不返回异常， 则大功告成了


        }
    }
}