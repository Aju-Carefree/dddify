﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dddify.Domain.Events
{
    public interface IDomainEvent : INotification
    {
    }
}
