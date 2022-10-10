using UnityEngine;
using UnityEngine.UI;

public class SendEmail : MonoBehaviour
{
    public InputField Stmp;
    public InputField MyEmailAddress;
    public InputField MyEmailPassword;
    public InputField ReceiveAddress;
    public InputField EmailTitle;
    public InputField EmailContent;
    public Button btnSend;

    private void Awake()
    {
        btnSend.onClick.AddListener(OnBtnSend);
    }

    private void OnBtnSend()
    {
        string stmpServer = Stmp.text;
        string mailAccount = MyEmailAddress.text;
        string pwd = MyEmailPassword.text;
        string mailTo = ReceiveAddress.text;
        string mailTitle = EmailTitle.text;
        string mailContent = EmailContent.text;
        SendEmailManager.Instance.SendEmail(stmpServer, mailAccount, pwd, mailTo, mailTitle, mailContent);
    }
}
