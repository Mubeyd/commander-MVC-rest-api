using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command> {
                new Command { Id = 0, HowTo = "HowTo0", Line = "Line0", Platform = "Platform0" },
                new Command { Id = 1, HowTo = "HowTo1", Line = "Line1", Platform = "Platform1" },
                new Command { Id = 2, HowTo = "HowTo2", Line = "Line2", Platform = "Platform2" }
            };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "HowTo0", Line = "Line0", Platform = "Platform" };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}