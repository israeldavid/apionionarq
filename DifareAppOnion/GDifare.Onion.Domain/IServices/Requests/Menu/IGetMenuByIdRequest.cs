using OnionPattern.Domain.Entities.Menu.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionPattern.Domain.IServices.Requests.Menu
{
    public interface IGetMenuByIdRequest
    {
        MenuResponse Execute(int id);
    }
}
