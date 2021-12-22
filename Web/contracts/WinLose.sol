pragma solidity ^0.8.9;

contract WinLose {
    uint public playerCount = 0;
    mapping (address => Player) public players;

    struct Player {
        unit256 address;
        int team;
        bool moneyAdded;
    }

    function addPlayer(string memory address, int team, bool moneyAdded){
        players[msg.sender] = Player(msg.sender, address, team, moneyAdded);
        if(playerCount <= 2){
            return;
        } else{
        playerCount +=1;
        }
    }
}
