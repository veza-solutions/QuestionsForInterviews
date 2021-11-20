using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewImplementation
{
    public abstract class ServiceBase
    {
        protected readonly IMapper _autoMapper;

        public ServiceBase(IMapper autoMapper)
        {
            this._autoMapper = autoMapper;
        }
    }
}
