using DatabaseMastery.DinnerMenuPostgreSQL.Dtos.ContactDtos;

namespace DatabaseMastery.DinnerMenuPostgreSQL.Services.ContactServices
{
    public interface IContactService
    {
        Task<List<ResultContactDto>> GetAllContactsAsync();
        Task CreateContactAsync(CreateContactDto createContactDto);
        Task MarkAsReadAsync(int id);
        Task DeleteContactAsync(int id);
    }
}