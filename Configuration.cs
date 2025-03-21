using System.Net.Mail;

namespace MyJwtKey;
 
 public static class Configuration
 {
    public static string JwtKey { get; set; } = "iuiufr32Q(UUH9uehfd39u)YUHIXWYIHuwi%";
    public static string ApiKey {get;set;} = "FootboolVlog/=24f2fmoq2o=u123ndi#$%%¨623";
    public static string ApiName {get;set;} = "My/Api/Name";
    public static  ConfSmtp smtp = new ();
    public class ConfSmtp
    {
      public int Port { get; set; }
      public string Host { get; set; }
      public string UserName { get; set; }
      public string Password { get; set; }
    }
 }