using System.Configuration;

namespace UI.Models
{
    partial class QLDTDataContext
    {
        partial void OnCreated()
        {
            this.Connection.ConnectionString = ConfigurationManager.AppSettings["connectionString"];
        }
    }
}