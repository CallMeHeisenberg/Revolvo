﻿namespace RevolvoCore.Commands.requests
{
    class LogoutRequest
    {
        public const short ID = 7987;

        public const short REQUEST_LOGOUT = 0;  
        public const short ABORT_LOGOUT = 1;

        public short request;

        public void readCommand(byte[] bytes)
        {
            var p = new ByteParser(bytes);
            request = p.readShort();
        }
    }
}
