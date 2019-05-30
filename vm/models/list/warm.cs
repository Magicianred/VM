﻿namespace vm.models.list
{
    public class warm : Instruction
    {
        public warm() : base(InsID.warm, 0xA) { }
        public override ulong Assembly()  // 0xABCDEFE
            => (ulong)((OPCode << 24) | (0xB << 20) | (0xC << 16) | (0xD << 12) | (0xE << 8) | (0xF << 4) | 0xE);
    }
}