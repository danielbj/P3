using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    public class GroupContainer
    {
        public List<Group> Groups { get; private set; }

        public GroupContainer()
        {
            Groups = new List<Group>();
        }

        public void AddGroup(Group group)
        {
            Groups.Add(group);
        }

        public void RemoveGroup(Group group)
        {
            Groups.Remove(group);
        }

        public List<Group> GetGroups(Predicate<Group> Filter)
        {
            List<Group> result = new List<Group>();

            foreach (Group g in Groups)
            {
                if (Filter(g))
                    result.Add(g);
            }
            return result;
        }
        /// <summary>
        /// Returns all groups in the group container
        /// </summary>
        /// <returns>List of all groups</returns>
        public List<Group> GetGroups()
        {
            return Groups;
        }       

    }
}
