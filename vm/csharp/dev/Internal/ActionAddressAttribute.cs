﻿namespace vm.dev.Internal
{
    using System;
    [AttributeUsage(AttributeTargets.Method)]
    public class ActionAddressAttribute : Attribute
    {
        public short Address { get; }
        public ActionAddressAttribute(short address) => Address = address;
    }
}