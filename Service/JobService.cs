using Core.Dtos.Constants;
using Core.Dtos.GenericDto;
using Core.Interfaces.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class JobService : IJobService
    {
        public async Task<GenericResponseDto<NoContent>> GetPersonList()
        {
            Console.WriteLine("Deneme Person List "+DateTime.Now.ToString());
            return GenericResponseDto<NoContent>.ResponseData(new NoContent(), (int)ErrorEnums.Success, null);
        }

        public async Task<GenericResponseDto<NoContent>> MailSend()
        {
            Console.WriteLine("Deneme MailSend " + DateTime.Now.ToString());

            return GenericResponseDto<NoContent>.ResponseData(new NoContent(), (int)ErrorEnums.Success, null);
        }
    }
}
