using event_platform_classLibrary.EventHandlers.Classes;

namespace event_platform_classLibrary.Strategy
{
    public abstract class FilterAlgoBase
    {
        public abstract List<(Event, float)> RankEvents(List<User> users, List<Event> events);
    }
}
