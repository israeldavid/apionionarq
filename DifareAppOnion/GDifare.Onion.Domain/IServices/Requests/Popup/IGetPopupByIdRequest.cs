using OnionPattern.Domain.Entities.Popup.Responses;


namespace OnionPattern.Domain.IServices.Requests.Popup
{
    public interface IGetPopupByIdRequest
    {
        PopupResponse Execute(int id);
    }
}
