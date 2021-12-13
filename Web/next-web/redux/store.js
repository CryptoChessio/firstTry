import { createStore, combineReducers } from "redux";
import profileReducer from "./reducers/profile";
const rootReducer = combineReducers({
    profile: profileReducer,
});
export const store = createStore(
    rootReducer,
    typeof window !== "undefined" &&
    window.__REDUX_DEVTOOLS_EXTENSION__ &&
    window.__REDUX_DEVTOOLS_EXTENSION__()
);