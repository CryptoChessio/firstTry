import Image from 'next/image'
import Polygon from '../images/Icons/polygon.png'
import bat from '../images/Icons/bat.png'
import DAI from '../images/Icons/DAI.png'
function About() {
  return (
    <div className="m-3 text-slate-700 ">
      <h2 className="text-white tracking-wide text-2xl m-3 tracking-wide">
        Tokenomics
      </h2>

      <div className="list-none text-center items-center justify-center flex shadow-xl">
        <div className="bg-gradient-to-r from-yellow-500 to-yellow-200 rounded-lg p-5 m-2">
          <Image
            src={DAI}
            alt="DAI"
            width={50}
            height={50}
            className="fill-white duration-700 ease-in-out hover:rotate-90"
          />
          <p>
            <strong className="text-xl">DAI</strong>
            <br />
            DAI is a decentralized stablecoin that is pegged to the USD.
          </p>
        </div>
        <div className="bg-gradient-to-r from-indigo-400 to-indigo-800 rounded-lg p-5 m-2 shadow-xl">
          <Image
            src={Polygon}
            alt="polygon"
            width={50}
            height={50}
            className="fill-white duration-700 ease-in-out  hover:rotate-180"
          />
          <p>
            <strong className="text-xl">MATIC</strong>
            <br />
            MATIC (Polygon) is the utility token for the Matic network a layer 2
            scaling protocol for the ethereum blockchain.
          </p>
        </div>
        <div className=" bg-gradient-to-r from-orange-500 to-violet-700 rounded-lg p-5 m-2 shadow-xl">
          <Image
            src={bat}
            alt="BAT"
            width={50}
            height={50}
            className="fill-white duration-700 ease-in-out hover:rotate-90"
          />
          <p>
            <strong className="text-xl">BAT</strong>
            <br />
            BAT is the utility token for the Brave browser.
          </p>
        </div>
      </div>
    </div>
  )
}

export default About
