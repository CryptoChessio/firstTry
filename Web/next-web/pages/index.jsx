import Image from "next/image";

function HomePage() {
  return (
    <div className="p-3">
      <h1>home</h1>
      <Image
        alt="Hero Home Page"
        src="/Assets/Home/HomeHero.svg"
        layout="fill"
      />
    </div>
  );
}

export default HomePage;
