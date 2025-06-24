﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DugunSalonuKiralama.Application.Features.CQRS.Commands.User
{
    public class RemoveUserCommand
    {
        public int Id { get; set; }

        public RemoveUserCommand(int id)
        {
            Id = id;
        }
    }
}

