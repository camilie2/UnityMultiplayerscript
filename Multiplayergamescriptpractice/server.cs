using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

//��Ʈ��ũ�� ����� ��Ƽ�÷��̾� ������ �ƶ����� Ŭ���̾�Ʈ�� ������ ��Ƽ�÷��̾� ������ �����ϰ� �ϱ� ���� �Բ� �ۿ��ϴ� ��ƼƼ�̴�.
//���� : ����ӽ� or Ŭ���� �������� ����Ǵ� ��ǻ�� ���α׷����� ���� ����, ������, ���� �����Ѵ�.
//Ŭ���̾�Ʈ : ���� ���踦 ǥ���ϰ�, �÷��̾� �Է��� ó���ϸ� ������ ����ϴ� ����
//Ŭ���̾�Ʈ�� �̵� �Ǵ� ���۰� ���� �Է¸���� ������ ������ ���� �������� ���Ӽ��迡 ���� ������Ʈ�� ����. ->�÷��̾�� ������ ǥ���Ѵ�.

//*������ Ŭ���̾�Ʈ�� �Է¸���� Ȯ���ϰ�, ������ ������ �����ϸ�, ���� ������ �����Ѵ�.

public class Server : NetworkingManager 
{
	//���� �÷��̾� List 
	private List<PlayerController> players = new List<PlayerController>();

	//Player ����� �����ϴ� script 
	public override void OnServerConnect(NetworkConnection conn)
	{
		Debug.Log("Client connected: " + conn.connectionId);

	//���ο� client ���� �÷��̾� ������Ʈ ��ȯ 
		GameObject player = (GameObject)Instantiate(playerPrefab, Vector3.zero,Quaternion.identity);
		NetworkServer.AddPlayerForConnection(conn,player,0);
		//����� �÷��̾��� ��� �߰�
		player.Add(player.GetComponenet<PlayerController>());


	}
	//Player �񿬰�� �����ϴ� script 
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