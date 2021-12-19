import * as type from "../types";
export const setInfo = () => {
    return {
        type: SET_USER_INFO,
        payload: userName,
    };
};