using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

//네트워크로 연결된 멀티플레이어 게임의 맥락에서 클라이언트와 서버는 멀티플레이어 게임을 가능하게 하기 위해 함께 작용하는 엔티티이다.
//서버 : 전용머신 or 클라우드 서버에서 실행되는 컴퓨터 프로그램으로 게임 세계, 물리학, 로직 관리한다.
//클라이언트 : 게임 세계를 표시하고, 플레이어 입력을 처리하며 서버와 통신하는 역할
//클라이언트는 이동 또는 동작과 같은 입력명령을 서버로 전송한 다음 서버에서 게임세계에 대한 업데이트를 수신. ->플레이어에게 게임을 표시한다.

//*서버는 클라이언트의 입력명령을 확인하고, 공정한 실행을 보장하며, 부정 행위를 방지한다.

public class Server : NetworkingManager 
{
	//연결 플레이어 List 
	private List<PlayerController> players = new List<PlayerController>();

	//Player 연결시 접속하는 script 
	public override void OnServerConnect(NetworkConnection conn)
	{
		Debug.Log("Client connected: " + conn.connectionId);

	//새로운 client 위해 플레이어 오브젝트 소환 
		GameObject player = (GameObject)Instantiate(playerPrefab, Vector3.zero,Quaternion.identity);
		NetworkServer.AddPlayerForConnection(conn,player,0);
		//연결된 플레이어의 사람 추가
		player.Add(player.GetComponenet<PlayerController>());


	}
	//Player 비연결시 접속하는 script 
	public override void OnServerDisconnect(NetworkConnection conn)
	{
		Debug.Log("Client disconnected: " + conn.connectionID);

		PlayerController player - player.Find(p => p.connectionToClient == conn);
		players.Remove(player);

		NetworkServer.Destroy(player.gameObject);

	}

	public override void OnStopServer() {
        base.OnStopServer();
        Debug.Log("Server stopped");
    }

   
    public override void OnUpdateServer() {
        base.OnUpdateServer();

        foreach (PlayerController player in players) {
            Vector3 position = player.transform.position;
            Quaternion rotation = player.transform.rotation;
            NetworkServer.SendToAll(1, new PlayerPositionMessage(player.connectionToClient.connectionId, position, rotation));
        }
    }









}