using Infrastructure.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class SubscribeFactory
{
    public static SubscriberEntity Create(SubscribeForm form)
    {
        try
        {
            var datetime = DateTime.Now;

            return new SubscriberEntity
            {
                Email = form.Email,
                DailyNewsletter = form.DailyNewsletter,
                AdvertisingUpdates = form.AdvertisingUpdates,
                WeekinReview = form.WeekinReview,
                EventUpdates = form.EventUpdates,
                StartupsWeekly = form.StartupsWeekly,
                Podcasts = form.Podcasts,
                Created = datetime,
                Modified = datetime,
            };
        }
        catch { }
        return null!;
    }
}