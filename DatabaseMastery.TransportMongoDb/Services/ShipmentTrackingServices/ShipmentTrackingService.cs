using AutoMapper;
using DatabaseMastery.TransportMongoDb.Dtos.ShipmentTrackingDtos;
using DatabaseMastery.TransportMongoDb.Entities;
using DatabaseMastery.TransportMongoDb.Settings;
using MongoDB.Driver;

namespace DatabaseMastery.TransportMongoDb.Services.ShipmentTrackingServices
{
    public class ShipmentTrackingService : IShipmentTrackingService
    {
        private readonly IMongoCollection<Shipment> _shipmentCollection;
        private readonly IMapper _mapper;

        public ShipmentTrackingService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _shipmentCollection = database.GetCollection<Shipment>(databaseSettings.ShipmentCollectionName);
            _mapper = mapper;
        }

        public async Task CreateTrackingAsync(CreateShipmentTrackingDto createDto)
        {
            var tracking = _mapper.Map<ShipmentTracking>(createDto);
            var filter = Builders<Shipment>.Filter.Eq(x => x.TrackingNumber, createDto.TrackingNumber);
            var update = Builders<Shipment>.Update
                .Push(x => x.Trackings, tracking)
                .Set(x => x.CurrentStatus, createDto.TrackingStatus);
            await _shipmentCollection.UpdateOneAsync(filter, update);
        }

        public async Task<List<ResultShipmentTrackingDto>> GetAllTrackingsAsync(string trackingNumber)
        {
            var shipment = await _shipmentCollection
                .Find(x => x.TrackingNumber == trackingNumber)
                .FirstOrDefaultAsync();

            if (shipment == null || shipment.Trackings == null)
                return new List<ResultShipmentTrackingDto>();

            return _mapper.Map<List<ResultShipmentTrackingDto>>(shipment.Trackings);
        }

        public async Task<ResultShipmentTrackingDto> GetTrackingByIdAsync(string trackingNumber, string trackingId)
        {
            var shipment = await _shipmentCollection
                .Find(x => x.TrackingNumber == trackingNumber)
                .FirstOrDefaultAsync();

            var tracking = shipment?.Trackings?.FirstOrDefault(t => t.TrackingId == trackingId);
            if (tracking == null)
                return null;

            return _mapper.Map<ResultShipmentTrackingDto>(tracking);
        }

        public async Task UpdateTrackingAsync(UpdateShipmentTrackingDto updateDto)
        {
            var filter = Builders<Shipment>.Filter.And(
                Builders<Shipment>.Filter.Eq(x => x.TrackingNumber, updateDto.TrackingNumber),
                Builders<Shipment>.Filter.ElemMatch(x => x.Trackings,
                    t => t.TrackingId == updateDto.TrackingId)
            );
            var update = Builders<Shipment>.Update
                .Set("Trackings.$.EventDate", updateDto.EventDate)
                .Set("Trackings.$.Location", updateDto.Location)
                .Set("Trackings.$.Description", updateDto.Description)
                .Set("Trackings.$.TrackingStatus", updateDto.TrackingStatus)
                .Set(x => x.CurrentStatus, updateDto.TrackingStatus);

            await _shipmentCollection.UpdateOneAsync(filter, update);
        }

        public async Task DeleteTrackingAsync(string trackingNumber, string trackingId)
        {
            var filter = Builders<Shipment>.Filter.Eq(x => x.TrackingNumber, trackingNumber);
            var update = Builders<Shipment>.Update.PullFilter(
                x => x.Trackings,
                t => t.TrackingId == trackingId
            );
            await _shipmentCollection.UpdateOneAsync(filter, update);
        }
    }
}