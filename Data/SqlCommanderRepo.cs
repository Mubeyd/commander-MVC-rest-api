using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }
        public IEnumerable<Command> GetAllCommands()
        {
            return this._context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return this._context.Commands.FirstOrDefault(item => item.Id == id);
        }
    }
}