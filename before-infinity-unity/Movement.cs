using System;
using UnityEnine; 

public class Movement
{
    public float Speed;

	public Movement(float speed)
	{
        Speed = speed;
	}

    public Vector3 Calculate(Vector3 change, float deltaTime)
    {
        change = change * Speed * deltaTime;
        return change;
    }
}
