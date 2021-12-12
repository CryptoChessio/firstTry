import { useRouter } from "next/router";

function settings() {
  const router = useRouter();
  console.log(router.query.userId); //getting the user ID

  const UserId = router.query.userID;

  // send req for user info and settings

  return (
    <div className="p-3">
      <h1>settings</h1>
      <p>
        lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec euismod
      </p>
    </div>
  );
}

export default settings;
