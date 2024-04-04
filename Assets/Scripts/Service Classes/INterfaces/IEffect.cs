﻿using NUnit.Framework;
using System.Collections.Generic;

public interface IEffect
{
    public bool Effect(Unit unit = null);
    public void EndEffect(Unit unit = null);
}

