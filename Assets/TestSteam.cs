﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;
using UnityEngine.Networking;
using System;

public class TestSteam : MonoBehaviour {

    protected Callback<GameOverlayActivated_t> m_GameOverlayActivated;
    private CallResult<NumberOfCurrentPlayers_t> m_NumberOfCurrentPlayers;


    public Callback<GameRichPresenceJoinRequested_t> m_JoinRequest;

    // Use this for initialization
    void Start () {
        if (SteamManager.Initialized)
        {
            string name = SteamFriends.GetPersonaName();
            Debug.Log(name);

            int friendCount = SteamFriends.GetFriendCount(EFriendFlags.k_EFriendFlagImmediate);
            Debug.Log("[STEAM-FRIENDS] Listing " + " Friends.");
            for (int i = 0; i < friendCount; ++i)
            {
                CSteamID friendSteamId = SteamFriends.GetFriendByIndex(i, EFriendFlags.k_EFriendFlagImmediate);
                string friendName = SteamFriends.GetFriendPersonaName(friendSteamId);
                EPersonaState friendState = SteamFriends.GetFriendPersonaState(friendSteamId);
                if (friendState != EPersonaState.k_EPersonaStateOffline)
                {
                    Debug.Log(friendName + " is " + friendState);

                    //if (friendName.Contains("[NoSound]Mysterisk"))
                    //{
                    //    SteamFriends.InviteUserToGame(friendSteamId, "Haha");
                    //    Debug.Log("Set invite to:" + friendName);
                    //}
                }


                FriendGameInfo_t tinfo;
                if (SteamFriends.GetFriendGamePlayed(friendSteamId, out tinfo))
                {
                    //CGameID gID = tinfo.m_gameID;

                    //SteamGameServer.get


                }

            }
        }
    }

    private void OnEnable()
    {
        if (SteamManager.Initialized)
        {
            m_GameOverlayActivated = Callback<GameOverlayActivated_t>.Create(OnGameOverLayActivated);
            m_NumberOfCurrentPlayers = CallResult<NumberOfCurrentPlayers_t>.Create(OnNumberOfCurrentPlayers);
            m_JoinRequest = Callback<GameRichPresenceJoinRequested_t>.Create(JoinRequest);
            
        }
    }

    private void JoinRequest(GameRichPresenceJoinRequested_t param)
    {
        Debug.Log(param.m_rgchConnect);
        Debug.Log("Recvd invite");
    }

    private void OnGameOverLayActivated(GameOverlayActivated_t pCallback)
    {
        if (pCallback.m_bActive != 0)
        {
            Debug.Log("Steam Overlay has been activated");
        }
        else
        {
            Debug.Log("Steam Overlay has been closed");
        }
    }

    private void OnNumberOfCurrentPlayers(NumberOfCurrentPlayers_t pCallback, bool bIOFailure)
    {
        if (pCallback.m_bSuccess != 1 || bIOFailure)
        {
            Debug.Log("There was an error retrieving the NumberOfCurrentPlayers.");
        }
        else
        {
            Debug.Log("The number of players playing your game: " + pCallback.m_cPlayers);
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SteamAPICall_t handle = SteamUserStats.GetNumberOfCurrentPlayers();
            m_NumberOfCurrentPlayers.Set(handle);
            Debug.Log("Called GetNumberOfCurrentPlayers()");

            // Check hijack join



        }

        
    }
}