using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using VR2_Klientrakendus.Models;
using VR2_Klientrakendus.Service.Interfaces;

namespace VR2_Klientrakendus.Service
{
    public class GroupService :BaseService, IGroupService
    {

        public GroupService():base(ServiceConstants.GroupServiceUrl)
        {
        }

        public async Task<ObservableCollection<Group>> GetAll()
        {
            return await base.GetData<ObservableCollection<Group>>(ServiceConstants.GroupServiceUrl);
        }

        public async Task<Group> GetById(int groupId)
        {
            return await base.GetData<Group>(ServiceConstants.GroupServiceUrl + "/" + groupId);
        }

        public async Task<ObservableCollection<Group>> GetBySearchQuery(string searchQuery)
        {
            return await base.GetData<ObservableCollection<Group>>(ServiceConstants.GroupServiceUrl + "/" + searchQuery);
        }

        public async Task<Group> Add(Group group)
        {
            return await base.PostData(group);
        }

        public async Task<Group> Update(Group group, int groupId)
        {
            return await base.PutData(group, groupId);
        }

        public async Task<Group> Delete(int groupId)
        {
            return await base.DeleteData<Group>(groupId);
        }
    }
}
