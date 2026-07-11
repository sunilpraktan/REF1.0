namespace Reflection.BusinessLogic
{
    public class ReflectionBusinessLogic
    {
        public string ReflectionConnectionString;
        public string ReturnValue; // use this variable in derived class to return data to Client after execution of store procedure.
        public string RequestValue; // Use this variable in all BL and remove RequestOption variable from all BL
        public string RequestOption; // Check after query execution to go to perticular section for data list loading
        public ReflectionBusinessLogic()
        {
            ReflectionConnectionString = System.Configuration.ConfigurationManager.AppSettings["strConnectionString"];
            //ReflectionConnectionString = "Data Source=CRIMUS002\\SQLEXPRESS;Initial Catalog=CRIDB;Persist Security Info=True;User ID=sa;Password=Sqlsa123";
            //ReflectionConnectionString = "Data Source=ACCURAVALVES\\SQLEXPRESS;Initial Catalog=ACCURADB;Persist Security Info=True;User ID=sa;Password=Sqlsa123";

        }
    }
}