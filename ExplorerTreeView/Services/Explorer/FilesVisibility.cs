﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplorerTreeView.Services
{
    public class FilesVisibility 
        : IFilesVisibility
    {
        public bool ShowFiles { get; set; } = false;
    }
}
