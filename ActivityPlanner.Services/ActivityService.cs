using ActivityPlanner.Entities.Models;
using ActivityPlanner.Repositories.Contracts;
using ActivityPlanner.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityPlanner.Services
{
    public class ActivityService : IActivityService
    {
        //todo: dto ları burada kullanacaksın şuanlık bu şekilde kalsınlar daha sonra dtolara geç!
        private readonly IRepositoryManager _repositoryManager;

        public ActivityService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
        public async void CreateOneActivitiy(Activity activity)
        {
            if (activity is null)
                throw new ArgumentNullException();

            _repositoryManager.Activity.CreateOneActivitiy(activity);
            await _repositoryManager.SaveAsync();   
        }

        public void DeleteOneActivitiy(Activity activity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Activity>> GetAllActivitiesAsync(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<Activity> GetOneActivityAsync(int id, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public void UpdateOneActivitiy(Activity activity)
        {
            throw new NotImplementedException();
        }
    }
}
