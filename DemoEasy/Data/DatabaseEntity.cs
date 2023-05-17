using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEasy.Data
{
    public class DatabaseEntity
    {
        public WinxEntities WinxEnt = new WinxEntities();

        public static DatabaseEntity DBEntity = new DatabaseEntity();

        /// <summary>
        /// Проверка подключения к базе данных.
        /// </summary>
        public static  DatabaseEntity connect
        {
            get
            {
                try
                {
                    return new DatabaseEntity();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
