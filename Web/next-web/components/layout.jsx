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
  const { userName, address } = useSelector((state) => state.profile);
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
      <nav className=" navbar navbar-defaultflex">
        <Link href="/">
          <a>
            <svg width="24" height="24">
              <path d="M11.499 12.03v11.971l-10.5-5.603v-11.835l10.5 5.467zm11.501 6.368l-10.501 5.602v-11.968l10.501-5.404v11.77zm-16.889-15.186l10.609 5.524-4.719 2.428-10.473-5.453 4.583-2.499zm16.362 2.563l-4.664 2.4-10.641-5.54 4.831-2.635 10.474 5.775z" />
            </svg>
          </a>
        </Link>
        <ul className="list-none flex">
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
      </nav>
      {children}
    </>
  );
}
