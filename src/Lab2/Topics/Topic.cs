using Itmo.ObjectOrientedProgramming.Lab2.Recipients;

namespace Itmo.ObjectOrientedProgramming.Lab2.Topics;

public class Topic
{
    public string Name { get; }

    public IReadOnlyCollection<UserRecipient> Users { get; }

    public Topic(string name, IReadOnlyCollection<UserRecipient> users)
    {
        Name = name;
        Users = users;
    }

    public class ThopicBuilder
    {
        private readonly string _name;

        private readonly List<UserRecipient> _users = [];

        public ThopicBuilder(string name)
        {
            _name = name;
        }

        public ThopicBuilder WithUser(UserRecipient user)
        {
            _users.Add(user);
            return this;
        }

        public Topic Build()
        {
            return new Topic(_name, _users);
        }
    }
}