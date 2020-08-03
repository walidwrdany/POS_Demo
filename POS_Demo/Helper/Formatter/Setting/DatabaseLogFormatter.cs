using System.Data.Entity;

namespace POS_Demo.DataModels
{
    public class MyDbConfiguration : DbConfiguration
    {
        public MyDbConfiguration()
        {
            //SetDatabaseLogFormatter(
            //    (context, writeAction) => new OneLineFormatter(context, writeAction));
        }
    }
}