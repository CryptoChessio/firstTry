import * as types from "../types";

const main = (
    state = {
        userInfo: {
            userName: "name",
        },
    },
    action
) => {
    switch (action.type) {
        case types.SET_USER_INFO:
            return {
                ...state,
                userInfo: { userName: action.payload },
            };
        default:
            return state;
    }
};

export default main;