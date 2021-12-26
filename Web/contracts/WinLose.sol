pragma solidity ^0.8.9;

contract WinLose {

    struct Player {
        int team;
        bool moneyAdded;
    }

    uint public playerCount = 0;
    mapping (address => Player) public players;

    function addPlayer(string memory address, int team, bool moneyAdded){
        players[msg.sender] = Player(msg.sender, address, team, moneyAdded);
        if(playerCount <= 2){
            return;
        } else{
        playerCount +=1;
        }
    }

    function getCandidate(uint id) external view returns (string memory name, uint voteCount) {
  name = candidateLookup[id].name;
  voteCount = candidateLookup[id].voteCount;
  }
}


