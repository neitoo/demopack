using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoStars.Data
{
    public class DataEntity
    {
        public DemoStarsEntities starsEntities = new DemoStarsEntities();

        public static DataEntity dataEntity = new DataEntity();


    }
}
