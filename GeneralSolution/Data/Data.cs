namespace Data
{
    public abstract class DataAPI
    {
        public static DataAPI CreateDataLayer()
        {
            return new DataLayer();
        }

    }

    public class DataLayer : DataAPI
    {
        public DataLayer()
        {

        }
    }
}