using OnionPattern.Domain.Entities.Popup.Requests;
using OnionPattern.Domain.Entities.Popup.Responses;

namespace OnionPattern.Domain.IServices.Requests.Popup
{
    public interface ICreatePopupRequest
    {
        PopupResponse Execute(CreatePopupInput input);
    }
}
