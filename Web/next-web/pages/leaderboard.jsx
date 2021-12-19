function leaderboard() {
  return (
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
          <tr className="text-slate-50">
          <svg class="w-3" xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13 10V3L4 14h7v7l9-11h-7z" />
</svg>
            <td> TheArctesian </td>
            <td> 69 </td>
            <td> 69 % </td>
            <td> 69 </td>
          </tr>
          <tr className="text-slate-50">
          <svg class="w-3" xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13 10V3L4 14h7v7l9-11h-7z" />
</svg>
            <td> meow </td>
            <td> 49 </td>
            <td> 49 % </td>
            <td> 49 </td>
          </tr>
          <tr className="text-slate-50">
          <svg class="w-3" xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13 10V3L4 14h7v7l9-11h-7z" />
</svg>
            <td> meow </td>
            <td> 49 </td>
            <td> 49 % </td>
            <td> 49 </td>
          </tr>
          <tr className="text-slate-50">
          <svg class="w-3" xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13 10V3L4 14h7v7l9-11h-7z" />
</svg>
            <td> meow </td>
            <td> 49 </td>
            <td> 49 % </td>
            <td> 49 </td>
          </tr>
        </table>
      </div>
    </div>
  );
}

export default leaderboard;
