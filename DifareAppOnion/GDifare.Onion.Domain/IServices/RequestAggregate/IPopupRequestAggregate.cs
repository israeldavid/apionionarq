using OnionPattern.Domain.IServices.Requests.Popup;

namespace OnionPattern.Domain.IServices.RequestAggregate
{
    public interface IPopupRequestAggregate
    {
        ICreatePopupRequest CreatePopupRequest { get; }
        IGetAllPopupsRequest GetAllPopupsRequest { get; }
        IGetPopupByIdRequest GetPopupByIdRequest { get; }
        IDeletePopupByIdRequest DeletePopupByIdRequest { get; }
        IUpdatePopupRequest UpdatePopupRequest { get; }
    }
}
