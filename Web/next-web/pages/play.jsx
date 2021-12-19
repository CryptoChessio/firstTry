function play() {
  return (
    <div className="p-3">
      <h2 className="text-2xl m-4 tracking-wide">GameModes</h2>
      <div className="list-none text-center items-center justify-center flex">
        <div className="bg-teal-600 rounded-lg p-5 m-2">
          <h1>Normal</h1>
          <p className="text-blue-900">Buy in 1 DAI</p>
        </div>
        <div className="bg-cyan-600 rounded-lg p-5 m-2">
          <h1>4 players no time limit</h1>
          <p className="text-blue-900">Buy in 1 BAT</p>
        </div>
        <div className="bg-indigo-500 rounded-lg p-5 m-2">
        <h1>4D Chess (coming soon)</h1>
          <p className="text-indigo-900">Buy in 1 MATIC</p>
        </div>
      </div>
    </div>
  );
}

export default play;
