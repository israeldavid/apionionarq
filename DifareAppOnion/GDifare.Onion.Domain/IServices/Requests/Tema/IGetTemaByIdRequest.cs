using OnionPattern.Domain.Entities.Tema.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionPattern.Domain.IServices.Requests.Tema
{
    public interface IGetTemaByIdRequest
    {
        TemaResponse Execute(int id);
    }
}
