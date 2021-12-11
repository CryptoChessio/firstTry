import Link from 'next/link'
export default function Layout({children}){
    return <>
    <nav>
      <Link href="/">
        <a><svg width="24" height="24" xmlns="http://www.w3.org/2000/svg" fill-rule="evenodd" clip-rule="evenodd"><path d="M11.499 12.03v11.971l-10.5-5.603v-11.835l10.5 5.467zm11.501 6.368l-10.501 5.602v-11.968l10.501-5.404v11.77zm-16.889-15.186l10.609 5.524-4.719 2.428-10.473-5.453 4.583-2.499zm16.362 2.563l-4.664 2.4-10.641-5.54 4.831-2.635 10.474 5.775z"/></svg></a>
      </Link>
      <ul>
        <li>
          <Link href="/">
            <a>Home</a>
            </Link>
        </li>
      <li>
        <Link href="/play">
          <a>Play</a>
        </Link>
      </li>
      <li>
        <Link href="/leaderboard">
          <a>Leaderboard</a>
        </Link>
      </li>
      <li>
        <Link href="settings">
          <a>settings</a>
        </Link>
      </li>
    </ul>
    </nav>

      {children}
      </>
}

//
// function Layout({children}){
//   return <p>This is layout<p>
//     {children}}
//
// export default Layout;
