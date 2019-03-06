import React from "react";
import {Controls} from "./Controls";
import {Grid} from "./Grid";

export const App = () => {
    return(
        <div className="app-root">
            <Grid />
            <Controls />
        </div>
    );
}