using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planning.Model
{
    public class GroupContainer
    {
        private List<Group> _groups;

        public GroupContainer()
        {
            _groups = new List<Group>();
        }

        public void AddGroup(Group group)
        {
            _groups.Add(group);
        }

        public void RemoveGroup(Group group)
        {
            _groups.Remove(group);
        }

        public List<Group> GetGroups(Predicate<Group> Filter)
        {
            List<Group> result = new List<Group>();

            foreach (Group g in _groups)
            {
                if (Filter(g))
                    result.Add(g);
            }
            return result;
        }

        public List<Group> GetGroups()
        {
            return _groups;
        }

    }
}
