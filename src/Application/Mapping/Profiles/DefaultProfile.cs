namespace Application.Mapping.Profiles;

public sealed class DefaultProfile : Profile
{
    public DefaultProfile()
    {
        CreateMap<IAggregateRoot, ICommand<IAggregateRoot>>()
        .ConvertUsing<IAggregateRootToICommandConverter>();

        CreateMap<IIntegrationEvent, ICommand<IAggregateRoot>>()
        .ConvertUsing<IIntegrationEventToICommandConverter>();

        CreateMap<IIntegrationEvent, IAggregateRoot>()
        .ConvertUsing<IIntegrationEventToIAggregateRootConverter>();

        CreateMap<IIntegrationEvent, PodEntity>()
        .ConvertUsing<IIntegrationEventToPodEntityConverter>();

        CreateMap<IIntegrationEvent, NodeEntity>()
        .ConvertUsing<IIntegrationEventToNodeEntityConverter>();
    }
}