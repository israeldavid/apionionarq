using OnionPattern.Domain.Entities.Menu.Requests;
using OnionPattern.Domain.Entities.Menu.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionPattern.Domain.IServices.Requests.Menu
{
    public interface IUpdateMenuRequest
    {
        MenuResponse Execute(UpdateMenuInput input);
    }
}
