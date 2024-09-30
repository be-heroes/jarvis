namespace Application.Mapping.Converters;

public class IAggregateRootToICommandConverter : ITypeConverter<IAggregateRoot, ICommand<IAggregateRoot>>
{
    public ICommand<IAggregateRoot> Convert(IAggregateRoot source, ICommand<IAggregateRoot> destination, ResolutionContext context)
    {
        switch (source)
        {
            case PodEntity entity:
                if (entity.Id == Guid.Empty)
                {
                    destination = new CreatePodEntityCommand(entity.PodSelector, entity.Metrics);
                }
                else
                {
                    destination = new UpdatePodEntityCommand(entity);
                }

                break;
            case null:
            default:
                throw new NotSupportedException($"The aggregate root type {source?.GetType().Name} is not supported.");
        }

        return destination;
    }
}