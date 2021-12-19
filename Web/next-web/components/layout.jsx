import Link from "next/link";
import Image from "next/image";
import { useEffect, useState } from "react";
import { useSelector, useDispatch } from "react-redux";
import { useMoralis } from "react-moralis";
import settingsSVG from "../images/Settings/Settings.svg";

export default function Layout({ children }) {
  const [userID, setUserID] = useState();
  const [UserNameState, setNameState] = useState();
  const dispatch = useDispatch();
  const { authenticate, isAuthenticated, logout, user } = useMoralis();
  // when authenticated, set the user address and name
  useEffect(() => {
    if (user) {
      setUserID(user.get("ethAddress"));
      setNameState(user.get("username"));
    }
    console.log(userID);
  });

  return (
    <>
      <nav className="flex">
        <div className="flex-1 m-5 bg-slate-900">
          <ul className="list-none flex text-center items-center justify-center">
            <li className="mx-5 border-solid border-2 border-indigo-600 rounded p-3 duration-700 ease-in-out  hover:border-indigo-200">
              <Link href="/">
                <a>Home</a>
              </Link>
            </li>
            <li className="mx-5 border-solid border-2 border-indigo-600 rounded p-3 duration-700 ease-in-out  hover:border-indigo-200">
              <Link href="/play">
                <a>Play</a>
              </Link>
            </li>
            <li className="mx-5 border-solid border-2 border-indigo-600 rounded p-3 duration-700 ease-in-out  hover:border-indigo-200">
              <Link href="/leaderboard">
                <a>Leaderboard</a>
              </Link>
            </li>
            <li className="mx-5 border-solid border-2 border-indigo-600 rounded p-3 duration-700 ease-in-out  hover:border-indigo-200">
              <Link href="/about">
                <a>About</a>
              </Link>
            </li>
            <li className="mx-5">
<<<<<<< HEAD
              {isAuthenticated ? (
                <button
                  onClick={logout}
                  className="bg-transparent hover:bg-indigo-600 text-orange-300 font-semibold hover:text-white py-2 px-4 border border-indigo-600 hover:border-transparent rounded"
                >
                  Logout
                  <p className="text-xs">{user.get("ethAddress")}</p>
                </button>
              ) : (
                <button
                  type="button"
                  className="bg-orange-500  hover:bg-blue-700 text-white font-bold rounded p-2 -my-2"
                  onClick={() => {
                    authenticate({ provider: "metamask" });
                  }}
                >
                  Connect To MetaMask
                </button>
              )}
=======
              <button
                type="button"
                className="bg-orange-400 hover:bg-blue-900 text-white font-bold rounded p-2 -my-2"
                // onClick={login}
              >
                Connect To MetaMask
              </button>
>>>>>>> 81b203e0dd3c4b31e759cffb662eab9cacc5331f
            </li>
            <li className="mx-5">
              <Link href="/settings/{userID}">
                <a>
                  <Image
                    className="fill-white duration-700 ease-in-out hover:rotate-180"
                    alt="settings"
                    width={28}
                    height={28}
                    src={settingsSVG}
                  />
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
