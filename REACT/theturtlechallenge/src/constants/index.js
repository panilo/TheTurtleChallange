//### ACTIONS ###
export const ROTATE = "ROTATE"
export const MOVE = "MOVE"
export const OUT_OF_BOUNDS = "OUT_OF_BOUNDS"
export const HIT_MINE = "HIT_MINE"

//### ENUMS ###
export const Direction = {
    North: 0, 
    East: 1, 
    South: 2, 
    West: 3
};

export const TurtleStatus = {
    StillInDanger: 0, 
    HitMine: 1, 
    OutOfBounds: 2, 
    Exit: 3
};