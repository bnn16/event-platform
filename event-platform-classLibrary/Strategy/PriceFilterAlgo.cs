using event_platform_classLibrary.EventHandlers.Classes;

namespace event_platform_classLibrary.Strategy
{
    public class PriceFilterAlgo : FilterAlgoBase
    {
        private float? lowerBound;
        private float? upperBound;

        public PriceFilterAlgo(float? lowerBound, float? upperBound)
        {
            this.lowerBound = lowerBound;
            this.upperBound = upperBound;
        }

        public override List<(Event, float)> RankEvents(List<User> users, List<Event> events)
        {
            List<(Event, float)> eventRatios = new List<(Event, float)>();
            List<(Event, float)> filteredEventRatios = new List<(Event, float)>();

            foreach (User user in users)
            {
                foreach (Event eventItem in events)
                {
                    float ratio = CalculateRatio(eventItem);

                    if (IsWithinBounds(eventItem))
                    {
                        filteredEventRatios.Add((eventItem, ratio));
                    }
                    else
                    {
                        eventRatios.Add((eventItem, ratio));
                    }
                }
            }

            eventRatios = SortEventRatios(eventRatios);
            filteredEventRatios = SortEventRatios(filteredEventRatios);

            return GetFilteredResults(eventRatios, filteredEventRatios);
        }

        private float CalculateRatio(Event eventItem)
        {
            // assign a higher ratio to events with lower prices for sorting
            return 1.0f / (float)eventItem.Price;
        }

        private bool IsWithinBounds(Event eventItem)
        {
            if ((lowerBound == null || lowerBound == 0) && (upperBound == null || upperBound == 0))
            {
                return false;
            }

            return eventItem.Price >= lowerBound && eventItem.Price <= upperBound;
        }

        private List<(Event, float)> SortEventRatios(List<(Event, float)> eventRatios)
        {
            return eventRatios.OrderByDescending(x => x.Item1.Price).ToList();
        }

        private List<(Event, float)> GetFilteredResults(List<(Event, float)> eventRatios, List<(Event, float)> filteredEventRatios)
        {
            if (lowerBound == 0 && upperBound == 0)
            {
                return eventRatios;
            }
            else
            {
                return filteredEventRatios;
            }
        }
    }
}
