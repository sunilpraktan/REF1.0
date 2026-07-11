namespace Reflection.EF
{
    public partial class COM_M002 : ObjectBase
    {
        public string alert_id { get; set; }
        public string alert_name { get; set; }
        public string trigger_point { get; set; }
        public string description { get; set; }
        public string alert_type { get; set; }
        public string trigger_from { get; set; }
        public string subject { get; set; }
        public string msg_body { get; set; }
        public string doc_req { get; set; }
       
    }
    public partial class COM_M002_A
    {
        public int id { get; set; }
        public string alert_id { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string user_type { get; set; }
        public string EmpId { get; set; }
        public string person_name { get; set; }
        public string user_id { get; set; }
        public string to_mail_id { get; set; }
        public string cc_mail_id { get; set; }
        public string bcc_mail_id { get; set; }
        public string trigger_point { get; set; }
        public string alert_name { get; set; }
        public string client { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
    }
    public class NotificationData
    {
        public string alert_id { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string description { get; set; }
        public string alert_type { get; set; }
        public string trigger_from { get; set; }
        public string subject { get; set; }
        public string msg_body { get; set; }
        public string doc_req { get; set; }
        public string user_type { get; set; }
        public string EmpId { get; set; }
        public string person_name { get; set; }
        public string user_id { get; set; }
        public string to_mail_id { get; set; }
        public string cc_mail_id { get; set; }
        public string bcc_mail_id { get; set; }
        public string trigger_point { get; set; }
        public string alert_name { get; set; }
        public string client { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string type { get; set; }
        public string Authority { get; set; }
        public string EmpName { get; set; }

    }
}
