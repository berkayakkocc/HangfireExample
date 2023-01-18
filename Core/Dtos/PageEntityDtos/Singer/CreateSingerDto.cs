using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.PageEntity.Singer
{
    public class CreateSingerDto
    {
        public string Name { get; set; }
        public int BornDate { get; set; }
        public int Age { get; set; }
    }
}
