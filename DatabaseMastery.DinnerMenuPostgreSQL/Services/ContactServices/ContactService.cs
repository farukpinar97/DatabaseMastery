using AutoMapper;
using DatabaseMastery.DinnerMenuPostgreSQL.Context;
using DatabaseMastery.DinnerMenuPostgreSQL.Dtos.ContactDtos;
using DatabaseMastery.DinnerMenuPostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseMastery.DinnerMenuPostgreSQL.Services.ContactServices
{
    public class ContactService : IContactService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ContactService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ResultContactDto>> GetAllContactsAsync()
        {
            var values = await _context.Contacts
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
            return _mapper.Map<List<ResultContactDto>>(values);
        }

        public async Task CreateContactAsync(CreateContactDto createContactDto)
        {
            var value = _mapper.Map<Contact>(createContactDto);
            await _context.Contacts.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task MarkAsReadAsync(int id)
        {
            var value = await _context.Contacts.FindAsync(id);
            if (value != null)
            {
                value.IsRead = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteContactAsync(int id)
        {
            var value = await _context.Contacts.FindAsync(id);
            if (value != null)
            {
                _context.Contacts.Remove(value);
                await _context.SaveChangesAsync();
            }
        }
    }
}