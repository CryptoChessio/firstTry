import Image from "next/image";

function About() {
  return (
    <div className="m-3 text-slate-700 ">
      <h2 className="text-white text-xl tracking-wide">Tokenomics</h2>

      <div className="list-none text-center items-center justify-center flex">
        <div className="bg-teal-500 rounded-lg p-5 m-2">
          <p>
            <strong>DAI</strong>
            <br />
            DAI is a decentralized stablecoin that is pegged to the USD.
          </p>
        </div>
        <div className="bg-cyan-500 rounded-lg p-5 m-2">
          <p>
            <strong>MATIC</strong>
            <br />
            MATIC (Polygon) is the utility token for the Matic network a layer 2
            scaling protocol for the ethereum blockchain.
          </p>
        </div>
        <div className="bg-indigo-500 rounded-lg p-5 m-2">
          <p>
            <strong>BAT</strong>
            <br />
            BAT is the utility token for the brave browser
          </p>
        </div>
      </div>
      <h2>How to play</h2>
    </div>
  );
}

export default About;
