using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.CommonEntity
{
    public abstract class BaseEntity : BaseEntityDetail
    {
        public long Id { get; set; }
    }
}
