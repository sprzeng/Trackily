﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trackily.Models.Binding.Project
{
    public class ProjectEditBindingModel : ProjectBaseBindingModel
    {
        public Dictionary<string, bool> RemoveMembers { get; set; }
    }
}
