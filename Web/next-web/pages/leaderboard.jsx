function leaderboard() {
  return (
    <>
      <div className="p-3">
        <h1 className="text-2xl m-3 tracking-wide"> Leaderboard </h1>
        <div className="bg-gradient-to-r from-indigo-600 to-blue-1000 rounded-lg">
          <table className="w-full whitespace-nowrap">
            <tr className="text-blue-400">
              <th> </th>
              <th> UserName </th>
              <th> Played </th>
              <th> Win ( % ) </th>
              <th> Earned (BAT) </th>
            </tr>
            <tr>
              <td> TheArctesian </td>
              <td> 69 </td>
              <td> 69 % </td>
              <td> 69 </td>
            </tr>
            <tr className="text-slate-50">
              <td> meow </td>
              <td> 49 </td>
              <td> 49 % </td>
              <td> 49 </td>
            </tr>
            <tr className="text-slate-50">
              <td> meow </td>
              <td> 49 </td>
              <td> 49 % </td>
              <td> 49 </td>
            </tr>
            <tr className="text-slate-50">
              <td> meow </td>
              <td> 49 </td>
              <td> 49 % </td>
              <td> 49 </td>
            </tr>
          </table>
        </div>
      </div>
    </>
  )
}

export default leaderboard
