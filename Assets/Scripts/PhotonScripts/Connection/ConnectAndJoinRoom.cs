using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace PhotonScripts.Connection
{
    public class ConnectAndJoinRoom : MonoBehaviour, IConnectionCallbacks, IMatchmakingCallbacks, ILobbyCallbacks
    {
        [SerializeField] private ServerSettings _serverSettings;
        [SerializeField] private TMP_Text _stateUiText;
        
        private LoadBalancingClient _lbc;

        private const string GAME_MOD_KEY = "gm";
        private const string AI_MOD_KEY = "ai";

        private void Start()
        {
            _lbc = new LoadBalancingClient();
            _lbc.AddCallbackTarget(this);

            if (!_lbc.ConnectUsingSettings(_serverSettings.AppSettings))
                Debug.LogError($"Error! Failed to connect");
        }

        private void Update()
        {
            _lbc?.Service();
            
            if (_lbc == null) return;
           _stateUiText.text = $"State: {_lbc.State.ToString()},\nUserID: {_lbc.UserId}";
        }

        public void OnConnected()
        {
            
        }

        public void OnConnectedToMaster()
        {
            Debug.Log($"OnConnectedToMaster");
           // _lbc.OpJoinRandomRoom();
          
           var roomOptions = new RoomOptions
           {
               MaxPlayers = 12,
               CustomRoomProperties = new Hashtable
               {
                   {GAME_MOD_KEY,1},
               }
           };
           var enterRoomParams = new EnterRoomParams{RoomOptions = roomOptions};
           
           _lbc.OpCreateRoom(enterRoomParams);

        }

        public void OnDisconnected(DisconnectCause cause)
        {
        }

        public void OnRegionListReceived(RegionHandler regionHandler)
        {
        }

        public void OnCustomAuthenticationResponse(Dictionary<string, object> data)
        {
        }

        public void OnCustomAuthenticationFailed(string debugMessage)
        {
        }

        public void OnFriendListUpdate(List<FriendInfo> friendList)
        {
        }

        public void OnCreatedRoom()
        {
            Debug.Log($"OnCreatedRoom");
        }

        public void OnCreateRoomFailed(short returnCode, string message)
        {
        }

        public void OnJoinedRoom()
        {
            Debug.Log($"OnJoinedRoom");
        }

        public void OnJoinRoomFailed(short returnCode, string message)
        {
        }

        public void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log($"OnJoinRandomFailed");
            _lbc.OpCreateRoom(new EnterRoomParams());
        }

        public void OnLeftRoom()
        {
        }

        public void OnJoinedLobby()
        {
        }

        public void OnLeftLobby()
        {
        }

        public void OnRoomListUpdate(List<RoomInfo> roomList)
        {
        }

        public void OnLobbyStatisticsUpdate(List<TypedLobbyInfo> lobbyStatistics)
        {
        }
        
        private void OnDestroy()
        {
            _lbc.RemoveCallbackTarget(this);
        }
    }
}
