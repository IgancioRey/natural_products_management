﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalProducts.Management.Persistence.Settings
{
    public class MongoDBSettings
    {

        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string ProductCollection { get; set; } = null!;

    }
}