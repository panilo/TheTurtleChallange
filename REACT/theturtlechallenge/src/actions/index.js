import {ROTATE, MOVE} from "../constants/index";

export function moveTurtle() { //Last position
    return { type: MOVE }
};

export function rotateTurtle() { //Last direction
    return { type: ROTATE }
};