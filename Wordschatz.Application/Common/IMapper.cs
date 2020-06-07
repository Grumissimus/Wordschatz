using System;
using System.Collections.Generic;
using System.Text;
using Wordschatz.Common.Entities;

namespace Wordschatz.Application.Common
{
    public interface IMapper<T, Q> 
        where T: Entity 
        where Q : IReadModel
    {
        public Q MapToReadModel(T model);
    }
}
