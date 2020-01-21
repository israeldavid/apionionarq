using OnionPattern.Domain.Entities.Tab.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionPattern.Domain.IServices.Requests.Tab
{
    public interface IGetTabByIdRequest
    {
        TabResponse Execute(int id);
    }
}
