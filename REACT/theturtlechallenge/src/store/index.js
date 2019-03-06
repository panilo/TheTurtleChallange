import { createStore, compose, applyMiddleware } from "redux";
import { gridBoundsMiddleware, gridMinesMiddleware } from "../middlewares/index";
import rootReducer from "../reducers/index";

const storeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
const store = createStore(rootReducer, storeEnhancers(applyMiddleware(gridBoundsMiddleware, gridMinesMiddleware)));

export default store;