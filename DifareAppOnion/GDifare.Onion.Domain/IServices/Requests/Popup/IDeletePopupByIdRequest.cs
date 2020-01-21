using OnionPattern.Domain.Entities.Popup.Responses;


namespace OnionPattern.Domain.IServices.Requests.Popup
{
    public interface IDeletePopupByIdRequest
    {
        PopupResponse Execute(int id);
    }
}
