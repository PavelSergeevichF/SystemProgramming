using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerView : NetworkBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;
    private GameObject playerCharacter;

    private void Start()
    {
        //SpawnCharacter();
    }

    public void SpawnCharacter()
    {
        if (!isServer)
        {
            return;
        }
        playerCharacter = Instantiate(playerPrefab);
        NetworkServer.SpawnWithClientAuthority(playerCharacter,connectionToClient);
    }
}
