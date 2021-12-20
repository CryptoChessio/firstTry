pragma solidity ^0.8.9;

contract WinLose {

    event PlayerWin(address Player, uint amount); //event for player win
    event StartGame(address player1, addPlayer2, uint amount); //event for game start
    address public player1; //address of player 1
    address public player2; //address of player 2
    address public mod = 0x2630ce05769Eb216a24Be24988D3872942aeAe3d; //cryptochess public wallet
    mapping (address => uint) public balances;

    

    function start(address player1, address player2, uint pool) {
        if(pool == 2){
            emit StartGame(player1, player2, pool)
        }
    }

    modifier addToPool() {
        
    }
    function addPlayer(address memory player1, address memory player2) public {
        player1 = player1;
        player2 = player2;
    }
}
