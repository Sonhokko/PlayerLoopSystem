# PlayerLoopSystem
This is my implementation of Unity's built-in game loop customization system.

## Important
Be warned this version is not secure as it has not been properly tested. 
This is just a sample that works but I can't be sure of it. 
Therefore, if you are going to use it in your projects, test it first and don't blindly use it.

## Installation
Copy the contents of the repository to your project or use link for install from Package manager
Optionally, you can customize the Assembly defenition. But it's not necessary at all.

## Start
All you have to do is define the system in your Monobehaviour.

```cs
public class MyTemplateClass : MonoBehaviour
{
   private IDisposable subscription;

   private void Start()
   {
      subscription = PlayerLoops.Update.Start(OnUpdate);
   }

   private void OnUpdate()
   {
      Debug.Log("Text test update message");
   }

   private void OnDestroy()
   {
      subscription?.Dispose();
   }
}
```

## More Info
- You can use not only Update. When accessing PlayerLoops, you will be able to see all the methods to use:Update, FixedUpdate etc.
- You can also add to this system if you want to emulate Monobehaviour's game loop without legacy from it.
- If you do not destroy the object. You can call subscribe and dispose in OnEnable/OnDisable
