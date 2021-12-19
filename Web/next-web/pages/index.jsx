import Image from "next/image";
import Hero from "../images/Home/Hero.svg";
function HomePage() {
  return (
    <div className="p-3">
      <Image
        src={Hero}
        alt="home hero"
        width={1400}
        height={700}
        className="z-1"
      />
    </div>
  );
}

export default HomePage;
