// using System.Collections;
// using System.Numerics;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class ERC1155balanceOfBlueSphere : MonoBehaviour
// {
//     public GameObject NFT;
//     private BigInteger balanceOf;
//     async void Start()
//     {
//         string chain = "polygon";
//         string network = "testnet";
//         string contract = "0x2953399124f0cbb46d2cbacd8a89cf0599974963";
//         string account = PlayerPrefs.GetString("Account");
//         string tokenId = "34052697030098104870503300278835492448340531213250745283529521091668804108289";

//         balanceOf = await ERC1155.BalanceOf(chain, network, contract, account, tokenId);
//         print(balanceOf);
//     }

//     public void Selection()
//     {
//         if (balanceOf > 0)
//         {
//             if (NFT.activeInHierarchy == false)
//             {
//                 NFT.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
//                 NFT.SetActive(true);
//             } else
//             {
//                 return;
//             }
//         }
//     }

//     public void FindNFT()
//     {
//         if (NFT.activeInHierarchy == true)
//         {
//             NFT.SetActive(false);
//         } else
//         {
//             return;
//         }
//     }
// }