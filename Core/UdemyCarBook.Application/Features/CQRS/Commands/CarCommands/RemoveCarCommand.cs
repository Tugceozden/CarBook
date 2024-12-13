using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.CQRS.Commands.CarCommands
{
	public  class RemoveCarCommand
	{
        public int Id { get; set; }

		public RemoveCarCommand(int id)
		{
			Id = id;
		}
	}
}
