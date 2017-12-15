using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class lobby : NetworkLobbyManager
{

	
	void Start ()
    {
        MMStart();
        MMListMatches();
	}
	
	void MMStart ()
    {
        Debug.Log("mmstart");
        this.StartMatchMaker();
	}

    void MMListMatches()
    {
        Debug.Log("mmlistmatch");
        this.matchMaker.ListMatches(0, 10, "", true, 0, 0, OnMatchList);
    }

    public override void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matchList)
    {
        Debug.Log("onmatchlist");
        base.OnMatchList(success, extendedInfo, matchList);

        if(!success)
            Debug.Log("list failed: " + extendedInfo);
        else if(matchList.Count > 0)
        {
            Debug.Log("success. list match: " + matchList[0]);
            MMJoinMatch(matchList[0]);
        }
        else
        {
            MMCreateMatch();
        }
    }

    void MMJoinMatch(MatchInfoSnapshot firstMatch)
    {
        Debug.Log("mmjoinmatch");
        this.matchMaker.JoinMatch(firstMatch.networkId, "", "", "", 0, 0, OnMatchJoined);
    }

    public override void OnMatchJoined(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        Debug.Log("onmatchjoined");
        base.OnMatchJoined(success, extendedInfo, matchInfo);

        if(!success)
            Debug.Log("join failed: " + extendedInfo);
        else
        {
            Debug.Log("successfully joined: " + matchInfo.networkId);
        }
    }

    void MMCreateMatch()
    {
        Debug.Log("mmcreatematch");
        this.matchMaker.CreateMatch("MM", 4, true, "", "", "", 0, 0, OnMatchCreate);
    }

    public override void OnMatchCreate(bool success, string extendedInfo, MatchInfo matchInfo)
    {
        Debug.Log("onmatchcreate");
        base.OnMatchCreate(success, extendedInfo, matchInfo);

        if(!success)
            Debug.Log("failed to create: " + extendedInfo);
        else
        {
            Debug.Log("successfully created: " + matchInfo.networkId);

        }
    }
}
