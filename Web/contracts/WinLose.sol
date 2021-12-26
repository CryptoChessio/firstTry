pragma solidity ^0.8.9;

contract WinLose {

    struct Player {
        int id;
        int team;
        bool win;
        bool moneyAdded;
    }

    uint public playerCount = 0;
    mapping (address => Player) public players;

    function addPlayer(string memory, int team, bool moneyAdded){
        players[msg.sender] = Player(msg.sender, address, team, moneyAdded);
        if(playerCount <= 2){
            return;
        } else{
        playerCount +=1;
        }
    }

    function getPlayer(uint id) external view returns (string memory name, uint voteCount) {
        name = [id].name;
        voteCount = candidateLookup[id].voteCount;
  }
}


