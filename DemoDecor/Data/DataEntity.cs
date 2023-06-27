using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDecor.Data
{
    public class DataEntity
    {
        public DecorDataBaseEntities baseEntities = new DecorDataBaseEntities();
        public static  DataEntity entity = new DataEntity();
    }
}
