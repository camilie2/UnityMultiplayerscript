using UnityEngine;
using Mirror;

public class PingManager : NetworkBehaviour
{
  
    [SerializeField] private PlayerStats playerStats = null;

   
    private void Update()
    {
        if (isLocalPlayer)
        {
            int pingTime = NetworkTime.rtt;
            playerStats.ping = pingTime;
        }
    }

    
}
