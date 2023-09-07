using UnityEngine.PlayerLoop;

public static class PlayerLoops
{
    public static readonly IPlayerLoopElement PreUpdate = new PlayerLoopSystem<PreUpdate>();
    public static readonly IPlayerLoopElement Update = new PlayerLoopSystem<Update>();
    public static readonly IPlayerLoopElement FixedUpdate = new PlayerLoopSystem<FixedUpdate>();
    public static readonly IPlayerLoopElement PreLateUpdate = new PlayerLoopSystem<PreLateUpdate>();
    public static readonly IPlayerLoopElement PostLateUpdate = new PlayerLoopSystem<PostLateUpdate>();
}
