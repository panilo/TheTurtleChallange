import {ROTATE, MOVE, Direction} from '../constants/index';

const initialState = {    
    currentPosition: {X:1,Y:1},
    direction:Direction.North
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
            currentPosition: Object.assign({}, state.currentPosition, nextPosition)
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

function getNextPosition(currentPosition, currentDirection){    
    let nextPosition = currentPosition;
        
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