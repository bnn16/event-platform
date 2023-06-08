using event_platform_classLibrary;
using event_platform_classLibrary.EventHandlers.Classes;
using event_platform_classLibrary.Strategy;

public class EventRanker
{
    private readonly FilterAlgoBase rankingStrategy;

    public EventRanker(FilterAlgoBase strategy)
    {
        rankingStrategy = strategy;
    }

    public List<(User, List<(Event, float)>)> RankAndPrintEvents(List<User> users, List<Event> events)
    {
        List<(User, List<(Event, float)>)> userEventRatios = new List<(User, List<(Event, float)>)>();

        foreach (User user in users)
        {
            List<(Event, float)> eventRatios = rankingStrategy.RankEvents(users, events);

            BubbleSort(eventRatios);

            userEventRatios.Add((user, eventRatios));
        }

        return userEventRatios;
    }



    private void BubbleSort(List<(Event, float)> unsorted)
    {
        int n = unsorted.Count;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (unsorted[j].Item2 > unsorted[j + 1].Item2)
                {
                    (Event, float) temp = unsorted[j];
                    unsorted[j] = unsorted[j + 1];
                    unsorted[j + 1] = temp;
                }
            }
        }
    }
}
