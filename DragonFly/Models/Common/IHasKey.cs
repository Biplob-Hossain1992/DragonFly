﻿namespace DragonFly.Models.Common
{
    public interface IHasKey<T>
    {
        T Id { get; set; }
    }
}
