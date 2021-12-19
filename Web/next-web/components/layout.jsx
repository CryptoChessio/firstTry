import Link from "next/link";
import { useRouter } from "next/router";
import { useEffect, useState } from "react";
import { useSelector, useDispatch } from "react-redux";
import { UPDATE_PROFILE } from "react-redux";
// import { profile } from "../redux/reducers/profile";
import Moralis from "moralis";

export default function Layout({ children }) {
  const [UserAddressState, setAddressState] = useState("");
  const [UserNameState, setNameState] = useState("");
  // const { userName, address } = useSelector((state) => state.profile);
  const dispatch = useDispatch();

  useEffect(() => {
    async function login() {
      const user = await Moralis.User.logIn("acct");
      if (user) {
        user.get("profilePic", "username");
      } else {
        alert("sign in w mm");
      }
    }
  });

  async function SignUp() {
    console.log("login called");
    var user = await Moralis.Web3.authenticate();
    if (user) {
      console.log(user);
      user.set("username", { userName });
    }
  }

  async function relogin(address) {
    dispatch({
      type: UPDATE_PROFILE,
      payload: {
        userName: profileJson.userName,
        address: profileJson.address,
      },
    });
  }
  return (
    <>
      <nav className="flex">
        <div className="flex-1 m-5 bg-slate-900">
          <ul className="list-none flex text-center items-center justify-center">
            <li className="ml-2 m">
              <Link href="/">
                <a>Home</a>
              </Link>
            </li>
            <li className="ml-2 mr-2">
              <Link href="/play">
                <a>Play</a>
              </Link>
            </li>
            <li className="ml-2 mr-2">
              <Link href="/leaderboard">
                <a>Leaderboard</a>
              </Link>
            </li>
            <li className="ml-2 mr-2">
              <Link href="/about">
                <a>About</a>
              </Link>
            </li>
            <li className="ml-2 mr-2">
              <button
                type="button"
                className="bg-blue-500 hover:bg-blue-700 text-white font-bold rounded p-2 -my-2"
                // onClick={login}
              >
                Connect To MetaMask
              </button>
            </li>
            <li className="ml-2 mr-2">
              <Link href="/settings/{userID}">
                <a>
                  <img
                    className="bg-gray-200 -m-1"
                    src="https://img.icons8.com/ios-filled/50/000000/apple-settings.png"
                  />{" "}
                </a>
              </Link>
            </li>
          </ul>
        </div>
      </nav>
      {children}
    </>
  );
}
