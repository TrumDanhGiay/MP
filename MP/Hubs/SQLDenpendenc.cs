using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MP.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MP.Hubs
{
    public class SQLDenpendenc
    {
        public IEnumerable<Menu> GetMenu()
        {
            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(@"select [MenuID], [MenuName] from [dbo].[Menu]", connection))
                {
                    command.Notification = null;
                    SqlDependency.Start(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                    SqlDependency dependency = new SqlDependency(command);

                    dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
                    using (var reader = command.ExecuteReader())
                        return reader.Cast<IDataRecord>()
                            .Select(x => new Menu()
                            {
                                MenuID = reader.GetString(0),
                                MenuName = reader.GetString(1)
                            }).ToList();
                }

            }
        }
        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            ChatHub.Show();
        }
    }
}