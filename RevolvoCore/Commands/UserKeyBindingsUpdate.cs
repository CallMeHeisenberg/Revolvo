﻿using System.Collections.Generic;

namespace RevolvoCore.Commands
{
    class UserKeyBindingsUpdate
    {
        public const short ID = 23508;

        public List<UserKeyBindingsModule> changedKeyBindings;
        public bool remove;

        public UserKeyBindingsUpdate() { }

        public UserKeyBindingsUpdate(List<UserKeyBindingsModule> changedKeyBindings, bool remove)
        {
            this.changedKeyBindings = changedKeyBindings;
            this.remove = remove;
        }

        public void readCommand(byte[] bytes)
        {
            var parse = new ByteParser(bytes);
            var times = parse.readInt();
            changedKeyBindings = new List<UserKeyBindingsModule>();
            for (var i = 0; i < times; i++)
            {
                var binding = new UserKeyBindingsModule();
                binding.readCommand(parse);
                changedKeyBindings.Add(binding);
            }

            remove = parse.readBool();
        }

        public byte[] write()
        {
            var cmd = new ByteArray(ID);
            cmd.Integer(changedKeyBindings.Count);
            foreach (UserKeyBindingsModule loc in changedKeyBindings)
            {
                cmd.AddBytes(loc.write());
            }
            cmd.Boolean(remove);
            return cmd.ToByteArray();
        }
    }
}