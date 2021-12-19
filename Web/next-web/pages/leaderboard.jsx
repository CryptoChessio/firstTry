function leaderboard() {
  return (
    <div className="p-3">
      <h1> Leader Board </h1>
      <div className="m-auto my-5 bg-indigo-500 p-5 rounded-lg mx-32  ">
        <table className="m-auto">
          <tr className="text-teal-500">
            <th> UserName </th>
            <th> Played </th>
            <th> Win( % ) </th>
            <th> Earned(BAT) </th>
          </tr>
          <tr className="text-slate-50">
            <td> TheArctesian </td>
            <td> 69 </td>
            <td> 69 % </td>
            <td> 69 </td>
          </tr>
        </table>
      </div>
    </div>
  );
}

export default leaderboard;
