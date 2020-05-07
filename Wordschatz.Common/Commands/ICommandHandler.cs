﻿namespace Wordschatz.Common.Commands
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        void Execute(T command);
    }
}