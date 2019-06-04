using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public interface IUnityService
{
    float GetDeltaTime();
    float GetAxisRaw(string axisName);
}
public class UnityService: IUnityService
{

    public float GetDeltaTime()
    {
        return Time.deltaTime;
    }
    public float GetAxisRaw(string axisName)
    {
        return CrossPlatformInputManager.GetAxisRaw(axisName);
    }
}