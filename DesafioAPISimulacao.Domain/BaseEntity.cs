﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DesafioAPISimulacao.Domain
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
    }
}
