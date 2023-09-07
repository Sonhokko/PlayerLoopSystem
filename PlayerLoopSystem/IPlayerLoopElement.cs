using System;

public interface IPlayerLoopElement
{ 
    IDisposable Start(Action updatable);
}
