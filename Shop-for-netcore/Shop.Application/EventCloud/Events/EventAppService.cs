using System;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Runtime.Session;
using EventCloud.Events.Dtos;
using EventCloud.Users;
using Abp.UI;
using Abp.ObjectMapping;

namespace EventCloud.Events
{
    [AbpAuthorize]
    public class EventAppService : EventCloudAppServiceBase, IEventAppService
    {
        private readonly IEventManager _eventManager;
        private readonly IEventRepository _eventRepository;

        public EventAppService(
            IEventManager eventManager,
            IEventRepository eventRepository,IObjectMapper objectMapper)
        {
            _eventManager = eventManager;
            _eventRepository = eventRepository;
            ObjectMapper = objectMapper;
        }

        public async Task<ListResultDto<EventListDto>> GetList(GetEventListInput input)
        {
            var events = await _eventRepository.GetListAsync(input.IncludeCanceledEvents);
            return new ListResultDto<EventListDto>(ObjectMapper.ProjectTo<EventListDto>(events.AsQueryable()).ToList());
            //return new ListResultDto<EventListDto>(events.MapTo<List<EventListDto>>());
        }

        public async Task<EventDetailOutput> GetDetail(EntityDto<Guid> input)
        {
            var @event = await _eventRepository.FirstOrDefaultAsync(input.Id);

            if (@event == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }
            return ObjectMapper.Map<EventDetailOutput>(@event);
           // return @event.MapTo<EventDetailOutput>();
        }

        public async Task Create(CreateEventInput input)
        {
            var @event = Event.Create(AbpSession.GetTenantId(), input.Title, input.Date, input.Description, input.MaxRegistrationCount);
            await _eventManager.CreateAsync(@event);
        }

        public async Task Cancel(EntityDto<Guid> input)
        {
            var @event = await _eventManager.GetAsync(input.Id);
            _eventManager.Cancel(@event);
        }

        public async Task<EventRegisterOutput> Register(EntityDto<Guid> input)
        {
            var registration = await RegisterAndSaveAsync(
                await _eventManager.GetAsync(input.Id),
                await GetCurrentUserAsync()
                );

            return new EventRegisterOutput
            {
                RegistrationId = registration.Id
            };
        }

        public async Task CancelRegistration(EntityDto<Guid> input)
        {
            await _eventManager.CancelRegistrationAsync(
                await _eventManager.GetAsync(input.Id),
                await GetCurrentUserAsync()
                );
        }

        private async Task<EventRegistration> RegisterAndSaveAsync(Event @event, User user)
        {
            var registration = await _eventManager.RegisterAsync(@event, user);
            await CurrentUnitOfWork.SaveChangesAsync();
            return registration;
        }
    }
}