import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from "react-redux";
import store from "./store/index";

import {Grid} from './components/Grid';
import "./style.css";

ReactDOM.render(
    <Provider store={store}>
        <Grid />
    </Provider>,
    document.getElementById('root')
);