using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using UnityEngine;

public class SendEmailManager
{
    private static SendEmailManager _instance;
    public static SendEmailManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new SendEmailManager();
            return _instance;
        }
    }

    /// <summary>
    /// 发送邮件
    /// </summary>
    /// <param name="pwd">授权码</param>
    public void SendEmail(string stmpServer, string mailAccount, string pwd,
        string mailTo, string mailTitle, string mailContent)
    {
        Debug.Log("Send Email");
        
        //邮件服务设置
        SmtpClient smtpClient = new SmtpClient();
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;     //指定电子邮件发送方式
        smtpClient.Host = stmpServer;                               //指定发送方SMTP服务器
        smtpClient.EnableSsl = true;                                //使用安全加密连接
        smtpClient.UseDefaultCredentials = false;                    //不和请求一起发送
        smtpClient.Credentials = new NetworkCredential(mailAccount, pwd);   //设置发送账号密码

        MailMessage mailMessage = new MailMessage(mailAccount, mailTo);     //实例化邮件信息实体并设置发送方和接收方
        mailMessage.Subject = mailTitle;            //设置发送邮件得标题
        mailMessage.SubjectEncoding = Encoding.UTF8;
        mailMessage.Body = mailContent;             //设置发送邮件内容
        mailMessage.BodyEncoding = Encoding.UTF8;   //设置发送邮件得编码
        mailMessage.IsBodyHtml = false;             //设置标题是否为HTML格式
        mailMessage.Priority = MailPriority.Normal; //设置邮件发送优先级

        try
        {
            smtpClient.Send(mailMessage); //发送邮件
            Debug.Log("发送成功");
        }
        catch (SmtpException ex)
        {
            Debug.LogError(ex.ToString());
            throw;
        }
    }
}
