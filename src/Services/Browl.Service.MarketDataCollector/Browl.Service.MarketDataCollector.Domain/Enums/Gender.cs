<<<<<<< HEAD
﻿namespace Browl.Service.MarketDataCollector.Domain.Enums;

public enum Gender
{
	M = 1,
	F = 2,
=======
﻿using System.ComponentModel;

namespace Browl.Service.MarketDataCollector.Domain.Enums;

public enum Gender
{

    [Description("Female")]
    F = 1,
    [Description("Male")]
    M = 2,
>>>>>>> dev
}