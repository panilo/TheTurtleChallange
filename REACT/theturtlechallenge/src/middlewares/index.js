import { MOVE, OUT_OF_BOUNDS, HIT_MINE } from "../constants/index"
import {getNextPosition} from "../reducers/index"

export function gridBoundsMiddleware(store) {
  return function(next) {

    return function(action) {
      const currentState = store.getState();
      
      if (action.type === MOVE) {
        //Check bounds
        let nextPosition = getNextPosition(currentState.currentPosition, currentState.direction);
        let gridSize = currentState.gridSize;    
                    
        if(nextPosition.X < 0 || nextPosition.Y < 0 
          || nextPosition.X > gridSize.X - 1 || nextPosition.Y > gridSize.Y - 1){
          //Raise action
          return store.dispatch({ type: OUT_OF_BOUNDS });
        }             
      }    

      return next(action);

    };
  };
}

export function gridMinesMiddleware(store) {
  return function(next) {

    return function(action) {
      const currentState = store.getState();
      
      if (action.type === MOVE) {
        //Check bounds
        let nextPosition = getNextPosition(currentState.currentPosition, currentState.direction);        
        let mine = currentState.mines.find(function(m){ return ( (nextPosition.X === m.X) && (nextPosition.Y === m.Y) ); } );

        if(mine){
          //Raise action
          return store.dispatch({ type: HIT_MINE });
        }             
      }    

      return next(action);

    };
  };
}