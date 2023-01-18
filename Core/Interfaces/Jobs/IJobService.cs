using Core.Dtos.GenericDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Jobs
{
    public interface IJobService
    {
        Task<GenericResponseDto<NoContent>> GetPersonList();

        Task<GenericResponseDto<NoContent>> MailSend();
    }
}
