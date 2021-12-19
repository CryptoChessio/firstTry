pragma solidity ^0.8.9;

contract HelloWorld {

    string public message;
    
    constructor (string memory message) public {
        
    }
    function hello() public pure returns (string memory) {
        return "hello world";
    }
}
