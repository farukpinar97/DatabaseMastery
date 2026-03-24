using AutoMapper;
using DatabaseMastery.TransportMongoDb.Dtos.GetInTouchDtos;
using DatabaseMastery.TransportMongoDb.Entities;
using DatabaseMastery.TransportMongoDb.Settings;
using MongoDB.Driver;

namespace DatabaseMastery.TransportMongoDb.Services.GetInTouchServices
{
    public class GetInTouchService:IGetInTouchService
    {
        private readonly IMongoCollection<GetInTouch> _GetInTouchCollection;
        private readonly IMapper _mapper;

        public GetInTouchService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _GetInTouchCollection = database.GetCollection<GetInTouch>(_databaseSettings.GetInTouchCollectionName);

            _mapper = mapper;
        }
        public async Task CreateGetInTouchAsync(CreateGetInTouchDto createGetInTouchDto)
        {
            var value = _mapper.Map<GetInTouch>(createGetInTouchDto);
            await _GetInTouchCollection.InsertOneAsync(value);
        }

        public async Task DeleteGetInTouchAsync(string id)
        {
            await _GetInTouchCollection.DeleteOneAsync(x => x.GetInTouchId == id);
        }

        public async Task<List<ResultGetInTouchDto>> GetAllGetInTouchAsync()
        {
            var values = await _GetInTouchCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultGetInTouchDto>>(values);
        }

        public async Task<GetGetInTouchByIdDto> GetGetInTouchByIdAsync(string id)
        {
            var value = await _GetInTouchCollection.Find(x => x.GetInTouchId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetGetInTouchByIdDto>(value);
        }

        public async Task UpdateGetInTouchAsync(UpdateGetInTouchDto updateGetInTouchDto)
        {
            var values = _mapper.Map<GetInTouch>(updateGetInTouchDto);
            await _GetInTouchCollection.FindOneAndReplaceAsync(x => x.GetInTouchId == updateGetInTouchDto.GetInTouchId, values);
        }
    }
}
