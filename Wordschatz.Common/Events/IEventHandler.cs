using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Wordschatz.Common.Events
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
    }
}
