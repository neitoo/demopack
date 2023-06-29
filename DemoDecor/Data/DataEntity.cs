using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DemoDecor.Data
{
    public class DataEntity
    {
        public DecorDataBaseEntities baseEntities;

        public DataEntity()
        {
            try
            {
                baseEntities = new DecorDataBaseEntities();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к базе данных: " + ex.Message, "Ошибка");
            }
        }

        public static DataEntity entity = new DataEntity();
    }
}
