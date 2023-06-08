using event_platform_classLibrary.EventHandlers.Classes;

namespace event_platform_classLibrary.Strategy
{
    public class TagFilterAlgo : FilterAlgoBase
    {
        public TagFilterAlgo() { }
        public override List<(Event, float)> RankEvents(List<User> users, List<Event> events)
        {
            Dictionary<int, string> eventTags = new Dictionary<int, string>()
        {
            { 1, "Art" },
            { 2, "Business" },
            { 3, "Celebrity" },
            { 4, "Charity" },
            { 5, "Concert" },
            { 6, "Conference" },
            { 7, "Cultural" },
            { 8, "Entertainment" },
            { 9, "Fashion" },
            { 10, "Festival" },
            { 11, "Film" },
            { 12, "Food" },
            { 13, "Music" },
            { 14, "Networking" },
            { 15, "Performing Arts" },
            { 16, "Sports" },
            { 17, "Technology" },
            { 18, "Theater" },
            { 19, "Travel" },
            {20, "Comedy"}
        };


            List<(Event, float)> eventRatios = new List<(Event, float)>();

            int maxTags = eventTags.Count;

            foreach (User user in users)
            {
                foreach (Event eventItem in events)
                {
                    float ratio;
                    int userMatchCount = 0;
                    int currentEventTags = eventItem.tags.Count;

                    foreach (var tag in eventItem.tags)
                    {
                        if (user.usersTags.Contains(tag))
                        {
                            userMatchCount++;
                            break;
                        }
                    }

                    ratio = (float)userMatchCount / currentEventTags - (maxTags - currentEventTags) / (float)maxTags;

                    eventRatios.Add((eventItem, ratio));
                }
            }

            return eventRatios;
        }
    }
}
