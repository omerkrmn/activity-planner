using ActivityPlanner.Entities.Models;
using ActivityPlanner.Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Repositories.EFcore.Extensions
{
    public static class ActivityQueryableExtensions
    {
        //public static IQueryable<Activity> FilterActivities(this IQueryable<Activity> activities, ActivityParameters parameters)
        //{
            
        //}
        public static IQueryable<Activity> CheckCountry(this IQueryable<Activity> activities, string? country)
        {
            if (string.IsNullOrWhiteSpace(country))
                return activities;
            var countryToCheck = country.Trim().ToLower();
            return activities.Where(a => a.Country.ToLower()== countryToCheck );
        }
        public static IQueryable<Activity> CheckCity(this IQueryable<Activity> activities, string? city)
        {
            if (string.IsNullOrWhiteSpace(city))
                return activities;
            var cityToCheck = city.Trim().ToLower();
            return activities.Where(a => a.City.ToLower()== cityToCheck);
        }
        public static IQueryable<Activity> CheckDate(this IQueryable<Activity> activities, DateTime? date)
        {
            if (date == null)
                return activities;
            return activities.Where(a => a.LastRegistrationDate <= date);
        }

        public static IQueryable<Activity> CheckStatus(this IQueryable<Activity> activities )
        {
            DateTime today = DateTime.UtcNow;
            return activities.Where(a => a.LastRegistrationDate >= today);
        }
    }
}
