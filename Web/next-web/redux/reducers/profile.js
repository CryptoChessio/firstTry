import { UPDATE_PROFILE } from "../actionTypes";
const initialState = {
    username: "",
    address: "",
};
const profileReducer = (state = initialState, action) => {
    switch (action.type) {
        case UPDATE_PROFILE:
            return {
                ...state,
                username: state.username,
                address: state.address,
            };
        default:
            return state;
    }
};