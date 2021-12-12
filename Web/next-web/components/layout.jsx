import Link from "next/link";
import { useRouter } from "next/router";
import { useEffect, useState } from "react";
export default function Layout({ children }) {
  const [loginState, setLoginState] = useState();

  const login = async () => {};
  return (
    <>
      <nav className=" navbar navbar-default m-10 flex">
        <Link href="/">
          <a>
            <svg
              width="24"
              height="24"
              xmlns="http://www.w3.org/2000/svg"
              fill-rule="evenodd"
              clip-rule="evenodd"
            >
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
            <Link href="settings">
              <a>settings</a>
            </Link>
          </li>
          <li className="ml-2 mr-2">
            <button
              type="button"
              className="bg-blue-500 hover:bg-blue-700 text-white font-bold rounded p-2 -my-2"
              onClick={login}
            >
              Connect To MetaMask
            </button>
          </li>
        </ul>
      </nav>
      <hr />
      {children}
    </>
  );
}

//
// function Layout({children}){
//   return <p>This is layout<p>
//     {children}}
//
// export default Layout;
