﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoringLogic.Interface
{
    public interface IPrint
    {
        void PrintData(List<Aircraft> data);
    }
}
