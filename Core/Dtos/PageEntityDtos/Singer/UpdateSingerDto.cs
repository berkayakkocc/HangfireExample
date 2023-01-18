using Core.Models.CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.PageEntity.Singer
{
    public class UpdateSingerDto:BaseEntity
    {
        public UpdateSingerDto()
        {

        }
        public UpdateSingerDto(string name, int bornDate, int age)
        {
            Name = name;
            BornDate = bornDate;
            Age = age;
        }

        public string Name { get; set; }
        public int BornDate { get; set; }
        public int Age { get; set; }
    }
}
