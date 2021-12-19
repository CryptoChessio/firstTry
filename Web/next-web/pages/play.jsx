function play() {
  return (
    <div className="p-3">
      <h2 className="text-2xl">GameModes</h2>
      <div className="list-none text-center items-center justify-center flex">
        <div className="bg-teal-500 rounded-lg p-5 m-2">
          <h1>Normal</h1>
          <p>Buy in 1 DAI</p>
        </div>
        <div className="bg-cyan-500 rounded-lg p-5 m-2">
          <h1>4 player no time limit</h1>
          <p>Buy in 1 BAT</p>
        </div>
        <div className="bg-indigo-500 rounded-lg p-5 m-2">
          <h1>4D Chess (coming soon)</h1>
          <p>Buy in 1 MATIC</p>
        </div>
      </div>
    </div>
  );
}

export default play;
