import {ROTATE, MOVE, Direction, TurtleStatus, OUT_OF_BOUNDS, HIT_MINE} from '../constants/index';

const initialState = {    
    currentPosition: {X:0,Y:0},
    direction:Direction.North,
    turtleStatus:TurtleStatus.StillInDanger,
    mines:[{X:2,Y:1},{X:0,Y:3},{X:4,Y:1}],
    gridSize:{X:5,Y:4}
};

function rootReducer(state = initialState, action) {
    
    if(action.type === ROTATE){
        //Get next direction
        let nextDirection = getNextDirection(state.direction);                
        return Object.assign({}, state, {
            direction: nextDirection
        });        
    }

    if(action.type === MOVE){
        //Get next position
        let nextPosition = getNextPosition(state.currentPosition, state.direction)
        return Object.assign({}, state, {            
            currentPosition: Object.assign({}, state.currentPosition, nextPosition),
            turtleStatus: TurtleStatus.StillInDanger
        });  
    }

    if(action.type === OUT_OF_BOUNDS){
        return Object.assign({}, state, {            
            turtleStatus: TurtleStatus.OutOfBounds
        });  
    }

    if(action.type === HIT_MINE){
        return Object.assign({}, state, {            
            turtleStatus: TurtleStatus.HitMine
        }); 
    }

    return state;
};

function getNextDirection(currentDirection){
    if(currentDirection > 2)
        return 0;
    else    
        return currentDirection + 1;
}

export function getNextPosition(currentPosition, currentDirection){    
    let nextPosition = Object.assign({}, currentPosition);
        
    if (currentDirection === Direction.North)
    {                
        nextPosition.Y = currentPosition.Y - 1;
    }

    if (currentDirection === Direction.South)
    {                
        nextPosition.Y = currentPosition.Y + 1;
    }

    if (currentDirection === Direction.East)
    {
        nextPosition.X = currentPosition.X + 1;             
    }

    if (currentDirection === Direction.West)
    {
        nextPosition.X = currentPosition.X - 1;
    }

    return nextPosition;
}

export default rootReducer;