import { useRouter } from "next/router";
import Image from "next/image";

function settings() {
  const router = useRouter();
  console.log(router.query.userId); //getting the user ID

  const UserId = router.query.userID;

  // send req for user info and settings

  //change userName function
  const changeUserName = () => {
    //send req to change userName
    console.log("something");
  };

  return (
    <div className="p-3">
      <h1>User</h1>
      <div>
        <div>
          <p>UserName</p>
          <form onSubmit={changeUserName()}>
            <button>Change Username</button>
          </form>
        </div>
        <div>
          <p>UserProfile</p>
          {/* <label>
            <Image src="{userId}/profileImage" alt="should be your profile" />
          </label> */}
        </div>
      </div>
    </div>
  );
}

export default settings;
