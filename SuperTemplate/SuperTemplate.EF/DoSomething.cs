using SuperTemplate.Core;
using SuperTemplate.Core.Entities;
using SuperTemplate.Core.Repository;

namespace SuperTemplate.EF
{
    public class DoSomething : IDoSomething
    {
        public string GiveMeAString()
        {
            return "I'm a string yay!";
        }
    }
}