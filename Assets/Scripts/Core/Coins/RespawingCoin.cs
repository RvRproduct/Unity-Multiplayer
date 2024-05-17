using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawingCoin : Coin
{

    public event Action<RespawingCoin> onCollected;

    private Vector3 previousPosition;

    private void Update()
    {
        if (previousPosition != transform.position)
        {
            Show(true);
        }

        previousPosition = transform.position;
        
    }

    public override int Collect()
    {  
        if (!IsServer) 
        {
            Show(false);
            return 0;
        }

        if (alreadyCollected) { return 0; }

        alreadyCollected = true;

        onCollected?.Invoke(this);

        return coinValue;
    }

    public void Reset()
    {
        alreadyCollected = false;
    }
}
