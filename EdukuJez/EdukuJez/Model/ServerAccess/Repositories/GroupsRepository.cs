using EdukuJez.Repositories;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class GroupsRepository : IRepository<Group>
    {
        List<Group> GroupList;
        const string CREATE_QUARY = "Select * from Groups";
        public GroupsRepository() {
            GroupList = new List<Group>();
            var response = ServerClient.StartConnection().ReturnDataReader(CREATE_QUARY);
            response.Wait();
            MapEntities(response.Result);
        }
        private void MapEntities(SqlDataReader reader)
        {
            while (reader.Read())
            {
                Group group = new Group();

                group.Id = reader.GetInt32(0);
                group.GroupName = reader.GetString(1);
                if(!reader.IsDBNull(2)) group.ParentGroup = reader.GetInt32(2);
                GroupList.Add(group);
            }
        }
        public Group GetById(int id)
        {
            for (int i=0; i<GroupList.Count();++i)
            {
                if (GroupList[i].Id==id) return GroupList[i];
            }
            return null;
        }
        public List<Group> GetAll() {
            return GroupList;
        }
        public void Create(Group entity) {
            throw new NotImplementedException();
        }
        public void Update(Group entity) {
            throw new NotImplementedException();
        }
        public void Delete(Group entity) {
            throw new NotImplementedException();
        }
    }
}